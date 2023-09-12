Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Configuration
Imports Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.IO
Imports System.Drawing.Point
Imports Microsoft.Office.Interop
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraPrinting.Export.Pdf
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports System.Drawing.Printing
Imports System.Text
Imports System.Net.Mail
Imports AccesoDatos
Imports Funciones

Public Class erp_ctrl_import_doh_lines
    Dim FechaMin As DateTime
    Dim sql, planner As String
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim dialog As New OpenFileDialog
        Dim path As String
        Dim ConnExcel As New OleDb.OleDbConnection
        Dim Cmd As New OleDb.OleDbCommand
        Dim Da As New OleDb.OleDbDataAdapter
        Dim Ds As New DataSet
        Dim Dset As New DataSet
        Dim fecha As String
        Dim conn As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ObjExcel As Excel.ApplicationClass
        Dim ObjW As Excel.WorkbookClass
        Dim nomHoja As String
        fecha = ""
        Try
            dialog.InitialDirectory = "C:\"
            dialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*"
            If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path = dialog.FileName
                ObjExcel = New Excel.ApplicationClass
                ObjW = ObjExcel.Workbooks.Open(path)
                nomHoja = ObjW.Sheets(1).Name
                ObjW.Close()
                ObjExcel.Quit()
                ConnExcel.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & "; Extended Properties= Excel 8.0;"
                Cmd.CommandText = "SELECT * FROM [" & nomHoja & "$]"
                Cmd.Connection = ConnExcel
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Ds.Tables(0).TableName = "Excel"
                GridControl1.DataSource = Ds.Tables(0)
                conn.ConnectionString = var_conexionERP
                comm.CommandType = CommandType.Text
                comm.Connection = conn
                conn.Open()
                SimpleButton3.Visible = True
                SimpleButton1.Visible = False
                SimpleButton8.Visible = False
                GV1.ExpandAllGroups()
                GV1.BestFitColumns()
                GV1.Columns("Alias_Line").OptionsColumn.AllowEdit = False
                GV1.Columns("Customer_id").OptionsColumn.AllowEdit = False
                GV1.Columns("Comments").OptionsColumn.AllowEdit = False
                GV1.Columns("Info_Date").OptionsColumn.AllowEdit = False
                SimpleButton2.Visible = False

            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub erp_ctrl_import_doh_lines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FechaMin As DateTime
        FechaMin = Now.ToShortDateString
        dt_fecha.Properties.MinValue = FechaMin.AddDays(-1)
        dt_fecha.Properties.MaxValue = FechaMin.AddDays(1)
        DateEdit1.Properties.MinValue = FechaMin.AddDays(-1)
        DateEdit1.Properties.MaxValue = FechaMin.AddDays(1)
        Dim ds As New DataSet
        CargaFechas()
        sql = "Select planner_id from  ERP_CTRL_PLANNER where planner_descr = '" & var_adm_Usr_NICK & "'"
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            planner = ds.Tables(0).Rows(0)(0).ToString.Trim
            planner = planner.Substring(1, 2)
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Usuario No se encuentra en la Base de Datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub CargaFechas()
        Dim ds As New DataSet
        Try
            sql = "select distinct  Info_Date from  ERP_CTRL_DOH_ACTIVATE_DATE "
            ds = Consulta_Datos(sql, var_conexionERP)
            cb_info_dt.Properties.DisplayMember = "Info_Date"
            cb_info_dt.Properties.ValueMember = "Info_Date"
            cb_info_dt.Properties.DataSource = ds.Tables(0)

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Try
            Dim FechaActual As Date
            FechaActual = Now.ToShortDateString
            Dim Customer, Line, doh, comments, Info_date, sql As String
            For I = 0 To GV1.RowCount - 1
                Line = GV1.GetRowCellValue(I, "Alias_Line").ToString
                Customer = GV1.GetRowCellValue(I, "Customer_id").ToString
                doh = GV1.GetRowCellValue(I, "DOH").ToString
                comments = GV1.GetRowCellValue(I, "Comments").ToString
                Info_date = GV1.GetRowCellValue(I, "Info_Date").ToString
                If Info_date = FechaActual Then
                    sql = "select Nombre_Formal from ERP_CTRL_LINES Where Nombre_comun = '" & Line & "'"
                    If Existe_Dato(sql, var_conexionERP) Then
                        sql = "INSERT INTO ERP_CTRL_DOH_LINES_TMP VALUES('" & Line & "','" & Customer & "', '" & doh & "' , '" & comments & "','" & Info_date & "' ) "
                        Executa_Query(sql, var_conexionERP)
                    Else
                        sql = "select sews_part_no from ERP_CTRL_XREF Where sews_part_no = '" & Line & "' and Customer_id = '" & Customer & "'"
                        If Existe_Dato(sql, var_conexionERP) Then
                            sql = "INSERT INTO ERP_CTRL_DOH_LINES_TMP VALUES('" & Line & "','" & Customer & "', '" & doh & "' , '" & comments & "','" & Info_date & "' ) "
                            Executa_Query(sql, var_conexionERP)
                        Else
                            DevExpress.XtraEditors.XtraMessageBox.Show("Linea o Numero de Parte no se encuentra en CND, No se Realizara la Importacion ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '' LIMPIAR GRID Y PONER EL BOTON DE GARGAR Y DESAPARECER EL BOTON GUARDAR 
                            sql = "DELETE FROM  ERP_CTRL_DOH_LINES_TMP"
                            Executa_Query(sql, var_conexionERP)
                            GV1.Columns.Clear()
                            SimpleButton1.Visible = True
                            SimpleButton3.Visible = False
                            Exit Sub
                        End If
                    End If
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Fecha de Excel no pertenece a la Actual", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Guardados Correctamente", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '' LIMPIAR GRID Y PONER BOTON DE GARGAR Y DESAPARECER EL DE GUARDAR 
            sql = "INSERT INTO ERP_CTRL_DOH_LINES SELECT * FROM ERP_CTRL_DOH_LINES_TMP"
            Executa_Query(sql, var_conexionERP)
            sql = "DELETE FROM  ERP_CTRL_DOH_LINES_TMP"
            Executa_Query(sql, var_conexionERP)
            sql = "Select  * from ERP_CTRL_DOH_ACTIVATE_DATE WHERE Info_date = '" & FechaActual & "' and Planner = '" & planner & "'"
            If Existe_Dato(sql, var_conexionERP) Then
                sql = "update ERP_CTRL_DOH_ACTIVATE_DATE set  Activo = '0' where Info_date = '" & FechaActual & "' and Planner  = '" & planner & "'"
                Executa_Query(sql, var_conexionERP)
            Else
                sql = "INSERT INTO ERP_CTRL_DOH_ACTIVATE_DATE VALUES('" & FechaActual & "','0','" & planner & "') "
                Executa_Query(sql, var_conexionERP)
            End If
            GV1.Columns.Clear()
            SimpleButton3.Visible = False
            SimpleButton1.Visible = True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SimpleButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton5.Click
        Try
            Dim fecha As String = cb_info_dt.Text
            Dim activar As String = fecha.Substring(0, 10)
            sql = "update dbo.ERP_CTRL_DOH_ACTIVATE_DATE set Activo = '1' where Info_date = '" & activar & "' "
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Fecha Activada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SimpleButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton6.Click
        Try
            SimpleButton2.Visible = True
            SimpleButton8.Visible = True
            If dt_fecha.Text <> "" Then
                'sql = "select a.Alias_Line , a.Customer_id , a.DOH ,Comments , Info_Date  from ERP_CTRL_DOH_LINES a left join erp_ctrl_lines b on a.Alias_Line = b.Nombre_comun " & _
                '" left join ERP_CTRL_XREF c on  b.Line_c = c.Line_c  where Info_Date = ' " & dt_fecha.Text.Trim & "' and c.Planner = '" & planner & "' and Active <> 0   group By A.Alias_Line,a.Customer_id ,a.DOH ,a.Comments , a.Info_Date"
                sql = "select a.Alias_Line , a.Customer_id , a.DOH ,Comments , Info_Date  from ERP_CTRL_DOH_LINES a left join erp_ctrl_lines b on a.Alias_Line = b.Nombre_comun " & _
                " left join ERP_CTRL_XREF c on  b.Line_c = c.Line_c  where Info_Date = ' " & dt_fecha.Text.Trim & "' and c.Planner = '" & planner & "' and Active <> 0   group By A.Alias_Line,a.Customer_id ,a.DOH ,a.Comments , a.Info_Date " & _
                " UNION ALL  select a.Alias_Line , a.Customer_id , a.DOH ,Comments , Info_Date  from ERP_CTRL_DOH_LINES a  left join ERP_CTRL_XREF c on  a.Alias_Line = c.sews_part_no " & _
                " and a.Customer_id=c.Customer_id where Info_Date = ' " & dt_fecha.Text.Trim & "' and c.Planner = '" & planner & "' and Active <> 0  and a.Alias_Line not in  (select a.Alias_Line  from ERP_CTRL_DOH_LINES a left join " & _
                " erp_ctrl_lines b on a.Alias_Line = b.Nombre_comun  left join ERP_CTRL_XREF c on  b.Line_c = c.Line_c  where Info_Date = ' " & dt_fecha.Text.Trim & "' and c.Planner = '" & planner & "' and Active <> 0  " & _
                " group By A.Alias_Line,a.Customer_id ,a.DOH ,a.Comments , a.Info_Date)  group By A.Alias_Line,a.Customer_id ,a.DOH ,a.Comments , a.Info_Date"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                GridControl1.DataSource = ds.Tables(0)
                GV1.ExpandAllGroups()
                GV1.BestFitColumns()
                GV1.Columns("Alias_Line").OptionsColumn.AllowEdit = False
                GV1.Columns("Customer_id").OptionsColumn.AllowEdit = False
                'GV1.Columns("Comments").OptionsColumn.AllowEdit = False
                GV1.Columns("Info_Date").OptionsColumn.AllowEdit = False
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim FechaActual As Date
        FechaActual = Now.ToShortDateString
        Dim Customer, Line, doh, comments, sql As String
        For I = 0 To GV1.RowCount - 1
            Line = GV1.GetRowCellValue(I, "Alias_Line").ToString
            Customer = GV1.GetRowCellValue(I, "Customer_id").ToString
            doh = GV1.GetRowCellValue(I, "DOH").ToString
            comments = GV1.GetRowCellValue(I, "Comments").ToString
            sql = "INSERT INTO ERP_CTRL_DOH_LINES VALUES('" & Line & "','" & Customer & "', '" & doh & "' , '" & comments & "','" & FechaActual & "' ) "
            Executa_Query(sql, var_conexionERP)
            sql = "Select  * from ERP_CTRL_DOH_ACTIVATE_DATE WHERE Info_date = '" & FechaActual & "' and Planner = '" & planner & "'"
            If Existe_Dato(sql, var_conexionERP) Then
                sql = "update ERP_CTRL_DOH_ACTIVATE_DATE set  Activo = '0' where Info_date = '" & FechaActual & "' and Planner  = '" & planner & "'"
                Executa_Query(sql, var_conexionERP)
            Else
                sql = "INSERT INTO ERP_CTRL_DOH_ACTIVATE_DATE VALUES('" & FechaActual & "','0','" & planner & "') "
                Executa_Query(sql, var_conexionERP)
            End If
        Next
        DevExpress.XtraEditors.XtraMessageBox.Show("Datos Guardados Correctamente", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GV1.Columns.Clear()
        SimpleButton2.Visible = False
    End Sub

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Try
            If DateEdit1.Text <> "" Then
                sql = "select  c.FG_Plant as Plant ,a.Alias_Line , a.Customer_id , a.DOH ,Comments , Info_Date  from ERP_CTRL_DOH_LINES a left join erp_ctrl_lines b on a.Alias_Line = b.Nombre_comun " & _
                " left join ERP_CTRL_XREF c on  b.Line_c = c.Line_c  where Info_Date = '" & DateEdit1.Text.Trim & "'  and Active <> 0   group By   c.FG_Plant ,A.Alias_Line,a.Customer_id ,a.DOH ,a.Comments , a.Info_Date" & _
                " union all  select  c.FG_Plant , a.Alias_Line , a.Customer_id , a.DOH ,Comments , Info_Date  from ERP_CTRL_DOH_LINES a  left join ERP_CTRL_XREF c on  a.Alias_Line =sews_part_no " & _
                " and a.Customer_id = c.Customer_id  where Info_Date = '" & DateEdit1.Text.Trim & "'  and Active <> 0  group By  c.FG_Plant , A.Alias_Line,a.Customer_id ,a.DOH ,a.Comments , a.Info_Date "
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                GridControl2.DataSource = ds.Tables(0)
                GridView1.ExpandAllGroups()
                GridView1.BestFitColumns()
                GridView1.Columns("Alias_Line").OptionsColumn.AllowEdit = False
                GridView1.Columns("Customer_id").OptionsColumn.AllowEdit = False
                'GV1.Columns("Comments").OptionsColumn.AllowEdit = False
                GridView1.Columns("Info_Date").OptionsColumn.AllowEdit = False
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton4.Click
        If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim FechaActual As Date
            FechaActual = Now.ToShortDateString
            Dim Customer, Line, doh, comments, Info_date, sql As String
            For I = 0 To GridView1.RowCount - 1
                Line = GridView1.GetRowCellValue(I, "Alias_Line").ToString
                Customer = GridView1.GetRowCellValue(I, "Customer_id").ToString
                doh = GridView1.GetRowCellValue(I, "DOH").ToString
                comments = GridView1.GetRowCellValue(I, "Comments").ToString
                Info_date = GridView1.GetRowCellValue(I, "Info_Date").ToString
                sql = "update dbo.ERP_CTRL_DOH_LINES  set DOH = '" & doh & "' , Comments = '" & comments & "' where Alias_Line = '" & Line & "' and Customer_id = '" & Customer & "' and Info_date = '" & Info_date & "'"
                Executa_Query(sql, var_conexionERP)
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SimpleButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton8.Click
        If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim Customer, Line, doh, comments, Info_date, sql As String
            For I = 0 To GV1.RowCount - 1
                Line = GV1.GetRowCellValue(I, "Alias_Line").ToString
                Customer = GV1.GetRowCellValue(I, "Customer_id").ToString
                doh = GV1.GetRowCellValue(I, "DOH").ToString
                comments = GV1.GetRowCellValue(I, "Comments").ToString
                Info_date = GV1.GetRowCellValue(I, "Info_Date").ToString
                sql = "update dbo.ERP_CTRL_DOH_LINES  set DOH = '" & doh & "' , Comments = '" & comments & "' where Alias_Line = '" & Line & "' and Customer_id = '" & Customer & "' and Info_date = '" & Info_date & "'"
                Executa_Query(sql, var_conexionERP)
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
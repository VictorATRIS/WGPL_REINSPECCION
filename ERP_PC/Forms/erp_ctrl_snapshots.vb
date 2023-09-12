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
Imports AccesoDatos
Imports Funciones
Public Class erp_ctrl_snapshots
    Dim sql, planner As String
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim dialog As New OpenFileDialog
        Dim path As String
        Dim ConnExcel As New OleDb.OleDbConnection
        Dim Cmd As New OleDb.OleDbCommand
        Dim Da As New OleDb.OleDbDataAdapter
        Dim Ds As New DataSet
        Dim Dset As New DataSet
        Dim conn As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ObjExcel As Excel.ApplicationClass
        Dim ObjW As Excel.WorkbookClass
        Dim nomHoja As String
        Dim FechaActual As Date
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
                Cmd.CommandText = "SELECT *  FROM [" & nomHoja & "$]"
                Cmd.Connection = ConnExcel
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Ds.Tables(0).TableName = "Excel"
                GridControl2.DataSource = Ds.Tables(0)
                conn.ConnectionString = var_conexionERP
                comm.CommandType = CommandType.Text
                comm.Connection = conn
                conn.Open()
                FechaActual = Now
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    sql = "DELETE FROM  ERP_CTRL_SNAPSHOTS_TMP"
                    Executa_Query(sql, var_conexionERP)
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_SNAPSHOTS_TMP VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(11).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(12).ToString.Trim & "'," & _
                        " '" & Ds.Tables(0).Rows(i)(13).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(14).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(15).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(16).ToString.Trim & "' ,'" & Ds.Tables(0).Rows(i)(17).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(18).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(19).ToString.Trim & "'," & _
                        " '" & Ds.Tables(0).Rows(i)(20).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(21).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(22).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(23).ToString.Trim & "' ,'" & Ds.Tables(0).Rows(i)(24).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(25).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(26).ToString.Trim & "'," & _
                        " '" & Ds.Tables(0).Rows(i)(27).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(28).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(29).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(30).ToString.Trim & "' ,'" & Ds.Tables(0).Rows(i)(31).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(32).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(33).ToString.Trim & "'," & _
                        " '" & Ds.Tables(0).Rows(i)(34).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(35).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(36).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(37).ToString.Trim & "' ,'" & Ds.Tables(0).Rows(i)(38).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(39).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(40).ToString.Trim & "'," & _
                        " '" & Ds.Tables(0).Rows(i)(41).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(42).ToString.Trim & "', '" & FechaActual & "', '" & planner & "' )"
                        comm.ExecuteNonQuery()
                    Next i
                    sql = "select distinct convert(date,ATR_LOAD_DATE) from ERP_CTRL_SNAPSHOTS_TMP"
                    Dim dr As New DataSet
                    dr = Consulta_Datos(sql, var_conexionERP)
                    If dr.Tables(0).Rows.Count > 0 Then
                        FechaActual = dr.Tables(0).Rows(0)(0).ToString.Trim
                        sql = "select * from ERP_CTRL_SNAPSHOTS where convert(date,ATR_LOAD_DATE) = '" & FechaActual & "' "
                        If Existe_Dato(sql, var_conexionERP) Then
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ya existen Registros en Fecha Actual, Se Cancelara la Importacion", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            sql = "DELETE FROM  ERP_CTRL_SNAPSHOTS_TMP"
                            Executa_Query(sql, var_conexionERP)
                            GridView1.Columns.Clear()
                        Else
                            sql = "DELETE FROM  ERP_CTRL_SNAPSHOTS"
                            Executa_Query(sql, var_conexionERP)
                            sql = "INSERT INTO ERP_CTRL_SNAPSHOTS SELECT * FROM ERP_CTRL_SNAPSHOTS_TMP"
                            Executa_Query(sql, var_conexionERP)
                            sql = "DELETE FROM  ERP_CTRL_SNAPSHOTS_TMP"
                            Executa_Query(sql, var_conexionERP)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            GridView1.Columns.Clear()
                        End If
                    Else
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub erp_ctrl_snapshots_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaFechas()
        sql = "Select planner_id from  ERP_CTRL_PLANNER where planner_descr = '" & var_adm_Usr_NICK & "'"
        Dim ds As New DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            planner = ds.Tables(0).Rows(0)(0).ToString.Trim
            planner = planner.Substring(1, 2)
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Usuario No se encuentra en la Base de Datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Try
            sql = "delete from ERP_CTRL_SNAPSHOTS_VERTICAL"
            Executa_Query(sql, var_conexionERP)
            ' sql = "Insert into ERP_CTRL_SNAPSHOTS_vertical SELECT Cust_part_no, Cust_Design_Level, Supplier_ID, Base_Part_No, Base_Design_Level, ASN_Origin , Location , Qty , LOADDATE as Info_date " & _
            ' "FROM     ERP_CTRL_SNAPSHOTS unpivot ( Qty for Location in ( IT_TO_ACS0, INV_ACS0,  IT_TO_CCS0, INV_CCS0, IT_TO_CCS2, INV_CCS2, IT_TO_LEX0, INV_LEX0, IT_TO_MSC0, INV_MSC0,  IT_TO_OCS0, INV_OCS0, IT_TO_SCSC, INV_SCSC " & _
            ' " ,IT_TO_TCSC, INV_TCSC, IT_TO_TDC0, INV_TDC0, IT_TO_YAS0, INV_YAS0) ) as p where convert(date,LOADDATE) = '" & cb_info_dt.Text.Trim & "' and Qty > 0"

            sql = "SP_CTRL_INSERTA_SNAPSHOT_VERTICAL_FECHA '" & cb_info_dt.Text.Trim & "'"
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CargaFechas()
        Dim ds As New DataSet
        Try
            sql = "select  distinct LOADDATE FROM ERP_CTRL_SNAPSHOTS "
            ds = Consulta_Datos(sql, var_conexionERP)
            cb_info_dt.Properties.DisplayMember = "LOADDATE"
            cb_info_dt.Properties.ValueMember = "LOADDATE"
            cb_info_dt.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Dim Lunes, anterior As DateTime


        sql = "select convert(date,DATEADD(WK,DATEDIFF(WK,0,GETDATE()),0))"
        Dim ds As New DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            Lunes = ds.Tables(0).Rows(0)(0).ToString.Trim
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Fecha no existe", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        sql = "SELECT CONVERT(DATE,DATEADD(d,-1,GETDATE()))"
        Dim dt As New DataSet
        dt = Consulta_Datos(sql, var_conexionERP)
        If dt.Tables(0).Rows.Count > 0 Then
            anterior = dt.Tables(0).Rows(0)(0).ToString.Trim
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Fecha no existe", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        sql = "SP_CTRL_INSERT_DETAIL_SNAPSHOTS '" & Lunes & "','" & anterior & "'"
        Executa_Query(sql, var_conexionERP)

        sql = "select c.Type_desc  as Line , e.Nombre_comun as Alias , d.Car_description as Vehicle , a.Cust_part_no + a.Customer_id as Cust_Part_no_Customer_ID , f.planner_descr , a.Cust_part_no , a.Base_Part_no ,a.Base_Design_Level ,a.Customer_id, a.Inv_whse , a.Location , a.Inventory " & _
        "from ERP_CTRL_SNAPSHOTS_DETAIL  a LEFT JOIN ERP_CTRL_XREF b ON rtrim(ltrim(a.Cust_part_no)) =  rtrim(ltrim(b.cust_part_no))  " & _
        "and rtrim(ltrim(a.Customer_id)) = rtrim(ltrim(b.Customer_id))  and replace(rtrim(ltrim(a.Base_Design_Level)),' ','')= rtrim(ltrim(b.DL)) " & _
        "left join erp_ctrl_product_type c on  b.Product_type = c.Type_cd left join ERP_CTRL_VEHICLES d on  d.Car_cd = b.Vehicle  left join erp_Ctrl_lines e on b.Line_c = e.Line_c left join ERP_CTRL_PLANNER f on f.planner_id = b.planner " & _
        "where a.Inv_whse <> 'BackOrder'  union all  " & _
        "select c.Type_desc  as Line , e.Nombre_comun as Alias , d.Car_description as Vehicle , a.Cust_part_no + a.Customer_id as Cust_Part_no_Customer_ID , f.planner_descr  , a.Cust_part_no , a.Base_Part_no ,a.Base_Design_Level ,a.Customer_id, a.Inv_whse , a.Location , a.Inventory " & _
        "from ERP_CTRL_SNAPSHOTS_DETAIL  a LEFT JOIN ERP_CTRL_XREF b ON rtrim(ltrim(a.Cust_part_no)) =   rtrim(ltrim(b.cust_part_no))" & _
        "and rtrim(ltrim(a.Customer_id)) = rtrim(ltrim(b.Customer_id))  " & _
        "left join erp_ctrl_product_type c on  b.Product_type = c.Type_cd left join ERP_CTRL_VEHICLES d on  d.Car_cd = b.Vehicle  left join erp_Ctrl_lines e on b.Line_c = e.Line_c  left join ERP_CTRL_PLANNER f on f.planner_id = b.planner  where a.Inv_whse = 'BackOrder' and b.Active = '1' "


        ds = Consulta_Datos(sql, var_conexionERP)
        GridControl3.DataSource = ds.Tables(0)
        GridView3.ExpandAllGroups()
        GridView3.BestFitColumns()
        Cursor = Cursors.Default
        Dim _excel As New Application
        Dim re = 2
        If ds.Tables(0).Rows.Count > 0 Then
            Dim Nombre_Excel = "LNP_Honda_Toyota_Sistema.xlsx"
            'Dim _wBook As Workbook = _excel.Workbooks.Open(System.Windows.Forms.Application.StartupPath & "\Documents\ATRWorkingDays4MF.xlsx")

            Dim _wBook As Workbook = _excel.Workbooks.Open(String.Format("{0}\LNP_Honda_Toyota_Sistema.xlsx", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)))
            Dim _sheet As Worksheet = DirectCast(_wBook.Worksheets("Detail"), Worksheet)
            For i = 0 To ds.Tables(0).Rows.Count - 1
                _sheet.Range("A" & re).Value = ds.Tables(0).Rows(i)("Line")
                _sheet.Range("B" & re).Value = ds.Tables(0).Rows(i)("Alias")
                _sheet.Range("C" & re).Value = ds.Tables(0).Rows(i)("Vehicle")
                _sheet.Range("D" & re).Value = ds.Tables(0).Rows(i)("Cust_Part_no_Customer_ID")
                _sheet.Range("E" & re).Value = ds.Tables(0).Rows(i)("planner_descr")
                _sheet.Range("F" & re).Value = ds.Tables(0).Rows(i)("Cust_part_no")
                _sheet.Range("G" & re).Value = ds.Tables(0).Rows(i)("Base_Part_no")
                _sheet.Range("H" & re).Value = ds.Tables(0).Rows(i)("Base_Design_Level")
                _sheet.Range("I" & re).Value = ds.Tables(0).Rows(i)("Customer_id")
                _sheet.Range("J" & re).Value = ds.Tables(0).Rows(i)("Inv_whse")
                _sheet.Range("K" & re).Value = ds.Tables(0).Rows(i)("Location")
                _sheet.Range("L" & re).Value = ds.Tables(0).Rows(i)("Inventory")
                re = re + 1
            Next
            Dim Nuevo_nombre As String = "LNP_Honda_Toyota_Sistema"
            _excel.Workbooks.Item(1).Saved = True
            _excel.Workbooks.Item(1).SaveAs(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Nuevo_nombre + ".xlsx")

            If Not _excel Is Nothing Then
                _excel.Quit()
                _excel = Nothing
            End If
            System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Nuevo_nombre + ".xlsx")
        End If


        'ds = Consulta_Datos(sql, var_conexionERP)
        'GridControl3.BindingContext = New System.Windows.Forms.BindingContext()
        'GridControl3.DataSource = Nothing
        'GridView3.Columns.Clear()
        'GridControl3.DataSource = ds.Tables(0)
        'GridControl3.ExportToXls(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\SNAPSHOTSDETAIL.xls")
        'System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\SNAPSHOTSDETAIL.xls")
        'Cursor = Cursors.Default
    End Sub

    Private Sub XtraTabPage2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles XtraTabPage2.Paint

    End Sub


End Class
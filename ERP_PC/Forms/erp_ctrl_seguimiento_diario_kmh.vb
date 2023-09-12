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
Imports Funciones
Imports AccesoDatos


Public Class erp_ctrl_seguimiento_diario_kmh
    Dim sql, planner As String
    Private Sub erp_ctrl_seguimiento_diario_kmh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CargaRevisiones()
            CargaRevisionesM()
            CargaActiva()
            CargaActivaM()
            CargaPlantas()
            'CargaSection()
            Dim ds As New DataSet
            Dim FechaMin As DateTime
            Dim FechaMax As DateTime
            FechaMin = Now.ToShortDateString
            sql = "SELECT convert(date,DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))"
            ds = Consulta_Datos(sql, var_conexionERP)
            FechaMin = ds.Tables(0).Rows(0)(0).ToString
            dt_fecha.Properties.MinValue = FechaMin

            FechaMax = Now.ToShortDateString
            sql = "select EOMONTH(getdate())"
            ds = Consulta_Datos(sql, var_conexionERP)
            FechaMax = ds.Tables(0).Rows(0)(0).ToString
            dt_fecha.Properties.MaxValue = FechaMax

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
        Dim Actual As String
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
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Sql = "DELETE FROM  ERP_CTRL_4MF_Daily_tmp"
                    Executa_Query(Sql, var_conexionERP)
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_4MF_Daily_tmp VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "' )"
                        comm.ExecuteNonQuery()
                    Next i
                    sql = "select distinct Rev from ERP_CTRL_4MF_Daily_tmp"
                    Dim dr As New DataSet
                    dr = Consulta_Datos(Sql, var_conexionERP)
                    If dr.Tables(0).Rows.Count > 0 Then
                        Actual = dr.Tables(0).Rows(0)(0).ToString.Trim
                        sql = "select * from ERP_CTRL_4MF_Daily where Rev = '" & Actual & "' "
                        If Existe_Dato(Sql, var_conexionERP) Then
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ya existen Registros con la misma Revision, Se Cancelara la Importacion", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            sql = "DELETE FROM  ERP_CTRL_4MF_Daily_tmp"
                            Executa_Query(Sql, var_conexionERP)
                            GridView1.Columns.Clear()
                        Else
                            sql = "INSERT INTO ERP_CTRL_4MF_Daily SELECT * FROM ERP_CTRL_4MF_Daily_tmp"
                            Executa_Query(sql, var_conexionERP)
                            sql = "DELETE FROM  ERP_CTRL_4MF_Daily_tmp"
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

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        sql = "select * from  ERP_CTRL_4MF_KMH_REV where Rev = '" & te_rev.Text & "' "
        If Existe_Dato(sql, var_conexionERP) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Ya existe Nombre de la Revision ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            te_rev.Text = ""
        Else
            sql = "insert into ERP_CTRL_4MF_KMH_REV values('" & te_rev.Text & "','0',getdate())"
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Revision registrada con exito", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            te_rev.Text = ""
            CargaRevisiones()
        End If
    End Sub

    Public Sub CargaRevisiones()
        Dim ds As New DataSet
        sql = "select rtrim(ltrim(Rev))as Rev from ERP_CTRL_4MF_KMH_REV where rtrim(ltrim(active)) <> '1' order by rev"
        ds = Consulta_Datos(sql, var_conexionERP)
        LookUp_revision.Properties.DisplayMember = "Rev"
        LookUp_revision.Properties.ValueMember = "Rev"
        LookUp_revision.Properties.DataSource = ds.Tables(0)
        LookUp_revision.EditValue = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub

    Public Sub CargaRevisionesM()
        Dim ds As New DataSet
        sql = "select rtrim(ltrim(Rev))as Rev from ERP_CTRL_4MF_Monthly_Rev where rtrim(ltrim(active)) <> '1' order by rev"
        ds = Consulta_Datos(sql, var_conexionERP)
        lu_monthy_acti.Properties.DisplayMember = "Rev"
        lu_monthy_acti.Properties.ValueMember = "Rev"
        lu_monthy_acti.Properties.DataSource = ds.Tables(0)
        lu_monthy_acti.EditValue = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub

    Public Sub CargaPlantas()
        Dim ds As New DataSet
        sql = "select distinct Planta from ERP_CTRL_4MF_Daily  where rev in (select Rev from ERP_CTRL_4MF_KMH_REV where Active = '1')"
        ds = Consulta_Datos(sql, var_conexionERP)
        up_Plantas.Properties.DisplayMember = "Planta"
        up_Plantas.Properties.ValueMember = "Planta"
        up_Plantas.Properties.DataSource = ds.Tables(0)
        up_Plantas.EditValue = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub

    Public Sub CargaSection()
        Dim ds As New DataSet
        up_section.EditValue = ""
        sql = "select distinct Section from ERP_CTRL_4MF_Daily  where rev in (select Rev from ERP_CTRL_4MF_KMH_REV where Active = '1') and Planta = '" & up_Plantas.Text.Trim & "'"
        ds = Consulta_Datos(sql, var_conexionERP)
        up_section.Properties.DisplayMember = "Section"
        up_section.Properties.ValueMember = "Section"
        up_section.Properties.DataSource = ds.Tables(0)
        up_section.EditValue = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub
    Public Sub CargaKMH()
        Dim ds As New DataSet
        td_kmh.Text = ""
        sql = "select KMH from ERP_CTRL_4MF_Daily  where rev in (select Rev from ERP_CTRL_4MF_KMH_REV where Active = '1') and Planta = '" & up_Plantas.Text.Trim & "' and Section  = '" & up_section.Text.Trim & "' and Date_plan = '" & dt_fecha.Text.Trim & "'"
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            td_kmh.Text = ds.Tables(0).Rows(0)(0).ToString.Trim
        End If
    End Sub

    Public Sub CargaActiva()
        Dim ds As New DataSet
        sql = "select rtrim(ltrim(Rev))as Rev from ERP_CTRL_4MF_KMH_REV where rtrim(ltrim(active)) = '1' order by rev"
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            Label2.Text = ds.Tables(0).Rows(0)(0).ToString.Trim
        Else
        End If
    End Sub

    Public Sub CargaActivaM()
        Dim ds As New DataSet
        sql = "select rtrim(ltrim(Rev))as Rev from ERP_CTRL_4MF_Monthly_Rev where rtrim(ltrim(active)) = '1' order by rev"
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            lb_monthy.Text = ds.Tables(0).Rows(0)(0).ToString.Trim
        Else
        End If
    End Sub

    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton4.Click
        Try
            sql = "update ERP_CTRL_4MF_KMH_REV set active = '0' where rev <> '" & LookUp_revision.Text.Trim & "'"
            Executa_Query(sql, var_conexionERP)
            sql = "update ERP_CTRL_4MF_KMH_REV set active = '1' where rev = '" & LookUp_revision.Text.Trim & "'"
            Executa_Query(sql, var_conexionERP)
            CargaRevisiones()
            CargaActiva()
            DevExpress.XtraEditors.XtraMessageBox.Show("Revision activada con exito", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton5.Click
        Try
            sql = "SP_CTRL_SEGUIMIENTO_KMH_DAILY"
            Dim ds As DataSet
            Dim vApli
            ds = Consulta_Datos(sql, var_conexionERP)
            DataGridView1.BindingContext = New System.Windows.Forms.BindingContext()
            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = ds.Tables(0)
            Dim dA As New DataSet
            sql = "select Planta , Section , KMH from ERP_CTRL_4MF_Monthly where Rev in (select rev from ERP_CTRL_4MF_Monthly_Rev where Active = '1')"
            dA = Consulta_Datos(sql, var_conexionERP)
            DataGridView2.BindingContext = New System.Windows.Forms.BindingContext()
            DataGridView2.DataSource = Nothing
            DataGridView2.Columns.Clear()
            DataGridView2.DataSource = dA.Tables(0)
            sql = "SP_CTRL_SEGUIMIENTO_KMH_DAILY_LINES"
            Dim dr As DataSet
            dr = Consulta_Datos(sql, var_conexionERP)
            DataGridView3.BindingContext = New System.Windows.Forms.BindingContext()
            DataGridView3.DataSource = Nothing
            DataGridView3.Columns.Clear()
            DataGridView3.DataSource = dr.Tables(0)
            'sql = "SP_CTRL_SEGUIMIENTO_KMH_DAILY_LINES_Battery"
            'Dim dy As DataSet
            'dy = Consulta_Datos(sql, var_conexionERP)
            'DataGridView4.BindingContext = New System.Windows.Forms.BindingContext()
            'DataGridView4.DataSource = Nothing
            'DataGridView4.Columns.Clear()
            'DataGridView4.DataSource = dy.Tables(0)
            'Cursor = Cursors.Default
            Dim _excel As New Application
            If ds.Tables(0).Rows.Count > 0 Then
                Dim Nombre_Excel = "KMH_Daily_Follow_Up_Report.xlsx"
                Dim _wBook As Workbook = _excel.Workbooks.Open(String.Format("{0}\KMH_Daily_Follow_Up_Report.xlsx", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)))
                Dim _sheet As Worksheet = DirectCast(_wBook.Worksheets("Tabla_Info"), Worksheet)

                '-----------------------ORIGINAL QUE SI FUNCIONA DESDE LA A ------------------------
                For c As Integer = 0 To DataGridView1.Columns.Count - 1
                    _sheet.Cells(1, c + 1).value = DataGridView1.Columns(c).HeaderText
                Next
                'exportamos las cabeceras de las columna
                For r As Integer = 0 To DataGridView1.RowCount - 1
                    For c As Integer = 0 To DataGridView1.Columns.Count - 1
                        _sheet.Cells(r + 2, c + 1).value = DataGridView1.Item(c, r).Value
                    Next
                Next
                '------------------------------------------------------------------------------------
                Dim _sheet2 As Worksheet = DirectCast(_wBook.Worksheets("4MF_Monthly"), Worksheet)
                For c As Integer = 0 To DataGridView2.Columns.Count - 1
                    _sheet2.Cells(1, c + 1).value = DataGridView2.Columns(c).HeaderText
                Next
                'exportamos las cabeceras de las columna
                For r As Integer = 0 To DataGridView2.RowCount - 1
                    For c As Integer = 0 To DataGridView2.Columns.Count - 1
                        _sheet2.Cells(r + 2, c + 1).value = DataGridView2.Item(c, r).Value
                    Next
                Next
                Dim _sheet3 As Worksheet = DirectCast(_wBook.Worksheets("Info_Lineas"), Worksheet)
                Dim re = 2
                For i = 0 To dr.Tables(0).Rows.Count - 1
                    _sheet3.Range("A" & re).Value = dr.Tables(0).Rows(i)("Vehicle")
                    _sheet3.Range("B" & re).Value = dr.Tables(0).Rows(i)("Line")
                    _sheet3.Range("C" & re).Value = dr.Tables(0).Rows(i)("F_Prod")
                    _sheet3.Range("D" & re).Value = dr.Tables(0).Rows(i)("Planta")
                    _sheet3.Range("E" & re).Value = dr.Tables(0).Rows(i)("No_Parte")
                    _sheet3.Range("F" & re).Value = dr.Tables(0).Rows(i)("Cliente")
                    _sheet3.Range("G" & re).Value = dr.Tables(0).Rows(i)("ATR_Plan")
                    _sheet3.Range("H" & re).Value = dr.Tables(0).Rows(i)("Actual")
                    _sheet3.Range("I" & re).Value = dr.Tables(0).Rows(i)("Dif")
                    _sheet3.Range("J" & re).Value = dr.Tables(0).Rows(i)("Section")
                    _sheet3.Range("K" & re).Value = dr.Tables(0).Rows(i)("SMH")
                    _sheet3.Range("L" & re).Value = dr.Tables(0).Rows(i)("Actual_KMH")
                    _sheet3.Range("M" & re).Value = dr.Tables(0).Rows(i)("Plan_KMH")
                    _sheet3.Range("N" & re).Value = dr.Tables(0).Rows(i)("Diff_KMH")
                    _sheet3.Range("O" & re).Value = dr.Tables(0).Rows(i)("Type_desc")
                    re = re + 1
                Next
                'Dim _sheet4 As Worksheet = DirectCast(_wBook.Worksheets("Info_Battery_Cable"), Worksheet)
                'Dim rr = 2
                'For j = 0 To dy.Tables(0).Rows.Count - 1
                '    _sheet4.Range("A" & rr).Value = dy.Tables(0).Rows(j)("Vehicle")
                '    _sheet4.Range("B" & rr).Value = dy.Tables(0).Rows(j)("Line")
                '    _sheet4.Range("C" & rr).Value = dy.Tables(0).Rows(j)("F_Prod")
                '    _sheet4.Range("D" & rr).Value = dy.Tables(0).Rows(j)("Planta")
                '    _sheet4.Range("E" & rr).Value = dy.Tables(0).Rows(j)("No_Parte")
                '    _sheet4.Range("F" & rr).Value = dy.Tables(0).Rows(j)("Cliente")
                '    _sheet4.Range("G" & rr).Value = dy.Tables(0).Rows(j)("ATR_Plan")
                '    _sheet4.Range("H" & rr).Value = dy.Tables(0).Rows(j)("Actual")
                '    _sheet4.Range("I" & rr).Value = dy.Tables(0).Rows(j)("Dif")
                '    _sheet4.Range("J" & rr).Value = dy.Tables(0).Rows(j)("Section")
                '    _sheet4.Range("K" & rr).Value = dy.Tables(0).Rows(j)("SMH")
                '    _sheet4.Range("L" & rr).Value = dy.Tables(0).Rows(j)("Actual_KMH")
                '    _sheet4.Range("M" & rr).Value = dy.Tables(0).Rows(j)("Plan_KMH")
                '    _sheet4.Range("N" & rr).Value = dy.Tables(0).Rows(j)("Diff_KMH")
                '    _sheet4.Range("O" & rr).Value = dy.Tables(0).Rows(j)("Type_desc")
                '    rr = rr + 1
                'Next
                ''--------------------------------------------------------------------------------------
                'Dim _sheet3 As Worksheet = DirectCast(_wBook.Worksheets("Info_Lineas"), Worksheet)

                'For c As Integer = 0 To DataGridView3.Columns.Count - 1
                '    _sheet3.Cells(1, c + 1).value = DataGridView3.Columns(c).HeaderText
                'Next
                ''exportamos las cabeceras de las columna
                'For r As Integer = 0 To DataGridView3.RowCount - 1
                '    For c As Integer = 0 To DataGridView3.Columns.Count - 1
                '        _sheet3.Cells(r + 2, c + 1).value = DataGridView3.Item(c, r).Value
                '    Next
                'Next
                ''--------------------------------------------------------------------------------------
                'Dim _sheet4 As Worksheet = DirectCast(_wBook.Worksheets("Info_Battery_Cable"), Worksheet)

                'For c As Integer = 0 To DataGridView4.Columns.Count - 1
                '    _sheet4.Cells(1, c + 1).value = DataGridView4.Columns(c).HeaderText
                'Next
                ''exportamos las cabeceras de las columna
                'For r As Integer = 0 To DataGridView4.RowCount - 1
                '    For c As Integer = 0 To DataGridView4.Columns.Count - 1
                '        _sheet4.Cells(r + 2, c + 1).value = DataGridView4.Item(c, r).Value
                '    Next
                'Next
                ''--------------------------------------------------------------------------------------
                Dim Nuevo_nombre As String = "KMH_Daily_Follow_Up_Report_Enviar"
                _excel.Workbooks.Item(1).Saved = True
                _excel.Workbooks.Item(1).SaveAs(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Nuevo_nombre + ".xlsx")
                If Not _excel Is Nothing Then
                    _excel.Quit()
                    _excel = Nothing
                End If
                System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Nuevo_nombre + ".xlsx")
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton6.Click
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
        Dim Actual As String
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
                GridControl1.DataSource = Ds.Tables(0)
                conn.ConnectionString = var_conexionERP
                comm.CommandType = CommandType.Text
                comm.Connection = conn
                conn.Open()
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    sql = "DELETE FROM  ERP_CTRL_4MF_Monthly_tmp"
                    Executa_Query(sql, var_conexionERP)
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_4MF_Monthly_tmp VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "' )"
                        comm.ExecuteNonQuery()
                    Next i
                    sql = "select distinct Rev from ERP_CTRL_4MF_Monthly_tmp"
                    Dim dr As New DataSet
                    dr = Consulta_Datos(sql, var_conexionERP)
                    If dr.Tables(0).Rows.Count > 0 Then
                        Actual = dr.Tables(0).Rows(0)(0).ToString.Trim
                        sql = "select * from ERP_CTRL_4MF_Monthly where Rev = '" & Actual & "' "
                        If Existe_Dato(sql, var_conexionERP) Then
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ya existen Registros con la misma Revision, Se Cancelara la Importacion", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            sql = "DELETE FROM  ERP_CTRL_4MF_Monthly_tmp"
                            Executa_Query(sql, var_conexionERP)
                            GridView2.Columns.Clear()
                        Else
                            sql = "INSERT INTO ERP_CTRL_4MF_Monthly SELECT * FROM ERP_CTRL_4MF_Monthly_tmp"
                            Executa_Query(sql, var_conexionERP)
                            sql = "DELETE FROM  ERP_CTRL_4MF_Monthly_tmp"
                            Executa_Query(sql, var_conexionERP)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            GridView2.Columns.Clear()
                        End If
                    Else
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        sql = "select * from  ERP_CTRL_4MF_Monthly_Rev where Rev = '" & te_monthy_rev.Text & "' "
        If Existe_Dato(sql, var_conexionERP) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Ya existe Nombre de la Revision ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            te_monthy_rev.Text = ""
        Else
            sql = "insert into ERP_CTRL_4MF_Monthly_Rev values('" & te_monthy_rev.Text & "','0',getdate())"
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Revision registrada con exito", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            te_monthy_rev.Text = ""
            CargaRevisionesM()
        End If
    End Sub

    Private Sub SimpleButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton8.Click
        Try
            sql = "update ERP_CTRL_4MF_Monthly_Rev set active = '0' where rev <> '" & lu_monthy_acti.Text.Trim & "'"
            Executa_Query(sql, var_conexionERP)
            sql = "update ERP_CTRL_4MF_Monthly_Rev set active = '1' where rev = '" & lu_monthy_acti.Text.Trim & "'"
            Executa_Query(sql, var_conexionERP)
            CargaRevisionesM()
            CargaActivaM()
            DevExpress.XtraEditors.XtraMessageBox.Show("Revision activada con exito", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub up_Plantas_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up_Plantas.EditValueChanged
        If up_Plantas.Text.Trim = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Planta", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            CargaSection()
        End If
    End Sub

    Private Sub dt_fecha_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha.EditValueChanged
        'If dt_fecha.Text.Trim = "" Then
        'DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Fecha", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Else
        CargaKMH()
        'End If
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        If td_kmh.Text.Trim = "" Then
        Else
            sql = "UPDATE ERP_CTRL_4MF_Daily SET KMH = '" & td_kmh.Text & "' where rev in (select Rev from ERP_CTRL_4MF_KMH_REV where Active = '1') and Planta = '" & up_Plantas.Text.Trim & "' and Section  = '" & up_section.Text.Trim & "' and Date_plan = '" & dt_fecha.Text.Trim & "'"
            Executa_Query(sql, var_conexionERP)

            DevExpress.XtraEditors.XtraMessageBox.Show("KMH Modificado ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)

            dt_fecha.EditValue = ""
            up_section.EditValue = ""
            td_kmh.Text = ""

        End If
    End Sub

    Private Sub XtraTabControl1_Click(sender As Object, e As EventArgs) Handles XtraTabControl1.Click

    End Sub
End Class
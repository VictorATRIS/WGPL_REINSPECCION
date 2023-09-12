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
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.OleDb
Imports Funciones
Imports AccesoDatos
Public Class erp_ctrl_crear_rev_4mf
    Dim sql As String
    Dim fechainicio As New DateTime
    Dim fechafinal As New DateTime
    Dim numefechas As New Integer
    Public Sub CargaRevisiones()

        Dim ds As New DataSet
        Try
            sql = "select rtrim(ltrim(Revision))   Revision from erp_ctrl_plan_rev  order by  type, initdate desc"
            ds = Consulta_Datos(sql, var_conexionERP)
            lu_rev3.Properties.DisplayMember = "Revision"
            lu_rev3.Properties.ValueMember = "Revision"
            lu_rev3.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub erp_ctrl_crear_rev_4mf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            CargaRevisiones()
            CargaRevisionesBase()
            CargaRevisionesGenerar()
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btn_gene_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gene.Click
        Try
            Dim conn As New SqlConnection
            Dim comm As New SqlCommand
            conn.ConnectionString = var_conexionERP
            comm.CommandType = CommandType.Text
            comm.Connection = conn
            conn.Open()
            '' SI YA EXISTE UNA REVISION CON _4MF  SE MOSTRARA LOS DATOS ,
            ''SI NO SE BUSCARA LA REVISION 202007 Y AL MOMENTO DE INSERTAR SE INSERTARAN LAS FECHAS DE ESA REVISION PERO CON EL NOMBRE DE _4MF
            sql = "SELECT * from ERP_CTRL_4MF_Dates where Rev = '" & lu_rev4.Text.Trim & "' "
            'sql = "SELECT * from ERP_CTRL_4MF_Dates where Rev = '" & lu_rev4.Text.Trim + "_4MF" & "' "
            Dim dr As DataSet
            dr = Consulta_Datos(sql, var_conexionERP)
            If dr.Tables(0).Rows.Count > 0 Then
                '' Muestro los archivos 
                GV1.Columns.Clear()
                sql = "select Rev,Date_4MF , Week_4MF , Month_4MF,ATR_Week_WD, ATR_Month_WD from ERP_CTRL_4MF_Dates where rev = '" & lu_rev4.Text.Trim & "' order by Date_4MF"
                'sql = "select Rev,Date_4MF , Week_4MF , Month_4MF,ATR_Week_WD, ATR_Month_WD from ERP_CTRL_4MF_Dates where rev = '" & lu_rev4.Text.Trim + "_4MF " & "' order by Date_4MF"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                GridControl1.DataSource = ds.Tables(0)
                GV1.ExpandAllGroups()
                GV1.BestFitColumns()
                Cursor = Cursors.Default
                GV1.Columns("Rev").OptionsColumn.AllowEdit = False
                GV1.Columns("Date_4MF").OptionsColumn.AllowEdit = False
                ''GV1.Columns("Week_4MF").OptionsColumn.AllowEdit = False
                GV1.Columns("Month_4MF").OptionsColumn.AllowEdit = False
            ElseIf DevExpress.XtraEditors.XtraMessageBox.Show("No existe esta revision en 4MF,Deseas generar  los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                sql = "SELECT * from ERP_CTRL_PLAN_REV where Revision = '" & lu_rev4.Text.Trim & "' "
                Dim de As DataSet
                de = Consulta_Datos(sql, var_conexionERP)
                If de.Tables(0).Rows.Count > 0 Then
                    CargaFechas()
                    While fechainicio <= fechafinal
                        sql = " Insert into ERP_CTRL_4MF_Dates values ('" & lu_rev4.Text.Trim & "','" & fechainicio & "',case WHEN DATEPART(DW,'" & fechainicio & "')=1 THEN dateadd(week,datediff(week,0,'" & fechainicio & "'),-7) else dateadd(week,datediff(week,0,'" & fechainicio & "'),0) end ,DATEADD(MM, DATEDIFF(MM,0,'" & fechainicio & "'), 0),Null,Null,Null)"
                        'sql = " Insert into ERP_CTRL_4MF_Dates values ('" & lu_rev4.Text.Trim + "_4MF" & "','" & fechainicio & "', dateadd(week,datediff(week,0,'" & fechainicio & "' ),0),DATEADD(MM, DATEDIFF(MM,0,'" & fechainicio & "'), 0),Null,Null,Null)"
                        Executa_Query(sql, var_conexionERP)
                        fechainicio = fechainicio.AddDays(1).ToShortDateString
                        sql = "select Rev,Date_4MF , Week_4MF , Month_4MF,ATR_Week_WD, ATR_Month_WD from ERP_CTRL_4MF_Dates where rev = '" & lu_rev4.Text.Trim & "' order by Date_4MF"
                        'sql = "select Rev,Date_4MF , Week_4MF , Month_4MF,ATR_Week_WD, ATR_Month_WD from ERP_CTRL_4MF_Dates where rev = '" & lu_rev4.Text.Trim + "_4MF" & "' order by Date_4MF"
                        Dim da As DataSet
                        da = Consulta_Datos(sql, var_conexionERP)
                        GridControl1.DataSource = da.Tables(0)
                        GV1.ExpandAllGroups()
                        GV1.BestFitColumns()
                        Cursor = Cursors.Default
                        GV1.Columns("Rev").OptionsColumn.AllowEdit = False
                        GV1.Columns("Date_4MF").OptionsColumn.AllowEdit = False
                        'GV1.Columns("Week_4MF").OptionsColumn.AllowEdit = False
                        GV1.Columns("Month_4MF").OptionsColumn.AllowEdit = False
                    End While
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion Generada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("No existe dato Master de Revision", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            Executa_Query(sql, var_conexionERP)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CargaFechas()
        Try
            Dim ds As New DataSet
            sql = "select InitDate from  ERP_CTRL_PLAN_REV where revision = '" & lu_rev4.Text.Trim & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            fechainicio = ds.Tables(0).Rows(0)(0).ToString.Trim
            Dim da As New DataSet
            'sql = "select EndDate from  ERP_CTRL_PLAN_REV where revision = '" & lu_rev4.Text.Trim & "'"
            sql = "select dateadd(dd,125,'" & fechainicio & "')"
            da = Consulta_Datos(sql, var_conexionERP)
            fechafinal = da.Tables(0).Rows(0)(0).ToString.Trim
            Dim df As New DataSet
            '' sql = "SELECT CONVERT(VARCHAR(10),DATEADD(dd,-28,'" & fechafinal & "'),103)"
            'sql = "SELECT DATEADD(dd,-28,'" & fechafinal & "')"
            'df = Consulta_Datos(sql, var_conexionERP)
            'fechafinal = df.Tables(0).Rows(0)(0).ToString.Trim
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            Dim Rev, Date_4MF, week_4MF, Month_4MF, ATR_week_wd, ATR_month_wd, month_change, sql As String
            Rev = lu_rev4.Text.Trim

            If Rev <> "" Then
                If existeEn4MF(Rev) = False Then
                    For I = 0 To GV1.RowCount - 1
                        Date_4MF = GV1.GetRowCellValue(I, "Date_4MF").ToString
                        week_4MF = GV1.GetRowCellValue(I, "Week_4MF").ToString
                        Month_4MF = GV1.GetRowCellValue(I, "Month_4MF").ToString
                        ATR_week_wd = GV1.GetRowCellValue(I, "ATR_Week_WD").ToString
                        ATR_month_wd = GV1.GetRowCellValue(I, "ATR_Month_WD").ToString
                        month_change = GV1.GetRowCellValue(I, "Month_change").ToString
                        'sql = "insert into ERP_CTRL_4MF_Dates values('" & Rev & "','" & ATR_week_wd & " ', ATR_Month_WD = '" & ATR_month_wd & "', Week_4MF = '" & week_4MF & "' where Rev = '" & Rev & "' and Date_4MF = '" & Date_4MF & "'  and Month_4MF = '" & Month_4MF & "'"
                        sql = String.Format("insert into ERP_CTRL_4MF_Dates values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Rev, Date_4MF, week_4MF, Month_4MF, ATR_week_wd, ATR_month_wd, month_change)
                        Executa_Query(sql, var_conexionERP)
                    Next
                    DevExpress.XtraEditors.XtraMessageBox.Show("Se ha registrado la revision ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ya hay datos de la revisión " & Rev & ", no se hizo el registro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Cargue el archivo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub GV1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GV1.RowCellStyle
    End Sub
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        Try
            If lu_rev3.Text <> "" Then
                Dim sql As String
                sql = "select * from  ERP_CTRL_4MF_Dates where  Rev = '" & lu_rev3.Text & "' order by Date_4MF"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                gc_confirmacion.DataSource = ds.Tables(0)
                gv_confirmacion.ExpandAllGroups()
                gv_confirmacion.BestFitColumns()
                Cursor = Cursors.Default
                Dim _excel As New Application
                Dim re = 2
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim Nombre_Excel = "ATRWorkingDays4MF.xlsx"
                    'Dim _wBook As Workbook = _excel.Workbooks.Open(System.Windows.Forms.Application.StartupPath & "\Documents\ATRWorkingDays4MF.xlsx")

                    Dim _wBook As Workbook = _excel.Workbooks.Open(String.Format("{0}\ATRWorkingDays4MF.xlsx", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)))
                    Dim _sheet As Worksheet = DirectCast(_wBook.Worksheets("ERP_CTRL_4MF_Dates"), Worksheet)
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        _sheet.Range("A" & re).Value = ds.Tables(0).Rows(i)("Rev")
                        _sheet.Range("B" & re).Value = ds.Tables(0).Rows(i)("Date_4MF")
                        _sheet.Range("C" & re).Value = ds.Tables(0).Rows(i)("Week_4MF")
                        _sheet.Range("D" & re).Value = ds.Tables(0).Rows(i)("Month_4MF")
                        _sheet.Range("E" & re).Value = ds.Tables(0).Rows(i)("ATR_Week_WD")
                        _sheet.Range("F" & re).Value = ds.Tables(0).Rows(i)("ATR_Month_WD")
                        _sheet.Range("G" & re).Value = ds.Tables(0).Rows(i)("Month_change")
                        re = re + 1
                    Next
                    Dim Nuevo_nombre As String = "ATR_Working_Day_"
                    _excel.Workbooks.Item(1).Saved = True
                    _excel.Workbooks.Item(1).SaveAs(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Nuevo_nombre + lu_rev3.Text + ".xlsx")

                    If Not _excel Is Nothing Then
                        _excel.Quit()
                        _excel = Nothing
                    End If
                    System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Nuevo_nombre + lu_rev3.Text + ".xlsx")
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GV1_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GV1.RowStyle
        Dim View As ColumnView = sender
        Dim col As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("Rev")
        For i As Integer = 0 To GV1.DataRowCount - 1
            If GV1.GetRowCellValue(i, col) <> GV1.GetRowCellValue((i + 7), col) Then
                e.Appearance.BackColor = Color.LightCyan
            End If
            If i = GV1.DataRowCount Then Exit For
        Next
    End Sub
    Public Sub CargaRevisionesBase()
        Dim ds As New DataSet
        Try
            sql = "select distinct Rev from  ERP_CTRL_4MF_Dates"
            ds = Consulta_Datos(sql, var_conexionERP)
            lu_base.Properties.DisplayMember = "Rev"
            lu_base.Properties.ValueMember = "Rev"
            lu_base.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub CargaRevisionesGenerar()
        Dim ds As New DataSet
        Try
            sql = "select rtrim(ltrim(Revision))   Revision from erp_ctrl_plan_rev  order by  type, initdate desc"
            ds = Consulta_Datos(sql, var_conexionERP)
            lu_generar.Properties.DisplayMember = "Revision"
            lu_generar.Properties.ValueMember = "Revision"
            lu_generar.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SimpleButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If lu_base.Text.Trim = "" Then
            lu_base.Focus()
            Exit Sub
        End If
        If lu_generar.Text.Trim = "" Then
            lu_generar.Focus()
            Exit Sub
        End If
        Dim ds As New dataset
        sql = String.Format("SP_CTRL_COPIAR_4MF_DATES '{0}', '{1}' ", lu_base.text.trim, lu_generar.text.trim)
        ds = Consulta_Datos(sql, var_conexionERP)
        sql = "select * from  ERP_CTRL_4MF_Dates where  Rev = '" & lu_generar.Text & "' order by Date_4MF"
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Generados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GridControl2.DataSource = ds.Tables(0)
            GridView1.ExpandAllGroups()
            GridView1.BestFitColumns()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GroupControl3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControl3.Paint

    End Sub

    Private Sub butExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExportarExcel.Click
        Dim dialog As New OpenFileDialog
        GridControl1.DataSource = Nothing
        Try

            'Le decimos al buscador de archivo que solo queremos los archivos tipo Excel
            dialog.Filter = "XLSX files (*.xlsx)|*.xlsx"
            'Verificamos que si se haya seleccionado un archivo
            If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                'Obtenemos la ruta del excel
                Dim ExcelFilePath = dialog.FileName
                'Cargamos el archivo de excel
                Dim conn As New System.Data.OleDb.OleDbConnection(String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=1';", ExcelFilePath))
                conn.Open()
                'Seleccionamos todo lo que haya en la hoja uno del excel
                Dim cmd As New OleDbDataAdapter("Select * FROM [Sheet1$] ", conn)
                cmd.TableMappings.Add("Table", "Table")
                Dim dt As New DataSet
                cmd.Fill(dt)
                'Vaciamos la informacion del excel en la tabla
                GridControl1.DataSource = dt.Tables(0)
                Dim rev As String = GV1.GetRowCellValue(0, "Rev").ToString
                lu_rev4.Text = GV1.GetRowCellValue(0, "Rev").ToString
                Dim columnName1 As String = GV1.Columns(0).Name
                Dim columnName2 As String = GV1.Columns(1).Name
                Dim columnName3 As String = GV1.Columns(2).Name
                If columnName1.Substring(3) = "Rev" And columnName2.Substring(3) = "Date_4MF" And columnName3.Substring(3) = "Week_4MF" Then
                    'Si la revision ya fue cargada en 4mf o aun o ha sido dada de alta no lo va dejara cargar el archivo
                    If existeEnPlanRev(rev) Then
                        If existeEn4MF(rev) Then
                            GridControl1.DataSource = Nothing
                            lu_rev4.Text = ""
                            GV1.Columns.Clear()
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ya hay datos de la revisión " & rev & ", no se importará el archivo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        GridControl1.DataSource = Nothing
                        lu_rev4.Text = ""
                        GV1.Columns.Clear()
                        DevExpress.XtraEditors.XtraMessageBox.Show("La revisión " & rev & " no existe en el master de revisiones, no se importará el archivo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    conn.Close()
                End If
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("El formato del archivo no es el correcto", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If



        Catch ex As Exception
            GridControl1.DataSource = Nothing
            GV1.Columns.Clear()
            lu_rev4.Text = ""
            DevExpress.XtraEditors.XtraMessageBox.Show("No se pudo cargar el archivo. Formato no valido", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub
    Private Function existeEnPlanRev(ByVal numRev As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim ds As New DataSet
            sql = String.Format("select * from erp_ctrl_plan_rev where revision = '{0}'", numRev)
            ds = Consulta_Datos(sql, var_conexionERP)
            If ds.Tables(0).Rows.Count >= 1 Then
                existe = True
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return existe

    End Function
    Private Function existeEn4MF(ByVal numRev As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim ds As New DataSet
            sql = "select * from erp_ctrl_4mf_dates where rev = '" & numRev.Trim & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            If ds.Tables(0).Rows.Count >= 1 Then
                existe = True
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return existe

    End Function

   
End Class
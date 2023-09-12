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
Imports Funciones
Imports AccesoDatos
Public Class erp_ctrl_modificacion_linea
    Dim sql As String

    'Dim dq As DataTable
    Dim planta, codigo, planta2, codigo2 As String
    Dim linea, mfg_plant, fg_plant, sews_part, short_part, custo_id As String
    ''CONSULTO LINEAS POR NOMBRE COMUN 
    Public Sub CargaNombreLineas()
        Dim ds As New DataSet
        Try
            sql = "select Line_c    from ERP_CTRL_LINES where  Nombre_comun = '" & up_nombre_comun.Text & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            lu_nombrelinea.Properties.DataSource = ds.Tables(0)
            lu_nombrelinea.Properties.DisplayMember = "Line_c"

            cargardatos()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub CargaNombreLineas1()
        Dim ds As New DataSet
        Try
            sql = "select  Nombre_comun,Nombre_Formal    from ERP_CTRL_LINES"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_nombre_comun.Properties.DataSource = ds.Tables(0)
            up_nombre_comun.Properties.DisplayMember = "Nombre_comun"

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Cargarplantas()
        Dim ds As New DataSet
        Try
            sql = "select Codes,Plant   from ERP_CTRL_CODES_PLANT"
            ds = Consulta_Datos(sql, var_conexionERP)
            cb_dual.Properties.DataSource = ds.Tables(0)
            cb_dual.Properties.DisplayMember = "Plant"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub Cargarplantas2()
        Dim ds As New DataSet
        Try
            sql = "select Codes, Plant  from ERP_CTRL_CODES_PLANT"
            ds = Consulta_Datos(sql, var_conexionERP)
            cb_plantas2.Properties.DataSource = ds.Tables(0)
            cb_plantas2.Properties.DisplayMember = "Plant"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub erp_ctrl_modificacion_linea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CargaNombreLineas()
        CargarPlantas2()
        Cargarplantas()
        CargaNombreLineas1()
        dt_fecha.DateTime = New DateTime(Now.Year, Now.Month, Now.Day)


        'dq.Columns.Add("Line_c", Type.GetType("System.String"))
        'dq.Columns.Add("Plant", Type.GetType("System.String"))
        'dq.Columns.Add("Plant_code", Type.GetType("System.String"))
        'dq.Columns.Add("Flujo", Type.GetType("System.String"))
        'dq.Columns.Add("Flujo_label", Type.GetType("System.String"))
        'dq.Columns.Add("MPS", Type.GetType("System.String"))
        'GridControl2.DataSource = dq
    End Sub
    Private Sub cargardatos()
        If lu_nombrelinea.Text <> "" Then
            sql = "select *  from  ERP_CTRL_LINES where Line_c = '" & lu_nombrelinea.text & " ' "
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            cb_booleano.Text = ds.Tables(0).Rows(0)("Transferencia").ToString
            cb_codigo.Text = ds.Tables(0).Rows(0)("Plant_code_new").ToString
            cb_planta.text = ds.Tables(0).Rows(0)("Planta_Nueva").ToString
            'dt_fecha.text = ds.Tables(0).Rows(0)("Fecha_Transf")
        End If
    End Sub
    Private Sub lu_nombrelinea_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lu_nombrelinea.EditValueChanged
        cargardatos()
    End Sub
    Private Sub btn_gene_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gene.Click
        If lu_nombrelinea.Text.Trim = "" Then
            lu_nombrelinea.Focus()
            Exit Sub
        End If
        If cb_booleano.Text.Trim = "" Then
            cb_booleano.Focus()
            Exit Sub
        End If
        If cb_codigo.Text.Trim = "" Then
            cb_codigo.Focus()
            Exit Sub
        End If
        If cb_planta.Text.Trim = "" Then
            cb_planta.Focus()
            Exit Sub
        End If
        sql = "update dbo.ERP_CTRL_LINES set Transferencia = '" & cb_booleano.text & "', Plant_code_new = '" & cb_codigo.Text & "',Planta_nueva = '" & cb_Planta.text & "', fecha_transf = '" & dt_fecha.text & "', Event = 'TR' where Line_c = '" & lu_nombrelinea.text & "' "
        Executa_Query(sql, var_conexionERP)
        sql = "update dbo.ERP_CTRL_XREF set Event = 'TR' where Line_c = '" & lu_nombrelinea.Text & "' "
        Executa_Query(sql, var_conexionERP)


        DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cb_planta.EditValue = ""
        'cb_planta.Text = ""
        up_nombre_comun.EditValue = ""
        lu_nombrelinea.EditValue = ""
        cb_codigo.EditValue = ""
        lu_nombrelinea.text = ""
        cb_booleano.text = ""
        cb_codigo.text = ""
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        If lu_nombrelinea.Text.Trim = "" Then
            lu_nombrelinea.Focus()
            Exit Sub
        End If
        sql = "update dbo.ERP_CTRL_LINES set Transferencia = Null, Plant_code_new = Null ,Planta_nueva = Null, fecha_transf = Null, Event = 'MP' where Line_c = '" & lu_nombrelinea.text & "' "
        Executa_Query(sql, var_conexionERP)
        sql = "update dbo.ERP_CTRL_XREF set Event = '0' where Line_c = '" & lu_nombrelinea.Text & "' "
        Executa_Query(sql, var_conexionERP)
        DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cb_planta.EditValue = ""
        'cb_planta.Text = ""
        up_nombre_comun.EditValue = ""
        lu_nombrelinea.EditValue = ""
        cb_codigo.EditValue = ""
        lu_nombrelinea.text = ""
        cb_booleano.text = ""
        cb_codigo.text = ""
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        Try
            If te_sews.text <> "" Then
                sql = "Select  a.sews_part_no , a.DL , a.Short_part_no , a.Customer_id , a.Mfg_Plant , a.FG_Plant , b.Line_c , b.Nombre_comun  from ERP_CTRL_XREF a inner join  ERP_CTRL_LINES b on a.Line_c = b.Line_c  where Active = '1' and sews_part_no = '" & te_sews.text & "'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                GridControl1.DataSource = ds.Tables(0)
                Gv1.ExpandAllGroups()
                Gv1.BestFitColumns()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btn_activar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_activar.Click
        If cb_dual.Text.Trim = "" Then
            cb_dual.Focus()
            Exit Sub
        End If
        If linea = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If mfg_plant = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If fg_plant = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If sews_part = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If short_part = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If custo_id = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            sql = "update dbo.ERP_CTRL_XREF  set Dual_plant = 'True' where  Line_c = '" & linea & "' and Active = '1' "
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Linea Actualizada a Dual Plan", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cb_dual_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_dual.EditValueChanged
        If cb_dual.Text <> "" Then
            'dim planta, codigo as String 
            sql = "select *  from  ERP_CTRL_CODES_PLANT where plant = '" & cb_dual.Text & " ' "
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            planta = ds.Tables(0).Rows(0)("Plant").ToString
            codigo = ds.Tables(0).Rows(0)("Codes").ToString
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        'dim linea, mfg_plant , fg_plant ,sews_part , short_part,custo_id  as String 
        Try
            linea = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Line_c").ToString
            mfg_plant = Gv1.GetRowCellValue(Gv1.FocusedRowHandle, "Mfg_Plant").ToString
            fg_plant = Gv1.GetRowCellValue(Gv1.FocusedRowHandle, "FG_Plant").ToString
            sews_part = Gv1.GetRowCellValue(Gv1.FocusedRowHandle, "sews_part_no").ToString
            short_part = Gv1.GetRowCellValue(Gv1.FocusedRowHandle, "Short_part_no").ToString
            custo_id = Gv1.GetRowCellValue(Gv1.FocusedRowHandle, "Customer_id").ToString
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_desactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_desactivar.Click
        If linea = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If mfg_plant = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If fg_plant = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If sews_part = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If short_part = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If custo_id = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            sql = "Delete from  ERP_CTRL_DUAL_PLANT_LINES  where Line_c = '" & linea & "'"
            Executa_Query(sql, var_conexionERP)
            sql = "update dbo.ERP_CTRL_XREF  set Dual_plant = 'False' where  Line_c = '" & linea & "' and Active = '1' "
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Dual Plan Eliminado de Linea", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        If cb_dual.Text.Trim = "" Then
            cb_dual.Focus()
            Exit Sub
        End If
        If linea = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If mfg_plant = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If fg_plant = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If sews_part = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If short_part = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If custo_id = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("No has seleccionado datos en Tabla", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            Dim ds As DataSet
            sql = "Select * from ERP_CTRL_DUAL_PLANT_LINES where Line_C = '" & linea & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Ya Existen Datos en Dual Plant, Se Mostraran Enseguida: ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GridControl2.DataSource = ds.Tables(0)
                GridView1.ExpandAllGroups()
                GridView1.BestFitColumns()
                Cursor = Cursors.Default
                GridView1.Columns("Line_c").OptionsColumn.AllowEdit = False
                GridView1.Columns("Plant").OptionsColumn.AllowEdit = False
                GridView1.Columns("Plant_code").OptionsColumn.AllowEdit = False
            Else
                sql = "Insert into  ERP_CTRL_DUAL_PLANT_LINES values ('" & linea & "','" & fg_plant & "','" & mfg_plant & "','PT_A','PT','MPS_A')"
                Executa_Query(sql, var_conexionERP)
                sql = "Insert into  ERP_CTRL_DUAL_PLANT_LINES values ('" & linea & "','" & fg_plant & "','" & mfg_plant & "','PT_B','PT','MPS_A')"
                Executa_Query(sql, var_conexionERP)
                sql = "Insert into  ERP_CTRL_DUAL_PLANT_LINES values ('" & linea & "','" & planta & "','" & codigo & "','PT_C','PT','MPS_B')"
                Executa_Query(sql, var_conexionERP)
                sql = "Insert into  ERP_CTRL_DUAL_PLANT_LINES values ('" & linea & "','" & planta & "','" & codigo & "','PT_D','PT','MPS_B')"
                Executa_Query(sql, var_conexionERP)
                sql = "Select * from ERP_CTRL_DUAL_PLANT_LINES where Line_C = '" & linea & "'"
                ds = Consulta_Datos(sql, var_conexionERP)
                GridControl2.DataSource = ds.Tables(0)
                GridView1.ExpandAllGroups()
                GridView1.BestFitColumns()
                Cursor = Cursors.Default
                GridView1.Columns("Line_c").OptionsColumn.AllowEdit = False
                GridView1.Columns("Plant").OptionsColumn.AllowEdit = False
                GridView1.Columns("Plant_code").OptionsColumn.AllowEdit = False
                DevExpress.XtraEditors.XtraMessageBox.Show("Linea Actualizada a Dual Plan", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cb_plantas2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_plantas2.EditValueChanged
        If cb_plantas2.Text <> "" Then
            sql = "select *  from  ERP_CTRL_CODES_PLANT where plant = '" & cb_dual.Text & " ' "
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            planta2 = ds.Tables(0).Rows(0)("Plant").ToString
            codigo2 = ds.Tables(0).Rows(0)("Codes").ToString
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Try
            Dim dq As New System.Data.DataTable
            If cb_plantas2.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("No se han capturado Piezas", "Solicitud de Herramental Satelite", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_flujo.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("No se han capturado el Numero de Parte", "Solicitud de Herramental Satelite", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_mps.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("No se han capturado el Numero Tool Crib", "Solicitud de Herramental Satelite", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            'dq.Columns.Add("Line_c", Type.GetType("System.String"))
            'dq.Columns.Add("Plant", Type.GetType("System.String"))
            'dq.Columns.Add("Plant_code", Type.GetType("System.String"))
            'dq.Columns.Add("Flujo", Type.GetType("System.String"))
            'dq.Columns.Add("Flujo_label", Type.GetType("System.String"))
            'dq.Columns.Add("MPS", Type.GetType("System.String"))
            'Dim workRow As DataRow
            ''For i = 0 To GridView1.RowCount - 1
            'workRow = dq.NewRow
            'workRow(0) = linea
            'workRow(1) = planta2
            'workRow(2) = codigo2
            'workRow(3) = cb_flujo.Text.Trim
            'workRow(4) = "PT"
            'workRow(5) = cb_mps.Text.Trim
            'dq.Rows.Add(workRow)
            'Next i
            'workRow = dq.NewRow
            'GridControl2.DataSource = dq
            sql = "Insert into  ERP_CTRL_DUAL_PLANT_LINES values ('" & linea & "','" & planta2 & "','" & codigo2 & "','" & cb_flujo.Text & "','PT','" & cb_mps.Text & "')"
            Executa_Query(sql, var_conexionERP)
            sql = "Select * from ERP_CTRL_DUAL_PLANT_LINES where Line_C = '" & linea & "'"
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            GridControl2.DataSource = ds.Tables(0)
            GridView1.ExpandAllGroups()
            GridView1.BestFitColumns()
            Cursor = Cursors.Default
            GridView1.Columns("Line_c").OptionsColumn.AllowEdit = False
            GridView1.Columns("Plant").OptionsColumn.AllowEdit = False
            GridView1.Columns("Plant_code").OptionsColumn.AllowEdit = False

            cb_plantas2.Text = ""
            cb_flujo.Text = ""
            cb_mps.Text = ""





        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Mantenimiento Herramental Satelite", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Public Sub ConsultaNoParte()
    '    Dim ds As DataSet

    'End Sub

    'Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
    '    Dim Lineas, Plantas3, Plant_code3, Flujo3, Flujo_label3, mps3, sql As String
    '    For I = 0 To GridView1.RowCount - 1
    '        'SOLICITUD = gridview.GetRowCellValue(I, "NoSolicitud").ToString
    '        Lineas = GridView1.GetRowCellValue(I, "Line_c").ToString
    '        Plantas3 = GridView1.GetRowCellValue(I, "Plant").ToString
    '        Plant_code3 = GridView1.GetRowCellValue(I, "Plant_code").ToString
    '        Flujo3 = GridView1.GetRowCellValue(I, "Flujo").ToString
    '        Flujo_label3 = GridView1.GetRowCellValue(I, "Flujo_label").ToString
    '        mps3 = GridView1.GetRowCellValue(I, "MPS").ToString
    '        'FECHA = gridview.GetRowCellValue(I, "Fecha")
    '        sql = "update dbo.ERP_CTRL_DUAL_PLANT_LINES  set Flujo = '" & Flujo3 & "' where  Line_c = '" & Lineas & "' and Plant = '" & Plantas3 & "' and Plant_code = '" & Plant_code3 & "' and MPS = '" & mps3 & "' "
    '        Executa_Query(sql, var_conexionERP)
    '    Next
    '    DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    'End Sub


    Private Sub up_nombre_comun_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up_nombre_comun.EditValueChanged
        If up_nombre_comun.Text <> "" Then
            CargaNombreLineas()
        End If
    End Sub
End Class
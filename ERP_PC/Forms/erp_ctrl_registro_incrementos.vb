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
Public Class erp_ctrl_registro_incrementos
    Dim sql, planner As String
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If up_Plantas.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Planta", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If up_linea.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Linea", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If up_tipo.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Tipo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If dt_fecha.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Fecha ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If up_turno.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Turno", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If te_evento.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Evento", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If te_currentcap.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Current Capacity", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If te_newcap.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar New Capacity", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If te_currentline.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Current Line Formation", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If te_newformation.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar New Line Formation", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Guardar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            sql = "insert into ERP_CTRL_REGISTRO_INCREMENTOS  VALUES  ('" & up_Plantas.Text.Trim & "','" & up_linea.Text.Trim & "','" & up_tipo.Text.Trim & "','" & up_turno.Text.Trim & "','" & te_evento.Text & "' " & _
                      ",'" & dt_fecha.Text.Trim & "','" & te_currentcap.Text.Trim & "','" & te_newcap.Text.Trim & "','" & te_currentline.Text.Trim & "','" & te_newformation.Text.Trim & "'" & _
                       ",Getdate())"
            Executa_Query(sql, var_conexionERP)
            te_evento.Text = ""
            te_currentcap.Text = ""
            te_newcap.Text = ""
            te_currentline.Text = ""
            te_newformation.Text = ""
            up_Plantas.EditValue = ""
            up_linea.EditValue = ""
            up_tipo.EditValue = ""
            up_turno.EditValue = ""
            dt_fecha.Text = ""
            CargarGrid()
            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub CargaPlantas()
        Dim ds As New DataSet
        Try
            sql = "select distinct FG_Plant as Plant from  ERP_CTRL_XREF where  Active <> '0'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_Plantas.Properties.DisplayMember = "Plant"
            up_Plantas.Properties.ValueMember = "Plant"
            up_Plantas.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub erp_ctrl_registro_incrementos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaPlantas()
        CargarGrid()
    End Sub

    Public Sub CargarGrid()
        Dim ds As New DataSet
        Try
            sql = "select Planta, Linea , Flujo , Turno , Evento, Fecha_efectiva , Current_capacity , New_capacity , Current_Line_Formation , New_Formation  from erp_Ctrl_registro_incrementos  where fecha_efectiva >= Getdate()"
            ds = Consulta_Datos(sql, var_conexionERP)
            gc_registros.DataSource = ds.Tables(0)
            gv_registros.ExpandAllGroups()
            gv_registros.BestFitColumns()
            Cursor = Cursors.Default
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub up_Plantas_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up_Plantas.EditValueChanged
        CargarLineas()
    End Sub
    Public Sub CargarLineas()
        Dim ds As New DataSet
        Try
            sql = "select distinct  b.nombre_comun as Linea from erp_ctrl_xref a, erp_ctrl_lines b, erp_ctrl_lines_formations_grouped c , erp_Ctrl_planner d , ERP_CTRL_VEHICLES e " & _
            " where a.line_c = c.line_cnd and a.line_c = b.line_c  and a.active <> '0' and d.planner_id = a.Planner and e.Car_cd = a.Vehicle and a.FG_Plant = '" & up_Plantas.Text & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_linea.Properties.DisplayMember = "Linea"
            up_linea.Properties.ValueMember = "Linea"
            up_linea.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CargarFlujo()
        Dim ds As New DataSet
        Try
            sql = "select distinct c.Flujo  from erp_ctrl_xref a, erp_ctrl_lines b, erp_ctrl_lines_formations_grouped c , erp_Ctrl_planner d , ERP_CTRL_VEHICLES e " & _
            " where a.line_c = c.line_cnd and a.line_c = b.line_c  and a.active <> '0' and d.planner_id = a.Planner and e.Car_cd = a.Vehicle and a.FG_Plant = '" & up_Plantas.Text.Trim & "' and b.Nombre_comun = '" & up_linea.Text.Trim & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_tipo.Properties.DisplayMember = "Flujo"
            up_tipo.Properties.ValueMember = "Flujo"
            up_tipo.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CargarTurno()
        Dim ds As New DataSet
        Try
            sql = "select distinct c.Turno from erp_ctrl_xref a, erp_ctrl_lines b, erp_ctrl_lines_formations_grouped c , erp_Ctrl_planner d , ERP_CTRL_VEHICLES e " & _
            " where a.line_c = c.line_cnd and a.line_c = b.line_c  and a.active <> '0' and d.planner_id = a.Planner and e.Car_cd = a.Vehicle and a.FG_Plant = '" & up_Plantas.Text & "' and b.Nombre_comun = '" & up_linea.Text & "' and c.Flujo = '" & up_tipo.Text & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_turno.Properties.DisplayMember = "Turno"
            up_turno.Properties.ValueMember = "Turno"
            up_turno.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub up_linea_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up_linea.EditValueChanged
        CargarFlujo()
    End Sub
    Private Sub up_tipo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up_tipo.EditValueChanged
        CargarTurno()
    End Sub
    Private Sub TextEdit1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_currentcap.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se puede ingresar valores de tipo número", MsgBoxStyle.Exclamation, "Ingreso de Número")
        End If
    End Sub
    Private Sub te_newcap_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_newcap.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se puede ingresar valores de tipo número", MsgBoxStyle.Exclamation, "Ingreso de Número")
        End If
    End Sub
    Private Sub te_currentline_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_currentline.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se puede ingresar valores de tipo número", MsgBoxStyle.Exclamation, "Ingreso de Número")
        End If
    End Sub
    Private Sub te_newformation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_newformation.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se puede ingresar valores de tipo número", MsgBoxStyle.Exclamation, "Ingreso de Número")
        End If
    End Sub
End Class
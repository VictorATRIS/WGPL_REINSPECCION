Imports AccesoDatos
Imports Funciones
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Configuration
Imports System.Reflection
Imports System.IO
Imports System.Drawing.Point

Public Class erp_ctrl_lots_adjustments
    Dim sql, planner As String
    Private Sub erp_ctrl_lots_adjustments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        sql = "Select planner_id from  ERP_CTRL_PLANNER where planner_descr = '" & var_adm_Usr_NICK & "'"
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            planner = ds.Tables(0).Rows(0)(0).ToString.Trim
            planner = planner.Substring(1, 2)
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Usuario No se encuentra en la Base de Datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If planner = "ME" Then
            CargaPlantas()
        Else
            CargaPlantasPlanner()
        End If


    End Sub
    Public Sub CargaPlantasPlanner()
        Dim ds As New DataSet
        Try
            sql = "select distinct FG_Plant as Plant from  ERP_CTRL_XREF where Planner = '" & planner & "' and Active <> '0'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_Plantas.Properties.DisplayMember = "Plant"
            up_Plantas.Properties.ValueMember = "Plant"
            up_Plantas.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If up_Plantas.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Planta", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If up_sews_parte.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Sews Part No", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If up_cliente.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Cliente", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If dt_fecha.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Fecha Plan", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If plan_nuevo.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Plan Nuevo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If te_doh.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar DOH", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Guardar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            sql = "insert into ERP_CTRL_LOTS_ADJUSTMENTS  VALUES  ('" & planner & "','" & up_sews_parte.Text.Trim & "','" & up_cliente.Text.Trim & "','" & dt_fecha.Text.Trim & "','" & te_actual.Text & "','" & plan_nuevo.Text & "'" & _
            ",'" & te_dif.Text.Trim & "','" & te_doh.Text.Trim & "',GETDATE(),'" & mm_descr.Text.Trim & "','" & te_kmh.Text.Trim & "','" & up_Plantas.Text.Trim & "')"
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargaPlantasPlanner()
            dt_fecha.Text = ""
            te_actual.Text = ""
            plan_nuevo.Text = ""
            te_doh.Text = ""
            te_dif.Text = ""
            te_smh.Text = ""
            te_kmh.Text = ""
            mm_descr.Text = ""
            LabelControl54.Visible = False
            dt_fecha.Visible = False
        End If
    End Sub
    Public Sub cargarPlanActual()
        Dim ds As New DataSet
        Try
            sql = "Select  Qty_plan as Plan_actual from ERP_CTRL_PLAN a left join ERP_CTRL_PLAN_REV b on  a.Rev = b.Revision " & _
                  " where b.Active = '1' and a.Part_no = '" & up_sews_parte.Text & "' and  a.Customer_id = '" & up_cliente.Text & "' and a.Date_plan = ' " & dt_fecha.DateTime.ToShortDateString & "' and a.tipo = 'PT'"
            ds = Consulta_Datos(sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                te_actual.Text = ds.Tables(0).Rows(0)(0).ToString.Trim
                'Else
                '    DevExpress.XtraEditors.XtraMessageBox.Show("No se encontro Qty Plan", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub plan_nuevo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plan_nuevo.EditValueChanged
        If plan_nuevo.Text = "" Then
            Exit Sub
        Else
            te_dif.Text = te_actual.Text - plan_nuevo.Text
            If up_sews_parte.Text <> "" Then
                If up_cliente.Text <> "" Then
                    Dim ds As New DataSet
                    Try
                        sql = "Select  round (b.SMH_TTL,5) from ERP_CTRL_XREF a left join ERP_CTRL_SMH b on a.cust_part_no = b.Cust_part_no and  a.Customer_id = b.Cust_id  " & _
                        " where a.sews_part_no = '" & up_sews_parte.Text & "' and a.Customer_id = '" & up_cliente.Text & "' " & _
                        " and b.Rev = (select SMH_Rev from ERP_CTRL_SMH_REV where Active = '1') and a.Active <> 0 "
                        ds = Consulta_Datos(sql, var_conexionERP)
                        If ds.Tables(0).Rows.Count > 0 Then
                            te_smh.Text = ds.Tables(0).Rows(0)(0).ToString.Trim
                            te_kmh.Text = te_smh.Text * te_dif.Text / 1000
                        End If
                    Catch ex As Exception
                        DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If
    End Sub
    Private Sub up_cliente_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up_cliente.EditValueChanged
        Dim ds As New DataSet
        Dim FechaMin As DateTime
        dt_fecha.Visible = True
        LabelControl54.Visible = True
        FechaMin = Now.ToShortDateString
        sql = "SELECT dbo.ufn_ADD_WORKING_DAYS( GETDATE() ,5)"
        ds = Consulta_Datos(sql, var_conexionERP)
        FechaMin = ds.Tables(0).Rows(0)(0).ToString
        dt_fecha.Properties.MinValue = FechaMin
    End Sub
    Private Sub dt_fecha_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha.EditValueChanged
        Dim ds, da, dr As New DataSet
        Dim FechaAlerta, FechaAlerta2 As DateTime
        Dim val As String
        te_actual.BackColor = Color.White
        sql = "select DATEPART(DW,'" & dt_fecha.DateTime.ToShortDateString & "')"
        dr = Consulta_Datos(sql, var_conexionERP)
        val = dr.Tables(0).Rows(0)(0).ToString
        If val = "1" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Dia no permitido", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            If val = "7" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Dia no permitido", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                FechaAlerta = Now.ToShortDateString
                sql = "SELECT dbo.ufn_ADD_WORKING_DAYS( GETDATE() ,5)"
                ds = Consulta_Datos(sql, var_conexionERP)
                FechaAlerta = ds.Tables(0).Rows(0)(0).ToString
                sql = "SELECT dbo.ufn_ADD_WORKING_DAYS( GETDATE() ,6)"
                ds = Consulta_Datos(sql, var_conexionERP)
                FechaAlerta2 = ds.Tables(0).Rows(0)(0).ToString
                If dt_fecha.DateTime.ToShortDateString = FechaAlerta Then
                    If DevExpress.XtraEditors.XtraMessageBox.Show("Dia ya fue Programado por Kanban, Permitir Seguir?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        te_actual.BackColor = Color.Tomato
                        cargarPlanActual()
                    End If
                Else
                    If dt_fecha.DateTime.ToShortDateString = FechaAlerta2 Then
                        If DevExpress.XtraEditors.XtraMessageBox.Show("Dia ya fue Programado por Kanban, Permitir Seguir?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            te_actual.BackColor = Color.Tomato
                            cargarPlanActual()
                        End If
                    Else
                        If dt_fecha.DateTime.ToShortDateString = #12:00:00 AM# Then
                            Exit Sub
                        Else
                            cargarPlanActual()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub cargarCustumer()
        Dim ds As New DataSet
        Try
            sql = "Select  distinct Customer_id as Cliente From ERP_CTRL_XREF where Planner = '" & planner & "'  and FG_Plant = '" & up_Plantas.Text & "' and Active <> '0' and sews_part_no = '" & up_sews_parte.Text & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_cliente.Properties.DisplayMember = "Cliente"
            up_cliente.Properties.ValueMember = "Cliente"
            up_cliente.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub cargarCustumerALL()
        Dim ds As New DataSet
        Try
            sql = "Select  distinct Customer_id as Cliente From ERP_CTRL_XREF where FG_Plant = '" & up_Plantas.Text & "' and Active <> '0' and sews_part_no = '" & up_sews_parte.Text & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_cliente.Properties.DisplayMember = "Cliente"
            up_cliente.Properties.ValueMember = "Cliente"
            up_cliente.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CargaSewsPartALL()
        Dim ds As New DataSet
        Try
            'sql = "SELECT distinct Sews_part_no , b.Plant  FROM ERP_CTRL_XREF a left join ERP_CTRL_DUAL_PLANT_LINES b ON a.Line_c = b.Line_c where FG_Plant = '" & up_Plantas.Text & "' and Active <> '0' and a.Planner = '" & planner & "' "
            sql = "select  distinct  Sews_part_no from  ERP_CTRL_XREF where  FG_Plant = '" & up_Plantas.Text & "' and Active <> '0'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_sews_parte.Properties.DataSource = ds.Tables(0)
            up_sews_parte.Properties.DisplayMember = "Sews_part_no"
            up_sews_parte.Properties.ValueMember = "Sews_part_no"
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub up_sews_parte_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up_sews_parte.EditValueChanged
        If planner = "ME" Then
            cargarCustumerALL()
        Else
            cargarCustumer()
        End If
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Configuration
Imports System.Threading
Imports System.Globalization
Imports Funciones
Imports AccesoDatos

Public Class erp_main_login_load
    Dim sql As String

    Private Sub erp_main_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Try
            Txt_usr.Focus()
            img_access.Visible = True
            img_access1.Visible = False
            img_deny.Visible = False
            If My.Computer.Name = "SYSDEVATR01" Or My.Computer.Name = "SYSDEVATR02" Or My.Computer.Name.Contains("SASYSDEVLAP") Then
                Txt_usr.Text = "atr.admin"
                Txt_pwd.Text = "adminatr08"
                Txt_pwd.Focus()
            End If

            var_conexionERP = DesencriptaCadenaConexionERP(ConfigurationManager.ConnectionStrings("ERP_cnn").ConnectionString)
            var_conexionPOP = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("POP_cnn").ConnectionString)
            var_conexionPOP35 = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("POP35_cnn").ConnectionString) 'POP_SP_cnn
            var_conexionPOPSP = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("POP_SP_cnn").ConnectionString) 'POP_SP_cnn
            var_conexionMPS = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("MPS_cnn").ConnectionString)
            var_conexionSAPC = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("SAPC_cnn").ConnectionString)
            var_conexionCNC = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("CNC_cnn").ConnectionString)
            var_conexionWO = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("WO_cnn").ConnectionString)
            var_conexionICS = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("ICS_cnn").ConnectionString)
            var_conexionCTRACE = DesencriptaCadenaConexionCTRACE(ConfigurationManager.ConnectionStrings("CTRACE_cnn").ConnectionString)
            var_conexionSAUERP = (DesencriptaCadenaConexionERPSAU(ConfigurationManager.ConnectionStrings("SAU_ERP_cnn").ConnectionString))
            var_conexionTRESS = (DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("TRESS_cnn").ConnectionString))


            var_IP_mailserver = ConfigurationManager.AppSettings("IP_Mail_server")
            var_adm_Planta = ConfigurationManager.AppSettings("erp_plant")
            'System.Diagnostics.Process.Start("DateFormat.exe")
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "/"
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Txt_pwd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_pwd.GotFocus
        img_access.Visible = False
        img_access1.Visible = True
        img_deny.Visible = False
    End Sub

    Private Sub Txt_usr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_usr.GotFocus
        img_access.Visible = True
        img_access1.Visible = False
        img_deny.Visible = False
    End Sub
    Public Sub ObtieneCredencialesCC()
        Dim ds As DataSet
        Dim us, pa, dom As String
        Try
            sql = "select * from   ERP_ADM_Acceso_cc"
            ds = Consulta_Datos(sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                us = ds.Tables(0).Rows(0)("Usuario")
                pa = ds.Tables(0).Rows(0)("Password")
                dom = ds.Tables(0).Rows(0)("Dominio")

                CCDominio = dom
                CCUsuario = Desencriptar(us, "usuario0")
                CCPAssword = Desencriptar(pa, "contrase")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub Btn_ent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ent.Click

        Dim ds As New DataSet

        Try
            If Txt_usr.Text = "" Then
                img_access.Visible = False
                img_access1.Visible = False
                img_deny.Visible = True
                MsgBox("Favor de escribir su NOMBRE de usuario", MsgBoxStyle.Critical, "ERP")
                Exit Sub
            End If
            If Txt_pwd.Text = "" Then
                img_access.Visible = False
                img_access1.Visible = False
                img_deny.Visible = True
                MsgBox("Favor de escribir su Contraseña", MsgBoxStyle.Critical, "ERP")
                Exit Sub
            End If

            sql = String.Format("SELECT * FROM ERP_ADM_User WHERE Usr_nick = '{0}' AND USR_PWD = '{1}'", Txt_usr.Text, Txt_pwd.Text)
            ds = Consulta_Datos(sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0)("Usr_Block").ToString.Trim = "S" Then
                    MessageBox.Show("Usuario Bloqueado. Contacte al Administrador", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Txt_usr.Text = ""
                    Txt_pwd.Text = ""
                    Txt_usr.Focus()
                    Exit Sub
                End If
                'If ds.Tables(0).Rows(0)("Usr_in").ToString.Trim = "S" Then
                '    MessageBox.Show("Usuario Actualmente en el Sistema en PC " & ds.Tables(0).Rows(0)("Usr_pc").ToString.Trim & ". Contacte al Administrador", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Txt_usr.Text = ""
                '    Txt_pwd.Text = ""
                '    Txt_usr.Focus()
                '    Exit Sub
                'End If
                var_adm_Usr_ID = ds.Tables(0).Rows(0)("USR_ID").ToString.Trim
                var_adm_Usr_NICK = ds.Tables(0).Rows(0)("Usr_nick").ToString.Trim
                var_adm_Usr_Name = ds.Tables(0).Rows(0)("Usr_name").ToString.Trim
                var_adm_group = ds.Tables(0).Rows(0)("GRP_id").ToString.Trim

                sql = String.Format("UPDATE ERP_ADM_User SET Usr_in = 'S', Usr_pc = '{0}' WHERE Usr_nick = '{1}'", My.Computer.Name, var_adm_Usr_NICK)
                Executa_Query(sql, var_conexionERP)

                ObtieneCredencialesCC()
                Dim forma_princ As New erp_main
                forma_princ.Show()

                WindowState = FormWindowState.Minimized
                ShowInTaskbar = False
            Else
                MessageBox.Show("Usuario o Password Incorrecto. Verifique Por Favor", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Txt_usr.Text = ""
                Txt_pwd.Text = ""
                Txt_usr.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Txt_pwd_KeyUp(sender As Object, e As KeyEventArgs) Handles Txt_pwd.KeyUp
        If e.KeyCode = Keys.Enter Then
            Btn_ent_Click(sender, e)
        End If
    End Sub
End Class

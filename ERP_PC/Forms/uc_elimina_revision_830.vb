Imports Funciones
Imports AccesoDatos

Public Class uc_elimina_revision_830
    Dim sql As String

    Public Sub CargaRevisiones()
        Try
            Dim ds As New DataSet
            sql = "select rtrim(ltrim(Revision)) Revision from erp_ctrl_plan_rev where rtrim(ltrim(active)) <> '2' and type = 'M8' order by type, initdate desc"
        ds = Consulta_Datos(sql, var_conexionERP)
        LookUp_revision.Properties.DisplayMember = "Revision"
        LookUp_revision.Properties.ValueMember = "Revision"
        LookUp_revision.Properties.DataSource = ds.Tables(0)

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub uc_elimina_revision_830_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargaRevisiones()
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Btn_guardar_Click(sender As Object, e As EventArgs) Handles Btn_guardar.Click
        Try
            If Trim(LookUp_revision.Text) = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Selecciona la revision que quieres eliminar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            sql = "delete from erp_ctrl_plan_rev where revision = '" & Trim(LookUp_revision.Text) & "'"
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("La revision se elimino con exito", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargaRevisiones()

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

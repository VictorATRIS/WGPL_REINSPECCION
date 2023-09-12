Imports Funciones
Imports AccesoDatos
Public Class erp_main
    Private Sub erp_main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ModulosXREFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModulosXREFToolStripMenuItem.Click

        If Valida_Acceso_Usr(var_adm_group, "erp_ctrl_autorizacion_eliminacion_caja", "1", var_conexionERP) Then
            Dim forma As New erp_mantenimiento_xref
            forma.ShowDialog()
        Else
            MessageBox.Show("No tiene permisos para accesar a este modulo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
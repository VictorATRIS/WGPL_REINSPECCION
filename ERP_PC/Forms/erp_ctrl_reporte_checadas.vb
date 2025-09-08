Imports AccesoDatos
Imports Funciones

Public Class erp_ctrl_reporte_checadas
    Dim sql As String
    Dim ds As DataSet
    Private Sub butBuscar_Click(sender As Object, e As EventArgs) Handles butBuscar.Click
        Try

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
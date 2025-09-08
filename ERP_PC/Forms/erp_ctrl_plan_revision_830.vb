Public Class erp_ctrl_plan_revision_830

   
    Private Sub NavBarControl1_LinkClicked(sender As Object, e As XtraNavBar.NavBarLinkEventArgs) Handles NavBarControl1.LinkClicked
        Try

            PanelControl1.Controls.Clear()
            Select Case e.Link.Caption
                Case "Agregar Revision"
                    Dim forma As New uc_agregar_revision_830
                    PanelControl1.Controls.Add(forma)
                Case "Especificar Revision"
                    Dim forma As New uc_ctrl_plan_selecciona_revision
                    PanelControl1.Controls.Add(forma)
                Case "Eliminar Revision"
                    Dim forma As New uc_elimina_revision_830
                    PanelControl1.Controls.Add(forma)
                Case "Activar Revision"
                    Dim forma As New uc_activa_revision_830
                    PanelControl1.Controls.Add(forma)
            End Select
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub erp_ctrl_plan_revision_830_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
Public Class erp_mantenimiento_xref
    Private Sub erp_mantenimiento_xref_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub butGeneraRevision_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles butGeneraRevision.ItemClick
        Dim forma As New erp_ctrl_genera_master_smh
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim forma As New erp_ctrl_importacion_xls_SMH
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        Dim forma As New erp_ctrl_lots_adjustments
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Dim forma As New erp_ctrl_generar_mensual_backorders
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim forma As New erp_ctrl_importar_ajustes_temporales
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim forma As New erp_ctrl_genera_ecn
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Dim forma As New erp_ctrl_crear_rev_4mf
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Dim forma As New dia_atraso
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim forma As New erp_ctrl_modificacion_linea
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick
        Dim forma As New erp_ctrl_formato_largo
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        Dim forma As New erp_ctrl_four_months_forecaste
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Dim forma As New erp_ctrl_datos_ips
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem29_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        Dim forma As New erp_ctrl_import_doh_lines
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Dim forma As New erp_ctrl_generar_sews_part
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        Dim forma As New erp_ctrl_snapshots
        forma.ShowDialog()
    End Sub

    Private Sub BarButtonItem32_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick
        Dim form As New erp_ctrl_must_go
        form.ShowDialog()
    End Sub

    Private Sub BarButtonItem41_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem41.ItemClick
        Dim form As New erp_ctrl_registro_incrementos
        form.ShowDialog()
    End Sub

    Private Sub BarButtonItem42_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem42.ItemClick
        Dim form As New erp_ctrl_830
        form.ShowDialog()
    End Sub

    Private Sub BarButtonItem43_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem43.ItemClick
        Dim form As New erp_ctrl_doh_projection
        form.ShowDialog()
    End Sub

    Private Sub BarButtonItem46_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem46.ItemClick
        Dim form As New erp_ctrl_seguimiento_diario_kmh
        form.ShowDialog()
    End Sub

    Private Sub barButonCambiarNo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barButonCambiarNo.ItemClick
        Dim form As New erp_ctrl_cambiar_NoPlant
        form.ShowDialog()
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick

    End Sub
End Class
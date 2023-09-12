Imports Funciones
Imports AccesoDatos
Public Class erp_ctrl_formato_largo

    Dim sql As String
    Private Sub btn_xref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xref.Click
        Try
            If te_sews.Text <> "" Then
                sql = "Select Mfg_Plant , FG_Plant , DL , Planner , sews_part_no , Short_part_no , Customer_id ,PHC2_Part_no_flg  from ERP_CTRL_XREF where Sews_part_no = '" & te_sews.Text.Trim & "'and Active <> 0 "
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                GridControl1.DataSource = ds.Tables(0)
                GV1.ExpandAllGroups()
                GV1.BestFitColumns()
                GV1.Columns("Mfg_Plant").OptionsColumn.AllowEdit = False
                GV1.Columns("FG_Plant").OptionsColumn.AllowEdit = False
                GV1.Columns("DL").OptionsColumn.AllowEdit = False
                GV1.Columns("Planner").OptionsColumn.AllowEdit = False
                GV1.Columns("sews_part_no").OptionsColumn.AllowEdit = False
                GV1.Columns("Short_part_no").OptionsColumn.AllowEdit = False
                GV1.Columns("Customer_id").OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim mfg_plant, fg_plant, dl, planner, sews_part, short_part, customer_id, Phc2, sql As String
            For I = 0 To GV1.RowCount - 1
                mfg_plant = GV1.GetRowCellValue(I, "Mfg_Plant").ToString
                fg_plant = GV1.GetRowCellValue(I, "FG_Plant").ToString
                dl = GV1.GetRowCellValue(I, "DL").ToString
                planner = GV1.GetRowCellValue(I, "Planner").ToString
                sews_part = GV1.GetRowCellValue(I, "sews_part_no").ToString
                short_part = GV1.GetRowCellValue(I, "Short_part_no").ToString
                customer_id = GV1.GetRowCellValue(I, "Customer_id").ToString
                Phc2 = GV1.GetRowCellValue(I, "PHC2_Part_no_flg").ToString
                sql = "update dbo.ERP_CTRL_XREF  set PHC2_Part_no_flg = '" & Phc2 & "' where sews_part_no = '" & sews_part & "' and Mfg_Plant = '" & mfg_plant & "' and FG_Plant = '" & fg_plant & "' and DL = '" & dl & "' and Short_part_no = '" & short_part & "' and Planner = '" & planner & "' and Customer_id = '" & customer_id & "'"
                Executa_Query(sql, var_conexionERP)
                CargaSews()
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub CargaSews()
        Try
            sql = "Select Mfg_Plant , FG_Plant , DL , Planner , sews_part_no , Short_part_no , Customer_id ,PHC2_Part_no_flg  from ERP_CTRL_XREF where Sews_part_no = '" & te_sews.Text.Trim & "'and Active <> 0 "
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            GridControl1.DataSource = ds.Tables(0)
            GV1.ExpandAllGroups()
            GV1.BestFitColumns()
            GV1.Columns("Mfg_Plant").OptionsColumn.AllowEdit = False
            GV1.Columns("FG_Plant").OptionsColumn.AllowEdit = False
            GV1.Columns("DL").OptionsColumn.AllowEdit = False
            GV1.Columns("Planner").OptionsColumn.AllowEdit = False
            GV1.Columns("sews_part_no").OptionsColumn.AllowEdit = False
            GV1.Columns("Short_part_no").OptionsColumn.AllowEdit = False
            GV1.Columns("Customer_id").OptionsColumn.AllowEdit = False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
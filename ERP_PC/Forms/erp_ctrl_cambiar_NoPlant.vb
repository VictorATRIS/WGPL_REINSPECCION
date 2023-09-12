Imports AccesoDatos
Imports Funciones

Public Class erp_ctrl_cambiar_NoPlant
    Dim sql As String
    Private Sub butBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butBuscar.Click
        llenarTabla(lookEditSews.Text, lookDl.Text, lookCustomer.Text)
    End Sub

    Private Sub erp_ctrl_cambiar_NoPlant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Try
            sql = "select Mfg_plant_cd from ERP_CTRL_MFG_SECTIONS ORDER BY Mfg_plant_cd"
            ds = Consulta_Datos(sql, var_conexionERP)
            Carga_CombooDevXpress(comboMFGNo, sql, var_conexionERP)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        getSewsPart()
    End Sub

    Private Sub butGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGuardar.Click
        If MessageBox.Show("Desea actualizar los datos de la tabla? ", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            If GV1.GetRowCellValue(0, "SEWS_PART_NO").ToString <> "" Then
                Try
                    sql = "update ERP_CTRL_XREF set mfg_plant = '" & comboMFGNo.SelectedItem.ToString & "' where sews_part_no ='" & GV1.GetRowCellValue(0, "SEWS_PART_NO").ToString & "'" & _
                    " and dl ='" & GV1.GetRowCellValue(0, "DL").ToString & "' and customer_id = '" & GV1.GetRowCellValue(0, "CUSTOMER_ID").ToString & "'"
                    If Executa_Query(sql, var_conexionERP) Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("El numero de planta se cambio con exito", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        llenarTabla(GV1.GetRowCellValue(0, "SEWS_PART_NO").ToString, GV1.GetRowCellValue(0, "DL").ToString, GV1.GetRowCellValue(0, "CUSTOMER_ID").ToString)
                        getSewsPart()
                        getDl()
                        getCustomer_id()
                    End If
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("No ha cargado ningun registro", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub getSewsPart()
        sql = "Select  sews_part_no from ERP_CTRL_XREF  " & _
                     " where Active <> '0' "
        Try
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            lookEditSews.Properties.DisplayMember = "sews_part_no"
            lookEditSews.Properties.DataSource = ds.Tables(0)

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub lookEditSews_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lookEditSews.EditValueChanged
        getDl()
    End Sub
    Private Sub getDl()
        sql = "Select  DISTINCT(DL) from ERP_CTRL_XREF  " & _
                 " where Active <> '0' and sews_part_no = '" & lookEditSews.Text & "'"
        Try
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            lookDl.Properties.DisplayMember = "DL"
            lookDl.Properties.DataSource = ds.Tables(0)

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub getCustomer_id()
        sql = "Select  CUSTOMER_ID from ERP_CTRL_XREF  " & _
            " where Active <> '0' and sews_part_no = '" & lookEditSews.Text & "' and dl ='" & lookDl.Text & "'"
        Try
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            lookCustomer.Properties.DisplayMember = "CUSTOMER_ID"
            lookCustomer.Properties.DataSource = ds.Tables(0)

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lookDl_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lookDl.EditValueChanged
        getCustomer_id()
    End Sub
    Private Sub llenarTabla(ByVal sews_part_no As String, ByVal dL As String, ByVal customer_id As String)
        Try
            If sews_part_no <> "" And dL <> "" And customer_id <> "" Then
                sql = "Select  SEWS_PART_NO,MFG_PLANT,FG_PLANT ,ACTIVE ,DL,CUSTOMER_ID,LINE_C from ERP_CTRL_XREF ERP_CTRL_LINES " & _
                      " where Active <> '0' and sews_part_no = '" & sews_part_no & "' and dl = '" & dL & "' and customer_id ='" & customer_id & "'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                If ds.Tables(0).Rows.Count > 0 Then
                    GridControl1.DataSource = ds.Tables(0)
                    comboMFGNo.SelectedItem = GV1.GetRowCellValue(0, "MFG_PLANT").ToString
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("No se encontro este registro en XREF", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Ingrese todos los filtros para buscar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
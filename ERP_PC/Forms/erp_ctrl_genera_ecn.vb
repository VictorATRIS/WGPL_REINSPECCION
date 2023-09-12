Imports AccesoDatos
Imports Funciones

Public Class erp_ctrl_genera_ecn
    Dim sql As String
    Private Sub erp_ctrl_generar_ecn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dt_fecha.DateTime = New DateTime(Now.Year, Now.Month, Now.Day)
        'cargareventos()
    End Sub
    Private Sub btn_xref_Click(sender As Object, e As EventArgs) Handles btn_xref.Click
        Try
            butActualizar.Visible = False
            If te_sews.Text <> "" Then
                sql = "Select * from ERP_CTRL_XREF where Sews_part_no = '" & te_sews.Text.Trim & "'and Active <> 0 "
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                GridControl1.DataSource = ds.Tables(0)
                GV1.ExpandAllGroups()
                GV1.BestFitColumns()
                Cursor = Cursors.Default
                GV1.Columns("Section_id").OptionsColumn.AllowEdit = False
                GV1.Columns("Mfg_Plant").OptionsColumn.AllowEdit = False
                GV1.Columns("PN_Qty").OptionsColumn.AllowEdit = False
                GV1.Columns("FG_Plant").OptionsColumn.AllowEdit = False
                GV1.Columns("SK_Plant").OptionsColumn.AllowEdit = False
                GV1.Columns("DL").OptionsColumn.AllowEdit = False
                GV1.Columns("Line_c").OptionsColumn.AllowEdit = False
                GV1.Columns("SRS_Line_c").OptionsColumn.AllowEdit = False
                GV1.Columns("Planner").OptionsColumn.AllowEdit = False
                GV1.Columns("sews_part_no").OptionsColumn.AllowEdit = False
                GV1.Columns("Supplier_id").OptionsColumn.AllowEdit = False
                GV1.Columns("IHS_Part_no").OptionsColumn.AllowEdit = False
                GV1.Columns("cust_part_no").OptionsColumn.AllowEdit = False
                GV1.Columns("Short_part_no").OptionsColumn.AllowEdit = False
                GV1.Columns("Std_Pack").OptionsColumn.AllowEdit = False
                GV1.Columns("MPS_Format").OptionsColumn.AllowEdit = False
                GV1.Columns("TipoEtiqArnes").OptionsColumn.AllowEdit = False
                GV1.Columns("Division").OptionsColumn.AllowEdit = False
                GV1.Columns("SubDivision").OptionsColumn.AllowEdit = False
                GV1.Columns("Vehicle").OptionsColumn.AllowEdit = False
                GV1.Columns("Product_type").OptionsColumn.AllowEdit = False
                GV1.Columns("DOH_Min_Policy").OptionsColumn.AllowEdit = False
                GV1.Columns("Container").OptionsColumn.AllowEdit = False
                GV1.Columns("SRS1").OptionsColumn.AllowEdit = False
                GV1.Columns("SRS2").OptionsColumn.AllowEdit = False
                GV1.Columns("ECN").OptionsColumn.AllowEdit = False
                GV1.Columns("Customer_id").OptionsColumn.AllowEdit = False
                GV1.Columns("KMH_Destination").OptionsColumn.AllowEdit = False
                GV1.Columns("Upd_dt").OptionsColumn.AllowEdit = False
                GV1.Columns("combo").OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub butGuardar_Click(sender As Object, e As EventArgs) Handles butGuardar.Click
        Try
            If te_active.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_dl.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar DL", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_ecn.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar ECN", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_sewsp.Text.Trim = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Sews Part No ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "4" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "5" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "6" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "7" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "8" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "9" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "0" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "1" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_active.Text = "2" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo Valido ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Guardar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                sql = "select  * from ERP_CTRL_XREF where sews_part_no  = '" & te_sewsp.Text & "' and  Dl = '" & te_dl.Text & "' and Active = '" & te_active.Text & "' and  Customer_id = '" & te_customer.Text & "' "
                If Existe_Dato(sql, var_conexionERP) Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("Sews Part No , Ya Existe. Favor de verificar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    sql = "select  * from ERP_CTRL_XREF where sews_part_no  = '" & te_sewsp.Text & "'  and Active = '" & te_active.Text & "' and  Customer_id = '" & te_customer.Text & "' "
                    If Existe_Dato(sql, var_conexionERP) Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Activo, Ya Existe. Favor de verificar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        sql = "select  * from ERP_CTRL_XREF where sews_part_no  = '" & te_sewsp.Text & "'  and Dl = '" & te_dl.Text & "' "
                        If Existe_Dato(sql, var_conexionERP) Then
                            DevExpress.XtraEditors.XtraMessageBox.Show("DL , Ya Existe. Favor de verificar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            sql = "insert into ERP_CTRL_XREF  VALUES  ('" & te_section.Text.Trim & "','" & te_mfg.Text.Trim & "','" & te_active.Text.Trim & "','" & te_pnqty.Text.Trim & "','" & te_fg.Text & "',Null" & _
                       ",'" & te_dl.Text.Trim & "','" & te_linec.Text.Trim & "',Null,'" & te_planner.Text.Trim & "','" & te_sewsp.Text.Trim & "','" & te_supplier.Text.Trim & "'" & _
                        ",'" & te_ihs.Text.Trim & "','" & te_custp.Text.Trim & "','" & te_shortp.Text.Trim & "','" & te_stdp.Text.Trim & "','" & te_mpsf.Text.Trim & "','" & te_tipoetiqarnes.Text.Trim & "'" & _
                        ",'" & te_division.Text.Trim & "','" & te_subdivision.Text.Trim & "','" & te_vehicle.Text.Trim & "','" & te_product.Text.Trim & "',Null,'" & te_container.Text.Trim & "'" & _
                        ",'" & te_srs1.Text.Trim & "','" & te_srs2.Text.Trim & "','" & te_ecn.Text.Trim & "','" & te_customer.Text.Trim & "',Null,Getdate(),'" & te_proporcionsat.Text.Trim & "'" & _
                        ",'" & te_proporcionmadre.Text.Trim & "','" & te_phc2.Text.Trim & "','NDL','" & te_online.Text.Trim & "','" & te_circqty.Text.Trim & "','" & te_smh.Text.Trim & "'" & _
                        ",'" & te_dual.Text.Trim & "',Null,'" & te_custp.Text.Trim & "','" & te_dl.Text.Trim & "','False','')"
                            Executa_Query(sql, var_conexionERP)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        te_section.Text = ""
                        te_mfg.Text = ""
                        te_active.Text = ""
                        te_pnqty.Text = ""
                        te_fg.Text = ""
                        te_dl.Text = ""
                        te_linec.Text = ""
                        te_planner.Text = ""
                        te_sewsp.Text = ""
                        te_supplier.Text = ""
                        te_ihs.Text = ""
                        te_custp.Text = ""
                        te_shortp.Text = ""
                        te_stdp.Text = ""
                        te_mpsf.Text = ""
                        te_tipoetiqarnes.Text = ""
                        te_division.Text = ""
                        te_subdivision.Text = ""
                        te_vehicle.Text = ""
                        te_product.Text = ""
                        te_container.Text = ""
                        te_srs1.Text = ""
                        te_srs2.Text = ""
                        te_ecn.Text = ""
                        te_customer.Text = ""
                        te_proporcionsat.Text = ""
                        te_proporcionmadre.Text = ""
                        te_phc2.Text = ""
                        cb_eventos.Text = ""
                        te_online.Text = ""
                        te_circqty.Text = ""
                        te_smh.Text = ""
                        te_dual.Text = ""
                        butActualizar.Visible = False
                        If te_sews.Text <> "" Then
                            sql = "Select * from ERP_CTRL_XREF where Sews_part_no = '" & te_sews.Text.Trim & "'and Active <> 0 "
                            Dim ds As DataSet
                            ds = Consulta_Datos(sql, var_conexionERP)
                            GridControl1.DataSource = ds.Tables(0)
                            GV1.ExpandAllGroups()
                            GV1.BestFitColumns()
                            Cursor = Cursors.Default
                            GV1.Columns("Section_id").OptionsColumn.AllowEdit = False
                            GV1.Columns("Mfg_Plant").OptionsColumn.AllowEdit = False
                            GV1.Columns("PN_Qty").OptionsColumn.AllowEdit = False
                            GV1.Columns("FG_Plant").OptionsColumn.AllowEdit = False
                            GV1.Columns("SK_Plant").OptionsColumn.AllowEdit = False
                            GV1.Columns("DL").OptionsColumn.AllowEdit = False
                            GV1.Columns("Line_c").OptionsColumn.AllowEdit = False
                            GV1.Columns("SRS_Line_c").OptionsColumn.AllowEdit = False
                            GV1.Columns("Planner").OptionsColumn.AllowEdit = False
                            GV1.Columns("sews_part_no").OptionsColumn.AllowEdit = False
                            GV1.Columns("Supplier_id").OptionsColumn.AllowEdit = False
                            GV1.Columns("IHS_Part_no").OptionsColumn.AllowEdit = False
                            GV1.Columns("cust_part_no").OptionsColumn.AllowEdit = False
                            GV1.Columns("Short_part_no").OptionsColumn.AllowEdit = False
                            GV1.Columns("Std_Pack").OptionsColumn.AllowEdit = False
                            GV1.Columns("MPS_Format").OptionsColumn.AllowEdit = False
                            GV1.Columns("TipoEtiqArnes").OptionsColumn.AllowEdit = False
                            GV1.Columns("Division").OptionsColumn.AllowEdit = False
                            GV1.Columns("SubDivision").OptionsColumn.AllowEdit = False
                            GV1.Columns("Vehicle").OptionsColumn.AllowEdit = False
                            GV1.Columns("Product_type").OptionsColumn.AllowEdit = False
                            GV1.Columns("DOH_Min_Policy").OptionsColumn.AllowEdit = False
                            GV1.Columns("Container").OptionsColumn.AllowEdit = False
                            GV1.Columns("SRS1").OptionsColumn.AllowEdit = False
                            GV1.Columns("SRS2").OptionsColumn.AllowEdit = False
                            GV1.Columns("ECN").OptionsColumn.AllowEdit = False
                            GV1.Columns("Customer_id").OptionsColumn.AllowEdit = False
                            GV1.Columns("KMH_Destination").OptionsColumn.AllowEdit = False
                            GV1.Columns("Upd_dt").OptionsColumn.AllowEdit = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    

    Private Sub butActualizar_Click(sender As Object, e As EventArgs) Handles butActualizar.Click
        If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim activo, sews_part_no, nivel_diseno, ecn, short_part, sql As String
            For I = 0 To GV1.RowCount - 1
                activo = GV1.GetRowCellValue(I, "Active").ToString
                sews_part_no = GV1.GetRowCellValue(I, "sews_part_no").ToString
                nivel_diseno = GV1.GetRowCellValue(I, "DL").ToString
                ecn = GV1.GetRowCellValue(I, "ECN").ToString
                short_part = GV1.GetRowCellValue(I, "Short_part_no").ToString
                If activo = "0" Then
                    sql = "update dbo.ERP_CTRL_XREF  set Active = '" & activo & "', Event = '0' where sews_part_no = '" & sews_part_no & "' and DL = '" & nivel_diseno & "' and ECN = '" & ecn & "' and Short_part_no = '" & short_part & "'"
                    Executa_Query(sql, var_conexionERP)
                Else
                    If activo = "1" Then
                        sql = "select  * from ERP_CTRL_XREF where Active  = '1' and DL = '" & nivel_diseno & "' and sews_part_no = '" & sews_part_no & "'"
                        If Existe_Dato(sql, var_conexionERP) Then
                            DevExpress.XtraEditors.XtraMessageBox.Show("Activo ya existe", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            sql = "update dbo.ERP_CTRL_XREF  set Active = '" & activo & "', Event = '0' where sews_part_no = '" & sews_part_no & "' and DL = '" & nivel_diseno & "' and ECN = '" & ecn & "' and Short_part_no = '" & short_part & "'"
                            Executa_Query(sql, var_conexionERP)
                        End If
                    Else
                        If activo = "3" Then
                            sql = "select  * from ERP_CTRL_XREF where Active  = '3' and DL = '" & nivel_diseno & "' and sews_part_no = '" & sews_part_no & "'"
                            If Existe_Dato(sql, var_conexionERP) Then
                                DevExpress.XtraEditors.XtraMessageBox.Show("Activo ya existe", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            Else
                                sql = "update dbo.ERP_CTRL_XREF  set Active = '" & activo & "', Event = 'NDL' where sews_part_no = '" & sews_part_no & "' and DL = '" & nivel_diseno & "' and ECN = '" & ecn & "' and Short_part_no = '" & short_part & "'"
                                Executa_Query(sql, var_conexionERP)
                            End If
                        Else
                            DevExpress.XtraEditors.XtraMessageBox.Show("Activo Incorrecto", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_consultaECN_Click(sender As Object, e As EventArgs) Handles btn_consultaECN.Click
        Try
            If te_ecnid.Text <> "" Then
                sql = "Select ECN_ID, Application_date_PT , Description , User_upd as Usuario, Upd_dt as Ultima_actualizacion  from  ERP_CTRL_ECN where ECN_ID = '" & te_ecnid.Text.Trim & "'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                gc_ecn.DataSource = ds.Tables(0)
                gv_ecn.ExpandAllGroups()
                gv_ecn.BestFitColumns()
                Cursor = Cursors.Default
                gv_ecn.Columns("ECN_ID").OptionsColumn.AllowEdit = False
                gv_ecn.Columns("Usuario").OptionsColumn.AllowEdit = False
                gv_ecn.Columns("Ultima_actualizacion").OptionsColumn.AllowEdit = False
                SimpleButton6.Visible = False
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            If dt_fecha.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Fecha", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_description.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Descripcion", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_ecn_id.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar ECN", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Guardar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                sql = "select  * from ERP_CTRL_ECN where ECN_ID  = '" & te_ecn_id.Text & "'"
                If Existe_Dato(sql, var_conexionERP) Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("ECN , Ya Existe. Favor de verificar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    sql = "insert into ERP_CTRL_ECN  VALUES  ('" & te_ecn_id.Text.Trim & "',NULL,NULL,'" & dt_fecha.Text & "','" & dt_fecha.Text & "',NULL" & _
                        ",NULL,NULL,NULL,NULL,'" & var_adm_Usr_NICK & "',GETDATE()" & _
                         ",'" & te_description.Text.Trim & "',NULL)"
                    Executa_Query(sql, var_conexionERP)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    te_ecn_id.Text = ""
                    te_description.Text = ""
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim ecn, fechaaplicacion, descripcion, sql As String
            For I = 0 To gv_ecn.RowCount - 1
                ecn = gv_ecn.GetRowCellValue(I, "ECN_ID").ToString
                fechaaplicacion = gv_ecn.GetRowCellValue(I, "Application_date_PT")
                descripcion = gv_ecn.GetRowCellValue(I, "Description").ToString
                sql = "update dbo.ERP_CTRL_ECN  set Application_date_PT = '" & fechaaplicacion & "',Application_date = '" & fechaaplicacion & "', Upd_dt = Getdate() , Description = '" & descripcion & "' where  ECN_ID = '" & ecn & "' "
                Executa_Query(sql, var_conexionERP)
            Next
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Try
            If te_custpart.Text <> "" Then
                sql = "Select * from   ERP_CTRL_SMH  a left join ERP_CTRL_SMH_REV b on a.Rev = b.SMH_Rev  where Cust_part_no = '" & te_custpart.Text.Trim & "' and  b.Active = '1'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                gc_smh.DataSource = ds.Tables(0)
                gv_smh.ExpandAllGroups()
                gv_smh.BestFitColumns()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try
            If te_custpart1.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Cust Part No ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_dl1.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar DL ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Guardar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                sql = "select  * from ERP_CTRL_SMH where Cust_part_no  = '" & te_custpart1.Text & "' and DL = '" & te_dl1.Text & "'"
                If Existe_Dato(sql, var_conexionERP) Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("Cust Part No , Ya Existe. Favor de verificar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    sql = "insert into ERP_CTRL_SMH  VALUES  ('" & te_rev1.Text.Trim & "','" & te_custpart1.Text.Trim & "','" & te_dl1.Text.Trim & "','" & te_custid1.Text.Trim & "','" & te_circuits1.Text.Trim & "','" & te_joints.Text & "'" & _
                        ",'" & te_smhcnc.Text.Trim & "','" & te_smhmiddle.Text.Trim & "','" & te_smhcncttl.Text.Trim & "','" & te_smhsubassy.Text.Trim & "','" & te_smhassy.Text.Trim & "','" & te_smhinsp.Text.Trim & "'" & _
                         ",'" & te_smhassyttl.Text.Trim & "','" & te_smhttl.Text.Trim & "','" & te_madre.Text.Trim & "', '" & te_satelite.Text.Trim & "','" & te_smhsrs.Text.Trim & "','" & te_smhsatelite.Text.Trim & "','" & te_twist.Text.Trim & "')"
                    Executa_Query(sql, var_conexionERP)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    te_rev1.Text = ""
                    te_custpart1.Text = ""
                    te_dl1.Text = ""
                    te_custid1.Text = ""
                    te_circuits1.Text = ""
                    te_joints.Text = ""
                    te_smhcnc.Text = ""
                    te_smhmiddle.Text = ""
                    te_smhcncttl.Text = ""
                    te_smhsubassy.Text = ""
                    te_smhassy.Text = ""
                    te_smhinsp.Text = ""
                    te_smhassyttl.Text = ""
                    te_smhttl.Text = ""
                    te_madre.Text = ""
                    te_satelite.Text = ""
                    te_smhsrs.Text = ""
                    te_smhsatelite.Text = ""
                    te_twist.Text = ""
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridControl1_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        Try
            te_section.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Section_id").ToString
            te_mfg.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Mfg_Plant").ToString
            ''te_active.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Active").ToString
            te_pnqty.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "PN_Qty").ToString
            te_fg.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "FG_Plant").ToString
            te_dl.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "DL").ToString
            te_linec.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Line_c").ToString
            te_planner.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Planner").ToString
            te_sewsp.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "sews_part_no").ToString
            te_supplier.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Supplier_id").ToString
            te_ihs.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "IHS_Part_no").ToString
            te_custp.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "cust_part_no").ToString
            ''te_shortp.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Short_part_no").ToString
            te_stdp.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Std_Pack").ToString
            te_mpsf.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "MPS_Format").ToString
            te_tipoetiqarnes.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "TipoEtiqArnes").ToString
            te_division.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Division").ToString
            te_subdivision.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "SubDivision").ToString
            te_vehicle.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Vehicle").ToString
            te_product.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Product_type").ToString
            te_container.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Container").ToString
            te_srs1.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "SRS1").ToString
            te_srs2.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "SRS2").ToString
            '' te_ecn.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "ECN").ToString
            te_customer.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Customer_id").ToString
            te_proporcionsat.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Proporcion_satelite").ToString
            te_proporcionmadre.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Proporcion_Madre").ToString
            te_phc2.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "PHC2_Part_no_flg").ToString
            cb_eventos.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Event").ToString
            te_online.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "OnlinePrinting").ToString
            te_circqty.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "circ_qty_avg").ToString
            te_smh.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "smh_avg").ToString
            te_dual.Text = GV1.GetRowCellValue(GV1.FocusedRowHandle, "Dual_plant").ToString
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GV1_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GV1.CustomRowCellEditForEditing
        butActualizar.Visible = True
    End Sub
    Private Sub te_active_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles te_active.EditValueChanged
        butActualizar.Visible = False
    End Sub
    Private Sub te_dl_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles te_dl.EditValueChanged
        butActualizar.Visible = False
    End Sub
    Private Sub te_shortp_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles te_shortp.EditValueChanged
        butActualizar.Visible = False
    End Sub
    Private Sub te_ecn_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles te_ecn.EditValueChanged
        butActualizar.Visible = False
    End Sub
    Private Sub cb_eventos_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_eventos.EditValueChanged
        butActualizar.Visible = False
    End Sub
    Private Sub gv_ecn_CustomRowCellEdit(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles gv_ecn.CustomRowCellEdit
        SimpleButton6.Visible = True
    End Sub
    Private Sub te_ecn_id_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles te_ecn_id.EditValueChanged
        SimpleButton6.Visible = False
    End Sub
    Private Sub dt_fecha_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha.EditValueChanged
        SimpleButton6.Visible = False
    End Sub
    Private Sub te_description_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles te_description.EditValueChanged
        SimpleButton6.Visible = False
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Try
            gv_cnd.Columns.Clear()
            sql = "SP_CTRL_CND_SMH"
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            gc_cnd.DataSource = ds.Tables(0)
            gv_cnd.ExpandAllGroups()
            gv_cnd.BestFitColumns()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub gc_smh_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gc_smh.DoubleClick
        te_rev1.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "Rev").ToString
        te_custpart1.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "Cust_part_no").ToString
        te_dl1.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "DL").ToString
        te_custid1.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "Cust_id").ToString
        te_circuits1.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "Circuits").ToString
        te_joints.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "Joints").ToString
        te_smhcnc.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SHM_CNC")
        te_smhmiddle.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_Middle_Process")
        te_smhcncttl.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_CNC_TTL")
        te_smhsubassy.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_SubAssy")
        te_smhassy.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_Assy")
        te_smhinsp.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_Insp")
        te_smhassyttl.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_Assy_TTL")
        te_smhttl.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_TTL")
        te_madre.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "Madre").ToString
        te_satelite.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "Satelite").ToString
        te_smhsrs.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_SRS").ToString
        te_smhsatelite.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_Satelite").ToString
        te_twist.Text = gv_smh.GetRowCellValue(gv_smh.FocusedRowHandle, "SMH_Twist").ToString

    End Sub
End Class
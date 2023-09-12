Imports AccesoDatos
Imports Funciones
Public Class erp_ctrl_generar_sews_part
    Dim sql As String
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Base" Then
            SimpleButton7.Visible = True
            cb_sews.Visible = True
            LabelControl1.Visible = True
            GroupBox2.Visible = False
        Else
            SimpleButton7.Visible = False
            cb_sews.Visible = False
            LabelControl1.Visible = False
            cargar_Mfg_plant()
            cargar_Line_c()
            cargar_Planner()
            cargar_Evento()
            cargar_Combo()
            cargar_Customer()
            cargar_division()
            cargar_subdivision()
            cargar_vehiculo()
            cargar_product_type()
            cargar_ECN()
            te_pnqty.Text = ""
            te_fg.Text = ""
            te_dl.Text = ""
            te_sewsp.Text = ""
            te_ihs.Text = ""
            te_custp.Text = ""
            te_shortp.Text = ""
            te_stdp.Text = ""
            te_mpsf.Text = ""
            te_tipoetiqarnes.Text = ""
            te_container.Text = ""
            te_srs1.Text = ""
            te_srs2.Text = ""
            te_circqty.Text = ""
            te_smh.Text = ""
            te_doh.Text = ""
            cargar_sews_part()
            GroupBox2.Visible = True
        End If
    End Sub
    Private Sub erp_ctrl_generar_sews_part_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_sews_part()
    End Sub
    Private Sub cargar_sews_part()
        sql = " select distinct sews_part_no  from erp_ctrl_xref where Active <> '0'"
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_sews.Properties.DisplayMember = "sews_part_no"
        cb_sews.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_Mfg_plant()
        sql = " select distinct Codes  from erp_ctrl_codes_plant "
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_mfgplant.Properties.DisplayMember = "Codes"
        cb_mfgplant.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_Line_c()
        sql = " select Line_c, Nombre_comun from ERP_CTRL_LINES "
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_Linec.Properties.DisplayMember = "Line_c"
        cb_Linec.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_Planner()
        sql = " select planner_id from ERP_CTRL_PLANNER  where planner_id not like '%1%' "
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_planner.Properties.DisplayMember = "planner_id"
        cb_planner.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_Evento()
        sql = "select Evento_id , Evento_desc from ERP_CTRL_PRODUCT_EVENTS"
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_eventos.Properties.DisplayMember = "Evento_id"
        cb_eventos.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_Combo()
        sql = " select Combo_id , Combo from ERP_CTRL_COMBO "
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_combo.Properties.DisplayMember = "Combo_id"
        cb_combo.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_Customer()
        sql = "select distinct Cust_cd from ERP_CTRL_CUSTOMER "
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        te_customer.Properties.DisplayMember = "Cust_cd"
        te_customer.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_division()
        sql = "select Division_cd , Division_desc  from ERP_CTRL_DIVISION"
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_division.Properties.DisplayMember = "Division_cd"
        cb_division.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_subdivision()
        sql = "select SubDivision_cd , SubDivision_desc from ERP_CTRL_SUBDIVISION"
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_subdiv.Properties.DisplayMember = "SubDivision_cd"
        cb_subdiv.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_vehiculo()
        sql = " select Car_cd , Car_description from ERP_CTRL_VEHICLES "
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_vehicle.Properties.DisplayMember = "Car_cd"
        cb_vehicle.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_product_type()
        sql = " Select Type_cd , Type_desc from ERP_CTRL_PRODUCT_TYPE"
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        cb_type.Properties.DisplayMember = "Type_cd"
        cb_type.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub cargar_ECN()
        sql = "select distinct ECN_ID from erp_ctrl_ecn "
        Dim ds As DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        te_ecn.Properties.DisplayMember = "ECN_ID"
        te_ecn.Properties.DataSource = ds.Tables(0)
    End Sub
    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        If cb_sews.Text <> "" Then
            cargar_Combo()
            cargar_Mfg_plant()
            cargar_Line_c()
            cargar_Planner()
            cargar_Evento()
            cargar_Customer()
            cargar_division()
            cargar_subdivision()
            cargar_vehiculo()
            cargar_product_type()
            cargar_ECN()
            GroupBox2.Visible = True
            sql = "SELECT TOP 1 Section_id, Mfg_Plant, Active, PN_Qty, FG_Plant, SK_Plant, DL, Line_c, SRS_Line_c, Planner, sews_part_no, Supplier_id, IHS_Part_no, cust_part_no, " & _
            " Short_part_no, Std_Pack, MPS_Format, TipoEtiqArnes, Division, SubDivision, Vehicle, Product_type, DOH_Min_Policy, Container, SRS1, SRS2, ECN, Customer_id, " & _
            " KMH_Destination, Upd_dt, Proporcion_satelite, Proporcion_Madre, PHC2_Part_no_flg, Event, OnlinePrinting, circ_qty_avg, smh_avg, Dual_plant, Customer_ETA, " & _
            " cust_part_no_A, FGGS_DL, LOCAL_SRS_MFG, combo from ERP_CTRL_XREF where sews_part_no = '" & cb_sews.Text.Trim & "' and Active = '1'  "
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                cb_mfgplant.Text = ds.Tables(0).Rows(0)("Mfg_Plant").ToString
                cb_active.Text = ds.Tables(0).Rows(0)("Active").ToString
                te_container.Text = ds.Tables(0).Rows(0)("Container").ToString
                te_pnqty.Text = ds.Tables(0).Rows(0)("PN_Qty").ToString
                te_fg.Text = ds.Tables(0).Rows(0)("FG_Plant").ToString
                te_dl.Text = ds.Tables(0).Rows(0)("DL").ToString
                cb_Linec.Text = ds.Tables(0).Rows(0)("Line_c").ToString
                cb_planner.Text = ds.Tables(0).Rows(0)("Planner").ToString
                te_sewsp.Text = ds.Tables(0).Rows(0)("sews_part_no").ToString
                te_ihs.Text = ds.Tables(0).Rows(0)("IHS_Part_no").ToString
                te_custp.Text = ds.Tables(0).Rows(0)("cust_part_no").ToString
                te_shortp.Text = ds.Tables(0).Rows(0)("Short_part_no").ToString
                te_stdp.Text = ds.Tables(0).Rows(0)("Std_Pack").ToString
                te_mpsf.Text = ds.Tables(0).Rows(0)("MPS_Format").ToString
                te_tipoetiqarnes.Text = ds.Tables(0).Rows(0)("TipoEtiqArnes").ToString
                cb_division.Text = ds.Tables(0).Rows(0)("Division").ToString
                cb_subdiv.Text = ds.Tables(0).Rows(0)("SubDivision").ToString
                cb_vehicle.Text = ds.Tables(0).Rows(0)("Vehicle").ToString
                cb_type.Text = ds.Tables(0).Rows(0)("Product_type").ToString
                te_doh.Text = ds.Tables(0).Rows(0)("DOH_Min_Policy").ToString
                te_srs1.Text = ds.Tables(0).Rows(0)("SRS1").ToString
                te_srs2.Text = ds.Tables(0).Rows(0)("SRS2").ToString
                te_ecn.Text = ds.Tables(0).Rows(0)("ECN").ToString
                te_customer.Text = ds.Tables(0).Rows(0)("Customer_id").ToString
                cb_phc2.Text = ds.Tables(0).Rows(0)("PHC2_Part_no_flg").ToString
                cb_eventos.Text = ds.Tables(0).Rows(0)("Event").ToString
                cb_print.Text = ds.Tables(0).Rows(0)("OnlinePrinting").ToString
                te_circqty.Text = ds.Tables(0).Rows(0)("circ_qty_avg").ToString
                te_smh.Text = ds.Tables(0).Rows(0)("smh_avg").ToString
                cb_dual.Text = ds.Tables(0).Rows(0)("Dual_plant").ToString
                cb_combo.Text = ds.Tables(0).Rows(0)("combo").ToString
                cb_print.Select()
                cb_dual.Select()
                cb_combo.Select()
                cb_eventos.Select()
                cb_phc2.Select()
                cb_mfgplant.Select()
                cb_Linec.Select()
                cb_planner.Select()
                cb_vehicle.Select()
                cb_type.Select()
                cb_division.Select()
                cb_subdiv.Select()
                te_customer.Select()
                te_ecn.Select()
                cb_active.Select()
            End If
        End If
    End Sub
    Private Sub cb_mfgplant_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_mfgplant.EditValueChanged
        If cb_mfgplant.Text <> "" Then
            sql = " select Plant  from erp_ctrl_codes_plant  where Codes = '" & cb_mfgplant.Text.Trim & "' "
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                te_fg.Text = ds.Tables(0).Rows(0)("Plant").ToString
            End If
        End If
    End Sub
    Private Sub btn_customer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_customer.Click
    End Sub
    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        Try
            If cb_mfgplant.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Mfg Plant", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_active.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Activo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_container.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Contenedor", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_pnqty.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar PN Qty ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_fg.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar FG Plant ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_dl.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar DL ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_Linec.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Numero de Linea ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_planner.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Planner ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_sewsp.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Sews Part No ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_ihs.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar IHS Part No ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_custp.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Cust Part No ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_shortp.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Short Part No ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_stdp.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Std Pack ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_mpsf.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar MPS format ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_tipoetiqarnes.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Tipo etiqueta Arnes ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_division.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Division ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_subdiv.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar SubDivision ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_vehicle.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Vehicle ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_type.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Product Type ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_type.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Product Type ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_doh.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar DOH Min ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_srs1.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar SRS1 ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_srs2.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar SRS2 ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_ecn.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar ECN ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_customer.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Customer ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_phc2.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar PHC2", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_eventos.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Eventos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_print.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Online Printing", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_circqty.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Circuit Qty", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If te_smh.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar SMH avg", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_dual.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Dual Plant", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If cb_combo.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Combo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            '' ingresar codigo 


        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

    End Sub
End Class
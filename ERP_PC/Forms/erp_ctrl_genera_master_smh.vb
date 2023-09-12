Imports Funciones
Imports AccesoDatos
Public Class erp_ctrl_genera_master_smh
    Dim sql As String

    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        Dim Hoy = Date.Now
        Dim year = (Hoy.Year)
        Dim mes As String = "00"
        mes = "0" & Hoy.Month
        Dim sql As String
        If te_revision.Text = "" Then
            Exit Sub
        End If
        If te_contenido.Text = "" Then
            Exit Sub
        End If
        sql = "insert into ERP_CTRL_SMH_REV  VALUES  ('" & te_revision.Text.Trim & "','" & year & "', '" & mes & "','0', getdate(), '" & var_adm_Usr_NICK & "' , '" & te_contenido.Text.Trim & "' ) "
        Executa_Query(sql, var_conexionERP)
        DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        te_revision.Text = ""
        te_contenido.Text = ""
        Carga_Revisiones()
        CargaRevision()
    End Sub
    Private Sub erp_ctrl_genera_master_smh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaRevision()
        Carga_Revisiones()
    End Sub
    Public Sub CargaRevision()
        Dim ds As New DataSet
        Sql = "select SMH_Rev from dbo.ERP_CTRL_SMH_REV where Active = 1"
        ds = Consulta_Datos(Sql, var_conexionERP)
        LabelControl5.Text = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub
    Private Sub Carga_Revisiones()
        Sql = "select distinct SMH_Rev, Active from dbo.ERP_CTRL_SMH_REV "
        Dim ds As DataSet
        ds = Consulta_Datos(Sql, var_conexionERP)
        lu_revisiones.Properties.DisplayMember = "SMH_Rev"
        lu_revisiones.Properties.DataSource = ds.Tables(0)
    End Sub

    Private Sub btn_activar_Click(sender As Object, e As EventArgs) Handles btn_activar.Click

        Dim activo As String
        Dim ds As New DataSet
        sql = "select SMH_Rev from dbo.ERP_CTRL_SMH_REV where Active = 1"
        ds = Consulta_Datos(sql, var_conexionERP)
        activo = ds.Tables(0).Rows(0)(0).ToString.Trim
        'Desactivar 
        sql = "update dbo.ERP_CTRL_SMH_REV set Active = '0' where SMH_Rev = '" & activo & "' "
        Executa_Query(sql, var_conexionERP)
        'Activar
        sql = "update dbo.ERP_CTRL_SMH_REV set Active = '1' where SMH_Rev = '" & lu_revisiones.Text.Trim & "' "
        Executa_Query(sql, var_conexionERP)
        CargaRevision()
        Carga_Revisiones()
    End Sub

    Private Sub btn_rConsultar_Click(sender As Object, e As EventArgs) Handles btn_rConsultar.Click
        Try
            If te_revsmh.Text <> "" Then
                sql = "SP_CTRL_GENERA_MASTER_SMH '" & te_revsmh.Text.Trim & "'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                gc_master.DataSource = ds.Tables(0)
                gv_master.ExpandAllGroups()
                gv_master.BestFitColumns()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_xls_Click(sender As Object, e As EventArgs) Handles btn_xls.Click
        Try
            If te_xls.Text <> "" Then
                sql = "Select * from ERP_CTRL_SMH_XLS where MPS_Part_no ='" & te_xls.Text.Trim & "'"
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

    Private Sub btn_xref_Click(sender As Object, e As EventArgs) Handles btn_xref.Click
        Try
            If te_xref.Text <> "" Then
                sql = "Select * from ERP_CTRL_XREF where MPS_Format = '" & te_xref.Text.Trim & "'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                gc_xref.DataSource = ds.Tables(0)
                gv_xref.ExpandAllGroups()
                gv_xref.BestFitColumns()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_guardaref_Click(sender As Object, e As EventArgs) Handles btn_guardaref.Click
        Try

            If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then



                Dim Section_id, Mfg_Plant, Active, PN_Qty, FG_Plant, SK_Plant, DL, Line_c, SRS_Line_c, Planner, sews_part_no, Supplier_id, IHS_Part_no, cust_part_no, Short_part_no, Std_Pack, MPS_Format, TipoEtiqArnes, Division, SubDivision, Vehicle, Product_type, DOH_Min_Policy, Container, SRS1, SRS2, ECN, Customer_id, KMH_Destination, Upd_dt, Proporcion_satelite, Proporcion_Madre, PHC2_Part_no_flg, Evento, OnlinePrinting, circ_qty_avg, smh_avg, Dual_plant, Customer_ETA, cust_part_no_A, FGGS_DL, LOCAL_SRS_MFG, sql As String
                For I = 0 To gv_xref.RowCount - 1
                    'SOLICITUD = gridview.GetRowCellValue(I, "NoSolicitud").ToString
                    Section_id = gv_xref.GetRowCellValue(I, "Section_id").ToString
                    Mfg_Plant = gv_xref.GetRowCellValue(I, "Mfg_Plant")   '.ToString 'quitar string
                    Active = gv_xref.GetRowCellValue(I, "Active")
                    PN_Qty = gv_xref.GetRowCellValue(I, "PN_Qty")
                    FG_Plant = gv_xref.GetRowCellValue(I, "FG_Plant").ToString
                    'SK_Plant= gv_xref.GetRowCellValue(I, "SK_Plant")
                    DL = gv_xref.GetRowCellValue(I, "DL").ToString
                    Line_c = gv_xref.GetRowCellValue(I, "Line_c")
                    SRS_Line_c = gv_xref.GetRowCellValue(I, "SRS_Line_c").ToString
                    Planner = gv_xref.GetRowCellValue(I, "Planner").ToString
                    sews_part_no = gv_xref.GetRowCellValue(I, "sews_part_no").ToString
                    Supplier_id = gv_xref.GetRowCellValue(I, "Supplier_id").ToString
                    IHS_Part_no = gv_xref.GetRowCellValue(I, "IHS_Part_no").ToString
                    cust_part_no = gv_xref.GetRowCellValue(I, "cust_part_no").ToString
                    Short_part_no = gv_xref.GetRowCellValue(I, "Short_part_no").ToString
                    Std_Pack = gv_xref.GetRowCellValue(I, "Std_Pack")
                    MPS_Format = gv_xref.GetRowCellValue(I, "MPS_Format").ToString
                    TipoEtiqArnes = gv_xref.GetRowCellValue(I, "TipoEtiqArnes")
                    Division = gv_xref.GetRowCellValue(I, "Division").ToString
                    SubDivision = gv_xref.GetRowCellValue(I, "SubDivision").ToString
                    Vehicle = gv_xref.GetRowCellValue(I, "Vehicle").ToString
                    Product_type = gv_xref.GetRowCellValue(I, "Product_type").ToString
                    DOH_Min_Policy = gv_xref.GetRowCellValue(I, "DOH_Min_Policy")
                    Container = gv_xref.GetRowCellValue(I, "Container").ToString
                    SRS1 = gv_xref.GetRowCellValue(I, "SRS1").ToString
                    SRS2 = gv_xref.GetRowCellValue(I, "SRS2").ToString
                    ECN = gv_xref.GetRowCellValue(I, "ECN").ToString
                    Customer_id = gv_xref.GetRowCellValue(I, "Customer_id").ToString
                    'KMH_Destination = gv_xref.GetRowCellValue(I, "KMH_Destination ").ToString
                    Upd_dt = gv_xref.GetRowCellValue(I, "Upd_dt")
                    Proporcion_satelite = gv_xref.GetRowCellValue(I, "Proporcion_satelite")
                    Proporcion_Madre = gv_xref.GetRowCellValue(I, "Proporcion_Madre")
                    'PHC2_Part_no_flg = gv_xref.GetRowCellValue(I, "PHC2_Part_no_flg")
                    Evento = gv_xref.GetRowCellValue(I, "Event")
                    OnlinePrinting = gv_xref.GetRowCellValue(I, "OnlinePrinting")
                    circ_qty_avg = gv_xref.GetRowCellValue(I, "circ_qty_avg")
                    smh_avg = gv_xref.GetRowCellValue(I, "smh_avg")
                    Dual_plant = gv_xref.GetRowCellValue(I, "Dual_plant")
                    Customer_ETA = gv_xref.GetRowCellValue(I, "Customer_ETA")
                    cust_part_no_A = gv_xref.GetRowCellValue(I, "cust_part_no_A").ToString
                    FGGS_DL = gv_xref.GetRowCellValue(I, "FGGS_DL")
                    LOCAL_SRS_MFG = gv_xref.GetRowCellValue(I, "LOCAL_SRS_MFG")
                    sql = "update dbo.ERP_CTRL_XREF set DL = '" & DL & "', FGGS_DL = '" & FGGS_DL & "'  where section_id = '" & Section_id & "' and Mfg_Plant = '" & Mfg_Plant & "' and Active = '" & Active & "' and  PN_Qty = '" & PN_Qty & "' and FG_Plant  = '" & FG_Plant & "' and " & _
                    " Line_C = '" & Line_c & "' and Planner ='" & Planner & "' and sews_part_no = '" & sews_part_no & "' and Supplier_id = '" & Supplier_id & "' and  IHS_Part_no = '" & IHS_Part_no & "' and cust_part_no = '" & cust_part_no & "' and " & _
                    " Short_part_no = '" & Short_part_no & "' and Std_Pack = '" & Std_Pack & "' and MPS_Format = '" & MPS_Format & "' and TipoEtiqArnes = '" & TipoEtiqArnes & "' and Division = '" & Division & "' and SubDivision = '" & SubDivision & "' and Vehicle = '" & Vehicle & "'  and " & _
                    " Product_type = '" & Product_type & "' and DOH_Min_Policy = '" & DOH_Min_Policy & "' and Container = '" & Container & "' and SRS1 = '" & SRS1 & "' and SRS2 = '" & SRS2 & "'  and ECN = '" & ECN & "' and Customer_id = '" & Customer_id & "' and " & _
                    " Upd_dt = '" & Upd_dt & "' and Proporcion_satelite = '" & Proporcion_satelite & "' and Proporcion_Madre = '" & Proporcion_Madre & "' and Event = '" & Evento & "' and OnlinePrinting = '" & OnlinePrinting & "'and circ_qty_avg = '" & circ_qty_avg & "' and" & _
                    " smh_avg = '" & smh_avg & "' and Dual_plant = '" & Dual_plant & "' and Customer_ETA = '" & Customer_ETA & "' and cust_part_no_A = '" & cust_part_no_A & "'and LOCAL_SRS_MFG = '" & LOCAL_SRS_MFG & "'"
                    Executa_Query(sql, var_conexionERP)
                Next
            End If
            DevExpress.XtraEditors.XtraMessageBox.Show("Solicitud Enviada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub butConsultar_Click(sender As Object, e As EventArgs) Handles butConsultar.Click
        Try
            sql = " SELECT sews_part_no,DL, Customer_id , Active FROM ERP_CTRL_XREF GROUP BY sews_part_no ,DL, Customer_id , Active HAVING COUNT(*)>1 "
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            GC_Rep.DataSource = ds.Tables(0)
            GV_Rep.ExpandAllGroups()
            GV_Rep.BestFitColumns()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
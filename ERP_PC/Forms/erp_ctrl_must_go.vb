Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Configuration
Imports Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.IO
Imports System.Drawing.Point
Imports Microsoft.Office.Interop
Imports System.Drawing.Drawing2D
Imports Funciones
Imports AccesoDatos

Public Class erp_ctrl_must_go
    Dim sql, planner As String
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim dialog As New OpenFileDialog
        Dim path As String
        Dim ConnExcel As New OleDb.OleDbConnection
        Dim Cmd As New OleDb.OleDbCommand
        Dim Da As New OleDb.OleDbDataAdapter
        Dim Ds As New DataSet
        Dim Dset As New DataSet
        Dim conn As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ObjExcel As Excel.ApplicationClass
        Dim ObjW As Excel.WorkbookClass
        Dim nomHoja As String
        Dim FechaActual As Date
        Try
            dialog.InitialDirectory = "C:\"
            dialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*"
            If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path = dialog.FileName
                ObjExcel = New Excel.ApplicationClass
                ObjW = ObjExcel.Workbooks.Open(path)
                nomHoja = ObjW.Sheets(1).Name
                ObjW.Close()
                ObjExcel.Quit()
                ConnExcel.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & "; Extended Properties= Excel 8.0;"
                Cmd.CommandText = "SELECT *  FROM [" & nomHoja & "$]"
                Cmd.Connection = ConnExcel
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Ds.Tables(0).TableName = "Excel"
                GridControl1.DataSource = Ds.Tables(0)
                conn.ConnectionString = var_conexionERP
                comm.CommandType = CommandType.Text
                comm.Connection = conn
                conn.Open()
                FechaActual = Now
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    sql = "DELETE FROM  ERP_CTRL_ASN_HISTORY_TMP"
                    Executa_Query(sql, var_conexionERP)
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_ASN_HISTORY_TMP VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(11).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(12).ToString.Trim & "'," & _
                        " '" & Ds.Tables(0).Rows(i)(13).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(14).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(15).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(16).ToString.Trim & "' ,'" & Ds.Tables(0).Rows(i)(17).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(18).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(19).ToString.Trim & "'," & _
                        " '" & Ds.Tables(0).Rows(i)(20).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(21).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(22).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(23).ToString.Trim & "' ,'" & Ds.Tables(0).Rows(i)(24).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(25).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(26).ToString.Trim & "', '" & FechaActual & "' )"
                        comm.ExecuteNonQuery()
                    Next i
                    sql = "select distinct convert(date,Info_dt) from ERP_CTRL_ASN_HISTORY_TMP"
                    Dim dr As New DataSet
                    dr = Consulta_Datos(sql, var_conexionERP)
                    If dr.Tables(0).Rows.Count > 0 Then
                        FechaActual = dr.Tables(0).Rows(0)(0).ToString.Trim
                        sql = "select DISTINCT Info_dt from ERP_CTRL_ASN_HISTORY where convert(date,Info_dt) = '" & FechaActual & "' "
                        If Existe_Dato(sql, var_conexionERP) Then
                            DevExpress.XtraEditors.XtraMessageBox.Show("Ya existen Registros en Fecha Actual, Se Cancelara la Importacion", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            sql = "DELETE FROM  ERP_CTRL_ASN_HISTORY_TMP"
                            Executa_Query(sql, var_conexionERP)
                            GV1.Columns.Clear()
                        Else
                            sql = "INSERT INTO ERP_CTRL_ASN_HISTORY SELECT * FROM ERP_CTRL_ASN_HISTORY_TMP"
                            Executa_Query(sql, var_conexionERP)
                            sql = "DELETE FROM  ERP_CTRL_ASN_HISTORY_TMP"
                            Executa_Query(sql, var_conexionERP)
                            sql = "DELETE FROM  ERP_CTRL_MUST_GO_ASN2"
                            Executa_Query(sql, var_conexionERP)
                            sql = "insert into ERP_CTRL_MUST_GO_ASN2 SELECT Ship_date1 , Base_part_number , Customer , ASN_number1 , Truck1 , SUM(Sets) as Total , convert(date,Info_dt)" & _
                            " FROM ERP_CTRL_ASN_HISTORY WHERE ASN_number2 = '' and Info_dt = CONVERT(DATE,GETDATE())" & _
                            " group by Ship_date1 , Base_part_number , Customer , ASN_number1 , Truck1 , convert(date,Info_dt)"
                            Executa_Query(sql, var_conexionERP)
                            XtraTabPage2.Parent = XtraTabControl1
                            XtraTabPage3.Parent = XtraTabControl1
                            XtraTabPage4.Parent = XtraTabControl1
                            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            GV1.Columns.Clear()
                        End If
                    Else
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub erp_ctrl_must_go_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT  DISTINCT  Info_dt FROM ERP_CTRL_ASN_HISTORY WHERE Info_dt = CONVERT(DATE,GETDATE())"
        Dim du As New DataSet
        du = Consulta_Datos(sql, var_conexionERP)
        If du.Tables(0).Rows.Count > 0 Then
            XtraTabPage1.TabControl.Visible = True
            XtraTabPage2.TabControl.Visible = True
            XtraTabPage3.TabControl.Visible = True
            XtraTabPage4.TabControl.Visible = True
            SimpleButton1.Visible = False
            GridControl1.Visible = False
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("ASN History no ha sido Cargado", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            XtraTabPage2.Parent = Nothing
            XtraTabPage3.Parent = Nothing
            XtraTabPage4.Parent = Nothing
        End If
        sql = "Select planner_id from  ERP_CTRL_PLANNER where planner_descr = '" & var_adm_Usr_NICK & "'"
        Dim ds As New DataSet
        ds = Consulta_Datos(sql, var_conexionERP)
        If ds.Tables(0).Rows.Count > 0 Then
            planner = ds.Tables(0).Rows(0)(0).ToString.Trim
            planner = planner.Substring(1, 2)
            CargaSewsPartNo()
            CargaNombre()
            '' GridApprove2()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Usuario No se encuentra en la Base de Datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            XtraTabPage1.Parent = Nothing
            XtraTabPage2.Parent = Nothing
            XtraTabPage3.Parent = Nothing
            XtraTabPage4.Parent = Nothing
        End If
        sql = " select distinct planner_id from erp_ctrl_must_go_approved where planner_id = '" & planner & "'"
        If Existe_Dato(sql, var_conexionERP) Then
            GroupBox4.Visible = True
            GroupBox5.Visible = True
            GroupBox6.Visible = True
            GroupBox8.Visible = True
            GridApprove()
        Else
            GroupBox4.Visible = False
            GroupBox5.Visible = False
            GroupBox6.Visible = False
            GroupBox8.Visible = False
        End If
        GridApprove6()
        ' CONSULTAR SI EL PLANNER YA PUSO DATOS EN LA TABLA DE VALIDACIONES SI EXISTEN EN EL ULTIMO NIVEL NO MOSTRAR LOS DATOS  
        sql = "select * from erp_Ctrl_must_go_validation where info_date =  convert(date,getdate()) and Planner = '" & planner & "'   and   Activo >= '2' "
        If Existe_Dato(sql, var_conexionERP) Then
            SimpleButton2.Visible = False
            SimpleButton10.Visible = False
            SimpleButton12.Visible = False
            SimpleButton11.Visible = False
            SimpleButton3.Visible = False
            SimpleButton4.Visible = False
            DevExpress.XtraEditors.XtraMessageBox.Show("Ya existen Must Go para TDC", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            SimpleButton2.Visible = True
            SimpleButton10.Visible = True
            SimpleButton12.Visible = True
            SimpleButton11.Visible = True
        End If
        Timer1.Start()
        Dim dr As New DataSet
        Dim FechaMin As DateTime
        FechaMin = Now.ToShortDateString
        sql = "select convert(date,getdate())"
        dr = Consulta_Datos(sql, var_conexionERP)
        FechaMin = dr.Tables(0).Rows(0)(0).ToString
    End Sub
    Public Sub GridApprove6()
        Try
            GridView6.Columns.Clear()
            sql = "select Planner, case Activo when 0 then 'Generado' when 1 then 'En Proceso' when 2 then 'Finalizado' when 3 then 'Finalizado sin Criticos' when 4 then 'No Ingreso'  end  as 'Estatus' " & _
            "from erp_Ctrl_must_go_validation  where info_date = convert(date, getdate())"
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            GridControl6.DataSource = ds.Tables(0)
            GridView6.ExpandAllGroups()
            GridView6.BestFitColumns()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GridApprove()
        Try
            GridView3.Columns.Clear()
            sql = "Select * from erp_ctrl_must_go_approved"
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            GridControl3.DataSource = ds.Tables(0)
            GridView3.ExpandAllGroups()
            GridView3.BestFitColumns()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CargaSewsPartNo()
        Dim ds As New DataSet
        Try
            sql = "select  distinct  Sews_part_no from  ERP_CTRL_XREF where Planner = '" & planner & "'  and Active <> '0'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_sews_parte.Properties.DataSource = ds.Tables(0)
            up_sews_parte.Properties.DisplayMember = "Sews_part_no"
            up_sews_parte.Properties.ValueMember = "Sews_part_no"
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub cargarCustumer()
        Dim ds As New DataSet
        Try
            sql = "Select  distinct Customer_id as Cliente From ERP_CTRL_XREF where Planner = '" & planner & "'  and Active <> '0' and sews_part_no = '" & up_sews_parte.Text & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            up_cliente.Properties.DisplayMember = "Cliente"
            up_cliente.Properties.ValueMember = "Cliente"
            up_cliente.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub up_sews_parte_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles up_sews_parte.EditValueChanged
        cargarCustumer()
    End Sub
    Public Sub CargaNombre()
        Dim ds As New DataSet
        Try
            sql = "select planner_id, planner_descr from ERP_CTRL_PLANNER where  SUBSTRING(planner_id,1,1) <> '1'"
            ds = Consulta_Datos(sql, var_conexionERP)
            lu_planner.Properties.DataSource = ds.Tables(0)
            lu_planner.Properties.DisplayMember = "planner_id"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SimpleButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton5.Click
        sql = " select distinct planner_id from erp_ctrl_must_go_approved where planner_id = '" & lu_planner.Text.Trim & "'"
        If Existe_Dato(sql, var_conexionERP) Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Ya existen Planner", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            sql = "insert into  erp_ctrl_must_go_approved select planner_id , planner_descr , 'Aprobado' from ERP_CTRL_PLANNER where planner_id = '" & lu_planner.Text.Trim & "' "
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion Almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GridApprove()
        End If
    End Sub
    Private Sub SimpleButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton6.Click
        Try
            Dim id, sql As String
            id = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "planner_id").ToString
            sql = " DELETE FROM erp_ctrl_must_go_approved where planner_id = '" & id & "'"
            Executa_Query(sql, var_conexionERP)
            GridApprove()
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Try
            If te_sews.Text <> "" Then
                If ComboBox2.Text <> "" Then
                    sql = "update erp_Ctrl_must_go_deadline set Hour = '" & te_sews.Text.Trim & "' , upd_date = Getdate()  where Type  = '" & ComboBox2.Text.Trim & "'"
                    Executa_Query(sql, var_conexionERP)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    te_sews.Text = ""
                    ComboBox2.Text = ""
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Ingresa Datos ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Ingresa Datos ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_corto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_corto.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub tb_doh_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_doh.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Try
            If ComboBox1.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Tipo", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If up_sews_parte.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Sews Part No", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If up_cliente.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Cliente", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If tb_corto.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Qty Corto", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If dt_fecha.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Fecha Corto", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If tb_doh.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar DOH", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If tb_comentario.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Comentario", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim cust_part, plant, shortdate, lead_time As String
            Dim deadline As Integer
            ' CONSULTAR CUST PART 
            Dim dr As New DataSet
            sql = "select TOP 1 cust_part_no from ERP_CTRL_XREF where sews_part_no = '" & up_sews_parte.Text & "' and Customer_id  = '" & up_cliente.Text & "' and Planner = '" & planner & "' and active <> '0'"
            dr = Consulta_Datos(sql, var_conexionERP)
            cust_part = dr.Tables(0).Rows(0)(0).ToString
            ' CONSULTO PLANT 
            Dim du As New DataSet
            sql = "select TOP 1 fg_plant from ERP_CTRL_XREF where sews_part_no = '" & up_sews_parte.Text & "' and Customer_id  = '" & up_cliente.Text & "' and Planner = '" & planner & "' and active <> '0'"
            du = Consulta_Datos(sql, var_conexionERP)
            plant = du.Tables(0).Rows(0)(0).ToString
            'DIA A CORTO
            Dim dw As New DataSet
            sql = "  SELECT  (DATEDIFF(dd, GETDATE()+1, CONVERT(DATE,'" & dt_fecha.Text & "')) ) " & _
            "-(DATEDIFF(wk, GETDATE()+1, '" & dt_fecha.Text & "') * 2)-1 " & _
            "-(CASE WHEN DATENAME(dw, GETDATE()) = 'Sunday' THEN 1 ELSE 0 END)" & _
            "-(CASE WHEN DATENAME(dw, '" & dt_fecha.Text & "') = 'Saturday' THEN 1 ELSE 0 END)"
            dw = Consulta_Datos(sql, var_conexionERP)
            shortdate = dw.Tables(0).Rows(0)(0).ToString
            Dim dc As New DataSet
            sql = " select  c.lead_time  from erp_ctrl_xref a left join ERP_CTRL_CUST_DELIVER b  on a.Customer_id = b.Customer_id   left join erp_ctrl_warehouses2  c " & _
            " on rtrim(ltrim(b.ship_to_whse)) = rtrim(ltrim(c.Sews_warehouse_id))  where sews_part_no = '" & up_sews_parte.Text.Trim & "' and a.Customer_id = '" & up_cliente.Text & "' and a.active = '1' and b.Active = '1' "
            dc = Consulta_Datos(sql, var_conexionERP)
            If dc.Tables(0).Rows.Count > 0 Then
                lead_time = dc.Tables(0).Rows(0)(0)
            Else
            End If
            deadline = shortdate - lead_time
            If ComboBox1.Text = "TDC" Then
                sql = "SELECT * FROM ERP_CTRL_MUST_GO_TDC  WHERE sews_part_no = '" & up_sews_parte.Text.Trim & "' and  Customer_id = '" & up_cliente.Text & "' and convert(date,date) = convert(date,getdate())"
                If Existe_Dato(sql, var_conexionERP) Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("Sews Part Number ya Ingresado", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cargarCustumer()
                    CargaSewsPartNo()
                    ComboBox1.Text = ""
                    up_sews_parte.EditValue = ""
                    up_cliente.EditValue = ""
                    tb_corto.Text = ""
                    dt_fecha.Text = ""
                    tb_doh.Text = ""
                    tb_comentario.Text = ""
                Else
                    sql = "insert into ERP_CTRL_MUST_GO_TDC  VALUES  (GETDATE(),'" & ComboBox1.Text.Trim & "','" & up_sews_parte.Text.Trim & "','" & cust_part & "', '" & up_cliente.Text & "','" & plant & "', '" & dt_fecha.Text & "' " & _
                      ",'" & tb_corto.Text & "','0','" & tb_doh.Text.Trim & "','" & deadline & "','0','" & tb_comentario.Text.Trim & "')"
                    Executa_Query(sql, var_conexionERP)
                    cargarCustumer()
                    CargaSewsPartNo()
                    ComboBox1.Text = ""
                    up_sews_parte.EditValue = ""
                    up_cliente.EditValue = ""
                    tb_corto.Text = ""
                    dt_fecha.Text = ""
                    tb_doh.Text = ""
                    tb_comentario.Text = ""
                    GridApprove2()
                    sql = "select * from erp_Ctrl_must_go_validation where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                    Dim dg As New DataSet
                    dg = Consulta_Datos(sql, var_conexionERP)
                    If dg.Tables(0).Rows.Count > 0 Then
                    Else
                        sql = "insert into ERP_CTRL_MUST_GO_validation values (convert(date,getdate()),'0','" & planner & "')"
                        Executa_Query(sql, var_conexionERP)
                    End If
                    GridApprove6()
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If ComboBox1.Text = "Plantas" Then
                    sql = "SELECT * FROM ERP_CTRL_MUST_GO_PLANTAS  WHERE sews_part_no = '" & up_sews_parte.Text.Trim & "' and  Customer_id = '" & up_cliente.Text & "' and convert(date,date) = convert(date,getdate())"
                    If Existe_Dato(sql, var_conexionERP) Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Sews Part Number ya Ingresado", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cargarCustumer()
                        CargaSewsPartNo()
                        ComboBox1.Text = ""
                        up_sews_parte.EditValue = ""
                        up_cliente.EditValue = ""
                        tb_corto.Text = ""
                        dt_fecha.Text = ""
                        tb_doh.Text = ""
                        tb_comentario.Text = ""
                    Else
                        sql = "insert into ERP_CTRL_MUST_GO_PLANTAS  VALUES  (GETDATE(),'" & ComboBox1.Text.Trim & "','" & up_sews_parte.Text.Trim & "','" & cust_part & "', '" & up_cliente.Text & "','" & plant & "', '" & dt_fecha.Text & "' " & _
                          ",'" & tb_corto.Text & "','0','" & tb_doh.Text.Trim & "','" & deadline & "','0','" & tb_comentario.Text.Trim & "')"
                        Executa_Query(sql, var_conexionERP)
                        cargarCustumer()
                        CargaSewsPartNo()
                        ComboBox1.Text = ""
                        up_sews_parte.EditValue = ""
                        up_cliente.EditValue = ""
                        tb_corto.Text = ""
                        dt_fecha.Text = ""
                        tb_doh.Text = ""
                        tb_comentario.Text = ""
                        GridApprove2()
                        sql = "select * from erp_Ctrl_must_go_validation where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                        Dim dg As New DataSet
                        dg = Consulta_Datos(sql, var_conexionERP)
                        If dg.Tables(0).Rows.Count > 0 Then
                        Else
                            sql = "insert into ERP_CTRL_MUST_GO_validation values (convert(date,getdate()),'0','" & planner & "')"
                            Executa_Query(sql, var_conexionERP)
                        End If
                        GridApprove6()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dt_fecha_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_fecha.EditValueChanged
        Try
            If dt_fecha.Text = "" Then
                Exit Sub
            Else
                Dim dw As New DataSet
                sql = "  SELECT  (DATEDIFF(dd, GETDATE(), CONVERT(DATE,'" & dt_fecha.Text & "')) ) -(DATEDIFF(wk, GETDATE(), CONVERT(DATE,'" & dt_fecha.Text & "')) * 2 ) -(CASE WHEN DATENAME(dw, GETDATE()) = 'Sunday' THEN 1 ELSE 0 END)" & _
                "-(CASE WHEN DATENAME(dw, CONVERT(DATE,'" & dt_fecha.Text & "')) = 'Saturday' THEN 1 ELSE 0 END) "
                dw = Consulta_Datos(sql, var_conexionERP)
                tb_doh.Text = dw.Tables(0).Rows(0)(0).ToString
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GridApprove2()
        Try
            GridView2.Columns.Clear()
            SimpleButton2.Visible = False
            SimpleButton10.Visible = False
            SimpleButton12.Visible = False
            SimpleButton11.Visible = False
            SimpleButton3.Visible = False
            SimpleButton4.Visible = False
            sql = "select a.Plant , a.sews_part_no ,a.customer_id, convert(date,a.Short_date) as Short_Date ," & _
            " STUFF((select  ',' + c.ASN_number1 from ERP_CTRL_MUST_GO_ASN2 c where a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer" & _
            " group by c.ASN_number1 for XML Path('')),1,1,'') as ASN_number1, " & _
            " STUFF(( select  ',' + c.Truck1  from ERP_CTRL_MUST_GO_ASN2 c where    a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer " & _
            " group by c.Truck1 for XML Path('')),1,1,'') as Trucks, " & _
            " STUFF(( select  ',' + convert(varchar,convert (date,c.Ship_date1)) from ERP_CTRL_MUST_GO_ASN2 c where   a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer " & _
            " group by c.Ship_date1 for XML Path('')),1,1,'') as Plant_ship_date, " & _
            " STUFF(( select  ',' + convert(varchar,c.Total) from ERP_CTRL_MUST_GO_ASN2 c where a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer " & _
            " group by c.Total for XML Path('')),1,1,'') as Inv_TDC_total " & _
            " ,sum(c.Total) as Total_TDC, case a.A_Embarcar when 0 then sum(c.Total) else a.A_Embarcar end as 'A_Embarcar',a.Short_Qty , a.DOH , f.rank  as Rank , d.Ship_to_whse as Destino ,  e.planner_descr as Planner , a.Comment , (sum(c.Total)-A.Short_Qty) as Resta   " & _
            " from ERP_CTRL_MUST_GO_TDC a left join ERP_CTRL_XREF b on a.sews_part_no = b.sews_part_no and a.customer_id = b.Customer_id  and a.cust_part_no = b.cust_part_no  " & _
            " left join ERP_CTRL_MUST_GO_ASN2 c on a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer  left join ERP_CTRL_CUST_DELIVER d on a.customer_id = d.Customer_id  " & _
            " left join ERP_CTRL_PLANNER e on b.Planner = e.planner_id  left join ERP_CTRL_MUST_GO_rank f on a.Rank = f.deadline " & _
            " where b.Active = '1'  and  b.Planner = '" & planner & "' and convert(date,a.date) = convert(date,getdate()) and a.Complete <> '2'  and d.Active = '1' and a.sews_part_no not in ( '82192-0R130H','82191-0R050H','82192-0R180H','82192-0R140H') " & _
            " group by a.Plant , a.sews_part_no ,a.customer_id,  a.Short_Qty , a.DOH , f.rank  , d.Ship_to_whse ,  e.planner_descr , a.Comment , a.Short_date ,a.A_Embarcar " & _
            " union all " & _
            " select a.Plant , a.sews_part_no ,a.customer_id, convert(date,a.Short_date) as Short_Date , " & _
            " STUFF((select  ',' + c.ASN_number1 from ERP_CTRL_MUST_GO_ASN2 c where substring(a.sews_part_no,0,12)  = c.Base_part_number and a.customer_id = c.Customer  " & _
            " group by c.ASN_number1 for XML Path('')),1,1,'') as ASN_number1,  " & _
            " STUFF(( select  ',' + c.Truck1  from ERP_CTRL_MUST_GO_ASN2 c where  substring(a.sews_part_no,0,12) = c.Base_part_number and a.customer_id = c.Customer  " & _
            " group by c.Truck1 for XML Path('')),1,1,'') as Trucks,  " & _
            " STUFF(( select  ',' + convert(varchar,convert (date,c.Ship_date1)) from ERP_CTRL_MUST_GO_ASN2 c where   substring(a.sews_part_no,0,12)  = c.Base_part_number and a.customer_id = c.Customer  " & _
            " group by c.Ship_date1 for XML Path('')),1,1,'') as Plant_ship_date,  " & _
            " STUFF(( select  ',' + convert(varchar,c.Total) from ERP_CTRL_MUST_GO_ASN2 c where substring(a.sews_part_no,0,12) = c.Base_part_number and a.customer_id = c.Customer  " & _
            " group by c.Total for XML Path('')),1,1,'') as Inv_TDC_total  " & _
            " ,sum(c.Total) as Total_TDC, case a.A_Embarcar when 0 then sum(c.Total) else a.A_Embarcar end as 'A_Embarcar',a.Short_Qty , a.DOH , f.rank  as Rank , d.Ship_to_whse as Destino ,  e.planner_descr as Planner , a.Comment , (sum(c.Total)-A.Short_Qty) as Resta   " & _
            "from ERP_CTRL_MUST_GO_TDC a left join ERP_CTRL_XREF b on a.sews_part_no = b.sews_part_no and a.customer_id = b.Customer_id  and a.cust_part_no = b.cust_part_no   " & _
            " left join ERP_CTRL_MUST_GO_ASN2 c on substring(a.sews_part_no,0,12) = c.Base_part_number and a.customer_id = c.Customer  left join ERP_CTRL_CUST_DELIVER d on a.customer_id = d.Customer_id  " & _
            " left join ERP_CTRL_PLANNER e on b.Planner = e.planner_id  left join ERP_CTRL_MUST_GO_rank f on a.Rank = f.deadline  " & _
            " where b.Active = '1'  and  b.Planner = '" & planner & "' and convert(date,a.date) = convert(date,getdate()) and a.Complete <> '2'  and d.Active = '1' and a.sews_part_no  in ( '82192-0R130H','82191-0R050H','82192-0R180H','82192-0R140H')  " & _
            " group by a.Plant , a.sews_part_no ,a.customer_id,  a.Short_Qty , a.DOH , f.rank  , d.Ship_to_whse ,  e.planner_descr , a.Comment , a.Short_date ,a.A_Embarcar  "
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            GridControl2.DataSource = ds.Tables(0)
            If ds.Tables(0).Rows.Count > 0 Then
                GridView2.Columns("Resta").Visible = False
                ''solo permitir editar la columna de A_Embarcar y la de Comentarios 
                GridView2.ExpandAllGroups()
                GridView2.BestFitColumns()
                GridView2.Columns("Plant").OptionsColumn.AllowEdit = False
                GridView2.Columns("sews_part_no").OptionsColumn.AllowEdit = False
                GridView2.Columns("customer_id").OptionsColumn.AllowEdit = False
                GridView2.Columns("Short_Date").OptionsColumn.AllowEdit = False
                GridView2.Columns("ASN_number1").OptionsColumn.AllowEdit = False
                GridView2.Columns("Trucks").OptionsColumn.AllowEdit = False
                GridView2.Columns("Plant_ship_date").OptionsColumn.AllowEdit = False
                GridView2.Columns("Inv_TDC_total").OptionsColumn.AllowEdit = False
                GridView2.Columns("Total_TDC").OptionsColumn.AllowEdit = False
                GridView2.Columns("Short_Qty").OptionsColumn.AllowEdit = False
                GridView2.Columns("DOH").OptionsColumn.AllowEdit = False
                GridView2.Columns("Rank").OptionsColumn.AllowEdit = False
                GridView2.Columns("Destino").OptionsColumn.AllowEdit = False
                GridView2.Columns("Planner").OptionsColumn.AllowEdit = False
                Cursor = Cursors.Default
                SimpleButton2.Visible = True
                SimpleButton10.Visible = True
                SimpleButton12.Visible = True
                SimpleButton11.Visible = True
                SimpleButton3.Visible = True
                SimpleButton4.Visible = True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GridApprove2_PLANTAS()
        Try
            GridView2.Columns.Clear()
            SimpleButton2.Visible = False
            SimpleButton10.Visible = False
            SimpleButton12.Visible = False
            SimpleButton11.Visible = False
            SimpleButton3.Visible = False
            SimpleButton4.Visible = False
            sql = "SP_CTRL_MUSTGO_PLANTAS '" & planner & " '"
            Dim ds As DataSet
            ds = Consulta_Datos(sql, var_conexionERP)
            GridControl2.DataSource = ds.Tables(0)
            If ds.Tables(0).Rows.Count > 0 Then
                GridView2.ExpandAllGroups()
                GridView2.BestFitColumns()
                GridView2.Columns("Plant").OptionsColumn.AllowEdit = False
                GridView2.Columns("sews_part_no").OptionsColumn.AllowEdit = False
                GridView2.Columns("customer_id").OptionsColumn.AllowEdit = False
                GridView2.Columns("Short_Date").OptionsColumn.AllowEdit = False
                GridView2.Columns("Adherencia").OptionsColumn.AllowEdit = False
                GridView2.Columns("Planeado_desde").OptionsColumn.AllowEdit = False
                GridView2.Columns("Qty_Plan_Hoy").OptionsColumn.AllowEdit = False
                GridView2.Columns("Inv_Piso").OptionsColumn.AllowEdit = False
                GridView2.Columns("Short_Qty").OptionsColumn.AllowEdit = False
                GridView2.Columns("DOH").OptionsColumn.AllowEdit = False
                GridView2.Columns("Rank").OptionsColumn.AllowEdit = False
                GridView2.Columns("Destino").OptionsColumn.AllowEdit = False
                GridView2.Columns("Planner").OptionsColumn.AllowEdit = False
                Cursor = Cursors.Default
                SimpleButton2.Visible = True
                SimpleButton10.Visible = True
                SimpleButton12.Visible = True
                SimpleButton11.Visible = True
                SimpleButton3.Visible = True
                SimpleButton4.Visible = True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.Text = "TDC" Then
            GridApprove2()
        Else
            GridApprove2_PLANTAS()
        End If
    End Sub
    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Try
            If ComboBox4.Text = "TDC" Then
                Dim sews_part, customer, plant, shortqty, sql As String
                sews_part = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "sews_part_no").ToString
                customer = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "customer_id").ToString
                plant = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Plant").ToString
                sql = " delete from ERP_CTRL_MUST_GO_TDC where sews_part_no = '" & sews_part & "' and customer_id = '" & customer & "' and plant = '" & plant & "'  and convert(date,date) = convert(date,getdate()) "
                Executa_Query(sql, var_conexionERP)
                GridApprove2()
                DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim sews_part, customer, plant, sql As String
                sews_part = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "sews_part_no").ToString
                customer = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "customer_id").ToString
                plant = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Plant").ToString
                sql = " delete from ERP_CTRL_MUST_GO_PLANTAS where sews_part_no = '" & sews_part & "' and customer_id = '" & customer & "' and plant = '" & plant & "'  and convert(date,date) = convert(date,getdate()) "
                Executa_Query(sql, var_conexionERP)
                GridApprove2_PLANTAS()
                DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton4.Click
        Try
            If ComboBox4.Text = "TDC" Then
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Dim sews_part, customer, plant, shortqty, aembarcar, comment, sql As String
                    For I = 0 To GridView2.RowCount - 1
                        sews_part = GridView2.GetRowCellValue(I, "sews_part_no").ToString
                        customer = GridView2.GetRowCellValue(I, "customer_id")
                        plant = GridView2.GetRowCellValue(I, "Plant").ToString
                        shortqty = GridView2.GetRowCellValue(I, "Short_Qty").ToString
                        aembarcar = GridView2.GetRowCellValue(I, "A_Embarcar").ToString
                        comment = GridView2.GetRowCellValue(I, "Comment").ToString
                        sql = "update ERP_CTRL_MUST_GO_TDC set Complete = '1', A_Embarcar = '" & aembarcar & "', Comment = '" & comment & "'  where convert(date,date) = convert(date,GETDATE ()) and sews_part_no = '" & sews_part & "' and customer_id = '" & customer & "' and Short_Qty = '" & shortqty & "' and  plant = '" & plant & "' "
                        Executa_Query(sql, var_conexionERP)
                    Next
                    GridApprove2()
                    sql = "select * from erp_Ctrl_must_go_validation where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                    Dim dy As New DataSet
                    dy = Consulta_Datos(sql, var_conexionERP)
                    If dy.Tables(0).Rows.Count > 0 Then
                        sql = "update erp_Ctrl_must_go_validation set Activo = '1' where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                        Executa_Query(sql, var_conexionERP)
                    Else
                        DevExpress.XtraEditors.XtraMessageBox.Show("No existen datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    GridApprove6()
                    DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Dim sews_part, customer, plant, shortqty, aembarcar, comment, sql As String
                    For I = 0 To GridView2.RowCount - 1
                        sews_part = GridView2.GetRowCellValue(I, "sews_part_no").ToString
                        customer = GridView2.GetRowCellValue(I, "customer_id")
                        plant = GridView2.GetRowCellValue(I, "Plant").ToString
                        shortqty = GridView2.GetRowCellValue(I, "Short_Qty").ToString
                        aembarcar = GridView2.GetRowCellValue(I, "A_Embarcar").ToString
                        comment = GridView2.GetRowCellValue(I, "Comment").ToString
                        sql = "update ERP_CTRL_MUST_GO_PLANTAS set Complete = '1', A_Embarcar = '" & aembarcar & "', Comment = '" & comment & "'  where convert(date,date) = convert(date,GETDATE ()) and sews_part_no = '" & sews_part & "' and customer_id = '" & customer & "' and Short_Qty = '" & shortqty & "' and  Plant = '" & plant & "' "
                        Executa_Query(sql, var_conexionERP)
                    Next
                    GridApprove2_PLANTAS()
                    sql = "select * from erp_Ctrl_must_go_validation where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                    Dim dy As New DataSet
                    dy = Consulta_Datos(sql, var_conexionERP)
                    If dy.Tables(0).Rows.Count > 0 Then
                        sql = "update erp_Ctrl_must_go_validation set Activo = '1' where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                        Executa_Query(sql, var_conexionERP)
                    Else
                        DevExpress.XtraEditors.XtraMessageBox.Show("No existen datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    GridApprove6()
                    DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SimpleButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton10.Click
        Dim dialog As New OpenFileDialog
        Dim path As String
        Dim ConnExcel As New OleDb.OleDbConnection
        Dim Cmd As New OleDb.OleDbCommand
        Dim Da As New OleDb.OleDbDataAdapter
        Dim Ds As New DataSet
        Dim Dset As New DataSet
        Dim conn As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ObjExcel As Excel.ApplicationClass
        Dim ObjW As Excel.WorkbookClass
        Dim nomHoja As String
        Dim FechaActual As Date
        Try
            dialog.InitialDirectory = "C:\"
            dialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*"
            If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path = dialog.FileName
                ObjExcel = New Excel.ApplicationClass
                ObjW = ObjExcel.Workbooks.Open(path)
                nomHoja = ObjW.Sheets(1).Name
                ObjW.Close()
                ObjExcel.Quit()
                ConnExcel.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & "; Extended Properties= Excel 8.0;"
                Cmd.CommandText = "SELECT *  FROM [" & nomHoja & "$]"
                Cmd.Connection = ConnExcel
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Ds.Tables(0).TableName = "Excel"
                GridControl5.DataSource = Ds.Tables(0)
                conn.ConnectionString = var_conexionERP
                comm.CommandType = CommandType.Text
                comm.Connection = conn
                conn.Open()
                FechaActual = Now
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    sql = "DELETE FROM  ERP_CTRL_MUST_GO_UP"
                    Executa_Query(sql, var_conexionERP)
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_MUST_GO_UP VALUES('" & FechaActual & "', '" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "')"
                        comm.ExecuteNonQuery()
                    Next i
                    sql = "select distinct convert(date,DATE) from ERP_CTRL_MUST_GO_UP"
                    Dim dr As New DataSet
                    dr = Consulta_Datos(sql, var_conexionERP)
                    If dr.Tables(0).Rows.Count > 0 Then
                        FechaActual = dr.Tables(0).Rows(0)(0).ToString.Trim
                        sql = "insert into ERP_CTRL_MUST_GO_TDC " & _
                        " SELECT date, type, sews_part_no , cust_part_no , customer_id ,plant, short_date , short_qty ,'0','','' ,'0', comment  FROM ERP_CTRL_MUST_GO_UP " & _
                        " WHERE TYPE = 'TDC' and sews_part_no not in (select sews_part_no from  ERP_CTRL_MUST_GO_TDC where convert(date,date) = '" & FechaActual & "') "
                        Executa_Query(sql, var_conexionERP)
                        sql = " insert into ERP_CTRL_MUST_GO_PLANTAS" & _
                       " SELECT date, type, sews_part_no , cust_part_no , customer_id ,plant, short_date , short_qty ,'0','','' ,'0', comment  FROM ERP_CTRL_MUST_GO_UP " & _
                       " WHERE TYPE =  'Plantas' and sews_part_no not in (select sews_part_no from  ERP_CTRL_MUST_GO_PLANTAS where convert(date,date) = '" & FechaActual & "') "
                        Executa_Query(sql, var_conexionERP)
                        sql = "DELETE FROM  ERP_CTRL_MUST_GO_UP"
                        Executa_Query(sql, var_conexionERP)
                        sql = "select * from ERP_CTRL_MUST_GO_TDC where convert(date,date)  = '" & FechaActual & "'"
                        Dim df As New DataSet
                        df = Consulta_Datos(sql, var_conexionERP)
                        For i = 0 To df.Tables(0).Rows.Count - 1
                            Dim shortdate2, doh, type, sews_part, customer_id, cust_part, rank, val As String
                            shortdate2 = df.Tables(0).Rows(i)("Short_date").ToString
                            type = df.Tables(0).Rows(i)("type").ToString
                            sews_part = df.Tables(0).Rows(i)("sews_part_no").ToString
                            customer_id = df.Tables(0).Rows(i)("customer_id").ToString
                            cust_part = df.Tables(0).Rows(i)("cust_part_no").ToString
                            Dim dw As New DataSet
                            sql = "  SELECT  (DATEDIFF(dd, GETDATE(), CONVERT(DATE,'" & shortdate2 & "')) ) -(DATEDIFF(wk, GETDATE(), CONVERT(DATE,'" & shortdate2 & "')) * 2 ) -(CASE WHEN DATENAME(dw, GETDATE()) = 'Sunday' THEN 1 ELSE 0 END)" & _
                            "-(CASE WHEN DATENAME(dw, CONVERT(DATE,'" & shortdate2 & "')) = 'Saturday' THEN 1 ELSE 0 END) "
                            dw = Consulta_Datos(sql, var_conexionERP)
                            doh = dw.Tables(0).Rows(0)(0).ToString
                            Dim dc As New DataSet
                            sql = " select  c.lead_time  from erp_ctrl_xref a left join ERP_CTRL_CUST_DELIVER b  on a.Customer_id = b.Customer_id   left join erp_ctrl_warehouses2  c " & _
                            " on rtrim(ltrim(b.ship_to_whse)) = rtrim(ltrim(c.Sews_warehouse_id))  where sews_part_no = '" & sews_part & "' and a.Customer_id = '" & customer_id & "' and a.active = '1' and b.Active = '1' "
                            dc = Consulta_Datos(sql, var_conexionERP)
                            If dc.Tables(0).Rows.Count > 0 Then
                                val = dc.Tables(0).Rows(0)(0)
                            Else
                            End If
                            rank = doh - val
                            sql = "update ERP_CTRL_MUST_GO_TDC set DOH = '" & doh & "' , Rank = '" & rank & "' where sews_part_no = '" & sews_part & "' and customer_id = '" & customer_id & "' and cust_part_no  = '" & cust_part & "' and type = '" & type & "' and convert(date,date) = '" & FechaActual & "' "
                            Executa_Query(sql, var_conexionERP)
                        Next i
                        sql = "select * from ERP_CTRL_MUST_GO_PLANTAS where convert(date,date)  = '" & FechaActual & "'"
                        Dim dj As New DataSet
                        dj = Consulta_Datos(sql, var_conexionERP)
                        For i = 0 To dj.Tables(0).Rows.Count - 1
                            Dim shortdate2, doh, type, sews_part, customer_id, cust_part, rank, val As String
                            shortdate2 = dj.Tables(0).Rows(i)("Short_date").ToString
                            type = dj.Tables(0).Rows(i)("type").ToString
                            sews_part = dj.Tables(0).Rows(i)("sews_part_no").ToString
                            customer_id = dj.Tables(0).Rows(i)("customer_id").ToString
                            cust_part = dj.Tables(0).Rows(i)("cust_part_no").ToString
                            Dim dw As New DataSet
                            sql = "  SELECT  (DATEDIFF(dd, GETDATE(), CONVERT(DATE,'" & shortdate2 & "')) ) -(DATEDIFF(wk, GETDATE(), CONVERT(DATE,'" & shortdate2 & "')) * 2 ) -(CASE WHEN DATENAME(dw, GETDATE()) = 'Sunday' THEN 1 ELSE 0 END)" & _
                            "-(CASE WHEN DATENAME(dw, CONVERT(DATE,'" & shortdate2 & "')) = 'Saturday' THEN 1 ELSE 0 END) "
                            dw = Consulta_Datos(sql, var_conexionERP)
                            doh = dw.Tables(0).Rows(0)(0).ToString
                            Dim dc As New DataSet
                            sql = " select  c.lead_time  from erp_ctrl_xref a left join ERP_CTRL_CUST_DELIVER b  on a.Customer_id = b.Customer_id   left join erp_ctrl_warehouses2  c " & _
                            " on rtrim(ltrim(b.ship_to_whse)) = rtrim(ltrim(c.Sews_warehouse_id))  where sews_part_no = '" & sews_part & "' and a.Customer_id = '" & customer_id & "' and a.active = '1' and b.Active = '1' "
                            dc = Consulta_Datos(sql, var_conexionERP)
                            If dc.Tables(0).Rows.Count > 0 Then
                                val = dc.Tables(0).Rows(0)(0)
                            Else
                            End If
                            rank = doh - val - 1
                            sql = "update ERP_CTRL_MUST_GO_PLANTAS set DOH = '" & doh & "' , Rank = '" & rank & "' where sews_part_no = '" & sews_part & "' and customer_id = '" & customer_id & "' and cust_part_no  = '" & cust_part & "' and type = '" & type & "' and convert(date,date) = '" & FechaActual & "' "
                            Executa_Query(sql, var_conexionERP)
                        Next i
                        sql = "select * from erp_Ctrl_must_go_validation where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                        Dim dg As New DataSet
                        dg = Consulta_Datos(sql, var_conexionERP)
                        If dg.Tables(0).Rows.Count > 0 Then
                        Else
                            sql = "insert into ERP_CTRL_MUST_GO_validation values (convert(date,getdate()),'0','" & planner & "')"
                            Executa_Query(sql, var_conexionERP)
                        End If
                        GridApprove6()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        GridView5.Columns.Clear()
                    End If
                Else
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView2_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        Try
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SimpleButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton12.Click
        sql = "select * from erp_Ctrl_must_go_validation where info_date = convert(date,getdate()) and planner = '" & planner & "'"
        Dim dg As New DataSet
        dg = Consulta_Datos(sql, var_conexionERP)
        If dg.Tables(0).Rows.Count > 0 Then
        Else
            sql = "insert into ERP_CTRL_MUST_GO_validation values (convert(date,getdate()),'3','" & planner & "')"
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion Guardada Sin Criticos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        GridApprove6()
        SimpleButton2.Visible = False
        SimpleButton10.Visible = False
        SimpleButton12.Visible = False
        SimpleButton11.Visible = False
        SimpleButton3.Visible = False
        SimpleButton4.Visible = False
    End Sub

    Private Sub SimpleButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton11.Click
        Try
            If ComboBox4.Text = "TDC" Then
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Dim sews_part, customer, plant, shortqty, aembarcar, Comment, sql As String
                    For I = 0 To GridView2.RowCount - 1
                        sews_part = GridView2.GetRowCellValue(I, "sews_part_no").ToString
                        customer = GridView2.GetRowCellValue(I, "customer_id")
                        plant = GridView2.GetRowCellValue(I, "Plant").ToString
                        shortqty = GridView2.GetRowCellValue(I, "Short_Qty").ToString
                        aembarcar = GridView2.GetRowCellValue(I, "A_Embarcar").ToString
                        Comment = GridView2.GetRowCellValue(I, "Comment").ToString
                        sql = "update ERP_CTRL_MUST_GO_TDC set Complete = '2' , A_Embarcar = '" & aembarcar & "', Comment = '" & Comment & "'  where convert(date,date) = convert(date,GETDATE ()) and sews_part_no = '" & sews_part & "' and customer_id = '" & customer & "' and Short_Qty = '" & shortqty & "' and  plant = '" & plant & "' "
                        Executa_Query(sql, var_conexionERP)
                    Next
                    GridApprove2()
                    sql = "select * from erp_Ctrl_must_go_validation where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                    Dim dy As New DataSet
                    dy = Consulta_Datos(sql, var_conexionERP)
                    If dy.Tables(0).Rows.Count > 0 Then
                        sql = "update erp_Ctrl_must_go_validation set Activo = '2' where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                        Executa_Query(sql, var_conexionERP)
                    Else
                    End If
                    GridApprove6()
                    DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SimpleButton2.Visible = False
                    SimpleButton10.Visible = False
                    SimpleButton12.Visible = False
                    SimpleButton11.Visible = False
                    SimpleButton3.Visible = False
                    SimpleButton4.Visible = False
                End If
            Else
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Actualizar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Dim sews_part, customer, plant, shortqty, aembarcar, Comment, sql As String
                    For I = 0 To GridView2.RowCount - 1
                        sews_part = GridView2.GetRowCellValue(I, "sews_part_no").ToString
                        customer = GridView2.GetRowCellValue(I, "customer_id")
                        plant = GridView2.GetRowCellValue(I, "Plant").ToString
                        shortqty = GridView2.GetRowCellValue(I, "Short_Qty").ToString
                        aembarcar = GridView2.GetRowCellValue(I, "A_Embarcar").ToString
                        Comment = GridView2.GetRowCellValue(I, "Comment").ToString
                        sql = "update ERP_CTRL_MUST_GO_PLANTAS set Complete = '2' , A_Embarcar = '" & aembarcar & "', Comment = '" & Comment & "'  where convert(date,date) = convert(date,GETDATE ()) and sews_part_no = '" & sews_part & "' and customer_id = '" & customer & "' and Short_Qty = '" & shortqty & "' and  plant = '" & plant & "' "
                        Executa_Query(sql, var_conexionERP)
                    Next
                    GridApprove2_PLANTAS()
                    sql = "select * from erp_Ctrl_must_go_validation where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                    Dim dy As New DataSet
                    dy = Consulta_Datos(sql, var_conexionERP)
                    If dy.Tables(0).Rows.Count > 0 Then
                        sql = "update erp_Ctrl_must_go_validation set Activo = '2' where info_date = convert(date,getdate()) and planner = '" & planner & "'"
                        Executa_Query(sql, var_conexionERP)
                    Else
                    End If
                    GridApprove6()
                    DevExpress.XtraEditors.XtraMessageBox.Show("Datos Actualizados Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SimpleButton2.Visible = False
                    SimpleButton10.Visible = False
                    SimpleButton12.Visible = False
                    SimpleButton11.Visible = False
                    SimpleButton3.Visible = False
                    SimpleButton4.Visible = False
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SimpleButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton9.Click
        Try
            If ComboBox3.Text = "TDC" Then
                GridView4.Columns.Clear()
                sql = "select a.Plant , a.sews_part_no , a.cust_part_no ,a.customer_id, convert(date,a.Short_date) as Short_Date ," & _
                " STUFF((select  ',' + c.ASN_number1 from ERP_CTRL_MUST_GO_ASN2 c where a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer" & _
                " group by c.ASN_number1 for XML Path('')),1,1,'') as ASN_number1, " & _
                " STUFF(( select  ',' + c.Truck1  from ERP_CTRL_MUST_GO_ASN2 c where    a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer " & _
                " group by c.Truck1 for XML Path('')),1,1,'') as Trucks, " & _
                " STUFF(( select  ',' + convert(varchar,convert (date,c.Ship_date1)) from ERP_CTRL_MUST_GO_ASN2 c where   a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer " & _
                " group by c.Ship_date1 for XML Path('')),1,1,'') as Plant_ship_date, " & _
                " STUFF(( select  ',' + convert(varchar,c.Total) from ERP_CTRL_MUST_GO_ASN2 c where a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer " & _
                " group by c.Total for XML Path('')),1,1,'') as Inv_TDC_total " & _
                " ,sum(c.Total) as Total_TDC, case a.A_Embarcar when 0 then sum(c.Total) else a.A_Embarcar end as 'A_Embarcar' , a.DOH , f.rank  as Rank , d.Ship_to_whse as Destino ,  e.planner_descr as Planner , a.Comment , (sum(c.Total)-A.Short_Qty) as Resta   " & _
                " from ERP_CTRL_MUST_GO_TDC a left join ERP_CTRL_XREF b on a.sews_part_no = b.sews_part_no and a.customer_id = b.Customer_id  and a.cust_part_no = b.cust_part_no  " & _
                " left join ERP_CTRL_MUST_GO_ASN2 c on a.sews_part_no = c.Base_part_number and a.customer_id = c.Customer  left join ERP_CTRL_CUST_DELIVER d on a.customer_id = d.Customer_id  " & _
                " left join ERP_CTRL_PLANNER e on b.Planner = e.planner_id  left join ERP_CTRL_MUST_GO_rank f on a.Rank = f.deadline " & _
                " where b.Active = '1' and convert(date,a.date) = convert(date,getdate()) and a.Complete = '2'  and d.Active = '1'  and a.sews_part_no not in ( '82192-0R130H','82191-0R050H','82192-0R180H','82192-0R140H') " & _
                " group by a.Plant , a.sews_part_no , a.cust_part_no ,a.customer_id, a.DOH , f.rank  , d.Ship_to_whse ,  e.planner_descr , a.Comment , a.Short_date ,a.A_Embarcar , A.Short_Qty " & _
                " UNION ALL  " & _
                " select a.Plant , a.sews_part_no , a.cust_part_no ,a.customer_id, convert(date,a.Short_date) as Short_Date , " & _
                " STUFF((select  ',' + c.ASN_number1 from ERP_CTRL_MUST_GO_ASN2 c where substring(a.sews_part_no,0,12)= c.Base_part_number and a.customer_id = c.Customer  " & _
                " group by c.ASN_number1 for XML Path('')),1,1,'') as ASN_number1,  " & _
                " STUFF(( select  ',' + c.Truck1  from ERP_CTRL_MUST_GO_ASN2 c where    substring(a.sews_part_no,0,12) = c.Base_part_number and a.customer_id = c.Customer  " & _
                " group by c.Truck1 for XML Path('')),1,1,'') as Trucks,  " & _
                " STUFF(( select  ',' + convert(varchar,convert (date,c.Ship_date1)) from ERP_CTRL_MUST_GO_ASN2 c where   substring(a.sews_part_no,0,12) = c.Base_part_number and a.customer_id = c.Customer  " & _
                " group by c.Ship_date1 for XML Path('')),1,1,'') as Plant_ship_date, " & _
                " STUFF(( select  ',' + convert(varchar,c.Total) from ERP_CTRL_MUST_GO_ASN2 c where substring(a.sews_part_no,0,12)= c.Base_part_number and a.customer_id = c.Customer  " & _
                " group by c.Total for XML Path('')),1,1,'') as Inv_TDC_total  " & _
                " ,sum(c.Total) as Total_TDC, case a.A_Embarcar when 0 then sum(c.Total) else a.A_Embarcar end as 'A_Embarcar' , a.DOH , f.rank  as Rank , d.Ship_to_whse as Destino ,  e.planner_descr as Planner , a.Comment , (sum(c.Total)-A.Short_Qty) as Resta    " & _
                " from ERP_CTRL_MUST_GO_TDC a left join ERP_CTRL_XREF b on a.sews_part_no = b.sews_part_no and a.customer_id = b.Customer_id  and a.cust_part_no = b.cust_part_no   " & _
                " left join ERP_CTRL_MUST_GO_ASN2 c on substring(a.sews_part_no,0,12) = c.Base_part_number and a.customer_id = c.Customer  left join ERP_CTRL_CUST_DELIVER d on a.customer_id = d.Customer_id   " & _
                " left join ERP_CTRL_PLANNER e on b.Planner = e.planner_id  left join ERP_CTRL_MUST_GO_rank f on a.Rank = f.deadline " & _
                " where b.Active = '1' and convert(date,a.date) = convert(date,getdate()) and a.Complete = '2'  and d.Active = '1' and a.sews_part_no  in ( '82192-0R130H','82191-0R050H','82192-0R180H','82192-0R140H') " & _
                " group by a.Plant , a.sews_part_no , a.cust_part_no ,a.customer_id, a.DOH , f.rank  , d.Ship_to_whse ,  e.planner_descr , a.Comment , a.Short_date ,a.A_Embarcar , A.Short_Qty "
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                If ds.Tables(0).Rows.Count > 0 Then
                    GridControl4.DataSource = ds.Tables(0)
                    GridView4.Columns("Resta").Visible = False
                    GridView4.ExpandAllGroups()
                    GridView4.BestFitColumns()
                    GridView4.Columns("Plant").OptionsColumn.AllowEdit = False
                    GridView4.Columns("sews_part_no").OptionsColumn.AllowEdit = False
                    GridView4.Columns("customer_id").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Short_Date").OptionsColumn.AllowEdit = False
                    'GridView4.Columns("ASN_number1").OptionsColumn.AllowEdit = False
                    'GridView4.Columns("Trucks").OptionsColumn.AllowEdit = False
                    'GridView4.Columns("Plant_ship_date").OptionsColumn.AllowEdit = False
                    'GridView4.Columns("Inv_TDC_total").OptionsColumn.AllowEdit = False
                    'GridView4.Columns("Total_TDC").OptionsColumn.AllowEdit = False
                    GridView4.Columns("A_Embarcar").OptionsColumn.AllowEdit = False
                    'GridView4.Columns("Short_Qty").OptionsColumn.AllowEdit = False
                    GridView4.Columns("DOH").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Rank").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Destino").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Planner").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Comment").OptionsColumn.AllowEdit = False
                    Cursor = Cursors.Default
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("No existen datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                sql = "select distinct Planner from ERP_CTRL_MUST_GO_VALIDATION  where Info_Date = convert(date, Getdate()) and Activo < '2'"
                Dim du As DataSet
                du = Consulta_Datos(sql, var_conexionERP)
                If du.Tables(0).Rows.Count >= 1 Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("Aun quedan Planner por Confirmar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    SimpleButton8.Visible = False

                Else
                    SimpleButton8.Visible = True
                End If
            Else
                GridView4.Columns.Clear()
                sql = "SP_CTRL_MUSTGO_PLANTAS_ALL"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                If ds.Tables(0).Rows.Count > 0 Then
                    GridControl4.DataSource = ds.Tables(0)
                    GridView4.ExpandAllGroups()
                    GridView4.BestFitColumns()
                    GridView4.Columns("Plant").OptionsColumn.AllowEdit = False
                    GridView4.Columns("sews_part_no").OptionsColumn.AllowEdit = False
                    GridView4.Columns("customer_id").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Short_Date").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Adherencia").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Planeado_desde").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Inv_Piso").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Short_Qty").OptionsColumn.AllowEdit = False
                    GridView4.Columns("DOH").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Rank").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Destino").OptionsColumn.AllowEdit = False
                    GridView4.Columns("Planner").OptionsColumn.AllowEdit = False
                    Cursor = Cursors.Default
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("No existen datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                sql = "select distinct Planner from ERP_CTRL_MUST_GO_VALIDATION  where Info_Date = convert(date, Getdate()) and Activo >= '2'"
                Dim du As DataSet
                du = Consulta_Datos(sql, var_conexionERP)
                If du.Tables(0).Rows.Count = 10 Then
                    SimpleButton8.Visible = True
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Aun quedan Planner por Confirmar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    SimpleButton8.Visible = False
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton8.Click
        Try
            If ComboBox3.Text = "TDC" Then
                sql = "SELECT * FROM ERP_cTRL_MUST_GO_DAILY WHERE convert(date,info_Dt)  = convert(date,Getdate()) and Type = 'TDC'"
                Dim dy As New DataSet
                dy = Consulta_Datos(sql, var_conexionERP)
                If dy.Tables(0).Rows.Count > 0 Then
                    Dim sql As String
                    sql = "delete from erp_Ctrl_must_go_daily where  convert(date,info_Dt) = convert(date,Getdate()) and Type = 'TDC'"
                    Executa_Query(sql, var_conexionERP)
                    Dim sews_part, cust_part, customer, plant, short_date, Asn_number, Trucks, Plant_ship_date, Inv_TDC, Total_tdc, Doh, rank, destino, Planner, aembarcar, Comment As String
                    For I = 0 To GridView4.RowCount - 1
                        plant = GridView4.GetRowCellValue(I, "Plant").ToString
                        sews_part = GridView4.GetRowCellValue(I, "sews_part_no").ToString
                        cust_part = GridView4.GetRowCellValue(I, "cust_part_no").ToString
                        customer = GridView4.GetRowCellValue(I, "customer_id").ToString
                        short_date = GridView4.GetRowCellValue(I, "Short_Date")
                        Asn_number = GridView4.GetRowCellValue(I, "ASN_number1").ToString
                        Trucks = GridView4.GetRowCellValue(I, "Trucks").ToString
                        Plant_ship_date = GridView4.GetRowCellValue(I, "Plant_ship_date").ToString
                        Inv_TDC = GridView4.GetRowCellValue(I, "Inv_TDC_total").ToString
                        Total_tdc = GridView4.GetRowCellValue(I, "Total_TDC").ToString
                        aembarcar = GridView4.GetRowCellValue(I, "A_Embarcar").ToString
                        Doh = GridView4.GetRowCellValue(I, "DOH").ToString
                        rank = GridView4.GetRowCellValue(I, "Rank").ToString
                        destino = GridView4.GetRowCellValue(I, "Destino").ToString
                        Planner = GridView4.GetRowCellValue(I, "Planner").ToString
                        Comment = GridView4.GetRowCellValue(I, "Comment").ToString
                        sql = "insert into ERP_CTRL_MUST_GO_DAILY  VALUES  ('" & plant & "','" & sews_part & "','" & customer & "','" & short_date & "', '" & Asn_number & "','" & Trucks & "', '" & Plant_ship_date & "' " & _
                            ",'" & Inv_TDC & "','" & Total_tdc & "','" & aembarcar & "','" & Doh & "','" & rank & "','" & destino & "', '" & Planner & "' , '" & Comment & "' , Getdate(), 'TDC','" & cust_part & "' )"
                        Executa_Query(sql, var_conexionERP)
                    Next
                    If GridView4.RowCount > 0 Then
                        GridView4.ExportToXls(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_TDC.xls")
                        System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_TDC.xls")
                    End If
                Else
                    Dim sews_part, cust_part, customer, plant, short_date, Asn_number, Trucks, Plant_ship_date, Inv_TDC, Total_tdc, Doh, rank, destino, Planner, aembarcar, Comment As String
                    For I = 0 To GridView4.RowCount - 1
                        plant = GridView4.GetRowCellValue(I, "Plant").ToString
                        sews_part = GridView4.GetRowCellValue(I, "sews_part_no").ToString
                        cust_part = GridView4.GetRowCellValue(I, "cust_part_no").ToString
                        customer = GridView4.GetRowCellValue(I, "customer_id").ToString
                        short_date = GridView4.GetRowCellValue(I, "Short_Date")
                        Asn_number = GridView4.GetRowCellValue(I, "ASN_number1").ToString
                        Trucks = GridView4.GetRowCellValue(I, "Trucks").ToString
                        Plant_ship_date = GridView4.GetRowCellValue(I, "Plant_ship_date").ToString
                        Inv_TDC = GridView4.GetRowCellValue(I, "Inv_TDC_total").ToString
                        Total_tdc = GridView4.GetRowCellValue(I, "Total_TDC").ToString
                        aembarcar = GridView4.GetRowCellValue(I, "A_Embarcar").ToString
                        Doh = GridView4.GetRowCellValue(I, "DOH").ToString
                        rank = GridView4.GetRowCellValue(I, "Rank").ToString
                        destino = GridView4.GetRowCellValue(I, "Destino").ToString
                        Planner = GridView4.GetRowCellValue(I, "Planner").ToString
                        Comment = GridView4.GetRowCellValue(I, "Comment").ToString
                        sql = "insert into ERP_CTRL_MUST_GO_DAILY  VALUES  ('" & plant & "','" & sews_part & "','" & customer & "','" & short_date & "', '" & Asn_number & "','" & Trucks & "', '" & Plant_ship_date & "' " & _
                            ",'" & Inv_TDC & "','" & Total_tdc & "','" & aembarcar & "','" & Doh & "','" & rank & "','" & destino & "', '" & Planner & "' , '" & Comment & "' ,Getdate(), 'TDC','" & cust_part & "')"
                        Executa_Query(sql, var_conexionERP)
                    Next
                    If GridView4.RowCount > 0 Then
                        GridView4.ExportToXls(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_TDC.xls")
                        System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_TDC.xls")
                    End If
                End If
            Else
                sql = "SELECT * FROM ERP_cTRL_MUST_GO_DAILY_plantas WHERE convert(date,info_Dt)  = convert(date,Getdate()) and Type = 'Plantas'"
                Dim dy As New DataSet
                dy = Consulta_Datos(sql, var_conexionERP)
                If dy.Tables(0).Rows.Count > 0 Then
                    Dim sql As String
                    sql = "delete from erp_Ctrl_must_go_daily_plantas where  convert(date,info_Dt) = convert(date,Getdate()) and Type = 'Plantas'"
                    Executa_Query(sql, var_conexionERP)
                    Dim sews_part, cust_part, customer, plant, short_date, Adherencia, planeado, Inv_piso, aembarcar, short_qty, Doh, rank, destino, Planner, Comment As String
                    For I = 0 To GridView4.RowCount - 1
                        plant = GridView4.GetRowCellValue(I, "Plant").ToString
                        sews_part = GridView4.GetRowCellValue(I, "sews_part_no").ToString
                        cust_part = GridView4.GetRowCellValue(I, "cust_part_no").ToString
                        customer = GridView4.GetRowCellValue(I, "customer_id").ToString
                        short_date = GridView4.GetRowCellValue(I, "Short_Date")
                        Adherencia = GridView4.GetRowCellValue(I, "Adherencia").ToString
                        planeado = GridView4.GetRowCellValue(I, "Planeado_desde").ToString
                        Inv_piso = GridView4.GetRowCellValue(I, "Inv_Piso").ToString
                        aembarcar = GridView4.GetRowCellValue(I, "A_Embarcar").ToString
                        short_qty = GridView4.GetRowCellValue(I, "Short_Qty").ToString
                        Doh = GridView4.GetRowCellValue(I, "DOH").ToString
                        rank = GridView4.GetRowCellValue(I, "Rank").ToString
                        destino = GridView4.GetRowCellValue(I, "Destino").ToString
                        Planner = GridView4.GetRowCellValue(I, "Planner").ToString
                        Comment = GridView4.GetRowCellValue(I, "Comment").ToString
                        sql = "insert into ERP_CTRL_MUST_GO_DAILY_plantas  VALUES  ('" & plant & "','" & sews_part & "','" & customer & "','" & short_date & "', '" & Adherencia & "','" & planeado & "', '" & Inv_piso & "' " & _
                            ",'" & aembarcar & "', '" & short_qty & "','" & Doh & "','" & rank & "','" & destino & "', '" & Planner & "' , '" & Comment & "' , Getdate(), 'Plantas','" & cust_part & "' )"
                        Executa_Query(sql, var_conexionERP)
                    Next
                    If GridView4.RowCount > 0 Then
                        GridView4.ExportToXls(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_Plantas.xls")
                        System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_Plantas.xls")
                    End If
                Else
                    Dim sews_part, cust_part, customer, plant, short_date, Adherencia, planeado, Inv_piso, aembarcar, short_qty, Doh, rank, destino, Planner, Comment As String
                    For I = 0 To GridView4.RowCount - 1
                        plant = GridView4.GetRowCellValue(I, "Plant").ToString
                        sews_part = GridView4.GetRowCellValue(I, "sews_part_no").ToString
                        cust_part = GridView4.GetRowCellValue(I, "cust_part_no").ToString
                        customer = GridView4.GetRowCellValue(I, "customer_id").ToString
                        short_date = GridView4.GetRowCellValue(I, "Short_Date")
                        Adherencia = GridView4.GetRowCellValue(I, "Adherencia").ToString
                        planeado = GridView4.GetRowCellValue(I, "Planeado_desde").ToString
                        Inv_piso = GridView4.GetRowCellValue(I, "Inv_Piso").ToString
                        aembarcar = GridView4.GetRowCellValue(I, "A_Embarcar").ToString
                        short_qty = GridView4.GetRowCellValue(I, "Short_Qty").ToString
                        Doh = GridView4.GetRowCellValue(I, "DOH").ToString
                        rank = GridView4.GetRowCellValue(I, "Rank").ToString
                        destino = GridView4.GetRowCellValue(I, "Destino").ToString
                        Planner = GridView4.GetRowCellValue(I, "Planner").ToString
                        Comment = GridView4.GetRowCellValue(I, "Comment").ToString
                        sql = "insert into ERP_CTRL_MUST_GO_DAILY_plantas  VALUES  ('" & plant & "','" & sews_part & "','" & customer & "','" & short_date & "', '" & Adherencia & "','" & planeado & "', '" & Inv_piso & "' " & _
                              ",'" & aembarcar & "', '" & short_qty & "','" & Doh & "','" & rank & "','" & destino & "', '" & Planner & "' , '" & Comment & "' , Getdate(), 'Plantas','" & cust_part & "' )"
                        Executa_Query(sql, var_conexionERP)
                    Next
                    If GridView4.RowCount > 0 Then
                        GridView4.ExportToXls(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_Plantas.xls")
                        System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_Plantas.xls")
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim horaactal As DateTime
        Dim horaMin As String
        horaactal = Now
        horaMin = horaactal.TimeOfDay.ToString
        horaMin = horaMin.Substring(0, 5)
        hora_actual.Text = horaMin
        sql = "select * from ERP_CTRL_MUST_GO_DEADLINE WHERE  '" & hora_actual.Text & "' >= substring(convert(varchar,Hour),0,6)"
        Dim du As DataSet
        du = Consulta_Datos(sql, var_conexionERP)
        If du.Tables(0).Rows.Count > 0 Then
            Timer1.Stop()
            DevExpress.XtraEditors.XtraMessageBox.Show("Hora Limite", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '' despues de la hora limite , consultar quien no cargo y poner en el status , no ingreso
            SimpleButton11.Visible = False
            SimpleButton2.Visible = False
            SimpleButton4.Visible = False
            SimpleButton12.Visible = False
            SimpleButton10.Visible = False
            sql = "select * from ERP_CTRL_MUST_GO_VALIDATION  where convert(date,Info_date) = convert(date,getdate ()) "
            Dim dw As DataSet
            dw = Consulta_Datos(sql, var_conexionERP)
            If du.Tables(0).Rows.Count = 10 Then
                Exit Sub
            Else
                sql = "select planner from ERP_CTRL_MUST_GO_VALIDATION  where convert(date,Info_date) = convert(date,'2021-05-05') and planner not in (select planner from ERP_CTRL_MUST_GO_VALIDATION where convert(date,Info_date) = convert(date,getdate()))"
                Dim ds As New DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        sql = "insert into ERP_CTRL_MUST_GO_VALIDATION  VALUES  ( getdate(),'4','" & ds.Tables(0).Rows(i)(0).ToString & "')"
                        Executa_Query(sql, var_conexionERP)
                    Next i
                    GridApprove6()
                Else
                End If
            End If
        Else
        End If
    End Sub

    Private Sub erp_ctrl_must_go_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Enabled = False
    End Sub

    Private Sub SimpleButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton13.Click
        Try
            If ComboBox5.Text = "TDC" Then
                GridView7.Columns.Clear()
                sql = "select * from ERP_CTRL_MUST_GO_DAILY where convert(date,Info_dt) = '" & DateEdit2.Text.Trim & "'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                If ds.Tables(0).Rows.Count > 0 Then
                    GridControl7.DataSource = ds.Tables(0)
                    GridView7.ExpandAllGroups()
                    GridView7.BestFitColumns()
                    Cursor = Cursors.Default
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("No existen datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                GridView7.Columns.Clear()
                sql = "select * from ERP_CTRL_MUST_GO_DAILY_plantas where convert(date,Info_dt) = '" & DateEdit2.Text.Trim & "'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                If ds.Tables(0).Rows.Count > 0 Then
                    GridControl7.DataSource = ds.Tables(0)
                    GridView7.ExpandAllGroups()
                    GridView7.BestFitColumns()
                    Cursor = Cursors.Default
                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("No existen datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton14.Click
        Try
            If ComboBox5.Text = "TDC" Then
                If GridView7.RowCount > 0 Then
                    GridView7.ExportToXls(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_Bitacora_TDC.xls")
                    System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_Bitacora_TDC.xls")
                End If
            Else
                If GridView7.RowCount > 0 Then
                    GridView7.ExportToXls(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_Bitacora_Plantas.xls")
                    System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Rpt_Must_GO_Bitacora_Plantas.xls")
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

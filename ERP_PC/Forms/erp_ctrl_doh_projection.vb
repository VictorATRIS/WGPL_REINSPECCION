Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Configuration
Imports Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.IO
Imports System.Drawing.Point
Imports Microsoft.Office.Interop
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports AccesoDatos
Imports Funciones
Public Class erp_ctrl_doh_projection
    Dim Sql, NumLinea, NumFlujo As String
    Private Sub erp_ctrl_doh_projection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaNombreLineas1()
        'Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CargaNombreLineas1()
        Dim ds As New DataSet
        Try
            Sql = "select  Nombre_comun,Nombre_Formal from ERP_CTRL_LINES"
            ds = Consulta_Datos(Sql, var_conexionERP)
            Carga_ComboDevXpress(up_nombre_comun, Sql, var_conexionERP)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub NumerodeLinea()
        Try
            Sql = " select Top 1  Line_c  from ERP_CTRL_LINES where Nombre_comun = '" & up_nombre_comun.Text & "'"
            Dim ds As DataSet
            ds = Consulta_Datos(Sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                NumLinea = ds.Tables(0).Rows(0)(0).ToString.Trim
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NumeroFlujos()
        Try
            Sql = "select count(*) Code_flujo  from ERP_CTRL_LINES_FORMATIONS_GROUPED where Line_CND = '" & NumLinea & "'"
            Dim ds As DataSet
            ds = Consulta_Datos(Sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                NumFlujo = ds.Tables(0).Rows(0)(0).ToString.Trim
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SimpleButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton9.Click
        DesactivarTextBox()
        If up_nombre_comun.Text <> "" Then
            NumerodeLinea()
            NumeroFlujos()
            Sql = "select * from ERP_CTRL_LINES_FORMATIONS_GROUPED where Line_CND = '" & NumLinea & "' order by Code_Flujo"
            Dim ds As DataSet
            ds = Consulta_Datos(Sql, var_conexionERP)
            te_fa.Text = ""
            te_fb.Text = ""
            te_fc.Text = ""
            te_fd.Text = ""
            te_fe.Text = ""
            te_ff.Text = ""
            te_fg.Text = ""
            te_fh.Text = ""
            te_da.Text = ""
            te_db.Text = ""
            te_dc.Text = ""
            te_dd.Text = ""
            te_de.Text = ""
            te_df.Text = ""
            te_dg.Text = ""
            te_dh.Text = ""
            Try
                Select Case NumFlujo
                    Case 1
                        te_la.Visible = True
                        te_ta.Visible = True
                        te_fa.Visible = True
                        te_da.Visible = True
                        te_la.Text = ds.Tables(0).Rows(0)("Flujo").ToString
                        te_ta.Text = ds.Tables(0).Rows(0)("Turno").ToString
                        te_lb.Text = "0"
                        te_lc.Text = "0"
                        te_ld.Text = "0"
                        te_le.Text = "0"
                        te_lf.Text = "0"
                        te_lg.Text = "0"
                        te_lh.Text = "0"
                        te_tb.Text = "0"
                        te_tc.Text = "0"
                        te_td.Text = "0"
                        te_te.Text = "0"
                        te_tf.Text = "0"
                        te_tg.Text = "0"
                        te_th.Text = "0"
                    Case 2
                        te_la.Visible = True
                        te_ta.Visible = True
                        te_fa.Visible = True
                        te_da.Visible = True
                        te_lb.Visible = True
                        te_tb.Visible = True
                        te_fb.Visible = True
                        te_db.Visible = True
                        te_la.Text = ds.Tables(0).Rows(0)("Flujo").ToString
                        te_ta.Text = ds.Tables(0).Rows(0)("Turno").ToString
                        te_lb.Text = ds.Tables(0).Rows(1)("Flujo").ToString
                        te_tb.Text = ds.Tables(0).Rows(1)("Turno").ToString
                        te_lc.Text = "0"
                        te_ld.Text = "0"
                        te_le.Text = "0"
                        te_lf.Text = "0"
                        te_lg.Text = "0"
                        te_lh.Text = "0"
                        te_tc.Text = "0"
                        te_td.Text = "0"
                        te_te.Text = "0"
                        te_tf.Text = "0"
                        te_tg.Text = "0"
                        te_th.Text = "0"
                    Case 3
                        te_la.Visible = True
                        te_ta.Visible = True
                        te_fa.Visible = True
                        te_da.Visible = True
                        te_lb.Visible = True
                        te_tb.Visible = True
                        te_fb.Visible = True
                        te_db.Visible = True
                        te_lc.Visible = True
                        te_tc.Visible = True
                        te_fc.Visible = True
                        te_dc.Visible = True
                        te_la.Text = ds.Tables(0).Rows(0)("Flujo").ToString
                        te_ta.Text = ds.Tables(0).Rows(0)("Turno").ToString
                        te_lb.Text = ds.Tables(0).Rows(1)("Flujo").ToString
                        te_tb.Text = ds.Tables(0).Rows(1)("Turno").ToString
                        te_tc.Text = ds.Tables(0).Rows(2)("Flujo").ToString
                        te_tc.Text = ds.Tables(0).Rows(2)("Turno").ToString
                        te_ld.Text = "0"
                        te_le.Text = "0"
                        te_lf.Text = "0"
                        te_lg.Text = "0"
                        te_lh.Text = "0"
                        te_td.Text = "0"
                        te_te.Text = "0"
                        te_tf.Text = "0"
                        te_tg.Text = "0"
                        te_th.Text = "0"
                    Case 4
                        te_la.Visible = True
                        te_ta.Visible = True
                        te_fa.Visible = True
                        te_da.Visible = True
                        te_lb.Visible = True
                        te_tb.Visible = True
                        te_fb.Visible = True
                        te_db.Visible = True
                        te_lc.Visible = True
                        te_tc.Visible = True
                        te_fc.Visible = True
                        te_dc.Visible = True
                        te_ld.Visible = True
                        te_td.Visible = True
                        te_fd.Visible = True
                        te_dd.Visible = True
                        te_la.Text = ds.Tables(0).Rows(0)("Flujo").ToString
                        te_ta.Text = ds.Tables(0).Rows(0)("Turno").ToString
                        te_lb.Text = ds.Tables(0).Rows(1)("Flujo").ToString
                        te_tb.Text = ds.Tables(0).Rows(1)("Turno").ToString
                        te_lc.Text = ds.Tables(0).Rows(2)("Flujo").ToString
                        te_tc.Text = ds.Tables(0).Rows(2)("Turno").ToString
                        te_ld.Text = ds.Tables(0).Rows(3)("Flujo").ToString
                        te_td.Text = ds.Tables(0).Rows(3)("Turno").ToString
                        te_le.Text = "0"
                        te_lf.Text = "0"
                        te_lg.Text = "0"
                        te_lh.Text = "0"
                        te_te.Text = "0"
                        te_tf.Text = "0"
                        te_tg.Text = "0"
                        te_th.Text = "0"
                    Case 5
                        te_la.Visible = True
                        te_ta.Visible = True
                        te_fa.Visible = True
                        te_da.Visible = True
                        te_lb.Visible = True
                        te_tb.Visible = True
                        te_fb.Visible = True
                        te_db.Visible = True
                        te_lc.Visible = True
                        te_tc.Visible = True
                        te_fc.Visible = True
                        te_dc.Visible = True
                        te_ld.Visible = True
                        te_td.Visible = True
                        te_fd.Visible = True
                        te_dd.Visible = True
                        te_le.Visible = True
                        te_te.Visible = True
                        te_fe.Visible = True
                        te_de.Visible = True
                        te_la.Text = ds.Tables(0).Rows(0)("Flujo").ToString
                        te_ta.Text = ds.Tables(0).Rows(0)("Turno").ToString
                        te_lb.Text = ds.Tables(0).Rows(1)("Flujo").ToString
                        te_tb.Text = ds.Tables(0).Rows(1)("Turno").ToString
                        te_lc.Text = ds.Tables(0).Rows(2)("Flujo").ToString
                        te_tc.Text = ds.Tables(0).Rows(2)("Turno").ToString
                        te_ld.Text = ds.Tables(0).Rows(3)("Flujo").ToString
                        te_td.Text = ds.Tables(0).Rows(3)("Turno").ToString
                        te_le.Text = ds.Tables(0).Rows(4)("Flujo").ToString
                        te_te.Text = ds.Tables(0).Rows(4)("Turno").ToString
                        te_lf.Text = "0"
                        te_lg.Text = "0"
                        te_lh.Text = "0"
                        te_tf.Text = "0"
                        te_tg.Text = "0"
                        te_th.Text = "0"
                    Case 6
                        te_la.Visible = True
                        te_ta.Visible = True
                        te_fa.Visible = True
                        te_da.Visible = True
                        te_lb.Visible = True
                        te_tb.Visible = True
                        te_fb.Visible = True
                        te_db.Visible = True
                        te_lc.Visible = True
                        te_tc.Visible = True
                        te_fc.Visible = True
                        te_dc.Visible = True
                        te_ld.Visible = True
                        te_td.Visible = True
                        te_fd.Visible = True
                        te_dd.Visible = True
                        te_le.Visible = True
                        te_te.Visible = True
                        te_fe.Visible = True
                        te_de.Visible = True
                        te_lf.Visible = True
                        te_tf.Visible = True
                        te_ff.Visible = True
                        te_df.Visible = True
                        te_la.Text = ds.Tables(0).Rows(0)("Flujo").ToString
                        te_ta.Text = ds.Tables(0).Rows(0)("Turno").ToString
                        te_lb.Text = ds.Tables(0).Rows(1)("Flujo").ToString
                        te_tb.Text = ds.Tables(0).Rows(1)("Turno").ToString
                        te_lc.Text = ds.Tables(0).Rows(2)("Flujo").ToString
                        te_tc.Text = ds.Tables(0).Rows(2)("Turno").ToString
                        te_ld.Text = ds.Tables(0).Rows(3)("Flujo").ToString
                        te_td.Text = ds.Tables(0).Rows(3)("Turno").ToString
                        te_le.Text = ds.Tables(0).Rows(4)("Flujo").ToString
                        te_te.Text = ds.Tables(0).Rows(4)("Turno").ToString
                        te_lf.Text = ds.Tables(0).Rows(5)("Flujo").ToString
                        te_tf.Text = ds.Tables(0).Rows(5)("Turno").ToString
                        te_lg.Text = "0"
                        te_lh.Text = "0"
                        te_tg.Text = "0"
                        te_th.Text = "0"
                    Case 7
                        te_la.Visible = True
                        te_ta.Visible = True
                        te_fa.Visible = True
                        te_da.Visible = True
                        te_lb.Visible = True
                        te_tb.Visible = True
                        te_fb.Visible = True
                        te_db.Visible = True
                        te_lc.Visible = True
                        te_tc.Visible = True
                        te_fc.Visible = True
                        te_dc.Visible = True
                        te_ld.Visible = True
                        te_td.Visible = True
                        te_fd.Visible = True
                        te_dd.Visible = True
                        te_le.Visible = True
                        te_te.Visible = True
                        te_fe.Visible = True
                        te_de.Visible = True
                        te_lf.Visible = True
                        te_tf.Visible = True
                        te_ff.Visible = True
                        te_df.Visible = True
                        te_lg.Visible = True
                        te_tg.Visible = True
                        te_fg.Visible = True
                        te_dg.Visible = True
                        te_la.Text = ds.Tables(0).Rows(0)("Flujo").ToString
                        te_ta.Text = ds.Tables(0).Rows(0)("Turno").ToString
                        te_lb.Text = ds.Tables(0).Rows(1)("Flujo").ToString
                        te_tb.Text = ds.Tables(0).Rows(1)("Turno").ToString
                        te_lc.Text = ds.Tables(0).Rows(2)("Flujo").ToString
                        te_tc.Text = ds.Tables(0).Rows(2)("Turno").ToString
                        te_ld.Text = ds.Tables(0).Rows(3)("Flujo").ToString
                        te_td.Text = ds.Tables(0).Rows(3)("Turno").ToString
                        te_le.Text = ds.Tables(0).Rows(4)("Flujo").ToString
                        te_te.Text = ds.Tables(0).Rows(4)("Turno").ToString
                        te_lf.Text = ds.Tables(0).Rows(5)("Flujo").ToString
                        te_tf.Text = ds.Tables(0).Rows(5)("Turno").ToString
                        te_lg.Text = ds.Tables(0).Rows(6)("Flujo").ToString
                        te_tg.Text = ds.Tables(0).Rows(6)("Turno").ToString
                        te_lh.Text = "0"
                        te_th.Text = "0"
                    Case 8
                        te_la.Visible = True
                        te_ta.Visible = True
                        te_fa.Visible = True
                        te_da.Visible = True
                        te_lb.Visible = True
                        te_tb.Visible = True
                        te_fb.Visible = True
                        te_db.Visible = True
                        te_lc.Visible = True
                        te_tc.Visible = True
                        te_fc.Visible = True
                        te_dc.Visible = True
                        te_ld.Visible = True
                        te_td.Visible = True
                        te_fd.Visible = True
                        te_dd.Visible = True
                        te_le.Visible = True
                        te_te.Visible = True
                        te_fe.Visible = True
                        te_de.Visible = True
                        te_lf.Visible = True
                        te_tf.Visible = True
                        te_ff.Visible = True
                        te_df.Visible = True
                        te_lg.Visible = True
                        te_tg.Visible = True
                        te_fg.Visible = True
                        te_dg.Visible = True
                        te_lh.Visible = True
                        te_th.Visible = True
                        te_fh.Visible = True
                        te_dh.Visible = True
                        te_la.Text = ds.Tables(0).Rows(0)("Flujo").ToString
                        te_ta.Text = ds.Tables(0).Rows(0)("Turno").ToString
                        te_lb.Text = ds.Tables(0).Rows(1)("Flujo").ToString
                        te_tb.Text = ds.Tables(0).Rows(1)("Turno").ToString
                        te_lc.Text = ds.Tables(0).Rows(2)("Flujo").ToString
                        te_tc.Text = ds.Tables(0).Rows(2)("Turno").ToString
                        te_ld.Text = ds.Tables(0).Rows(3)("Flujo").ToString
                        te_td.Text = ds.Tables(0).Rows(3)("Turno").ToString
                        te_le.Text = ds.Tables(0).Rows(4)("Flujo").ToString
                        te_te.Text = ds.Tables(0).Rows(4)("Turno").ToString
                        te_lf.Text = ds.Tables(0).Rows(5)("Flujo").ToString
                        te_tf.Text = ds.Tables(0).Rows(5)("Turno").ToString
                        te_lg.Text = ds.Tables(0).Rows(6)("Flujo").ToString
                        te_tg.Text = ds.Tables(0).Rows(6)("Turno").ToString
                        te_lh.Text = ds.Tables(0).Rows(7)("Flujo").ToString
                        te_th.Text = ds.Tables(0).Rows(7)("Turno").ToString
                End Select
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub DesactivarTextBox()
        te_la.Visible = False
        te_lb.Visible = False
        te_lc.Visible = False
        te_ld.Visible = False
        te_le.Visible = False
        te_lf.Visible = False
        te_lg.Visible = False
        te_lh.Visible = False
        te_ta.Visible = False
        te_tb.Visible = False
        te_tc.Visible = False
        te_td.Visible = False
        te_te.Visible = False
        te_tf.Visible = False
        te_tg.Visible = False
        te_th.Visible = False
        te_fa.Visible = False
        te_fb.Visible = False
        te_fc.Visible = False
        te_fd.Visible = False
        te_fe.Visible = False
        te_ff.Visible = False
        te_fg.Visible = False
        te_fh.Visible = False
        te_da.Visible = False
        te_db.Visible = False
        te_dc.Visible = False
        te_dd.Visible = False
        te_de.Visible = False
        te_df.Visible = False
        te_dg.Visible = False
        te_dh.Visible = False

        te_la.Text = ""
        te_lb.Text = ""
        te_lc.Text = ""
        te_ld.Text = ""
        te_le.Text = ""
        te_lf.Text = ""
        te_lg.Text = ""
        te_lh.Text = ""
        te_ta.Text = ""
        te_tb.Text = ""
        te_tc.Text = ""
        te_td.Text = ""
        te_te.Text = ""
        te_tf.Text = ""
        te_tg.Text = ""
        te_th.Text = ""
        te_fa.Text = ""
        te_fb.Text = ""
        te_fc.Text = ""
        te_fd.Text = ""
        te_fe.Text = ""
        te_ff.Text = ""
        te_fg.Text = ""
        te_fh.Text = ""
        te_da.Text = ""
        te_db.Text = ""
        te_dc.Text = ""
        te_dd.Text = ""
        te_de.Text = ""
        te_df.Text = ""
        te_dg.Text = ""
        te_dh.Text = ""
    End Sub
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
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Sql = "DELETE FROM  erp_Ctrl_doh_projection_TMP"
                    Executa_Query(Sql, var_conexionERP)
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_DOH_PROJECTION_TMP VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(11).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(12).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(13).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(14).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(15).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(16).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(17).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(18).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(19).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(20).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(21).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(22).ToString.Trim & "')"
                        comm.ExecuteNonQuery()
                    Next i
                    Sql = "select distinct Line_c from erp_Ctrl_lines where rtrim(ltrim(Nombre_comun)) in ( select distinct rtrim(ltrim(Line)) from ERP_CTRL_DOH_PROJECTION_TMP )"
                    Dim dF As New DataSet
                    dF = Consulta_Datos(Sql, var_conexionERP)
                    If dF.Tables(0).Rows.Count > 0 Then
                        Sql = "select distinct  rtrim(ltrim(Line)) from erp_Ctrl_doh_projection where rtrim(ltrim(Line)) in (select  distinct  rtrim(ltrim(Line)) from erp_Ctrl_doh_projection_tmp)"
                        Dim dr As New DataSet
                        dr = Consulta_Datos(Sql, var_conexionERP)
                        If dr.Tables(0).Rows.Count > 0 Then
                            If DevExpress.XtraEditors.XtraMessageBox.Show("Ya Existen Datos Guardados , Deseas Sobreescribir ? ", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                                Sql = "delete from erp_Ctrl_doh_projection where rtrim(ltrim(Line)) in (select  distinct  rtrim(ltrim(Line)) from erp_Ctrl_doh_projection_tmp)"
                                Executa_Query(Sql, var_conexionERP)
                                Sql = "INSERT INTO erp_Ctrl_doh_projection SELECT * FROM erp_Ctrl_doh_projection_TMP"
                                Executa_Query(Sql, var_conexionERP)
                                Sql = "DELETE FROM  erp_Ctrl_doh_projection_TMP"
                                Executa_Query(Sql, var_conexionERP)
                                DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                Sql = "DELETE FROM  erp_Ctrl_doh_projection_TMP"
                                Executa_Query(Sql, var_conexionERP)
                                Exit Sub
                            End If
                        Else
                            Sql = "INSERT INTO erp_Ctrl_doh_projection SELECT * FROM erp_Ctrl_doh_projection_TMP"
                            Executa_Query(Sql, var_conexionERP)
                            Sql = "DELETE FROM  erp_Ctrl_doh_projection_TMP"
                            Executa_Query(Sql, var_conexionERP)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        DevExpress.XtraEditors.XtraMessageBox.Show("Linea No eziste en CND , Favor de Revisar ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub te_fa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_fa.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_fb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_fb.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_fc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_fc.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_fd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_fd.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_fe_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_fe.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_ff_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_ff.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_fg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_fg.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_fh_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_fh.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_da_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_da.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_db_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_db.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_dc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_dc.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_dd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_dd.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_de_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_de.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_df_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_df.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_dg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_dg.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_dh_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_dh.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub te_section_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles te_inv.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton4.Click
        '' GUARDAR EN UNA TABLA TEMPORAL 
        Try
            Select Case NumFlujo
                Case 1
                    If te_fa.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_da.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_inv.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Inventario Inicial ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Sql = "delete from ERP_CTRL_DOH_PROJECTION_Data where Linea = '" & up_nombre_comun.Text.Trim & "'"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_la.Text.Trim & "','" & te_ta.Text.Trim & "', '" & te_fa.Text & "','" & te_da.Text & "', '" & te_inv.Text & "' " & _
                     ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)

                    DesactivarTextBox()
                    te_inv.Text = ""
                    dt_fecha.EditValue = ""
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 2
                    If te_fa.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_da.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fb.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_db.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_inv.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Inventario Inicial ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Sql = "delete from ERP_CTRL_DOH_PROJECTION_Data where Linea = '" & up_nombre_comun.Text.Trim & "'"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_la.Text.Trim & "','" & te_ta.Text.Trim & "', '" & te_fa.Text & "','" & te_da.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lb.Text.Trim & "','" & te_tb.Text.Trim & "', '" & te_fb.Text & "','" & te_db.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    DesactivarTextBox()
                    te_inv.Text = ""
                    dt_fecha.EditValue = ""

                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 3
                    If te_fa.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_da.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fb.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_db.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_inv.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Inventario Inicial ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Sql = "delete from ERP_CTRL_DOH_PROJECTION_Data where Linea = '" & up_nombre_comun.Text.Trim & "'"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_la.Text.Trim & "','" & te_ta.Text.Trim & "', '" & te_fa.Text & "','" & te_da.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lb.Text.Trim & "','" & te_tb.Text.Trim & "', '" & te_fb.Text & "','" & te_db.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lc.Text.Trim & "','" & te_tc.Text.Trim & "', '" & te_fc.Text & "','" & te_dc.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    DesactivarTextBox()
                    te_inv.Text = ""
                    dt_fecha.EditValue = ""
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 4
                    If te_fa.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_da.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fb.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_db.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_inv.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Inventario Inicial ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Sql = "delete from ERP_CTRL_DOH_PROJECTION_Data where Linea = '" & up_nombre_comun.Text.Trim & "'"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_la.Text.Trim & "','" & te_ta.Text.Trim & "', '" & te_fa.Text & "','" & te_da.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lb.Text.Trim & "','" & te_tb.Text.Trim & "', '" & te_fb.Text & "','" & te_db.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lc.Text.Trim & "','" & te_tc.Text.Trim & "', '" & te_fc.Text & "','" & te_dc.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_ld.Text.Trim & "','" & te_td.Text.Trim & "', '" & te_fd.Text & "','" & te_dd.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)

                    DesactivarTextBox()
                    te_inv.Text = ""
                    dt_fecha.EditValue = ""

                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Case 5
                    If te_fa.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_da.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fb.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_db.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fe.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea E ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_de.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario E ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_inv.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Inventario Inicial ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Sql = "delete from ERP_CTRL_DOH_PROJECTION_Data where Linea = '" & up_nombre_comun.Text.Trim & "'"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_la.Text.Trim & "','" & te_ta.Text.Trim & "', '" & te_fa.Text & "','" & te_da.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lb.Text.Trim & "','" & te_tb.Text.Trim & "', '" & te_fb.Text & "','" & te_db.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lc.Text.Trim & "','" & te_tc.Text.Trim & "', '" & te_fc.Text & "','" & te_dc.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_ld.Text.Trim & "','" & te_td.Text.Trim & "', '" & te_fd.Text & "','" & te_dd.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_le.Text.Trim & "','" & te_te.Text.Trim & "', '" & te_fe.Text & "','" & te_de.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)

                    DesactivarTextBox()
                    te_inv.Text = ""
                    dt_fecha.EditValue = ""

                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 6
                    If te_fa.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_da.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fb.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_db.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fe.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea E ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_de.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario E ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_ff.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea F ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_df.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario F ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_inv.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Inventario Inicial ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Sql = "delete from ERP_CTRL_DOH_PROJECTION_Data where Linea = '" & up_nombre_comun.Text.Trim & "'"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_la.Text.Trim & "','" & te_ta.Text.Trim & "', '" & te_fa.Text & "','" & te_da.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lb.Text.Trim & "','" & te_tb.Text.Trim & "', '" & te_fb.Text & "','" & te_db.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lc.Text.Trim & "','" & te_tc.Text.Trim & "', '" & te_fc.Text & "','" & te_dc.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_ld.Text.Trim & "','" & te_td.Text.Trim & "', '" & te_fd.Text & "','" & te_dd.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_le.Text.Trim & "','" & te_te.Text.Trim & "', '" & te_fe.Text & "','" & te_de.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lf.Text.Trim & "','" & te_tf.Text.Trim & "', '" & te_ff.Text & "','" & te_df.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)

                    DesactivarTextBox()
                    te_inv.Text = ""
                    dt_fecha.EditValue = ""

                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 7
                    If te_fa.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_da.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fb.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_db.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fe.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea E ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_de.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario E ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_ff.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea F ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_df.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario F ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fg.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea G ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dg.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario G ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_inv.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Inventario Inicial ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Sql = "delete from ERP_CTRL_DOH_PROJECTION_Data where Linea = '" & up_nombre_comun.Text.Trim & "'"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_la.Text.Trim & "','" & te_ta.Text.Trim & "', '" & te_fa.Text & "','" & te_da.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lb.Text.Trim & "','" & te_tb.Text.Trim & "', '" & te_fb.Text & "','" & te_db.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lc.Text.Trim & "','" & te_tc.Text.Trim & "', '" & te_fc.Text & "','" & te_dc.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_ld.Text.Trim & "','" & te_td.Text.Trim & "', '" & te_fd.Text & "','" & te_dd.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_le.Text.Trim & "','" & te_te.Text.Trim & "', '" & te_fe.Text & "','" & te_de.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lf.Text.Trim & "','" & te_tf.Text.Trim & "', '" & te_ff.Text & "','" & te_df.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lg.Text.Trim & "','" & te_tg.Text.Trim & "', '" & te_fg.Text & "','" & te_dg.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)

                    DesactivarTextBox()
                    te_inv.Text = ""
                    dt_fecha.EditValue = ""

                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 8
                    If te_fa.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_da.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario A ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fb.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_db.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario B ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dc.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario C ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dd.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario D ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fe.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea E ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_de.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario E ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_ff.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea F ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_df.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario F ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fg.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea G ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dg.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario G ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_fh.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Linea H ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_dh.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Formacion de Plan Diario H ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If te_inv.Text = "" Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Inventario Inicial ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Sql = "delete from ERP_CTRL_DOH_PROJECTION_Data where Linea = '" & up_nombre_comun.Text.Trim & "'"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_la.Text.Trim & "','" & te_ta.Text.Trim & "', '" & te_fa.Text & "','" & te_da.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lb.Text.Trim & "','" & te_tb.Text.Trim & "', '" & te_fb.Text & "','" & te_db.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lc.Text.Trim & "','" & te_tc.Text.Trim & "', '" & te_fc.Text & "','" & te_dc.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_ld.Text.Trim & "','" & te_td.Text.Trim & "', '" & te_fd.Text & "','" & te_dd.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_le.Text.Trim & "','" & te_te.Text.Trim & "', '" & te_fe.Text & "','" & te_de.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lf.Text.Trim & "','" & te_tf.Text.Trim & "', '" & te_ff.Text & "','" & te_df.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lg.Text.Trim & "','" & te_tg.Text.Trim & "', '" & te_fg.Text & "','" & te_dg.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    Sql = "insert into ERP_CTRL_DOH_PROJECTION_DATA VALUES  ('" & up_nombre_comun.Text.Trim & "','" & te_lh.Text.Trim & "','" & te_th.Text.Trim & "', '" & te_fh.Text & "','" & te_dh.Text & "', '" & te_inv.Text & "' " & _
                    ",'" & dt_fecha.Text & "')"
                    Executa_Query(Sql, var_conexionERP)
                    DesactivarTextBox()
                    te_inv.Text = ""
                    dt_fecha.EditValue = ""

                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Select
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Try
            If up_nombre_comun.Text <> "" Then
                Dim sql As String
                sql = "select * from ERP_CTRL_DOH_PROJECTION  WHERE Line = '" & up_nombre_comun.Text & "' and Data	 = 'Daily_Forecast'"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                sql = "select * from ERP_CTRL_DOH_PROJECTION  WHERE Line = '" & up_nombre_comun.Text & "' and Data	 = 'Working_Days'"
                Dim dsa As DataSet
                dsa = Consulta_Datos(sql, var_conexionERP)
                sql = "select max(c.Car_description) as  Vehiculo  from erp_Ctrl_lines a  left join ERP_CTRL_XREF b on a.Line_C = b.Line_c left join ERP_CTRL_VEHICLES c on b.Vehicle = c.Car_cd  where Nombre_comun like '%" & up_nombre_comun.Text & "%' and Active <> '0'"
                Dim dsR As DataSet
                dsR = Consulta_Datos(sql, var_conexionERP)

                sql = "SELECT * FROM  ERP_CTRL_DOH_PROJECTION_DATA  WHERE Linea = '" & up_nombre_comun.Text & "'"
                Dim dsE As DataSet
                dsE = Consulta_Datos(sql, var_conexionERP)

                Dim re = 5
                Cursor = Cursors.Default
                Dim _excel As New Application
                Dim Nombre_Excel = "DOH_PROJECTION.xlsx"
                Dim _wBook As Workbook = _excel.Workbooks.Open(String.Format("{0}\DOH_PROJECTION.xlsx", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)))
                Dim _sheet As Worksheet = DirectCast(_wBook.Worksheets("Sheet1"), Worksheet)
                For i = 0 To dsE.Tables(0).Rows.Count - 1

                    _sheet.Range("A4").Value = dsR.Tables(0).Rows(0)("Vehiculo")
                    _sheet.Range("B4").Value = ds.Tables(0).Rows(0)("Line")
                    _sheet.Range("F3").Value = dsE.Tables(0).Rows(0)("Fecha_inicio")
                    _sheet.Range("E14").Value = dsE.Tables(0).Rows(0)("Inv_inicial")

                    _sheet.Range("F4").Value = ds.Tables(0).Rows(0)("0")
                    _sheet.Range("G4").Value = ds.Tables(0).Rows(0)("1")
                    _sheet.Range("H4").Value = ds.Tables(0).Rows(0)("2")
                    _sheet.Range("I4").Value = ds.Tables(0).Rows(0)("3")
                    _sheet.Range("J4").Value = ds.Tables(0).Rows(0)("4")
                    _sheet.Range("K4").Value = ds.Tables(0).Rows(0)("5")
                    _sheet.Range("L4").Value = ds.Tables(0).Rows(0)("6")
                    _sheet.Range("M4").Value = ds.Tables(0).Rows(0)("7")
                    _sheet.Range("N4").Value = ds.Tables(0).Rows(0)("8")
                    _sheet.Range("O4").Value = ds.Tables(0).Rows(0)("9")
                    _sheet.Range("P4").Value = ds.Tables(0).Rows(0)("10")
                    _sheet.Range("Q4").Value = ds.Tables(0).Rows(0)("11")
                    _sheet.Range("R4").Value = ds.Tables(0).Rows(0)("12")
                    _sheet.Range("S4").Value = ds.Tables(0).Rows(0)("13")
                    _sheet.Range("T4").Value = ds.Tables(0).Rows(0)("14")
                    _sheet.Range("U4").Value = ds.Tables(0).Rows(0)("15")
                    _sheet.Range("V4").Value = ds.Tables(0).Rows(0)("16")
                    _sheet.Range("W4").Value = ds.Tables(0).Rows(0)("17")
                    _sheet.Range("X4").Value = ds.Tables(0).Rows(0)("18")
                    _sheet.Range("Y4").Value = ds.Tables(0).Rows(0)("19")
                    _sheet.Range("Z4").Value = ds.Tables(0).Rows(0)("20")

                    _sheet.Range("F2").Value = dsa.Tables(0).Rows(0)("0")
                    _sheet.Range("G2").Value = dsa.Tables(0).Rows(0)("1")
                    _sheet.Range("H2").Value = dsa.Tables(0).Rows(0)("2")
                    _sheet.Range("I2").Value = dsa.Tables(0).Rows(0)("3")
                    _sheet.Range("J2").Value = dsa.Tables(0).Rows(0)("4")
                    _sheet.Range("K2").Value = dsa.Tables(0).Rows(0)("5")
                    _sheet.Range("L2").Value = dsa.Tables(0).Rows(0)("6")
                    _sheet.Range("M2").Value = dsa.Tables(0).Rows(0)("7")
                    _sheet.Range("N2").Value = dsa.Tables(0).Rows(0)("8")
                    _sheet.Range("O2").Value = dsa.Tables(0).Rows(0)("9")
                    _sheet.Range("P2").Value = dsa.Tables(0).Rows(0)("10")
                    _sheet.Range("Q2").Value = dsa.Tables(0).Rows(0)("11")
                    _sheet.Range("R2").Value = dsa.Tables(0).Rows(0)("12")
                    _sheet.Range("S2").Value = dsa.Tables(0).Rows(0)("13")
                    _sheet.Range("T2").Value = dsa.Tables(0).Rows(0)("14")
                    _sheet.Range("U2").Value = dsa.Tables(0).Rows(0)("15")
                    _sheet.Range("V2").Value = dsa.Tables(0).Rows(0)("16")
                    _sheet.Range("W2").Value = dsa.Tables(0).Rows(0)("17")
                    _sheet.Range("X2").Value = dsa.Tables(0).Rows(0)("18")
                    _sheet.Range("Y2").Value = dsa.Tables(0).Rows(0)("19")
                    _sheet.Range("Z2").Value = dsa.Tables(0).Rows(0)("20")

                    _sheet.Range("C" & re).Value = dsE.Tables(0).Rows(i)("Flujo")
                    _sheet.Range("D" & re).Value = dsE.Tables(0).Rows(i)("Turno")
                    _sheet.Range("E" & re).Value = dsE.Tables(0).Rows(i)("Line_formation")
                    _sheet.Range("F" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("G" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("H" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("I" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("J" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("K" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("L" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("M" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("N" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("O" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("P" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("Q" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("R" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("S" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("T" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("U" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("V" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("W" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("X" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("Y" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    _sheet.Range("Z" & re).Value = dsE.Tables(0).Rows(i)("Plan_diario")
                    re = re + 1
                Next
                Dim Nuevo_nombre As String = "DOH_PROJECTION"
                _excel.Workbooks.Item(1).Saved = True
                _excel.Workbooks.Item(1).SaveAs(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Nuevo_nombre + ".xlsx")
                If Not _excel Is Nothing Then
                    _excel.Quit()
                    _excel = Nothing
                End If
                System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & Nuevo_nombre + ".xlsx")
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
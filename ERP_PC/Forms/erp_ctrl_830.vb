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
Imports AccesoDatos
Imports Funciones
Public Class erp_ctrl_830
    Dim sql As String
    'Dim planner As String
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim dialog As New OpenFileDialog
        Dim path As String
        Dim ConnExcel As New OleDb.OleDbConnection
        Dim Cmd As New OleDb.OleDbCommand
        Dim Da As New OleDb.OleDbDataAdapter
        Dim Ds As New DataSet
        Dim Dset As New DataSet
        Dim revision As String
        Dim conn As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ObjExcel As Excel.ApplicationClass
        Dim ObjW As Excel.WorkbookClass
        Dim nomHoja As String
        revision = ""
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
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    sql = "Delete from ERP_CTRL_830_IMPORT_TMP"
                    Executa_Query(sql, var_conexionERP)
                    ''Cursor = Cursors.WaitCursor
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO  ERP_CTRL_830_IMPORT_TMP VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "'," & _
                        "'" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(11).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(12).ToString.Trim & "'," & _
                        "'" & Ds.Tables(0).Rows(i)(13).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(14).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(15).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(16).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(17).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(18).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(19).ToString.Trim & "'," & _
                        "'" & Ds.Tables(0).Rows(i)(20).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(21).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(22).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(23).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(24).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(25).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(26).ToString.Trim & "'," & _
                        "'" & Ds.Tables(0).Rows(i)(27).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(28).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(29).ToString.Trim & "')"
                        comm.ExecuteNonQuery()
                    Next i
                    sql = "select distinct Customer from ERP_CTRL_830_IMPORT_TMP where Customer in (select Customer_id from ERP_CTRL_CUST_DELIVER where Active = '1') "
                    Dim dg As New DataSet
                    dg = Consulta_Datos(sql, var_conexionERP)
                    If dg.Tables(0).Rows.Count > 0 Then
                        sql = "select distinct customer from ERP_CTRL_830_IMPORT_TMP where convert(varchar,convert(date,Issuance_date))+Customer  in " & _
                    "(select convert(varchar,convert(date,Issuance_date))+Customer from ERP_CTRL_830_IMPORT ) "
                        Dim dr As New DataSet
                        dr = Consulta_Datos(sql, var_conexionERP)
                        If dr.Tables(0).Rows.Count > 0 Then
                            If DevExpress.XtraEditors.XtraMessageBox.Show("Ya existen Datos del mismo Cliente , Desea Reemplazar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                                ' eliminar datos de la original que solo sean del mismo cliente y misma fecha 
                                sql = "delete from ERP_CTRL_830_IMPORT where convert(varchar,convert(date,Issuance_date))+Customer in (select distinct convert(varchar,convert(date,Issuance_date))+Customer from ERP_CTRL_830_IMPORT_TMP)"
                                Executa_Query(sql, var_conexionERP)
                                sql = " insert into ERP_CTRL_830_IMPORT select * from ERP_CTRL_830_IMPORT_TMP "
                                Executa_Query(sql, var_conexionERP)
                                sql = "DELETE FROM  ERP_CTRL_830_IMPORT_TMP"
                                Executa_Query(sql, var_conexionERP)
                                DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                SimpleButton1.Visible = False
                                conn.Close()
                                GV1.Columns.Clear()
                                'y pegar datos de la temporal a la original 
                            End If
                        Else
                            '''AGREGAR VALIDACION SI EL CLIENTE NO EXISTE NO GUARDAR EN TABLA ERP_CTRL_830_IMPORT
                            '' GUARDAR EN LA TABLA QUE NO ES TEMPORAL 
                            sql = " insert into ERP_CTRL_830_IMPORT select * from ERP_CTRL_830_IMPORT_TMP "
                            Executa_Query(sql, var_conexionERP)
                            sql = "DELETE FROM  ERP_CTRL_830_IMPORT_TMP"
                            Executa_Query(sql, var_conexionERP)
                            DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            SimpleButton1.Visible = False
                            conn.Close()
                            GV1.Columns.Clear()
                        End If
                    Else
                        DevExpress.XtraEditors.XtraMessageBox.Show("Cliente no se encuentra  en Base de Datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub erp_ctrl_830_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarCustomer()
        'Dim ds As New DataSet
        'sql = "Select planner_id from  ERP_CTRL_PLANNER where planner_descr = '" & var_adm_Usr_NICK & "'"
        'ds = Consulta_Datos(sql, var_conexionERP)
        'If ds.Tables(0).Rows.Count > 0 Then
        '    planner = ds.Tables(0).Rows(0)(0).ToString.Trim
        '    planner = planner.Substring(1, 2)
        'Else
        '    DevExpress.XtraEditors.XtraMessageBox.Show("Usuario No se encuentra en la Base de Datos", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub
    Public Sub CargarCustomer()
        Dim ds As New DataSet
        Try
            sql = "select distinct Customer from ERP_CTRL_830_IMPORT "
            ds = Consulta_Datos(sql, var_conexionERP)
            up_cliente.Properties.DataSource = ds.Tables(0)
            up_cliente.Properties.DisplayMember = "Customer"
            up_cliente.Properties.ValueMember = "Customer"
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''' TRANSFORMAR A VERTICAL EL CUSTOMER QUE EXISTA EN LA TABLA DE ERP_CTRL_830_IMPORT
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
End Class
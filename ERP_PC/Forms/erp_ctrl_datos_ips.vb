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
Public Class erp_ctrl_datos_ips
    Dim sql As String
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim dialog As New OpenFileDialog
        Dim path As String
        Dim ConnExcel As New OleDb.OleDbConnection
        Dim Cmd As New OleDb.OleDbCommand
        Dim Da As New OleDb.OleDbDataAdapter
        Dim Ds As New DataSet
        Dim Dset As New DataSet
        Dim fecha As String
        Dim conn As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ObjExcel As Excel.ApplicationClass
        Dim ObjW As Excel.WorkbookClass
        Dim nomHoja As String
        Dim StrSQL, revision As String
        fecha = ""
        Try
            dialog.InitialDirectory = "C:\"
            dialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*"
            If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path = dialog.FileName
                ObjExcel = New Excel.ApplicationClass
                ObjW = ObjExcel.Workbooks.Open(path)
                nomHoja = ObjW.Sheets(2).Name
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
                comm.CommandText = "DELETE FROM ERP_CTRL_IMPORT_IPS_TMP"
                comm.ExecuteNonQuery()
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_IMPORT_IPS_TMP VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(11).ToString.Trim & "' )"
                        comm.ExecuteNonQuery()
                    Next i
                    conn.Close()
                    StrSQL = "Select top 1 convert(date,Upload_date) from  ERP_CTRL_IMPORT_IPS_TMP order by Upload_date desc"
                    revision = Consulta_Dato(StrSQL, var_conexionERP)
                    StrSQL = String.Format("Select * from  ERP_CTRL_IMPORT_IPS where Upload_date = '{0}'", Trim(revision))
                    If Existe_Dato(StrSQL, var_conexionERP) = True Then
                        Cursor = Cursors.Default
                        If DevExpress.XtraEditors.XtraMessageBox.Show("Ya existen los Datos , Deseas Eliminar e Insertar ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            StrSQL = "DELETE from ERP_CTRL_IMPORT_IPS where Upload_date = '" & revision & "'"
                            Executa_Query(StrSQL, var_conexionERP)
                            StrSQL = "Insert Into ERP_CTRL_IMPORT_IPS Select * From ERP_CTRL_IMPORT_IPS_TMP"
                            Executa_Query(StrSQL, var_conexionERP)
                            MessageBox.Show("Importado Correctamente", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            GV1.Columns.Clear()
                        Else
                            Exit Sub
                        End If
                    Else
                        StrSQL = "Insert Into ERP_CTRL_IMPORT_IPS Select * From ERP_CTRL_IMPORT_IPS_TMP"
                        If Executa_Query(StrSQL, var_conexionERP) = True Then
                            StrSQL = "DELETE from ERP_CTRL_IMPORT_IPS_TMP"
                            Executa_Query(StrSQL, var_conexionERP)
                            MessageBox.Show("Importado Correctamente", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            GV1.Columns.Clear()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim dialog As New OpenFileDialog
        Dim path As String
        Dim ConnExcel As New OleDb.OleDbConnection
        Dim Cmd As New OleDb.OleDbCommand
        Dim Da As New OleDb.OleDbDataAdapter
        Dim Ds As New DataSet
        Dim Dset As New DataSet
        Dim fecha As String
        Dim conn As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ObjExcel As Excel.ApplicationClass
        Dim ObjW As Excel.WorkbookClass
        Dim nomHoja As String
        Dim StrSQL, revision As String
        fecha = ""
        Try
            dialog.InitialDirectory = "C:\"
            dialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*"
            If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                path = dialog.FileName
                ObjExcel = New Excel.ApplicationClass
                ObjW = ObjExcel.Workbooks.Open(path)
                nomHoja = ObjW.Sheets(2).Name
                ObjW.Close()
                ObjExcel.Quit()
                ConnExcel.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & "; Extended Properties= Excel 8.0;"
                Cmd.CommandText = "SELECT *  FROM [" & nomHoja & "$]"
                Cmd.Connection = ConnExcel
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Ds.Tables(0).TableName = "Excel"
                GridControl2.DataSource = Ds.Tables(0)
                conn.ConnectionString = var_conexionERP
                comm.CommandType = CommandType.Text
                comm.Connection = conn
                conn.Open()
                comm.CommandText = "DELETE FROM ERP_CTRL_IMPORT_DES11_TMP"
                comm.ExecuteNonQuery()
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_IMPORT_DES11_TMP VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(11).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(12).ToString.Trim & "'," & _
                        "'" & Ds.Tables(0).Rows(i)(13).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(14).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(15).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(16).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(17).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(18).ToString.Trim & "','" & Ds.Tables(0).Rows(i)(19).ToString.Trim & "' )"
                        comm.ExecuteNonQuery()
                    Next i
                    conn.Close()
                    StrSQL = "DELETE from ERP_CTRL_IMPORT_DES11"
                    Executa_Query(StrSQL, var_conexionERP)
                    StrSQL = "Insert Into ERP_CTRL_IMPORT_DES11 select  * from ERP_CTRL_IMPORT_DES11_TMP where Plant_code in (Select Codes from ERP_CTRL_CODES_PLANT)"
                    Executa_Query(StrSQL, var_conexionERP)
                    StrSQL = "DELETE from ERP_CTRL_IMPORT_DES11_TMP"
                    Executa_Query(StrSQL, var_conexionERP)
                    MessageBox.Show("Importado Correctamente", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GridView1.Columns.Clear()
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
Imports Funciones
Imports AccesoDatos
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
Public Class erp_ctrl_importar_ajustes_temporales
    Dim sql As String
    Private Sub butEliminar_Click(sender As Object, e As EventArgs) Handles butEliminar.Click
        Try
            If te_revtmp.Text <> "" Then
                If DevExpress.XtraEditors.XtraMessageBox.Show("Desea eliminar los datos ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    sql = "Delete from ERP_CTRL_ADHERENCIA where Rev = '" & te_revtmp.Text.Trim & "'  "
                    Executa_Query(sql, var_conexionERP)
                    'Cursor = Cursors.WaitCursor  
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion Eliminada Correctamente ", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    te_revtmp.Text = ""
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub butCargar_Click(sender As Object, e As EventArgs) Handles butCargar.Click
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
                    'Cursor = Cursors.WaitCursor
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_ADHERENCIA VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "')"
                        comm.ExecuteNonQuery()
                    Next i
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    butCargar.Visible = False
                    conn.Close()
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
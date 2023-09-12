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

Public Class erp_ctrl_four_months_forecaste

    Dim sql As String
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
                    Cursor = Cursors.WaitCursor
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_4MF_Data_Up VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', round('" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "',2,0), round('" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "',2,0), " & _
                        " round('" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "',2,0), round('" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "',2,0), round('" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "',2,0))"
                        comm.ExecuteNonQuery()
                    Next i
                    Cursor = Cursors.Default
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SimpleButton1.Visible = False

                    conn.Close()
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim ds As New DataSet
        Try
            sql = "select  * from ERP_CTRL_4MF_Data where Rev  = '" & LookUp_revision.Text.Trim & "' "
            If Existe_Dato(sql, var_conexionERP) Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Rev, Ya Existe. Favor de verificar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                sql = "SP_CTRL_4MF_CREA_DATOS_VERTICALES '" & LookUp_revision.Text.Trim & "'"
                Executa_Query(sql, var_conexionERP)
                DevExpress.XtraEditors.XtraMessageBox.Show("Informacion Generada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LookUp_revision.Text = ""
                CargaRevisiones3()
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Dim DGrid2 As New DevExpress.XtraGrid.GridControl
        Dim gridView1 As New DevExpress.XtraGrid.Views.Grid.GridView()
        Dim ds As New DataSet
        Try
            sql = "SP_CTRL_4MF_GENERA_DATOS '" & LookUpEdit1.Text.Trim & "'"
            ds = Consulta_Datos(sql, var_conexionERP)
            DGrid2.BindingContext = New System.Windows.Forms.BindingContext()
            DGrid2.DataSource = ds.Tables(0)
            DGrid2.ViewCollection.Add(gridView1)
            DGrid2.MainView = gridView1
            DGrid2.ExportToXls(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\" & LookUpEdit1.Text & ".xls")
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\" & LookUpEdit1.Text & ".xls")
            LookUpEdit1.Text = ""
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub erp_ctrl_four_months_forecast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CargaRevisiones()
            CargaRevisiones2()
            CargaRevisiones3()
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CargaRevisiones()
        Dim ds As New DataSet
        sql = "select distinct Rev as Revision from ERP_CTRL_4MF_Data_Up order by rev"
        ds = Consulta_Datos(sql, var_conexionERP)
        LookUp_revision.Properties.DisplayMember = "Revision"
        LookUp_revision.Properties.ValueMember = "Revision"
        LookUp_revision.Properties.DataSource = ds.Tables(0)
        LookUp_revision.EditValue = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub
    Public Sub CargaRevisiones2()
        Dim ds As New DataSet
        sql = "select distinct Rev as Revision from ERP_CTRL_4MF_Data_Up order by rev"
        ds = Consulta_Datos(sql, var_conexionERP)
        LookUpEdit2.Properties.DisplayMember = "Revision"
        LookUpEdit2.Properties.ValueMember = "Revision"
        LookUpEdit2.Properties.DataSource = ds.Tables(0)
        LookUpEdit2.EditValue = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub
    Public Sub CargaRevisiones3()
        Dim ds As New DataSet
        sql = "select distinct Rev as Revision from ERP_CTRL_4MF_Data order by rev"
        ds = Consulta_Datos(sql, var_conexionERP)
        LookUpEdit1.Properties.DisplayMember = "Revision"
        LookUpEdit1.Properties.ValueMember = "Revision"
        LookUpEdit1.Properties.DataSource = ds.Tables(0)
        LookUpEdit1.EditValue = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub

    Private Sub SimpleButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton5.Click
        Try
            If DateEdit1.DateTime.ToShortDateString = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Month 0", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DateEdit2.DateTime.ToShortDateString = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Month 3", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DateEdit3.DateTime.ToShortDateString = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Month 1", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DateEdit4.DateTime.ToShortDateString = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Month 4", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DateEdit5.DateTime.ToShortDateString = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Month 2", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DateEdit6.DateTime.ToShortDateString = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Favor de Ingresar Month 5", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If DevExpress.XtraEditors.XtraMessageBox.Show("Desea Guardar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                sql = "select  * from ERP_CTRL_4MF_Months where Rev  = '" & LookUpEdit2.Text & "' "
                If Existe_Dato(sql, var_conexionERP) Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("Rev, Ya Existe. Favor de verificar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DateEdit1.Text = ""
                    DateEdit2.Text = ""
                    DateEdit3.Text = ""
                    DateEdit4.Text = ""
                    DateEdit5.Text = ""
                    DateEdit6.Text = ""
                    LookUpEdit2.Text = ""
                    Exit Sub
                Else
                    sql = "insert into ERP_CTRL_4MF_Months (Rev,Month_Name,Month_No) values ('" & LookUpEdit2.Text & "','" & DateEdit1.DateTime.ToShortDateString & "','0'),('" & LookUpEdit2.Text & "','" & DateEdit3.DateTime.ToShortDateString & "','1'),('" & LookUpEdit2.Text & "','" & DateEdit5.DateTime.ToShortDateString & "','2'),('" & LookUpEdit2.Text & "','" & DateEdit2.DateTime.ToShortDateString & "','3'),('" & LookUpEdit2.Text & "','" & DateEdit4.DateTime.ToShortDateString & "','4'),('" & LookUpEdit2.Text & "','" & DateEdit6.DateTime.ToShortDateString & "','5')"
                    Executa_Query(sql, var_conexionERP)
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DateEdit1.Text = ""
                    DateEdit2.Text = ""
                    DateEdit3.Text = ""
                    DateEdit4.Text = ""
                    DateEdit5.Text = ""
                    DateEdit6.Text = ""
                    LookUpEdit2.Text = ""
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
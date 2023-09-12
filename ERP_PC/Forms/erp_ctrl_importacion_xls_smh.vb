Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Configuration

Imports System.Reflection
Imports System.IO
Imports System.Drawing.Point

Imports System.Drawing.Drawing2D
Imports Funciones
Imports AccesoDatos

Public Class erp_ctrl_importacion_xls_smh
    Dim sql As String
    Private Sub butCargarArchivo_Click(sender As Object, e As EventArgs) Handles butCargarArchivo.Click
        Dim conn As New SqlConnection
        Dim comm As New SqlCommand
        conn.ConnectionString = var_conexionERP
        comm.CommandType = CommandType.Text
        comm.Connection = conn
        conn.Open()
        Dim dialog As New OpenFileDialog
        Dim rutaArchivo, RUTADOCS As String
        dialog.Filter = "CSV Files (*.csv)|*.csv"
        If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            rutaArchivo = dialog.FileName
        Else
            Exit Sub
        End If
        RUTADOCS = rutaArchivo ' PreparaArchivo(rutaArchivo, cabecera)
        Dim ConnExcel As New OleDb.OleDbConnection
        Dim Cmd As New OleDb.OleDbCommand
        Dim Ds As New DataSet
        Dim Da As New OleDb.OleDbDataAdapter
        Dim RepCheck As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Try
            GridControl1.DataSource = Nothing

            ConnExcel.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & RUTADOCS.Replace(Path.GetFileName(RUTADOCS), "") & "; Extended Properties='text;HDR=Yes;FMT=Delimited';"
            Cmd.CommandText = "SELECT   *    FROM " & Path.GetFileName(RUTADOCS) & "    "
            Cmd.Connection = ConnExcel
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Ds.Tables(0).TableName = "Excel"
            GridControl1.DataSource = Ds.Tables(0)
            If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Sql = "SELECT top 1 * FROM ERP_CTRL_SMH_XLS "
                Dim dr As DataSet
                dr = Consulta_Datos(Sql, var_conexionERP)
                If dr.Tables(0).Rows.Count > 0 Then
                    'System.Threading.Thread.CurrentThread.CurrentCulture = CurrentCI
                    If DevExpress.XtraEditors.XtraMessageBox.Show("Ya existe un archivo cargado, Deseas Eliminar ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        Sql = "Delete from ERP_CTRL_SMH_XLS  "
                        Executa_Query(Sql, var_conexionERP)
                        Cursor = Cursors.WaitCursor
                        For i = 0 To Ds.Tables(0).Rows.Count - 1
                            comm.CommandText = "INSERT INTO ERP_CTRL_SMH_XLS VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(11).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(12).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(13).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(14).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(15).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(16).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(17).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(18).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(19).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(20).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(21).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(22).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(23).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(24).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(25).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(26).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(27).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(28).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(29).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(30).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(31).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(32).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(33).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(34).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(35).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(36).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(37).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(38).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(39).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(40).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(41).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(42).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(43).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(44).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(45).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(46).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(47).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(48).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(49).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(50).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(51).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(52).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(53).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(54).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(55).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(56).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(57).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(58).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(59).ToString.Trim & "', " & _
                            " '" & Ds.Tables(0).Rows(i)(60).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(61).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(62).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(63).ToString.Trim & "')"
                            comm.ExecuteNonQuery()
                        Next i
                        DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Quitar_()
                        conn.Close()
                    End If
                Else
                    Cursor = Cursors.WaitCursor
                    For i = 0 To Ds.Tables(0).Rows.Count - 1
                        comm.CommandText = "INSERT INTO ERP_CTRL_SMH_XLS VALUES('" & Ds.Tables(0).Rows(i)(0).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(1).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(2).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(3).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(4).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(5).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(6).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(7).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(8).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(9).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(10).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(11).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(12).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(13).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(14).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(15).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(16).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(17).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(18).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(19).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(20).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(21).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(22).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(23).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(24).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(25).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(26).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(27).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(28).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(29).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(30).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(31).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(32).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(33).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(34).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(35).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(36).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(37).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(38).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(39).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(40).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(41).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(42).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(43).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(44).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(45).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(46).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(47).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(48).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(49).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(50).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(51).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(52).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(53).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(54).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(55).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(56).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(57).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(58).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(59).ToString.Trim & "', " & _
                        " '" & Ds.Tables(0).Rows(i)(60).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(61).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(62).ToString.Trim & "', '" & Ds.Tables(0).Rows(i)(63).ToString.Trim & "')"
                        comm.ExecuteNonQuery()
                    Next i
                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Quitar_()
                    conn.Close()
                    ''

                End If
            End If
            '******************************************************************************************************************
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If DevExpress.XtraEditors.XtraMessageBox.Show("Desea guardar los datos?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

            Sql = "SELECT top 1 * FROM ERP_CTRL_SMH_XLS "
            Dim ds As DataSet
            ds = Consulta_Datos(Sql, var_conexionERP)
            If ds.Tables(0).Rows.Count > 0 Then
                System.Threading.Thread.CurrentThread.CurrentCulture = CurrentCI
                If DevExpress.XtraEditors.XtraMessageBox.Show("Ya existe un archivo cargado, Deseas Eliminar ?", "ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Sql = "Delete from ERP_CTRL_SMH_XLS  "
                    Executa_Query(Sql, var_conexionERP)

                    Cursor = Cursors.WaitCursor


                    Dim conn As New SqlConnection
                    Dim comm As New SqlCommand
                    conn.ConnectionString = var_conexionERP
                    comm.CommandType = CommandType.Text
                    comm.Connection = conn




                    Executa_Query(Sql, var_conexionSAUERP)

                    DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SimpleButton2.Enabled = False


                End If
            Else


                Dim conn As New SqlConnection
                Dim comm As New SqlCommand
                conn.ConnectionString = var_conexionERP
                comm.CommandType = CommandType.Text
                comm.Connection = conn

                conn.Close()
                DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SimpleButton2.Enabled = False

            End If
        End If
    End Sub

    Private Sub Quitar_()
        sql = "Update ERP_CTRL_SMH_XLS set MPS_Part_no =  REPLACE( MPS_Part_no,'@','') from  ERP_CTRL_SMH_XLS"
        Executa_Query(sql, var_conexionERP)
        sql = "Update ERP_CTRL_SMH_XLS set Cus_desch_c1 =  REPLACE( Cus_desch_c1,'@','') from  ERP_CTRL_SMH_XLS"
        Executa_Query(sql, var_conexionERP)
        sql = "Update ERP_CTRL_SMH_XLS set Cus_desch_c2 =  REPLACE( Cus_desch_c2,'@','') from  ERP_CTRL_SMH_XLS"
        Executa_Query(sql, var_conexionERP)
        sql = "Update ERP_CTRL_SMH_XLS set  int_desc_c =  REPLACE(  int_desc_c,'@','') from  ERP_CTRL_SMH_XLS"
        Executa_Query(sql, var_conexionERP)

    End Sub
End Class
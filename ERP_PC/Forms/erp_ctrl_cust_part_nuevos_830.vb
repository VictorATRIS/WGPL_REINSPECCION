
Imports AccesoDatos
Imports Funciones
Public Class erp_ctrl_cust_part_nuevos_830
    Dim sql As String
    Public ds, ds2 As DataSet
    Private Sub erp_ctrl_cust_part_nuevos_830_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            gc_productos.DataSource = Nothing
            gv_productos.Columns.Clear()
            gc_productos.DataSource = ds.Tables(0)
            gv_productos.BestFitColumns()

            gc_no_cnd.DataSource = Nothing
            gv_no_cnd.Columns.Clear()
            gc_no_cnd.DataSource = ds2.Tables(0)
            gv_no_cnd.BestFitColumns()
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show("Error general: " & ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()

    End Sub

    
End Class
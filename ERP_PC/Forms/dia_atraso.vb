Imports AccesoDatos
Imports Funciones
Public Class dia_atraso
    Dim sql As String
    Private Sub dia_atraso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargadia()
    End Sub
    Public Sub Cargadia()
        Dim ds As New DataSet
        sql = "select dia_atraso from ERP_CTRL_DIA_ATRASO"
        ds = Consulta_Datos(sql, var_conexionERP)
        Label3.Text = ds.Tables(0).Rows(0)(0).ToString.Trim
    End Sub

    Private Sub btn_gene_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gene.Click
        sql = "update dbo.ERP_CTRL_DIA_ATRASO set Dia_atraso = '" & CB_dia.Text.Trim & "' , Fecha_actualizacion = getdate() "
        Executa_Query(sql, var_conexionERP)
        Cargadia()
        DevExpress.XtraEditors.XtraMessageBox.Show("Dia Actualizado", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
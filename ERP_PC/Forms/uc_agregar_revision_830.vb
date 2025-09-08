Imports AccesoDatos
Imports Funciones
Public Class uc_agregar_revision_830
    Dim sql As String
    Private Sub Btn_guardar_Click(sender As Object, e As EventArgs) Handles Btn_guardar.Click
        Try

            If Trim(TB_revision.Text) = "" Or DateEdit1.Text = "" Then
                DevExpress.XtraEditors.XtraMessageBox.Show("No dejes campos vacios", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            sql = "select * from erp_ctrl_plan_rev where revision = '" & Trim(TB_revision.Text) & "'"
            If Existe_Dato(sql, var_conexionERP) Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Esta revision ya fue registrada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            sql = String.Format("insert into erp_ctrl_plan_rev values ('{0}','{1}',null,'0',getdate(),'M8')", Trim(TB_revision.Text), DateEdit1.Text)
            Executa_Query(sql, var_conexionERP)
            DevExpress.XtraEditors.XtraMessageBox.Show("La revision se registro con exito", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

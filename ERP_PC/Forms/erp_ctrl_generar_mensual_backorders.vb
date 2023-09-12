Imports AccesoDatos
Imports Funciones
Public Class erp_ctrl_generar_mensual_backorders
    Dim sql As String

    Private Sub butConsultar_Click(sender As Object, e As EventArgs) Handles butConsultar.Click
        Try

            Dim fechaI = DateEdit1.DateTime.ToShortDateString
            Dim fechaF = DateEdit2.DateTime.ToShortDateString
            If DateEdit1.Text <> "" And DateEdit2.Text <> "" Then
                sql = "SELECT     'MP' AS Section_Id, 'BackOrder' AS Rev, convert(char(25),(DATEADD(s,0,DATEADD(mm,DATEDIFF(m,0,getdate()),0))), 101) as Prod_date, b.Line as Line, rtrim(b.Plant) as Plant, a.Sews_part_no, b.Customer_Id, b.type, SUM(CONVERT(int, b.Dif)) * -1 AS Total_PLAN, '0' AS Total_Prod, SUM(CONVERT(int, b.Dif)) AS Dif " & _
                       "FROM      erp_ctrl_xref as a, erp_ctrl_adherencia as b, erp_ctrl_lines as c WHERE (b.Prod_date >= '" & fechaI & "') AND (b.Prod_date <= '" & fechaF & "') AND (a.Active = '1' ) and a.line_c = c.line_c and a.sews_part_no = b.Sews_part_no and a.customer_id = b.customer_id   " & _
                       "and b.type <> 'ESQ' and A.sews_part_no not like 'AB%' GROUP BY a.Sews_part_no, b.line, b.Plant, b.Customer_Id, b.type HAVING SUM(CONVERT(int, b.Dif)) <> 0"
                Dim ds As DataSet
                ds = Consulta_Datos(sql, var_conexionERP)
                Cursor = Cursors.Default
                gc_backs.DataSource = ds.Tables(0)
                butInsertar.Visible = True
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub butInsertar_Click(sender As Object, e As EventArgs) Handles butInsertar.Click
        Try

            Dim fechaI = DateEdit1.DateTime.ToShortDateString
            Dim fechaF = DateEdit2.DateTime.ToShortDateString
            If DateEdit1.Text <> "" And DateEdit2.Text <> "" Then
                sql = "INSERT INTO ERP_CTRL_ADHERENCIA SELECT 'MP' AS Section_Id, 'BackOrder' AS Rev, convert(char(25),(DATEADD(s,0,DATEADD(mm,DATEDIFF(m,0,getdate()),0))), 101) as Prod_date, b.Line as Line, rtrim(b.Plant) as Plant, a.Sews_part_no, b.Customer_Id, b.type, SUM(CONVERT(int, b.Dif)) * -1 AS Total_PLAN, " & _
                       "'0' AS Total_Prod, SUM(CONVERT(int, b.Dif)) AS Dif " & _
                       "FROM      erp_ctrl_xref as a, erp_ctrl_adherencia as b, erp_ctrl_lines as c WHERE (b.Prod_date >= '" & fechaI & "') AND (b.Prod_date <= '" & fechaF & "') AND (a.Active = '1' ) and a.line_c = c.line_c and a.sews_part_no = b.Sews_part_no and a.customer_id = b.customer_id   " & _
                       "and b.type <> 'ESQ' and A.sews_part_no not like 'AB%' GROUP BY a.Sews_part_no, b.line, b.Plant, b.Customer_Id, b.type HAVING SUM(CONVERT(int, b.Dif)) <> 0"
                Executa_Query(sql, var_conexionERP)
                Cursor = Cursors.Default
                DevExpress.XtraEditors.XtraMessageBox.Show("Informacion almacenada", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                butInsertar.Visible = False

            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
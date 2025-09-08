Imports AccesoDatos
Imports Funciones

Public Class frmRechazoRequest
    Public serialArnes, sortRequestIds, sql As String
    Dim ds As DataSet
    Private Sub frmRechazoRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            labSerial.Text = serialArnes

            checkedCombo.Properties.DataSource = Nothing

            sql = "SELECT DISTINCT d.SortRequest_Id, " &
                   "Quality_Issue, " &
                   "CAST(d.SortRequest_Id AS VARCHAR) + ' - ' + Quality_Issue AS DisplayText " &
                   "FROM ERP_CTRL_WGPL_SORT_REQUEST_DT d " &
                   "JOIN ERP_CTRL_WGPL_SORT_REQUEST r ON r.SortRequest_Id = d.SortRequest_Id " &
                   "WHERE d.SortRequest_Id IN (" & String.Join(",", sortRequestIds.Split(","c).Select(Function(s) "'" & s.Trim() & "'")) & ") " &
                   "AND r.statusRequest = '2'"
            ds = Consulta_Datos(sql, var_conexionERP)
            checkedCombo.Properties.DisplayMember = "DisplayText"
            checkedCombo.Properties.ValueMember = "SortRequest_Id"
            checkedCombo.Properties.DataSource = ds.Tables(0)

            checkedCombo.Refresh()
            checkedCombo.SetEditValue(Nothing)


        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Reinspección", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim seleccionados = checkedCombo.Properties.GetCheckedItems().ToString().Split(","c).Select(Function(s) s.Trim()).ToList()

        If seleccionados.Count = 0 Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Seleccione al menos un SortRequest como defectuoso.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Public ReadOnly Property SortsDefectuosos As List(Of String)
        Get
            Return checkedCombo.Properties.GetCheckedItems().ToString().Split(","c).Select(Function(s) s.Trim()).ToList()
        End Get
    End Property


    Public ReadOnly Property SortsCorrectos As List(Of String)
        Get
            Dim todos = sortRequestIds.Split(","c).Select(Function(s) s.Trim()).ToList()
            Return todos.Except(SortsDefectuosos).ToList()
        End Get
    End Property



End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Configuration
Imports System.Threading
Imports System.Globalization
Imports Funciones
Imports AccesoDatos

Imports Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.IO
Imports System.Drawing.Point
Imports Microsoft.Office.Interop
Imports System.Drawing.Drawing2D

Imports hoja = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb

Public Class erp_ctrl_cargar_archivo_pull_system
    Dim sql As String
    Dim ds As DataSet
    Dim listaNoValidos As New List(Of String)

    Dim cryRpt As ReportDocument = New ReportDocument()
    Dim forma_reportes As New erp_reports
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles butCargarArchivo.Click
        Try
            Dim dialog As New OpenFileDialog()
            Dim path As String
            Dim ConnExcel As New OleDb.OleDbConnection()
            Dim Cmd As New OleDb.OleDbCommand()
            Dim Da As New OleDb.OleDbDataAdapter()
            Dim Ds As New System.Data.DataSet()
            Dim nomHoja As String
            Dim provider As String

            dialog.InitialDirectory = "C:\"
            dialog.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx"

            If dialog.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                path = dialog.FileName

                Try
                    provider = "Microsoft.ACE.OLEDB.12.0"
                    ConnExcel.ConnectionString = "Provider=" & provider & ";Data Source=" & path & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
                    ConnExcel.Open()
                Catch ex As Exception
                    ConnExcel.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;'", path)
                    Try
                        ConnExcel.Open()
                    Catch ex2 As Exception
                        MessageBox.Show("Error al abrir el archivo con ambos proveedores. Verifique su instalación de Office.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                End Try

                ' Obtener el nombre de la primera hoja sin usar Interop
                Dim dtSheets As System.Data.DataTable = ConnExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                If dtSheets IsNot Nothing AndAlso dtSheets.Rows.Count > 0 Then
                    nomHoja = dtSheets.Rows(0)("TABLE_NAME").ToString().Replace("'", "")
                Else
                    MessageBox.Show("No se encontraron hojas en el archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ConnExcel.Close()
                    Exit Sub
                End If

                ' Leer los datos de la hoja
                Cmd.CommandText = "SELECT * FROM [" & nomHoja & "]"
                Cmd.Connection = ConnExcel
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Ds.Tables(0).TableName = "Excel"

                ' Mostrar los datos en el GridControl
                If Ds.Tables(0).Rows.Count > 1 AndAlso
                   String.IsNullOrEmpty(Ds.Tables(0).Rows(0)(0).ToString()) AndAlso
                   String.IsNullOrEmpty(Ds.Tables(0).Rows(1)(0).ToString()) Then

                    Ds.Tables(0).Rows(1).Delete()
                    Ds.Tables(0).Rows(0).Delete()
                    Ds.Tables(0).AcceptChanges()
                End If

                GridControl1.DataSource = Ds.Tables(0)
                ConnExcel.Close()
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles butGuardar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim order_no, cust_part, ship_to, created_date, ship_date, due_date, part_no, desing As String
            Dim qty As Integer = 0

            sql = "delete from ERP_CTRL_PULL_SYSTEM_ORDER_TMP"
            Executa_Query(sql, var_conexionERP)


            For i = 0 To GV1.RowCount - 1
                order_no = GV1.GetRowCellValue(i, GV1.Columns(0).FieldName).ToString()
                cust_part = GV1.GetRowCellValue(i, GV1.Columns(1).FieldName).ToString()
                ship_to = GV1.GetRowCellValue(i, GV1.Columns(2).FieldName).ToString()
                created_date = GV1.GetRowCellValue(i, GV1.Columns(3).FieldName).ToString()
                due_date = GV1.GetRowCellValue(i, GV1.Columns(4).FieldName).ToString()
                ship_date = GV1.GetRowCellValue(i, GV1.Columns(5).FieldName).ToString()
                part_no = GV1.GetRowCellValue(i, GV1.Columns(6).FieldName).ToString()
                desing = GV1.GetRowCellValue(i, GV1.Columns(7).FieldName).ToString()
                qty = GV1.GetRowCellValue(i, GV1.Columns(8).FieldName).ToString()

                ' Agregar el valor a una lista para inserción posterior
                sql = String.Format(
                    " INSERT INTO ERP_CTRL_PULL_SYSTEM_ORDER_tmp VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                    order_no, cust_part, ship_to, created_date, due_date, ship_date, part_no, desing, qty, var_adm_Usr_NICK
                )
                Executa_Query(sql, var_conexionERP)

            Next


            sql = "SP_CTRL_GUARDA_DATOS_PULL_SYSTEM_ORDER'" & Trim(var_adm_Usr_NICK) & "'"
            Executa_Query(sql, var_conexionERP)
            sql = "SP_CTRL_PULL_SYSTEM_GENERA_DAILY_ORDER'" & Trim(var_adm_Usr_NICK) & "'"
            Executa_Query(sql, var_conexionERP)
            sql = "SP_CTRL_ENVIA_CORREOS_KANBAN_PULL_SYSTEM'" & Trim(var_adm_Usr_NICK) & "'"
            Executa_Query(sql, var_conexionERP)
            sql = "SP_CTRL_PULL_SYSTEM_ACTUALIZA_OVERAGE'" & Trim(var_adm_Usr_NICK) & "'"
            Executa_Query(sql, var_conexionERP)

            'DevExpress.XtraEditors.XtraMessageBox.Show("Datos registrados correctamente", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Information)


            checaDatos()
            GV1.Columns.Clear()
            GridControl1.DataSource = Nothing


            Cursor = Cursors.Default
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub erp_ctrl_cargar_archivo_pull_system_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            var_conexionERP = DesencriptaCadenaConexionERP(ConfigurationManager.ConnectionStrings("ERP_cnn").ConnectionString)
            var_conexionPOP = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("POP_cnn").ConnectionString)
            var_conexionPOP35 = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("POP35_cnn").ConnectionString) 'POP_SP_cnn
            var_conexionPOPSP = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("POP_SP_cnn").ConnectionString) 'POP_SP_cnn
            var_conexionMPS = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("MPS_cnn").ConnectionString)
            var_conexionSAPC = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("SAPC_cnn").ConnectionString)
            var_conexionCNC = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("CNC_cnn").ConnectionString)
            var_conexionWO = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("WO_cnn").ConnectionString)
            var_conexionICS = DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("ICS_cnn").ConnectionString)
            var_conexionCTRACE = DesencriptaCadenaConexionCTRACE(ConfigurationManager.ConnectionStrings("CTRACE_cnn").ConnectionString)
            var_conexionSAUERP = (DesencriptaCadenaConexionERPSAU(ConfigurationManager.ConnectionStrings("SAU_ERP_cnn").ConnectionString))
            var_conexionTRESS = (DesencriptaCadenaConexion(ConfigurationManager.ConnectionStrings("TRESS_cnn").ConnectionString))


            var_IP_mailserver = ConfigurationManager.AppSettings("IP_Mail_server")
            var_adm_Planta = ConfigurationManager.AppSettings("erp_plant")
            'System.Diagnostics.Process.Start("DateFormat.exe")
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "/"
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"

            var_adm_Usr_NICK = "RPAUser"
            '***************************************************************************************************************************
            '***************************************************************************************************************************
            checaDatos()

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub checaDatos()
        Try
            sql = "SELECT * FROM ERP_CTRL_PULL_SYSTEM_ORDER WHERE Issue_date = CONVERT(date, GETDATE(),101)"
            If Existe_Dato(sql, var_conexionERP) Then
                butCargarArchivo.Enabled = False
                butGuardar.Enabled = False
                labInfo.Visible = True
            Else
                labInfo.Visible = False
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GV1_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GV1.CustomDrawCell
        Dim valorCelda As Object = GV1.GetRowCellValue(e.RowHandle, e.Column.FieldName)

        ' Si el valor está en la lista de números no válidos, pintar la celda
        If listaNoValidos.Contains(valorCelda.ToString()) Then
            e.Appearance.BackColor = Color.Red
            e.Appearance.BackColor2 = Color.Red
            e.Appearance.ForeColor = Color.White
        End If
    End Sub
End Class

Imports Funciones
Imports AccesoDatos
Imports System.Configuration
Imports System.Threading
Imports System.Globalization

Imports QRCoder
Imports System.Drawing.Printing

Public Class Reinspeccion
    Dim sql As String
    Dim ds As DataSet
    Private qrImage As Bitmap


    Private Sub textNumReloj_KeyDown(sender As Object, e As KeyEventArgs) Handles textNumReloj.KeyDown
        textSerial.Text = ""
        labNumReloj.Text = ""
        limpiarCampos()

        If e.KeyCode = Keys.Enter Then
            Dim numReloj As String = textNumReloj.Text

            Dim sinLetra As String = numReloj.Replace("A", "")
            sinLetra = sinLetra.Replace("a", "")
            Dim numeroEntero As Integer = Integer.Parse(sinLetra)
            Dim resultadoFinal As String = numeroEntero.ToString()

            Try
                sql = "select PRETTYNAME from erp_aaids_colabora where cb_codigo = '" & resultadoFinal & "'"
                If Existe_Dato(sql, var_conexionERP) Then
                    labNumReloj.Text = Consulta_Dato(sql, var_conexionERP)
                    textSerial.Focus()
                    textNumReloj.Text = resultadoFinal
                Else
                    textNumReloj.Focus()
                    labNumReloj.Text = ""
                    DevExpress.XtraEditors.XtraMessageBox.Show("Numero de empleado no encontrado", "Reinspeccion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    textSerial.Text = ""
                End If
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Reinspeccion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Sub limpiarCampos()
        LabPartNo.Text = ""
        LabMaster.Text = ""
        LabPlanta.Text = ""
        LabQty.Text = ""
        textScaneo.Text = ""
        checkedCombo.Properties.DataSource = Nothing
        checkedCombo.Refresh()
        gc_arnes.DataSource = Nothing
        gv_arnes.Columns.Clear()

        gc_estatus.DataSource = Nothing
        gv_estatus.Columns.Clear()

    End Sub



    Private Sub Reinspeccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        var_conexionERP = DesencriptaCadenaConexionERP(ConfigurationManager.ConnectionStrings("ERP_cnn").ConnectionString)
        var_IP_mailserver = ConfigurationManager.AppSettings("IP_Mail_server")
        var_adm_Planta = ConfigurationManager.AppSettings("erp_plant")
        'System.Diagnostics.Process.Start("DateFormat.exe")
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "/"
        Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        checkImprimir.Checked = True



    End Sub

    Private Sub Reinspeccion_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        textNumReloj.Focus()
    End Sub


    Private Sub textSerial_KeyDown(sender As Object, e As KeyEventArgs) Handles textSerial.KeyDown
        checkedCombo.Properties.DataSource = Nothing
        checkedCombo.Refresh()
        limpiarCampos()
        labColor.Visible = False

        If labNumReloj.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show("El numero de reloj es incorrecto", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            If e.KeyCode = Keys.Enter Then
                checkedCombo.Properties.DataSource = Nothing
                checkedCombo.Refresh()
                sql = "select distinct d.SortRequest_Id from ERP_CTRL_WGPL_SORT_REQUEST_DT d" &
                    " join ERP_CTRL_WGPL_SORT_REQUEST r on r.SortRequest_Id = d.SortRequest_Id " &
                       " WHERE Serial_no = '" & textSerial.Text.Trim.Substring(1) & "' and statusRequest = '2' "
                ds = Consulta_Datos(sql, var_conexionERP)

                ' Configurar propiedades del combo
                checkedCombo.Properties.DisplayMember = "SortRequest_Id"
                checkedCombo.Properties.ValueMember = "SortRequest_Id"
                checkedCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
                checkedCombo.Properties.DataSource = ds.Tables(0)
                checkedCombo.Refresh()

                ' Esperar a que el combo esté completamente cargado
                Application.DoEvents()

                ' Marcar todos los ítems como seleccionados
                Dim seleccionados As New List(Of Object)
                For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In checkedCombo.Properties.Items
                    item.CheckState = CheckState.Checked
                    seleccionados.Add(item.Value)
                Next

                ' Reflejar la selección en el EditValue
                checkedCombo.SetEditValue(seleccionados)
                checkedCombo.CheckAll()



                sql = "SELECT TOP 1 d.SortRequest_Id, d.PRODUCT_NO, d.Serial_no, d.Qty, d.Master " &
                      "FROM ERP_CTRL_WGPL_SORT_REQUEST_DT d " &
                      "JOIN ERP_CTRL_WGPL_SORT_REQUEST r ON r.SortRequest_Id = d.SortRequest_Id " &
                      "WHERE d.Serial_no = '" & textSerial.Text.Trim.Substring(1) & "' and statusRequest IN( '2' ,'99')"
                ds = Consulta_Datos(sql, var_conexionERP)

                If ds IsNot Nothing And ds.Tables.Count > 0 And ds.Tables(0).Rows.Count > 0 Then
                    Dim fila As DataRow = ds.Tables(0).Rows(0)

                    LabPartNo.Text = fila("PRODUCT_NO").ToString()
                    LabMaster.Text = fila("Master").ToString()
                    LabPlanta.Text = fila("SortRequest_Id").ToString().Split("-")(0)
                    LabQty.Text = fila("Qty").ToString()
                    textScaneo.Focus()


                    cargarSortRequest()
                    cargarStatus()



                Else
                    DevExpress.XtraEditors.XtraMessageBox.Show("No se encontraron datos para el serial ingresado.", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Reinspección", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub cargarSortRequest()
        gv_arnes.Columns.Clear()
        gc_arnes.DataSource = Nothing

        sql = "SP_CTRL_WGPL_GET_STATUS_SORT_REQUEST_SERIAL '" & textSerial.Text.Trim.Substring(1) & "'"
        ds = Consulta_Datos(sql, var_conexionERP)

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            gc_arnes.DataSource = ds.Tables(0)
            gv_arnes.BestFitColumns()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("No se encontraron datos para el número de serie.", "Consulta vacía", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub cargarStatus()
        gc_estatus.DataSource = Nothing
        gv_estatus.Columns.Clear()

        sql = "SP_CTRL_WGPL_STATUS_INSPECCION_POR_SORT_REQUEST '" & textSerial.Text.Trim.Substring(1) & "'"
        ds = Consulta_Datos(sql, var_conexionERP)
        gc_estatus.DataSource = ds.Tables(0)
        gv_estatus.BestFitColumns()

        Dim progressBar As New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        progressBar.Minimum = 0
        progressBar.Maximum = 100
        progressBar.ShowTitle = True
        progressBar.PercentView = True
        progressBar.Step = 1
        progressBar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        gc_estatus.RepositoryItems.Add(progressBar)

        ' Asignar el RepositoryItem a la columna
        If gv_estatus.Columns("Porcentaje_Inspeccion") IsNot Nothing Then
            gv_estatus.Columns("Porcentaje_Inspeccion").ColumnEdit = progressBar
            gv_estatus.Columns("Porcentaje_Inspeccion").Caption = "Avance (%)"
            gv_estatus.Columns("Porcentaje_Inspeccion").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        End If

        ' Manejar el evento CustomDrawCell para cambiar color de la barra
        AddHandler gv_estatus.CustomDrawCell, Sub(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs)
                                                  If e.Column.FieldName = "Porcentaje_Inspeccion" Then
                                                      Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
                                                      Dim porcentaje As Integer = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, e.Column))

                                                      ' Dibujar barra de progreso con color dinámico
                                                      Dim bounds As Rectangle = e.Bounds
                                                      Dim barWidth As Integer = CInt(bounds.Width * porcentaje / 100)
                                                      Dim barColor As Color

                                                      If porcentaje < 50 Then
                                                          barColor = Color.Red
                                                      ElseIf porcentaje < 80 Then
                                                          barColor = Color.Gold
                                                      Else
                                                          barColor = Color.ForestGreen
                                                      End If

                                                      ' Fondo de celda
                                                      e.Graphics.FillRectangle(New SolidBrush(Color.White), bounds)

                                                      ' Barra de progreso
                                                      e.Graphics.FillRectangle(New SolidBrush(barColor), New Rectangle(bounds.X, bounds.Y + 2, barWidth, bounds.Height - 4))

                                                      ' Texto centrado
                                                      Dim text As String = porcentaje.ToString() & "%"
                                                      Dim textSize As SizeF = e.Graphics.MeasureString(text, e.Appearance.Font)
                                                      Dim textX As Integer = bounds.X + (bounds.Width - textSize.Width) / 2
                                                      Dim textY As Integer = bounds.Y + (bounds.Height - textSize.Height) / 2
                                                      e.Graphics.DrawString(text, e.Appearance.Font, Brushes.Black, New PointF(textX, textY))

                                                      e.Handled = True
                                                  End If
                                                  gc_estatus.Refresh()

                                              End Sub
    End Sub



    Private Sub textScaneo_KeyDown(sender As Object, e As KeyEventArgs) Handles textScaneo.KeyDown
        Try


            If e.KeyCode = Keys.Enter Then
                If gv_arnes.RowCount = 0 Then
                    Exit Sub
                End If

                If gv_arnes.RowCount = 0 And textScaneo.Text <> "" Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("No se ha cargado ninguna caja", "Reinspección", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ' Buscar si el valor existe en la columna Harness_Label
                Dim existe As Boolean = False
                For i As Integer = 0 To gv_arnes.RowCount - 1
                    Dim valorCelda As String = gv_arnes.GetRowCellValue(i, "Harness_Label").ToString().Trim()
                    If valorCelda.Replace(" ", "").ToUpper() = textScaneo.Text.Replace(" ", "").Trim().ToUpper() Then
                        existe = True
                        Exit For
                    End If

                Next
                Dim seleccionados = checkedCombo.Properties.GetCheckedItems()
                If seleccionados.ToString = "" Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("Seleccione el Sort Request con el que se va a trabajar", "Reinspección", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    textScaneo.Text = ""
                    Exit Sub
                End If


                If textScaneo.Text.ToUpper = "DEFECTO" Then
                    checkDefecto.Checked = True
                    textScaneo.Text = ""
                End If



                If Not existe Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("Este arnés no pertenece a esta caja", "Reinspección", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    textScaneo.Text = ""
                    Exit Sub
                End If

                Dim ids As String = checkedCombo.Properties.GetCheckedItems().ToString()



                If seleccionados.ToString.Split(",").Count > 1 And checkDefecto.Checked Then
                    Dim frm As New frmRechazoRequest()
                    frm.serialArnes = textScaneo.Text.Trim
                    frm.sortRequestIds = ids

                    If frm.ShowDialog() = DialogResult.OK Then
                        ' Marcar defectuosos
                        For Each id In frm.SortsDefectuosos
                            sql = "SP_CTRL_WGPL_UPDATE_STATUS_HARNESS '" & id & "', '" & textScaneo.Text & "' , '" & textNumReloj.Text.Trim & "', '-1'"
                            Executa_Query(sql, var_conexionERP)
                        Next

                        ' Marcar correctos
                        For Each id In frm.SortsCorrectos
                            sql = "SP_CTRL_WGPL_UPDATE_STATUS_HARNESS '" & id & "', '" & textScaneo.Text & "' , '" & textNumReloj.Text.Trim & "', '1'"
                            Executa_Query(sql, var_conexionERP)
                        Next

                        cargarSortRequest()
                        cargarStatus()
                        checkDefecto.Checked = False
                        textScaneo.Text = ""
                        sql = "SP_CTRL_WGPL_SORT_REQUEST_PENDIENTES_CAJA '" & textSerial.Text.Trim.Substring(1) & "'"
                        If Existe_Dato(sql, var_conexionERP) Then
                            Exit Sub

                        Else
                            checkedCombo.Properties.DataSource = Nothing
                            checkedCombo.Refresh()
                            limpiarCampos()
                            If checkImprimir.Checked Then
                                imprimeEtiqueta(textSerial.Text.Trim)
                            End If

                            textSerial.Focus()
                            textSerial.Text = ""
                            labColor.Visible = True
                        End If

                    Else
                        DevExpress.XtraEditors.XtraMessageBox.Show("No seleccionaste ningun Sort Request", "Reinspeccion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If


                Dim defecto As Integer = If(checkDefecto.Checked, -1, 1)
                sql = "select * from ERP_CTRL_WGPL_SORT_REQUEST_HARNESS where status in ('1') and  SortRequest_Id IN (" & String.Join(",", ids.Split(","c).Select(Function(s) "'" & s.Trim() & "'")) & ") and (Harness_label ='" & textScaneo.Text.Trim & "' or Harness_label_QR ='" & textScaneo.Text.Trim & "' )"
                If Existe_Dato(sql, var_conexionERP) Then
                    DevExpress.XtraEditors.XtraMessageBox.Show("Este arnes ya fue reinspeccionado", "Reinspección", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                sql = "SP_CTRL_WGPL_UPDATE_STATUS_HARNESS '" & ids & "', '" & textScaneo.Text & "' , '" & textNumReloj.Text.Trim & "','" & defecto.ToString & "'"
                Executa_Query(sql, var_conexionERP)
                cargarSortRequest()
                cargarStatus()
                checkDefecto.Checked = False
                textScaneo.Text = ""

                sql = "SP_CTRL_WGPL_SORT_REQUEST_PENDIENTES_CAJA '" & textSerial.Text.Trim.Substring(1) & "'"
                If Existe_Dato(sql, var_conexionERP) Then
                    Exit Sub

                Else
                    checkedCombo.Properties.DataSource = Nothing
                    checkedCombo.Refresh()
                    limpiarCampos()
                    If checkImprimir.Checked Then
                        imprimeEtiqueta(textSerial.Text.Trim)
                    End If
                    textScaneo.Text = ""
                    textSerial.Focus()
                    textSerial.Text = ""
                    labColor.Visible = True

                End If
            End If


        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Reinspeccion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub gv_arnes_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gv_arnes.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim cellValue As Object = view.GetRowCellValue(e.RowHandle, e.Column)
        If cellValue IsNot Nothing Then
            Dim statusValue As String = cellValue.ToString().Trim()

            Select Case statusValue
                Case "Pendiente"
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 204) ' Amarillo pastel
                    e.Appearance.BackColor2 = Color.FromArgb(255, 255, 204)
                Case "Aprobado"
                    e.Appearance.BackColor = Color.FromArgb(204, 255, 204) ' Verde pastel
                    e.Appearance.BackColor2 = Color.FromArgb(204, 255, 204)
                Case "Rechazado"
                    e.Appearance.BackColor = Color.FromArgb(255, 204, 204) ' Rojo pastel
                    e.Appearance.BackColor2 = Color.FromArgb(255, 204, 204)
            End Select
        End If
    End Sub


    Private Sub checkedCombo_EditValueChanged(sender As Object, e As EventArgs) Handles checkedCombo.EditValueChanged
        Try
            '  Dim ids As String = checkedCombo.Properties.GetCheckedItems().ToString()
            ' gc_arnes.DataSource = Nothing
            ' gv_arnes.Columns.Clear()

            '  If ids = "" Then
            'Return
            '  End If

            ' sql = "SELECT Quality_Issue + '/' FROM ERP_CTRL_WGPL_SORT_REQUEST WHERE SortRequest_Id IN (" & String.Join(",", ids.Split(","c).Select(Function(s) "'" & s.Trim() & "'")) & ")"
            'LabDefecto.Text = Consulta_Dato(sql, var_conexionERP)
            'cargarDatos()



        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Reinspeccion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Private Sub checkDefecto_CheckedChanged(sender As Object, e As EventArgs) Handles checkDefecto.CheckedChanged
        textScaneo.Focus()

    End Sub

    Private Sub textScaneo_Leave(sender As Object, e As EventArgs) Handles textScaneo.Leave
        textScaneo.Text = ""
    End Sub


    Dim textoAImprimir As String = ""
    Private Sub imprimeEtiqueta(ByRef caja As String)
        Try
            textoAImprimir = ""
            sql = "SP_CTRL_WGPL_GENERA_DATOS_QR '" & textSerial.Text.Trim.Substring(1) & "'"
            textoAImprimir = Consulta_Dato(sql, var_conexionERP)

            ' Tamaño real de etiqueta: 3cm x 2cm ≈ 113 x 76 puntos
            Dim etiquetaSize As New PaperSize("Etiqueta3x2cm", 113, 76)
            imprimirQR.DefaultPageSettings.PaperSize = etiquetaSize
            imprimirQR.DefaultPageSettings.Landscape = False


            imprimirQR.Print()


        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show("Error al generar o imprimir QR: " & ex.Message, "Reinspección", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub imprimirQR_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles imprimirQR.PrintPage
        Try
            Dim qrText As String = textoAImprimir

            ' Generar el QR
            Dim qrGenerator As New QRCodeGenerator()
            Dim qrData As QRCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As New QRCode(qrData)
            Dim qrImage As Bitmap = qrCode.GetGraphic(4)

            ' Fuente y pincel
            Dim fontSmall As New Font("Arial", 4.5F, FontStyle.Regular)
            Dim brush As New SolidBrush(Color.Black)
            Dim format As New StringFormat With {.Alignment = StringAlignment.Center}

            ' Posicionamiento dentro de etiqueta 3x2 cm (113x76 puntos)
            Dim qrWidth As Integer = 50
            Dim qrHeight As Integer = 50
            Dim qrX As Integer = (e.PageBounds.Width - qrWidth) \ 2
            Dim qrY As Integer = 0 ' subido desde 5 a 0

            ' Dibujar QR
            e.Graphics.DrawImage(qrImage, qrX, qrY, qrWidth, qrHeight)

            ' Texto debajo del QR (más arriba)
            Dim textoEtiqueta As String = "Serial: " & textSerial.Text.Trim.ToUpper
            Dim textoY As Integer = qrY + qrHeight - 2 ' subido desde +2 a -2
            e.Graphics.DrawString(textoEtiqueta, fontSmall, brush, qrX + qrWidth / 2, textoY, format)

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show("Error al imprimir QR: " & ex.Message, "Reinspección", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            sql = "SP_CTRL_WGPL_SORT_REQUEST_PENDIENTES_CAJA '" & textSerial.Text.Trim.Substring(1) & "'"
            If Existe_Dato(sql, var_conexionERP) Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Esta Caja Tiene Sort Request Pendientes", "Reinspeccion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            Else
                imprimeEtiqueta(textSerial.Text.Trim)
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show("Error al generar o imprimir QR: " & ex.Message, "Reinspeccion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            gc_datosRequest.DataSource = Nothing
            gv_datosRequest.Columns.Clear()

            sql = "SP_CTRL_WGPL_CONSULTA_DATOS_SORT_REQUEST"
            ds = Consulta_Datos(sql, var_conexionERP)

            gc_datosRequest.DataSource = ds.Tables(0)
            gv_datosRequest.BestFitColumns()


        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Reinspeccion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub gv_datosRequest_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gv_datosRequest.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.Column.FieldName = "Estado_Arnes" OrElse e.Column.FieldName = "Estado_Solicitud" Then
            Dim cellValue = view.GetRowCellValue(e.RowHandle, e.Column)

            If cellValue IsNot Nothing Then
                Select Case cellValue.ToString().Trim()
                    Case "Pendiente"
                        e.Appearance.BackColor = Color.FromArgb(255, 255, 204) ' Amarillo pastel
                        e.Appearance.BackColor2 = Color.FromArgb(255, 255, 204)
                    Case "Aprobado"
                        e.Appearance.BackColor = Color.FromArgb(204, 255, 204) ' Verde pastel
                        e.Appearance.BackColor2 = Color.FromArgb(204, 255, 204)
                    Case "Rechazado"
                        e.Appearance.BackColor = Color.FromArgb(255, 204, 204) ' Rojo pastel
                        e.Appearance.BackColor2 = Color.FromArgb(255, 204, 204)
                End Select
            End If
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        gv_datosRequest.ExportToXlsx(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\reporteSortRequest.xlsx")
        System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Personal) & "\reporteSortRequest.xlsx")
    End Sub
End Class
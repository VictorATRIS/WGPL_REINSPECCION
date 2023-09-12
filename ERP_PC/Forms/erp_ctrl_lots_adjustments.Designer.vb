<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_lots_adjustments
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.mm_descr = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.dt_fecha = New DevExpress.XtraEditors.DateEdit()
        Me.up_cliente = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.te_kmh = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.te_smh = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.te_dif = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.te_doh = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.plan_nuevo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl50 = New DevExpress.XtraEditors.LabelControl()
        Me.te_actual = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl54 = New DevExpress.XtraEditors.LabelControl()
        Me.up_sews_parte = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.up_Plantas = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl33 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox1.SuspendLayout()
        CType(Me.mm_descr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_fecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_fecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.up_cliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_kmh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_smh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_dif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_doh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.plan_nuevo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_actual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.up_sews_parte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.up_Plantas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_guardar
        '
        Me.btn_guardar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.btn_guardar.Appearance.Options.UseFont = True
        Me.btn_guardar.Location = New System.Drawing.Point(304, 612)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(156, 38)
        Me.btn_guardar.TabIndex = 202
        Me.btn_guardar.Text = "Guardar Registro"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.mm_descr)
        Me.GroupBox1.Controls.Add(Me.LabelControl9)
        Me.GroupBox1.Controls.Add(Me.dt_fecha)
        Me.GroupBox1.Controls.Add(Me.up_cliente)
        Me.GroupBox1.Controls.Add(Me.LabelControl8)
        Me.GroupBox1.Controls.Add(Me.LabelControl7)
        Me.GroupBox1.Controls.Add(Me.te_kmh)
        Me.GroupBox1.Controls.Add(Me.LabelControl6)
        Me.GroupBox1.Controls.Add(Me.te_smh)
        Me.GroupBox1.Controls.Add(Me.LabelControl4)
        Me.GroupBox1.Controls.Add(Me.te_dif)
        Me.GroupBox1.Controls.Add(Me.LabelControl3)
        Me.GroupBox1.Controls.Add(Me.te_doh)
        Me.GroupBox1.Controls.Add(Me.LabelControl2)
        Me.GroupBox1.Controls.Add(Me.plan_nuevo)
        Me.GroupBox1.Controls.Add(Me.LabelControl50)
        Me.GroupBox1.Controls.Add(Me.te_actual)
        Me.GroupBox1.Controls.Add(Me.LabelControl54)
        Me.GroupBox1.Controls.Add(Me.up_sews_parte)
        Me.GroupBox1.Controls.Add(Me.LabelControl1)
        Me.GroupBox1.Controls.Add(Me.up_Plantas)
        Me.GroupBox1.Controls.Add(Me.LabelControl33)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(716, 529)
        Me.GroupBox1.TabIndex = 201
        Me.GroupBox1.TabStop = False
        '
        'mm_descr
        '
        Me.mm_descr.Location = New System.Drawing.Point(313, 442)
        Me.mm_descr.Name = "mm_descr"
        Me.mm_descr.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.mm_descr.Properties.Appearance.Options.UseFont = True
        Me.mm_descr.Size = New System.Drawing.Size(254, 51)
        Me.mm_descr.TabIndex = 230
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl9.Location = New System.Drawing.Point(152, 444)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(126, 22)
        Me.LabelControl9.TabIndex = 228
        Me.LabelControl9.Text = "Comentarios :"
        '
        'dt_fecha
        '
        Me.dt_fecha.EditValue = Nothing
        Me.dt_fecha.Location = New System.Drawing.Point(226, 141)
        Me.dt_fecha.Name = "dt_fecha"
        Me.dt_fecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.dt_fecha.Properties.Appearance.Options.UseFont = True
        Me.dt_fecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_fecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dt_fecha.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.dt_fecha.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.dt_fecha.Size = New System.Drawing.Size(125, 28)
        Me.dt_fecha.TabIndex = 226
        Me.dt_fecha.Visible = False
        '
        'up_cliente
        '
        Me.up_cliente.Location = New System.Drawing.Point(529, 89)
        Me.up_cliente.Name = "up_cliente"
        Me.up_cliente.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.up_cliente.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.up_cliente.Properties.Appearance.Options.UseBackColor = True
        Me.up_cliente.Properties.Appearance.Options.UseFont = True
        Me.up_cliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.up_cliente.Properties.NullText = ""
        Me.up_cliente.Size = New System.Drawing.Size(125, 28)
        Me.up_cliente.TabIndex = 225
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl8.Location = New System.Drawing.Point(404, 92)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(80, 22)
        Me.LabelControl8.TabIndex = 224
        Me.LabelControl8.Text = "Cliente  :"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl7.Location = New System.Drawing.Point(207, 402)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(55, 22)
        Me.LabelControl7.TabIndex = 223
        Me.LabelControl7.Text = "KMH :"
        '
        'te_kmh
        '
        Me.te_kmh.Enabled = False
        Me.te_kmh.Location = New System.Drawing.Point(313, 396)
        Me.te_kmh.Name = "te_kmh"
        Me.te_kmh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.te_kmh.Properties.Appearance.Options.UseFont = True
        Me.te_kmh.Properties.Appearance.Options.UseTextOptions = True
        Me.te_kmh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_kmh.Properties.Mask.EditMask = "d"
        Me.te_kmh.Size = New System.Drawing.Size(119, 28)
        Me.te_kmh.TabIndex = 222
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Location = New System.Drawing.Point(208, 351)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(53, 22)
        Me.LabelControl6.TabIndex = 221
        Me.LabelControl6.Text = "SMH :"
        '
        'te_smh
        '
        Me.te_smh.Enabled = False
        Me.te_smh.Location = New System.Drawing.Point(313, 345)
        Me.te_smh.Name = "te_smh"
        Me.te_smh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.te_smh.Properties.Appearance.Options.UseFont = True
        Me.te_smh.Properties.Appearance.Options.UseTextOptions = True
        Me.te_smh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_smh.Properties.Mask.EditMask = "d"
        Me.te_smh.Size = New System.Drawing.Size(119, 28)
        Me.te_smh.TabIndex = 220
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Location = New System.Drawing.Point(169, 303)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(111, 22)
        Me.LabelControl4.TabIndex = 219
        Me.LabelControl4.Text = "Diferencia  :"
        '
        'te_dif
        '
        Me.te_dif.EditValue = ""
        Me.te_dif.Enabled = False
        Me.te_dif.Location = New System.Drawing.Point(313, 299)
        Me.te_dif.Name = "te_dif"
        Me.te_dif.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.te_dif.Properties.Appearance.Options.UseFont = True
        Me.te_dif.Properties.Appearance.Options.UseTextOptions = True
        Me.te_dif.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_dif.Properties.Mask.EditMask = "d"
        Me.te_dif.Size = New System.Drawing.Size(119, 26)
        Me.te_dif.TabIndex = 218
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Location = New System.Drawing.Point(164, 254)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(113, 22)
        Me.LabelControl3.TabIndex = 217
        Me.LabelControl3.Text = "DOH Linea  :"
        '
        'te_doh
        '
        Me.te_doh.Location = New System.Drawing.Point(313, 251)
        Me.te_doh.Name = "te_doh"
        Me.te_doh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.te_doh.Properties.Appearance.Options.UseFont = True
        Me.te_doh.Properties.Appearance.Options.UseTextOptions = True
        Me.te_doh.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_doh.Properties.Mask.EditMask = "d"
        Me.te_doh.Size = New System.Drawing.Size(119, 26)
        Me.te_doh.TabIndex = 216
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Location = New System.Drawing.Point(158, 202)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(120, 22)
        Me.LabelControl2.TabIndex = 215
        Me.LabelControl2.Text = "Plan Nuevo  :"
        '
        'plan_nuevo
        '
        Me.plan_nuevo.EditValue = ""
        Me.plan_nuevo.Location = New System.Drawing.Point(313, 198)
        Me.plan_nuevo.Name = "plan_nuevo"
        Me.plan_nuevo.Properties.Appearance.BackColor = System.Drawing.Color.LightSteelBlue
        Me.plan_nuevo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plan_nuevo.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.plan_nuevo.Properties.Appearance.Options.UseBackColor = True
        Me.plan_nuevo.Properties.Appearance.Options.UseFont = True
        Me.plan_nuevo.Properties.Appearance.Options.UseForeColor = True
        Me.plan_nuevo.Properties.Appearance.Options.UseTextOptions = True
        Me.plan_nuevo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.plan_nuevo.Properties.Mask.EditMask = "d"
        Me.plan_nuevo.Size = New System.Drawing.Size(119, 26)
        Me.plan_nuevo.TabIndex = 214
        '
        'LabelControl50
        '
        Me.LabelControl50.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl50.Location = New System.Drawing.Point(365, 143)
        Me.LabelControl50.Name = "LabelControl50"
        Me.LabelControl50.Size = New System.Drawing.Size(119, 22)
        Me.LabelControl50.TabIndex = 213
        Me.LabelControl50.Text = "Plan Actual  :"
        '
        'te_actual
        '
        Me.te_actual.Enabled = False
        Me.te_actual.Location = New System.Drawing.Point(529, 141)
        Me.te_actual.Name = "te_actual"
        Me.te_actual.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.te_actual.Properties.Appearance.Options.UseFont = True
        Me.te_actual.Properties.Appearance.Options.UseTextOptions = True
        Me.te_actual.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_actual.Properties.Mask.EditMask = "d"
        Me.te_actual.Size = New System.Drawing.Size(125, 28)
        Me.te_actual.TabIndex = 212
        '
        'LabelControl54
        '
        Me.LabelControl54.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl54.Location = New System.Drawing.Point(6, 143)
        Me.LabelControl54.Name = "LabelControl54"
        Me.LabelControl54.Size = New System.Drawing.Size(205, 22)
        Me.LabelControl54.TabIndex = 210
        Me.LabelControl54.Text = "Fecha de Produccion  :"
        Me.LabelControl54.Visible = False
        '
        'up_sews_parte
        '
        Me.up_sews_parte.Location = New System.Drawing.Point(226, 85)
        Me.up_sews_parte.Name = "up_sews_parte"
        Me.up_sews_parte.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.up_sews_parte.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.up_sews_parte.Properties.Appearance.Options.UseBackColor = True
        Me.up_sews_parte.Properties.Appearance.Options.UseFont = True
        Me.up_sews_parte.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.up_sews_parte.Properties.NullText = ""
        Me.up_sews_parte.Size = New System.Drawing.Size(125, 28)
        Me.up_sews_parte.TabIndex = 209
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Location = New System.Drawing.Point(82, 91)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(129, 22)
        Me.LabelControl1.TabIndex = 208
        Me.LabelControl1.Text = "No. de Parte  :"
        '
        'up_Plantas
        '
        Me.up_Plantas.Location = New System.Drawing.Point(298, 29)
        Me.up_Plantas.Name = "up_Plantas"
        Me.up_Plantas.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.up_Plantas.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.up_Plantas.Properties.Appearance.Options.UseBackColor = True
        Me.up_Plantas.Properties.Appearance.Options.UseFont = True
        Me.up_Plantas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.up_Plantas.Properties.NullText = ""
        Me.up_Plantas.Size = New System.Drawing.Size(125, 28)
        Me.up_Plantas.TabIndex = 207
        '
        'LabelControl33
        '
        Me.LabelControl33.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl33.Location = New System.Drawing.Point(208, 32)
        Me.LabelControl33.Name = "LabelControl33"
        Me.LabelControl33.Size = New System.Drawing.Size(70, 22)
        Me.LabelControl33.TabIndex = 206
        Me.LabelControl33.Text = "Planta :"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl5.Location = New System.Drawing.Point(268, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(244, 22)
        Me.LabelControl5.TabIndex = 200
        Me.LabelControl5.Text = "Ajustes Manuales de Lotes "
        '
        'erp_ctrl_lots_adjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 662)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LabelControl5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "erp_ctrl_lots_adjustments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "erp_ctrl_lots_adjustments"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.mm_descr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_fecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_fecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.up_cliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_kmh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_smh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_dif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_doh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.plan_nuevo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_actual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.up_sews_parte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.up_Plantas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mm_descr As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dt_fecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents up_cliente As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_kmh As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_smh As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_dif As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_doh As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents plan_nuevo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl50 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_actual As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl54 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents up_sews_parte As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents up_Plantas As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl33 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_registro_incrementos
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gc_registros = New DevExpress.XtraGrid.GridControl()
        Me.gv_registros = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.te_newformation = New DevExpress.XtraEditors.TextEdit()
        Me.btn_guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl33 = New DevExpress.XtraEditors.LabelControl()
        Me.up_Plantas = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.te_currentline = New DevExpress.XtraEditors.TextEdit()
        Me.up_linea = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.te_newcap = New DevExpress.XtraEditors.TextEdit()
        Me.te_evento = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl54 = New DevExpress.XtraEditors.LabelControl()
        Me.te_currentcap = New DevExpress.XtraEditors.TextEdit()
        Me.dt_fecha = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.up_turno = New DevExpress.XtraEditors.LookUpEdit()
        Me.up_tipo = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gc_registros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_registros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.te_newformation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.up_Plantas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_currentline.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.up_linea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_newcap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_evento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_currentcap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_fecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_fecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.up_turno.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.up_tipo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gc_registros)
        Me.GroupBox2.Location = New System.Drawing.Point(974, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(601, 464)
        Me.GroupBox2.TabIndex = 249
        Me.GroupBox2.TabStop = False
        '
        'gc_registros
        '
        Me.gc_registros.Location = New System.Drawing.Point(6, 57)
        Me.gc_registros.MainView = Me.gv_registros
        Me.gc_registros.Name = "gc_registros"
        Me.gc_registros.Size = New System.Drawing.Size(589, 254)
        Me.gc_registros.TabIndex = 120
        Me.gc_registros.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_registros, Me.GridView1})
        '
        'gv_registros
        '
        Me.gv_registros.DetailHeight = 450
        Me.gv_registros.GridControl = Me.gc_registros
        Me.gv_registros.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gv_registros.Name = "gv_registros"
        Me.gv_registros.OptionsBehavior.Editable = False
        Me.gv_registros.OptionsView.ColumnAutoWidth = False
        Me.gv_registros.OptionsView.RowAutoHeight = True
        Me.gv_registros.OptionsView.ShowGroupPanel = False
        Me.gv_registros.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gc_registros
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.te_newformation)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.LabelControl33)
        Me.GroupBox1.Controls.Add(Me.up_Plantas)
        Me.GroupBox1.Controls.Add(Me.LabelControl6)
        Me.GroupBox1.Controls.Add(Me.LabelControl1)
        Me.GroupBox1.Controls.Add(Me.te_currentline)
        Me.GroupBox1.Controls.Add(Me.up_linea)
        Me.GroupBox1.Controls.Add(Me.LabelControl7)
        Me.GroupBox1.Controls.Add(Me.LabelControl2)
        Me.GroupBox1.Controls.Add(Me.te_newcap)
        Me.GroupBox1.Controls.Add(Me.te_evento)
        Me.GroupBox1.Controls.Add(Me.LabelControl5)
        Me.GroupBox1.Controls.Add(Me.LabelControl54)
        Me.GroupBox1.Controls.Add(Me.te_currentcap)
        Me.GroupBox1.Controls.Add(Me.dt_fecha)
        Me.GroupBox1.Controls.Add(Me.LabelControl4)
        Me.GroupBox1.Controls.Add(Me.LabelControl10)
        Me.GroupBox1.Controls.Add(Me.up_turno)
        Me.GroupBox1.Controls.Add(Me.up_tipo)
        Me.GroupBox1.Controls.Add(Me.LabelControl3)
        Me.GroupBox1.Location = New System.Drawing.Point(231, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(737, 464)
        Me.GroupBox1.TabIndex = 248
        Me.GroupBox1.TabStop = False
        '
        'te_newformation
        '
        Me.te_newformation.Location = New System.Drawing.Point(583, 264)
        Me.te_newformation.Name = "te_newformation"
        Me.te_newformation.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.te_newformation.Properties.Appearance.Options.UseFont = True
        Me.te_newformation.Properties.Appearance.Options.UseTextOptions = True
        Me.te_newformation.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_newformation.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.te_newformation.Properties.Mask.EditMask = "d"
        Me.te_newformation.Size = New System.Drawing.Size(125, 28)
        Me.te_newformation.TabIndex = 244
        '
        'btn_guardar
        '
        Me.btn_guardar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.btn_guardar.Appearance.Options.UseFont = True
        Me.btn_guardar.Image = Global.ERP_PC.My.Resources.Resources.icons8_guardar_30
        Me.btn_guardar.Location = New System.Drawing.Point(275, 382)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(201, 38)
        Me.btn_guardar.TabIndex = 245
        Me.btn_guardar.Text = "Guardar Registro"
        '
        'LabelControl33
        '
        Me.LabelControl33.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl33.Location = New System.Drawing.Point(200, 30)
        Me.LabelControl33.Name = "LabelControl33"
        Me.LabelControl33.Size = New System.Drawing.Size(70, 22)
        Me.LabelControl33.TabIndex = 208
        Me.LabelControl33.Text = "Planta :"
        '
        'up_Plantas
        '
        Me.up_Plantas.Location = New System.Drawing.Point(275, 29)
        Me.up_Plantas.Name = "up_Plantas"
        Me.up_Plantas.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.up_Plantas.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.up_Plantas.Properties.Appearance.Options.UseBackColor = True
        Me.up_Plantas.Properties.Appearance.Options.UseFont = True
        Me.up_Plantas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.up_Plantas.Properties.NullText = ""
        Me.up_Plantas.Size = New System.Drawing.Size(125, 28)
        Me.up_Plantas.TabIndex = 209
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Location = New System.Drawing.Point(393, 270)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(155, 22)
        Me.LabelControl6.TabIndex = 243
        Me.LabelControl6.Text = "New Formation  :"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Location = New System.Drawing.Point(109, 77)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 22)
        Me.LabelControl1.TabIndex = 210
        Me.LabelControl1.Text = "Linea :"
        '
        'te_currentline
        '
        Me.te_currentline.Location = New System.Drawing.Point(262, 270)
        Me.te_currentline.Name = "te_currentline"
        Me.te_currentline.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.te_currentline.Properties.Appearance.Options.UseFont = True
        Me.te_currentline.Properties.Appearance.Options.UseTextOptions = True
        Me.te_currentline.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_currentline.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.te_currentline.Properties.Mask.EditMask = "d"
        Me.te_currentline.Size = New System.Drawing.Size(125, 28)
        Me.te_currentline.TabIndex = 242
        '
        'up_linea
        '
        Me.up_linea.Location = New System.Drawing.Point(174, 74)
        Me.up_linea.Name = "up_linea"
        Me.up_linea.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.up_linea.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.up_linea.Properties.Appearance.Options.UseBackColor = True
        Me.up_linea.Properties.Appearance.Options.UseFont = True
        Me.up_linea.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.up_linea.Properties.NullText = ""
        Me.up_linea.Size = New System.Drawing.Size(338, 28)
        Me.up_linea.TabIndex = 211
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl7.Location = New System.Drawing.Point(6, 272)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(227, 22)
        Me.LabelControl7.TabIndex = 241
        Me.LabelControl7.Text = "Current Line Formation  :"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Location = New System.Drawing.Point(14, 170)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(74, 22)
        Me.LabelControl2.TabIndex = 212
        Me.LabelControl2.Text = "Evento :"
        '
        'te_newcap
        '
        Me.te_newcap.Location = New System.Drawing.Point(583, 219)
        Me.te_newcap.Name = "te_newcap"
        Me.te_newcap.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.te_newcap.Properties.Appearance.Options.UseFont = True
        Me.te_newcap.Properties.Appearance.Options.UseTextOptions = True
        Me.te_newcap.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_newcap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.te_newcap.Properties.Mask.EditMask = "d"
        Me.te_newcap.Size = New System.Drawing.Size(125, 28)
        Me.te_newcap.TabIndex = 240
        '
        'te_evento
        '
        Me.te_evento.Location = New System.Drawing.Point(109, 164)
        Me.te_evento.Name = "te_evento"
        Me.te_evento.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.te_evento.Properties.Appearance.Options.UseFont = True
        Me.te_evento.Properties.Appearance.Options.UseTextOptions = True
        Me.te_evento.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_evento.Properties.Mask.EditMask = "d"
        Me.te_evento.Size = New System.Drawing.Size(229, 28)
        Me.te_evento.TabIndex = 213
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl5.Location = New System.Drawing.Point(413, 225)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(135, 22)
        Me.LabelControl5.TabIndex = 239
        Me.LabelControl5.Text = "New Capacity :"
        '
        'LabelControl54
        '
        Me.LabelControl54.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl54.Location = New System.Drawing.Point(400, 177)
        Me.LabelControl54.Name = "LabelControl54"
        Me.LabelControl54.Size = New System.Drawing.Size(148, 22)
        Me.LabelControl54.TabIndex = 227
        Me.LabelControl54.Text = "Fecha Efectiva  :"
        '
        'te_currentcap
        '
        Me.te_currentcap.Location = New System.Drawing.Point(194, 218)
        Me.te_currentcap.Name = "te_currentcap"
        Me.te_currentcap.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, System.Drawing.FontStyle.Bold)
        Me.te_currentcap.Properties.Appearance.Options.UseFont = True
        Me.te_currentcap.Properties.Appearance.Options.UseTextOptions = True
        Me.te_currentcap.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.te_currentcap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.te_currentcap.Properties.Mask.EditMask = "d"
        Me.te_currentcap.Size = New System.Drawing.Size(125, 28)
        Me.te_currentcap.TabIndex = 238
        '
        'dt_fecha
        '
        Me.dt_fecha.EditValue = Nothing
        Me.dt_fecha.Location = New System.Drawing.Point(583, 171)
        Me.dt_fecha.Name = "dt_fecha"
        Me.dt_fecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.dt_fecha.Properties.Appearance.Options.UseFont = True
        Me.dt_fecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt_fecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dt_fecha.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.dt_fecha.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.dt_fecha.Size = New System.Drawing.Size(125, 28)
        Me.dt_fecha.TabIndex = 228
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Location = New System.Drawing.Point(14, 221)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(164, 22)
        Me.LabelControl4.TabIndex = 237
        Me.LabelControl4.Text = "Current Capacity :"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl10.Location = New System.Drawing.Point(109, 121)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(57, 22)
        Me.LabelControl10.TabIndex = 233
        Me.LabelControl10.Text = "Flujo :"
        '
        'up_turno
        '
        Me.up_turno.Location = New System.Drawing.Point(423, 118)
        Me.up_turno.Name = "up_turno"
        Me.up_turno.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.up_turno.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.up_turno.Properties.Appearance.Options.UseBackColor = True
        Me.up_turno.Properties.Appearance.Options.UseFont = True
        Me.up_turno.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.up_turno.Properties.NullText = ""
        Me.up_turno.Size = New System.Drawing.Size(125, 28)
        Me.up_turno.TabIndex = 236
        '
        'up_tipo
        '
        Me.up_tipo.Location = New System.Drawing.Point(174, 120)
        Me.up_tipo.Name = "up_tipo"
        Me.up_tipo.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.up_tipo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.up_tipo.Properties.Appearance.Options.UseBackColor = True
        Me.up_tipo.Properties.Appearance.Options.UseFont = True
        Me.up_tipo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.up_tipo.Properties.NullText = ""
        Me.up_tipo.Size = New System.Drawing.Size(125, 28)
        Me.up_tipo.TabIndex = 234
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Location = New System.Drawing.Point(351, 122)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(66, 22)
        Me.LabelControl3.TabIndex = 235
        Me.LabelControl3.Text = "Turno :"
        '
        'erp_ctrl_registro_incrementos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1813, 506)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "erp_ctrl_registro_incrementos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "erp_ctrl_registro_incrementos"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gc_registros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_registros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.te_newformation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.up_Plantas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_currentline.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.up_linea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_newcap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_evento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_currentcap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_fecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_fecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.up_turno.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.up_tipo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gc_registros As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_registros As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents te_newformation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btn_guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl33 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents up_Plantas As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_currentline As DevExpress.XtraEditors.TextEdit
    Friend WithEvents up_linea As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_newcap As DevExpress.XtraEditors.TextEdit
    Friend WithEvents te_evento As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl54 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_currentcap As DevExpress.XtraEditors.TextEdit
    Friend WithEvents dt_fecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents up_turno As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents up_tipo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_reporte_checadas
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Date_inicio = New DevExpress.XtraEditors.DateEdit()
        Me.butBuscar = New DevExpress.XtraEditors.SimpleButton()
        Me.Date_fin = New DevExpress.XtraEditors.DateEdit()
        Me.gc_actuales = New DevExpress.XtraGrid.GridControl()
        Me.gv_actuales = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.Date_inicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date_inicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date_fin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Date_fin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_actuales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_actuales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.gc_actuales)
        Me.GroupControl1.Controls.Add(Me.CheckBox1)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.Date_inicio)
        Me.GroupControl1.Controls.Add(Me.butBuscar)
        Me.GroupControl1.Controls.Add(Me.Date_fin)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1197, 563)
        Me.GroupControl1.TabIndex = 4
        Me.GroupControl1.Text = "Reporte de Checadas"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(494, 44)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(105, 17)
        Me.CheckBox1.TabIndex = 276
        Me.CheckBox1.Text = "Incluye Entradas"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Location = New System.Drawing.Point(207, 44)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(38, 17)
        Me.LabelControl4.TabIndex = 275
        Me.LabelControl4.Text = "F. fin:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Location = New System.Drawing.Point(11, 44)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(76, 17)
        Me.LabelControl3.TabIndex = 274
        Me.LabelControl3.Text = "F. de inicio:"
        '
        'Date_inicio
        '
        Me.Date_inicio.EditValue = Nothing
        Me.Date_inicio.Location = New System.Drawing.Point(91, 44)
        Me.Date_inicio.Margin = New System.Windows.Forms.Padding(2)
        Me.Date_inicio.Name = "Date_inicio"
        Me.Date_inicio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Date_inicio.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Date_inicio.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.Date_inicio.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.Date_inicio.Size = New System.Drawing.Size(112, 20)
        Me.Date_inicio.TabIndex = 3
        '
        'butBuscar
        '
        Me.butBuscar.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butBuscar.Appearance.Options.UseFont = True
        Me.butBuscar.Location = New System.Drawing.Point(359, 35)
        Me.butBuscar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.butBuscar.Margin = New System.Windows.Forms.Padding(2)
        Me.butBuscar.Name = "butBuscar"
        Me.butBuscar.Size = New System.Drawing.Size(116, 29)
        Me.butBuscar.TabIndex = 272
        Me.butBuscar.Text = "Buscar"
        '
        'Date_fin
        '
        Me.Date_fin.EditValue = Nothing
        Me.Date_fin.Location = New System.Drawing.Point(249, 44)
        Me.Date_fin.Margin = New System.Windows.Forms.Padding(2)
        Me.Date_fin.Name = "Date_fin"
        Me.Date_fin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Date_fin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Date_fin.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.Date_fin.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.Date_fin.Size = New System.Drawing.Size(106, 20)
        Me.Date_fin.TabIndex = 5
        '
        'gc_actuales
        '
        Me.gc_actuales.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2)
        Me.gc_actuales.Location = New System.Drawing.Point(11, 79)
        Me.gc_actuales.MainView = Me.gv_actuales
        Me.gc_actuales.Margin = New System.Windows.Forms.Padding(2)
        Me.gc_actuales.Name = "gc_actuales"
        Me.gc_actuales.Size = New System.Drawing.Size(1175, 473)
        Me.gc_actuales.TabIndex = 277
        Me.gc_actuales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_actuales})
        '
        'gv_actuales
        '
        Me.gv_actuales.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.Appearance.EvenRow.Options.UseFont = True
        Me.gv_actuales.Appearance.FocusedRow.BackColor = System.Drawing.Color.Khaki
        Me.gv_actuales.Appearance.FocusedRow.Options.UseBackColor = True
        Me.gv_actuales.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.Appearance.HorzLine.Options.UseFont = True
        Me.gv_actuales.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent
        Me.gv_actuales.Appearance.OddRow.BackColor2 = System.Drawing.Color.Transparent
        Me.gv_actuales.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.Appearance.OddRow.Options.UseBackColor = True
        Me.gv_actuales.Appearance.OddRow.Options.UseFont = True
        Me.gv_actuales.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.gv_actuales.Appearance.Row.Options.UseFont = True
        Me.gv_actuales.Appearance.VertLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.Appearance.VertLine.Options.UseFont = True
        Me.gv_actuales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.gv_actuales.AppearancePrint.Lines.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.AppearancePrint.Lines.Options.UseFont = True
        Me.gv_actuales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.AppearancePrint.OddRow.Options.UseFont = True
        Me.gv_actuales.AppearancePrint.Preview.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.AppearancePrint.Preview.Options.UseFont = True
        Me.gv_actuales.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.gv_actuales.AppearancePrint.Row.Options.UseFont = True
        Me.gv_actuales.DetailHeight = 450
        Me.gv_actuales.FixedLineWidth = 6
        Me.gv_actuales.GridControl = Me.gc_actuales
        Me.gv_actuales.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gv_actuales.Name = "gv_actuales"
        Me.gv_actuales.OptionsBehavior.Editable = False
        Me.gv_actuales.OptionsPrint.EnableAppearanceOddRow = True
        Me.gv_actuales.OptionsView.EnableAppearanceEvenRow = True
        Me.gv_actuales.OptionsView.EnableAppearanceOddRow = True
        Me.gv_actuales.OptionsView.ShowGroupPanel = False
        Me.gv_actuales.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'erp_ctrl_reporte_checadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 563)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "erp_ctrl_reporte_checadas"
        Me.Text = "erp_ctrl_reporte_checadas"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.Date_inicio.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date_inicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date_fin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Date_fin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_actuales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_actuales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Date_inicio As DevExpress.XtraEditors.DateEdit
    Friend WithEvents butBuscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Date_fin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents gc_actuales As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_actuales As DevExpress.XtraGrid.Views.Grid.GridView
End Class

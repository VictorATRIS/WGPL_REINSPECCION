<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_generar_mensual_backorders
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
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.butInsertar = New DevExpress.XtraEditors.SimpleButton()
        Me.butConsultar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.gc_backs = New DevExpress.XtraGrid.GridControl()
        Me.gv_backs = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_backs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_backs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(178, 37)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(203, 18)
        Me.LabelControl3.TabIndex = 129
        Me.LabelControl3.Text = "Considera todo el Mes anterior "
        '
        'butInsertar
        '
        Me.butInsertar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butInsertar.Appearance.Options.UseFont = True
        Me.butInsertar.Location = New System.Drawing.Point(584, 14)
        Me.butInsertar.Name = "butInsertar"
        Me.butInsertar.Size = New System.Drawing.Size(91, 24)
        Me.butInsertar.TabIndex = 128
        Me.butInsertar.Text = "Insertar"
        Me.butInsertar.Visible = False
        '
        'butConsultar
        '
        Me.butConsultar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butConsultar.Appearance.Options.UseFont = True
        Me.butConsultar.Location = New System.Drawing.Point(441, 12)
        Me.butConsultar.Name = "butConsultar"
        Me.butConsultar.Size = New System.Drawing.Size(91, 24)
        Me.butConsultar.TabIndex = 127
        Me.butConsultar.Text = "Consultar"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(107, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 18)
        Me.LabelControl1.TabIndex = 123
        Me.LabelControl1.Text = "Del:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(268, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(16, 18)
        Me.LabelControl2.TabIndex = 124
        Me.LabelControl2.Text = "Al:"
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(138, 11)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit1.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.DateEdit1.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.DateEdit1.Size = New System.Drawing.Size(96, 22)
        Me.DateEdit1.TabIndex = 125
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(290, 11)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit2.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.DateEdit2.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.DateEdit2.Size = New System.Drawing.Size(96, 22)
        Me.DateEdit2.TabIndex = 126
        '
        'gc_backs
        '
        Me.gc_backs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gc_backs.Location = New System.Drawing.Point(3, 60)
        Me.gc_backs.MainView = Me.gv_backs
        Me.gc_backs.Name = "gc_backs"
        Me.gc_backs.Size = New System.Drawing.Size(1039, 484)
        Me.gc_backs.TabIndex = 122
        Me.gc_backs.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_backs})
        '
        'gv_backs
        '
        Me.gv_backs.GridControl = Me.gc_backs
        Me.gv_backs.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gv_backs.Name = "gv_backs"
        Me.gv_backs.OptionsView.RowAutoHeight = True
        Me.gv_backs.OptionsView.ShowGroupPanel = False
        '
        'erp_ctrl_generar_mensual_backorders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 556)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.butInsertar)
        Me.Controls.Add(Me.butConsultar)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.DateEdit1)
        Me.Controls.Add(Me.DateEdit2)
        Me.Controls.Add(Me.gc_backs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "erp_ctrl_generar_mensual_backorders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "erp_ctrl_generar_mensual_backorders"
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_backs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_backs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents butInsertar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents butConsultar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents gc_backs As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_backs As DevExpress.XtraGrid.Views.Grid.GridView
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_formato_largo
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
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GV1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.te_sews = New DevExpress.XtraEditors.TextEdit()
        Me.btn_xref = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.te_sews.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Location = New System.Drawing.Point(367, 255)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(144, 36)
        Me.SimpleButton7.TabIndex = 213
        Me.SimpleButton7.Text = "Actualizar"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(12, 91)
        Me.GridControl1.MainView = Me.GV1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(841, 142)
        Me.GridControl1.TabIndex = 212
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV1})
        '
        'GV1
        '
        Me.GV1.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.Appearance.EvenRow.Options.UseFont = True
        Me.GV1.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.Appearance.HorzLine.Options.UseFont = True
        Me.GV1.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent
        Me.GV1.Appearance.OddRow.BackColor2 = System.Drawing.Color.Transparent
        Me.GV1.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.Appearance.OddRow.Options.UseBackColor = True
        Me.GV1.Appearance.OddRow.Options.UseFont = True
        Me.GV1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GV1.Appearance.Row.Options.UseFont = True
        Me.GV1.Appearance.VertLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.Appearance.VertLine.Options.UseFont = True
        Me.GV1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GV1.AppearancePrint.Lines.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.AppearancePrint.Lines.Options.UseFont = True
        Me.GV1.AppearancePrint.OddRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.AppearancePrint.OddRow.Options.UseFont = True
        Me.GV1.AppearancePrint.Preview.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.AppearancePrint.Preview.Options.UseFont = True
        Me.GV1.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(7, Byte))
        Me.GV1.AppearancePrint.Row.Options.UseFont = True
        Me.GV1.DetailHeight = 450
        Me.GV1.GridControl = Me.GridControl1
        Me.GV1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GV1.Name = "GV1"
        Me.GV1.OptionsPrint.EnableAppearanceOddRow = True
        Me.GV1.OptionsView.EnableAppearanceEvenRow = True
        Me.GV1.OptionsView.EnableAppearanceOddRow = True
        Me.GV1.OptionsView.RowAutoHeight = True
        Me.GV1.OptionsView.ShowGroupPanel = False
        Me.GV1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(228, 53)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(110, 18)
        Me.LabelControl9.TabIndex = 211
        Me.LabelControl9.Text = "Sews Part No :"
        '
        'te_sews
        '
        Me.te_sews.Location = New System.Drawing.Point(357, 50)
        Me.te_sews.Name = "te_sews"
        Me.te_sews.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.te_sews.Properties.Appearance.Options.UseFont = True
        Me.te_sews.Properties.Mask.EditMask = "d"
        Me.te_sews.Size = New System.Drawing.Size(129, 24)
        Me.te_sews.TabIndex = 210
        '
        'btn_xref
        '
        Me.btn_xref.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.btn_xref.Appearance.Options.UseFont = True
        Me.btn_xref.Location = New System.Drawing.Point(516, 45)
        Me.btn_xref.Name = "btn_xref"
        Me.btn_xref.Size = New System.Drawing.Size(121, 28)
        Me.btn_xref.TabIndex = 209
        Me.btn_xref.Text = "Consulta"
        '
        'erp_ctrl_formato_largo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 321)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.te_sews)
        Me.Controls.Add(Me.btn_xref)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "erp_ctrl_formato_largo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "erp_ctrl_formato_largo"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.te_sews.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents te_sews As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btn_xref As DevExpress.XtraEditors.SimpleButton
End Class

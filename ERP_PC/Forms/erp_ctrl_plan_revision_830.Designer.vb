<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_plan_revision_830
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
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarAgregar = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarEliminarRevision = New DevExpress.XtraNavBar.NavBarItem()
        Me.NavBarActivarRevision = New DevExpress.XtraNavBar.NavBarItem()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.NavBarGroup1
        Me.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroup1})
        Me.NavBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.NavBarAgregar, Me.NavBarEliminarRevision, Me.NavBarActivarRevision})
        Me.NavBarControl1.Location = New System.Drawing.Point(0, 0)
        Me.NavBarControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = 223
        Me.NavBarControl1.Size = New System.Drawing.Size(223, 175)
        Me.NavBarControl1.TabIndex = 1
        Me.NavBarControl1.Text = "Opciones"
        '
        'NavBarGroup1
        '
        Me.NavBarGroup1.Caption = "Opciones"
        Me.NavBarGroup1.Expanded = True
        Me.NavBarGroup1.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Small
        Me.NavBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText
        Me.NavBarGroup1.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarAgregar), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarEliminarRevision), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarActivarRevision)})
        Me.NavBarGroup1.Name = "NavBarGroup1"
        '
        'NavBarAgregar
        '
        Me.NavBarAgregar.AppearancePressed.BackColor = System.Drawing.Color.Blue
        Me.NavBarAgregar.AppearancePressed.Options.UseBackColor = True
        Me.NavBarAgregar.Caption = "Agregar Revision"
        Me.NavBarAgregar.LargeImage = Global.WGPL_REINSPECTION.My.Resources.Resources.icons8_agregar_regla_96
        Me.NavBarAgregar.Name = "NavBarAgregar"
        Me.NavBarAgregar.SmallImage = Global.WGPL_REINSPECTION.My.Resources.Resources.icons8_maximum_order_32
        '
        'NavBarEliminarRevision
        '
        Me.NavBarEliminarRevision.Caption = "Eliminar Revision"
        Me.NavBarEliminarRevision.Name = "NavBarEliminarRevision"
        Me.NavBarEliminarRevision.SmallImage = Global.WGPL_REINSPECTION.My.Resources.Resources.icons8_eliminar_papelera_24
        '
        'NavBarActivarRevision
        '
        Me.NavBarActivarRevision.Caption = "Activar Revision"
        Me.NavBarActivarRevision.Name = "NavBarActivarRevision"
        Me.NavBarActivarRevision.SmallImage = Global.WGPL_REINSPECTION.My.Resources.Resources.icons8_de_acuerdo_30
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(223, 0)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(393, 175)
        Me.PanelControl1.TabIndex = 3
        '
        'erp_ctrl_plan_revision_830
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 175)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.NavBarControl1)
        Me.Name = "erp_ctrl_plan_revision_830"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "erp_ctrl_plan_revision_830"
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarAgregar As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarEliminarRevision As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarActivarRevision As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
End Class

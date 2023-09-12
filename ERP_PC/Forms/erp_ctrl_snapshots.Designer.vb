<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_snapshots
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_info_dt = New DevExpress.XtraEditors.LookUpEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cb_info_dt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage2
        Me.XtraTabControl1.Size = New System.Drawing.Size(997, 739)
        Me.XtraTabControl1.TabIndex = 6
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage2, Me.XtraTabPage1})
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GridControl2)
        Me.XtraTabPage2.Controls.Add(Me.SimpleButton1)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(991, 708)
        Me.XtraTabPage2.Text = "SNAP SHOTS"
        '
        'GridControl2
        '
        Me.GridControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl2.Location = New System.Drawing.Point(3, 3)
        Me.GridControl2.MainView = Me.GridView1
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(979, 649)
        Me.GridControl2.TabIndex = 6
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 450
        Me.GridView1.GridControl = Me.GridControl2
        Me.GridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(803, 668)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(137, 34)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "Cargar Archivo"
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GroupBox2)
        Me.XtraTabPage1.Controls.Add(Me.GroupBox1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(991, 708)
        Me.XtraTabPage1.Text = "Detalle de SNAP SHOTS "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SimpleButton3)
        Me.GroupBox2.Controls.Add(Me.GridControl3)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 102)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(971, 539)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton3.Appearance.Options.UseFont = True
        Me.SimpleButton3.Location = New System.Drawing.Point(369, 21)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(167, 34)
        Me.SimpleButton3.TabIndex = 7
        Me.SimpleButton3.Text = "Generar Detalle"
        '
        'GridControl3
        '
        Me.GridControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl3.Location = New System.Drawing.Point(6, 75)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(959, 411)
        Me.GridControl3.TabIndex = 9
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.DetailHeight = 450
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.RowAutoHeight = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        Me.GridView3.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_info_dt)
        Me.GroupBox1.Controls.Add(Me.SimpleButton2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(965, 82)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'cb_info_dt
        '
        Me.cb_info_dt.Location = New System.Drawing.Point(341, 31)
        Me.cb_info_dt.Name = "cb_info_dt"
        Me.cb_info_dt.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.cb_info_dt.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.cb_info_dt.Properties.Appearance.Options.UseBackColor = True
        Me.cb_info_dt.Properties.Appearance.Options.UseFont = True
        Me.cb_info_dt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cb_info_dt.Properties.NullText = ""
        Me.cb_info_dt.Size = New System.Drawing.Size(156, 28)
        Me.cb_info_dt.TabIndex = 243
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Location = New System.Drawing.Point(623, 27)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(167, 34)
        Me.SimpleButton2.TabIndex = 6
        Me.SimpleButton2.Text = "Generar a Vertical "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(149, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha de SNAP SHOTS :"
        '
        'erp_ctrl_snapshots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 739)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "erp_ctrl_snapshots"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "erp_ctrl_snapshots"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cb_info_dt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_info_dt As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

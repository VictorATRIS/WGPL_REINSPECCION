<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_cust_part_nuevos_830
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gc_productos = New DevExpress.XtraGrid.GridControl()
        Me.gv_productos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gc_no_cnd = New DevExpress.XtraGrid.GridControl()
        Me.gv_no_cnd = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.gc_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_no_cnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_no_cnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1140, 501)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'gc_productos
        '
        Me.gc_productos.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2)
        Me.gc_productos.Location = New System.Drawing.Point(11, 58)
        Me.gc_productos.MainView = Me.gv_productos
        Me.gc_productos.Margin = New System.Windows.Forms.Padding(2)
        Me.gc_productos.Name = "gc_productos"
        Me.gc_productos.Size = New System.Drawing.Size(562, 438)
        Me.gc_productos.TabIndex = 7
        Me.gc_productos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_productos, Me.GridView2})
        '
        'gv_productos
        '
        Me.gv_productos.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.gv_productos.Appearance.OddRow.Options.UseBackColor = True
        Me.gv_productos.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.gv_productos.Appearance.Row.BackColor2 = System.Drawing.Color.White
        Me.gv_productos.Appearance.Row.Options.UseBackColor = True
        Me.gv_productos.DetailHeight = 450
        Me.gv_productos.GridControl = Me.gc_productos
        Me.gv_productos.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gv_productos.Name = "gv_productos"
        Me.gv_productos.OptionsBehavior.Editable = False
        Me.gv_productos.OptionsBehavior.ReadOnly = True
        Me.gv_productos.OptionsView.AllowCellMerge = True
        Me.gv_productos.OptionsView.RowAutoHeight = True
        Me.gv_productos.OptionsView.ShowGroupPanel = False
        Me.gv_productos.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gc_productos
        Me.GridView2.Name = "GridView2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(84, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(422, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CUST_PART CON NUEVOS MODELOS"
        '
        'gc_no_cnd
        '
        Me.gc_no_cnd.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2)
        Me.gc_no_cnd.Location = New System.Drawing.Point(654, 58)
        Me.gc_no_cnd.MainView = Me.gv_no_cnd
        Me.gc_no_cnd.Margin = New System.Windows.Forms.Padding(2)
        Me.gc_no_cnd.Name = "gc_no_cnd"
        Me.gc_no_cnd.Size = New System.Drawing.Size(562, 438)
        Me.gc_no_cnd.TabIndex = 9
        Me.gc_no_cnd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_no_cnd, Me.GridView3})
        '
        'gv_no_cnd
        '
        Me.gv_no_cnd.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.gv_no_cnd.Appearance.OddRow.Options.UseBackColor = True
        Me.gv_no_cnd.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.gv_no_cnd.Appearance.Row.BackColor2 = System.Drawing.Color.White
        Me.gv_no_cnd.Appearance.Row.Options.UseBackColor = True
        Me.gv_no_cnd.DetailHeight = 450
        Me.gv_no_cnd.GridControl = Me.gc_no_cnd
        Me.gv_no_cnd.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gv_no_cnd.Name = "gv_no_cnd"
        Me.gv_no_cnd.OptionsBehavior.Editable = False
        Me.gv_no_cnd.OptionsBehavior.ReadOnly = True
        Me.gv_no_cnd.OptionsView.RowAutoHeight = True
        Me.gv_no_cnd.OptionsView.ShowGroupPanel = False
        Me.gv_no_cnd.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gc_no_cnd
        Me.GridView3.Name = "GridView3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(704, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(479, 25)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "CUST_PART NUNCA REGISTRADO EN CND"
        '
        'erp_ctrl_cust_part_nuevos_830
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1227, 531)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gc_no_cnd)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gc_productos)
        Me.Controls.Add(Me.Label1)
        Me.Name = "erp_ctrl_cust_part_nuevos_830"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "erp_ctrl_cust_part_nuevos_830"
        CType(Me.gc_productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_productos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_no_cnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_no_cnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents gc_productos As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_productos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gc_no_cnd As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_no_cnd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

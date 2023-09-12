<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_importacion_xls_smh
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
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GV1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.butCargarArchivo = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(-1, 2)
        Me.GridControl1.MainView = Me.GV1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1059, 672)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV1})
        '
        'GV1
        '
        Me.GV1.DetailHeight = 450
        Me.GV1.GridControl = Me.GridControl1
        Me.GV1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GV1.Name = "GV1"
        Me.GV1.OptionsView.ColumnAutoWidth = False
        Me.GV1.OptionsView.RowAutoHeight = True
        Me.GV1.OptionsView.ShowGroupPanel = False
        Me.GV1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Location = New System.Drawing.Point(466, 689)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(114, 35)
        Me.SimpleButton2.TabIndex = 4
        Me.SimpleButton2.Visible = False
        '
        'butCargarArchivo
        '
        Me.butCargarArchivo.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCargarArchivo.Appearance.Options.UseFont = True
        Me.butCargarArchivo.Location = New System.Drawing.Point(890, 680)
        Me.butCargarArchivo.Name = "butCargarArchivo"
        Me.butCargarArchivo.Size = New System.Drawing.Size(154, 44)
        Me.butCargarArchivo.TabIndex = 5
        Me.butCargarArchivo.Text = "Cargar Archivo"
        '
        'erp_ctrl_importacion_xls_smh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 729)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.butCargarArchivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "erp_ctrl_importacion_xls_smh"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "erp_ctrl_importacion_xls_smh"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents butCargarArchivo As DevExpress.XtraEditors.SimpleButton
End Class

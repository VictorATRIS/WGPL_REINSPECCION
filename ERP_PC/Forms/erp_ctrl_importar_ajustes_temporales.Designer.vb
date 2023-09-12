<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_importar_ajustes_temporales
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
        Me.te_revtmp = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.butEliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.butCargar = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GV1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.te_revtmp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'te_revtmp
        '
        Me.te_revtmp.Location = New System.Drawing.Point(139, 521)
        Me.te_revtmp.Name = "te_revtmp"
        Me.te_revtmp.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.te_revtmp.Properties.Appearance.Options.UseFont = True
        Me.te_revtmp.Properties.Mask.EditMask = "d"
        Me.te_revtmp.Size = New System.Drawing.Size(135, 24)
        Me.te_revtmp.TabIndex = 117
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(12, 526)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(121, 19)
        Me.LabelControl6.TabIndex = 116
        Me.LabelControl6.Text = "Revision TMP :"
        '
        'butEliminar
        '
        Me.butEliminar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butEliminar.Appearance.Options.UseFont = True
        Me.butEliminar.Location = New System.Drawing.Point(289, 511)
        Me.butEliminar.Name = "butEliminar"
        Me.butEliminar.Size = New System.Drawing.Size(137, 34)
        Me.butEliminar.TabIndex = 115
        Me.butEliminar.Text = "Eliminar Anterior"
        '
        'butCargar
        '
        Me.butCargar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCargar.Appearance.Options.UseFont = True
        Me.butCargar.Location = New System.Drawing.Point(679, 511)
        Me.butCargar.Name = "butCargar"
        Me.butCargar.Size = New System.Drawing.Size(137, 34)
        Me.butCargar.TabIndex = 114
        Me.butCargar.Text = "Cargar Archivo"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.GV1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(832, 493)
        Me.GridControl1.TabIndex = 113
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
        'erp_ctrl_importar_ajustes_temporales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 555)
        Me.Controls.Add(Me.te_revtmp)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.butEliminar)
        Me.Controls.Add(Me.butCargar)
        Me.Controls.Add(Me.GridControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "erp_ctrl_importar_ajustes_temporales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "erp_ctrl_importar_ajustes_temporales"
        CType(Me.te_revtmp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents te_revtmp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents butEliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents butCargar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class

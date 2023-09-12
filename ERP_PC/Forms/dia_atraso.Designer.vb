<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dia_atraso
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_gene = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_dia = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.CB_dia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(244, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 29)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Q"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(64, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 21)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Qty de Dia Actual : "
        '
        'btn_gene
        '
        Me.btn_gene.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.btn_gene.Appearance.Options.UseFont = True
        Me.btn_gene.Location = New System.Drawing.Point(117, 170)
        Me.btn_gene.Name = "btn_gene"
        Me.btn_gene.Size = New System.Drawing.Size(121, 28)
        Me.btn_gene.TabIndex = 122
        Me.btn_gene.Text = "Actualizar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(257, 21)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Seleccionar Dias de Atrasos :"
        '
        'CB_dia
        '
        Me.CB_dia.Location = New System.Drawing.Point(124, 123)
        Me.CB_dia.Name = "CB_dia"
        Me.CB_dia.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_dia.Properties.Appearance.Options.UseFont = True
        Me.CB_dia.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CB_dia.Properties.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.CB_dia.Size = New System.Drawing.Size(100, 26)
        Me.CB_dia.TabIndex = 120
        '
        'dia_atraso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 255)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_gene)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CB_dia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "dia_atraso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dia_atraso"
        CType(Me.CB_dia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_gene As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_dia As DevExpress.XtraEditors.ComboBoxEdit
End Class

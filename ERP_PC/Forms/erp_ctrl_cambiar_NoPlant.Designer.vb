<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_ctrl_cambiar_NoPlant
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
        Me.lookCustomer = New DevExpress.XtraEditors.LookUpEdit()
        Me.lookDl = New DevExpress.XtraEditors.LookUpEdit()
        Me.lookEditSews = New DevExpress.XtraEditors.LookUpEdit()
        Me.comboMFGNo = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.butGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GV1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.butBuscar = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.lookCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lookDl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lookEditSews.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboMFGNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lookCustomer
        '
        Me.lookCustomer.Location = New System.Drawing.Point(730, 69)
        Me.lookCustomer.Name = "lookCustomer"
        Me.lookCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lookCustomer.Properties.NullText = ""
        Me.lookCustomer.Size = New System.Drawing.Size(148, 22)
        Me.lookCustomer.TabIndex = 170
        '
        'lookDl
        '
        Me.lookDl.Location = New System.Drawing.Point(420, 67)
        Me.lookDl.Name = "lookDl"
        Me.lookDl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lookDl.Properties.NullText = ""
        Me.lookDl.Size = New System.Drawing.Size(163, 22)
        Me.lookDl.TabIndex = 169
        '
        'lookEditSews
        '
        Me.lookEditSews.Location = New System.Drawing.Point(208, 68)
        Me.lookEditSews.Name = "lookEditSews"
        Me.lookEditSews.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lookEditSews.Properties.NullText = ""
        Me.lookEditSews.Size = New System.Drawing.Size(130, 22)
        Me.lookEditSews.TabIndex = 168
        '
        'comboMFGNo
        '
        Me.comboMFGNo.Location = New System.Drawing.Point(208, 162)
        Me.comboMFGNo.Name = "comboMFGNo"
        Me.comboMFGNo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.75!)
        Me.comboMFGNo.Properties.Appearance.Options.UseFont = True
        Me.comboMFGNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.comboMFGNo.Size = New System.Drawing.Size(117, 28)
        Me.comboMFGNo.TabIndex = 167
        '
        'butGuardar
        '
        Me.butGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butGuardar.Appearance.Options.UseFont = True
        Me.butGuardar.Location = New System.Drawing.Point(343, 152)
        Me.butGuardar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.butGuardar.Name = "butGuardar"
        Me.butGuardar.Size = New System.Drawing.Size(154, 36)
        Me.butGuardar.TabIndex = 166
        Me.butGuardar.Text = "Actualizar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(110, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 24)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = "Mfg Plant:"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(181, 224)
        Me.GridControl1.MainView = Me.GV1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(627, 199)
        Me.GridControl1.TabIndex = 164
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GV1})
        '
        'GV1
        '
        Me.GV1.DetailHeight = 450
        Me.GV1.GridControl = Me.GridControl1
        Me.GV1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GV1.Name = "GV1"
        Me.GV1.OptionsBehavior.Editable = False
        Me.GV1.OptionsView.ColumnAutoWidth = False
        Me.GV1.OptionsView.RowAutoHeight = True
        Me.GV1.OptionsView.ShowGroupPanel = False
        Me.GV1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'butBuscar
        '
        Me.butBuscar.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butBuscar.Appearance.Options.UseFont = True
        Me.butBuscar.Location = New System.Drawing.Point(724, 112)
        Me.butBuscar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.butBuscar.Name = "butBuscar"
        Me.butBuscar.Size = New System.Drawing.Size(154, 36)
        Me.butBuscar.TabIndex = 163
        Me.butBuscar.Text = "Buscar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(606, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 24)
        Me.Label3.TabIndex = 162
        Me.Label3.Text = "Customer ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(360, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 24)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "DL:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 24)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Sews Part. No:"
        '
        'erp_ctrl_cambiar_NoPlant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 488)
        Me.Controls.Add(Me.lookCustomer)
        Me.Controls.Add(Me.lookDl)
        Me.Controls.Add(Me.lookEditSews)
        Me.Controls.Add(Me.comboMFGNo)
        Me.Controls.Add(Me.butGuardar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.butBuscar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "erp_ctrl_cambiar_NoPlant"
        Me.Text = "erp_ctrl_cambiar_NoPlant"
        CType(Me.lookCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lookDl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lookEditSews.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboMFGNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lookCustomer As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lookDl As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lookEditSews As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents comboMFGNo As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents butGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GV1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents butBuscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

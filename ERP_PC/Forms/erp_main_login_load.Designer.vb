<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class erp_main_login_load
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(erp_main_login_load))
        Me.Lbl_pwd = New System.Windows.Forms.Label()
        Me.lbl_user = New System.Windows.Forms.Label()
        Me.Txt_pwd = New System.Windows.Forms.TextBox()
        Me.Txt_usr = New System.Windows.Forms.TextBox()
        Me.Btn_ent = New System.Windows.Forms.Button()
        Me.img_locallogo = New System.Windows.Forms.PictureBox()
        Me.img_access = New System.Windows.Forms.PictureBox()
        Me.img_access1 = New System.Windows.Forms.PictureBox()
        Me.img_deny = New System.Windows.Forms.PictureBox()
        Me.Lbl_Title1 = New System.Windows.Forms.Label()
        CType(Me.img_locallogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_access, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_access1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_deny, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_pwd
        '
        Me.Lbl_pwd.AutoSize = True
        Me.Lbl_pwd.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_pwd.Location = New System.Drawing.Point(224, 387)
        Me.Lbl_pwd.Name = "Lbl_pwd"
        Me.Lbl_pwd.Size = New System.Drawing.Size(129, 23)
        Me.Lbl_pwd.TabIndex = 10
        Me.Lbl_pwd.Text = "Contraseña:"
        '
        'lbl_user
        '
        Me.lbl_user.AutoSize = True
        Me.lbl_user.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user.Location = New System.Drawing.Point(242, 328)
        Me.lbl_user.Name = "lbl_user"
        Me.lbl_user.Size = New System.Drawing.Size(87, 23)
        Me.lbl_user.TabIndex = 9
        Me.lbl_user.Text = "Usuario:"
        '
        'Txt_pwd
        '
        Me.Txt_pwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_pwd.Location = New System.Drawing.Point(172, 413)
        Me.Txt_pwd.Name = "Txt_pwd"
        Me.Txt_pwd.Size = New System.Drawing.Size(235, 30)
        Me.Txt_pwd.TabIndex = 8
        Me.Txt_pwd.UseSystemPasswordChar = True
        '
        'Txt_usr
        '
        Me.Txt_usr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_usr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_usr.Location = New System.Drawing.Point(172, 354)
        Me.Txt_usr.Name = "Txt_usr"
        Me.Txt_usr.Size = New System.Drawing.Size(235, 30)
        Me.Txt_usr.TabIndex = 7
        '
        'Btn_ent
        '
        Me.Btn_ent.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Btn_ent.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ent.Location = New System.Drawing.Point(172, 461)
        Me.Btn_ent.Name = "Btn_ent"
        Me.Btn_ent.Size = New System.Drawing.Size(235, 41)
        Me.Btn_ent.TabIndex = 11
        Me.Btn_ent.Text = "Entrar"
        Me.Btn_ent.UseVisualStyleBackColor = False
        '
        'img_locallogo
        '
        Me.img_locallogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.img_locallogo.Image = Global.ERP_PC.My.Resources.Resources.logo_loginTNS
        Me.img_locallogo.Location = New System.Drawing.Point(376, 551)
        Me.img_locallogo.Name = "img_locallogo"
        Me.img_locallogo.Size = New System.Drawing.Size(202, 71)
        Me.img_locallogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_locallogo.TabIndex = 12
        Me.img_locallogo.TabStop = False
        '
        'img_access
        '
        Me.img_access.Image = CType(resources.GetObject("img_access.Image"), System.Drawing.Image)
        Me.img_access.Location = New System.Drawing.Point(192, 76)
        Me.img_access.Name = "img_access"
        Me.img_access.Size = New System.Drawing.Size(215, 198)
        Me.img_access.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_access.TabIndex = 14
        Me.img_access.TabStop = False
        '
        'img_access1
        '
        Me.img_access1.Image = CType(resources.GetObject("img_access1.Image"), System.Drawing.Image)
        Me.img_access1.Location = New System.Drawing.Point(192, 76)
        Me.img_access1.Name = "img_access1"
        Me.img_access1.Size = New System.Drawing.Size(214, 202)
        Me.img_access1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_access1.TabIndex = 15
        Me.img_access1.TabStop = False
        '
        'img_deny
        '
        Me.img_deny.Image = CType(resources.GetObject("img_deny.Image"), System.Drawing.Image)
        Me.img_deny.Location = New System.Drawing.Point(203, 95)
        Me.img_deny.Name = "img_deny"
        Me.img_deny.Size = New System.Drawing.Size(192, 179)
        Me.img_deny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.img_deny.TabIndex = 16
        Me.img_deny.TabStop = False
        Me.img_deny.Visible = False
        '
        'Lbl_Title1
        '
        Me.Lbl_Title1.AutoSize = True
        Me.Lbl_Title1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Title1.Location = New System.Drawing.Point(-4, 551)
        Me.Lbl_Title1.Name = "Lbl_Title1"
        Me.Lbl_Title1.Size = New System.Drawing.Size(252, 69)
        Me.Lbl_Title1.TabIndex = 17
        Me.Lbl_Title1.Text = "ERP PC"
        '
        'erp_main_login_load
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 634)
        Me.Controls.Add(Me.Lbl_Title1)
        Me.Controls.Add(Me.img_deny)
        Me.Controls.Add(Me.img_access1)
        Me.Controls.Add(Me.img_access)
        Me.Controls.Add(Me.img_locallogo)
        Me.Controls.Add(Me.Btn_ent)
        Me.Controls.Add(Me.Lbl_pwd)
        Me.Controls.Add(Me.lbl_user)
        Me.Controls.Add(Me.Txt_pwd)
        Me.Controls.Add(Me.Txt_usr)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "erp_main_login_load"
        Me.Text = "Form1"
        CType(Me.img_locallogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_access, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_access1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_deny, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_pwd As System.Windows.Forms.Label
    Friend WithEvents lbl_user As System.Windows.Forms.Label
    Friend WithEvents Txt_usr As System.Windows.Forms.TextBox
    Friend WithEvents Btn_ent As System.Windows.Forms.Button
    Friend WithEvents img_locallogo As System.Windows.Forms.PictureBox
    Friend WithEvents img_access As System.Windows.Forms.PictureBox
    Friend WithEvents img_access1 As System.Windows.Forms.PictureBox
    Friend WithEvents img_deny As System.Windows.Forms.PictureBox
    Friend WithEvents Lbl_Title1 As System.Windows.Forms.Label
    Private WithEvents Txt_pwd As System.Windows.Forms.TextBox

End Class

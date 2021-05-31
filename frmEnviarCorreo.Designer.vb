<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnviarCorreo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnviarCorreo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEnviarEmail = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDatos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(495, 198)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnEnviarEmail)
        Me.GroupBox2.Location = New System.Drawing.Point(414, 26)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(69, 162)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 143)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 52
        Me.Label20.Text = "Cerrar"
        Me.Label20.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(6, 84)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(56, 56)
        Me.btnCancelar.TabIndex = 51
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Enviar"
        Me.Label2.Visible = False
        '
        'btnEnviarEmail
        '
        Me.btnEnviarEmail.BackColor = System.Drawing.Color.White
        Me.btnEnviarEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviarEmail.Image = CType(resources.GetObject("btnEnviarEmail.Image"), System.Drawing.Image)
        Me.btnEnviarEmail.Location = New System.Drawing.Point(6, 9)
        Me.btnEnviarEmail.Name = "btnEnviarEmail"
        Me.btnEnviarEmail.Size = New System.Drawing.Size(56, 56)
        Me.btnEnviarEmail.TabIndex = 49
        Me.btnEnviarEmail.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDatos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCorreo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(401, 162)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información a Enviar"
        '
        'txtDatos
        '
        Me.txtDatos.BackColor = System.Drawing.Color.White
        Me.txtDatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtDatos.Location = New System.Drawing.Point(53, 58)
        Me.txtDatos.Multiline = True
        Me.txtDatos.Name = "txtDatos"
        Me.txtDatos.ReadOnly = True
        Me.txtDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDatos.Size = New System.Drawing.Size(329, 97)
        Me.txtDatos.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Datos:"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(53, 31)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(329, 20)
        Me.txtCorreo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Correo:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmEnviarCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(502, 202)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEnviarCorreo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar Correo"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEnviarEmail As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtDatos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class

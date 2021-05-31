<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuFacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuFacturacion))
        Me.btnFacturaIndividual = New System.Windows.Forms.Button()
        Me.btnFacturaDiaria = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnManejoFactura = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFacturaIndividual
        '
        Me.btnFacturaIndividual.BackColor = System.Drawing.Color.White
        Me.btnFacturaIndividual.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnFacturaIndividual.FlatAppearance.BorderSize = 2
        Me.btnFacturaIndividual.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnFacturaIndividual.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnFacturaIndividual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFacturaIndividual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturaIndividual.ForeColor = System.Drawing.Color.Black
        Me.btnFacturaIndividual.Location = New System.Drawing.Point(12, 43)
        Me.btnFacturaIndividual.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFacturaIndividual.Name = "btnFacturaIndividual"
        Me.btnFacturaIndividual.Size = New System.Drawing.Size(192, 59)
        Me.btnFacturaIndividual.TabIndex = 0
        Me.btnFacturaIndividual.Text = "Factura Individual"
        Me.btnFacturaIndividual.UseVisualStyleBackColor = False
        '
        'btnFacturaDiaria
        '
        Me.btnFacturaDiaria.BackColor = System.Drawing.Color.White
        Me.btnFacturaDiaria.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnFacturaDiaria.FlatAppearance.BorderSize = 2
        Me.btnFacturaDiaria.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnFacturaDiaria.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnFacturaDiaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFacturaDiaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturaDiaria.Location = New System.Drawing.Point(12, 110)
        Me.btnFacturaDiaria.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFacturaDiaria.Name = "btnFacturaDiaria"
        Me.btnFacturaDiaria.Size = New System.Drawing.Size(192, 59)
        Me.btnFacturaDiaria.TabIndex = 0
        Me.btnFacturaDiaria.Text = "Factura Global"
        Me.btnFacturaDiaria.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSalir.FlatAppearance.BorderSize = 2
        Me.btnSalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(212, 110)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(192, 59)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnManejoFactura
        '
        Me.btnManejoFactura.BackColor = System.Drawing.Color.White
        Me.btnManejoFactura.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnManejoFactura.FlatAppearance.BorderSize = 2
        Me.btnManejoFactura.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnManejoFactura.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnManejoFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManejoFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManejoFactura.Location = New System.Drawing.Point(212, 43)
        Me.btnManejoFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.btnManejoFactura.Name = "btnManejoFactura"
        Me.btnManejoFactura.Size = New System.Drawing.Size(192, 59)
        Me.btnManejoFactura.TabIndex = 2
        Me.btnManejoFactura.Text = "Consulta Factura"
        Me.btnManejoFactura.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnFacturaIndividual)
        Me.Panel1.Controls.Add(Me.btnManejoFactura)
        Me.Panel1.Controls.Add(Me.btnFacturaDiaria)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Location = New System.Drawing.Point(4, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 206)
        Me.Panel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(185, 87)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 34)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "c"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(176, 176)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 24)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Correo"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmMenuFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(445, 212)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuFacturacion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú de Facturación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFacturaDiaria As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnManejoFactura As System.Windows.Forms.Button
    Friend WithEvents btnFacturaIndividual As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class

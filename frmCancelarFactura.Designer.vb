<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelarFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarFactura))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTipoRelacion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDatos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvLista = New System.Windows.Forms.DataGridView()
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrefijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFolioOp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImportePagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFormaPagoSAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaveSAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcionSAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoFac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboInclDirCte = New System.Windows.Forms.ComboBox()
        Me.cboInclDirSuc = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(4, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 280)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Location = New System.Drawing.Point(552, 32)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(92, 233)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(21, 208)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 17)
        Me.Label20.TabIndex = 52
        Me.Label20.Text = "Cerrar"
        Me.Label20.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(8, 135)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 69)
        Me.btnCerrar.TabIndex = 51
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 84)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Cancelar"
        Me.Label2.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(8, 11)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 69)
        Me.btnCancelar.TabIndex = 49
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboTipoRelacion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDatos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMotivo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 32)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(535, 233)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información a Cancelar"
        '
        'cboTipoRelacion
        '
        Me.cboTipoRelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRelacion.FormattingEnabled = True
        Me.cboTipoRelacion.Location = New System.Drawing.Point(89, 197)
        Me.cboTipoRelacion.Name = "cboTipoRelacion"
        Me.cboTipoRelacion.Size = New System.Drawing.Size(437, 24)
        Me.cboTipoRelacion.TabIndex = 5
        Me.cboTipoRelacion.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 193)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 36)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tipo Relacion"
        Me.Label4.Visible = False
        '
        'txtDatos
        '
        Me.txtDatos.BackColor = System.Drawing.Color.White
        Me.txtDatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtDatos.Location = New System.Drawing.Point(90, 68)
        Me.txtDatos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDatos.Multiline = True
        Me.txtDatos.Name = "txtDatos"
        Me.txtDatos.ReadOnly = True
        Me.txtDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDatos.Size = New System.Drawing.Size(437, 118)
        Me.txtDatos.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Datos:"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(90, 38)
        Me.txtMotivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMotivo.MaxLength = 50
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(437, 22)
        Me.txtMotivo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Motivo:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'dgvLista
        '
        Me.dgvLista.AllowUserToAddRows = False
        Me.dgvLista.AllowUserToDeleteRows = False
        Me.dgvLista.BackgroundColor = System.Drawing.Color.White
        Me.dgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLista.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLista.ColumnHeadersHeight = 20
        Me.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvLista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFecha, Me.colConcepto, Me.colTipo, Me.colPrefijo, Me.colFolioOp, Me.colTipoMov, Me.colDescuento, Me.colIVA, Me.colImportePagado, Me.colCosto, Me.colImporte, Me.colInteres, Me.colRecargo, Me.colFormaPagoSAT, Me.colClaveSAT, Me.colDescripcionSAT, Me.colTotal, Me.colTipoFac})
        Me.dgvLista.GridColor = System.Drawing.Color.White
        Me.dgvLista.Location = New System.Drawing.Point(4, 312)
        Me.dgvLista.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.ReadOnly = True
        Me.dgvLista.RowHeadersVisible = False
        Me.dgvLista.Size = New System.Drawing.Size(660, 59)
        Me.dgvLista.TabIndex = 5
        Me.dgvLista.Visible = False
        '
        'colFecha
        '
        Me.colFecha.DataPropertyName = "Fecha"
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Visible = False
        Me.colFecha.Width = 5
        '
        'colConcepto
        '
        Me.colConcepto.DataPropertyName = "Concepto"
        Me.colConcepto.HeaderText = "Concepto"
        Me.colConcepto.Name = "colConcepto"
        Me.colConcepto.ReadOnly = True
        Me.colConcepto.Visible = False
        Me.colConcepto.Width = 5
        '
        'colTipo
        '
        Me.colTipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 35
        '
        'colPrefijo
        '
        Me.colPrefijo.DataPropertyName = "Prefijo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colPrefijo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPrefijo.HeaderText = "Prefijo"
        Me.colPrefijo.Name = "colPrefijo"
        Me.colPrefijo.ReadOnly = True
        Me.colPrefijo.Width = 40
        '
        'colFolioOp
        '
        Me.colFolioOp.DataPropertyName = "NoTicket"
        Me.colFolioOp.HeaderText = "No.Ticket"
        Me.colFolioOp.Name = "colFolioOp"
        Me.colFolioOp.ReadOnly = True
        Me.colFolioOp.Width = 60
        '
        'colTipoMov
        '
        Me.colTipoMov.DataPropertyName = "TipoMov"
        Me.colTipoMov.HeaderText = "Movimiento"
        Me.colTipoMov.Name = "colTipoMov"
        Me.colTipoMov.ReadOnly = True
        Me.colTipoMov.Width = 150
        '
        'colDescuento
        '
        Me.colDescuento.DataPropertyName = "Descuento"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.colDescuento.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDescuento.HeaderText = "Descuento"
        Me.colDescuento.Name = "colDescuento"
        Me.colDescuento.ReadOnly = True
        Me.colDescuento.Width = 80
        '
        'colIVA
        '
        Me.colIVA.DataPropertyName = "IVA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.colIVA.DefaultCellStyle = DataGridViewCellStyle5
        Me.colIVA.HeaderText = "IVA"
        Me.colIVA.Name = "colIVA"
        Me.colIVA.ReadOnly = True
        Me.colIVA.Width = 80
        '
        'colImportePagado
        '
        Me.colImportePagado.DataPropertyName = "ImportePagado"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.colImportePagado.DefaultCellStyle = DataGridViewCellStyle6
        Me.colImportePagado.HeaderText = "Importe"
        Me.colImportePagado.Name = "colImportePagado"
        Me.colImportePagado.ReadOnly = True
        '
        'colCosto
        '
        Me.colCosto.DataPropertyName = "Costo"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.colCosto.DefaultCellStyle = DataGridViewCellStyle7
        Me.colCosto.HeaderText = "Costo"
        Me.colCosto.Name = "colCosto"
        Me.colCosto.ReadOnly = True
        Me.colCosto.Width = 80
        '
        'colImporte
        '
        Me.colImporte.DataPropertyName = "Importe"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.colImporte.DefaultCellStyle = DataGridViewCellStyle8
        Me.colImporte.HeaderText = "Utilidad"
        Me.colImporte.Name = "colImporte"
        Me.colImporte.ReadOnly = True
        Me.colImporte.Width = 80
        '
        'colInteres
        '
        Me.colInteres.DataPropertyName = "Interes"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.colInteres.DefaultCellStyle = DataGridViewCellStyle9
        Me.colInteres.HeaderText = "Interes"
        Me.colInteres.Name = "colInteres"
        Me.colInteres.ReadOnly = True
        Me.colInteres.Width = 80
        '
        'colRecargo
        '
        Me.colRecargo.DataPropertyName = "Recargo"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.colRecargo.DefaultCellStyle = DataGridViewCellStyle10
        Me.colRecargo.HeaderText = "Recargo"
        Me.colRecargo.Name = "colRecargo"
        Me.colRecargo.ReadOnly = True
        Me.colRecargo.Width = 80
        '
        'colFormaPagoSAT
        '
        Me.colFormaPagoSAT.DataPropertyName = "FormaPagoSAT"
        Me.colFormaPagoSAT.HeaderText = "FormaPagoSAT"
        Me.colFormaPagoSAT.Name = "colFormaPagoSAT"
        Me.colFormaPagoSAT.ReadOnly = True
        Me.colFormaPagoSAT.Visible = False
        '
        'colClaveSAT
        '
        Me.colClaveSAT.DataPropertyName = "ClaveSAT"
        Me.colClaveSAT.HeaderText = "CodigoSAT"
        Me.colClaveSAT.Name = "colClaveSAT"
        Me.colClaveSAT.ReadOnly = True
        Me.colClaveSAT.Visible = False
        '
        'colDescripcionSAT
        '
        Me.colDescripcionSAT.DataPropertyName = "DescripcionSAT"
        Me.colDescripcionSAT.HeaderText = "DescripcionSAT"
        Me.colDescripcionSAT.Name = "colDescripcionSAT"
        Me.colDescripcionSAT.ReadOnly = True
        Me.colDescripcionSAT.Visible = False
        '
        'colTotal
        '
        Me.colTotal.DataPropertyName = "Total"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = "0"
        Me.colTotal.DefaultCellStyle = DataGridViewCellStyle11
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        Me.colTotal.Visible = False
        Me.colTotal.Width = 70
        '
        'colTipoFac
        '
        Me.colTipoFac.DataPropertyName = "TipoFactura"
        Me.colTipoFac.HeaderText = "TipoFactura"
        Me.colTipoFac.Name = "colTipoFac"
        Me.colTipoFac.ReadOnly = True
        Me.colTipoFac.Visible = False
        '
        'cboInclDirCte
        '
        Me.cboInclDirCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInclDirCte.Enabled = False
        Me.cboInclDirCte.FormattingEnabled = True
        Me.cboInclDirCte.Items.AddRange(New Object() {"NO", "SI"})
        Me.cboInclDirCte.Location = New System.Drawing.Point(303, 328)
        Me.cboInclDirCte.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInclDirCte.Name = "cboInclDirCte"
        Me.cboInclDirCte.Size = New System.Drawing.Size(63, 24)
        Me.cboInclDirCte.TabIndex = 16
        Me.cboInclDirCte.Visible = False
        '
        'cboInclDirSuc
        '
        Me.cboInclDirSuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInclDirSuc.FormattingEnabled = True
        Me.cboInclDirSuc.Items.AddRange(New Object() {"NO", "SI"})
        Me.cboInclDirSuc.Location = New System.Drawing.Point(305, 342)
        Me.cboInclDirSuc.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInclDirSuc.Name = "cboInclDirSuc"
        Me.cboInclDirSuc.Size = New System.Drawing.Size(63, 24)
        Me.cboInclDirSuc.TabIndex = 17
        Me.cboInclDirSuc.Visible = False
        '
        'frmCancelarFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(669, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboInclDirSuc)
        Me.Controls.Add(Me.cboInclDirCte)
        Me.Controls.Add(Me.dgvLista)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelarFactura"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar Factura"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtDatos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboTipoRelacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrefijo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFolioOp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipoMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImportePagado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFormaPagoSAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClaveSAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcionSAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipoFac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboInclDirCte As System.Windows.Forms.ComboBox
    Friend WithEvents cboInclDirSuc As System.Windows.Forms.ComboBox
End Class

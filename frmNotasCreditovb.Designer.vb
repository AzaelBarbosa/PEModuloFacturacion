<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotasCreditovb
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
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTextoAnuncio = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.colRSel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colRFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRPrefijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRNoTicket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRTipoMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRImportePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRRecargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRSerieFacturaGlobal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRFolioFacturaGlobal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRUUIDFacturaGlobal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRFormaPagoSAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRCodigoSAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRDescripcionSAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRImporteFacturar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRTipoFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colREstatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboInclDirCte = New System.Windows.Forms.ComboBox()
        Me.cboInclDirSuc = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Location = New System.Drawing.Point(449, 6)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(173, 237)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = Global.PEFacturacion.My.Resources.Resources.Buscar
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(8, 52)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 40)
        Me.Button1.TabIndex = 52
        Me.Button1.Text = "Buscar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = Global.PEFacturacion.My.Resources.Resources.cerrar
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(8, 148)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(154, 39)
        Me.btnCerrar.TabIndex = 51
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = Global.PEFacturacion.My.Resources.Resources.factura
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(8, 100)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(154, 40)
        Me.btnCancelar.TabIndex = 49
        Me.btnCancelar.Text = "Facturar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTextoAnuncio)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtpFechaIni)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dgvResultado)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 6)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(428, 237)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Notas Credito"
        '
        'lblTextoAnuncio
        '
        Me.lblTextoAnuncio.BackColor = System.Drawing.Color.Transparent
        Me.lblTextoAnuncio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoAnuncio.ForeColor = System.Drawing.Color.Blue
        Me.lblTextoAnuncio.Location = New System.Drawing.Point(17, 142)
        Me.lblTextoAnuncio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTextoAnuncio.Name = "lblTextoAnuncio"
        Me.lblTextoAnuncio.Size = New System.Drawing.Size(390, 45)
        Me.lblTextoAnuncio.TabIndex = 33
        Me.lblTextoAnuncio.Text = "Extrayendo datos de facturación..."
        Me.lblTextoAnuncio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoAnuncio.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(33, 27)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Desde:"
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(82, 27)
        Me.dtpFechaIni.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(136, 19)
        Me.dtpFechaIni.TabIndex = 29
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(272, 27)
        Me.dtpFechaFin.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(135, 19)
        Me.dtpFechaFin.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(226, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Hasta:"
        '
        'dgvResultado
        '
        Me.dgvResultado.AllowUserToAddRows = False
        Me.dgvResultado.AllowUserToDeleteRows = False
        Me.dgvResultado.BackgroundColor = System.Drawing.Color.White
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRSel, Me.colRFecha, Me.colRTipo, Me.colRPrefijo, Me.colRNoTicket, Me.colRTipoMov, Me.colRImportePago, Me.colRCosto, Me.colRDescuento, Me.colRImporte, Me.colRInteres, Me.colRRecargo, Me.colRIVA, Me.colRConcepto, Me.colRSerieFacturaGlobal, Me.colRFolioFacturaGlobal, Me.colRUUIDFacturaGlobal, Me.colRFormaPagoSAT, Me.colRCodigoSAT, Me.colRDescripcionSAT, Me.colRImporteFacturar, Me.colRTipoFactura, Me.colREstatus})
        Me.dgvResultado.GridColor = System.Drawing.Color.White
        Me.dgvResultado.Location = New System.Drawing.Point(8, 63)
        Me.dgvResultado.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvResultado.MultiSelect = False
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.RowHeadersVisible = False
        Me.dgvResultado.Size = New System.Drawing.Size(412, 166)
        Me.dgvResultado.TabIndex = 28
        '
        'colRSel
        '
        Me.colRSel.DataPropertyName = "Sel"
        Me.colRSel.HeaderText = ""
        Me.colRSel.Name = "colRSel"
        Me.colRSel.Width = 30
        '
        'colRFecha
        '
        Me.colRFecha.DataPropertyName = "Fecha"
        Me.colRFecha.HeaderText = "Fecha"
        Me.colRFecha.Name = "colRFecha"
        Me.colRFecha.ReadOnly = True
        Me.colRFecha.Width = 70
        '
        'colRTipo
        '
        Me.colRTipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRTipo.DefaultCellStyle = DataGridViewCellStyle21
        Me.colRTipo.HeaderText = "Tipo"
        Me.colRTipo.Name = "colRTipo"
        Me.colRTipo.Width = 60
        '
        'colRPrefijo
        '
        Me.colRPrefijo.DataPropertyName = "Prefijo"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colRPrefijo.DefaultCellStyle = DataGridViewCellStyle22
        Me.colRPrefijo.HeaderText = "Prefijo"
        Me.colRPrefijo.Name = "colRPrefijo"
        Me.colRPrefijo.Width = 50
        '
        'colRNoTicket
        '
        Me.colRNoTicket.DataPropertyName = "NoTicket"
        Me.colRNoTicket.HeaderText = "Folio"
        Me.colRNoTicket.Name = "colRNoTicket"
        Me.colRNoTicket.ReadOnly = True
        Me.colRNoTicket.Width = 70
        '
        'colRTipoMov
        '
        Me.colRTipoMov.DataPropertyName = "TipoMov"
        Me.colRTipoMov.HeaderText = "Movimiento"
        Me.colRTipoMov.Name = "colRTipoMov"
        Me.colRTipoMov.ReadOnly = True
        Me.colRTipoMov.Width = 177
        '
        'colRImportePago
        '
        Me.colRImportePago.DataPropertyName = "ImportePagado"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.Format = "C2"
        DataGridViewCellStyle23.NullValue = Nothing
        Me.colRImportePago.DefaultCellStyle = DataGridViewCellStyle23
        Me.colRImportePago.HeaderText = "Importe"
        Me.colRImportePago.Name = "colRImportePago"
        Me.colRImportePago.ReadOnly = True
        '
        'colRCosto
        '
        Me.colRCosto.DataPropertyName = "Costo"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle24.Format = "C2"
        DataGridViewCellStyle24.NullValue = Nothing
        Me.colRCosto.DefaultCellStyle = DataGridViewCellStyle24
        Me.colRCosto.HeaderText = "Costo"
        Me.colRCosto.Name = "colRCosto"
        Me.colRCosto.ReadOnly = True
        Me.colRCosto.Width = 80
        '
        'colRDescuento
        '
        Me.colRDescuento.DataPropertyName = "Descuento"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle25.Format = "C2"
        DataGridViewCellStyle25.NullValue = Nothing
        Me.colRDescuento.DefaultCellStyle = DataGridViewCellStyle25
        Me.colRDescuento.HeaderText = "Descuento"
        Me.colRDescuento.Name = "colRDescuento"
        Me.colRDescuento.ReadOnly = True
        Me.colRDescuento.Width = 80
        '
        'colRImporte
        '
        Me.colRImporte.DataPropertyName = "Importe"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle26.Format = "C2"
        DataGridViewCellStyle26.NullValue = Nothing
        Me.colRImporte.DefaultCellStyle = DataGridViewCellStyle26
        Me.colRImporte.HeaderText = "Utilidad"
        Me.colRImporte.Name = "colRImporte"
        Me.colRImporte.ReadOnly = True
        Me.colRImporte.Width = 80
        '
        'colRInteres
        '
        Me.colRInteres.DataPropertyName = "Interes"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle27.Format = "C2"
        DataGridViewCellStyle27.NullValue = Nothing
        Me.colRInteres.DefaultCellStyle = DataGridViewCellStyle27
        Me.colRInteres.HeaderText = "Interes"
        Me.colRInteres.Name = "colRInteres"
        Me.colRInteres.ReadOnly = True
        Me.colRInteres.Width = 80
        '
        'colRRecargo
        '
        Me.colRRecargo.DataPropertyName = "Recargo"
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle28.Format = "C2"
        DataGridViewCellStyle28.NullValue = Nothing
        Me.colRRecargo.DefaultCellStyle = DataGridViewCellStyle28
        Me.colRRecargo.HeaderText = "Recargo"
        Me.colRRecargo.Name = "colRRecargo"
        Me.colRRecargo.ReadOnly = True
        Me.colRRecargo.Width = 80
        '
        'colRIVA
        '
        Me.colRIVA.DataPropertyName = "IVA"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle29.Format = "C2"
        DataGridViewCellStyle29.NullValue = Nothing
        Me.colRIVA.DefaultCellStyle = DataGridViewCellStyle29
        Me.colRIVA.HeaderText = "IVA"
        Me.colRIVA.Name = "colRIVA"
        Me.colRIVA.ReadOnly = True
        Me.colRIVA.Width = 80
        '
        'colRConcepto
        '
        Me.colRConcepto.DataPropertyName = "Concepto"
        Me.colRConcepto.HeaderText = "Concepto"
        Me.colRConcepto.Name = "colRConcepto"
        Me.colRConcepto.ReadOnly = True
        Me.colRConcepto.Visible = False
        '
        'colRSerieFacturaGlobal
        '
        Me.colRSerieFacturaGlobal.DataPropertyName = "SerieFacturaGlobal"
        Me.colRSerieFacturaGlobal.HeaderText = "SerieFacturaGlobal"
        Me.colRSerieFacturaGlobal.Name = "colRSerieFacturaGlobal"
        Me.colRSerieFacturaGlobal.ReadOnly = True
        Me.colRSerieFacturaGlobal.Visible = False
        '
        'colRFolioFacturaGlobal
        '
        Me.colRFolioFacturaGlobal.DataPropertyName = "FolioFacturaGlobal"
        Me.colRFolioFacturaGlobal.HeaderText = "FolioFacturaGlobal"
        Me.colRFolioFacturaGlobal.Name = "colRFolioFacturaGlobal"
        Me.colRFolioFacturaGlobal.ReadOnly = True
        Me.colRFolioFacturaGlobal.Visible = False
        '
        'colRUUIDFacturaGlobal
        '
        Me.colRUUIDFacturaGlobal.DataPropertyName = "UUIDFacturaGlobal"
        Me.colRUUIDFacturaGlobal.HeaderText = "UUIDFacturaGlobal"
        Me.colRUUIDFacturaGlobal.Name = "colRUUIDFacturaGlobal"
        Me.colRUUIDFacturaGlobal.ReadOnly = True
        Me.colRUUIDFacturaGlobal.Visible = False
        '
        'colRFormaPagoSAT
        '
        Me.colRFormaPagoSAT.DataPropertyName = "FormaPagoSAT"
        Me.colRFormaPagoSAT.HeaderText = "FormaPagoSAT"
        Me.colRFormaPagoSAT.Name = "colRFormaPagoSAT"
        Me.colRFormaPagoSAT.Visible = False
        '
        'colRCodigoSAT
        '
        Me.colRCodigoSAT.DataPropertyName = "ClaveSAT"
        Me.colRCodigoSAT.HeaderText = "CodigoSAT"
        Me.colRCodigoSAT.Name = "colRCodigoSAT"
        Me.colRCodigoSAT.Visible = False
        '
        'colRDescripcionSAT
        '
        Me.colRDescripcionSAT.DataPropertyName = "DescripcionSAT"
        Me.colRDescripcionSAT.HeaderText = "DescripcionSAT"
        Me.colRDescripcionSAT.Name = "colRDescripcionSAT"
        Me.colRDescripcionSAT.Visible = False
        '
        'colRImporteFacturar
        '
        Me.colRImporteFacturar.DataPropertyName = "Total"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle30.Format = "C2"
        DataGridViewCellStyle30.NullValue = Nothing
        Me.colRImporteFacturar.DefaultCellStyle = DataGridViewCellStyle30
        Me.colRImporteFacturar.HeaderText = "Importe a Facturar"
        Me.colRImporteFacturar.Name = "colRImporteFacturar"
        Me.colRImporteFacturar.ReadOnly = True
        Me.colRImporteFacturar.Visible = False
        Me.colRImporteFacturar.Width = 80
        '
        'colRTipoFactura
        '
        Me.colRTipoFactura.DataPropertyName = "TipoFactura"
        Me.colRTipoFactura.HeaderText = "TipoFactura"
        Me.colRTipoFactura.Name = "colRTipoFactura"
        Me.colRTipoFactura.ReadOnly = True
        Me.colRTipoFactura.Visible = False
        '
        'colREstatus
        '
        Me.colREstatus.DataPropertyName = "Estatus"
        Me.colREstatus.HeaderText = "Estatus"
        Me.colREstatus.Name = "colREstatus"
        Me.colREstatus.Visible = False
        '
        'cboInclDirCte
        '
        Me.cboInclDirCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInclDirCte.Enabled = False
        Me.cboInclDirCte.FormattingEnabled = True
        Me.cboInclDirCte.Items.AddRange(New Object() {"NO", "SI"})
        Me.cboInclDirCte.Location = New System.Drawing.Point(198, 353)
        Me.cboInclDirCte.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInclDirCte.Name = "cboInclDirCte"
        Me.cboInclDirCte.Size = New System.Drawing.Size(63, 21)
        Me.cboInclDirCte.TabIndex = 15
        '
        'cboInclDirSuc
        '
        Me.cboInclDirSuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInclDirSuc.FormattingEnabled = True
        Me.cboInclDirSuc.Items.AddRange(New Object() {"NO", "SI"})
        Me.cboInclDirSuc.Location = New System.Drawing.Point(198, 324)
        Me.cboInclDirSuc.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInclDirSuc.Name = "cboInclDirSuc"
        Me.cboInclDirSuc.Size = New System.Drawing.Size(63, 21)
        Me.cboInclDirSuc.TabIndex = 16
        '
        'frmNotasCreditovb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(631, 252)
        Me.Controls.Add(Me.cboInclDirCte)
        Me.Controls.Add(Me.cboInclDirSuc)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNotasCreditovb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Notas de Credito"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents colRSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colRFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRPrefijo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRNoTicket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRTipoMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRImportePago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRDescuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRRecargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRIVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRSerieFacturaGlobal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRFolioFacturaGlobal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRUUIDFacturaGlobal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRFormaPagoSAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRCodigoSAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRDescripcionSAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRImporteFacturar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRTipoFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colREstatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTextoAnuncio As System.Windows.Forms.Label
    Friend WithEvents cboInclDirCte As System.Windows.Forms.ComboBox
    Friend WithEvents cboInclDirSuc As System.Windows.Forms.ComboBox
End Class

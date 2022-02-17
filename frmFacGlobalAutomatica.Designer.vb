<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacGlobalAutomatica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacGlobalAutomatica))
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.cboInclDirCte = New System.Windows.Forms.ComboBox()
        Me.cboInclDirSuc = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(4, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 244)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 32)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(640, 199)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(601, 164)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "C"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
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
        Me.dgvLista.Location = New System.Drawing.Point(4, 271)
        Me.dgvLista.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.ReadOnly = True
        Me.dgvLista.RowHeadersVisible = False
        Me.dgvLista.Size = New System.Drawing.Size(660, 59)
        Me.dgvLista.TabIndex = 4
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
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(4, 337)
        Me.dtpFechaIni.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(116, 22)
        Me.dtpFechaIni.TabIndex = 8
        Me.dtpFechaIni.Visible = False
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(129, 337)
        Me.dtpFechaFin.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(116, 22)
        Me.dtpFechaFin.TabIndex = 9
        Me.dtpFechaFin.Visible = False
        '
        'cboInclDirCte
        '
        Me.cboInclDirCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInclDirCte.Enabled = False
        Me.cboInclDirCte.FormattingEnabled = True
        Me.cboInclDirCte.Items.AddRange(New Object() {"NO", "SI"})
        Me.cboInclDirCte.Location = New System.Drawing.Point(327, 336)
        Me.cboInclDirCte.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInclDirCte.Name = "cboInclDirCte"
        Me.cboInclDirCte.Size = New System.Drawing.Size(63, 24)
        Me.cboInclDirCte.TabIndex = 15
        Me.cboInclDirCte.Visible = False
        '
        'cboInclDirSuc
        '
        Me.cboInclDirSuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInclDirSuc.FormattingEnabled = True
        Me.cboInclDirSuc.Items.AddRange(New Object() {"NO", "SI"})
        Me.cboInclDirSuc.Location = New System.Drawing.Point(255, 336)
        Me.cboInclDirSuc.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInclDirSuc.Name = "cboInclDirSuc"
        Me.cboInclDirSuc.Size = New System.Drawing.Size(63, 24)
        Me.cboInclDirSuc.TabIndex = 16
        Me.cboInclDirSuc.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 300000
        '
        'frmFacGlobalAutomatica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(668, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboInclDirCte)
        Me.Controls.Add(Me.cboInclDirSuc)
        Me.Controls.Add(Me.dtpFechaIni)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.dgvLista)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmFacGlobalAutomatica"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factura Global Diaria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
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
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboInclDirCte As System.Windows.Forms.ComboBox
    Friend WithEvents cboInclDirSuc As System.Windows.Forms.ComboBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

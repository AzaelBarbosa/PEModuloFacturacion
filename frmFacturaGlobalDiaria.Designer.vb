<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaGlobalDiaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaGlobalDiaria))
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
        Me.txtRespuesta = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTextoAnuncio = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.txtCantPartidas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalFactura = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboInclDirCte = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboInclDirSuc = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGenerarFactura = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnBuscarMovimientos = New System.Windows.Forms.Button()
        Me.btnExportaExcel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.picCBB = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCBB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRespuesta
        '
        Me.txtRespuesta.Location = New System.Drawing.Point(448, 562)
        Me.txtRespuesta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRespuesta.Multiline = True
        Me.txtRespuesta.Name = "txtRespuesta"
        Me.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRespuesta.Size = New System.Drawing.Size(137, 29)
        Me.txtRespuesta.TabIndex = 9
        Me.txtRespuesta.Text = "Para ver el XML"
        Me.txtRespuesta.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(800, 562)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(84, 22)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(704, 562)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(84, 22)
        Me.TextBox2.TabIndex = 12
        Me.TextBox2.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.lblTextoAnuncio)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.dgvLista)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1023, 512)
        Me.Panel1.TabIndex = 17
        '
        'lblTextoAnuncio
        '
        Me.lblTextoAnuncio.BackColor = System.Drawing.Color.Transparent
        Me.lblTextoAnuncio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoAnuncio.ForeColor = System.Drawing.Color.Blue
        Me.lblTextoAnuncio.Location = New System.Drawing.Point(36, 236)
        Me.lblTextoAnuncio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTextoAnuncio.Name = "lblTextoAnuncio"
        Me.lblTextoAnuncio.Size = New System.Drawing.Size(703, 49)
        Me.lblTextoAnuncio.TabIndex = 18
        Me.lblTextoAnuncio.Text = "Extrayendo datos de facturación..."
        Me.lblTextoAnuncio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoAnuncio.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFolio)
        Me.GroupBox3.Controls.Add(Me.txtCantPartidas)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtDescuento)
        Me.GroupBox3.Controls.Add(Me.txtSubTotal)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtIVA)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtTotalFactura)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cboInclDirCte)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cboInclDirSuc)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 364)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(757, 138)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(320, 20)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(180, 22)
        Me.txtFolio.TabIndex = 11
        Me.txtFolio.Visible = False
        '
        'txtCantPartidas
        '
        Me.txtCantPartidas.BackColor = System.Drawing.Color.White
        Me.txtCantPartidas.Location = New System.Drawing.Point(85, 20)
        Me.txtCantPartidas.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantPartidas.Name = "txtCantPartidas"
        Me.txtCantPartidas.ReadOnly = True
        Me.txtCantPartidas.Size = New System.Drawing.Size(73, 22)
        Me.txtCantPartidas.TabIndex = 5
        Me.txtCantPartidas.Text = "0"
        Me.txtCantPartidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(576, 108)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "TOTAL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.White
        Me.txtDescuento.Location = New System.Drawing.Point(640, 49)
        Me.txtDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(105, 22)
        Me.txtDescuento.TabIndex = 5
        Me.txtDescuento.Text = "$ 0.00"
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.Color.White
        Me.txtSubTotal.Location = New System.Drawing.Point(640, 20)
        Me.txtSubTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(105, 22)
        Me.txtSubTotal.TabIndex = 5
        Me.txtSubTotal.Text = "$ 0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(587, 79)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "I.V.A.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.White
        Me.txtIVA.Location = New System.Drawing.Point(640, 79)
        Me.txtIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(105, 22)
        Me.txtIVA.TabIndex = 5
        Me.txtIVA.Text = "$ 0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(544, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "SUBTOTAL:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 69)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(285, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Incluir dirección de la sucursal en la factura:"
        '
        'txtTotalFactura
        '
        Me.txtTotalFactura.BackColor = System.Drawing.Color.White
        Me.txtTotalFactura.Location = New System.Drawing.Point(640, 108)
        Me.txtTotalFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalFactura.Name = "txtTotalFactura"
        Me.txtTotalFactura.ReadOnly = True
        Me.txtTotalFactura.Size = New System.Drawing.Size(105, 22)
        Me.txtTotalFactura.TabIndex = 5
        Me.txtTotalFactura.Text = "$ 0.00"
        Me.txtTotalFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(533, 49)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 17)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "DESCUENTO:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 98)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(261, 17)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Incluir dirección del cliente en la factura:"
        '
        'cboInclDirCte
        '
        Me.cboInclDirCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInclDirCte.Enabled = False
        Me.cboInclDirCte.FormattingEnabled = True
        Me.cboInclDirCte.Items.AddRange(New Object() {"NO", "SI"})
        Me.cboInclDirCte.Location = New System.Drawing.Point(320, 98)
        Me.cboInclDirCte.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInclDirCte.Name = "cboInclDirCte"
        Me.cboInclDirCte.Size = New System.Drawing.Size(63, 24)
        Me.cboInclDirCte.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(213, 20)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Folio Factura:"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Partidas:"
        '
        'cboInclDirSuc
        '
        Me.cboInclDirSuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInclDirSuc.FormattingEnabled = True
        Me.cboInclDirSuc.Items.AddRange(New Object() {"NO", "SI"})
        Me.cboInclDirSuc.Location = New System.Drawing.Point(320, 69)
        Me.cboInclDirSuc.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInclDirSuc.Name = "cboInclDirSuc"
        Me.cboInclDirSuc.Size = New System.Drawing.Size(63, 24)
        Me.cboInclDirSuc.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimpiar)
        Me.GroupBox2.Controls.Add(Me.btnGenerarFactura)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Controls.Add(Me.btnBuscarMovimientos)
        Me.GroupBox2.Controls.Add(Me.btnExportaExcel)
        Me.GroupBox2.Location = New System.Drawing.Point(779, 30)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(230, 473)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = Global.PEFacturacion.My.Resources.Resources.btnnuevo
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(11, 20)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(208, 46)
        Me.btnLimpiar.TabIndex = 20
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnGenerarFactura
        '
        Me.btnGenerarFactura.BackColor = System.Drawing.Color.White
        Me.btnGenerarFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerarFactura.Image = Global.PEFacturacion.My.Resources.Resources.factura
        Me.btnGenerarFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerarFactura.Location = New System.Drawing.Point(11, 182)
        Me.btnGenerarFactura.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerarFactura.Name = "btnGenerarFactura"
        Me.btnGenerarFactura.Size = New System.Drawing.Size(208, 46)
        Me.btnGenerarFactura.TabIndex = 6
        Me.btnGenerarFactura.Text = "Facturar"
        Me.btnGenerarFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGenerarFactura.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.White
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCerrar.Image = Global.PEFacturacion.My.Resources.Resources.cerrar
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(11, 238)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(208, 46)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "Salir"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'btnBuscarMovimientos
        '
        Me.btnBuscarMovimientos.BackColor = System.Drawing.Color.White
        Me.btnBuscarMovimientos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarMovimientos.Image = Global.PEFacturacion.My.Resources.Resources.Buscar
        Me.btnBuscarMovimientos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarMovimientos.Location = New System.Drawing.Point(11, 74)
        Me.btnBuscarMovimientos.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscarMovimientos.Name = "btnBuscarMovimientos"
        Me.btnBuscarMovimientos.Size = New System.Drawing.Size(208, 46)
        Me.btnBuscarMovimientos.TabIndex = 2
        Me.btnBuscarMovimientos.Text = "Buscar"
        Me.btnBuscarMovimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscarMovimientos.UseVisualStyleBackColor = False
        '
        'btnExportaExcel
        '
        Me.btnExportaExcel.BackColor = System.Drawing.Color.White
        Me.btnExportaExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportaExcel.Image = Global.PEFacturacion.My.Resources.Resources.excel
        Me.btnExportaExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportaExcel.Location = New System.Drawing.Point(11, 128)
        Me.btnExportaExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExportaExcel.Name = "btnExportaExcel"
        Me.btnExportaExcel.Size = New System.Drawing.Size(208, 46)
        Me.btnExportaExcel.TabIndex = 15
        Me.btnExportaExcel.Text = "Excel"
        Me.btnExportaExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportaExcel.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaIni)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 30)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(757, 54)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(224, 20)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 17)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Desde:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Movimientos: "
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(320, 20)
        Me.dtpFechaIni.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(116, 22)
        Me.dtpFechaIni.TabIndex = 7
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(597, 20)
        Me.dtpFechaFin.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(116, 22)
        Me.dtpFechaFin.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(512, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Hasta:"
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
        Me.dgvLista.Location = New System.Drawing.Point(11, 89)
        Me.dgvLista.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvLista.Name = "dgvLista"
        Me.dgvLista.ReadOnly = True
        Me.dgvLista.RowHeadersVisible = False
        Me.dgvLista.Size = New System.Drawing.Size(757, 276)
        Me.dgvLista.TabIndex = 3
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
        'picCBB
        '
        Me.picCBB.BackColor = System.Drawing.Color.White
        Me.picCBB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picCBB.Location = New System.Drawing.Point(597, 562)
        Me.picCBB.Margin = New System.Windows.Forms.Padding(4)
        Me.picCBB.Name = "picCBB"
        Me.picCBB.Size = New System.Drawing.Size(85, 39)
        Me.picCBB.TabIndex = 10
        Me.picCBB.TabStop = False
        Me.picCBB.Visible = False
        '
        'frmFacturaGlobalDiaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1042, 530)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtRespuesta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picCBB)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmFacturaGlobalDiaria"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factura Global Diaria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCBB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarMovimientos As System.Windows.Forms.Button
    Friend WithEvents dgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFactura As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerarFactura As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtRespuesta As System.Windows.Forms.TextBox
    Friend WithEvents picCBB As System.Windows.Forms.PictureBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCantPartidas As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboInclDirSuc As System.Windows.Forms.ComboBox
    Friend WithEvents cboInclDirCte As System.Windows.Forms.ComboBox
    Friend WithEvents btnExportaExcel As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblTextoAnuncio As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
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
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManejoFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManejoFactura))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvResultadoFact = New System.Windows.Forms.DataGridView()
        Me.colSel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFolio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcuse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colArchivoPDF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colArchivoXML = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCorreo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRFC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUUID = New System.Windows.Forms.TextBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.chbxUUID = New System.Windows.Forms.CheckBox()
        Me.chbxFolio = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.chbxFechas = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnNotasCredito = New System.Windows.Forms.Button()
        Me.btnSustitucion = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnExportaExcel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnVerXMLAcuse = New System.Windows.Forms.Button()
        Me.btnVerPDFAcuse = New System.Windows.Forms.Button()
        Me.btnVerPDF = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnVerXML = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEnviarEmail = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCancelaFac = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.cmdActivar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvResultadoFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Location = New System.Drawing.Point(2, 6)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(710, 510)
        Me.Panel1.TabIndex = 24
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvResultadoFact)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 134)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 361)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resultado de la Busqueda"
        '
        'dgvResultadoFact
        '
        Me.dgvResultadoFact.AllowUserToAddRows = False
        Me.dgvResultadoFact.AllowUserToDeleteRows = False
        Me.dgvResultadoFact.BackgroundColor = System.Drawing.Color.White
        Me.dgvResultadoFact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultadoFact.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSel, Me.colFecha, Me.colFolio, Me.colSerie, Me.colEstatus, Me.colAcuse, Me.colTipo, Me.colTipoComprobante, Me.colImporte, Me.colUUID, Me.colArchivoPDF, Me.colArchivoXML, Me.colCorreo, Me.colNoCliente, Me.colRFC})
        Me.dgvResultadoFact.GridColor = System.Drawing.Color.White
        Me.dgvResultadoFact.Location = New System.Drawing.Point(8, 16)
        Me.dgvResultadoFact.Name = "dgvResultadoFact"
        Me.dgvResultadoFact.RowHeadersVisible = False
        Me.dgvResultadoFact.Size = New System.Drawing.Size(474, 294)
        Me.dgvResultadoFact.TabIndex = 12
        '
        'colSel
        '
        Me.colSel.HeaderText = ""
        Me.colSel.Name = "colSel"
        Me.colSel.Width = 30
        '
        'colFecha
        '
        Me.colFecha.DataPropertyName = "FechaFactura"
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 60
        '
        'colFolio
        '
        Me.colFolio.DataPropertyName = "Folio"
        Me.colFolio.HeaderText = "Folio"
        Me.colFolio.Name = "colFolio"
        Me.colFolio.ReadOnly = True
        Me.colFolio.Width = 70
        '
        'colSerie
        '
        Me.colSerie.DataPropertyName = "Serie"
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.ReadOnly = True
        Me.colSerie.Width = 40
        '
        'colEstatus
        '
        Me.colEstatus.DataPropertyName = "Estatus"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colEstatus.DefaultCellStyle = DataGridViewCellStyle1
        Me.colEstatus.HeaderText = "Estatus"
        Me.colEstatus.Name = "colEstatus"
        Me.colEstatus.Width = 45
        '
        'colAcuse
        '
        Me.colAcuse.DataPropertyName = "Acuse"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colAcuse.DefaultCellStyle = DataGridViewCellStyle2
        Me.colAcuse.HeaderText = "Acuse"
        Me.colAcuse.Name = "colAcuse"
        Me.colAcuse.Width = 40
        '
        'colTipo
        '
        Me.colTipo.DataPropertyName = "TipoFactura"
        Me.colTipo.HeaderText = "Comprobante"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 75
        '
        'colTipoComprobante
        '
        Me.colTipoComprobante.DataPropertyName = "TipoComprobante"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTipoComprobante.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTipoComprobante.HeaderText = "Tipo"
        Me.colTipoComprobante.Name = "colTipoComprobante"
        Me.colTipoComprobante.Width = 40
        '
        'colImporte
        '
        Me.colImporte.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colImporte.DefaultCellStyle = DataGridViewCellStyle4
        Me.colImporte.HeaderText = "Importe"
        Me.colImporte.Name = "colImporte"
        Me.colImporte.ReadOnly = True
        Me.colImporte.Width = 115
        '
        'colUUID
        '
        Me.colUUID.DataPropertyName = "FolioFiscal"
        Me.colUUID.HeaderText = "UUID"
        Me.colUUID.Name = "colUUID"
        Me.colUUID.ReadOnly = True
        Me.colUUID.Width = 240
        '
        'colArchivoPDF
        '
        Me.colArchivoPDF.DataPropertyName = "NombreArchivoPDF"
        Me.colArchivoPDF.HeaderText = "ArchivoPDF"
        Me.colArchivoPDF.Name = "colArchivoPDF"
        Me.colArchivoPDF.Visible = False
        Me.colArchivoPDF.Width = 150
        '
        'colArchivoXML
        '
        Me.colArchivoXML.DataPropertyName = "NombreArchivoXML"
        Me.colArchivoXML.HeaderText = "ArchivoXML"
        Me.colArchivoXML.Name = "colArchivoXML"
        Me.colArchivoXML.Visible = False
        Me.colArchivoXML.Width = 150
        '
        'colCorreo
        '
        Me.colCorreo.DataPropertyName = "CorreoE"
        Me.colCorreo.HeaderText = "Correo"
        Me.colCorreo.Name = "colCorreo"
        Me.colCorreo.Width = 200
        '
        'colNoCliente
        '
        Me.colNoCliente.DataPropertyName = "NoCliente"
        Me.colNoCliente.HeaderText = "NoCliente"
        Me.colNoCliente.Name = "colNoCliente"
        Me.colNoCliente.Visible = False
        Me.colNoCliente.Width = 80
        '
        'colRFC
        '
        Me.colRFC.DataPropertyName = "RFC"
        Me.colRFC.HeaderText = "RFC"
        Me.colRFC.Name = "colRFC"
        Me.colRFC.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCancelar)
        Me.GroupBox1.Controls.Add(Me.cmdActivar)
        Me.GroupBox1.Controls.Add(Me.txtUUID)
        Me.GroupBox1.Controls.Add(Me.txtFolio)
        Me.GroupBox1.Controls.Add(Me.chbxUUID)
        Me.GroupBox1.Controls.Add(Me.chbxFolio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpFechaIni)
        Me.GroupBox1.Controls.Add(Me.chbxFechas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 96)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones de Busqueda"
        '
        'txtUUID
        '
        Me.txtUUID.Enabled = False
        Me.txtUUID.Location = New System.Drawing.Point(88, 70)
        Me.txtUUID.MaxLength = 40
        Me.txtUUID.Name = "txtUUID"
        Me.txtUUID.Size = New System.Drawing.Size(394, 20)
        Me.txtUUID.TabIndex = 7
        '
        'txtFolio
        '
        Me.txtFolio.Enabled = False
        Me.txtFolio.Location = New System.Drawing.Point(88, 44)
        Me.txtFolio.MaxLength = 20
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(184, 20)
        Me.txtFolio.TabIndex = 6
        '
        'chbxUUID
        '
        Me.chbxUUID.AutoSize = True
        Me.chbxUUID.Location = New System.Drawing.Point(16, 73)
        Me.chbxUUID.Name = "chbxUUID"
        Me.chbxUUID.Size = New System.Drawing.Size(56, 17)
        Me.chbxUUID.TabIndex = 3
        Me.chbxUUID.Text = "UUID:"
        Me.chbxUUID.UseVisualStyleBackColor = True
        '
        'chbxFolio
        '
        Me.chbxFolio.AutoSize = True
        Me.chbxFolio.Location = New System.Drawing.Point(16, 47)
        Me.chbxFolio.Name = "chbxFolio"
        Me.chbxFolio.Size = New System.Drawing.Size(51, 17)
        Me.chbxFolio.TabIndex = 2
        Me.chbxFolio.Text = "Folio:"
        Me.chbxFolio.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(226, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Hasta"
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Enabled = False
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(132, 19)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(88, 20)
        Me.dtpFechaIni.TabIndex = 4
        Me.dtpFechaIni.Value = New Date(2019, 2, 27, 0, 0, 0, 0)
        '
        'chbxFechas
        '
        Me.chbxFechas.AutoSize = True
        Me.chbxFechas.Location = New System.Drawing.Point(16, 23)
        Me.chbxFechas.Name = "chbxFechas"
        Me.chbxFechas.Size = New System.Drawing.Size(64, 17)
        Me.chbxFechas.TabIndex = 1
        Me.chbxFechas.Text = "Fechas:"
        Me.chbxFechas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Desde"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(279, 19)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(88, 20)
        Me.dtpFechaFin.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnNotasCredito)
        Me.GroupBox3.Controls.Add(Me.btnSustitucion)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.btnExportaExcel)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.btnVerXMLAcuse)
        Me.GroupBox3.Controls.Add(Me.btnVerPDFAcuse)
        Me.GroupBox3.Controls.Add(Me.btnVerPDF)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.btnVerXML)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.btnEnviarEmail)
        Me.GroupBox3.Controls.Add(Me.btnBuscar)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.btnCerrar)
        Me.GroupBox3.Controls.Add(Me.btnCancelaFac)
        Me.GroupBox3.Controls.Add(Me.btnLimpiar)
        Me.GroupBox3.Location = New System.Drawing.Point(510, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(175, 475)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        '
        'btnNotasCredito
        '
        Me.btnNotasCredito.BackColor = System.Drawing.Color.White
        Me.btnNotasCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNotasCredito.Image = Global.PEFacturacion.My.Resources.Resources.factura
        Me.btnNotasCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNotasCredito.Location = New System.Drawing.Point(9, 386)
        Me.btnNotasCredito.Name = "btnNotasCredito"
        Me.btnNotasCredito.Size = New System.Drawing.Size(156, 37)
        Me.btnNotasCredito.TabIndex = 62
        Me.btnNotasCredito.Text = "  Notas de Credito"
        Me.btnNotasCredito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNotasCredito.UseVisualStyleBackColor = False
        '
        'btnSustitucion
        '
        Me.btnSustitucion.BackColor = System.Drawing.Color.White
        Me.btnSustitucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSustitucion.Image = Global.PEFacturacion.My.Resources.Resources.cambio
        Me.btnSustitucion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSustitucion.Location = New System.Drawing.Point(9, 346)
        Me.btnSustitucion.Name = "btnSustitucion"
        Me.btnSustitucion.Size = New System.Drawing.Size(156, 37)
        Me.btnSustitucion.TabIndex = 61
        Me.btnSustitucion.Text = "  Sustituir Factura"
        Me.btnSustitucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSustitucion.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(137, 370)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Exportar"
        Me.Label12.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(101, 371)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Ver XML Acuse"
        Me.Label8.Visible = False
        '
        'btnExportaExcel
        '
        Me.btnExportaExcel.BackColor = System.Drawing.Color.White
        Me.btnExportaExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExportaExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportaExcel.Image = Global.PEFacturacion.My.Resources.Resources.excel
        Me.btnExportaExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportaExcel.Location = New System.Drawing.Point(9, 124)
        Me.btnExportaExcel.Name = "btnExportaExcel"
        Me.btnExportaExcel.Size = New System.Drawing.Size(156, 37)
        Me.btnExportaExcel.TabIndex = 59
        Me.btnExportaExcel.Text = "  Exportar Excel"
        Me.btnExportaExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExportaExcel.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(103, 370)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Ver PDF Acuse"
        Me.Label6.Visible = False
        '
        'btnVerXMLAcuse
        '
        Me.btnVerXMLAcuse.BackColor = System.Drawing.Color.White
        Me.btnVerXMLAcuse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnVerXMLAcuse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerXMLAcuse.Image = Global.PEFacturacion.My.Resources.Resources.XMLAcuse
        Me.btnVerXMLAcuse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerXMLAcuse.Location = New System.Drawing.Point(9, 310)
        Me.btnVerXMLAcuse.Name = "btnVerXMLAcuse"
        Me.btnVerXMLAcuse.Size = New System.Drawing.Size(156, 37)
        Me.btnVerXMLAcuse.TabIndex = 56
        Me.btnVerXMLAcuse.Text = "  Ver Acuse XML"
        Me.btnVerXMLAcuse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVerXMLAcuse.UseVisualStyleBackColor = False
        '
        'btnVerPDFAcuse
        '
        Me.btnVerPDFAcuse.BackColor = System.Drawing.Color.White
        Me.btnVerPDFAcuse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnVerPDFAcuse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerPDFAcuse.Image = Global.PEFacturacion.My.Resources.Resources.PDFAcuse
        Me.btnVerPDFAcuse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerPDFAcuse.Location = New System.Drawing.Point(9, 272)
        Me.btnVerPDFAcuse.Name = "btnVerPDFAcuse"
        Me.btnVerPDFAcuse.Size = New System.Drawing.Size(156, 37)
        Me.btnVerPDFAcuse.TabIndex = 55
        Me.btnVerPDFAcuse.Text = "  Ver Acuse PDF"
        Me.btnVerPDFAcuse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVerPDFAcuse.UseVisualStyleBackColor = False
        '
        'btnVerPDF
        '
        Me.btnVerPDF.BackColor = System.Drawing.Color.White
        Me.btnVerPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnVerPDF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerPDF.Image = Global.PEFacturacion.My.Resources.Resources.pdf
        Me.btnVerPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerPDF.Location = New System.Drawing.Point(9, 162)
        Me.btnVerPDF.Name = "btnVerPDF"
        Me.btnVerPDF.Size = New System.Drawing.Size(156, 37)
        Me.btnVerPDF.TabIndex = 54
        Me.btnVerPDF.Text = "  Ver PDF"
        Me.btnVerPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVerPDF.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(134, 370)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Ver XML"
        Me.Label5.Visible = False
        '
        'btnVerXML
        '
        Me.btnVerXML.BackColor = System.Drawing.Color.White
        Me.btnVerXML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnVerXML.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerXML.Image = Global.PEFacturacion.My.Resources.Resources.xml
        Me.btnVerXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerXML.Location = New System.Drawing.Point(9, 198)
        Me.btnVerXML.Name = "btnVerXML"
        Me.btnVerXML.Size = New System.Drawing.Size(156, 37)
        Me.btnVerXML.TabIndex = 52
        Me.btnVerXML.Text = "  Ver XML"
        Me.btnVerXML.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVerXML.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(134, 371)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Ver PDF"
        Me.Label4.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Enviar"
        Me.Label2.Visible = False
        '
        'btnEnviarEmail
        '
        Me.btnEnviarEmail.BackColor = System.Drawing.Color.White
        Me.btnEnviarEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnviarEmail.Image = Global.PEFacturacion.My.Resources.Resources.correo
        Me.btnEnviarEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviarEmail.Location = New System.Drawing.Point(9, 87)
        Me.btnEnviarEmail.Name = "btnEnviarEmail"
        Me.btnEnviarEmail.Size = New System.Drawing.Size(156, 37)
        Me.btnEnviarEmail.TabIndex = 48
        Me.btnEnviarEmail.Text = "  Enviar Correo"
        Me.btnEnviarEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnviarEmail.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.White
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = Global.PEFacturacion.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(9, 50)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(156, 37)
        Me.btnBuscar.TabIndex = 9
        Me.btnBuscar.Text = "  Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(80, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Buscar"
        Me.Label7.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(148, 370)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Cerrar"
        Me.Label20.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(101, 371)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 13)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Cancelar Factura"
        Me.Label19.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 71)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Limpiar"
        Me.Label18.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = Global.PEFacturacion.My.Resources.Resources.cerrar
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(9, 427)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(156, 37)
        Me.btnCerrar.TabIndex = 11
        Me.btnCerrar.Text = "  Salir"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCancelaFac
        '
        Me.btnCancelaFac.BackColor = System.Drawing.Color.White
        Me.btnCancelaFac.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelaFac.Image = Global.PEFacturacion.My.Resources.Resources.CancelarDoc
        Me.btnCancelaFac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelaFac.Location = New System.Drawing.Point(9, 236)
        Me.btnCancelaFac.Name = "btnCancelaFac"
        Me.btnCancelaFac.Size = New System.Drawing.Size(156, 37)
        Me.btnCancelaFac.TabIndex = 10
        Me.btnCancelaFac.Text = "  Cancelar Factura"
        Me.btnCancelaFac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelaFac.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = Global.PEFacturacion.My.Resources.Resources.Limpiar
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(9, 13)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(156, 37)
        Me.btnLimpiar.TabIndex = 8
        Me.btnLimpiar.Text = "  Limpiar"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'cmdActivar
        '
        Me.cmdActivar.Location = New System.Drawing.Point(422, 27)
        Me.cmdActivar.Name = "cmdActivar"
        Me.cmdActivar.Size = New System.Drawing.Size(26, 23)
        Me.cmdActivar.TabIndex = 19
        Me.cmdActivar.Text = "A"
        Me.cmdActivar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(454, 27)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(26, 23)
        Me.cmdCancelar.TabIndex = 20
        Me.cmdCancelar.Text = "C"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmManejoFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(722, 551)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManejoFactura"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manejo de Factura"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvResultadoFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnCancelaFac As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUUID As System.Windows.Forms.TextBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents chbxUUID As System.Windows.Forms.CheckBox
    Friend WithEvents chbxFolio As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents chbxFechas As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvResultadoFact As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnVerPDF As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnVerXML As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEnviarEmail As System.Windows.Forms.Button
    Friend WithEvents btnVerXMLAcuse As System.Windows.Forms.Button
    Friend WithEvents btnVerPDFAcuse As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnExportaExcel As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents colSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFolio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcuse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUUID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colArchivoPDF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colArchivoXML As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCorreo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRFC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSustitucion As System.Windows.Forms.Button
    Friend WithEvents btnNotasCredito As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdActivar As System.Windows.Forms.Button

End Class

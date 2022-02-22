Public Class frmCancelarFactura
    Public TipoFactura As String = ""
    Public Folio As Integer = 0
    Private Sub guardaDatosCancelacion(ByVal datos As DataTable, ByVal motivo As String)
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Try
            For Each dr As DataRow In dtEnviar.Rows
                If conAcuse = True Then
                    sSQL = "UPDATE BDSPEXPRESS.dbo.BPFFacturas SET Acuse = 'SI', Estatus = 'C', MotivoCancelacion = '" & motivo & "', TipoCancelacion = '" & TipoRelacionCancelado & "' WHERE Folio = '" & dr("Folio") & "'  and Serie = '" & dr("Serie") & "' and FolioFiscal = '" & dr("FolioFiscal") & "'"
                Else
                    sSQL = "UPDATE BDSPEXPRESS.dbo.BPFFacturas SET Estatus = 'C', MotivoCancelacion = '" & motivo & "', TipoCancelacion = '" & TipoRelacionCancelado & "' WHERE Folio = '" & dr("Folio") & "'  and Serie = '" & dr("Serie") & "' and FolioFiscal = '" & dr("FolioFiscal") & "'"
                End If
                SQLServer.ExecSQL(sSQL)
            Next
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub CargaTipoRelacion()
        Dim sSQL As String = ""
        Dim dtTipoRela As New DataTable
        Dim drTipoRela As DataRow

        sSQL = "SELECT DescCorta, Valor1T FROM BPFCatalogos WHERE Tabla = 111 AND Elemento <> 0 AND Estatus = 'A' ORDER BY Valor1T"
        dtTipoRela = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")

        For iFila As Integer = 0 To dtTipoRela.Rows.Count - 1
            drTipoRela = dtTipoRela.Rows(iFila)
            cboTipoRelacion.Items.Add(drTipoRela("Valor1T").ToString & " - " & drTipoRela("DescCorta").ToString)
        Next iFila

    End Sub
    Private Sub CargaTipoCancelacion()
        Dim sSQL As String = ""
        Dim dtTipoCancel As New DataTable
        Dim drTipoCancel As DataRow

        sSQL = "SELECT DescCorta, Valor1T FROM BPFCatalogos WHERE Tabla = 112 AND Elemento <> 0 AND Estatus = 'A' ORDER BY Valor1T"
        dtTipoCancel = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")

        For iFila As Integer = 0 To dtTipoCancel.Rows.Count - 1
            drTipoCancel = dtTipoCancel.Rows(iFila)
            cboTipoCancelacion.Items.Add(drTipoCancel("Valor1T").ToString & " - " & drTipoCancel("DescCorta").ToString)
        Next iFila

    End Sub
    Private Sub frmCancelarFactura_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DatosCancelar As String = ""
        Me.BackgroundImage = Pantallazo
        Me.Text = "Cancelar - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        'Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        'Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)

        For Each dr As DataRow In dtEnviar.Rows
            DatosCancelar = DatosCancelar & "Factura: " & dr("Serie") & " " & dr("Folio") & vbNewLine
            DatosCancelar = DatosCancelar & "Tipo: " & dr("TipoFactura") & vbNewLine
            DatosCancelar = DatosCancelar & "Folio Fiscal: " & dr("FolioFiscal") & vbNewLine
            DatosCancelar = DatosCancelar & "Archivos: " & dr("NombreArchivoPDF") & vbNewLine
            DatosCancelar = DatosCancelar & dr("NombreArchivoXML") & vbNewLine
            DatosCancelar = DatosCancelar & vbNewLine

        Next
        txtDatos.Text = DatosCancelar


        If TipoCancelacion = "SUSTITUCION" Then
            Label4.Visible = True
            cboTipoRelacion.Visible = True
            Label5.Visible = True
            cboTipoCancelacion.Visible = True
            CargaTipoRelacion()
            CargaTipoCancelacion()
            cboInclDirSuc.SelectedIndex = 1
            lblleyenda.Visible = True
            Me.Text = "Sustituir"
            btnCancelar.Text = "Sustituir"
            GroupBox1.Text = "Información a Sustituir"
        Else
            Label4.Visible = False
            cboTipoRelacion.Visible = False
            Label5.Visible = True
            cboTipoCancelacion.Visible = True
            CargaTipoCancelacion()
        End If



    End Sub
    Private Sub Limpia()
        Try
            cboInclDirCte.SelectedIndex = 0
            cboInclDirSuc.SelectedIndex = 1

            If Not dtDetalle Is Nothing And dtDetalle.Rows.Count > 0 Then
                dtDetalle.Rows.Clear()
            End If
            dgvLista.DataSource = dtDetalle
            dsDevs = New DataSet
            dtDevsEnca = New DataTable
            dtDevsDeta = New DataTable

            TipoCancelacion = ""
            FechaCancelado = ""
            CFDIRelacionadoCancelado = ""
            TipoRelacionCancelado = ""
            CFDIRelacionadoSustitucion = ""
            TipoRelacionSustitucion = ""

        Catch ex As Exception
            texto = texto & Format(Now, "HHmm").ToString & "~" & "Error: " & ex.Message & vbNewLine
            My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
            End
        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim motivo As String = ""
        Dim dr As DataRow

        dr = dtEnviar.Rows(0)

        If txtMotivo.Text = "" Then
            MsgBox("Por favor indique el motivo de la cancelación!", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If
        Try
            motivo = txtMotivo.Text

            'ObtenerMovimientos(FechaCancelado)

            'cancelaFactura(dtEnviar)
            seCancelo = True
            If seCancelo = True Then
                'guardaDatosCancelacion(dtEnviar, motivo)
                If TipoCancelacion = "SUSTITUCION" Then
                    If TipoFactura = "INDIVIDUAL" Then
                        CFDIRelacionadoCancelado = dr("FolioFiscal").ToString
                        TipoRelacionCancelado = Mid(cboTipoRelacion.Text, 1, 2)
                        strFechaBusqueda = "20211221"
                        guardaDatosCancelacion(dtEnviar, motivo)
                        ObtenerMovimientosIndividual(FechaCancelado, Folio, CFDIRelacionadoCancelado, TipoRelacionCancelado)
                        'Facturar(CFDIRelacionadoCancelado, TipoRelacionCancelado)
                    Else
                        CFDIRelacionadoCancelado = dr("FolioFiscal").ToString
                        TipoRelacionCancelado = Mid(cboTipoCancelacion.Text, 1, 2)
                        TipoRelacionSustitucion = Mid(cboTipoRelacion.Text, 1, 2)
                        guardaDatosCancelacion(dtEnviar, motivo)
                        ObtenerMovimientos(FechaCancelado)
                        Facturar(CFDIRelacionadoCancelado, TipoRelacionSustitucion)
                        cancelaFactura(dtEnviar, CFDIRelacionadoSustitucion, TipoRelacionCancelado)
                        guardaDatosCancelacion(dtEnviar, motivo)
                    End If

                End If
            End If

            Limpia()
            Me.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message & "Tipo Error: " & TipoError, MsgBoxStyle.Exclamation, "Facturación")
        End Try
    End Sub

    Private Sub btnCancelar_MouseLeave(sender As Object, e As EventArgs) Handles btnCancelar.MouseLeave
        Label2.Visible = False
    End Sub

    Private Sub btnCancelar_MouseMove(sender As Object, e As MouseEventArgs) Handles btnCancelar.MouseMove
        Label2.Visible = True
    End Sub

    Private Sub btnCerrar_MouseLeave(sender As Object, e As EventArgs) Handles btnCerrar.MouseLeave
        Label20.Visible = False
    End Sub

    Private Sub btnCerrar_MouseMove(sender As Object, e As MouseEventArgs) Handles btnCerrar.MouseMove
        Label20.Visible = True
    End Sub

    Private Sub ObtenerMovimientosIndividual(Fecha As String, Folio As Integer, strCFDIRelacionado As String, strTipoRelacion As String)
        Dim NvoConcepto As String = ""
        Dim sSQL As String = ""
        Dim dtTest As New DataTable
        Dim dtDeta2 As New DataTable
        Dim dtDeta3 As New DataTable
        Dim strMsg As String = ""
        Dim strSerieFacturaGlobal As String = ""
        Dim strFolioFacturaGlobal As String = ""
        Dim strUUIDFacturaGlobal As String = ""
        Dim Concepto As String = ""
        'VARIABLES NUEVAS
        Dim TipoBusqueda As String = ""
        Dim FolOperacion As String = ""
        Dim FolioOperacion As Long = 0
        Dim Carac As Integer = 0
        CodIntSat = ""
        DescIntSat = ""
        CodApaSat = ""
        DescApaSat = ""
        Sistema = ""
        Accion = "BUSCA"
        Dim NoTicket As Integer = 0
        Dim Serie As String = ""

        Try
            'limpiando las tablas
            dtDetalle = New DataTable
            dsDevs = New DataSet
            dtDevsEnca = New DataTable
            dtDevsDeta = New DataTable

            Me.Cursor = Cursors.WaitCursor

            Dim dtPartidas As New DataTable
            Dim drPartidas As DataRow

            sSQL = "SELECT NoSucursal, Folio, Serie, NoTicket, TipoTicket FROM BPFFacturasPartidas WHERE Folio = " & Folio & " GROUP BY NoSucursal, Folio, Serie, NoTicket, TipoTicket"
            dtPartidas = SQLServer.ExecSQLReturnDT(sSQL, "BPFPartidas")

            For iFila As Integer = 0 To dtPartidas.Rows.Count - 1
                drPartidas = dtPartidas.Rows(iFila)
                NoTicket = drPartidas("NoTicket").ToString
                TipoFac = drPartidas("TipoTicket").ToString
                Serie = drPartidas("Serie").ToString


                Dim oParam(14) As SqlClient.SqlParameter

                'Buscando codigos y descripcion de productos
                BuscaCodyDescProd()


                Select Case TipoFac
                    Case "E"
                        'Empeño
                        TipoBusqueda = ""
                        Try
                            sSQL = "sps_VINO_FacturaPeriodica"
                            oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                            oParam(1) = New SqlClient.SqlParameter("@pFechaIni", DBNull.Value)
                            oParam(2) = New SqlClient.SqlParameter("@pFechaFin", DBNull.Value)
                            oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                            oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", NoTicket)
                            oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                            oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
                            oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", DBNull.Value)
                            oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ)
                            oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", CodIntSat)
                            oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DescIntSat)
                            oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", CodApaSat)
                            oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
                            oParam(13) = New SqlClient.SqlParameter("@pFolioOperacion2", NoTicket)
                            oParam(14) = New SqlClient.SqlParameter("@pTipoFactura2", "INDIVIDUAL")
                            dtDetalle = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

                            If Not dtDetalle Is Nothing Then
                                If dtDetalle.Rows.Count > 0 Then
                                    DatosCliente(0, dtDetalle.Rows(0).Item("NoTicket").ToString)
                                End If
                            End If

                        Catch exAQ As Exception
                            Me.Cursor = Cursors.Default
                            MsgBox("No hay conexión con el servidor de venta de aparatos, por favor avise a sistemas!" & vbCrLf & exAQ.Message, MsgBoxStyle.Exclamation, "Facturacion")
                        End Try


                    Case "J"
                        ''Venta de joyería




                        Try

                        Catch exAQ As Exception
                            Me.Cursor = Cursors.Default
                            MsgBox("No hay conexión con el servidor de venta de aparatos, por favor avise a sistemas!" & vbCrLf & exAQ.Message, MsgBoxStyle.Exclamation, "Facturacion")
                        End Try

                    Case "A"

                        'Adminpaq
                        TipoBusqueda = ""

                        SQLServer.Init(, strBDAQ, strServerAQ, strUsrAQ, strPwdAQ)

                        sSQL = "SELECT TOP 1 * FROM Catalogos"
                        dtTest = SQLServer.ExecSQLReturnDT(sSQL, "Catalogos")

                        AdminpaqEsperaActualizacion()

                        sSQL = "sps_AQ_FacturaPeriodica"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)

                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", DBNull.Value)
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", DBNull.Value)

                        oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                        oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", NoTicket)
                        oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                        oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", Serie)

                        oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "INDIVIDUAL")

                        oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ / 100)
                        oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", DBNull.Value)
                        oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DBNull.Value)
                        oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", DBNull.Value)
                        oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
                        oParam(13) = New SqlClient.SqlParameter("@pFolioOperacion2", NoTicket)
                        oParam(14) = New SqlClient.SqlParameter("@pTipoFactura2", "INDIVIDUAL")
                        dtDetalle = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

                        If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                            strMsg = "No se encuentra el ticket " & Serie & " " & NoTicket & "!"
                            MsgBox(strMsg, MsgBoxStyle.Exclamation, "Facturación")
                        End If

                        ConectaBD()

                End Select

                dtDetalle.Columns.Add("Sel", GetType(Integer))  'PARA SELECCIONAR EN EL GRID
                dtDetalle.Columns.Add("SerieFacturaGlobal", GetType(String))
                dtDetalle.Columns.Add("FolioFacturaglobal", GetType(String))
                dtDetalle.Columns.Add("UUIDFacturaGlobal", GetType(String))
                dtDetalle.Columns.Add("TipoFactura", GetType(String))
                dtDetalle.Columns.Add("Estatus", GetType(String))
                For Each dr As DataRow In dtDetalle.Rows
                    dr("Sel") = 0
                    strSerieFacturaGlobal = ""
                    strFolioFacturaGlobal = ""
                    strUUIDFacturaGlobal = ""
                    TipoFac = ""
                    EstatusFac = ""
                    dr("SerieFacturaGlobal") = strSerieFacturaGlobal
                    dr("FolioFacturaglobal") = strFolioFacturaGlobal
                    dr("UUIDFacturaGlobal") = strUUIDFacturaGlobal
                    dr("TipoFactura") = TipoFac
                    dr("Estatus") = EstatusFac
                Next dr

                For Each dr As DataRow In dtDetalle.Rows
                    Concepto = ""
                    If dr("Prefijo") <> "A" And dr("Prefijo") <> "J" Then
                        NombreMov(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto)
                        dr("TipoMov") = Concepto
                    Else
                        dr("TipoMov") = dr("DescripcionSAT")
                    End If
                Next dr

                dtDetalle.AcceptChanges()

                If TipoFac = "E" Then
                    dgvResultado.DataSource = AgrupaTickets()
                Else
                    'dgvResultado.DataSource = dtDetalle
                    dgvResultado.DataSource = AnexaCamposFac()
                End If

                dgvResultado.Refresh()

                For Fila As Integer = 0 To dgvResultado.RowCount - 1
                    If dgvResultado.Item("colRUUIDFacturaGlobal", Fila).Value = "" Then
                        dgvResultado.Rows(Fila).DefaultCellStyle.BackColor = System.Drawing.Color.White
                    Else
                        If dgvResultado.Item("colREstatus", Fila).Value = "A" Then
                            If dgvResultado.Item("colRTipoFactura", Fila).Value = "GLOBAL" Then
                                dgvResultado.Rows(Fila).DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue
                            Else
                                dgvResultado.Rows(Fila).DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen
                            End If
                        Else
                            dgvResultado.Rows(Fila).DefaultCellStyle.BackColor = System.Drawing.Color.White
                        End If
                    End If
                Next

                dgvResultado.Refresh()

                dgvFacturar.Rows.Clear()
                dgvFacturar.Refresh()

                Me.Cursor = Cursors.Default

                'regreso la conexión al servidor de la sucursal
                ConectaBD()


                For iFila2 = 0 To dgvResultado.RowCount - 1
                    Agrega(iFila2)
                Next iFila2

            Next iFila

INICIO:




            'obteniendo los datos del lugar de emision (sucursal)
            DatosLugarEmision()
            If dtLugarEmision Is Nothing Then
                Exit Sub
            End If
            If dtLugarEmision.Rows.Count <= 0 Then
                MsgBox("No se encontraron datos del lugar de emisión, por favor avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If

            'obteniendo las claves fiscales (Regimen Fiscal, Forma de Pago, Moneda, Uso CFDI, Metodo de Pago)
            dtClavesFiscales = New DataTable
            'drClavesFiscales As DataRow

            strRegimenFiscal = ""
            strClaveProductoSAT = ""
            strUnidadMedidaSAT = ""
            strUnidadMedidaPE = ""
            strCondicionesPago = ""
            Sistema = ""
            Accion = "FACTURA"
            Factura = ""

            sSQL = "SELECT * FROM BPFCatalogoEmpresas WHERE NoEmpresa = 1"
            dtClavesFiscales = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoEmpresas")
            If dtClavesFiscales Is Nothing OrElse dtClavesFiscales.Rows.Count <= 0 Then
                MsgBox("No hay información de Claves del SAT, por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturación")
                Exit Sub
            End If

            drClavesFiscales = dtClavesFiscales.Rows(0)

            strRegimenFiscal = drClavesFiscales.Item("ClaveRegimenFiscalSAT").ToString.Trim.ToUpper

            'revisando si ya hay movimientos incluidos para facturar
            If dgvFacturar.RowCount <= 0 Then
                MsgBox("No ha agregado movimientos para la generacion de la factura", MsgBoxStyle.Information, "Facturacion")
                Exit Sub
            End If

            If TipoFac = "E" Then
                Sistema = "EMPEÑO"
            Else
                If TipoFac = "A" Then
                    Sistema = "ADMINPAQ"
                Else
                    Sistema = "JOYERIA"
                End If
            End If

            'estos son los datos para a facturar            
            dtDetalleInd = GeneraTablaDetalleIndi()

            If cboInclDirSuc.Text = "SI" Then
                strDirSuc = True
            Else
                strDirSuc = False
            End If
            If cboInclDirCte.Text = "SI" Then
                strDirCli = True
            Else
                strDirCli = False
            End If

            'Dim foliosNC As String = ""
            'For iFila = 0 To dgvFacturar.RowCount - 1
            '    If YaEnFacturaIndividual((dgvFacturar.Item("colFPrefijo", iFila).Value).ToString, (dgvFacturar.Item("colFNoTicket", iFila).Value).ToString) And TipoFac = "GLOBAL" Then
            '        If foliosNC = "" Then
            '            foliosNC += dgvFacturar.Item("colFNoTicket", iFila).Value
            '        Else
            '            foliosNC += ", " & dgvFacturar.Item("colFNoTicket", iFila).Value
            '        End If
            '    End If
            'Next iFila
            'If foliosNC <> "" Then
            '    Dim res As String = MsgBox("El Folio: " & foliosNC & "  Ya esta incluido en una Factura Global, Se realizara la Nota de Crédito Correspondiente.", MsgBoxStyle.YesNo, "Facturación")
            '    If res = 7 Then
            '        Exit Sub
            '    End If
            'End If

            Dim frmDatCt As New frmDatosClienteFacturacion
            frmDatCt.GridDatos = dgvFacturar
            frmDatCt.ShowDialog()
            If frmDatCt.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            If strTipoFactura = "GLOBAL" Then
                With drClavesFiscales
                    strMonedaClave = .Item("ClaveMonedaSAT").ToString.Trim.ToUpper
                    strUsoCFDIClave = .Item("ClaveUsoCFDISATFAC").ToString.Trim.ToUpper
                    strFormaPagoClave = .Item("ClaveFormaPagoSAT").ToString.Trim.ToUpper
                    strMetodoPagoClave = .Item("ClaveMetodoPagoSAT").ToString.Trim.ToUpper
                End With
            Else
                strMonedaClave = strMonedaClaveIND
                strUsoCFDIClave = strUsoCFDIClaveIND
                strFormaPagoClave = strFormaPagoClaveIND
                strMetodoPagoClave = strMetodoPagoClaveIND
            End If

            'en este punto ya tengo la lista de operaciones que se van a facturar y cada una de esas operaciones cual ya está incluída en una factura global
            'se procede a generar la factura
            If dtCliente Is Nothing Then
                Exit Sub
            End If
            If dtCliente.Rows.Count <= 0 Then
                MsgBox("No se encontraron datos del cliente, por favor avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If

            'validando redondeos de iva
            Dim dblValidaIVA As Double = 0
            Dim dblValidaTotal As Double = 0
            Dim ImpAntesIVA As Double = 0
            For Each dr As DataRow In dtDetalleInd.Rows
                If dr("IVA") > 0 Then
                    dblValidaIVA = 0
                    dblValidaTotal = 0
                    ImpAntesIVA = 0
                    dblValidaIVA = dr("IVA")
                    dblValidaTotal = dr("Total")

                    If Format(dr("Interes"), "#0.000000").ToString > "0.000000" Then
                        ImpAntesIVA = ImpAntesIVA + dr("Interes")
                    End If
                    If Format(dr("Recargo"), "#0.000000").ToString > "0.000000" Then
                        ImpAntesIVA = ImpAntesIVA + dr("Recargo")
                    End If
                    If Format(dr("Importe"), "#0.000000").ToString > "0.000000" Then
                        ImpAntesIVA = ImpAntesIVA + dr("Importe")
                    End If

                    ValidaRedondeos(1.0, 2, ImpAntesIVA, 6, dblPorcentajeIVA, dblValidaIVA, dblValidaTotal)

                    dr("IVA") = dblValidaIVA
                    dr("Total") = dblValidaTotal
                    dr.AcceptChanges()
                End If
            Next dr

            For Each dr As DataRow In dtDetalleInd.Rows
                Concepto = dr("Concepto").ToString
                NombreMovFac(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto, Mid(dr("NoTicket").ToString, 1, 1), NvoConcepto)
                dr("TipoMov") = NvoConcepto
                If dr("Tipo") = "TR" Or dr("Tipo") = "PF" Or dr("Tipo") = "CE" Or dr("Tipo") = "CF" Or (dr("Tipo") = "VT" And Concepto = "INTERESES") Then
                    dr("DescripcionSAT") = NvoConcepto
                End If
            Next dr

            'generando las notas de credito
            'si hay registros con marca de factura global, se procede a generar las notas de credito para cada uno           
            'If foliosNC <> "" Then
            '    errorNC = False
            '    GeneraNotaCreditoIndividual(dtDetalleInd)
            '    If errorNC Then
            '        GoTo NoSeHaceNada
            '    End If
            'End If

            'estos son los datos para la factura
            'validando redondeos de iva
            dblValidaIVA = 0
            dblValidaTotal = 0
            ImpAntesIVA = 0
            For Each dr As DataRow In dtDetalleInd.Rows
                If dr("IVA") > 0 Then
                    dblValidaIVA = 0
                    dblValidaTotal = 0
                    ImpAntesIVA = 0
                    dblValidaIVA = dr("IVA")
                    dblValidaTotal = dr("Total")

                    If Format(dr("Interes"), "#0.000000").ToString > "0.000000" Then
                        ImpAntesIVA = ImpAntesIVA + dr("Interes")
                    End If
                    If Format(dr("Recargo"), "#0.000000").ToString > "0.000000" Then
                        ImpAntesIVA = ImpAntesIVA + dr("Recargo")
                    End If
                    If Format(dr("Importe"), "#0.000000").ToString > "0.000000" Then
                        ImpAntesIVA = ImpAntesIVA + dr("Importe")
                    End If

                    ValidaRedondeos(1.0, 2, ImpAntesIVA, 6, dblPorcentajeIVA, dblValidaIVA, dblValidaTotal)

                    dr("IVA") = dblValidaIVA
                    dr("Total") = dblValidaTotal
                    dr.AcceptChanges()
                End If
            Next dr

            If cboInclDirSuc.Text = "SI" Then
                strDirSuc = True
            End If
            If cboInclDirCte.Text = "SI" Then
                strDirCli = True
            End If

            dblSumaImporte = 0
            dblSumaDescuento = 0
            dblSumaIVA = 0
            dblSumaTotal = 0
            dblSumaInteres = 0
            dblSumaRecargo = 0
            dblSubtotal = 0

            For Each dr As DataRow In dtDetalleInd.Rows
                dblSumaTotal += CDbl(dr("ImportePagado"))
                dblSumaImporte += CDbl(dr("Importe"))
                dblSumaDescuento += CDbl(dr("Descuento"))
                dblSumaInteres += CDbl(dr("Interes"))
                dblSumaRecargo += CDbl(dr("Recargo"))
                dblSumaIVA += CDbl(dr("IVA"))
            Next

            dblSubtotal = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")

            Factura = "INDIVIDUAL"

            FechaFact = Format(Now.Date, "yyyyMMdd")
            'generando factura

            GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleInd, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, strCFDIRelacionado, strTipoRelacion, enTipoDocumentoAfectar.FacturaIndividual, )
            'GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleInd, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaIndividual, )

        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Function GeneraTablaDetalleIndi() As DataTable
        Dim intFila As Integer = 0
        Dim j As Integer = 0
        Dim SumoCosto As Boolean = False
        Dim dtReturn As New DataTable
        Dim drNew As DataRow

        dtReturn = dtDetalle.Clone
        Try
            If Sistema = "EMPEÑO" Then
                For j = 0 To dgvFacturar.Rows.Count - 1
                    If CDbl(dgvFacturar.Item("colFCosto", j).Value) > 0 Then
                        If CDbl(dgvFacturar.Item("colFIVA", j).Value) > 0 Then
                            drNew = dtReturn.NewRow
                            drNew("Concepto") = "INTERESES"
                            drNew("Fecha") = dgvFacturar.Item("colFFecha", j).Value
                            drNew("Tipo") = dgvFacturar.Item("colFTipo", j).Value
                            drNew("NoTicket") = dgvFacturar.Item("colFPrefijo", j).Value & "-" & dgvFacturar.Item("colFNoticket", j).Value
                            drNew("TipoMov") = dgvFacturar.Item("colFTipoMov", j).Value
                            drNew("Importe") = dgvFacturar.Item("colFImporte", j).Value
                            drNew("Descuento") = dgvFacturar.Item("colFDescuento", j).Value
                            drNew("IVA") = dgvFacturar.Item("colFIVA", j).Value
                            drNew("Total") = dgvFacturar.Item("colFImporteFacturar", j).Value
                            drNew("Costo") = dgvFacturar.Item("colFCosto", j).Value
                            drNew("ImportePagado") = CDbl(dgvFacturar.Item("colFImportePago", j).Value) - CDbl(dgvFacturar.Item("colFCosto", j).Value)
                            drNew("Interes") = dgvFacturar.Item("colFInteres", j).Value
                            drNew("Recargo") = dgvFacturar.Item("colFRecargo", j).Value
                            drNew("UUIDFacturaGlobal") = dgvFacturar.Item("colFUUIDFacturaGlobal", j).Value
                            drNew("FormaPagoSAT") = dgvFacturar.Item("colFFormaPagoSAT", j).Value
                            drNew("ClaveSAT") = dgvFacturar.Item("colFCodigoSAT", j).Value
                            drNew("DescripcionSAT") = dgvFacturar.Item("colFDescripcionSAT", j).Value
                            dtReturn.Rows.Add(drNew)
                            dtReturn.AcceptChanges()
                        End If
                        'SI TIENE CAPITAL, SE GENERA OTRA DE PARTIDA DEL COSTO SIN INTERESES
                        drNew = dtReturn.NewRow
                        drNew("Concepto") = "LIQUIDACION"
                        drNew("Fecha") = dgvFacturar.Item("colFFecha", j).Value
                        drNew("Tipo") = dgvFacturar.Item("colFTipo", j).Value
                        drNew("NoTicket") = dgvFacturar.Item("colFPrefijo", j).Value & "-" & dgvFacturar.Item("colFNoticket", j).Value
                        drNew("TipoMov") = dgvFacturar.Item("colFTipoMov", j).Value
                        drNew("Importe") = CDbl(dgvFacturar.Item("colFCosto", j).Value)
                        drNew("Descuento") = 0
                        drNew("IVA") = 0
                        drNew("Total") = 0
                        drNew("Costo") = 0
                        drNew("ImportePagado") = CDbl(dgvFacturar.Item("colFCosto", j).Value)
                        drNew("Interes") = 0
                        drNew("Recargo") = 0
                        drNew("UUIDFacturaGlobal") = dgvFacturar.Item("colFUUIDFacturaGlobal", j).Value
                        drNew("FormaPagoSAT") = dgvFacturar.Item("colFFormaPagoSAT", j).Value
                        drNew("ClaveSAT") = dgvFacturar.Item("colFCodigoSAT", j).Value
                        drNew("DescripcionSAT") = dgvFacturar.Item("colFDescripcionSAT", j).Value
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()
                        SumoCosto = True
                    Else
                        If SumoCosto = False Then
                            drNew = dtReturn.NewRow
                            drNew("Concepto") = "INTERESES"
                            drNew("Fecha") = dgvFacturar.Item("colFFecha", j).Value
                            drNew("Tipo") = dgvFacturar.Item("colFTipo", j).Value
                            drNew("NoTicket") = dgvFacturar.Item("colFPrefijo", j).Value & "-" & dgvFacturar.Item("colFNoticket", j).Value
                            drNew("TipoMov") = dgvFacturar.Item("colFTipoMov", j).Value
                            drNew("Importe") = dgvFacturar.Item("colFImporte", j).Value
                            drNew("Descuento") = dgvFacturar.Item("colFDescuento", j).Value
                            drNew("IVA") = dgvFacturar.Item("colFIVA", j).Value
                            drNew("Total") = dgvFacturar.Item("colFImporteFacturar", j).Value
                            drNew("Costo") = dgvFacturar.Item("colFCosto", j).Value
                            drNew("ImportePagado") = CDbl(dgvFacturar.Item("colFImportePago", j).Value) - CDbl(dgvFacturar.Item("colFCosto", j).Value)
                            drNew("Interes") = dgvFacturar.Item("colFInteres", j).Value
                            drNew("Recargo") = dgvFacturar.Item("colFRecargo", j).Value
                            drNew("UUIDFacturaGlobal") = dgvFacturar.Item("colFUUIDFacturaGlobal", j).Value
                            drNew("FormaPagoSAT") = dgvFacturar.Item("colFFormaPagoSAT", j).Value
                            drNew("ClaveSAT") = dgvFacturar.Item("colFCodigoSAT", j).Value
                            drNew("DescripcionSAT") = dgvFacturar.Item("colFDescripcionSAT", j).Value
                            dtReturn.Rows.Add(drNew)
                            dtReturn.AcceptChanges()
                        End If
                    End If
                Next j

            Else
                For intFila = 0 To dgvFacturar.Rows.Count - 1
                    If dgvFacturar.Item("colFImporte", intFila).Value > 0 Then
                        drNew = dtReturn.NewRow
                        drNew("Concepto") = "INTERESES VENTA"
                        drNew("Fecha") = dgvFacturar.Item("colFFecha", intFila).Value
                        drNew("Tipo") = dgvFacturar.Item("colFTipo", intFila).Value
                        drNew("NoTicket") = dgvFacturar.Item("colFPrefijo", intFila).Value & "-" & dgvFacturar.Item("colFNoticket", intFila).Value
                        drNew("TipoMov") = dgvFacturar.Item("colFTipoMov", intFila).Value
                        drNew("Importe") = dgvFacturar.Item("colFImporte", intFila).Value
                        drNew("Descuento") = dgvFacturar.Item("colFDescuento", intFila).Value
                        drNew("IVA") = dgvFacturar.Item("colFIVA", intFila).Value
                        drNew("Total") = dgvFacturar.Item("colFImporteFacturar", intFila).Value
                        drNew("Costo") = dgvFacturar.Item("colFCosto", intFila).Value
                        drNew("ImportePagado") = CDbl(dgvFacturar.Item("colFImportePago", intFila).Value) - CDbl(dgvFacturar.Item("colFCosto", intFila).Value)
                        drNew("Interes") = dgvFacturar.Item("colFInteres", intFila).Value
                        drNew("Recargo") = dgvFacturar.Item("colFRecargo", intFila).Value
                        drNew("UUIDFacturaGlobal") = dgvFacturar.Item("colFUUIDFacturaGlobal", intFila).Value
                        drNew("FormaPagoSAT") = dgvFacturar.Item("colFFormaPagoSAT", intFila).Value
                        drNew("ClaveSAT") = dgvFacturar.Item("colFCodigoSAT", intFila).Value
                        drNew("DescripcionSAT") = dgvFacturar.Item("colFDescripcionSAT", intFila).Value
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()

                        'PARA LOS TICKETS DE APARATOS Y JOYERIA QUE EL COSTO SEA MENOR AL PRECIO PAGADO, SE DEBE DE  2 LINEAS EN LA FACTURA
                        'UNA LINEA CON EL IMPORTE DEL COSTO Y SIN IVA
                        'UNA LINEA CON EL IMPORTE DE LA UTILIDAD Y EL IVA DE LA UTILIDAD

                        drNew = dtReturn.NewRow
                        drNew("Concepto") = dgvFacturar.Item("colFConcepto", intFila).Value
                        drNew("Fecha") = dgvFacturar.Item("colFFecha", intFila).Value
                        drNew("Tipo") = dgvFacturar.Item("colFTipo", intFila).Value
                        drNew("NoTicket") = dgvFacturar.Item("colFPrefijo", intFila).Value & "-" & dgvFacturar.Item("colFNoticket", intFila).Value
                        drNew("TipoMov") = dgvFacturar.Item("colFTipoMov", intFila).Value
                        drNew("Importe") = dgvFacturar.Item("colFCosto", intFila).Value
                        drNew("Descuento") = 0
                        drNew("IVA") = 0
                        drNew("Costo") = 0
                        drNew("Total") = dgvFacturar.Item("colFCosto", intFila).Value
                        drNew("ImportePagado") = dgvFacturar.Item("colFCosto", intFila).Value
                        drNew("Interes") = dgvFacturar.Item("colFInteres", intFila).Value
                        drNew("Recargo") = dgvFacturar.Item("colFRecargo", intFila).Value
                        drNew("UUIDFacturaGlobal") = dgvFacturar.Item("colFUUIDFacturaGlobal", intFila).Value
                        drNew("FormaPagoSAT") = dgvFacturar.Item("colFFormaPagoSAT", intFila).Value
                        drNew("ClaveSAT") = dgvFacturar.Item("colFCodigoSAT", intFila).Value
                        drNew("DescripcionSAT") = dgvFacturar.Item("colFDescripcionSAT", intFila).Value
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()
                    Else

                        drNew = dtReturn.NewRow
                        drNew("Concepto") = dgvFacturar.Item("colFConcepto", intFila).Value
                        drNew("Fecha") = dgvFacturar.Item("colFFecha", intFila).Value
                        drNew("Tipo") = dgvFacturar.Item("colFTipo", intFila).Value
                        drNew("NoTicket") = dgvFacturar.Item("colFPrefijo", intFila).Value & "-" & dgvFacturar.Item("colFNoticket", intFila).Value
                        drNew("TipoMov") = dgvFacturar.Item("colFTipoMov", intFila).Value
                        drNew("Importe") = dgvFacturar.Item("colFCosto", intFila).Value
                        drNew("Descuento") = 0
                        drNew("IVA") = 0
                        drNew("Costo") = 0
                        drNew("Total") = dgvFacturar.Item("colFCosto", intFila).Value
                        drNew("ImportePagado") = dgvFacturar.Item("colFCosto", intFila).Value
                        drNew("Interes") = dgvFacturar.Item("colFInteres", intFila).Value
                        drNew("Recargo") = dgvFacturar.Item("colFRecargo", intFila).Value
                        drNew("UUIDFacturaGlobal") = dgvFacturar.Item("colFUUIDFacturaGlobal", intFila).Value
                        drNew("FormaPagoSAT") = dgvFacturar.Item("colFFormaPagoSAT", intFila).Value
                        drNew("ClaveSAT") = dgvFacturar.Item("colFCodigoSAT", intFila).Value
                        drNew("DescripcionSAT") = dgvFacturar.Item("colFDescripcionSAT", intFila).Value
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()

                    End If

                Next intFila
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            GeneraTablaDetalleIndi = dtReturn
        End Try
    End Function
    Private Sub Agrega(ByVal NoFilaResultado As Integer)
        Dim intFilaNueva As Integer = 0
        Try
            'se asume que se agrega una fila
            dgvFacturar.Rows.Add()
            intFilaNueva = dgvFacturar.RowCount - 1
            dgvFacturar.Item("colFFecha", intFilaNueva).Value = dgvResultado.Item("colRFecha", NoFilaResultado).Value

            If dgvResultado.Item("colRPrefijo", NoFilaResultado).Value = "A" Or dgvResultado.Item("colRPrefijo", NoFilaResultado).Value = "J" Then
                dgvFacturar.Item("colFTipo", intFilaNueva).Value = "VT"
            Else
                dgvFacturar.Item("colFTipo", intFilaNueva).Value = dgvResultado.Item("colRTipo", NoFilaResultado).Value
            End If
            dgvFacturar.Item("colFPrefijo", intFilaNueva).Value = dgvResultado.Item("colRPrefijo", NoFilaResultado).Value
            dgvFacturar.Item("colFNoticket", intFilaNueva).Value = dgvResultado.Item("colRNoTicket", NoFilaResultado).Value
            dgvFacturar.Item("colFImportePago", intFilaNueva).Value = dgvResultado.Item("colRImportePago", NoFilaResultado).Value
            dgvFacturar.Item("colFConcepto", intFilaNueva).Value = dgvResultado.Item("colRConcepto", NoFilaResultado).Value
            dgvFacturar.Item("colFImporteFacturar", intFilaNueva).Value = dgvResultado.Item("colRImporteFacturar", NoFilaResultado).Value
            dgvFacturar.Item("colFDescuento", intFilaNueva).Value = dgvResultado.Item("colRDescuento", NoFilaResultado).Value
            dgvFacturar.Item("colFIVA", intFilaNueva).Value = dgvResultado.Item("colRIVA", NoFilaResultado).Value
            dgvFacturar.Item("colFImporte", intFilaNueva).Value = dgvResultado.Item("colRImporte", NoFilaResultado).Value
            dgvFacturar.Item("colFDescuento", intFilaNueva).Value = dgvResultado.Item("colRDescuento", NoFilaResultado).Value
            dgvFacturar.Item("colFCosto", intFilaNueva).Value = dgvResultado.Item("colRCosto", NoFilaResultado).Value
            dgvFacturar.Item("colFInteres", intFilaNueva).Value = dgvResultado.Item("colRInteres", NoFilaResultado).Value
            dgvFacturar.Item("colFRecargo", intFilaNueva).Value = dgvResultado.Item("colRRecargo", NoFilaResultado).Value
            dgvFacturar.Item("colFSerieFacturaGlobal", intFilaNueva).Value = dgvResultado.Item("colRSerieFacturaGlobal", NoFilaResultado).Value
            dgvFacturar.Item("colFFolioFacturaGlobal", intFilaNueva).Value = dgvResultado.Item("colRFolioFacturaGlobal", NoFilaResultado).Value
            dgvFacturar.Item("colFUUIDFacturaGlobal", intFilaNueva).Value = dgvResultado.Item("colRUUIDFacturaGlobal", NoFilaResultado).Value
            dgvFacturar.Item("colFSel", intFilaNueva).Value = 0
            dgvFacturar.Item("colFCodigoSAT", intFilaNueva).Value = dgvResultado.Item("colRCodigoSAT", NoFilaResultado).Value
            dgvFacturar.Item("colFFormaPagoSAT", intFilaNueva).Value = dgvResultado.Item("colRFormaPagoSAT", NoFilaResultado).Value
            dgvFacturar.Item("colFDescripcionSAT", intFilaNueva).Value = dgvResultado.Item("colRDescripcionSAT", NoFilaResultado).Value
            dgvFacturar.Item("colFTipoMov", intFilaNueva).Value = dgvResultado.Item("colRTipoMov", NoFilaResultado).Value
            dgvFacturar.Item("colFTipoFactura", intFilaNueva).Value = dgvResultado.Item("colRTipoFactura", NoFilaResultado).Value
            If TipoFac = "" Then
                dgvFacturar.Rows(intFilaNueva).DefaultCellStyle.BackColor = System.Drawing.Color.White
            Else
                If TipoFac = "GLOBAL" Then
                    dgvFacturar.Rows(intFilaNueva).DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue
                Else
                    dgvFacturar.Rows(intFilaNueva).DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen
                End If
            End If
            dgvFacturar.Rows(intFilaNueva).DefaultCellStyle.BackColor = dgvResultado.Rows(NoFilaResultado).DefaultCellStyle.BackColor
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub
    Private Sub ObtenerMovimientos(Fecha As String)
        Dim sSQL As String = ""
        Dim oParam(12) As SqlClient.SqlParameter
        Dim dtTest As New DataTable
        Dim dtDeta2 As New DataTable
        Dim dtDeta3 As New DataTable
        Dim drNew As DataRow
        Dim Concepto As String = ""

        Sistema = ""


        Try


            'limpiando las tablas
            dtDetalle = New DataTable
            dsDevs = New DataSet
            dtDevsEnca = New DataTable
            dtDevsDeta = New DataTable

            TipoError = "Busca Empenos"
            BuscaCodyDescProd()
            sSQL = "sps_VINO_FacturaPeriodica"
            oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
            oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Fecha)
            oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Fecha)
            oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
            oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", DBNull.Value)
            oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
            oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
            oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "GLOBAL")
            oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ)
            oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", CodIntSat)
            oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DescIntSat)
            oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", CodApaSat)
            oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
            dtDetalle = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

            Sistema = "GLOBAL"
            dtDetalle = AgrupaTickets()

            If bolTienePuntodeVenta Then
                'tiene punto de venta
                If bolTieneVentaAparatos Or bolTieneVentaJoyeria Then
                    'tiene venta de aparatos
                    Try

Intento:
                        IntConexion = IntConexion + 1
                        'tratando de conectar al servidor de ventas electronicos 
                        SQLServer.Init(, strBDAQGlobal, strServerAQ, strUsrAQ, strPwdAQ)
                        'probando
                        sSQL = "SELECT TOP 1 * FROM PE.dbo.Catalogos"
                        dtTest = SQLServer.ExecSQLReturnDT(sSQL, "Catalogos")
                        'pasó la prueba, se continua con la obtencion del detalle
                        'esperando actualizacion de adminpaq por si hubiera

                        TipoError = "Espera Adminpaq"
                        AdminpaqEsperaActualizacion()

                        TipoError = "Busca Ventas"
                        sSQL = "sps_AVR_FacturaGlobal"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Fecha)
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Fecha)
                        oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                        oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", DBNull.Value)
                        oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                        oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
                        oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "GLOBAL")
                        oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ / 100)
                        oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", DBNull.Value)
                        oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DBNull.Value)
                        oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", DBNull.Value)
                        oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
                        dtDeta2 = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

                        If Not dtDeta2 Is Nothing AndAlso dtDeta2.Rows.Count > 0 Then
                            For Each drDeta2 As DataRow In dtDeta2.Rows
                                If drDeta2("Tipo") = "VT" And drDeta2("Prefijo") = "J" Then
                                    drNew = dtDetalle.NewRow
                                    drNew("Concepto") = "VENTA DE JOYERIA"
                                    drNew("Fecha") = drDeta2("Fecha")
                                    drNew("Tipo") = drDeta2("Tipo")
                                    drNew("Prefijo") = drDeta2("Prefijo")
                                    drNew("NoTicket") = drDeta2("NoTicket")
                                    drNew("TipoMov") = drDeta2("TipoMov")
                                    drNew("Importe") = drDeta2("Importe")
                                    drNew("Costo") = drDeta2("Costo")
                                    drNew("Descuento") = drDeta2("Descuento")
                                    drNew("Total") = drDeta2("Total")
                                    drNew("ImportePagado") = drDeta2("ImportePagado")
                                    drNew("Interes") = drDeta2("Interes")
                                    drNew("Recargo") = drDeta2("Recargo")
                                    drNew("IVA") = drDeta2("IVA")
                                    dtDetalle.Rows.Add(drNew)
                                    dtDetalle.AcceptChanges()
                                Else
                                    drNew = dtDetalle.NewRow
                                    drNew("Concepto") = drDeta2("Concepto")
                                    drNew("Fecha") = drDeta2("Fecha")
                                    drNew("Tipo") = drDeta2("Tipo")
                                    drNew("Prefijo") = drDeta2("Prefijo")
                                    drNew("NoTicket") = drDeta2("NoTicket")
                                    drNew("TipoMov") = drDeta2("TipoMov")
                                    drNew("Importe") = drDeta2("Importe")
                                    drNew("Costo") = drDeta2("Costo")
                                    drNew("Descuento") = drDeta2("Descuento")
                                    drNew("Total") = drDeta2("Total")
                                    drNew("ImportePagado") = drDeta2("ImportePagado")
                                    drNew("Interes") = drDeta2("Interes")
                                    drNew("Recargo") = drDeta2("Recargo")
                                    drNew("IVA") = drDeta2("IVA")
                                    dtDetalle.Rows.Add(drNew)
                                    dtDetalle.AcceptChanges()
                                End If
                            Next drDeta2
                        End If

                        'DEVOLUCIONES
                        SQLServer.Init(, strBDAQ, strServerAQ, strUsrAQ, strPwdAQ)

                        TipoError = "Busca Devoluciones"
                        sSQL = "sps_AQ_FacturaPeriodica_Devs"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Fecha)
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Fecha)
                        oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                        oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", DBNull.Value)
                        oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                        oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
                        oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "GLOBAL")
                        oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ / 100)
                        oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", DBNull.Value)
                        oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DBNull.Value)
                        oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", DBNull.Value)
                        oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
                        dsDevs = SQLServer.ExecSPReturnDS(sSQL, oParam, "Devoluciones")
                        If Not dsDevs Is Nothing AndAlso dsDevs.Tables.Count > 0 Then
                            dtDevsEnca = dsDevs.Tables(0)
                            dtDevsDeta = dsDevs.Tables(1)
                            dtDevsDeta.Columns.Add("DescripcionSAT", GetType(String))
                            dtDevsDeta.AcceptChanges()
                        End If

                        ConectaBD()

                        IntConexion = 0

                    Catch excnn As Exception

                    End Try

                End If
            End If

            TipoError = "Conceptos"
            For Each dr As DataRow In dtDetalle.Rows
                Concepto = ""
                NombreMov(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto)
                dr("TipoMov") = Concepto
            Next dr

            TipoError = "Redondeos"
            'validando redondeos de iva
            Dim dblValidaIVA As Double = 0
            Dim dblValidaTotal As Double = 0
            Dim ImpAntesIVA As Double = 0
            For Each dr As DataRow In dtDetalle.Rows
                dblValidaIVA = 0
                dblValidaTotal = 0
                ImpAntesIVA = 0
                dblValidaIVA = dr("IVA")
                dblValidaTotal = dr("Total")

                If Format(dr("Interes"), "#0.000000").ToString > "0.000000" Then
                    ImpAntesIVA = ImpAntesIVA + dr("Interes")
                End If
                If Format(dr("Recargo"), "#0.000000").ToString > "0.000000" Then
                    ImpAntesIVA = ImpAntesIVA + dr("Recargo")
                End If
                If Format(dr("Importe"), "#0.000000").ToString > "0.000000" Then
                    ImpAntesIVA = ImpAntesIVA + dr("Importe")
                End If

                ValidaRedondeos(1.0, 2, ImpAntesIVA, 6, dblPorcentajeIVA, dblValidaIVA, dblValidaTotal)

                dr("IVA") = dblValidaIVA
                dr("Total") = dblValidaTotal
                dr.AcceptChanges()
            Next dr

            'regreso la conexión al servidor de la sucursal
            ConectaBD()

            TipoError = "Revisando Movimientos Facturados"
            'REVISANDO LOS QUE YA SE FACTURARON EN UNA GLOBAL O EN UNA INDIVIDUAL
            Dim arrBorrar As New ArrayList
            Dim x As Integer
            Dim drBorrar As DataRow

            If TipoCancelacion = "SUSTITUCION" Then



            Else
                For Each dr As DataRow In dtDetalle.Rows
                    'REVISANDO EN LAS GLOBALES
                    If YaEnFacturaGlobal(dr("Prefijo").ToString.Trim.ToUpper, dr("NoTicket").ToString, dr("Fecha").ToString) Then
                        'Agrega registro a borrar
                        arrBorrar.Add(dr("Noticket"))
                    End If
                    'REVISANDO EN LAS INDIVIDUALES
                    If YaEnFacturaIndividual(dr("Prefijo").ToString.Trim.ToUpper, dr("NoTicket").ToString) Then
                        'Agrega registro a borrar
                        arrBorrar.Add(dr("Noticket"))
                    End If
                    'REVISANDO SI HUBO DEVOLUCION EN EL MISMO DIA
                    If SeDevolvio(dtDevsDeta, dr("NoTicket").ToString) Then
                        'Agrega registro a borrar
                        arrBorrar.Add(dr("Noticket"))
                    End If
                Next dr

                Dim bolBorrar As Boolean = False
                If arrBorrar.Count > 0 Then
                    'hay algo para borrar de la tabla
                    drBorrar = Nothing
                    For x = 0 To arrBorrar.Count - 1
                        'buscando
                        For Each dr As DataRow In dtDetalle.Rows
                            If dr("Noticket") = arrBorrar(x) Then
                                drBorrar = dr
                                bolBorrar = True
                                Exit For
                            End If
                        Next dr
                        'Borrando
                        If Not drBorrar Is Nothing And bolBorrar Then
                            dtDetalle.Rows.Remove(drBorrar)
                            dtDetalle.AcceptChanges()
                            bolBorrar = False
                        End If
                    Next x
                End If

            End If

            dblSumaImporte = 0
            dblSumaDescuento = 0
            dblSumaIVA = 0
            dblSumaTotal = 0
            dblSubtotal = 0
            dgvLista.DataSource = dtDetalle
            dgvLista.Refresh()

            TipoError = "Busca PE001"
            For Each dr As DataRow In dtDetalle.Rows

                dblSumaDescuento += Math.Round(dr("Descuento"), 6)
                dblSumaIVA += Math.Round(dr("IVA"), 6)
                dblSumaTotal += Math.Round(dr("ImportePagado"), 6)
            Next dr
            TipoError = "Busca PE002"
            dblSubtotal = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")
            TipoError = "Busca PE003"

            If dtDetalle.Rows.Count <= 0 Then

                Exit Sub

            End If

            'ConectaBD()

        Catch ex As Exception


        End Try
    End Sub
    Private Sub Facturar(ByVal strCFDIRelacionado As String, ByVal strTipoRelacion As String)
        Dim Concepto As String = ""
        Dim NvoConcepto As String = ""
        dtDetalleGlob.Clear()
        dtDetalleDev.Clear()
        dtDetDevAvr.Clear()

        Try
            TipoError = "Busca Factura"
            If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                MsgBox("No hay movimientos Pendientes", MsgBoxStyle.Information, "Facturacion")
                Exit Sub
            End If
            Factura = ""
            'obteniendo los datos del lugar de emision (sucursal)
            TipoError = "Busca Lugar Emision"
            DatosLugarEmision()

            If cboInclDirSuc.Text = "SI" Then
                strDirSuc = True
            Else
                strDirSuc = False
            End If
            If cboInclDirCte.Text = "SI" Then
                strDirCli = True
            Else
                strDirCli = False
            End If

            If dtLugarEmision Is Nothing Then
                Exit Sub
            End If


            If dtLugarEmision.Rows.Count <= 0 Then
                MsgBox("ERROR: No se encontraron datos del lugar de emisión", MsgBoxStyle.Critical)
                End
            End If
            'obteniendo los datos del cliente, para este caso, es publico en general
            TipoError = "Busca Clientes"
            DatosCliente()

            If dtCliente Is Nothing Then
                End
            End If


            If dtCliente.Rows.Count <= 0 Then
                MsgBox("ERROR: No se encontraron datos del cliente", MsgBoxStyle.Critical)
                End
            End If

            'estos son los datos para facturar   
            TipoError = "Genera Tabla Detalle"
            dtDetalleGlob = GeneraTablaDetalle(dtDetalle)

            For Each dr As DataRow In dtDetalleGlob.Rows
                Concepto = dr("Concepto").ToString
                NombreMovFac(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto, Mid(dr("NoTicket").ToString, 1, 1), NvoConcepto)
                dr("TipoMov") = NvoConcepto
                dr("DescripcionSAT") = NvoConcepto
            Next dr

            Factura = "GLOBAL"
            strTipoFactura = Factura

            'ASIGNO FECHA PARA ETIQUETA PERSONALIZADA
            strFechaBusqueda = FechaCancelado

            errorFG = False
            'GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleGlob, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaGlobal, )
            GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleGlob, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, strCFDIRelacionado, strTipoRelacion, enTipoDocumentoAfectar.FacturaGlobal, )

            If errorFG Then
                GoTo NoseHaceNada
            End If

            'SI HAY DEVOLUCIONES, GENERA LAS NOTAS DE CREDITO
            If Not dtDevsEnca Is Nothing AndAlso dtDevsEnca.Rows.Count > 0 Then
                texto = ""
                Dim x1 As String = ""
                Dim x2 As String = ""
                GeneraNotasdeCredito(x1, x2)
            End If

            Limpia()

NoseHaceNada:

            dtCliente.Rows.Clear()

            'End

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FacturarIndividual(ByVal strCFDIRelacionado As String, ByVal strTipoRelacion As String)
        Dim Concepto As String = ""
        Dim NvoConcepto As String = ""
        dtDetalleGlob.Clear()
        dtDetalleDev.Clear()
        dtDetDevAvr.Clear()

        Try
            TipoError = "Busca Factura"
            If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                MsgBox("No hay movimientos Pendientes", MsgBoxStyle.Information, "Facturacion")
                Exit Sub
            End If
            Factura = ""
            'obteniendo los datos del lugar de emision (sucursal)
            TipoError = "Busca Lugar Emision"
            DatosLugarEmision()

            If cboInclDirSuc.Text = "SI" Then
                strDirSuc = True
            Else
                strDirSuc = False
            End If
            If cboInclDirCte.Text = "SI" Then
                strDirCli = True
            Else
                strDirCli = False
            End If

            If dtLugarEmision Is Nothing Then
                Exit Sub
            End If


            If dtLugarEmision.Rows.Count <= 0 Then
                MsgBox("ERROR: No se encontraron datos del lugar de emisión", MsgBoxStyle.Critical)
                End
            End If
            'obteniendo los datos del cliente, para este caso, es publico en general
            TipoError = "Busca Clientes"
            DatosCliente()

            If dtCliente Is Nothing Then
                End
            End If


            If dtCliente.Rows.Count <= 0 Then
                MsgBox("ERROR: No se encontraron datos del cliente", MsgBoxStyle.Critical)
                End
            End If

            'estos son los datos para facturar   
            TipoError = "Genera Tabla Detalle"
            dtDetalleGlob = GeneraTablaDetalle(dtDetalle)

            For Each dr As DataRow In dtDetalleGlob.Rows
                Concepto = dr("Concepto").ToString
                NombreMovFac(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto, Mid(dr("NoTicket").ToString, 1, 1), NvoConcepto)
                dr("TipoMov") = NvoConcepto
                dr("DescripcionSAT") = NvoConcepto
            Next dr

            Factura = "GLOBAL"
            strTipoFactura = Factura

            'ASIGNO FECHA PARA ETIQUETA PERSONALIZADA
            strFechaBusqueda = FechaCancelado

            errorFG = False
            ' GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleGlob, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaGlobal, )
            'GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleGlob, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, strCFDIRelacionado, strTipoRelacion, enTipoDocumentoAfectar.FacturaIndividual, )

            GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleInd, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, strCFDIRelacionado, strTipoRelacion, enTipoDocumentoAfectar.FacturaIndividual, )
            If errorFG Then
                GoTo NoseHaceNada
            End If

            'SI HAY DEVOLUCIONES, GENERA LAS NOTAS DE CREDITO
            If Not dtDevsEnca Is Nothing AndAlso dtDevsEnca.Rows.Count > 0 Then
                texto = ""
                Dim x1 As String = ""
                Dim x2 As String = ""
                GeneraNotasdeCredito(x1, x2)
            End If

            Limpia()

NoseHaceNada:

            dtCliente.Rows.Clear()

            'End

        Catch ex As Exception

        End Try
    End Sub

    Private Function GeneraTablaDetalle(ByVal Datos As DataTable) As DataTable
        Dim intFila As Integer = 0
        Dim SumoCosto As Boolean = False
        Dim dtReturn As New DataTable
        Dim drNew As DataRow
        dtReturn = dtDetalle.Clone

        Try
            For intFila = 0 To Datos.Rows.Count - 1
                If Datos.Rows(intFila).Item("Prefijo").ToString.ToUpper = "A" Or Datos.Rows(intFila).Item("Prefijo").ToString.ToUpper = "J" Then
                    If CDbl(Datos.Rows(intFila).Item("IVA").ToString) > 0 Then
                        drNew = dtReturn.NewRow
                        drNew("Concepto") = "INTERESES"
                        drNew("Fecha") = Datos.Rows(intFila).Item("Fecha").ToString
                        drNew("Tipo") = Datos.Rows(intFila).Item("Tipo").ToString
                        drNew("NoTicket") = Datos.Rows(intFila).Item("Prefijo").ToString & "-" & Datos.Rows(intFila).Item("NoTicket").ToString
                        drNew("TipoMov") = Datos.Rows(intFila).Item("TipoMov").ToString
                        drNew("Importe") = Datos.Rows(intFila).Item("Importe").ToString
                        drNew("Descuento") = Datos.Rows(intFila).Item("Descuento").ToString
                        drNew("IVA") = Datos.Rows(intFila).Item("IVA").ToString
                        drNew("Total") = Datos.Rows(intFila).Item("ImportePagado").ToString
                        drNew("Costo") = Datos.Rows(intFila).Item("Costo").ToString
                        drNew("ImportePagado") = CDbl(Datos.Rows(intFila).Item("ImportePagado").ToString) - CDbl(Datos.Rows(intFila).Item("Costo").ToString)
                        drNew("Interes") = Datos.Rows(intFila).Item("Interes").ToString
                        drNew("Recargo") = Datos.Rows(intFila).Item("Recargo").ToString
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()
                    End If
                    'PARA LOS TICKETS DE APARATOS Y JOYERIA QUE EL COSTO SEA MENOR AL PRECIO PAGADO, SE DEBE DE GENERAR 2 LINEAS EN LA FACTURA
                    'UNA LINEA CON EL IMPORTE DEL COSTO Y SIN IVA
                    'UNA LINEA CON EL IMPORTE DE LA UTILIDAD Y EL IVA DE LA UTILIDAD
                    If CDbl(Datos.Rows(intFila).Item("Costo").ToString) > 0 Then
                        drNew = dtReturn.NewRow
                        drNew("Concepto") = Datos.Rows(intFila).Item("Concepto").ToString
                        drNew("Fecha") = Datos.Rows(intFila).Item("Fecha").ToString
                        drNew("Tipo") = Datos.Rows(intFila).Item("Tipo").ToString
                        drNew("NoTicket") = Datos.Rows(intFila).Item("Prefijo").ToString & "-" & Datos.Rows(intFila).Item("NoTicket").ToString
                        drNew("TipoMov") = Datos.Rows(intFila).Item("TipoMov").ToString
                        drNew("Importe") = Datos.Rows(intFila).Item("Costo").ToString
                        drNew("Descuento") = 0
                        drNew("IVA") = 0
                        drNew("Costo") = 0
                        drNew("Total") = Datos.Rows(intFila).Item("Costo").ToString
                        drNew("ImportePagado") = Datos.Rows(intFila).Item("Costo").ToString
                        drNew("Interes") = Datos.Rows(intFila).Item("Interes").ToString
                        drNew("Recargo") = Datos.Rows(intFila).Item("Recargo").ToString
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()
                    End If
                Else
                    If CDbl(Datos.Rows(intFila).Item("Costo").ToString) > 0 Then
                        If CDbl(Datos.Rows(intFila).Item("IVA").ToString) > 0 Then
                            drNew = dtReturn.NewRow
                            drNew("Concepto") = "INTERESES"
                            drNew("Fecha") = Datos.Rows(intFila).Item("Fecha").ToString
                            drNew("Tipo") = Datos.Rows(intFila).Item("Tipo").ToString
                            drNew("NoTicket") = Datos.Rows(intFila).Item("Prefijo").ToString & "-" & Datos.Rows(intFila).Item("NoTicket").ToString
                            drNew("TipoMov") = Datos.Rows(intFila).Item("TipoMov").ToString
                            drNew("Importe") = Datos.Rows(intFila).Item("Importe").ToString
                            drNew("Descuento") = Datos.Rows(intFila).Item("Descuento").ToString
                            drNew("IVA") = Datos.Rows(intFila).Item("IVA").ToString
                            drNew("Total") = Datos.Rows(intFila).Item("ImportePagado").ToString
                            drNew("Costo") = Datos.Rows(intFila).Item("Costo").ToString
                            drNew("ImportePagado") = CDbl(Datos.Rows(intFila).Item("ImportePagado").ToString) - CDbl(Datos.Rows(intFila).Item("Costo").ToString)
                            drNew("Interes") = Datos.Rows(intFila).Item("Interes").ToString
                            drNew("Recargo") = Datos.Rows(intFila).Item("Recargo").ToString
                            dtReturn.Rows.Add(drNew)
                            dtReturn.AcceptChanges()
                        End If
                        'SI TIENE CAPITAL, SE GENERA OTRA DE PARTIDA DEL COSTO SIN INTERESES
                        drNew = dtReturn.NewRow
                        drNew("Concepto") = "LIQUIDACION"
                        drNew("Fecha") = Datos.Rows(intFila).Item("Fecha").ToString
                        drNew("Tipo") = Datos.Rows(intFila).Item("Tipo").ToString
                        drNew("NoTicket") = Datos.Rows(intFila).Item("Prefijo").ToString & "-" & Datos.Rows(intFila).Item("NoTicket").ToString
                        drNew("TipoMov") = Datos.Rows(intFila).Item("TipoMov").ToString
                        drNew("Importe") = CDbl(Datos.Rows(intFila).Item("Costo").ToString)
                        drNew("Descuento") = 0
                        drNew("IVA") = 0
                        drNew("Total") = 0
                        drNew("Costo") = 0
                        drNew("ImportePagado") = CDbl(Datos.Rows(intFila).Item("Costo").ToString)
                        drNew("Interes") = 0
                        drNew("Recargo") = 0
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()
                        SumoCosto = True
                    Else
                        drNew = dtReturn.NewRow
                        drNew("Concepto") = "INTERESES"
                        drNew("Fecha") = Datos.Rows(intFila).Item("Fecha").ToString
                        drNew("Tipo") = Datos.Rows(intFila).Item("Tipo").ToString
                        drNew("NoTicket") = Datos.Rows(intFila).Item("Prefijo").ToString & "-" & Datos.Rows(intFila).Item("NoTicket").ToString
                        drNew("TipoMov") = Datos.Rows(intFila).Item("TipoMov").ToString
                        drNew("Importe") = Datos.Rows(intFila).Item("Importe").ToString
                        drNew("Descuento") = Datos.Rows(intFila).Item("Descuento").ToString
                        drNew("IVA") = Datos.Rows(intFila).Item("IVA").ToString
                        drNew("Total") = Datos.Rows(intFila).Item("ImportePagado").ToString
                        drNew("Costo") = Datos.Rows(intFila).Item("Costo").ToString
                        drNew("ImportePagado") = CDbl(Datos.Rows(intFila).Item("ImportePagado").ToString) - CDbl(Datos.Rows(intFila).Item("Costo").ToString)
                        drNew("Interes") = Datos.Rows(intFila).Item("Interes").ToString
                        drNew("Recargo") = Datos.Rows(intFila).Item("Recargo").ToString
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()
                    End If
                End If
            Next intFila

        Catch ex As Exception
            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
            My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
            End
        Finally
            GeneraTablaDetalle = dtReturn
        End Try
    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
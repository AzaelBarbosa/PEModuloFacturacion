Imports System.IO
Public Class frmFacturaGlobalDiaria

#Region "Variables"
    'Dim dblSumaImporte As Double = 0
    'Dim dblSumaIVA As Double = 0
    'Dim dblSumaTotal As Double = 0
#End Region

#Region "Procedimientos"

    Private Sub LimpiaPantalla()

        Try
            txtCantPartidas.Text = "0"
            txtDescuento.Text = "$ 0.00"
            txtFolio.Text = ""
            txtIVA.Text = "$ 0.00"
            txtRespuesta.Text = ""
            txtSubTotal.Text = "$ 0.00"
            txtTotalFactura.Text = "$ 0.00"
            cboInclDirCte.SelectedIndex = 0
            cboInclDirSuc.SelectedIndex = 1

            dtpFechaIni.Value = CDate(strFechaUltimoCierre)
            dtpFechaFin.Value = CDate(strFechaUltimoCierre)

            If Not dtDetalle Is Nothing And dtDetalle.Rows.Count > 0 Then
                dtDetalle.Rows.Clear()
            End If
            dgvLista.DataSource = dtDetalle
            'dtDetalle = New DataTable
            dsDevs = New DataSet
            dtDevsEnca = New DataTable
            dtDevsDeta = New DataTable

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
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
                If (Datos.Rows(intFila).Item("Prefijo").ToString.ToUpper = "A" Or Datos.Rows(intFila).Item("Prefijo").ToString.ToUpper = "J") And Datos.Rows(intFila).Item("TipoAparato").ToString.ToUpper <> 648 Then
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
                ElseIf Datos.Rows(intFila).Item("TipoAparato").ToString.ToUpper = 648 Then
                    drNew = dtReturn.NewRow
                    drNew("Concepto") = "INTERESES"
                    drNew("Fecha") = Datos.Rows(intFila).Item("Fecha").ToString
                    drNew("Tipo") = Datos.Rows(intFila).Item("Tipo").ToString
                    drNew("NoTicket") = Datos.Rows(intFila).Item("Prefijo").ToString & "-" & Datos.Rows(intFila).Item("NoTicket").ToString
                    drNew("TipoMov") = Datos.Rows(intFila).Item("TipoMov").ToString
                    drNew("Importe") = CDbl(Datos.Rows(intFila).Item("ImportePagado").ToString) - CDbl(Datos.Rows(intFila).Item("IVA").ToString)
                    drNew("Descuento") = Datos.Rows(intFila).Item("Descuento").ToString
                    drNew("IVA") = Datos.Rows(intFila).Item("IVA").ToString
                    drNew("Total") = Datos.Rows(intFila).Item("ImportePagado").ToString
                    drNew("Costo") = Datos.Rows(intFila).Item("Costo").ToString
                    drNew("ImportePagado") = CDbl(Datos.Rows(intFila).Item("ImportePagado").ToString) - CDbl(Datos.Rows(intFila).Item("Costo").ToString)
                    drNew("Interes") = Datos.Rows(intFila).Item("Interes").ToString
                    drNew("Recargo") = Datos.Rows(intFila).Item("Recargo").ToString
                    dtReturn.Rows.Add(drNew)
                    dtReturn.AcceptChanges()
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
                        'If SumoCosto = False Then
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
                        'drNew("UUIDFacturaGlobal") = Datos.Rows(j).Item("UUIDFacturaGlobal").ToString
                        'drNew("FormaPagoSAT") = CInt(Datos.Rows(j).Item("FormaPagoSAT").ToString)
                        'drNew("ClaveSAT") = Datos.Rows(j).Item("ClaveSAT").ToString
                        'drNew("DescripcionSAT") = Datos.Rows(j).Item("DescripcionSAT").ToString
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()
                        'End If
                    End If
                End If
            Next intFila

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            GeneraTablaDetalle = dtReturn
        End Try
    End Function

    Private Function GridExport(ByVal DGV As DataGridView) As Boolean
        If DGV.RowCount > 0 Then
            Dim filename As String = Application.StartupPath & "\Export_" + Format(Now, "hhmmss").ToString + ".xls"
            DGV.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            DGV.SelectAll()
            IO.File.WriteAllText(filename, DGV.GetClipboardContent().GetText.TrimEnd)
            DGV.ClearSelection()
            Process.Start(filename)
            Return True
        Else
            Return False
        End If
    End Function

    Private Function FacturaGlobalFecha(ByVal Fecha As String) As Boolean
        Dim bolResultado As Boolean = False
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        'Dim fechaFac As String = Mid(Fecha, 1, 4) & Mid(Fecha, 6, 2) & Mid(Fecha, 9, 2)
        Try
            sSQL = "SELECT TOP 1 a.Serie, a.Folio " & _
                   "FROM BPFFacturas a " & _
                   "INNER JOIN BPFFacturasPartidas b ON a.NoSucursal=b.NoSucursal AND a.Folio=b.Folio AND a.Serie=b.Serie AND a.TipoFactura=b.TipoFactura " & _
                   "WHERE a.Estatus = 'A' AND a.TipoComprobante = 'I' AND a.TipoFactura = 'GLOBAL' AND b.FechaTicket = '" & Fecha & "' AND a.EstatusFEL = 'F'"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFFacturasPartidas")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    bolResultado = True
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            FacturaGlobalFecha = bolResultado
        End Try
    End Function



#End Region

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarMovimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMovimientos.Click
        Dim sSQL As String = ""
        Dim oParam(12) As SqlClient.SqlParameter
        Dim dtTest As New DataTable
        Dim dtDeta2 As New DataTable
        Dim dtDeta3 As New DataTable
        Dim drNew As DataRow
        Dim Concepto As String = ""

        Sistema = ""


        FactTimbrada = False
        MovBorrados = False

        If strFechaUltimoCierre < dtpFechaIni.Value Then
            MsgBox("No se a realizado el cierre del dia seleccionado, verifique.", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        If dtpFechaIni.Value > dtpFechaFin.Value Then
            Me.Cursor = Cursors.Default
            MsgBox("Rango de fechas inválido! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        'If (dtpFechaIni.Value = dtpFechaFin.Value) And dtpFechaIni.Value = strFechaUltimoCierre Then
        '    If FacturaGlobalFecha(Mid(strFechaUltimoCierre, 1, 4) & Mid(strFechaUltimoCierre, 6, 2) & Mid(strFechaUltimoCierre, 9, 2)) Then
        '        MsgBox("Solo se puede generar una Factura Global para un dia cerrado. " & vbCrLf & "Ya existe una Factura Global para " & Mid(strFechaUltimoCierre, 9, 2) & "-" & Mid(strFechaUltimoCierre, 6, 2) & "-" & Mid(strFechaUltimoCierre, 1, 4) & " movimiento no procede.", MsgBoxStyle.Exclamation, "Facturación")
        '        Exit Sub
        '    End If
        'Else
        '    If FacturaGlobalFecha(Mid(dtpFechaIni.Value, 7, 4) & Mid(dtpFechaIni.Value, 4, 2) & Mid(dtpFechaIni.Value, 1, 2)) Then
        '        MsgBox("Solo se puede generar una Factura Global para un dia cerrado. " & vbCrLf & "Ya existe una Factura Global de esta Fecha!", MsgBoxStyle.Exclamation, "Facturación")
        '        Exit Sub
        '    End If
        'End If

        Me.Cursor = Cursors.WaitCursor
        lblTextoAnuncio.Text = "Validando información inicial..."
        lblTextoAnuncio.Visible = True
        lblTextoAnuncio.Refresh()
        Try
            Me.Cursor = Cursors.WaitCursor
            'limpiando las tablas
            dtDetalle = New DataTable
            dsDevs = New DataSet
            dtDevsEnca = New DataTable
            dtDevsDeta = New DataTable

            'OBTENIENDO EL DETALLE DE LA INFORMACION DE LA FACTURA
            lblTextoAnuncio.Text = "Esperando actualización de Empeño..."
            lblTextoAnuncio.Visible = True
            lblTextoAnuncio.Refresh()

            FechaFact = Format(dtpFechaIni.Value, "yyyyMMdd")

            strFechaBusqueda = FechaFact


            sArchivoLog = "C:\SPE\VINO\LOG\LogFactura_Proceso_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmmss").ToString & ".txt"
            wrFichero = File.AppendText(sArchivoLog)

            '-------------------------------------
            '---BUSCAR FACTURA GLOBAL PENDIENTE---
            '-------------------------------------

            If BuscaFacturaGlobalPendiente(FechaFact) = True Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "VALIDANDO FACTURA PENDIENTE.......................... " & vbNewLine

                For Each dr As DataRow In dtFactPend.Rows
                    Comprobando = "SI"
                    obtenerXMLFolio(dtFactPend)
                    If FactTimbrada = True Then
                        ActualizaMovimientosFacturados(IIf(dr("TipoComprobante") = "I", enTipoDocumento.Factura, enTipoDocumento.NotaCredito), dr("Folio"))
                        ActualizarFacturaGlobalPendiente(FechaFact)
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FACTURA TIMBRADA SE DESCARGARAN LOS ARCHIVOS PDF Y XML..................... " & vbNewLine

                        obtenerXML(dtFactPend)
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "XML DESCARGADO CON EXITO.................. " & vbNewLine

                        obtenerPDF(dtFactPend)
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "PDF DESCARGADO CON EXITO.................. " & vbNewLine

                        ActualizaMovimientosFacturados(IIf(dr("TipoComprobante") = "I", enTipoDocumento.Factura, enTipoDocumento.NotaCredito), dr("Folio"))
                        MsgBox("Factura con Folio: " & dr("Folio").ToString & " Ya Fue Timbrada Se descargan El XML y PDF", MsgBoxStyle.Information)
                        FactTimbrada = False
                        LimpiaPantalla()
                        dtCliente.Rows.Clear()
                        lblTextoAnuncio.Visible = False
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FACTURA NO TIMBRADA SE CONTINUA PROCESO: " & vbNewLine

                        intSiguienteFolio = dr("Folio")
                        BorrarFacturaGlobalPendiente(dr("Folio"), FechaFact)
                        MovBorrados = True
                    End If
                Next dr
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "------------------------------------------------------------" & vbNewLine

            End If

            '--------------------------------------ftexto

            BuscaCodyDescProd()
            sSQL = "sps_VINO_FacturaPeriodica"
            oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
            oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
            oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaFin.Value, "yyyyMMdd"))
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
            ' oParam(13) = New SqlClient.SqlParameter("@pTipoFactura2", "GLOBAL")
            dtDetalle = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

            Sistema = "GLOBAL"
            dtDetalle = AgrupaTickets()

            If bolTienePuntodeVenta Then
                'tiene punto de venta
                If bolTieneVentaAparatos Or bolTieneVentaJoyeria Then
                    'tiene venta de aparatos
                    Try
                        lblTextoAnuncio.Text = "Esperando actualización de Aparatos..."
                        lblTextoAnuncio.Visible = True
                        lblTextoAnuncio.Refresh()
                        'tratando de conectar al servidor de ventas electronicos (12)
                        'SQLServer.Init(, strBDAQ, strServerAQ, strUsrAQ, strPwdAQ)
                        SQLServer.Init(, strBDAQGlobal, strServerAQ, strUsrAQ, strPwdAQ)
                        'probando
                        sSQL = "SELECT TOP 1 * FROM PE.dbo.Catalogos"
                        dtTest = SQLServer.ExecSQLReturnDT(sSQL, "Catalogos")
                        'pasó la prueba, se continua con la obtencion del detalle
                        'esperando actualizacion de adminpaq por si hubiera
                        lblTextoAnuncio.Visible = True
                        lblTextoAnuncio.Refresh()
                        AdminpaqEsperaActualizacion()
                        lblTextoAnuncio.Visible = False
                        lblTextoAnuncio.Refresh()

                        'sSQL = "sps_AQ_FacturaPeriodica"
                        sSQL = "sps_AVR_FacturaGlobal"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaFin.Value, "yyyyMMdd"))
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
                                    drNew("TipoAparato") = drDeta2("TipoAparato")
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
                                    drNew("TipoAparato") = drDeta2("TipoAparato")
                                    dtDetalle.Rows.Add(drNew)
                                    dtDetalle.AcceptChanges()
                                End If
                            Next drDeta2
                        End If

                        lblTextoAnuncio.Text = "Verificando si hay devoluciones..."
                        lblTextoAnuncio.Visible = True
                        lblTextoAnuncio.Refresh()

                        'DEVOLUCIONES
                        SQLServer.Init(, strBDAQ, strServerAQ, strUsrAQ, strPwdAQ)

                        sSQL = "sps_AQ_FacturaPeriodica_Devs"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaFin.Value, "yyyyMMdd"))
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
                    Catch excnn As Exception
                        Me.Cursor = Cursors.Default
                        MsgBox("no hay conexión con el servidor de venta de aparatos, por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturacion")
                        Me.Cursor = Cursors.WaitCursor
                    End Try
                End If

                'If bolTieneVentaJoyeria Then
                '    'tiene venta de joyería
                '    Try
                '        lblTextoAnuncio.Text = "Esperando actualización de Joyeria..."
                '        lblTextoAnuncio.Visible = True
                '        lblTextoAnuncio.Refresh()

                '        'tratando de conectar al servidor de ventas joyería (8)
                '        SQLServer.Init(, strBDJY, strServerJY, strUsrJY, strPwdJY)
                '        'probando
                '        sSQL = "SELECT TOP 1 * FROM BDSPSAYT.dbo.BSAYTCatalogos"
                '        dtTest = SQLServer.ExecSQLReturnDT(sSQL, "Catalogos")

                '        'pasó la prueba, se continua con la obtencion del detalle
                '        sSQL = "sps_JOYERIA_FacturaPeriodica"
                '        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                '        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
                '        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaFin.Value, "yyyyMMdd"))
                '        oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                '        oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", DBNull.Value)
                '        oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                '        oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
                '        oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "GLOBAL")
                '        oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ)
                '        oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", DBNull.Value)
                '        oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DBNull.Value)
                '        oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", DBNull.Value)
                '        oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DBNull.Value)
                '        dtDeta2 = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

                '        If Not dtDeta2 Is Nothing AndAlso dtDeta2.Rows.Count > 0 Then
                '            For Each drDeta2 As DataRow In dtDeta2.Rows
                '                drNew = dtDetalle.NewRow
                '                drNew("Concepto") = drDeta2("Concepto")
                '                drNew("Fecha") = drDeta2("Fecha")
                '                drNew("Tipo") = drDeta2("Tipo")
                '                drNew("Prefijo") = drDeta2("Prefijo")
                '                drNew("NoTicket") = drDeta2("NoTicket")
                '                drNew("TipoMov") = drDeta2("TipoMov")
                '                drNew("Importe") = drDeta2("Importe")
                '                drNew("Costo") = drDeta2("Costo")
                '                drNew("Descuento") = drDeta2("Descuento")
                '                drNew("Total") = drDeta2("Total")
                '                drNew("ImportePagado") = drDeta2("ImportePagado")
                '                drNew("Interes") = drDeta2("Interes")
                '                drNew("Recargo") = drDeta2("Recargo")
                '                drNew("IVA") = drDeta2("IVA")
                '                dtDetalle.Rows.Add(drNew)
                '                dtDetalle.AcceptChanges()
                '            Next drDeta2
                '        End If

                '    Catch excnn As Exception
                '        Me.Cursor = Cursors.Default
                '        MsgBox("No hay conexión con el servidor de venta de joyería, por favor avise a sistemas!" & vbCrLf & excnn.Message, MsgBoxStyle.Exclamation, "Facturacion")
                '        Me.Cursor = Cursors.WaitCursor
                '    End Try
                'End If
            End If

            For Each dr As DataRow In dtDetalle.Rows
                Concepto = ""
                NombreMov(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto)
                dr("TipoMov") = Concepto
            Next dr

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

                If dblValidaIVA > 0 Then
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

            lblTextoAnuncio.Text = "Verificando movimientos ya facturados..."
            lblTextoAnuncio.Visible = True
            lblTextoAnuncio.Refresh()

            'regreso la conexión al servidor de la sucursal
            ConectaBD()

            'REVISANDO LOS QUE YA SE FACTURARON EN UNA GLOBAL O EN UNA INDIVIDUAL
            Dim arrBorrar As New ArrayList
            Dim x As Integer
            Dim drBorrar As DataRow
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

            dblSumaImporte = 0
            dblSumaDescuento = 0
            dblSumaIVA = 0
            dblSumaTotal = 0
            dblSubtotal = 0
            dgvLista.DataSource = dtDetalle
            dgvLista.Refresh()

            For Each dr As DataRow In dtDetalle.Rows
                dblSumaDescuento += Math.Round(dr("Descuento"), 6)
                dblSumaIVA += Math.Round(dr("IVA"), 6)
                dblSumaTotal += Math.Round(dr("ImportePagado"), 6)
            Next dr

            txtSubTotal.Text = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")
            dblSubtotal = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.000000")
            txtDescuento.Text = Format(dblSumaDescuento, "#,##0.00")
            txtIVA.Text = Format(dblSumaIVA, "#,##0.00")
            txtTotalFactura.Text = Format(dblSumaTotal, "#,##0.00")
            txtCantPartidas.Text = dtDetalle.Rows.Count.ToString

            'forzando el orden de las columnas
            With dgvLista
                .Columns("colTipo").DisplayIndex = 0
                .Columns("colPrefijo").DisplayIndex = 1
                .Columns("colFolioOp").DisplayIndex = 2
                .Columns("colTipoMov").DisplayIndex = 3
                .Columns("colDescuento").DisplayIndex = 4
                .Columns("colIVA").DisplayIndex = 5
                .Columns("colImportePagado").DisplayIndex = 6
                .Columns("colCosto").DisplayIndex = 7
                .Columns("colImporte").DisplayIndex = 8
                .Columns("colInteres").DisplayIndex = 9
                .Columns("colRecargo").DisplayIndex = 10
            End With

            If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                MsgBox("No hay movimientos pendientes de facturar!", MsgBoxStyle.Exclamation, "Facturación")
            End If

            ConectaBD()

            lblTextoAnuncio.Visible = False
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try
    End Sub

    Private Sub frmFacturaGlobalDiaria_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmFactGlbl = Nothing
    End Sub

    Private Sub frmFacturaGlobalDiaria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.BackgroundImage = Pantallazo
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        Me.Text = "Factura Global Diaria - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        dtpFechaIni.Value = CDate(strFechaUltimoCierre)
        dtpFechaFin.Value = CDate(strFechaUltimoCierre)
        ivaAJ = BuscaIvaSuc(IvaS)
        cboInclDirSuc.SelectedIndex = 1
        cboInclDirCte.SelectedIndex = 0
    End Sub

    Private Sub btnGenerarFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarFactura.Click
        Dim Concepto As String = ""
        Dim NvoConcepto As String = ""
        dtDetalleGlob.Clear()
        dtDetalleDev.Clear()
        dtDetDevAvr.Clear()

        'nombreArchi = "C:\SPE\VINO\LOG\" & "LogFactura" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"

        Try
            If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                MsgBox("No hay información para facturar!", MsgBoxStyle.Exclamation, "Facturación")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            lblTextoAnuncio.Text = "Validando información inicial..."
            lblTextoAnuncio.Visible = True
            lblTextoAnuncio.Refresh()

            Factura = ""
            'obteniendo los datos del lugar de emision (sucursal)
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
                MsgBox("No se encontraron datos del lugar de emisión, por favor avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If
            'obteniendo los datos del cliente, para este caso, es publico en general
            DatosCliente()
            If dtCliente Is Nothing Then
                Exit Sub
            End If
            If dtCliente.Rows.Count <= 0 Then
                MsgBox("No se encontraron datos del cliente, por favor avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If

            lblTextoAnuncio.Text = "Generando tabla de detalle..."
            lblTextoAnuncio.Visible = True
            lblTextoAnuncio.Refresh()

            'estos son los datos para a facturar            
            dtDetalleGlob = GeneraTablaDetalle(dtDetalle)

            For Each dr As DataRow In dtDetalleGlob.Rows
                Concepto = dr("Concepto").ToString
                NombreMovFac(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto, Mid(dr("NoTicket").ToString, 1, 1), NvoConcepto)
                dr("TipoMov") = NvoConcepto
                dr("DescripcionSAT") = NvoConcepto
            Next dr

            Factura = "GLOBAL"
            lblTextoAnuncio.Text = "Extrayendo datos del cliente..."
            lblTextoAnuncio.Visible = True
            lblTextoAnuncio.Refresh()

            errorFG = False

            If strVersionFacturas <> "40" Then
                GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleGlob, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaGlobal, )
            Else
                GeneraFactura40(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleGlob, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaGlobal, )
            End If

            If errorFG Then
                GoTo NoseHaceNada
            End If

            txtRespuesta.Text = strRespuesta
            imgBytes = Convert.FromBase64String(strCBB)
            Me.picCBB.Image = Bytes2Image(imgBytes)

            'SI HAY DEVOLUCIONES, GENERA LAS NOTAS DE CREDITO
            If Not dtDevsEnca Is Nothing AndAlso dtDevsEnca.Rows.Count > 0 Then
                Dim x1 As String = ""
                Dim x2 As String = ""

                lblTextoAnuncio.Text = "Generando notas de crédito..."
                lblTextoAnuncio.Visible = True
                lblTextoAnuncio.Refresh()

                GeneraNotasdeCredito2(x1, x2)
            End If

            LimpiaPantalla()

NoseHaceNada:

            dtCliente.Rows.Clear()

            lblTextoAnuncio.Visible = False
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try
    End Sub

    Private Sub btnExportaExcel_Click(sender As Object, e As EventArgs) Handles btnExportaExcel.Click
        GridExport(Me.dgvLista)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaPantalla()
    End Sub


    Private Sub dtpFechaIni_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaIni.ValueChanged
        dtpFechaFin.Value = dtpFechaIni.Value
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
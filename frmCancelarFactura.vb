Public Class frmCancelarFactura
    Public TipoFactura As String = ""
    Private Sub guardaDatosCancelacion(ByVal datos As DataTable, ByVal motivo As String)
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Try
            For Each dr As DataRow In dtEnviar.Rows
                If conAcuse = True Then
                    sSQL = "UPDATE BDSPEXPRESS.dbo.BPFFacturas SET Acuse = 'SI', Estatus = 'C', MotivoCancelacion = '" & motivo & "' WHERE Folio = '" & dr("Folio") & "'  and Serie = '" & dr("Serie") & "' and FolioFiscal = '" & dr("FolioFiscal") & "'"
                Else
                    sSQL = "UPDATE BDSPEXPRESS.dbo.BPFFacturas SET Estatus = 'C', MotivoCancelacion = '" & motivo & "' WHERE Folio = '" & dr("Folio") & "'  and Serie = '" & dr("Serie") & "' and FolioFiscal = '" & dr("FolioFiscal") & "'"
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

    Private Sub frmCancelarFactura_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DatosCancelar As String = ""
        Me.BackgroundImage = Pantallazo
        Me.Text = "Cancelar - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)

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
            CargaTipoRelacion()
            cboInclDirSuc.SelectedIndex = 1
        Else
            Label4.Visible = False
            cboTipoRelacion.Visible = False
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

            cancelaFactura(dtEnviar)
            'seCancelo = True
            If seCancelo = True Then
                guardaDatosCancelacion(dtEnviar, motivo)
                If TipoCancelacion = "SUSTITUCION" Then
                    If TipoFactura = "INDIVIDUAL" Then
                        CFDIRelacionadoCancelado = dr("FolioFiscal").ToString
                        TipoRelacionCancelado = Mid(cboTipoRelacion.Text, 1, 2)


                    Else
                        CFDIRelacionadoCancelado = dr("FolioFiscal").ToString
                        TipoRelacionCancelado = Mid(cboTipoRelacion.Text, 1, 2)

                        ObtenerMovimientos(FechaCancelado)
                        Facturar(CFDIRelacionadoCancelado, TipoRelacionCancelado)
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

    Private Sub ObtenerMovimientosIndividual()

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

        'limpiando las tablas
        dtDetalle = New DataTable
        dsDevs = New DataSet
        dtDevsEnca = New DataTable
        dtDevsDeta = New DataTable

        Me.Cursor = Cursors.WaitCursor

INICIO:

        Dim oParam(14) As SqlClient.SqlParameter

        'Buscando codigos y descripcion de productos
        BuscaCodyDescProd()

        Try
            Select Case TipoFac
                Case "E"
                    'Empeño
                    TipoBusqueda = ""
                    Try

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


            End Select

            Me.Cursor = Cursors.Default

            'regreso la conexión al servidor de la sucursal
            ConectaBD()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
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
            ' GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleGlob, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaGlobal, )
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
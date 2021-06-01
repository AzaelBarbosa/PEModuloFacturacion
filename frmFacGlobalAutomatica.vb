Imports System.IO


Public Class frmFacGlobalAutomatica
    Dim FechaFacturada As Boolean = False
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

    Private Sub Limpia()
        Try
            cboInclDirCte.SelectedIndex = 0
            cboInclDirSuc.SelectedIndex = 1

            dtpFechaIni.Value = CDate(strFechaUltimoCierre)
            dtpFechaFin.Value = CDate(strFechaUltimoCierre)

            If Not dtDetalle Is Nothing And dtDetalle.Rows.Count > 0 Then
                dtDetalle.Rows.Clear()
            End If
            dgvLista.DataSource = dtDetalle
            dsDevs = New DataSet
            dtDevsEnca = New DataTable
            dtDevsDeta = New DataTable

        Catch ex As Exception
            texto = texto & Format(Now, "HHmm").ToString & "~" & "Error: " & ex.Message & vbNewLine
            My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
            End
        End Try
    End Sub

    Private Sub frmfrmFacGlobalAutomatica_Load(sender As Object, e As EventArgs) Handles Me.Load
        strTipoFactura = "GLOBAL"
        strmodoFactura = "AUTOMATICA"
        Automatico()
        ''Me.BackgroundImage = Pantallazo
        'Me.Text = "Factura Global Automatica - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        'Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        'Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)

        'dtpFechaIni.Value = CDate(strFechaUltimoCierre)
        'dtpFechaFin.Value = CDate(strFechaUltimoCierre)

        'ivaAJ = BuscaIvaSuc(IvaS)
        'cboInclDirSuc.SelectedIndex = 1
        'cboInclDirCte.SelectedIndex = 0

        'Try
        '    'PRUEBA DE ESCRITURA BLOC DE NOTA   C:\SPE\VINO\LOG\
        '    nombreArchi = "C:\SPE\VINO\LOG\" & "LogFactura" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
        '    If (System.IO.File.Exists(nombreArchi)) Then
        '        File.Delete(nombreArchi)
        '    End If

        '    texto = Format(Now, "HH:mm:ss").ToString & "~" & "INICIANDO FACTURA GLOBAL AUTOMATICA.............................." & vbNewLine
        '    buscar()
        '    facturar()
        '    'BackgroundWorker1.RunWorkerAsync()
        '    'End
        'Catch ex As Exception
        '    texto = texto & Format(Now, "HHmm").ToString & "~" & "Error: " & ex.Message & vbNewLine
        '    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
        '    End
        'End Try
    End Sub
    Public Sub Automatico()



        strTipoFactura = "GLOBAL"
        strmodoFactura = "AUTOMATICA"

        Try

            If IntConexion > 0 Then
                Timer1.Enabled = False
                ConectaBD()
                GoTo Reintento
            End If

            SeUsaMasivo()

            FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
            nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"

            If UsoFManual = 1 Then
                dtpFechaIni.Value = CDate(FechaManual)
                dtpFechaFin.Value = CDate(FechaManual)
            Else
                dtpFechaIni.Value = CDate(strFechaUltimoCierre)
                dtpFechaFin.Value = CDate(strFechaUltimoCierre)
            End If

            ivaAJ = BuscaIvaSuc(IvaS)
            cboInclDirSuc.SelectedIndex = 1
            cboInclDirCte.SelectedIndex = 0

            'PRUEBA DE ESCRITURA BLOC DE NOTA   C:\SPE\VINO\LOG\
            If UsoFManual = 1 Then
                nombreArchi = sRuta & "\LOG\" & "LogFactura_FA_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                FechaFact = Replace(FechaManual, "-", "")
                strFechaBusqueda = FechaFact
            Else
                nombreArchi = sRuta & "\LOG\" & "LogFactura_FA_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                FechaFact = Replace(strFechaUltimoCierre, "-", "")
                strFechaBusqueda = FechaFact
            End If


            If (System.IO.File.Exists(nombreArchi)) Then
                File.Delete(nombreArchi)
            End If

            If UsoFManual = 1 Then
                texto = Format(Now, "HH:mm:ss").ToString & "~" & "INICIANDO FACTURA GLOBAL AUTOMATICA.............................." & vbNewLine
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "SUCURSAL: " & Format(intNoSucursal, "000").ToString & " " & strNombreSuc & vbNewLine
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FECHA MOVIMIENTO: " & FechaManual.ToString & " " & vbNewLine
            Else
                texto = Format(Now, "HH:mm:ss").ToString & "~" & "INICIANDO FACTURA GLOBAL AUTOMATICA.............................." & vbNewLine
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "SUCURSAL: " & Format(intNoSucursal, "000").ToString & " " & strNombreSuc & vbNewLine
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FECHA MOVIMIENTO: " & strFechaUltimoCierre.ToString & " " & vbNewLine
            End If


Reintento:

            buscar()
            facturar()
        Catch ex As Exception
            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
            My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
            EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
            End
        End Try

    End Sub
    Private Sub TestDoEvents()
        For i As Integer = 0 To 15000000
            Application.DoEvents()
        Next
        Automatico()
    End Sub
    Private Sub SeUsaMasivo()
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable

        sSQL = "SELECT Valor1T, Valor1N FROM BPFCatalogos WHERE Tabla=40 AND Elemento = 1"

        dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "Masivo")
        If Not dtBusca Is Nothing Then
            If dtBusca.Rows.Count > 0 Then
                FechaManual = dtBusca.Rows(0).Item("Valor1T")
                UsoFManual = dtBusca.Rows(0).Item("Valor1N")
            End If
        End If

        If FechaManual <> "" Then
            FechaManual = Mid(FechaManual, 1, 4) & "-" & Mid(FechaManual, 5, 2) & "-" & Mid(FechaManual, 7, 2)
        End If
    End Sub

    Private Sub SeFacturoGlobal()
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable

        sSQL = "SELECT * FROM BPFFacturas WHERE TipoFactura='GLOBAL' AND FechaFactura = '" & Format(dtpFechaIni.Value, "yyyyMMdd") & "'"

        dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "Buscar")
        If Not dtBusca Is Nothing Then
            If dtBusca.Rows.Count > 0 Then
                FechaFacturada = True
            Else
                FechaFacturada = False
            End If
        End If

    End Sub

    Private Sub buscar()
        Dim sSQL As String = ""
        Dim oParam(12) As SqlClient.SqlParameter
        Dim dtTest As New DataTable
        Dim dtDeta2 As New DataTable
        Dim dtDeta3 As New DataTable
        Dim drNew As DataRow
        Dim Concepto As String = ""

        Sistema = ""
        'nombreArchi = "C:\SPE\VINO\LOG\" & "LogFactura" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"

        Try


            'limpiando las tablas
            dtDetalle = New DataTable
            dsDevs = New DataSet
            dtDevsEnca = New DataTable
            dtDevsDeta = New DataTable

            'OBTENIENDO EL DETALLE DE LA INFORMACION DE LA FACTURA

            ''-------------------------------------
            ''---BUSCAR FACTURA GLOBAL PENDIENTE---
            ''-------------------------------------

            'If BuscaFacturaGlobalPendiente(FechaFact) = True Then
            '    For Each dr As DataRow In dtFactPend.Rows
            '        Comprobando = "SI"
            '        obtenerPDF(dtFactPend)
            '        If FactTimbrada = True Then
            '            obtenerPDF(dtFactPend)
            '            obtenerXML(dtFactPend)
            '            ActualizaMovimientosFacturados(enTipoDocumento.Factura, dr("Folio"))
            '        Else
            '            intSiguienteFolio = dr("Folio")
            '            BorrarFacturaGlobalPendiente(dr("Folio"))
            '        End If
            '    Next dr
            'End If

            ''--------------------------------------

            BuscaCodyDescProd()
            sSQL = "sps_VINO_FacturaPeriodica"
            oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
            oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
            oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaIni.Value, "yyyyMMdd"))
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
            'oParam(13) = New SqlClient.SqlParameter("@pTipoFactura2", "GLOBAL")
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

                        AdminpaqEsperaActualizacion()

                        sSQL = "sps_AVR_FacturaGlobal"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaIni.Value, "yyyyMMdd"))
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

                        sSQL = "sps_AQ_FacturaPeriodica_Devs"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaIni.Value, "yyyyMMdd"))
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

                        If IntConexion > 3 Then
                            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "ERROR: NO HAY CONEXION CON EL SERVIDOR DE VENTA DE APARATOS: " & strServerAQ & vbNewLine
                            My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                            FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                            nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                            EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                            End
                        Else
                            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "NO SE PUDO CONECTAR AL SERVIDOR DE APARATOS: " & strServerAQ & "....... REINTENTO " & IntConexion & vbNewLine
                            'Timer1.Enabled = True
                            'Timer1.Start()
                            TestDoEvents()
                        End If
                    End Try

                End If
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

            If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                If FechaFacturada = True Then
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Día ya fue facturado previamente!" & vbNewLine
                    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    'EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                    End
                Else
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "No hay movimientos pendientes de facturar!" & vbNewLine
                    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    'EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                    End
                End If
            End If

            ConectaBD()

        Catch ex As Exception

            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & TipoError & " Error: " & ex.Message & vbNewLine
            My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
            FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
            nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
            EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
            End
        End Try


    End Sub

    Private Sub facturar()
        Dim Concepto As String = ""
        Dim NvoConcepto As String = ""
        dtDetalleGlob.Clear()
        dtDetalleDev.Clear()
        dtDetDevAvr.Clear()

        Try
            If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "ERROR: No hay información para facturar" & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                End
            End If
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
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "ERROR: No se encontraron datos del lugar de emisión" & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                End
            End If
            'obteniendo los datos del cliente, para este caso, es publico en general
            DatosCliente()
            If dtCliente Is Nothing Then
                End
            End If
            If dtCliente.Rows.Count <= 0 Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "ERROR: No se encontraron datos del cliente" & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                End
            End If

            'estos son los datos para facturar            
            dtDetalleGlob = GeneraTablaDetalle(dtDetalle)

            For Each dr As DataRow In dtDetalleGlob.Rows
                Concepto = dr("Concepto").ToString
                NombreMovFac(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto, Mid(dr("NoTicket").ToString, 1, 1), NvoConcepto)
                dr("TipoMov") = NvoConcepto
                dr("DescripcionSAT") = NvoConcepto
            Next dr

            Factura = "GLOBAL"

            errorFG = False
            GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleGlob, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaGlobal, )

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

            End

        Catch ex As Exception
            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
            My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
            FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
            nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
            EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
            End
        End Try
    End Sub

    'Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    '    buscar()
    '    facturar()
    'End Sub

    'Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
    '    End
    'End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Automatico()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
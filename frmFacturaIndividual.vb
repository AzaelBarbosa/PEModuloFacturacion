Imports VB = Microsoft.VisualBasic
Imports System.IO
Imports System.Text

Public Class frmFacturaIndividual
    Dim arrCondPago As New ArrayList

#Region "Procedimientos"
    Private Sub LimpiaPantalla()
        Dim dtResFake As New DataTable
        Dim dtFecha As Date = DateSerial(Year(Date.Today), Month(Date.Today), 1)
        Try
            lblTextoAnuncio.Visible = False
            tipoMovFact = ""
            Me.txtSerieDoc.Text = ""
            Me.txtCliente.Text = ""
            Me.txtFolioBoleta.Text = ""
            Me.txtFolioOperacion.Text = ""
            Me.txtFolioOperacion.Left = txtCliente.Left
            Me.txtTotalImportePagado.Text = "$ 0.00"
            Me.txtDescuento.Text = "$ 0.00"
            Me.txtSubtotal.Text = "$ 0.00"
            Me.txtIva.Text = "$ 0.00"
            Me.chbxFechas.Checked = True
            strDirSuc = False
            strDirCli = False
            dtResFake = dtDetalle.Clone
            dgvResultado.DataSource = dtResFake
            dgvFacturar.Rows.Clear()
            Me.Label16.Visible = False
            Me.txtDiasPagoAplazado.Visible = False
            Me.Label17.Visible = False
            Me.dtpFechaIni.Value = dtFecha
            Me.dtpFechaFin.Value = Date.Today
            Me.dtpFechaIni.Enabled = False
            Me.dtpFechaFin.Enabled = False
            Me.cdroFacGlobal.Visible = False
            Me.cdroFacIndividual.Visible = False
            Me.lblFacGlobal.Visible = False
            Me.lblFacIndividual.Visible = False
            If chbxFechas.Checked = True Then
                dtpFechaIni.Enabled = True
                dtpFechaFin.Enabled = True
                txtFolioBoleta.Focus()
            Else
                dtpFechaIni.Enabled = False
                dtpFechaFin.Enabled = False
            End If
            ordenGrids()
            LlenaCombo()
            Me.cboSistema.Focus()
            Me.cboInclDirCte.SelectedIndex = 0
            Me.cboInclDirSuc.SelectedIndex = 1
            Me.cboCondPago.SelectedIndex = 0
            Me.cboSistema.SelectedIndex = 0
            Me.rbBoleta.Focus()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, "Limpia Pantalla")
        End Try
    End Sub
    Private Function BuscaFolioOper(ByVal Folio) As Integer
        Dim Resutlado As Integer = 0
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim dr As DataRow

        Try
            TipoFac = ""
            serieFac = ""
            folioFac = ""
            fechaFac = ""
            sSQL = "SELECT a.FolioOperacion, a.Folio " & _
                   "FROM BPFMovimientosCaja a  " & _
                   "INNER JOIN BPFBoletasPagosFijos b ON a.Folio = b.Folio " & _
                   "WHERE a.Folio ='" & Folio & "' AND a.FechaMovimiento =< '" & Format(dtpFechaIni.Value, "yyyyMMdd") & "' AND a.FechaMovimiento >= '" & Format(dtpFechaFin.Value, "yyyyMMdd") & "'"

            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFMovimientosCaja")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    dr = dtBusca.Rows(0)
                    Resutlado = dr("FolioOperacion")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            BuscaFolioOper = Resutlado
        End Try

    End Function
    Private Sub ordenGrids()
        ''forzando el orden de las columnas
        With dgvResultado
            .Columns("colRSel").DisplayIndex = 0
            .Columns("colRFecha").DisplayIndex = 1
            .Columns("colRTipo").DisplayIndex = 2
            .Columns("colRPrefijo").DisplayIndex = 3
            .Columns("colRNoTicket").DisplayIndex = 4
            .Columns("colRTipoMov").DisplayIndex = 5
            .Columns("colRImportePago").DisplayIndex = 6
            .Columns("colRCosto").DisplayIndex = 7
            .Columns("colRDescuento").DisplayIndex = 8
            .Columns("colRImporte").DisplayIndex = 9
            .Columns("colRInteres").DisplayIndex = 10
            .Columns("colRRecargo").DisplayIndex = 11
            .Columns("colRIVA").DisplayIndex = 12
            .Columns("colRConcepto").DisplayIndex = 13
        End With
        With dgvFacturar
            .Columns("colFSel").DisplayIndex = 0
            .Columns("colFFecha").DisplayIndex = 1
            .Columns("colFTipo").DisplayIndex = 2
            .Columns("colFPrefijo").DisplayIndex = 3
            .Columns("colFNoTicket").DisplayIndex = 4
            .Columns("colFTipoMov").DisplayIndex = 5
            .Columns("colFImportePago").DisplayIndex = 6
            .Columns("colFCosto").DisplayIndex = 7
            .Columns("colFDescuento").DisplayIndex = 8
            .Columns("colFImporte").DisplayIndex = 9
            .Columns("colFInteres").DisplayIndex = 10
            .Columns("colFRecargo").DisplayIndex = 11
            .Columns("colFIVA").DisplayIndex = 12
            .Columns("colFConcepto").DisplayIndex = 13
        End With
    End Sub

    Private Sub LlenaCombo()
        Try
            arrCondPago = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "", , "Tabla=108 AND Elemento<>0", "DescCorta")
            cboCondPago.DataSource = arrCondPago
            cboCondPago.DisplayMember = "Description"
            cboCondPago.ValueMember = "ID"

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

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

    Private Function GeneraTablaDetalle() As DataTable
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
                            drNew("TipoAparato") = 0
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
                        drNew("TipoAparato") = 0
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
                            drNew("TipoAparato") = 0
                            dtReturn.Rows.Add(drNew)
                            dtReturn.AcceptChanges()
                        End If
                    End If
                Next j

            Else
                For intFila = 0 To dgvFacturar.Rows.Count - 1
                    If dgvFacturar.Item("colFImporte", intFila).Value > 0 And dgvFacturar.Item("colTipoAparato", intFila).Value <> 648 Then
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
                        drNew("TipoAparato") = 0
                        drNew("Cantidad") = dgvFacturar.Item("colFCantidad", intFila).Value
                        drNew("Neto") = dgvFacturar.Item("colFNeto", intFila).Value
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
                        drNew("TipoAparato") = 0
                        drNew("Cantidad") = dgvFacturar.Item("colFCantidad", intFila).Value
                        drNew("Neto") = dgvFacturar.Item("colFNeto", intFila).Value
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()

                    ElseIf dgvFacturar.Item("colTipoAparato", intFila).Value = 648 Then

                        drNew = dtReturn.NewRow
                        drNew("Concepto") = dgvFacturar.Item("colFConcepto", intFila).Value
                        drNew("Fecha") = dgvFacturar.Item("colFFecha", intFila).Value
                        drNew("Tipo") = dgvFacturar.Item("colFTipo", intFila).Value
                        drNew("NoTicket") = dgvFacturar.Item("colFPrefijo", intFila).Value & "-" & dgvFacturar.Item("colFNoticket", intFila).Value
                        drNew("TipoMov") = dgvFacturar.Item("colFTipoMov", intFila).Value
                        drNew("Importe") = CDbl(dgvFacturar.Item("colFImportePago", intFila).Value) - CDbl(dgvFacturar.Item("colFIVA", intFila).Value)
                        drNew("Descuento") = dgvFacturar.Item("colFDescuento", intFila).Value
                        drNew("IVA") = dgvFacturar.Item("colFIVA", intFila).Value
                        drNew("Total") = CDbl(dgvFacturar.Item("colFImportePago", intFila).Value) - CDbl(dgvFacturar.Item("colFIVA", intFila).Value)
                        drNew("Costo") = dgvFacturar.Item("colFCosto", intFila).Value
                        drNew("ImportePagado") = dgvFacturar.Item("colFImportePago", intFila).Value
                        drNew("Interes") = dgvFacturar.Item("colFInteres", intFila).Value
                        drNew("Recargo") = dgvFacturar.Item("colFRecargo", intFila).Value
                        drNew("UUIDFacturaGlobal") = dgvFacturar.Item("colFUUIDFacturaGlobal", intFila).Value
                        drNew("FormaPagoSAT") = dgvFacturar.Item("colFFormaPagoSAT", intFila).Value
                        drNew("ClaveSAT") = dgvFacturar.Item("colFCodigoSAT", intFila).Value
                        drNew("DescripcionSAT") = dgvFacturar.Item("colFDescripcionSAT", intFila).Value
                        drNew("TipoAparato") = dgvFacturar.Item("colTipoAparato", intFila).Value
                        drNew("DescripcionSAT2") = dgvFacturar.Item("colFDescripcionSAT2", intFila).Value
                        drNew("Cantidad") = dgvFacturar.Item("colFCantidad", intFila).Value
                        drNew("Neto") = dgvFacturar.Item("colFNeto", intFila).Value
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
                        drNew("TipoAparato") = 0
                        drNew("Cantidad") = dgvFacturar.Item("colFCantidad", intFila).Value
                        drNew("Neto") = dgvFacturar.Item("colFNeto", intFila).Value
                        dtReturn.Rows.Add(drNew)
                        dtReturn.AcceptChanges()

                    End If

                Next intFila
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            GeneraTablaDetalle = dtReturn
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
            dgvFacturar.Item("colTipoAparato", intFilaNueva).Value = dgvResultado.Item("colRTipoAparato", NoFilaResultado).Value
            dgvFacturar.Item("colFDescripcionSAT2", intFilaNueva).Value = dgvResultado.Item("colRDescripcionSAT2", NoFilaResultado).Value
            dgvFacturar.Item("colFCantidad", intFilaNueva).Value = dgvResultado.Item("colRCantidad", NoFilaResultado).Value
            dgvFacturar.Item("colFNeto", intFilaNueva).Value = dgvResultado.Item("colRNeto", NoFilaResultado).Value
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

    Private Function YaAgregado(ByVal NoTicket As String, ByVal Concepto As String, ByVal fecha As String, ByVal TipoMov As String, ByVal Importe As String, ByVal Costo As String) As Boolean
        Dim bolResultado As Boolean = False
        Dim iFila As Integer = 0
        Try
            For iFila = 0 To dgvFacturar.RowCount - 1
                If (dgvFacturar.Item("colFNoTicket", iFila).Value).ToString = NoTicket And dgvFacturar.Item("colFConcepto", iFila).Value = Concepto And dgvFacturar.Item("colFFecha", iFila).Value = fecha And dgvFacturar.Item("colFTipoMov", iFila).Value = TipoMov And dgvFacturar.Item("colFImportePago", iFila).Value = Importe And dgvFacturar.Item("colFCosto", iFila).Value = Costo Then
                    bolResultado = True
                    Exit For
                End If
            Next iFila
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            YaAgregado = bolResultado
        End Try
    End Function

    Private Function YaEnFacturaIndividual(ByVal Prefijo As String, ByVal NoTicket As String) As Boolean
        Dim bolResultado As Boolean = False
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim dr As DataRow
        Try
            TipoFac = ""
            serieFac = ""
            folioFac = ""
            fechaFac = ""
            sSQL = "SELECT TOP 1 b.Serie, b.Folio, b.TipoFactura,a.Serie,a.Folio,a.FechaFactura " & _
                   "FROM BPFFacturasPartidas b " & _
                   "INNER JOIN BPFFacturas a ON a.NoSucursal=b.NoSucursal AND a.Folio=b.Folio AND a.Serie=b.Serie AND a.TipoFactura=b.TipoFactura " & _
                   "WHERE b.TipoTicket='" & Prefijo & "' AND b.NoTicket='" & Trim(NoTicket) & "' and a.Estatus = 'A' AND A.TipoComprobante = 'I' " & _
                   "ORDER BY a.Folio DESC"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFFacturasPartidas")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    dr = dtBusca.Rows(0)
                    bolResultado = True
                    TipoFac = dr("TipoFactura")
                    serieFac = dr("Serie")
                    folioFac = dr("Folio")
                    fechaFac = dr("FechaFactura")
                    fechaFac = Mid(fechaFac, 7, 2) & "/" & Mid(fechaFac, 5, 2) & "/" & Mid(fechaFac, 1, 4)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            YaEnFacturaIndividual = bolResultado
        End Try
    End Function

    Private Sub SumaTickets()
        Dim intFila As Integer = 0
        Dim dblTotalImportePagado As Double = 0
        Dim dblTotalImporteFacturar As Double = 0
        dblSumaImporte = 0
        dblSumaDescuento = 0
        dblSumaIVA = 0
        dblSumaTotal = 0
        dblSumaInteres = 0
        dblSumaRecargo = 0
        dblSubtotal = 0
        dtDetalleInd.Clear()

        'dtDetalleInd = GeneraTablaDetalle()

        Try
            For intFila = 0 To dgvFacturar.RowCount - 1
                dblTotalImportePagado += CDbl(dgvFacturar.Item("colFImportePago", intFila).Value)
                dblTotalImporteFacturar += CDbl(dgvFacturar.Item("colFImporteFacturar", intFila).Value)
            Next intFila

            For intFila = 0 To dgvFacturar.RowCount - 1
                dblSumaTotal += CDbl(dgvFacturar.Item("colFImportePago", intFila).Value)
                dblSumaImporte += CDbl(dgvFacturar.Item("colFImporte", intFila).Value)
                dblSumaDescuento += CDbl(dgvFacturar.Item("colFDescuento", intFila).Value)
                dblSumaInteres += CDbl(dgvFacturar.Item("colFInteres", intFila).Value)
                dblSumaRecargo += CDbl(dgvFacturar.Item("colFRecargo", intFila).Value)
                dblSumaIVA += CDbl(dgvFacturar.Item("colFIVA", intFila).Value)
            Next intFila

            txtSubtotal.Text = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")
            dblSubtotal = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")
            txtDescuento.Text = Format(dblSumaDescuento, "$ #,##0.00")
            txtIva.Text = Format(dblSumaIVA, "$ #,##0.00")
            txtTotalImportePagado.Text = Format(dblSumaTotal, "$ #,##0.00")

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally

        End Try
    End Sub

    Private Function TicketEnFacturaGlobal(ByVal Prefijo As String, ByVal NoTicket As String, ByRef SerieFacturaGlobal As String, ByRef FolioFacturaGlobal As String, ByRef UUIDFacturaGlobal As String, ByVal TipoBusqueda As String) As Boolean
        Dim bolResult As Boolean = False
        Dim sSQL As String = ""
        Dim dtResult As New DataTable
        Dim dr As DataRow


        Try

            sSQL = ""
            sSQL = "SELECT TOP 1 a.Serie, a.Folio, a.FolioFiscal, a.TipoFactura, a.Estatus "
            sSQL &= "FROM BPFFacturas a "
            sSQL &= "INNER JOIN BPFFacturasPartidas b ON a.NoSucursal=b.NoSucursal AND a.Folio=b.Folio AND a.Serie=b.Serie AND a.TipoFactura=b.TipoFactura "
            sSQL &= "WHERE b.TipoTicket='" & Prefijo.Trim & "' "
            sSQL &= "AND b.NoTicket='" & NoTicket.Trim & "' and a.TipoComprobante = 'I' "
            sSQL &= "ORDER BY a.Folio DESC "
            'sSQL &= "AND a.TipoFactura='GLOBAL';"

            dtResult = SQLServer.ExecSQLReturnDT(sSQL, "BPFFacturas")

            If Not dtResult Is Nothing Then
                If dtResult.Rows.Count > 0 Then
                    dr = dtResult.Rows(0)
                    If Not IsDBNull(dr("Serie")) AndAlso Not IsDBNull(dr("Folio")) AndAlso Not IsDBNull(dr("FolioFiscal")) Then
                        bolResult = True
                        SerieFacturaGlobal = dr("Serie")
                        FolioFacturaGlobal = dr("Folio")
                        UUIDFacturaGlobal = dr("FolioFiscal")
                        TipoFac = dr("TipoFactura")
                        EstatusFac = dr("Estatus")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            TicketEnFacturaGlobal = bolResult
        End Try
    End Function

#End Region

    Private Sub dgvResultado_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.ColumnIndex = 7 Then
            MsgBox("Clic en la fila " & e.RowIndex.ToString)
        End If
    End Sub

    Private Sub frmFacturaIndividual_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.BackgroundImage = Pantallazo
        Me.Text = "Factura Individual - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        LimpiaPantalla()
    End Sub

    Private Sub btnBuscar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim sSQL As String = ""
        'Dim oParam(12) As SqlClient.SqlParameter
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


        Dim TipoTicket As String = ""
        Dim NoTicket As Integer = 0

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

        If chbxFechas.Checked Then
            If dtpFechaIni.Value > dtpFechaFin.Value Then
                Me.Cursor = Cursors.Default
                MsgBox("Rango de fechas inválido! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
                Exit Sub
            End If
        End If

        If txtFolioBoleta.Text = "" And txtCliente.Text = "" And txtFolioOperacion.Text = "" And txtSerieDoc.Text = "" Then
            Me.Cursor = Cursors.Default
            MsgBox("No hay ningun parametro de busqueda.", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        lblTextoAnuncio.Text = "Buscando Tickets disponibles para facturar..."
        lblTextoAnuncio.Visible = True
        lblTextoAnuncio.Refresh()

        If cboSistema.SelectedIndex = 0 Then
            Sistema = "EMPEÑO"
            TipoTicket = "E"
            If txtFolioOperacion.Text <> "" Then
                NoTicket = txtFolioOperacion.Text
            Else
                NoTicket = 0
            End If
        Else
            If cboSistema.SelectedIndex = 1 Then
                Sistema = "ADMINPAQ"
                TipoTicket = "A"
                NoTicket = txtFolioOperacion.Text
            Else
                Sistema = "JOYERIA"
                TipoTicket = "J"
                NoTicket = txtFolioOperacion.Text
            End If
        End If
INICIO:

        Dim oParam(14) As SqlClient.SqlParameter

        sArchivoLog = "S:\VINO\LOG\LogFactura_Proceso_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmmss").ToString & ".txt"
        wrFichero = File.AppendText(sArchivoLog)

        '-------------------------------------
        '---BUSCAR FACTURA INDIVIDUAL PENDIENTE---
        '-------------------------------------

        If BuscaFacturaIndividualPendiente(NoTicket, TipoTicket) = True Then
            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "VALIDANDO FACTURA PENDIENTE.......................... " & vbNewLine

            For Each dr As DataRow In dtFactPend.Rows
                Comprobando = "SI"
                obtenerXMLFolio(dtFactPend)
                If FactTimbrada = True Then
                    ActualizaMovimientosFacturados(IIf(dr("TipoComprobante") = "I", enTipoDocumento.Factura, enTipoDocumento.NotaCredito), dr("Folio"))
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
                    BorrarFacturaIndividualPendiente(dr("Folio"))
                    MovBorrados = True
                End If
            Next dr
            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "------------------------------------------------------------" & vbNewLine

        End If

        '--------------------------------------ftexto


        'Buscando codigos y descripcion de productos
        BuscaCodyDescProd()
        If chbxFechas.Checked Then
            strFechaBusqueda = Format(dtpFechaIni.Value, "yyyyMMdd").ToString & "a " & Format(dtpFechaFin.Value, "yyyyMMdd").ToString
        End If

        Try
            Select Case cboSistema.SelectedIndex
                Case 0
                    'Empeño
                    TipoBusqueda = ""
                    lblTextoAnuncio.Text = "Esperando actualización de Empeño..."
                    lblTextoAnuncio.Visible = True
                    lblTextoAnuncio.Refresh()
                    sSQL = "sps_VINO_FacturaPeriodica"
                    oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                    If chbxFechas.Checked Then
                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaFin.Value, "yyyyMMdd"))
                    Else
                        oParam(1) = New SqlClient.SqlParameter("@pFechaIni", DBNull.Value)
                        oParam(2) = New SqlClient.SqlParameter("@pFechaFin", DBNull.Value)
                    End If
                    If rbBoleta.Checked Then
                        If Not IsNumeric(txtFolioBoleta.Text) Then
                            Me.Cursor = Cursors.Default
                            MsgBox("Folio de boleta inválido! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
                            Exit Sub
                        End If
                        TipoBusqueda = "BOLETA"
                        oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", txtFolioBoleta.Text)
                        oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", DBNull.Value)
                        oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                        oParam(13) = New SqlClient.SqlParameter("@pFolioOperacion2", txtFolioBoleta.Text)
                    End If
                    If rbFolioOperacion.Checked Then
                        If Not IsNumeric(txtFolioOperacion.Text) Then
                            Me.Cursor = Cursors.Default
                            MsgBox("Folio de operación inválido! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
                            Exit Sub
                        End If
                        TipoBusqueda = "OPERACION"
                        If FolOperacion = "" Then
                            FolOperacion = txtFolioOperacion.Text
                        End If
                        oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                        oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", txtFolioOperacion.Text)
                        oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                        oParam(13) = New SqlClient.SqlParameter("@pFolioOperacion2", txtFolioOperacion.Text)
                    End If
                    If rbCliente.Checked Then
                        TipoBusqueda = "CLIENTE"
                        oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                        oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", DBNull.Value)
                        oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", txtCliente.Text)
                        oParam(13) = New SqlClient.SqlParameter("@pFolioOperacion2", DBNull.Value)
                    End If
                    oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
                    oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", DBNull.Value)

                    oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ)
                    oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", CodIntSat)
                    oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DescIntSat)
                    oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", CodApaSat)
                    oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
                    oParam(14) = New SqlClient.SqlParameter("@pTipoFactura2", "INDIVIDUAL")
                    dtDetalle = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

                    If Not dtDetalle Is Nothing Then
                        If dtDetalle.Rows.Count > 0 Then
                            DatosCliente(0, dtDetalle.Rows(0).Item("NoTicket").ToString)
                        End If
                    End If

                    If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                        If rbBoleta.Checked Then
                            strMsg = "No se encuentra la boleta " & txtFolioBoleta.Text & "!"
                            'LimpiaPantalla()
                        ElseIf rbCliente.Checked Then
                            strMsg = "No se encuentran los movimientos del cliente " & txtCliente.Text & "!"
                            'LimpiaPantalla()
                        ElseIf rbFolioOperacion.Checked Then
                            strMsg = "No se encuentra el folio de operación " & txtFolioOperacion.Text & "!"
                            'LimpiaPantalla()
                        End If

                        MsgBox(strMsg, MsgBoxStyle.Exclamation, "Facturación")
                    End If

                    'If rbBoleta.Checked = True Then
                    '    'PARA FOLIO OPERACION ----27/10/2020
                    '    If dtDetalle.Rows.Count <= 1 Then
                    '        For Each dr As DataRow In dtDetalle.Rows
                    '            FolioOperacion = dr("NoTicket").ToString
                    '            If dr("NoTicket").ToString <> FolioOperacion Then
                    '                FolOperacion = dr("NoTicket").ToString
                    '            End If
                    '        Next dr
                    '    Else
                    '        For Each dr As DataRow In dtDetalle.Rows
                    '            If dr("NoTicket").ToString <> FolioOperacion Then
                    '                FolOperacion = FolOperacion & "," & dr("NoTicket").ToString
                    '            End If
                    '            FolioOperacion = dr("NoTicket").ToString
                    '        Next dr
                    '        Carac = Len(FolOperacion)
                    '        FolOperacion = Mid(FolOperacion, 2)
                    '    End If
                    '    rbFolioOperacion.Checked = True
                    '    txtFolioOperacion.Text = FolioOperacion
                    '    GoTo INICIO
                    'End If


                Case 1
                    'Adminpaq
                    TipoBusqueda = ""
                    Try
                        'se requiere serie y folio del documento
                        If txtSerieDoc.Text.Trim = "" Then
                            Me.Cursor = Cursors.Default
                            MsgBox("Por favor capture la serie del documento!", MsgBoxStyle.Exclamation, "Facturación")
                            Exit Sub
                        End If
                        'tratando de conectar al servidor de ventas electronicos (12)
                        SQLServer.Init(, strBDAQ, strServerAQ, strUsrAQ, strPwdAQ)

                        sSQL = "SELECT TOP 1 * FROM Catalogos"
                        dtTest = SQLServer.ExecSQLReturnDT(sSQL, "Catalogos")

                        lblTextoAnuncio.Text = "Esperando actualización Aparatos..."
                        lblTextoAnuncio.Visible = True
                        lblTextoAnuncio.Refresh()
                        'AdminpaqEsperaActualizacion()

                        sSQL = "sps_AQ_FacturaPeriodica"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                        If chbxFechas.Checked Then
                            oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
                            oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaFin.Value, "yyyyMMdd"))
                        Else
                            oParam(1) = New SqlClient.SqlParameter("@pFechaIni", DBNull.Value)
                            oParam(2) = New SqlClient.SqlParameter("@pFechaFin", DBNull.Value)
                        End If
                        If rbFolioOperacion.Checked Then
                            If Not IsNumeric(txtFolioOperacion.Text) Then
                                Me.Cursor = Cursors.Default
                                MsgBox("Folio de operación inválido! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
                                Exit Sub
                            End If
                            oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                            oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", txtFolioOperacion.Text)
                            oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                            oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", txtSerieDoc.Text.Trim.ToUpper)
                        End If
                        oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "INDIVIDUAL")

                        oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ / 100)
                        oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", DBNull.Value)
                        oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DBNull.Value)
                        oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", DBNull.Value)
                        oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
                        oParam(13) = New SqlClient.SqlParameter("@pFolioOperacion2", txtFolioOperacion.Text)
                        oParam(14) = New SqlClient.SqlParameter("@pTipoFactura2", "INDIVIDUAL")
                        dtDetalle = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

                        If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                            strMsg = "No se encuentra el ticket " & txtSerieDoc.Text & " " & txtFolioOperacion.Text & "!"
                            MsgBox(strMsg, MsgBoxStyle.Exclamation, "Facturación")
                        End If

                        ConectaBD()

                    Catch exAQ As Exception
                        Me.Cursor = Cursors.Default
                        MsgBox("No hay conexión con el servidor de venta de aparatos, por favor avise a sistemas!" & vbCrLf & exAQ.Message, MsgBoxStyle.Exclamation, "Facturacion")
                    End Try

                Case 2
                    'Venta de joyería
                    TipoBusqueda = ""
                    Try
                        'tratando de conectar al servidor de ventas joyería (8)
                        SQLServer.Init(, strBDJY, strServerJY, strUsrJY, strPwdJY)
                        'probando
                        sSQL = "SELECT TOP 1 * FROM BDSPSAYT.dbo.BSAYTCatalogos"
                        dtTest = SQLServer.ExecSQLReturnDT(sSQL, "Catalogos")
                        'pasó la prueba, se continua con la obtencion del detalle

                        lblTextoAnuncio.Text = "Esperando Actualización Joyeria..."
                        lblTextoAnuncio.Visible = True
                        lblTextoAnuncio.Refresh()

                        sSQL = "sps_JOYERIA_FacturaPeriodica"
                        oParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                        If chbxFechas.Checked Then
                            oParam(1) = New SqlClient.SqlParameter("@pFechaIni", Format(dtpFechaIni.Value, "yyyyMMdd"))
                            oParam(2) = New SqlClient.SqlParameter("@pFechaFin", Format(dtpFechaFin.Value, "yyyyMMdd"))
                        Else
                            oParam(1) = New SqlClient.SqlParameter("@pFechaIni", DBNull.Value)
                            oParam(2) = New SqlClient.SqlParameter("@pFechaFin", DBNull.Value)
                        End If
                        If rbFolioOperacion.Checked Then
                            If Not IsNumeric(txtFolioOperacion.Text) Then
                                Me.Cursor = Cursors.Default
                                MsgBox("Folio de operación inválido! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
                                Exit Sub
                            End If
                            oParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                            oParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", txtFolioOperacion.Text)
                            oParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                            oParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
                        End If
                        oParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "INDIVIDUAL")

                        oParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ)
                        oParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", DBNull.Value)
                        oParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DBNull.Value)
                        oParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", DBNull.Value)
                        oParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DBNull.Value)
                        oParam(13) = New SqlClient.SqlParameter("@pFolioOperacion2", txtFolioOperacion.Text)
                        oParam(14) = New SqlClient.SqlParameter("@pTipoFactura2", "INDIVIDUAL")
                        dtDetalle = SQLServer.ExecSPReturnDT(sSQL, oParam, "Detalle")

                        If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count <= 0 Then
                            strMsg = "No se encuentra el folio de operación " & txtFolioOperacion.Text & "!"
                            MsgBox(strMsg, MsgBoxStyle.Exclamation, "Facturación")
                        End If

                        ConectaBD()

                    Catch exJY As Exception
                        Me.Cursor = Cursors.Default
                        MsgBox("No hay conexión con el servidor de venta de joyería, por favor avise a sistemas!" & vbCrLf & exJY.Message, MsgBoxStyle.Exclamation, "Facturacion")
                    End Try

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
                If TicketEnFacturaGlobal(dr("Prefijo").ToString, dr("NoTicket").ToString, strSerieFacturaGlobal, strFolioFacturaGlobal, strUUIDFacturaGlobal, TipoBusqueda) Then
                    dr("SerieFacturaGlobal") = strSerieFacturaGlobal
                    dr("FolioFacturaglobal") = strFolioFacturaGlobal
                    dr("UUIDFacturaGlobal") = strUUIDFacturaGlobal
                    dr("TipoFactura") = TipoFac
                    dr("Estatus") = EstatusFac
                Else
                    dr("SerieFacturaGlobal") = ""
                    dr("FolioFacturaglobal") = ""
                    dr("UUIDFacturaGlobal") = ""
                    dr("TipoFactura") = ""
                    dr("Estatus") = ""
                End If
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

            lblTextoAnuncio.Text = "Asignación de conceptos..."
            lblTextoAnuncio.Visible = True
            lblTextoAnuncio.Refresh()

            dtDetalle.AcceptChanges()

            If cboSistema.SelectedIndex = 0 Then
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
            Me.txtTotalImportePagado.Text = "$ 0.00"
            Me.txtDescuento.Text = "$ 0.00"
            Me.txtSubtotal.Text = "$ 0.00"
            Me.txtIva.Text = "$ 0.00"

            ordenGrids()

            Me.cdroFacGlobal.Visible = True
            Me.cdroFacIndividual.Visible = True
            Me.lblFacGlobal.Visible = True
            Me.lblFacIndividual.Visible = True
            Me.Cursor = Cursors.Default

            'regreso la conexión al servidor de la sucursal
            ConectaBD()

            lblTextoAnuncio.Visible = False

        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    
    Private Sub btnCerrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAgrega_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrega.Click
        'Dim iFila As Integer = 0
        Sistema = ""
        Accion = "AGREGA"
        Dim bolSeleccionaron As Boolean = False
        Try
            'revisando si tiene filas el grid del resultado
            If dgvResultado.RowCount <= 0 Then
                Exit Sub
            End If
            'si tiene filas
            'revisando si seleccionaron alguna
            For iFila = 0 To dgvResultado.RowCount - 1
                If Not IsDBNull(dgvResultado.Item("colRSel", iFila).Value) Then
                    If dgvResultado.Item("colRSel", iFila).Value = 1 Then
                        bolSeleccionaron = True
                        Exit For
                    End If
                End If
            Next iFila
            If Not bolSeleccionaron Then
                MsgBox("Por favor seleccione los movimientos que se van a facturar!", MsgBoxStyle.Exclamation, "Facturación")
                Exit Sub
            End If

            If cboSistema.SelectedIndex = 0 Then
                Sistema = "EMPEÑO"
            Else
                If cboSistema.SelectedIndex = 1 Then
                    Sistema = "ADMINPAQ"
                Else
                    Sistema = "JOYERIA"
                End If
            End If

            BuscaFechaLimite()

            'si, seleccionaron algo
            'para cada renglon seleccionado, revisar si ya lo agregaron para no duplicar, también se revisa si ya está incluído en una factura
            For iFila = 0 To dgvResultado.RowCount - 1
                If Not IsDBNull(dgvResultado.Item("colRSel", iFila).Value) Then
                    If dgvResultado.Item("colRSel", iFila).Value = 1 Then
                        'revisando si ya fué facturado anteriormente
                        If YaEnFacturaIndividual((dgvResultado.Item("colRPrefijo", iFila).Value).ToString, (dgvResultado.Item("colRNoTicket", iFila).Value).ToString) And TipoFac = "INDIVIDUAL" Then
                            MsgBox("El Movimiento:" & dgvResultado.Item("colRNoTicket", iFila).Value & " ya se facturó anteriormente." & vbCrLf & "Folio Factura: " & serieFac & " " & folioFac & vbCrLf & "Fecha : " & fechaFac, MsgBoxStyle.Exclamation, "Facturación")
                        Else
                            If dgvResultado.Item("colRFecha", iFila).Value >= FechaLimite Then
                                If dgvFacturar.RowCount <= 0 Then
                                    'no han agregado, es el primero, se agrega de forma automática
                                    Agrega(iFila)
                                Else
                                    'ya agregaron, buscando
                                    If Not YaAgregado((dgvResultado.Item("colRNoTicket", iFila).Value).ToString, dgvResultado.Item("colRConcepto", iFila).Value, dgvResultado.Item("colRFecha", iFila).Value, dgvResultado.Item("colRTipoMov", iFila).Value, dgvResultado.Item("colRImportePago", iFila).Value, dgvResultado.Item("colRCosto", iFila).Value) Then
                                        Agrega(iFila)
                                    End If
                                End If
                            Else
                                MsgBox("El folio: " & dgvResultado.Item("colRNoTicket", iFila).Value & " sobrepasa el limite de dias permitidos para facturar!", MsgBoxStyle.Exclamation, "Facturación")
                            End If
                        End If
                    End If
                End If
            Next iFila
            SumaTickets()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Private Sub btnEliminar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim iFila As Integer = 0
        Dim bolSeleccionaron As Boolean = False
        Try
            'revisando si tiene filas el grid de lo que se vá a facturar
            If dgvFacturar.RowCount <= 0 Then
                Exit Sub
            End If
            'si tiene filas
            'revisando si seleccionaron alguna
            For iFila = 0 To dgvFacturar.RowCount - 1
                If Not IsDBNull(dgvFacturar.Item("colFSel", iFila).Value) Then
                    If dgvFacturar.Item("colFSel", iFila).Value = True Then
                        bolSeleccionaron = True
                        Exit For
                    End If
                End If
            Next iFila
            If Not bolSeleccionaron Then
                Exit Sub
            End If
            'si, seleccionaron algo, confirmando la elimnación
            If MsgBox("Está seguro de elimnar las partidas seleccionadas?", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Facturación") = MsgBoxResult.No Then
                Exit Sub
            End If
            'para cada renglon seleccionado, eliminar
            Dim bolElimino As Boolean = False
            Do
                If dgvFacturar.Rows.Count <= 0 Then
                    Exit Do
                End If
                bolElimino = False
                For iFila = 0 To dgvFacturar.RowCount - 1
                    If dgvFacturar.Item("colFSel", iFila).Value = True Then
                        'eliminando
                        dgvFacturar.Rows.RemoveAt(iFila)
                        bolElimino = True
                        Exit For
                    End If
                Next iFila
            Loop Until bolElimino = False
            SumaTickets()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Private Sub btnExportaExcel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportaExcel.Click
        GridExport(Me.dgvFacturar)
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        LimpiaPantalla()
    End Sub

    Private Sub btnGenerarFactura_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarFactura.Click
        Dim intFila As Integer = 0
        Dim sSQL As String = ""
        Dim Concepto As String = ""
        Dim NvoConcepto As String = ""

        Try
            'obteniendo los datos del lugar de emision (sucursal)
            DatosLugarEmision()
            If dtLugarEmision Is Nothing Then
                Exit Sub
            End If
            If dtLugarEmision.Rows.Count <= 0 Then
                MsgBox("No se encontraron datos del lugar de emisión, por favor avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If
            If cboCondPago.Text = "PAGO APLAZADO" And txtDiasPagoAplazado.Text = "" Then
                MsgBox("En la Condicion de Pago Aplazado se requiere el Número de Dias, coloquelo o elija otra opción!", MsgBoxStyle.Exclamation, "Facturacion")
                txtDiasPagoAplazado.Focus()
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

            If cboSistema.SelectedIndex = 0 Then
                Sistema = "EMPEÑO"
            Else
                If cboSistema.SelectedIndex = 1 Then
                    Sistema = "ADMINPAQ"
                Else
                    Sistema = "JOYERIA"
                End If
            End If

            'estos son los datos para a facturar            
            dtDetalleInd = GeneraTablaDetalle()

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

            If cboCondPago.Text = "PAGO APLAZADO" Then
                PagoAplazado = True
            Else
                PagoAplazado = False
            End If

            Dim foliosNC As String = ""
            For iFila = 0 To dgvFacturar.RowCount - 1
                If YaEnFacturaIndividual((dgvFacturar.Item("colFPrefijo", iFila).Value).ToString, (dgvFacturar.Item("colFNoTicket", iFila).Value).ToString) And TipoFac = "GLOBAL" Then
                    If foliosNC = "" Then
                        foliosNC += dgvFacturar.Item("colFNoTicket", iFila).Value
                    Else
                        foliosNC += ", " & dgvFacturar.Item("colFNoTicket", iFila).Value
                    End If
                End If
            Next iFila
            If foliosNC <> "" Then
                Dim res As String = MsgBox("El Folio: " & foliosNC & "  Ya esta incluido en una Factura Global, Se realizara la Nota de Crédito Correspondiente.", MsgBoxStyle.YesNo, "Facturación")
                If res = 7 Then
                    Exit Sub
                End If
            End If

            Dim frmDatCt As New frmDatosClienteFacturacion
            frmDatCt.GridDatos = dgvFacturar
            frmDatCt.ShowDialog()
            If frmDatCt.DialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If





            Me.Cursor = Cursors.WaitCursor
            lblTextoAnuncio.Text = "Validando información inicial..."
            lblTextoAnuncio.Visible = True
            lblTextoAnuncio.Refresh()

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

            If cboCondPago.Text = "--- SELECCIONE ---" Or cboCondPago.Text = "" Then
                strCondicionesPago = ""
            Else
                If cboCondPago.Text = "PAGO APLAZADO" Then
                    strCondicionesPago = DameCondicionesPagoIDDefault(cboCondPago.Text, txtDiasPagoAplazado.Text)
                Else
                    strCondicionesPago = DameCondicionesPagoIDDefault(cboCondPago.Text, "")
                End If
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

            lblTextoAnuncio.Text = "Extrayendo datos del cliente..."
            lblTextoAnuncio.Visible = True
            lblTextoAnuncio.Refresh()

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
            If strVersionFacturas <> "40" Then
                GeneraFactura(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleInd, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaIndividual, )
            Else
                GeneraFactura40(enTipoDocumento.Factura, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleInd, strCondicionesPago, strRespuesta, True, strDirSuc, strDirCli, strCBB, , , enTipoDocumentoAfectar.FacturaIndividual, )
            End If


            'generando las notas de credito
            'si hay registros con marca de factura global, se procede a generar las notas de credito para cada uno           
            If foliosNC <> "" Then
                lblTextoAnuncio.Text = "Generando notas de crédito..."
                lblTextoAnuncio.Visible = True
                lblTextoAnuncio.Refresh()
                errorNC = False
                GeneraNotaCreditoIndividual(dtDetalleInd)
                If errorNC Then
                    GoTo NoSeHaceNada
                End If
            End If


NoSeHaceNada:

            Me.Cursor = Cursors.Default

            lblTextoAnuncio.Visible = False
            Sistema = ""
            If strEstatusGeneracion = "OK" Then
                'LIMPIAR LA PANTALLA
                LimpiaPantalla()
                dtCliente.Rows.Clear()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub cboSistema_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSistema.SelectedIndexChanged
        ivaAJ = BuscaIvaSuc(IvaS)
        txtCliente.Text = ""
        txtSerieDoc.Text = ""
        txtFolioOperacion.Text = ""
        txtFolioBoleta.Text = ""
        Sistema = ""
        Select Case cboSistema.SelectedIndex
            Case 0
                'Empeño
                Sistema = "EMPEÑO"
                rbBoleta.Enabled = True
                rbBoleta.Checked = True
                txtFolioBoleta.Enabled = True
                rbCliente.Enabled = True
                rbCliente.Checked = False
                txtCliente.Enabled = True
                rbFolioOperacion.Enabled = True
                rbFolioOperacion.Checked = False
                rbFolioOperacion.Text = "Folio Operación:"
                txtFolioOperacion.Enabled = True
                txtFolioOperacion.Left = txtCliente.Left
                lblFolioDoc.Left = 258
                lblFolioDoc.Visible = False
                txtSerieDoc.Left = 280
                txtSerieDoc.Visible = False
                txtCliente.Enabled = False
                txtSerieDoc.Enabled = False
                txtFolioOperacion.Enabled = False
                txtFolioBoleta.Enabled = True
                txtFolioBoleta.Focus()
            Case 1
                'AdminPaq
                Sistema = "ADMINPAQ"
                rbBoleta.Enabled = False
                rbBoleta.Checked = False
                txtFolioBoleta.Enabled = False
                rbCliente.Enabled = False
                rbCliente.Checked = False
                txtCliente.Enabled = False
                rbFolioOperacion.Enabled = True
                rbFolioOperacion.Checked = True
                rbFolioOperacion.Text = "Ticket     Serie:"
                txtFolioOperacion.Enabled = True
                lblFolioDoc.Visible = True
                txtSerieDoc.Left = txtCliente.Left
                txtSerieDoc.Visible = True
                lblFolioDoc.Left = 440 '587
                txtSerieDoc.Enabled = True
                txtFolioOperacion.Left = 480 '640
                txtSerieDoc.Focus()
            Case 2
                'Venta de joyería
                Sistema = "JOYERIA"
                rbBoleta.Enabled = False
                rbBoleta.Checked = False
                txtFolioBoleta.Enabled = False
                rbCliente.Enabled = False
                rbCliente.Checked = False
                txtCliente.Enabled = False
                rbFolioOperacion.Enabled = True
                rbFolioOperacion.Checked = True
                rbFolioOperacion.Text = "Folio Operación:"
                txtFolioOperacion.Left = txtCliente.Left
                txtFolioOperacion.Enabled = True
                lblFolioDoc.Visible = False
                lblFolioDoc.Left = 208
                txtSerieDoc.Visible = False
                txtSerieDoc.Left = 240
                txtFolioOperacion.Focus()
        End Select
    End Sub

    Private Sub chbxFechas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbxFechas.Click
        If chbxFechas.Checked = True Then
            dtpFechaIni.Enabled = True
            dtpFechaFin.Enabled = True
            txtFolioBoleta.Focus()
        Else
            dtpFechaIni.Enabled = False
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub rbCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCliente.Click
        Dim i As Integer
        Dim col As New AutoCompleteStringCollection
        Dim dt As New DataTable()

        Dim consulta As String = "SELECT NombreCliente FROM BPFCatalogoClientes"
        dt = SQLServer.ExecSQLReturnDT(consulta, "BPFCatalogoClientes")
        For i = 0 To dt.Rows.Count - 1
            col.Add(dt.Rows(i)("NombreCliente").ToString)
        Next i
        txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCliente.AutoCompleteCustomSource = col
        txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtCliente.DisplayMember = dt.Rows(i - 1)("NombreCliente").ToString
        txtCliente.ValueMember = dt.Rows(i - 1)("NombreCliente").ToString
        txtCliente.Focus()
    End Sub

    Private Sub rbFolioOperacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFolioOperacion.Click
        Select Case cboSistema.SelectedIndex
            Case 0
                txtFolioOperacion.Focus()   'empeño
            Case 1
                txtSerieDoc.Focus()   'AdminPaq
            Case 2
                txtFolioOperacion.Focus()         'Venta de joyería
        End Select
    End Sub

    Private Sub rbBoleta_CheckedChanged(sender As Object, e As EventArgs) Handles rbBoleta.CheckedChanged
        txtCliente.Text = ""
        txtSerieDoc.Text = ""
        txtFolioOperacion.Text = ""
        txtFolioBoleta.Text = ""
        txtCliente.Enabled = False
        txtSerieDoc.Enabled = False
        txtFolioOperacion.Enabled = False
        txtFolioBoleta.Enabled = True
    End Sub

    Private Sub rbBoleta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBoleta.Click
        txtFolioBoleta.Focus()
    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Dim sSQL1 As String = ""
        'Dim nombreCliente As String
        'Dim dtConsulta As New DataTable
        'Dim i As Integer

        'If Asc(e.KeyChar) = 13 Then
        '    dtConsulta = New DataTable
        '    nombreCliente = txtCliente.Text
        '    Try
        '        sSQL1 = "SELECT NombreCliente FROM BPFCatalogoClientes where NombreCliente like '%" & nombreCliente & "%'"
        '        dtConsulta = SQLServer.ExecSQLReturnDT(sSQL1, "BPFCatalogoClientes")

        '        If Not dtConsulta Is Nothing Then
        '            If dtConsulta.Rows.Count > 0 Then
        '                For i = 0 To dtConsulta.Rows.Count - 1
        '                    ComboBox1.DataSource = dtConsulta.DefaultView
        '                Next i
        '            End If
        '        End If

        '    Catch ex As Exception
        '        Me.Cursor = Cursors.Default
        '    End Try
        'End If
    End Sub

    Private Sub cboCondPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondPago.SelectedIndexChanged
        If cboCondPago.Text = "PAGO APLAZADO" Then
            Label16.Visible = True
            Label17.Visible = True
            txtDiasPagoAplazado.Text = ""
            txtDiasPagoAplazado.Visible = True
            txtDiasPagoAplazado.Focus()
        Else
            Me.Label16.Visible = False
            Me.txtDiasPagoAplazado.Visible = False
            Me.Label17.Visible = False
        End If
    End Sub

    Private Sub rbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbCliente.CheckedChanged
        txtCliente.Text = ""
        txtSerieDoc.Text = ""
        txtFolioOperacion.Text = ""
        txtFolioBoleta.Text = ""
        txtCliente.Enabled = True
        txtSerieDoc.Enabled = False
        txtFolioOperacion.Enabled = False
        txtFolioBoleta.Enabled = False
    End Sub

    Private Sub rbFolioOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles rbFolioOperacion.CheckedChanged
        txtCliente.Text = ""
        txtSerieDoc.Text = ""
        txtFolioOperacion.Text = ""
        txtFolioBoleta.Text = ""
        txtCliente.Enabled = False
        txtSerieDoc.Enabled = True
        txtFolioOperacion.Enabled = True
        txtFolioBoleta.Enabled = False
    End Sub

    Private Sub rbBoleta_LostFocus(sender As Object, e As EventArgs) Handles rbBoleta.LostFocus
        txtCliente.Enabled = False
        txtSerieDoc.Enabled = False
        txtFolioOperacion.Enabled = False
        txtFolioBoleta.Enabled = True
    End Sub

    Private Sub txtFolioBoleta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioBoleta.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtSerieDoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerieDoc.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        Else
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        Else
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub txtFolioOperacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioOperacion.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCliente.SelectedIndexChanged

    End Sub
End Class
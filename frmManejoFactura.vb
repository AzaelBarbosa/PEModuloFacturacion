Imports System.IO
Imports System.Text

Public Class frmManejoFactura
    Dim dtBusqueda As New DataTable

    Private Sub Limpia()
        Dim dtRes As New DataTable
        Dim dtFecha As Date = DateSerial(Year(Date.Today), Month(Date.Today), Today.Day)
        Try
            chbxFechas.Checked = False
            chbxFolio.Checked = False
            chbxUUID.Checked = False
            dtpFechaIni.Enabled = False
            dtpFechaFin.Enabled = False
            dtpFechaIni.Value = dtFecha
            dtpFechaFin.Value = dtFecha
            txtFolio.Text = ""
            txtUUID.Text = ""
            txtFolio.Enabled = False
            txtUUID.Enabled = False
            dtRes = dtBusqueda.Clone
            dgvResultadoFact.DataSource = dtRes
            ordenGrids()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Limpia Pantalla")
        End Try
    End Sub

    Private Sub guardaAcuseCancelacion(ByVal datos As DataTable)
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Try
            For Each dr As DataRow In dtEnviar.Rows
                If conAcuse = True Then
                    sSQL = "UPDATE BDSPEXPRESS.dbo.BPFFacturas SET Acuse = 'SI' WHERE Folio = '" & dr("Folio") & "'  and Serie = '" & dr("Serie") & "' and FolioFiscal = '" & dr("FolioFiscal") & "'"
                End If
                SQLServer.ExecSQL(sSQL)
            Next
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

    Private Sub ordenGrids()
        'forzando el orden de las columnas
        With dgvResultadoFact
            .Columns("colSel").DisplayIndex = 0
            .Columns("colFecha").DisplayIndex = 1
            .Columns("colFolio").DisplayIndex = 2
            .Columns("colSerie").DisplayIndex = 3
            .Columns("colEstatus").DisplayIndex = 4
            .Columns("colAcuse").DisplayIndex = 5
            .Columns("colTipo").DisplayIndex = 6
            .Columns("colTipoComprobante").DisplayIndex = 7
            .Columns("colImporte").DisplayIndex = 8
            .Columns("colUUID").DisplayIndex = 9
            .Columns("colArchivoPDF").DisplayIndex = 10
            .Columns("colArchivoXML").DisplayIndex = 11
        End With
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpia()
    End Sub

    Private Sub frmCancelaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.BackgroundImage = Pantallazo
        Me.Text = "Manejo Facturas - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        Limpia()
    End Sub

    Private Sub btnLimpiar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiar.MouseLeave
        'Label18.Visible = False
    End Sub

    Private Sub btnLimpiar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLimpiar.MouseMove
        'Label18.Visible = True
    End Sub

    Private Sub btnCancelaFac_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelaFac.MouseLeave
        'Label19.Visible = False
    End Sub

    Private Sub btnCancelaFac_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCancelaFac.MouseMove
        'Label19.Visible = True
    End Sub

    Private Sub btnCerrar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.MouseLeave
        'Label20.Visible = False
    End Sub

    Private Sub btnCerrar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCerrar.MouseMove
        'Label20.Visible = True
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim consulta As String = ""
        Dim c As Integer = 0
        Dim strMsg As String = ""

        If chbxFechas.Checked Then
            If dtpFechaIni.Value > dtpFechaFin.Value Then
                MsgBox("Rango de fechas inválido! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
                Exit Sub
            End If
        End If
        If chbxFolio.Checked Then
            If txtFolio.Text = "" Then
                MsgBox("No ha capturado el folio de la factura! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
                Exit Sub
            End If
        End If
        If chbxUUID.Checked Then
            If txtUUID.Text = "" Then
                MsgBox("No ha capturado el UUID de la factura! Por favor revise.", MsgBoxStyle.Exclamation, "Facturación")
                Exit Sub
            End If
        End If

        If chbxFechas.Checked = False And chbxFolio.Checked = False And chbxUUID.Checked = False Then
            Me.Cursor = Cursors.Default
            MsgBox("No hay ningun parametro de busqueda.", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        'limpiando las tablas
        dtBusqueda = New DataTable

        Try
            consulta = "SELECT f.FechaFactura, f.Folio, f.Serie, f.Estatus, CASE WHEN f.Estatus = 'C' AND f.Acuse = '' THEN 'NO' ELSE f.Acuse end Acuse, f.TipoFactura, f.TipoComprobante, f.ImporteTotal, f.FolioFiscal, f.NombreArchivoPDF, f.NombreArchivoXML, f.NoCliente, c.CorreoE, f.RFC " & _
                       "FROM BPFFacturas f LEFT JOIN dbo.BPFCatalogoClientes c ON f.NoCliente = c.NoCliente "

            If chbxFechas.Checked Then
                If dtpFechaIni.Value = dtpFechaFin.Value Then
                    consulta = consulta & "Where FechaFactura = '" & Format(dtpFechaIni.Value, "yyyyMMdd") & "' "
                Else
                    consulta = consulta & "Where FechaFactura >= '" & Format(dtpFechaIni.Value, "yyyyMMdd") & "' and FechaFactura <= '" & Format(dtpFechaFin.Value, "yyyyMMdd") & "' "
                End If
                c = 1
            End If
            If chbxFolio.Checked Then
                If c = 1 Then
                    consulta = consulta & "and Folio = " & txtFolio.Text
                Else
                    consulta = consulta & "Where Folio = " & txtFolio.Text
                    c = 1
                End If
            End If
            If chbxUUID.Checked Then
                If c = 1 Then
                    consulta = consulta & "and FolioFiscal = '" & txtUUID.Text & "'"
                Else
                    consulta = consulta & "Where FolioFiscal = '" & txtUUID.Text & "'"
                End If
            End If

            dtBusqueda = SQLServer.ExecSQLReturnDT(consulta, "BPFFacturas")

            If dtBusqueda Is Nothing OrElse dtBusqueda.Rows.Count <= 0 Then
                If chbxFechas.Checked Then
                    strMsg = "No se encuentran Facturas de las Fechas: " & dtpFechaIni.Value & " - " & dtpFechaFin.Value & "!"
                ElseIf chbxFolio.Checked Then
                    strMsg = "No se encuentran el Folio: " & txtFolio.Text & "!"
                ElseIf chbxUUID.Checked Then
                    strMsg = "No se encuentra el UUID: " & txtUUID.Text & "!"
                Else
                    strMsg = "No hay facturas generadas!"
                End If
                MsgBox(strMsg, MsgBoxStyle.Exclamation, "Facturación")
            End If

            dgvResultadoFact.DataSource = dtBusqueda
            ordenGrids()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Busqueda de Factura")
        End Try
    End Sub

    Private Sub btnBuscar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.MouseLeave
        'Label7.Visible = False
    End Sub

    Private Sub btnBuscar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnBuscar.MouseMove
        'Label7.Visible = True
    End Sub

    Private Sub chbxFechas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbxFechas.Click
        Dim dtFecha As Date = DateSerial(Year(Date.Today), Month(Date.Today), Today.Day)
        If chbxFechas.Checked = True Then
            dtpFechaIni.Enabled = True
            dtpFechaFin.Enabled = True
            txtFolio.Enabled = False
            txtFolio.Text = ""
            txtUUID.Enabled = False
            txtUUID.Text = ""
            chbxFolio.Checked = False
            chbxUUID.Checked = False
            dtpFechaIni.Focus()
        Else
            dtpFechaIni.Value = dtFecha
            dtpFechaIni.Enabled = False
            dtpFechaFin.Value = dtFecha
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub chbxFolio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbxFolio.Click
        Dim dtFecha As Date = DateSerial(Year(Date.Today), Month(Date.Today), Today.Day)
        If chbxFolio.Checked = True Then
            dtpFechaIni.Enabled = False
            dtpFechaIni.Value = dtFecha
            dtpFechaFin.Enabled = False
            dtpFechaFin.Value = dtFecha
            txtFolio.Enabled = True
            txtFolio.Text = ""
            txtUUID.Enabled = False
            txtUUID.Text = ""
            chbxFechas.Checked = False
            chbxUUID.Checked = False
            txtFolio.Focus()
        Else
            txtFolio.Text = ""
            txtFolio.Enabled = False
        End If
    End Sub

    Private Sub chbxUUID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbxUUID.Click
        Dim dtFecha As Date = DateSerial(Year(Date.Today), Month(Date.Today), Today.Day)
        If chbxUUID.Checked = True Then
            dtpFechaIni.Enabled = False
            dtpFechaIni.Value = dtFecha
            dtpFechaFin.Enabled = False
            dtpFechaFin.Value = dtFecha
            txtFolio.Enabled = False
            txtFolio.Text = ""
            txtUUID.Enabled = True
            txtUUID.Text = ""
            chbxFechas.Checked = False
            chbxFolio.Checked = False
            txtUUID.Focus()
        Else
            txtUUID.Text = ""
            txtUUID.Enabled = False
        End If
    End Sub

    Private Sub btnCancelaFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelaFac.Click
        Dim intFila As Integer = 0
        Dim sSQL As String = ""
        Dim bolSeleccionaron As Boolean = False
        Dim Seleccionaron As Integer = 0
        Dim drNew As DataRow

        If dgvResultadoFact.RowCount <= 0 Then
            Exit Sub
        End If

        For intFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", intFila).Value) Then
                If dgvResultadoFact.Item("colSel", intFila).Value = True Then
                    bolSeleccionaron = True
                    Exit For
                End If
            End If
        Next intFila
        If Not bolSeleccionaron Then
            MsgBox("Por favor seleccione el folio a Cancelar!", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        For intFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", intFila).Value) Then
                If dgvResultadoFact.Item("colSel", intFila).Value = True Then
                    Seleccionaron = Seleccionaron + 1
                End If
            End If
        Next intFila
        If Seleccionaron > 1 Then
            MsgBox("Por favor seleccione 1 solo folio a Cancelar!", MsgBoxStyle.Exclamation, "Facturacion")
            Exit Sub
        End If

        dtEnviar = dtBusqueda.Clone
        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                    If dgvResultadoFact.Item("colEstatus", iFila).Value = "A" Then
                        drNew = dtEnviar.NewRow
                        drNew("FechaFactura") = dgvResultadoFact.Item("colFecha", iFila).Value
                        drNew("Folio") = dgvResultadoFact.Item("colFolio", iFila).Value
                        drNew("Serie") = dgvResultadoFact.Item("colSerie", iFila).Value
                        drNew("TipoFactura") = dgvResultadoFact.Item("colTipo", iFila).Value
                        drNew("FolioFiscal") = dgvResultadoFact.Item("colUUID", iFila).Value
                        drNew("NombreArchivoPDF") = dgvResultadoFact.Item("colArchivoPDF", iFila).Value
                        drNew("NombreArchivoXML") = dgvResultadoFact.Item("colArchivoXML", iFila).Value
                        drNew("CorreoE") = dgvResultadoFact.Item("colCorreo", iFila).Value
                        drNew("NoCliente") = dgvResultadoFact.Item("colNoCliente", iFila).Value
                        dtEnviar.Rows.Add(drNew)
                        dtEnviar.AcceptChanges()
                    Else
                        MsgBox("Esta Factura ya esta cancelada!", MsgBoxStyle.Exclamation, "Facturación")
                        Exit Sub
                    End If
                End If
            End If
        Next iFila

        Dim frmDatCancelar As New frmCancelarFactura
        TipoCancelacion = ""
        frmDatCancelar.ShowDialog()
        If frmDatCancelar.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
    End Sub

    Private Sub btnEnviarEmail_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarEmail.MouseLeave
        'Label2.Visible = False
    End Sub

    Private Sub btnEnviarEmail_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnEnviarEmail.MouseMove
        'Label2.Visible = True
    End Sub

    Private Sub btnVerPDF_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerPDF.MouseLeave
        'Label4.Visible = False
    End Sub

    Private Sub btnVerPDF_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnVerPDF.MouseMove
        'Label4.Visible = True
    End Sub

    Private Sub btnVerXML_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerXML.MouseLeave
        ' Label5.Visible = False
    End Sub

    Private Sub btnVerXML_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnVerXML.MouseMove
        'Label5.Visible = True
    End Sub

    Private Sub btnExportaExcel_Click(sender As Object, e As EventArgs) Handles btnExportaExcel.Click
        GridExport(Me.dgvResultadoFact)
    End Sub

    Private Sub btnExportaExcel_MouseLeave(sender As Object, e As EventArgs) Handles btnExportaExcel.MouseLeave
        'Label12.Visible = False
    End Sub

    Private Sub btnExportaExcel_MouseMove(sender As Object, e As MouseEventArgs) Handles btnExportaExcel.MouseMove
        'Label12.Visible = True
    End Sub

    Private Sub btnVerPDFAcuse_Click(sender As Object, e As EventArgs) Handles btnVerPDFAcuse.Click
        Dim strCarpetaFacturas As String = ""
        Dim fechaFac As Date
        Dim bolSeleccionaron As Boolean = False
        Dim seleccionaron As Integer = 0
        Dim drNew As DataRow
        Dim separa() As String

        If dgvResultadoFact.RowCount <= 0 Then
            Exit Sub
        End If
        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                    bolSeleccionaron = True
                    Exit For
                End If
            End If
        Next iFila
        If Not bolSeleccionaron Then
            MsgBox("Por favor seleccione las facturas canceladas que se van a mostrar!", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        For intFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", intFila).Value) Then
                If dgvResultadoFact.Item("colSel", intFila).Value = True Then
                    Seleccionaron = Seleccionaron + 1
                End If
            End If
        Next intFila
        If Seleccionaron > 1 Then
            MsgBox("Por favor seleccione 1 solo folio para mostrar!", MsgBoxStyle.Exclamation, "Facturacion")
            Exit Sub
        End If

        dtEnviar = dtBusqueda.Clone
        Try
            For iFila = 0 To dgvResultadoFact.RowCount - 1
                If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                    If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                        If dgvResultadoFact.Item("colEstatus", iFila).Value = "C" Then
                            fechaFac = CDate(Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 7, 2) & "/" & Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 5, 2) & "/" & Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 1, 4))
                            strCarpetaFacturas = VerificaCarpetaFacturacion(intNoSucursal, fechaFac)
                            separa = Split(dgvResultadoFact.Item("colArchivoPDF", iFila).Value, ".")
                            If File.Exists(strCarpetaFacturas & "\" & separa(0) & "_CANCELADA." & separa(1)) Then
                                Process.Start(strCarpetaFacturas & "\" & separa(0) & "_CANCELADA." & separa(1))
                            Else
                                Dim res As String = MsgBox("No se encuentra el PDF del Acuse de Cancelación, ¿Desea obtenerlo?", MsgBoxStyle.YesNo, "Facturación")
                                If res = 6 Then
                                    dtEnviar.Clear()
                                    drNew = dtEnviar.NewRow
                                    drNew("FechaFactura") = dgvResultadoFact.Item("colFecha", iFila).Value
                                    drNew("Folio") = dgvResultadoFact.Item("colFolio", iFila).Value
                                    drNew("Serie") = dgvResultadoFact.Item("colSerie", iFila).Value
                                    drNew("TipoFactura") = dgvResultadoFact.Item("colTipo", iFila).Value
                                    drNew("FolioFiscal") = dgvResultadoFact.Item("colUUID", iFila).Value
                                    drNew("RFC") = dgvResultadoFact.Item("colRFC", iFila).Value
                                    dtEnviar.Rows.Add(drNew)
                                    dtEnviar.AcceptChanges()

                                    obtenerAcusePDF(dtEnviar)
                                End If
                            End If
                        Else
                            MsgBox("Esta Factura no esta cancelada!", MsgBoxStyle.Exclamation, "Facturación")
                        End If
                    End If
                End If
            Next iFila
        Catch ex As Exception
            MsgBox("Error al abrir el archivo, avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturación")
        End Try
    End Sub

    Private Sub btnVerPDFAcuse_MouseLeave(sender As Object, e As EventArgs) Handles btnVerPDFAcuse.MouseLeave
        'Label6.Visible = False
    End Sub

    Private Sub btnVerPDFAcuse_MouseMove(sender As Object, e As MouseEventArgs) Handles btnVerPDFAcuse.MouseMove
        'Label6.Visible = True
    End Sub

    Private Sub btnVerXMLAcuse_Click(sender As Object, e As EventArgs) Handles btnVerXMLAcuse.Click
        Dim strCarpetaFacturas As String = ""
        Dim fechaFac As Date
        Dim bolSeleccionaron As Boolean = False
        Dim seleccionaron As Integer = 0
        Dim drNew As DataRow
        Dim separa() As String

        If dgvResultadoFact.RowCount <= 0 Then
            Exit Sub
        End If
        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                    bolSeleccionaron = True
                    Exit For
                End If
            End If
        Next iFila
        If Not bolSeleccionaron Then
            MsgBox("Por favor seleccione las facturas canceladas que se van a mostrar!", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        For intFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", intFila).Value) Then
                If dgvResultadoFact.Item("colSel", intFila).Value = True Then
                    seleccionaron = seleccionaron + 1
                End If
            End If
        Next intFila
        If seleccionaron > 1 Then
            MsgBox("Por favor seleccione 1 solo folio para mostrar!", MsgBoxStyle.Exclamation, "Facturacion")
            Exit Sub
        End If

        dtEnviar = dtBusqueda.Clone
        Try
            For iFila = 0 To dgvResultadoFact.RowCount - 1
                If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                    If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                        If dgvResultadoFact.Item("colEstatus", iFila).Value = "C" Then
                            fechaFac = CDate(Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 7, 2) & "/" & Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 5, 2) & "/" & Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 1, 4))
                            strCarpetaFacturas = VerificaCarpetaFacturacion(intNoSucursal, fechaFac)
                            separa = Split(dgvResultadoFact.Item("colArchivoXML", iFila).Value, ".")
                            If File.Exists(strCarpetaFacturas & "\" & separa(0) & "_CANCELADA." & separa(1)) Then
                                Process.Start(strCarpetaFacturas & "\" & separa(0) & "_CANCELADA." & separa(1))
                            Else
                                Dim res As String = MsgBox("No se encuentra el XML del Acuse de Cancelación, ¿Desea obtenerlo?", MsgBoxStyle.YesNo, "Facturación")
                                If res = 6 Then
                                    dtEnviar.Clear()
                                    drNew = dtEnviar.NewRow
                                    drNew("FechaFactura") = dgvResultadoFact.Item("colFecha", iFila).Value
                                    drNew("Folio") = dgvResultadoFact.Item("colFolio", iFila).Value
                                    drNew("Serie") = dgvResultadoFact.Item("colSerie", iFila).Value
                                    drNew("TipoFactura") = dgvResultadoFact.Item("colTipo", iFila).Value
                                    drNew("FolioFiscal") = dgvResultadoFact.Item("colUUID", iFila).Value
                                    drNew("RFC") = dgvResultadoFact.Item("colRFC", iFila).Value
                                    dtEnviar.Rows.Add(drNew)
                                    dtEnviar.AcceptChanges()

                                    obtenerAcuseXML(dtEnviar)
                                    If conAcuse = True Then
                                        guardaAcuseCancelacion(dtEnviar)
                                    End If
                                End If
                            End If
                        Else
                            MsgBox("Esta Factura no esta cancelada!", MsgBoxStyle.Exclamation, "Facturación")
                        End If
                    End If
                End If
            Next iFila
        Catch ex As Exception
            MsgBox("Error al abrir el archivo, avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturación")
        End Try
    End Sub

    Private Sub btnVerXMLAcuse_MouseLeave(sender As Object, e As EventArgs) Handles btnVerXMLAcuse.MouseLeave
        'Label8.Visible = False
    End Sub

    Private Sub btnVerXMLAcuse_MouseMove(sender As Object, e As MouseEventArgs) Handles btnVerXMLAcuse.MouseMove
        'Label8.Visible = True
    End Sub

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
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

    Private Sub txtUUID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUUID.KeyPress
        If InStr("ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789", e.KeyChar) = False Then
            If (Asc(e.KeyChar)) <> 8 And (Asc(e.KeyChar)) <> 45 Then
                e.Handled = True
            End If
        End If
        If Char.IsLetter(e.KeyChar) Then
            txtUUID.CharacterCasing = CharacterCasing.Upper
        End If
    End Sub

    Private Sub btnEnviarEmail_Click(sender As Object, e As EventArgs) Handles btnEnviarEmail.Click
        Dim bolSeleccionaron As Boolean = False
        Dim drNew As DataRow

        If dgvResultadoFact.RowCount <= 0 Then
            Exit Sub
        End If
        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = "TRUE" Then
                    bolSeleccionaron = True
                    Exit For
                End If
            End If
        Next iFila
        If Not bolSeleccionaron Then
            MsgBox("Por favor seleccione las facturas que se van a enviar!", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        dtEnviar = dtBusqueda.Clone






        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                    drNew = dtEnviar.NewRow
                    drNew("Folio") = dgvResultadoFact.Item("colFolio", iFila).Value
                    drNew("Serie") = dgvResultadoFact.Item("colSerie", iFila).Value
                    drNew("FolioFiscal") = dgvResultadoFact.Item("colUUID", iFila).Value
                    drNew("NombreArchivoPDF") = dgvResultadoFact.Item("colArchivoPDF", iFila).Value
                    drNew("NombreArchivoXML") = dgvResultadoFact.Item("colArchivoXML", iFila).Value
                    drNew("CorreoE") = dgvResultadoFact.Item("colCorreo", iFila).Value
                    drNew("NoCliente") = dgvResultadoFact.Item("colNoCliente", iFila).Value
                    drNew("Estatus") = dgvResultadoFact.Item("colEstatus", iFila).Value
                    dtEnviar.Rows.Add(drNew)
                    dtEnviar.AcceptChanges()
                End If
            End If
        Next iFila

        Dim frmDatEnvio As New frmEnviarCorreo
        frmDatEnvio.ShowDialog()
        If frmDatEnvio.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
    End Sub

    Private Sub btnVerPDF_Click(sender As Object, e As EventArgs) Handles btnVerPDF.Click
        Dim strCarpetaFacturas As String = ""
        Dim fechaFac As Date
        Dim bolSeleccionaron As Boolean = False
        Dim drNew As DataRow

        If dgvResultadoFact.RowCount <= 0 Then
            Exit Sub
        End If
        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = "TRUE" Then
                    bolSeleccionaron = True
                    Exit For
                End If
            End If
        Next iFila
        If Not bolSeleccionaron Then
            MsgBox("Por favor seleccione las facturas que se van a mostrar!", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        dtEnviar = dtBusqueda.Clone
        Try
            For iFila = 0 To dgvResultadoFact.RowCount - 1
                If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                    If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                        If dgvResultadoFact.Item("colEstatus", iFila).Value = "A" Then
                            fechaFac = CDate(Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 7, 2) & "/" & Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 5, 2) & "/" & Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 1, 4))
                            strCarpetaFacturas = VerificaCarpetaFacturacion(intNoSucursal, fechaFac)
                            If File.Exists(strCarpetaFacturas & "\" & dgvResultadoFact.Item("colArchivoPDF", iFila).Value) Then
                                Process.Start(strCarpetaFacturas & "\" & dgvResultadoFact.Item("colArchivoPDF", iFila).Value)
                            Else
                                Dim res As String = MsgBox("No se encuentra el PDF de la factura, ¿Desea obtenerlo?", MsgBoxStyle.YesNo, "Facturación")
                                If res = 6 Then
                                    dtEnviar.Clear()
                                    drNew = dtEnviar.NewRow
                                    drNew("FechaFactura") = dgvResultadoFact.Item("colFecha", iFila).Value
                                    drNew("Folio") = dgvResultadoFact.Item("colFolio", iFila).Value
                                    drNew("Serie") = dgvResultadoFact.Item("colSerie", iFila).Value
                                    drNew("TipoFactura") = dgvResultadoFact.Item("colTipo", iFila).Value
                                    drNew("FolioFiscal") = dgvResultadoFact.Item("colUUID", iFila).Value
                                    drNew("RFC") = dgvResultadoFact.Item("colRFC", iFila).Value
                                    dtEnviar.Rows.Add(drNew)
                                    dtEnviar.AcceptChanges()

                                    obtenerPDF(dtEnviar)
                                End If
                            End If
                        Else
                            MsgBox("Esta Factura esta cancelada!", MsgBoxStyle.Exclamation, "Facturación")
                        End If
                    End If
                End If
            Next iFila
        Catch ex As Exception
            MsgBox("Error al abrir el archivo, avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturación")
        End Try
    End Sub

    Private Sub btnVerXML_Click(sender As Object, e As EventArgs) Handles btnVerXML.Click
        Dim strCarpetaFacturas As String = ""
        Dim fechaFac As Date
        Dim bolSeleccionaron As Boolean = False
        Dim drNew As DataRow

        If dgvResultadoFact.RowCount <= 0 Then
            Exit Sub
        End If

        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = "TRUE" Then
                    bolSeleccionaron = True
                    Exit For
                End If
            End If
        Next iFila
        If Not bolSeleccionaron Then
            MsgBox("Por favor seleccione las facturas que se van a mostrar!", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        dtEnviar = dtBusqueda.Clone
        Try
            For iFila = 0 To dgvResultadoFact.RowCount - 1
                If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                    If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                        If dgvResultadoFact.Item("colEstatus", iFila).Value = "A" Then
                            fechaFac = CDate(Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 7, 2) & "/" & Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 5, 2) & "/" & Mid(dgvResultadoFact.Item("colFecha", iFila).Value, 1, 4))
                            strCarpetaFacturas = VerificaCarpetaFacturacion(intNoSucursal, fechaFac)
                            If File.Exists(strCarpetaFacturas & "\" & dgvResultadoFact.Item("colArchivoXML", iFila).Value) Then
                                Process.Start(strCarpetaFacturas & "\" & dgvResultadoFact.Item("colArchivoXML", iFila).Value)
                            Else
                                Dim res As String = MsgBox("No se encuentra el XML de la factura, ¿Desea obtenerlo?", MsgBoxStyle.YesNo, "Facturación")
                                If res = 6 Then
                                    dtEnviar.Clear()
                                    drNew = dtEnviar.NewRow
                                    drNew("FechaFactura") = dgvResultadoFact.Item("colFecha", iFila).Value
                                    drNew("Folio") = dgvResultadoFact.Item("colFolio", iFila).Value
                                    drNew("Serie") = dgvResultadoFact.Item("colSerie", iFila).Value
                                    drNew("TipoFactura") = dgvResultadoFact.Item("colTipo", iFila).Value
                                    drNew("FolioFiscal") = dgvResultadoFact.Item("colUUID", iFila).Value
                                    drNew("RFC") = dgvResultadoFact.Item("colRFC", iFila).Value
                                    dtEnviar.Rows.Add(drNew)
                                    dtEnviar.AcceptChanges()

                                    obtenerXML(dtEnviar)
                                End If
                            End If
                        Else
                            MsgBox("Esta Factura esta cancelada!", MsgBoxStyle.Exclamation, "Facturación")
                        End If
                    End If
                End If
            Next iFila
        Catch ex As Exception
            MsgBox("Error al abrir el archivo, avise a Sistemas!", MsgBoxStyle.Exclamation, "Facturación")
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnSustitucion_Click(sender As Object, e As EventArgs) Handles btnSustitucion.Click
        Dim intSeleccionados As Integer
        Dim intFila As Integer = 0
        Dim sSQL As String = ""
        Dim bolSeleccionaron As Boolean = False
        Dim Seleccionaron As Integer = 0
        Dim drNew As DataRow
        Dim TipoF As String = ""

        If dgvResultadoFact.RowCount <= 0 Then
            Exit Sub
        End If

        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                    If dgvResultadoFact.Item("colEstatus", iFila).Value = "A" Then
                        intSeleccionados = intSeleccionados + 1
                        bolSeleccionaron = True
                    Else
                        MsgBox("Esta Factura esta cancelada!", MsgBoxStyle.Exclamation, "Facturación")
                        Exit Sub
                    End If
                End If
            End If
        Next iFila

        If Not bolSeleccionaron Then
            MsgBox("Por favor seleccione 1 folio a sustituir.", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        If intSeleccionados > 1 Then
            MsgBox("Solo debe selecciona 1 solo folio a sustituir.", MsgBoxStyle.Exclamation, "Facturación")
            Exit Sub
        End If

        dtEnviar = dtBusqueda.Clone
        For iFila = 0 To dgvResultadoFact.RowCount - 1
            If Not IsDBNull(dgvResultadoFact.Item("colSel", iFila).Value) Then
                If dgvResultadoFact.Item("colSel", iFila).Value = True Then
                    If dgvResultadoFact.Item("colEstatus", iFila).Value = "A" Then
                        drNew = dtEnviar.NewRow
                        drNew("FechaFactura") = dgvResultadoFact.Item("colFecha", iFila).Value
                        drNew("Folio") = dgvResultadoFact.Item("colFolio", iFila).Value
                        drNew("Serie") = dgvResultadoFact.Item("colSerie", iFila).Value
                        drNew("TipoFactura") = dgvResultadoFact.Item("colTipo", iFila).Value
                        drNew("FolioFiscal") = dgvResultadoFact.Item("colUUID", iFila).Value
                        drNew("NombreArchivoPDF") = dgvResultadoFact.Item("colArchivoPDF", iFila).Value
                        drNew("NombreArchivoXML") = dgvResultadoFact.Item("colArchivoXML", iFila).Value
                        drNew("CorreoE") = dgvResultadoFact.Item("colCorreo", iFila).Value
                        drNew("NoCliente") = dgvResultadoFact.Item("colNoCliente", iFila).Value
                        dtEnviar.Rows.Add(drNew)
                        dtEnviar.AcceptChanges()
                        FechaCancelado = dgvResultadoFact.Item("colFecha", iFila).Value
                        TipoF = dgvResultadoFact.Item("colTipo", iFila).Value
                    Else
                        MsgBox("Esta Factura ya esta cancelada!", MsgBoxStyle.Exclamation, "Facturación")
                        Exit Sub
                    End If
                End If
            End If
        Next iFila

        Dim frmDatCancelar As New frmCancelarFactura
        TipoCancelacion = "SUSTITUCION"
        frmDatCancelar.TipoFactura = TipoF
        frmDatCancelar.ShowDialog()
        If frmDatCancelar.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

    End Sub
End Class

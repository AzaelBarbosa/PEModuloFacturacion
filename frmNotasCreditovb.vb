Imports System.IO

Public Class frmNotasCreditovb

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sSQL As String = ""
        Dim oParam(12) As SqlClient.SqlParameter
        Dim dtTest As New DataTable

        sArchivoLog = "C:\SPE\VINO\LOG\LogFactura_Proceso_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
        wrFichero = File.AppendText(sArchivoLog)

        If bolTienePuntodeVenta Then
            'tiene punto de venta
            If bolTieneVentaAparatos Or bolTieneVentaJoyeria Then
                'tiene venta de aparatos
                Try
                    strFechaBusqueda = Format(dtpFechaIni.Value, "yyyy-MM-dd")
                    FechaFact = Format(dtpFechaIni.Value, "yyyyMMdd")

                    lblTextoAnuncio.Text = "Esperando actualización de Aparatos..."
                    lblTextoAnuncio.Visible = True
                    lblTextoAnuncio.Refresh()

                    SQLServer.Init(, strBDAQGlobal, strServerAQ, strUsrAQ, strPwdAQ)
                    'probando
                    sSQL = "SELECT TOP 1 * FROM PE.dbo.Catalogos"
                    dtTest = SQLServer.ExecSQLReturnDT(sSQL, "Catalogos")


                    AdminpaqEsperaActualizacion()

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
                    If Not dsDevs Is Nothing Then
                        dtDevsEnca = dsDevs.Tables(0)
                        dtDevsDeta = dsDevs.Tables(1)
                        dtDevsDeta.Columns.Add("DescripcionSAT", GetType(String))
                        dtDevsDeta.AcceptChanges()
                    End If
                    dgvResultado.DataSource = dtDevsDeta
                    dgvResultado.Refresh()

                    strTipoFactura = "GLOBAL"

                    lblTextoAnuncio.Visible = False
                    lblTextoAnuncio.Refresh()

                    ConectaBD()

                Catch excnn As Exception
                    Me.Cursor = Cursors.Default
                    MsgBox("no hay conexión con el servidor de venta de aparatos, por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturacion")
                    Me.Cursor = Cursors.WaitCursor
                End Try
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        lblTextoAnuncio.Text = "Generando notas de crédito..."
        lblTextoAnuncio.Visible = True
        lblTextoAnuncio.Refresh()

        If Not dtDevsEnca Is Nothing AndAlso dtDevsEnca.Rows.Count > 0 Then
            Dim x1 As String = ""
            Dim x2 As String = ""

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
            'lblTextoAnuncio.Text = "Generando notas de crédito..."
            'lblTextoAnuncio.Visible = True
            'lblTextoAnuncio.Refresh()

            GeneraNotasdeCredito2(x1, x2)
        End If

        dtCliente.Rows.Clear()

        dsDevs = New DataSet
        dtDevsEnca = New DataTable
        dtDevsDeta = New DataTable

        dgvResultado.DataSource = dtDevsDeta

        lblTextoAnuncio.Visible = False
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmNotasCreditovb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboInclDirCte.SelectedIndex = 0
        cboInclDirSuc.SelectedIndex = 1

    End Sub
End Class
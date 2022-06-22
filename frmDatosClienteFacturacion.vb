Imports VB = Microsoft.VisualBasic

Public Class frmDatosClienteFacturacion

#Region "Variables"

    Dim arrFormaPago As New ArrayList
    Dim arrMetodoPago As New ArrayList
    Dim arrUsoCFDI As New ArrayList
    Dim arrMoneda As New ArrayList
    Dim arrRegimenFiscal As New ArrayList
    Dim intFormaPagoID As Integer = 0
    Dim intMetodoPagoID As Integer = 0
    Dim intUsoCFDIID As Integer = 0
    Dim bolMostrarAvisoRFC As Boolean = False
    Private dgvDatos As DataGridView

#End Region

#Region "Propiedades"

    Public Property GridDatos As DataGridView
        Get
            Return dgvDatos
        End Get
        Set(value As DataGridView)
            dgvDatos = value
        End Set
    End Property

#End Region

#Region "Procedimientos"

    Private Function Valida() As Boolean
        Dim bolResult As Boolean = False
        Try
            'nombre o razon social, forma de pago, metodo de pago y uso de cfdi
            If (txtNombre.Text.Trim = "" And txtRazonSocial.Text.Trim = "") Then
                MsgBox("Por favor capture el Nombre o la Razón Social!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Function
            End If
            If cboFormaPago.SelectedIndex = 0 Then
                MsgBox("Por favor seleccione la Forma de Pago!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Function
            End If
            If cboMetodoPago.SelectedIndex = 0 And cboUsoCFDI.SelectedIndex > 0 Then
                MsgBox("Por favor seleccione el Método de Pago!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Function
            End If
            If cboUsoCFDI.SelectedIndex = 0 Then
                MsgBox("Por favor seleccione el Uso del CFDI!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Function
            End If
            If txtRFC.Text.Trim = "" Then
                MsgBox("Por favor capture el RFC!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Function
            End If
            If txtRFC.Text.Length < 12 Or txtRFC.Text.Length > 13 Then
                MsgBox("Por favor capture el RFC!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Function
            End If
            bolResult = True
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            Valida = bolResult
        End Try
    End Function

    Public Sub Muestra()
        Dim dr As DataRow
        Try
            Limpia()
            cboFormaPago.SelectedValue = DameFormaPagoIDDefault()
            cboMetodoPago.SelectedValue = DameMetodoPagoIDDefault()
            cboMoneda.SelectedValue = DameMonedaIDDefault()
            cboUsoCFDI.SelectedValue = DameMetodoPagoIDDefault()
            If dtCliente Is Nothing OrElse dtCliente.Rows.Count <= 0 Then
                'DatosCliente(0)
                GoTo Seguir
            End If
            dr = dtCliente.Rows(0)
            txtCalle.Text = dr("CalleFiscal").ToString.Trim
            txtCiudad.Text = dr("MunicipioFiscal").ToString.Trim
            txtColonia.Text = dr("ColoniaFiscal").ToString.Trim
            txtCP.Text = dr("CodigoPostalFiscal").ToString.Trim
            txtEstado.Text = dr("EstadoFiscal").ToString.Trim
            txtNoExt.Text = dr("NoExteriorFiscal").ToString.Trim
            txtNoInt.Text = dr("NoInteriorFiscal").ToString.Trim
            txtNombre.Text = dr("NombreCliente").ToString.Trim
            txtPais.Text = dr("PaisFiscal").ToString.Trim
            txtRazonSocial.Text = dr("RazonSocial").ToString.Trim
            txtRFC.Text = dr("RFC").ToString.Trim
            txtTelefono.Text = dr("Telefono01").ToString.Trim
            txtCorreo.Text = dr("CorreoE").ToString.Trim

Seguir:
            If txtRFC.Text.Trim.Length < 12 Or txtRFC.Text.Trim.Length > 13 Then
                bolMostrarAvisoRFC = True
                txtRFC.BackColor = Color.Yellow
                txtRFC.Text = strRFCGenerico
            End If

            If PagoAplazado = True Then
                cboMetodoPago.SelectedIndex = 1
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Private Sub Limpia()
        Try
            txtCalle.Text = ""
            txtCiudad.Text = ""
            txtColonia.Text = ""
            txtCP.Text = ""
            txtEstado.Text = ""
            txtNoExt.Text = ""
            txtNoInt.Text = ""
            txtNombre.Text = ""
            txtPais.Text = ""
            txtRazonSocial.Text = ""
            txtRFC.Text = ""
            txtTelefono.Text = ""
            txtCorreo.Text = ""
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Private Sub LlenaCombos()
        Try
            arrFormaPago = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "DescCorta", , "Tabla=104 AND Elemento<>0", "DescCorta")
            arrFormaPago.Insert(0, New ComboArray("--- SELECCIONE ---", 0))
            cboFormaPago.DataSource = arrFormaPago
            cboFormaPago.DisplayMember = "Description"
            cboFormaPago.ValueMember = "ID"

            arrMetodoPago = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "DescCorta", , "Tabla=103 AND Elemento<>0 AND Estatus='A'", "DescCorta")
            arrMetodoPago.Insert(0, New ComboArray("--- SELECCIONE ---", 0))
            cboMetodoPago.DataSource = arrMetodoPago
            cboMetodoPago.DisplayMember = "Description"
            cboMetodoPago.ValueMember = "ID"

            'arrUsoCFDI = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "DescCorta", , "Tabla=105 AND Elemento<>0 AND Estatus='A'", "DescCorta")
            'arrUsoCFDI.Insert(0, New ComboArray("--- SELECCIONE ---", 0))
            'cboUsoCFDI.DataSource = arrUsoCFDI
            'cboUsoCFDI.DisplayMember = "Description"
            'cboUsoCFDI.ValueMember = "ID"

            arrMoneda = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "DescCorta", , "Tabla=107 AND Elemento<>0", "DescCorta")
            arrMoneda.Insert(0, New ComboArray("--- SELECCIONE ---", 0))
            cboMoneda.DataSource = arrMoneda
            cboMoneda.DisplayMember = "Description"
            cboMoneda.ValueMember = "ID"

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub
    
    Private Sub AgregaCliente()
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim intNoClienteNuevo As Integer = 0
        Try
            'buscando al cliente
            sSQL = "SELECT * FROM BPFCatalogoClientes WHERE NombreCliente LIKE '%" & txtNombre.Text.Trim.ToUpper & "%'"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoClientes")

            If dtBusca Is Nothing OrElse dtBusca.Rows.Count <= 0 Then
                'si no existe, lo agrego
                'obteniendo el numero de cliente siguiente para la sucursal
                sSQL = "SELECT Max(NoCliente) AS Ultimo FROM BPFCatalogoClientes WHERE NoCliente <= 500000"
                dtBusca = New DataTable
                dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoClientes")
                If dtBusca Is Nothing OrElse dtBusca.Rows.Count <= 0 Then
                    intNoClienteNuevo = 1
                Else
                    intNoClienteNuevo = dtBusca.Rows(0).Item("Ultimo") + 1
                End If
                'agregando
                sSQL = ""
                sSQL = "INSERT INTO BPFCatalogoClientes(NoCliente, NombreCliente, Identificacion, Calle, Colonia, Municipio, Estado, CodigoPostal, Telefono01, Telefono02, Observacion, Clasificacion, TipoCliente, FechaAlta, FechaUM,Mercadeo,RFC,Ocupacion,FechaNacimiento,NoExt,NoInt,CorreoE,CURP,TipoIdentificacion,PaisID,PaisNacimientoID,PaisNacionalidadID,Nombres,ApellidoPaterno,ApellidoMaterno,"
                sSQL &= "BoletasVigentes,RazonSocial,CalleFiscal,NoExteriorFiscal,NoInteriorFiscal,ColoniaFiscal,PoblacionFiscal,MunicipioFiscal,EstadoFiscal,CodigoPostalFiscal,PaisFiscal,Referencia,ClaveUsoCFDISAT,TipoPersona,RegimenFiscal)"
                sSQL &= "VALUES (" & intNoClienteNuevo.ToString & ",'" & txtNombre.Text.Trim.ToUpper & "','','" & txtCalle.Text.Trim.ToUpper & "','" & txtColonia.Text.Trim.ToUpper & "','" & txtCiudad.Text.Trim.ToUpper & "','" & txtEstado.Text.Trim.ToUpper & "','" & txtCP.Text.Trim.ToUpper & "','" & txtTelefono.Text.Trim & "','','',1,1,CONVERT(VARCHAR(8),GETDATE(),112),CONVERT(VARCHAR(8),GETDATE(),112),'NO','" & txtRFC.Text.Trim.ToUpper & "','','','" & txtNoExt.Text.Trim.ToUpper & "','" & txtNoInt.Text.Trim.ToUpper & "','" & txtCorreo.Text.Trim.ToLower & "','',0,1,1,1,'Nombres','ApellidoPaterno','ApellidoMaterno',"
                sSQL &= "0,'" & txtRazonSocial.Text.Trim.ToUpper & "','" & txtCalle.Text.Trim.ToUpper & "','" & txtNoExt.Text.Trim.ToUpper & "','" & txtNoInt.Text.Trim.ToUpper & "','" & txtColonia.Text.Trim.ToUpper & "','" & txtCiudad.Text.Trim.ToUpper & "','" & txtCiudad.Text.Trim.ToUpper & "','" & txtEstado.Text.Trim.ToUpper & "','" & txtCP.Text.Trim.ToUpper & "','" & txtPais.Text.Trim.ToUpper & "','','" & VB.Left(cboUsoCFDI.Text, 3) & "','" & IIf(rbFisica.Checked = True, "Fisica", "Moral") & "','" & VB.Left(cboRegimenFiscal.Text, 3) & "')"

                SQLServer.ExecSQL(sSQL)

                DatosCliente(intNoClienteNuevo)
            Else
                'si ya existe, le actualizo la info
                If txtNombre.Text.Trim.ToUpper <> "PUBLICO EN GENERAL" Then
                    If dtBusca.Rows(0).Item("NoCliente").ToString <> 0 Then
                        sSQL = "UPDATE BDSPEXPRESS.dbo.BPFCatalogoClientes SET RFC='" & txtRFC.Text.Trim.ToUpper & "', "
                        sSQL &= "RazonSocial='" & txtRazonSocial.Text.Trim.ToUpper & "', "
                        sSQL &= "Callefiscal='" & txtCalle.Text.Trim.ToUpper & "', "
                        sSQL &= "NoExteriorFiscal='" & txtNoExt.Text.Trim.ToUpper & "', "
                        sSQL &= "NoInteriorFiscal='" & txtNoInt.Text.Trim.ToUpper & "', "
                        sSQL &= "CorreoE='" & txtCorreo.Text.Trim.ToLower & "', "
                        sSQL &= "ColoniaFiscal='" & txtColonia.Text.Trim.ToUpper & "', "
                        sSQL &= "PoblacionFiscal='" & txtCiudad.Text.Trim.ToUpper & "', "
                        sSQL &= "MunicipioFiscal='" & txtCiudad.Text.Trim.ToUpper & "', "
                        sSQL &= "EstadoFiscal='" & txtEstado.Text.Trim.ToUpper & "', "
                        sSQL &= "CodigoPostalFiscal='" & txtCP.Text.Trim.ToUpper & "', "
                        sSQL &= "PaisFiscal='" & txtPais.Text.Trim.ToUpper & "', "
                        sSQL &= "Telefono01='" & txtTelefono.Text.Trim & "', "
                        sSQL &= "ClaveUsoCFDISAT='" & VB.Left(cboUsoCFDI.Text, 3) & "', "
                        sSQL &= "TipoPersona='" & IIf(rbFisica.Checked = True, "Fisica", "Moral") & "', "
                        sSQL &= "RegimenFiscal='" & VB.Left(cboRegimenFiscal.Text, 3) & "' "
                        sSQL &= "WHERE NoCliente=" & dtBusca.Rows(0).Item("NoCliente").ToString
                        SQLServer.ExecSQL(sSQL)
                        DatosCliente(dtBusca.Rows(0).Item("NoCliente"))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Private Sub DeterminaFormadePagoMayor()
        Dim intFormaPagoMayor As Integer = 0
        Dim dblImporteMayor As Double = 0
        Dim intFila As Integer

        Try
            'determinando el ticket con mayor importe
            For intFila = 0 To dgvDatos.RowCount - 1
                If CDbl(dgvDatos.Item("colFImportePago", intFila).Value) > dblImporteMayor Then
                    dblImporteMayor = CDbl(dgvDatos.Item("colFImportePago", intFila).Value)
                    intFormaPagoMayor = CInt(dgvDatos.Item("colFFormaPagoSAT", intFila).Value)
                End If
            Next intFila

            If intFormaPagoMayor <= 0 Then
                intFormaPagoMayor = 1
            End If

            Me.cboFormaPago.SelectedValue = intFormaPagoMayor

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "DeterminaFormadePagoMayor")
        End Try
    End Sub

#End Region

    Private Sub frmDatosClienteFacturacion_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.BackgroundImage = Pantallazo
        Me.Text = "Datos Cliente Facturación - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        Panel1.Left = (Me.Width / 2) - (Me.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Me.Height / 2)

        LlenaCombos()
        Muestra()
        DeterminaFormadePagoMayor()

        If bolMostrarAvisoRFC Then
            bolMostrarAvisoRFC = False
            If MsgBox("No existe el Cliente." & vbCrLf & "Desea utilizar cliente Publico en General.?" & vbCrLf & vbCr, MsgBoxStyle.YesNo, "Facturación") = vbYes Then
                chbPublicoGeneral.Checked = True
            Else
                Limpia()
            End If
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        correoFact = ""
        If Valida() Then
            'BUSCAR AL CLIENTE EN LA BD DE EMPEñO, SI NO EXISTE, AGREGARLO
            If strDirCli = True And txtNombre.Text = "" Then
                MsgBox("Por favor capture el Nombre del Cliente...", MsgBoxStyle.Exclamation, "Facturacion")
                txtNombre.Focus()
                Exit Sub
            End If
            If strDirCli = True And txtRazonSocial.Text = "" Then
                MsgBox("Por favor capture la Razon Social...", MsgBoxStyle.Exclamation, "Facturacion")
                txtRazonSocial.Focus()
                Exit Sub
            End If
            If strDirCli = True And txtCalle.Text = "" Then
                MsgBox("Por favor capture el Domicilio...", MsgBoxStyle.Exclamation, "Facturacion")
                txtCalle.Focus()
                Exit Sub
            End If
            If strDirCli = True And txtColonia.Text = "" Then
                MsgBox("Por favor capture la Colonia...", MsgBoxStyle.Exclamation, "Facturacion")
                txtColonia.Focus()
                Exit Sub
            End If
            If txtCP.Text = "" Then
                MsgBox("Por favor capture la Codigo Postal...", MsgBoxStyle.Exclamation, "Facturacion")
                txtCP.Focus()
                Exit Sub
            End If
            If strDirCli = True And txtCiudad.Text = "" Then
                MsgBox("Por favor capture la Ciudad...", MsgBoxStyle.Exclamation, "Facturacion")
                txtCiudad.Focus()
                Exit Sub
            End If
            If strDirCli = True And txtEstado.Text = "" Then
                MsgBox("Por favor capture el Estado...", MsgBoxStyle.Exclamation, "Facturacion")
                txtEstado.Focus()
                Exit Sub
            End If
            If strDirCli = True And txtPais.Text = "" Then
                MsgBox("Por favor capture el Pais...", MsgBoxStyle.Exclamation, "Facturacion")
                txtPais.Focus()
                Exit Sub
            End If
            If txtCorreo.Text = "" Then
                MsgBox("Por favor capture la Direccion de correo electronico...", MsgBoxStyle.Exclamation, "Facturacion")
                txtCorreo.Focus()
                Exit Sub
            End If

            If rbFisica.Checked = False And rbMoral.Checked = False Then
                MsgBox("Por favor seleccione si es persona Moral o Fisica...", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If

            If cboRegimenFiscal.Text = "" Or cboRegimenFiscal.Text = "--- SELECCIONE ---" Then
                MsgBox("Por favor seleccione el Regimen Fiscal...", MsgBoxStyle.Exclamation, "Facturacion")
                cboRegimenFiscal.Focus()
                Exit Sub
            End If

            If cboRegimenFiscal.Text = "" Or cboRegimenFiscal.Text = "--- SELECCIONE ---" Then
                MsgBox("Por favor seleccione el Regimen Fiscal...", MsgBoxStyle.Exclamation, "Facturacion")
                cboRegimenFiscal.Focus()
                Exit Sub
            End If

            If ValidaUSOCFDI(VB.Left(cboUsoCFDI.Text, 3), VB.Left(cboRegimenFiscal.Text, 3)) = False Then
                MsgBox("Por favor seleccione un Regimen Fiscal Valido para el Uso del CFDI...", MsgBoxStyle.Exclamation, "Facturacion")
                cboRegimenFiscal.Focus()
                Exit Sub
            End If

            ErrorProvider1.Clear()
            If txtCorreo.Text <> "" Then
                If validar_Mail(LCase(txtCorreo.Text)) = False Then
                    ErrorProvider1.SetError(txtCorreo, "Dirección de correo electronico invalida, el correo debe tener el formato: " & vbNewLine & _
                                            "nombre@dominio.com, por favor seleccione un correo valido")
                    txtCorreo.Focus()
                    txtCorreo.SelectAll()
                    Exit Sub
                End If
            End If

            If MsgBox("Los datos Capturados son Correctos?, Desea continuar con la emisión de la Factura?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                Exit Sub
            End If

            correoFact = txtCorreo.Text.Trim.ToLower
            AgregaCliente()

            strMonedaClaveIND = VB.Left(cboMoneda.Text, 3)
            strUsoCFDIClaveIND = VB.Left(cboUsoCFDI.Text, 3)
            strFormaPagoClaveIND = Format(cboFormaPago.SelectedValue, "00")
            strMetodoPagoClaveIND = VB.Left(cboMetodoPago.Text, 3)
            strRegimenFiscalIND = VB.Left(cboRegimenFiscal.Text, 3)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpia()
    End Sub

    Private Sub btnLimpiar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiar.MouseLeave
        Label18.Visible = False
    End Sub

    Private Sub btnLimpiar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLimpiar.MouseMove
        Label18.Visible = True
    End Sub

    Private Sub btnAceptar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.MouseLeave
        Label19.Visible = False
    End Sub

    Private Sub btnAceptar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAceptar.MouseMove
        Label19.Visible = True
    End Sub

    Private Sub btnCancelar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.MouseLeave
        Label20.Visible = False
    End Sub

    Private Sub btnCancelar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCancelar.MouseMove
        Label20.Visible = True
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Try
            If txtRFC.Text.Trim = "" Then
                MsgBox("Por favor capture el RFC para buscar al cliente!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If
            If txtRFC.Text.Trim.Length < 12 Or txtRFC.Text.Trim.Length > 13 Then
                MsgBox("Por favor capture el RFC para buscar al cliente!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If

            sSQL = "SELECT * FROM BPFCatalogoClientes WHERE RFC='" & txtRFC.Text.Trim.ToUpper & "'"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoClientes")

            If dtBusca Is Nothing OrElse dtBusca.Rows.Count <= 0 Then
                MsgBox("Cliente no encontrado! Por favor verifique.", MsgBoxStyle.Information, "Facturacion")
                Exit Sub
            End If

            dtCliente = New DataTable
            dtCliente = dtBusca.Copy

            Muestra()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion" & " - Buscar Cliente")
        End Try
    End Sub

    Private Sub btnBuscar_MouseLeave(sender As Object, e As EventArgs) Handles btnBuscar.MouseLeave
        Label22.Visible = False
    End Sub

    Private Sub btnBuscar_MouseMove(sender As Object, e As MouseEventArgs) Handles btnBuscar.MouseMove
        Label22.Visible = True
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub chbPublicoGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles chbPublicoGeneral.CheckedChanged
        If chbPublicoGeneral.Checked = True Then
            DatosCliente(0)
            Muestra()
        Else
            Limpia()
        End If
    End Sub

    Private Sub btnBuscaCliente_Click(sender As Object, e As EventArgs) Handles btnBuscaCliente.Click
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Try
            If txtRFC.Text.Trim = "" Then
                MsgBox("Por favor capture el RFC para buscar al cliente!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If
            If txtRFC.Text.Trim.Length < 12 Or txtRFC.Text.Trim.Length > 13 Then
                MsgBox("Por favor capture el RFC para buscar al cliente!", MsgBoxStyle.Exclamation, "Facturacion")
                Exit Sub
            End If

            sSQL = "SELECT * FROM BPFCatalogoClientes WHERE RFC='" & txtRFC.Text.Trim.ToUpper & "'"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoClientes")

            If dtBusca Is Nothing OrElse dtBusca.Rows.Count <= 0 Then
                MsgBox("Cliente no encontrado! Por favor verifique.", MsgBoxStyle.Information, "Facturacion")
                Limpia()
                Exit Sub
            End If

            dtCliente = New DataTable
            dtCliente = dtBusca.Copy

            Muestra()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion" & " - Buscar Cliente")
        End Try
    End Sub

    Private Sub chbValoresFP_CheckedChanged(sender As Object, e As EventArgs) Handles chbValoresFP.CheckedChanged
        If chbValoresFP.Checked = True Then
            DeterminaFormadePagoMayor()
        End If
    End Sub

    Private Sub cboMetodoPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMetodoPago.SelectedIndexChanged

    End Sub

    Private Sub cboMetodoPago_TextChanged(sender As Object, e As EventArgs) Handles cboMetodoPago.TextChanged
        'If cboMetodoPago.SelectedIndex = 2 Then
        '    cboFormaPago.SelectedIndex = 5
        'Else
        '    DeterminaFormadePagoMayor()
        'End If
    End Sub

    Private Sub lblTextoAnuncio_Click(sender As Object, e As EventArgs) Handles lblTextoAnuncio.Click

    End Sub

    Private Sub rbMoral_CheckedChanged(sender As Object, e As EventArgs) Handles rbMoral.CheckedChanged
        Try
            arrRegimenFiscal = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "DescCorta", , "Tabla=113 AND Elemento<>0 AND Estatus = 'A' AND Valor2T IN ('M', 'A')", "DescCorta")
            arrRegimenFiscal.Insert(0, New ComboArray("--- SELECCIONE ---", 0))
            cboRegimenFiscal.DataSource = arrRegimenFiscal
            cboRegimenFiscal.DisplayMember = "Description"
            cboRegimenFiscal.ValueMember = "ID"

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try

    End Sub

    Private Sub rbFisica_CheckedChanged(sender As Object, e As EventArgs) Handles rbFisica.CheckedChanged
        Try

            arrRegimenFiscal = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "DescCorta", , "Tabla=113 AND Elemento<>0 AND Estatus = 'A' AND Valor2T IN ('F', 'A')", "DescCorta")
            arrRegimenFiscal.Insert(0, New ComboArray("--- SELECCIONE ---", 0))
            cboRegimenFiscal.DataSource = arrRegimenFiscal
            cboRegimenFiscal.DisplayMember = "Description"
            cboRegimenFiscal.ValueMember = "ID"

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Private Sub cboUsoCFDI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUsoCFDI.SelectedIndexChanged

    End Sub

    Private Sub cboRegimenFiscal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRegimenFiscal.SelectedIndexChanged

        If rbMoral.Checked = True Then
            arrUsoCFDI = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "DescCorta", , "Tabla=105 AND Elemento<>0 AND Estatus='A' AND Valor2T IN ('M', 'A') AND Valor3T LIKE '% " & VB.Left(cboRegimenFiscal.Text, 3) & "%'", "DescCorta")
            arrUsoCFDI.Insert(0, New ComboArray("--- SELECCIONE ---", 0))
            cboUsoCFDI.DataSource = arrUsoCFDI
            cboUsoCFDI.DisplayMember = "Description"
            cboUsoCFDI.ValueMember = "ID"
        ElseIf rbFisica.Checked = True Then
            arrUsoCFDI = Utilerias.BuildComboArray("BPFCatalogos", "DescLarga", "Elemento", "DescCorta", , "Tabla=105 AND Elemento<>0 AND Estatus='A' AND Valor2T IN ('F', 'A') AND Valor3T LIKE '% " & VB.Left(cboRegimenFiscal.Text, 3) & "%'", "DescCorta")
            arrUsoCFDI.Insert(0, New ComboArray("--- SELECCIONE ---", 0))
            cboUsoCFDI.DataSource = arrUsoCFDI
            cboUsoCFDI.DisplayMember = "Description"
            cboUsoCFDI.ValueMember = "ID"
        End If

    End Sub
End Class
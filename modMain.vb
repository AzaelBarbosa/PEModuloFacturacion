Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography
Imports System.ServiceModel
Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Net.Security


Module modMain

#Region "Variables Globales"
    Public strUsuario As Integer = 0
    Public strTipoFactura As String = ""
    Public strmodoFactura As String = ""
    Public texto As String = ""
    Public nombreArchi As String = ""
    Public FechaLog As String = ""
    Public nombreLog As String = ""
    Public frmMenu As New frmMenuFacturacion
    Public frmFactInd As frmFacturaIndividual
    Public frmFactGlbl As frmFacturaGlobalDiaria
    Public frmManFact As frmManejoFactura
    Public frmFactGlblAut As frmFacGlobalAutomatica
    Public bolTienePuntodeVenta As Boolean = False
    Public bolTieneVentaAparatos As Boolean = False
    Public bolTieneVentaJoyeria As Boolean = False
    Public strServerEmpeno As String = ""
    Public strBDEmpeno As String = ""
    Public strUsrEmpeno As String = ""
    Public strPwdEmpeno As String = ""
    Public strServerAQ As String = ""
    Public strBDAQ As String = ""
    Public strBDAQGlobal As String = ""
    Public strUsrAQ As String = ""
    Public strPwdAQ As String = ""
    Public strServerJY As String = ""
    Public strBDJY As String = ""
    Public strUsrJY As String = ""
    Public strPwdJY As String = ""
    Public dblPorcentajeIVA As Double
    Public intNoSucursal As Long = 0
    Public strNombreSuc As String = ""
    Public dtResumen As New DataTable
    Public dtDetalle As New DataTable
    Public dsDevs As DataSet
    Public dtDevsEnca As New DataTable
    Public dtDevsDeta As New DataTable
    Public dtCliente As New DataTable
    Public dtFactPend As New DataTable
    'Public dtEmisor As New DataTable
    Public dtLugarEmision As New DataTable
    Public dtOrganizacion As New DataTable

    'Variables para Uso Masivo
    Public FechaManual As String
    Public UsoFManual As Integer


    Public strFechaUltimoCierre As String       'para obtener cuando fue el ultimo cierre,solo de esa fecha se puede hacer la global
    Public sRuta As String = "" 'Ruta PAR log 

    Public intElementoCata As Integer = 0
    Public strAreaServicioTimbrado As String = ""
    Public strUsuarioServicioTimbrado As String = ""
    Public strCuentaServicioTimbrado As String = ""
    Public strContrasenaServicioTimbrado As String = ""
    Public strSerieFactura As String = ""
    Public strSiguienteFolio As String = ""
    Public intSiguienteFolio As Long = 0
    Public intSiguienteFolioNC As Integer = 0
    Public dblSumaImporte As Double = 0
    Public dblSumaDescuento As Double = 0
    Public dblSumaIVA As Double = 0
    Public dblSumaTotal As Double = 0
    Public dblSumaInteres As Double = 0
    Public dblSumaRecargo As Double = 0
    Public dblSumaCosto As Double = 0
    Public dblSubtotal As Double = 0
    Public Sistema As String = ""
    Public Factura As String = ""
    Public Accion As String = ""
    Public PagoAplazado As Boolean = False
    Public errorNC As Boolean = False
    Public errorFG As Boolean = False
    Public TipoFac As String = ""
    Public EstatusFac As String = ""
    Public serieFac As String = ""
    Public folioFac As String = ""
    Public fechaFac As String = ""
    Public FechaLimite As String = ""
    Public CreditosLimite As String = ""

    Public strCliNombre As String = ""
    Public strCliRFC As String = ""
    Public strCliCalle As String = ""
    Public strCliCodigoPostal As String = ""
    Public strCliColonia As String = ""
    Public strCliEstado As String = ""
    Public strCliLocalidad As String = ""
    Public strCliMunicipio As String = ""
    Public strCliNombreCliente As String = ""
    Public strCliNumeroExterior As String = ""
    Public strCliNumeroInterior As String = ""
    Public strCliPais As String = ""
    Public strCliReferencia As String = ""
    Public strCliTelefono As String = ""

    Public strEmiCalle As String = ""
    Public strEmiCodigoPostal As String = ""
    Public strEmiColonia As String = ""
    Public strEmiEstado As String = ""
    Public strEmiLocalidad As String = ""
    Public strEmiMunicipio As String = ""
    Public strEmiNombreCliente As String = ""
    Public strEmiNumeroExterior As String = ""
    Public strEmiNumeroInterior As String = ""
    Public strEmiPais As String = ""
    Public strEmiReferencia As String = ""
    Public strEmiTelefono As String = ""

    Public strSucCalle As String = ""
    Public strSucCodigoPostal As String = ""
    Public strSucColonia As String = ""
    Public strSucEstado As String = ""
    Public strSucLocalidad As String = ""
    Public strSucMunicipio As String = ""
    Public strSucNombreCliente As String = ""
    Public strSucNumeroExterior As String = ""
    Public strSucNumeroInterior As String = ""
    Public strSucPais As String = ""
    Public strSucReferencia As String = ""
    Public strSucTelefono As String = ""
    Public strMonedaClave As String = "'"
    Public strUsoCFDIClave As String = ""
    Public strFormaPagoClave As String = ""
    Public strMetodoPagoClave As String = ""
    Dim strNombreArchivoXML As String = ""
    Dim strNombreArchivoPDF As String = ""

    Public strMonedaClaveIND As String = "'"
    Public strUsoCFDIClaveIND As String = ""
    Public strFormaPagoClaveIND As String = ""
    Public strMetodoPagoClaveIND As String = ""
    Public bolObtuvoCred As Boolean = False

    Public strUUID As String = ""
    Public strCFDIRel As String = ""
    Public strTipoRel As String = ""
    Public strFechaTimbrado As String = ""
    Public strRespuesta As String = ""
    Public strDirSuc As Boolean = False
    Public strDirCli As Boolean = False
    Public seCancelo As Boolean = False
    Public conAcuse As Boolean = False
    Public strCBB As String = ""
    Public imgBytes() As Byte

    Public bolAdminpaqActualizando As Boolean = False

    Public dtClavesFiscales As New DataTable
    Public drClavesFiscales As DataRow
    Public dtEnviar As New DataTable

    Public strRegimenFiscal As String = ""
    Public strClaveProductoSAT As String = ""
    Public strUnidadMedidaSAT As String = ""
    Public strUnidadMedidaPE As String = ""
    Public strCondicionesPago As String = ""

    Public strRFCGenerico As String

    Public strEstatusGeneracion As String = ""

    'para mostrar la pantalla de vino como fake
    Public fSize As Size = Screen.PrimaryScreen.Bounds.Size
    Public bm As New Bitmap(fSize.Width, fSize.Height)
    Public gr As Graphics = Graphics.FromImage(bm)
    Public Pantallazo As Image

    Public CodIntSat As String = ""
    Public DescIntSat As String = ""
    Public CodApaSat As String = ""
    Public DescApaSat As String = ""
    Public correoFact As String = ""

    Public IvaS As Double = 0.0
    Public ivaAJ As Double = 0.0
    Public dtDetalleInd As New DataTable
    Public dtDetalleGlob As New DataTable
    Public dtDetalleDev As New DataTable
    Public dtDetDevAvr As New DataTable
    Public dtAgrupaDetalle As New DataTable
    Public tipoMovFact As String = ""

    Public TipoError As String = ""
    Public FechaFact As String
    Public FactTimbrada As Boolean = False
    Public Comprobando As String = ""
    Public MovBorrados As Boolean = False

    Public IntConexion As Integer = 0

    Public strFechaBusqueda As String = ""
    'CANCELACION/SUSTITUCION
    Public TipoCancelacion As String = ""
    Public FechaCancelado As String = ""
    Public CFDIRelacionadoCancelado As String = ""
    Public TipoRelacionCancelado As String = ""
#End Region

    Public Enum enTipoDocumento As Integer
        Factura = 1
        NotaCredito
    End Enum

    Public Enum enTipoDocumentoAfectar As Integer
        FacturaGlobal = 1
        FacturaIndividual
    End Enum

    Sub Main()

        'Prueba de Merge

        'leyendo el archivo config de la sucursal
        LeeConfig()
        'de forma predeterminada, se conecta primero al servidor de la sucursal
        ConectaBD()
        'obteniendo parámetros de la sucursal
        ObtenerParametros()
        'se leen los argumentos de la linea de comandos

        '----PARA PROBAR LA AUTOMATICA

        'strTipoFactura = "GLOBAL"
        'strmodoFactura = "AUTOMATICA"
        'frmFactGlblAut = New frmFacGlobalAutomatica
        'frmFactGlblAut.Automatico()

        '-------------------------

        Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        'identificando parámetros
        If CommandLineArgs.Count > 0 Then
            'trae argumentos, cuantos?
            If CommandLineArgs.Count = 2 Then
                strUsuario = CommandLineArgs(1).ToString.ToUpper
                If CommandLineArgs(0).ToString.ToUpper = "INDIVIDUAL" Then
                    gr.CopyFromScreen(0, 0, 0, 0, fSize)
                    Pantallazo = bm
                    strTipoFactura = "INDIVIDUAL"
                    strmodoFactura = "INDIVIDUAL"
                    If frmFactInd Is Nothing Then
                        frmFactInd = New frmFacturaIndividual
                    End If
                    frmFactInd.ShowDialog()
                ElseIf CommandLineArgs(0).ToString.ToUpper = "GLOBAL" Then
                    gr.CopyFromScreen(0, 0, 0, 0, fSize)
                    Pantallazo = bm
                    strTipoFactura = "GLOBAL"
                    strmodoFactura = "GLOBAL"
                    If frmFactGlbl Is Nothing Then
                        frmFactGlbl = New frmFacturaGlobalDiaria
                    End If
                    frmFactGlbl.ShowDialog()
                ElseIf CommandLineArgs(0).ToString.ToUpper = "CONSULTA" Then
                    gr.CopyFromScreen(0, 0, 0, 0, fSize)
                    Pantallazo = bm
                    If frmManFact Is Nothing Then
                        frmManFact = New frmManejoFactura
                    End If
                    frmManFact.ShowDialog()

                ElseIf CommandLineArgs(0).ToString.ToUpper = "AUTOMATICA" Then
                    strTipoFactura = "GLOBAL"
                    strmodoFactura = "AUTOMATICA"
                    frmFactGlblAut = New frmFacGlobalAutomatica
                    frmFactGlblAut.Automatico()
                    End
                ElseIf CommandLineArgs(0).ToString.ToUpper = "MENU" Then
                    'parámetros incorrectos, se muestra menú
                    'frmMenu.ShowDialog()
                End If
            End If
        Else                                   'Comentar esta linea para que no se ejecute sin argumentos
            'sin parámetros, se muestra menú
            frmMenu.ShowDialog()               'Comentar esta linea para que no se ejecute sin argumentos
        End If

        End

    End Sub

    Public Function validar_Mail(ByVal sMail As String) As Boolean
        Return Regex.IsMatch(sMail, _
                  "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    End Function

    Public Sub EnviarCorreo(ByVal creditos As String)
        Dim smtp As New System.Net.Mail.SmtpClient
        Dim correo As New System.Net.Mail.MailMessage
        Dim asuntoCorreo As String = ""
        Dim cuerpoCorreo As String = ""

        With smtp
            .Port = 587
            .Host = "smtp.office365.com"
            .Credentials = New System.Net.NetworkCredential("factura.electronica@prestamoexpress.com", "fael#123")
            .EnableSsl = True
        End With

        asuntoCorreo = "AVISO: Créditos CFDI restantes llego a límite mínimo, " & Format(intNoSucursal, "000").ToString & "-" & strNombreSuc
        cuerpoCorreo = "AVISO:<br>" & _
                       "Programar la compra de Créditos CFDI adicionales a la Sucursal " & Format(intNoSucursal, "000").ToString & "-" & strNombreSuc & _
                       " para continuar con la Facturación Electrónica. <br><br>" & _
                       "Créditos Restantes: " & creditos & " <br><br>" & _
                       "Atender con Prioridad <br>" & _
                       "Saludos!!!"
        With correo
            .From = New System.Net.Mail.MailAddress("factura.electronica@prestamoexpress.com")
            .To.Add("sistemas@prestamoexpress.com") 'sistemas@prestamoexpress.com.mx
            .Subject = asuntoCorreo
            .Body = cuerpoCorreo
            .IsBodyHtml = True
            .Priority = System.Net.Mail.MailPriority.High
        End With

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            smtp.Send(correo)
            'MessageBox.Show("Su mensaje de correo ha sido enviado.", _
            '                "Correo enviado", _
            '                 MessageBoxButtons.OK)
        Catch ex As Exception
            'MessageBox.Show("Error: " & ex.Message, _
            '                "Error al enviar correo", _
            '                 MessageBoxButtons.OK)
        End Try
    End Sub

    Public Sub EnviarCorreoLOG(ByVal NombreArchivo As String, ByVal Fecha As String, ByVal RutaArchivo As String)
        Dim smtp As New System.Net.Mail.SmtpClient
        Dim correo As New System.Net.Mail.MailMessage

        Dim data As Net.Mail.Attachment = New Net.Mail.Attachment(RutaArchivo)
        Dim asuntoCorreo As String = ""
        Dim cuerpoCorreo As String = ""
        data.Name = NombreArchivo


        With smtp
            .Port = 587
            .Host = "smtp.office365.com"
            .Credentials = New System.Net.NetworkCredential("factura.electronica@prestamoexpress.com", "fael#123")
            .EnableSsl = True
        End With

        If strmodoFactura = "AUTOMATICA" Then

            asuntoCorreo = "AVISO: Error al generar factura " & strmodoFactura & ", " & Format(intNoSucursal, "000").ToString & "-" & strNombreSuc
            cuerpoCorreo = "AVISO:<br>" & _
                           "Error al generar factura " & strmodoFactura & ", con fecha " & Fecha & " Sucursal: " & Format(intNoSucursal, "000").ToString & "-" & strNombreSuc & " <br><br>" & _
                           "Atender con Prioridad <br>" & _
                           "Saludos!!!"

        ElseIf strTipoFactura = "GLOBAL" Then

            asuntoCorreo = "AVISO: Error al generar factura " & strTipoFactura & ", " & Format(intNoSucursal, "000").ToString & "-" & strNombreSuc
            cuerpoCorreo = "AVISO:<br>" & _
                           "Error al generar factura " & strTipoFactura & ", con fecha " & Fecha & " Sucursal: " & Format(intNoSucursal, "000").ToString & "-" & strNombreSuc & " <br><br>" & _
                           "Atender con Prioridad <br>" & _
                           "Saludos!!!"
        Else

            asuntoCorreo = "AVISO: Error al generar factura " & strTipoFactura & ", " & Format(intNoSucursal, "000").ToString & "-" & strNombreSuc
            cuerpoCorreo = "AVISO:<br>" & _
                           "Error al generar factura " & strTipoFactura & ", con fecha " & Fecha & " Sucursal: " & Format(intNoSucursal, "000").ToString & "-" & strNombreSuc & " <br><br>" & _
                           "Atender con Prioridad <br>" & _
                           "Saludos!!!"

        End If

        With correo
            .From = New System.Net.Mail.MailAddress("factura.electronica@prestamoexpress.com")
            .To.Add("sistemas@prestamoexpress.com") 'sistemas@prestamoexpress.com.mx
            .Subject = asuntoCorreo
            .Body = cuerpoCorreo
            .Attachments.Add(data)
            .IsBodyHtml = True
            .Priority = System.Net.Mail.MailPriority.High
        End With

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            smtp.Send(correo)
            'MessageBox.Show("Su mensaje de correo ha sido enviado.", _
            '                "Correo enviado", _
            '                 MessageBoxButtons.OK)
        Catch ex As Exception
            'MessageBox.Show("Error: " & ex.Message, _
            '                "Error al enviar correo", _
            '                 MessageBoxButtons.OK)
        End Try
    End Sub
    Public Sub EnviarCorreoPrueba()

        Dim smtp As New System.Net.Mail.SmtpClient
        Dim correo As New System.Net.Mail.MailMessage


        Dim asuntoCorreo As String = ""
        Dim cuerpoCorreo As String = ""


        With smtp
            .Port = 587
            .Host = "smtp.office365.com"
            .Credentials = New System.Net.NetworkCredential("factura.electronica@prestamoexpress.com", "fael#123")
            .EnableSsl = True
        End With

        asuntoCorreo = "AVISO: Corre Prueba"
        cuerpoCorreo = "AVISO:<br>" & _
                       "Este es un Correo de Prueba del Modulo de Facturacion <br><br>" & _
                       "Saludos!!!"


        With correo
            .From = New System.Net.Mail.MailAddress("factura.electronica@prestamoexpress.com")
            .To.Add("sistemas@prestamoexpress.com") 'sistemas@prestamoexpress.com.mx
            .Subject = asuntoCorreo
            .Body = cuerpoCorreo
            .IsBodyHtml = True
            .Priority = System.Net.Mail.MailPriority.High
        End With



        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
            smtp.Send(correo)
            MessageBox.Show("Su mensaje de correo ha sido enviado.", _
                            "Correo enviado", _
                             MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, _
                            "Error al enviar correo", _
                             MessageBoxButtons.OK)
        End Try
    End Sub

    Public Function obtenerNoCreditos() As String
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim RespuestaServicio As Object
        Dim UUIDEnviar As String = ""
        Dim creditos As String = ""


        If strAreaServicioTimbrado = "PRUEBAS" Then
            datosUsuario = New FelTest.Credenciales
        Else
            datosUsuario = New FelProd.Credenciales
        End If

        If strCuentaServicioTimbrado <> "" Then
            datosUsuario.Cuenta = strCuentaServicioTimbrado
        End If
        If strContrasenaServicioTimbrado <> "" Then
            datosUsuario.Password = strContrasenaServicioTimbrado
        End If
        If strUsuarioServicioTimbrado <> "" Then
            datosUsuario.Usuario = strUsuarioServicioTimbrado
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            ConexionRemota33 = New FelTest.ConexionRemotaClient
        Else
            ConexionRemota33 = New FelProd.ConexionRemotaClient
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            RespuestaServicio = New FelTest.RespuestaOperacionCR
        Else
            RespuestaServicio = New FelProd.RespuestaOperacionCR
        End If

        Try

            RespuestaServicio = ConexionRemota33.ObtenerNumerosCreditos(datosUsuario)

            If RespuestaServicio.OperacionExitosa = True Then
                creditos = RespuestaServicio.CreditosRestantes
            Else
                If strmodoFactura = "AUTOMATICA" Then
                    texto = texto & "Error General: " & RespuestaServicio.ErrorGeneral & vbNewLine
                    texto = texto & "Error Detallado: " & RespuestaServicio.ErrorDetallado & vbNewLine
                Else
                    MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                End If
            End If

        Catch e As TimeoutException
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & "Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas" & vbNewLine
                bolObtuvoCred = False
            Else
                frmDatosClienteFacturacion.Cursor = Cursors.Default
                MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
                bolObtuvoCred = False
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & "ERROR: No Hay conexión con el PAC FEL-Factura en Línea , Intentar más tarde " & vbNewLine
                'texto = texto & "Error Detallado: " & ex.Message & vbNewLine
                bolObtuvoCred = False
            Else
                frmDatosClienteFacturacion.Cursor = Cursors.Default
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
                bolObtuvoCred = False
            End If
        Finally
            obtenerNoCreditos = creditos
            bolObtuvoCred = True
        End Try
    End Function

    Public Sub enviarEmail(ByVal Datos As DataTable, ByVal correos As String)
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim RespuestaServicio As Object
        Dim UUIDEnviar As String = ""
        Dim mensaje As String = ""

        If strAreaServicioTimbrado = "PRUEBAS" Then
            datosUsuario = New FelTest.Credenciales
        Else
            datosUsuario = New FelProd.Credenciales
        End If

        If strCuentaServicioTimbrado <> "" Then
            datosUsuario.Cuenta = strCuentaServicioTimbrado
        End If
        If strContrasenaServicioTimbrado <> "" Then
            datosUsuario.Password = strContrasenaServicioTimbrado
        End If
        If strUsuarioServicioTimbrado <> "" Then
            datosUsuario.Usuario = strUsuarioServicioTimbrado
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            ConexionRemota33 = New FelTest.ConexionRemotaClient
        Else
            ConexionRemota33 = New FelProd.ConexionRemotaClient
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            RespuestaServicio = New FelTest.RespuestaOperacionCR
        Else
            RespuestaServicio = New FelProd.RespuestaOperacionCR
        End If

        Try
            mensaje = "Envio Comprobante CFDI"

            For Each dr As DataRow In Datos.Rows
                UUIDEnviar = ""
                UUIDEnviar = dr("FolioFiscal")
                If dr("Estatus") = "A" Then
                    mensaje = "Envio Comprobante CFDI"
                Else
                    mensaje = "Envio Comprobante de Cancelacion"
                End If
                RespuestaServicio = ConexionRemota33.EnviarCFDI(datosUsuario, UUIDEnviar, correos, mensaje, mensaje, "")
            Next

            If RespuestaServicio.OperacionExitosa = True Then
                MessageBox.Show("Correo enviado.", "Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
            End If
        Catch e As TimeoutException
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
        Catch ex As Exception
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Public Sub obtenerPDF(ByVal Datos As DataTable)
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim RespuestaServicio As Object
        Dim fecha As Date
        Dim claveCFDI As String

        FactTimbrada = False

        If strAreaServicioTimbrado = "PRUEBAS" Then
            datosUsuario = New FelTest.Credenciales
        Else
            datosUsuario = New FelProd.Credenciales
        End If

        If strCuentaServicioTimbrado <> "" Then
            datosUsuario.Cuenta = strCuentaServicioTimbrado
        End If
        If strContrasenaServicioTimbrado <> "" Then
            datosUsuario.Password = strContrasenaServicioTimbrado
        End If
        If strUsuarioServicioTimbrado <> "" Then
            datosUsuario.Usuario = strUsuarioServicioTimbrado
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            ConexionRemota33 = New FelTest.ConexionRemotaClient
        Else
            ConexionRemota33 = New FelProd.ConexionRemotaClient
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            RespuestaServicio = New FelTest.RespuestaOperacionCR
        Else
            RespuestaServicio = New FelProd.RespuestaOperacionCR
        End If

        Try
            For Each dr As DataRow In Datos.Rows
                claveCFDI = ""
                fecha = CDate(Mid(dr("FechaFactura"), 7, 2) & "/" & Mid(dr("FechaFactura"), 5, 2) & "/" & Mid(dr("FechaFactura"), 1, 4))
                If dr("TipoFactura") = "INDIVIDUAL" Or dr("TipoFactura") = "GLOBAL" Then
                    claveCFDI = "FAC"
                Else
                    claveCFDI = "CRE"
                End If

                RespuestaServicio = ConexionRemota33.ObtenerPDF(datosUsuario, dr("FolioFiscal"), "")
                If RespuestaServicio.OperacionExitosa = True Then


                    Dim strCarpetaFacturas As String = VerificaCarpetaFacturacion(intNoSucursal, fecha)
                    strNombreArchivoPDF = Format(intNoSucursal, "000") & "_" & Format(fecha, "yyyyMMdd") & "_" & claveCFDI & "_" & Format(dr("Folio"), "000000") & "_" & dr("Serie") & "_" & dr("RFC") & ".PDF"

                    Dim oDatosPDF() As Byte = Convert.FromBase64String(RespuestaServicio.PDF)
                    Dim ms As MemoryStream = New MemoryStream
                    ms.Write(oDatosPDF, 0, oDatosPDF.Length)
                    My.Computer.FileSystem.WriteAllBytes(strCarpetaFacturas & "\" & strNombreArchivoPDF, oDatosPDF, False)

                    ms.Dispose()

                    MsgBox("PDF obtenido con éxito!", MsgBoxStyle.Exclamation, "Facturación")
                Else
                    If strmodoFactura = "AUTOMATICA" Then
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error General: " & RespuestaServicio.ErrorGeneral & "Error Detallado: " & RespuestaServicio.ErrorDetallado & vbNewLine
                        My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                        FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                        nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                        EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                        End
                    Else
                        MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                    End If
                End If
            Next

        Catch e As TimeoutException
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "ERROR AL OBTENER PDF: Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas" & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                'End
            Else
                MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "ERROR: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                frmDatosClienteFacturacion.Cursor = Cursors.Default
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If

        End Try
    End Sub

    Public Sub obtenerAcusePDF(ByVal Datos As DataTable)
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim fecha As Date
        Dim claveCFDI As String
        Dim oRespuestaPDF As Object

        datosUsuario = New FelProd.Credenciales
        datosUsuario.Cuenta = strCuentaServicioTimbrado
        datosUsuario.Usuario = strUsuarioServicioTimbrado
        datosUsuario.Password = strContrasenaServicioTimbrado
        ConexionRemota33 = New FelProd.ConexionRemotaClient
        oRespuestaPDF = New FelProd.RespuestaCancelacionCR

        Try
            For Each dr As DataRow In Datos.Rows
                claveCFDI = ""
                fecha = CDate(Mid(dr("FechaFactura"), 7, 2) & "/" & Mid(dr("FechaFactura"), 5, 2) & "/" & Mid(dr("FechaFactura"), 1, 4))
                If dr("TipoFactura") = "INDIVIDUAL" Or dr("TipoFactura") = "GLOBAL" Then
                    claveCFDI = "FAC"
                Else
                    claveCFDI = "CRE"
                End If

                oRespuestaPDF = ConexionRemota33.ObtenerPDF(datosUsuario, dr("FolioFiscal"), "")
                If oRespuestaPDF.OperacionExitosa = True Then

                    Dim strCarpetaFacturas As String = VerificaCarpetaFacturacion(intNoSucursal, fecha)
                    strNombreArchivoPDF = Format(intNoSucursal, "000") & "_" & Format(fecha, "yyyyMMdd") & "_" & claveCFDI & "_" & Format(dr("Folio"), "000000") & "_" & dr("Serie") & "_" & dr("RFC") & "_CANCELADA" & ".PDF"

                    Dim oDatosPDF() As Byte = Convert.FromBase64String(oRespuestaPDF.PDF)
                    Dim ms As MemoryStream = New MemoryStream
                    ms.Write(oDatosPDF, 0, oDatosPDF.Length)
                    My.Computer.FileSystem.WriteAllBytes(strCarpetaFacturas & "\" & strNombreArchivoPDF, oDatosPDF, False)

                    ms.Dispose()

                    MsgBox("PDF del Acuse de Cancelación obtenido con éxito!", MsgBoxStyle.Exclamation, "Facturación")
                Else
                    MsgBox("Error General: " & vbCrLf & vbCrLf & oRespuestaPDF.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & oRespuestaPDF.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                End If
            Next
        Catch e As TimeoutException
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
        Catch ex As Exception
            frmDatosClienteFacturacion.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub ConsultaFactura(ByVal Datos As DataTable)
        Dim RespuestaAcuse As String = ""
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim fecha As Date
        Dim claveCFDI As String
        Dim RespuestaServicio As Object

        conAcuse = False
        datosUsuario = New FelTest.Credenciales
        datosUsuario.Cuenta = strCuentaServicioTimbrado
        datosUsuario.Usuario = strUsuarioServicioTimbrado
        datosUsuario.Password = strContrasenaServicioTimbrado
        ConexionRemota33 = New FelTest.ConexionRemotaClient
        RespuestaServicio = New FelTest.RespuestaCancelacionCR

        Try
            For Each dr As DataRow In Datos.Rows
                claveCFDI = ""
                fecha = CDate(Mid(dr("FechaFactura"), 7, 2) & "/" & Mid(dr("FechaFactura"), 5, 2) & "/" & Mid(dr("FechaFactura"), 1, 4))
                If dr("TipoFactura") = "INDIVIDUAL" Or dr("TipoFactura") = "GLOBAL" Then
                    claveCFDI = "FAC"
                Else
                    claveCFDI = "CRE"
                End If

                RespuestaServicio = ConexionRemota33.ObtenerAcuseEnvio(datosUsuario, dr("FolioFiscal"))

                If RespuestaServicio.OperacionExitosa = True Then

                    Dim strCarpetaFacturas As String = VerificaCarpetaFacturacion(intNoSucursal, fecha)
                    strNombreArchivoXML = Format(intNoSucursal, "000") & "_" & Format(fecha, "yyyyMMdd") & "_" & claveCFDI & "_" & Format(dr("Folio"), "000000") & "_" & dr("Serie") & "_" & dr("RFC") & "_CANCELADA" & ".XML"

                    If RespuestaServicio.XML IsNot Nothing Then
                        RespuestaAcuse = RespuestaServicio.XML
                        GuardaXML(strCarpetaFacturas & "\" & strNombreArchivoXML, RespuestaAcuse)
                        conAcuse = True
                    End If

                    MsgBox("XML del Acuse de Cancelación obtenido con éxito!", MsgBoxStyle.Exclamation, "Facturación")
                Else
                    MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                End If
            Next
        Catch e As TimeoutException
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
        Catch ex As Exception
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try
    End Sub
    Public Sub obtenerAcuseXML(ByVal Datos As DataTable)
        Dim RespuestaAcuse As String = ""
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim fecha As Date
        Dim claveCFDI As String
        Dim RespuestaServicio As Object

        conAcuse = False
        datosUsuario = New FelProd.Credenciales
        datosUsuario.Cuenta = strCuentaServicioTimbrado
        datosUsuario.Usuario = strUsuarioServicioTimbrado
        datosUsuario.Password = strContrasenaServicioTimbrado
        ConexionRemota33 = New FelProd.ConexionRemotaClient
        RespuestaServicio = New FelProd.RespuestaCancelacionCR

        Try
            For Each dr As DataRow In Datos.Rows
                claveCFDI = ""
                fecha = CDate(Mid(dr("FechaFactura"), 7, 2) & "/" & Mid(dr("FechaFactura"), 5, 2) & "/" & Mid(dr("FechaFactura"), 1, 4))
                If dr("TipoFactura") = "INDIVIDUAL" Or dr("TipoFactura") = "GLOBAL" Then
                    claveCFDI = "FAC"
                Else
                    claveCFDI = "CRE"
                End If

                RespuestaServicio = ConexionRemota33.ObtenerAcuseCancelacion(datosUsuario, dr("FolioFiscal"))

                If RespuestaServicio.OperacionExitosa = True Then

                    Dim strCarpetaFacturas As String = VerificaCarpetaFacturacion(intNoSucursal, fecha)
                    strNombreArchivoXML = Format(intNoSucursal, "000") & "_" & Format(fecha, "yyyyMMdd") & "_" & claveCFDI & "_" & Format(dr("Folio"), "000000") & "_" & dr("Serie") & "_" & dr("RFC") & "_CANCELADA" & ".XML"

                    If RespuestaServicio.XML IsNot Nothing Then
                        RespuestaAcuse = RespuestaServicio.XML
                        GuardaXML(strCarpetaFacturas & "\" & strNombreArchivoXML, RespuestaAcuse)
                        conAcuse = True
                    End If

                    MsgBox("XML del Acuse de Cancelación obtenido con éxito!", MsgBoxStyle.Exclamation, "Facturación")
                Else
                    MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                End If
            Next
        Catch e As TimeoutException
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
        Catch ex As Exception
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try
    End Sub
    Public Sub obtenerXMLFolio(ByVal Datos As DataTable)
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim RespuestaServicio As Object
        Dim fecha As Date
        Dim claveCFDI As String = ""
        Dim RespuestaoXML As String = ""

        If strAreaServicioTimbrado = "PRUEBAS" Then
            datosUsuario = New FelTest.Credenciales
        Else
            datosUsuario = New FelProd.Credenciales
        End If

        If strCuentaServicioTimbrado <> "" Then
            datosUsuario.Cuenta = strCuentaServicioTimbrado
        End If
        If strContrasenaServicioTimbrado <> "" Then
            datosUsuario.Password = strContrasenaServicioTimbrado
        End If
        If strUsuarioServicioTimbrado <> "" Then
            datosUsuario.Usuario = strUsuarioServicioTimbrado
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            ConexionRemota33 = New FelTest.ConexionRemotaClient
        Else
            ConexionRemota33 = New FelProd.ConexionRemotaClient
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            RespuestaServicio = New FelTest.RespuestaOperacionCR
        Else
            RespuestaServicio = New FelProd.RespuestaOperacionCR
        End If

        Try
            For Each dr As DataRow In Datos.Rows
                claveCFDI = ""
                fecha = CDate(Mid(dr("FechaFactura"), 7, 2) & "/" & Mid(dr("FechaFactura"), 5, 2) & "/" & Mid(dr("FechaFactura"), 1, 4))
                If dr("TipoFactura") = "INDIVIDUAL" Or dr("TipoFactura") = "GLOBAL" Then
                    claveCFDI = "FAC"
                Else
                    claveCFDI = "CRE"
                End If

                'SE VALIDA CONCATENANDO LA SERIE Y EL FOLIO (YA QUE ASI ESTA TIMBRADA EN FEL)
                RespuestaServicio = ConexionRemota33.ObtenerXMLPorReferencia(datosUsuario, dr("Serie") & dr("Folio"))

                If RespuestaServicio.OperacionExitosa = True Then

                    If RespuestaServicio.XML IsNot Nothing Then
                        RespuestaoXML = RespuestaServicio.XML
                        'GuardaXML(strCarpetaFacturas & "\" & strNombreArchivoXML, RespuestaoXML)
                    End If

                    strUUID = GetXML(RespuestaoXML, "<tfd:TimbreFiscalDigital", "UUID", Chr(34))
                    strFechaTimbrado = GetXML(RespuestaoXML, "<tfd:TimbreFiscalDigital", "FechaTimbrado", Chr(34))

                    If Comprobando = "SI" Then
                        FactTimbrada = True
                        Comprobando = ""
                        Exit Sub
                    End If

                Else
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error General PE01202: " & vbNewLine & RespuestaServicio.ErrorGeneral & vbNewLine & "Error Detallado: " & vbNewLine & RespuestaServicio.ErrorDetallado & vbNewLine
                    'MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                End If
            Next

        Catch e As TimeoutException
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
        Catch ex As Exception
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try
    End Sub
    Public Sub obtenerXML(ByVal Datos As DataTable)
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim RespuestaServicio As Object
        Dim fecha As Date
        Dim claveCFDI As String = ""
        Dim RespuestaoXML As String = ""

        If strAreaServicioTimbrado = "PRUEBAS" Then
            datosUsuario = New FelTest.Credenciales
        Else
            datosUsuario = New FelProd.Credenciales
        End If

        If strCuentaServicioTimbrado <> "" Then
            datosUsuario.Cuenta = strCuentaServicioTimbrado
        End If
        If strContrasenaServicioTimbrado <> "" Then
            datosUsuario.Password = strContrasenaServicioTimbrado
        End If
        If strUsuarioServicioTimbrado <> "" Then
            datosUsuario.Usuario = strUsuarioServicioTimbrado
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            ConexionRemota33 = New FelTest.ConexionRemotaClient
        Else
            ConexionRemota33 = New FelProd.ConexionRemotaClient
        End If

        If strAreaServicioTimbrado = "PRUEBAS" Then
            RespuestaServicio = New FelTest.RespuestaOperacionCR
        Else
            RespuestaServicio = New FelProd.RespuestaOperacionCR
        End If

        Try
            For Each dr As DataRow In Datos.Rows
                claveCFDI = ""
                fecha = CDate(Mid(dr("FechaFactura"), 7, 2) & "/" & Mid(dr("FechaFactura"), 5, 2) & "/" & Mid(dr("FechaFactura"), 1, 4))
                If dr("TipoFactura") = "INDIVIDUAL" Or dr("TipoFactura") = "GLOBAL" Then
                    claveCFDI = "FAC"
                Else
                    claveCFDI = "CRE"
                End If

                RespuestaServicio = ConexionRemota33.ObtenerXMLPorUUID(datosUsuario, dr("FolioFiscal"))

                If RespuestaServicio.OperacionExitosa = True Then

                    Dim strCarpetaFacturas As String = VerificaCarpetaFacturacion(intNoSucursal, fecha)
                    strNombreArchivoXML = Format(intNoSucursal, "000") & "_" & Format(fecha, "yyyyMMdd") & "_" & claveCFDI & "_" & Format(dr("Folio"), "000000") & "_" & dr("Serie") & "_" & dr("RFC") & ".XML"

                    If RespuestaServicio.XML IsNot Nothing Then
                        RespuestaoXML = RespuestaServicio.XML
                        GuardaXML(strCarpetaFacturas & "\" & strNombreArchivoXML, RespuestaoXML)
                    End If

                    MsgBox("XML obtenido con éxito!", MsgBoxStyle.Exclamation, "Facturación")
                Else
                    If strmodoFactura = "AUTOMATICA" Then
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error General: " & RespuestaServicio.ErrorGeneral & "Error Detallado: " & RespuestaServicio.ErrorDetallado & vbNewLine
                        My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                        FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                        nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                        EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                        'End
                    Else
                        MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                    End If
                    'MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                End If
            Next

        Catch e As TimeoutException
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
        Catch ex As Exception
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try
    End Sub

    Private Sub LeeConfig()
        Dim sr As StreamReader
        Dim sLinea As String = ""
        Try
            If Not File.Exists("C:\CONFIG\CONFIG-SPEXPRESS.TXT") Then
                MsgBox("No se encuentra el archivo CONFIG, por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturación")
                End
            End If

            sr = New StreamReader("C:\CONFIG\CONFIG-SPEXPRESS.TXT", True)
            sRuta = sr.ReadLine
            sRuta = Replace(sRuta, """", "")
            sLinea = sr.ReadLine
            sLinea = sr.ReadLine
            sLinea = sr.ReadLine
            sLinea = sr.ReadLine
            sLinea = sr.ReadLine
            sLinea = sr.ReadLine    'instancia
            strServerEmpeno = sLinea.Replace(Chr(34), "")
            sLinea = sr.ReadLine.Replace(Chr(34), "")    'USR
            strUsrEmpeno = sLinea
            sLinea = sr.ReadLine.Replace(Chr(34), "")    'PWD
            'strPwd = Encripta(sLinea.Replace(Chr(34), ""), "D")
            sLinea = sr.ReadLine    'BD
            strBDEmpeno = sLinea.Replace(Chr(34), "")

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error al leer el archivo CONFIG, por favor avise a sistemas!" & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error al leer el archivo CONFIG, por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturación")
                End
            End If

        End Try
    End Sub

    Public Sub ConectaBD()
        Dim sSQL As String = ""
        Dim dtPaso As New DataTable
        Try
            If strServerEmpeno.Trim <> "" Then
                'se establecen los parametros de conexión a la sucursal y se inicializa
                SQLServer.Init(, strBDEmpeno, strServerEmpeno, "sa", "masterkey")
                Try
                    'se ejecuta una consulta para probar la conexión
                    SQLServer.ExecSQL("USE BDSPEXPRESS")
                Catch ex As Exception
                    Try
                        'se prueba con otra contraseña
                        SQLServer.Init(, strBDEmpeno, strServerEmpeno, "sa", "M@st3rkey")
                        'se ejecuta una consulta para probar la conexión
                        SQLServer.ExecSQL("USE BDSPEXPRESS")
                    Catch ex1 As Exception
                        'al pasar por aqui, de plano no se puede conectar al servidor de la sucursal
                        MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
                        End
                    End Try
                End Try

                'obteniendo el numero de la sucursal
                sSQL = "SELECT TOP 1 * FROM BDSPEXPRESS.dbo.BPFCatalogoSucursales"
                dtPaso = SQLServer.ExecSQLReturnDT(sSQL)
                If Not dtPaso Is Nothing AndAlso dtPaso.Rows.Count > 0 Then
                    intNoSucursal = dtPaso.Rows(0).Item("NoSucursal")
                    strNombreSuc = dtPaso.Rows(0).Item("Sucursal")
                End If
            Else
                End
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "ERROR: Al intentar conectar al servidor!" & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error al intentar conectar al servidor, por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturación")
                End
            End If
        End Try

    End Sub

    Public Function AgrupaTickets() As DataTable
        Dim drNueva As DataRow
        Dim Fecha As Integer = 0
        Dim Tipo As String = ""
        Dim Prefijo As String = ""
        Dim NoTicket As String = ""
        Dim Caso As String = ""
        Dim Agrupa As String = ""
        Dim dblImporte As Double = 0
        Dim dblCosto As Double = 0
        Dim dblDescuento As Double = 0
        Dim dblTotal As Double = 0
        Dim dblImpPagado As Double = 0
        Dim dblInteres As Double = 0
        Dim dblRecargo As Double = 0
        Dim dblIVA As Double = 0
        Dim TipoMovi As String = ""
        Dim seAgrupa, YaEnAgrupaDetalle As Boolean
        'Variables Para decimales
        Dim ValorDecimal As Double = 0
        Dim ValorEntero As Long = 0

        dtAgrupaDetalle.Clear()
        dtAgrupaDetalle = dtDetalle.Clone

        Try
            For j = 0 To dtDetalle.Rows.Count - 1
                Fecha = dtDetalle.Rows(j).Item("Fecha")
                Tipo = dtDetalle.Rows(j).Item("Tipo").ToString
                Prefijo = dtDetalle.Rows(j).Item("Prefijo").ToString
                NoTicket = dtDetalle.Rows(j).Item("NoTicket").ToString
                Caso = dtDetalle.Rows(j).Item("TipoMov").ToString
                Agrupa = dtDetalle.Rows(j).Item("Agrupa").ToString
                dblImporte = 0
                dblCosto = 0
                dblDescuento = 0
                dblTotal = 0
                dblImpPagado = 0
                dblInteres = 0
                dblRecargo = 0
                dblIVA = 0
                TipoMovi = ""
                YaEnAgrupaDetalle = False
                For i = 0 To dtDetalle.Rows.Count - 1
                    If (Fecha = dtDetalle.Rows(i).Item("Fecha").ToString And Tipo = dtDetalle.Rows(i).Item("Tipo").ToString And Prefijo = dtDetalle.Rows(i).Item("Prefijo").ToString And NoTicket = dtDetalle.Rows(i).Item("NoTicket").ToString And Agrupa = dtDetalle.Rows(i).Item("Agrupa").ToString) Then
                        'If Tipo = "CF" And dtDetalle.Rows(i).Item("Caso").ToString <> "CASO 08" And Caso <> "10400" Then
                        seAgrupa = True
                        dblImporte += CDbl(dtDetalle.Rows(i).Item("Importe").ToString)
                        'Negativo
                        If Format(dtDetalle.Rows(i).Item("Importe"), "#0.000000").ToString < "0.000000" Then
                            dblImporte += CDbl(dtDetalle.Rows(i).Item("IVA").ToString)
                        End If
                        '--------
                        dblCosto += CDbl(dtDetalle.Rows(i).Item("Costo").ToString)
                        dblDescuento += CDbl(dtDetalle.Rows(i).Item("Descuento").ToString)
                        dblTotal += CDbl(dtDetalle.Rows(i).Item("Total").ToString)
                        dblImpPagado += CDbl(dtDetalle.Rows(i).Item("ImportePagado").ToString)
                        dblInteres += CDbl(dtDetalle.Rows(i).Item("Interes").ToString)
                        dblRecargo += CDbl(dtDetalle.Rows(i).Item("Recargo").ToString)
                        dblIVA += CDbl(dtDetalle.Rows(i).Item("IVA").ToString)
                        TipoMovi = dtDetalle.Rows(i).Item("TipoMov").ToString
                        'Else
                        'If Tipo = "CF" And dtDetalle.Rows(i).Item("Caso").ToString = "CASO 08" And Caso = "10400" Then
                        '    seAgrupa = True
                        '    dblImporte += CDbl(dtDetalle.Rows(i).Item("Importe").ToString)
                        '    'Negativo
                        '    If Format(dtDetalle.Rows(i).Item("Importe"), "#0.000000").ToString < "0.000000" Then
                        '        dblImporte += CDbl(dtDetalle.Rows(i).Item("IVA").ToString)
                        '    End If
                        '    '--------
                        '    dblCosto += CDbl(dtDetalle.Rows(i).Item("Costo").ToString)
                        '    dblDescuento += CDbl(dtDetalle.Rows(i).Item("Descuento").ToString)
                        '    dblTotal += CDbl(dtDetalle.Rows(i).Item("Total").ToString)
                        '    dblImpPagado += CDbl(dtDetalle.Rows(i).Item("ImportePagado").ToString)
                        '    dblInteres += CDbl(dtDetalle.Rows(i).Item("Interes").ToString)
                        '    dblRecargo += CDbl(dtDetalle.Rows(i).Item("Recargo").ToString)
                        '    dblIVA += CDbl(dtDetalle.Rows(i).Item("IVA").ToString)
                        '    TipoMovi = dtDetalle.Rows(i).Item("TipoMov").ToString
                        'ElseIf Tipo <> "CF" Then
                        '    seAgrupa = True
                        '    dblImporte += CDbl(dtDetalle.Rows(i).Item("Importe").ToString)
                        '    'Negativo
                        '    If Format(dtDetalle.Rows(i).Item("Importe"), "#0.000000").ToString < "0.000000" Then
                        '        dblImporte += CDbl(dtDetalle.Rows(i).Item("IVA").ToString)
                        '    End If
                        '    '--------
                        '    dblCosto += CDbl(dtDetalle.Rows(i).Item("Costo").ToString)
                        '    dblDescuento += CDbl(dtDetalle.Rows(i).Item("Descuento").ToString)
                        '    dblTotal += CDbl(dtDetalle.Rows(i).Item("Total").ToString)
                        '    dblImpPagado += CDbl(dtDetalle.Rows(i).Item("ImportePagado").ToString)
                        '    dblInteres += CDbl(dtDetalle.Rows(i).Item("Interes").ToString)
                        '    dblRecargo += CDbl(dtDetalle.Rows(i).Item("Recargo").ToString)
                        '    dblIVA += CDbl(dtDetalle.Rows(i).Item("IVA").ToString)
                        '    TipoMovi = dtDetalle.Rows(i).Item("TipoMov").ToString
                        'End If
                        'End If
                    End If
                Next
                If seAgrupa = True Then
                    If dtAgrupaDetalle.Rows.Count = 0 Then
                        drNueva = dtAgrupaDetalle.NewRow
                        drNueva("Concepto") = dtDetalle.Rows(j).Item("Concepto").ToString
                        drNueva("Fecha") = dtDetalle.Rows(j).Item("Fecha").ToString
                        drNueva("Tipo") = dtDetalle.Rows(j).Item("Tipo").ToString
                        drNueva("Prefijo") = dtDetalle.Rows(j).Item("Prefijo").ToString
                        drNueva("NoTicket") = dtDetalle.Rows(j).Item("NoTicket").ToString
                        drNueva("TipoMov") = dtDetalle.Rows(j).Item("TipoMov").ToString
                        drNueva("Importe") = CStr(dblImporte)
                        drNueva("Costo") = CStr(dblCosto)
                        drNueva("Descuento") = CStr(dblDescuento)
                        drNueva("Total") = CStr(dblTotal)
                        drNueva("ImportePagado") = CStr(dblImpPagado)
                        drNueva("Interes") = CStr(dblInteres)
                        drNueva("Recargo") = CStr(dblRecargo)
                        drNueva("IVA") = CStr(dblIVA)
                        drNueva("FormaPagoSAT") = dtDetalle.Rows(j).Item("FormaPagoSAT").ToString
                        drNueva("ClaveSAT") = dtDetalle.Rows(j).Item("ClaveSAT").ToString
                        drNueva("DescripcionSAT") = dtDetalle.Rows(j).Item("DescripcionSAT").ToString
                        If Sistema <> "GLOBAL" Then
                            drNueva("UUIDFacturaGlobal") = dtDetalle.Rows(j).Item("UUIDFacturaGlobal").ToString
                            drNueva("TipoFactura") = dtDetalle.Rows(j).Item("TipoFactura").ToString
                            drNueva("Estatus") = dtDetalle.Rows(j).Item("Estatus").ToString
                        End If
                        drNueva("Agrupa") = dtDetalle.Rows(j).Item("Agrupa").ToString
                        dtAgrupaDetalle.Rows.Add(drNueva)
                        dtAgrupaDetalle.AcceptChanges()
                        seAgrupa = False
                    Else
                        For Each dr As DataRow In dtAgrupaDetalle.Rows
                            If (Fecha = dr("Fecha").ToString And Tipo = dr("Tipo").ToString And Prefijo = dr("Prefijo").ToString And NoTicket = dr("NoTicket").ToString And Agrupa = dr("Agrupa").ToString) Then
                                'If Tipo = "CF" And Caso = "112" Then
                                dr("TipoMov") = TipoMovi
                                dr("Importe") = dblImporte
                                dr("Costo") = dblCosto
                                dr("Descuento") = dblDescuento
                                dr("Total") = dblTotal
                                dr("ImportePagado") = dblImpPagado
                                dr("Interes") = dblInteres
                                dr("Recargo") = dblRecargo
                                dr("IVA") = dblIVA
                                dtAgrupaDetalle.AcceptChanges()
                                YaEnAgrupaDetalle = True
                                'ElseIf Tipo = "CF" And Caso = "10400" Then

                                'ElseIf Tipo <> "CF" Then
                                '    dr("TipoMov") = TipoMovi
                                '    dr("Importe") = dblImporte
                                '    dr("Costo") = dblCosto
                                '    dr("Descuento") = dblDescuento
                                '    dr("Total") = dblTotal
                                '    dr("ImportePagado") = dblImpPagado
                                '    dr("Interes") = dblInteres
                                '    dr("Recargo") = dblRecargo
                                '    dr("IVA") = dblIVA
                                '    dtAgrupaDetalle.AcceptChanges()
                                '    YaEnAgrupaDetalle = True
                                'End If
                            End If
                        Next dr
                        If YaEnAgrupaDetalle = False Then
                            drNueva = dtAgrupaDetalle.NewRow
                            drNueva("Concepto") = dtDetalle.Rows(j).Item("Concepto").ToString
                            drNueva("Fecha") = dtDetalle.Rows(j).Item("Fecha").ToString
                            drNueva("Tipo") = dtDetalle.Rows(j).Item("Tipo").ToString
                            drNueva("Prefijo") = dtDetalle.Rows(j).Item("Prefijo").ToString
                            drNueva("NoTicket") = dtDetalle.Rows(j).Item("NoTicket").ToString
                            drNueva("TipoMov") = dtDetalle.Rows(j).Item("TipoMov").ToString
                            drNueva("Importe") = CStr(dblImporte)
                            drNueva("Costo") = CStr(dblCosto)
                            drNueva("Descuento") = CStr(dblDescuento)
                            drNueva("Total") = CStr(dblTotal)
                            drNueva("ImportePagado") = CStr(dblImpPagado)
                            drNueva("Interes") = CStr(dblInteres)
                            drNueva("Recargo") = CStr(dblRecargo)
                            drNueva("IVA") = CStr(dblIVA)
                            drNueva("FormaPagoSAT") = dtDetalle.Rows(j).Item("FormaPagoSAT").ToString
                            drNueva("ClaveSAT") = dtDetalle.Rows(j).Item("ClaveSAT").ToString
                            drNueva("DescripcionSAT") = dtDetalle.Rows(j).Item("DescripcionSAT").ToString
                            If Sistema <> "GLOBAL" Then
                                drNueva("UUIDFacturaGlobal") = dtDetalle.Rows(j).Item("UUIDFacturaGlobal").ToString
                                drNueva("TipoFactura") = dtDetalle.Rows(j).Item("TipoFactura").ToString
                                drNueva("Estatus") = dtDetalle.Rows(j).Item("Estatus").ToString
                            End If
                            drNueva("Agrupa") = dtDetalle.Rows(j).Item("Agrupa").ToString
                            dtAgrupaDetalle.Rows.Add(drNueva)
                            dtAgrupaDetalle.AcceptChanges()
                        End If
                    End If
                Else
                    drNueva = dtAgrupaDetalle.NewRow
                    drNueva("Concepto") = dtDetalle.Rows(j).Item("Concepto").ToString
                    drNueva("Fecha") = dtDetalle.Rows(j).Item("Fecha").ToString
                    drNueva("Tipo") = dtDetalle.Rows(j).Item("Tipo").ToString
                    drNueva("Prefijo") = dtDetalle.Rows(j).Item("Prefijo").ToString
                    drNueva("NoTicket") = dtDetalle.Rows(j).Item("NoTicket").ToString
                    drNueva("TipoMov") = dtDetalle.Rows(j).Item("TipoMov").ToString
                    drNueva("Importe") = dtDetalle.Rows(j).Item("Importe").ToString
                    drNueva("Costo") = dtDetalle.Rows(j).Item("Costo").ToString
                    drNueva("Descuento") = dtDetalle.Rows(j).Item("Descuento").ToString
                    drNueva("Total") = dtDetalle.Rows(j).Item("Total").ToString
                    drNueva("ImportePagado") = dtDetalle.Rows(j).Item("ImportePagado").ToString
                    drNueva("Interes") = dtDetalle.Rows(j).Item("Interes").ToString
                    drNueva("Recargo") = dtDetalle.Rows(j).Item("Recargo").ToString
                    drNueva("IVA") = dtDetalle.Rows(j).Item("IVA").ToString
                    drNueva("FormaPagoSAT") = dtDetalle.Rows(j).Item("FormaPagoSAT").ToString
                    drNueva("ClaveSAT") = dtDetalle.Rows(j).Item("ClaveSAT").ToString
                    drNueva("DescripcionSAT") = dtDetalle.Rows(j).Item("DescripcionSAT").ToString
                    If Sistema <> "GLOBAL" Then
                        drNueva("UUIDFacturaGlobal") = dtDetalle.Rows(j).Item("UUIDFacturaGlobal").ToString
                        drNueva("TipoFactura") = dtDetalle.Rows(j).Item("TipoFactura").ToString
                        drNueva("Estatus") = dtDetalle.Rows(j).Item("Estatus").ToString
                    End If
                    drNueva("Agrupa") = dtDetalle.Rows(j).Item("Agrupa").ToString
                    dtAgrupaDetalle.Rows.Add(drNueva)
                    dtAgrupaDetalle.AcceptChanges()
                End If

            Next
            For Each dr As DataRow In dtAgrupaDetalle.Rows
                If dr("Costo") > 0 Then
                    'Codigo Nuevo 20/10/2020
                    '------------------------------------
                    If dr("Tipo") = "PF" Then

                        ValorEntero = Int(CDbl(dr("ImportePagado")) + CDbl(dr("Costo")))
                        ValorDecimal = (CDbl(dr("ImportePagado")) + CDbl(dr("Costo"))) - ValorEntero
                        ValorDecimal = 1 - ValorDecimal
                        '------------------------------------
                        dr("ImportePagado") = (CDbl(dr("ImportePagado")) + CDbl(dr("Costo"))) + ValorDecimal
                        dr("Costo") = CDbl(dr("Costo")) + ValorDecimal
                    Else

                        dr("ImportePagado") = (CDbl(dr("ImportePagado")) + CDbl(dr("Costo"))) 'Linea Original
                    End If
                    '------------------------------------
                End If
            Next dr
        Catch ex As Exception
            'MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            AgrupaTickets = dtAgrupaDetalle
        End Try
    End Function

    Public Function AnexaCamposFac() As DataTable
        Dim drNueva As DataRow
        dtAgrupaDetalle.Clear()
        dtAgrupaDetalle = dtDetalle.Clone
        Try
            For j = 0 To dtDetalle.Rows.Count - 1
                drNueva = dtAgrupaDetalle.NewRow
                drNueva("Concepto") = dtDetalle.Rows(j).Item("Concepto").ToString
                drNueva("Fecha") = dtDetalle.Rows(j).Item("Fecha").ToString
                drNueva("Tipo") = dtDetalle.Rows(j).Item("Tipo").ToString
                drNueva("Prefijo") = dtDetalle.Rows(j).Item("Prefijo").ToString
                drNueva("NoTicket") = dtDetalle.Rows(j).Item("NoTicket").ToString
                drNueva("TipoMov") = dtDetalle.Rows(j).Item("TipoMov").ToString
                drNueva("Importe") = dtDetalle.Rows(j).Item("Importe").ToString
                drNueva("Costo") = dtDetalle.Rows(j).Item("Costo").ToString
                drNueva("Descuento") = dtDetalle.Rows(j).Item("Descuento").ToString
                drNueva("Total") = dtDetalle.Rows(j).Item("Total").ToString
                drNueva("ImportePagado") = dtDetalle.Rows(j).Item("ImportePagado").ToString
                drNueva("Interes") = dtDetalle.Rows(j).Item("Interes").ToString
                drNueva("Recargo") = dtDetalle.Rows(j).Item("Recargo").ToString
                drNueva("IVA") = dtDetalle.Rows(j).Item("IVA").ToString
                drNueva("FormaPagoSAT") = dtDetalle.Rows(j).Item("FormaPagoSAT").ToString
                drNueva("ClaveSAT") = dtDetalle.Rows(j).Item("ClaveSAT").ToString
                drNueva("DescripcionSAT") = dtDetalle.Rows(j).Item("DescripcionSAT").ToString
                If Sistema <> "GLOBAL" Then
                    drNueva("UUIDFacturaGlobal") = dtDetalle.Rows(j).Item("UUIDFacturaGlobal").ToString
                    drNueva("TipoFactura") = dtDetalle.Rows(j).Item("TipoFactura").ToString
                    drNueva("Estatus") = dtDetalle.Rows(j).Item("Estatus").ToString
                End If
                dtAgrupaDetalle.Rows.Add(drNueva)
                dtAgrupaDetalle.AcceptChanges()
            Next

        Catch ex As Exception
            'MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            AnexaCamposFac = dtAgrupaDetalle
        End Try
    End Function

    Public Function SeDevolvio(ByVal dtDetaDev As DataTable, ByVal folio As String) As Boolean
        Dim bolResultado As Boolean = False
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable

        Try
            For Each dr As DataRow In dtDetaDev.Rows
                If LTrim(folio) = dr("FolioOrigen") Then
                    bolResultado = True
                End If
            Next dr
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            SeDevolvio = bolResultado
        End Try
    End Function

    Public Function YaEnFacturaGlobal(ByVal Prefijo As String, ByVal NoTicket As String, ByVal FechaTicket As String) As Boolean

        Dim bolResultado As Boolean = False
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable

        Try
            sSQL = "SELECT TOP 1 b.Serie, b.Folio " & _
                   "FROM BPFFacturasPartidas b " & _
                   "INNER JOIN BPFFacturas a ON a.NoSucursal=b.NoSucursal AND a.Folio=b.Folio AND a.Serie=b.Serie AND a.TipoFactura=b.TipoFactura " & _
                   "WHERE b.TipoTicket='" & Prefijo & "' AND b.NoTicket= " & NoTicket & " AND FechaTicket = '" & FechaTicket & "' AND b.TipoFactura='GLOBAL' and a.Estatus = 'A'" & _
                   "ORDER BY b.Folio DESC"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFFacturasPartidas")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    bolResultado = True
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            YaEnFacturaGlobal = bolResultado
        End Try
    End Function
    Public Function BuscaFacturaGlobalPendiente(ByVal Fecha As String) As Boolean

        Dim bolResultado As Boolean = False
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable

        Try
            sSQL = "SELECT * " & _
                   "FROM BPFFacturas " & _
                   "WHERE FechaFactura = '" & Fecha & "' AND TipoFactura='GLOBAL' AND EstatusFEL = 'P'"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFFacturas")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    bolResultado = True
                    dtFactPend = dtBusca
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            BuscaFacturaGlobalPendiente = bolResultado
        End Try
    End Function
    Public Sub VerificarFacturaGlobalPendiente(ByVal Folio As String)

        Dim bolResultado As Boolean = False
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable

        Try
            sSQL = "SELECT TOP 1 * " & _
                   "FROM BPFFacturas " & _
                   "WHERE FechaFactura = '" & Folio & "' AND TipoFactura='GLOBAL' AND EstatusFEL = 'P'"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFFacturasPartidas")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    bolResultado = True
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub
    Public Sub BorrarFacturaGlobalPendiente(ByVal Folio As String, ByVal Fecha As String)

        Dim bolResultado As Boolean = False
        Dim sSQL As String = ""

        Try
            sSQL = "DELETE " & _
                   "FROM BPFFacturas " & _
                   "WHERE FechaFactura = '" & Fecha & "' AND Folio = '" & Folio & "'"
            SQLServer.ExecSQL(sSQL)

            sSQL = "DELETE " & _
                   "FROM BPFFacturasPartidas " & _
                   "WHERE Folio = '" & Folio & "'"
            SQLServer.ExecSQL(sSQL)

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub
    Public Function YaEnFacturaIndividual(ByVal Prefijo As String, ByVal NoTicket As String) As Boolean
        Dim bolResultado As Boolean = False
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable

        Try
            sSQL = "SELECT TOP 1 b.Serie, b.Folio " & _
                   "FROM BPFFacturasPartidas b " & _
                   "INNER JOIN BPFFacturas a ON a.NoSucursal=b.NoSucursal AND a.Folio=b.Folio AND a.Serie=b.Serie AND a.TipoFactura=b.TipoFactura " & _
                   "WHERE b.TipoTicket = '" & Prefijo & "' AND b.NoTicket = " & NoTicket & " AND b.TipoFactura = 'INDIVIDUAL' AND a.Estatus = 'A'" & _
                   "ORDER BY b.Folio DESC"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BPFFacturasPartidas")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    bolResultado = True
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            YaEnFacturaIndividual = bolResultado
        End Try
    End Function

    Public Function NombreMov(ByVal Tipo As String, ByVal Movimiento As String, ByRef Concepto As String) As String
        Try
            Concepto = "PAGO"
            If Movimiento = 1 Or Movimiento = 111 Then
                Concepto = "PAGO"
            End If
            If Movimiento = 1000 Then
                Concepto = "BOLETA NUEVA"
            End If
            If Movimiento = 2 Then
                If Tipo = "PF" Then
                    Concepto = "PAGO"
                Else
                    Concepto = "CAMBIO DE PLAN PF A TR"
                End If
            End If
            If Movimiento = 2000 Then
                Concepto = "COMISION PRESTA PRESTA"
            End If
            If Movimiento = 3 Then 'Or Movimiento = 11000
                Concepto = "REFRENDO"
            End If
            If Movimiento = 11000 Then
                Concepto = "RECARGO"
            End If
            If Movimiento = 4 Or Movimiento = 12000 Or Movimiento = 104 Or Movimiento = 112 Then
                Concepto = "LIQUIDACION"
            End If
            If Movimiento = 5 Or Movimiento = 13000 Or Movimiento = 10 Then
                Concepto = "ABONO A CAPITAL"
            End If
            If Movimiento = 6 Then
                Concepto = "CAMBIO DE PLAN TR A PF"
            End If
            If Movimiento = 7000 Then
                Concepto = "COMISION REAL POR LIQ. ANTICIPADA"
            End If
            If Movimiento = 14000 Then
                Concepto = "CAMBIATE PAGO FACIL"
            End If
            If Movimiento = 16 Then
                'Concepto = "COMPRA DE DIAS"
                Concepto = "REFRENDO"
            End If
            If Movimiento = 17 Or Movimiento = 18 Or Movimiento = 100 Or Movimiento = 105 Or Movimiento = 4000 Or Movimiento = 6000 Then
                Concepto = "RECUPERACION"
            End If
            If Movimiento = 19 Then
                Concepto = "CAJERO EXPRESS"
            End If
            If Movimiento = 20 Then
                Concepto = "VENTA DE APARATOS"
            End If
            If Movimiento = 21 Then
                Concepto = "VENTA DE JOYERIA"
            End If
            If Movimiento = 122 Then
                Concepto = "EXTENSION DE PLAZO"
            End If
            'COMISION CF
            If Movimiento = 10400 Then
                Concepto = "COMISION CF"
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            NombreMov = Concepto
        End Try
    End Function

    Public Function NombreMovFac(ByVal Tipo As String, ByVal Movimiento As String, ByVal Concepto As String, ByVal Prefijo As String, ByRef NvoConcepto As String) As String
        Try
            If Tipo = "TR" And Movimiento = "LIQUIDACION" And Concepto = "LIQUIDACION" Then
                NvoConcepto = "LIQUIDACION"
            ElseIf Tipo = "TR" And Movimiento = "REFRENDO" And Concepto = "INTERESES" Then
                NvoConcepto = "REFRENDO"
            ElseIf Tipo = "TR" And Movimiento = "COMPRA DE DIAS" And Concepto = "INTERESES" Then
                NvoConcepto = "INTERESES"
            ElseIf Tipo = "TR" And Movimiento = "LIQUIDACION" And Concepto = "INTERESES" Then
                NvoConcepto = "INTERES ORDINARIO"
            ElseIf Tipo = "TR" And Movimiento = "RECARGO" And Concepto = "INTERESES" Then
                NvoConcepto = "INTERES ORDINARIO"
            Else
                NvoConcepto = "INTERES ORDINARIO"
            End If
            If Tipo = "TR" And Movimiento = "RECUPERACION" And Concepto = "INTERESES" Then
                NvoConcepto = "INTERES ORDINARIO"
            End If
            If Tipo = "TR" And Movimiento = "RECUPERACION" And Concepto = "LIQUIDACION" Then
                NvoConcepto = "LIQUIDACION"
            End If
            If Tipo = "TR" And Movimiento = "ABONO A CAPITAL" And Concepto = "INTERESES" Then
                NvoConcepto = "INTERESES"
            End If
            If Tipo = "TR" And Movimiento = "ABONO A CAPITAL" And Concepto = "ABONO A CAPITAL" Then
                NvoConcepto = "ABONO A CAPITAL"
            End If
            If Tipo = "TR" And Movimiento = "ABONO A CAPITAL" And Concepto = "LIQUIDACION" Then
                NvoConcepto = "ABONO A CAPITAL"
            End If
            If Tipo = "PF" And Movimiento = "PAGO" And Concepto = "INTERESES" Then
                'NvoConcepto = "INTERESES"
                NvoConcepto = "INTERES ORDINARIO"
            End If
            If Tipo = "PF" And Movimiento = "PAGO" And Concepto = "LIQUIDACION" Then
                NvoConcepto = "INTERES ORDINARIO"
            End If
            If Tipo = "CE" And Movimiento = "CAJERO EXPRESS" And Concepto = "INTERESES" Then
                NvoConcepto = "COMISIONES"
            End If
            If Tipo = "CE" And Movimiento = "CAJERO EXPRESS" And Concepto = "INTERESES" Then
                NvoConcepto = "COMISIONES"
            End If
            If Tipo = "VT" And Concepto = "INTERESES" And Movimiento = "VENTA DE APARATOS" And Prefijo = "A" Then
                NvoConcepto = "APARATOS AL CONTADO"
            End If
            If Tipo = "VT" And Concepto = "INTERESES" And Movimiento <> "VENTA DE APARATOS" And Prefijo = "A" Then
                NvoConcepto = Movimiento
            End If
            If Tipo = "VT" And Concepto = "APARATOS AL CONTADO" Then
                NvoConcepto = "APARATOS AL CONTADO"
            End If
            If Tipo = "VT" And Concepto = "INTERESES" And Movimiento = "VENTA DE JOYERIA" And Prefijo = "J" Then
                NvoConcepto = "VENTA DE JOYERIA"
            End If
            If Tipo = "VT" And Concepto = "INTERESES" And Movimiento <> "VENTA DE JOYERIA" And Prefijo = "J" Then
                NvoConcepto = Movimiento
            End If
            If Tipo = "VT" And Concepto = "VENTA DE JOYERIA" Then
                NvoConcepto = "VENTA DE JOYERIA"
            End If
            If Tipo = "CF" And Movimiento = "PAGO" And Concepto = "INTERESES" Then
                NvoConcepto = "VENTA DE APARATOS CF"
                'NvoConcepto = "INTERESES"
            End If
            If Tipo = "CF" And Movimiento = "PAGO" And Concepto = "LIQUIDACION" Then
                NvoConcepto = "VENTA DE APARATOS CF"
            End If
            If Tipo = "CF" And Movimiento = "LIQUIDACION" And Concepto = "LIQUIDACION" Then
                NvoConcepto = "LIQUIDACION"
            End If
            If Tipo = "CF" And Movimiento = "LIQUIDACION" And Concepto = "INTERESES" Then
                NvoConcepto = "VENTA DE APARATOS CF"
            End If
            If Tipo = "CF" And Movimiento = "COMISION CF" And Concepto = "INTERESES" Then
                NvoConcepto = "COMISION CF"
            End If
            If Tipo = "CF" And Movimiento = "RECUPERACION" And Concepto = "INTERESES" Then
                NvoConcepto = "VENTA DE APARATOS CF"
                'NvoConcepto = "INTERESES"
            End If
            If Tipo = "CF" And Movimiento = "RECUPERACION" And Concepto = "LIQUIDACION" Then
                NvoConcepto = "VENTA DE APARATOS CF"
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            NombreMovFac = NvoConcepto
        End Try
    End Function

    Public Sub ObtenerParametros()
        Dim sSQL As String = ""
        Dim dtParam As New DataTable
        Dim drParam As DataRow

        Dim strAmbiente As String

        Dim dtParam2 As New DataTable
        Dim drParam2 As DataRow

        ivaAJ = BuscaIvaSuc(IvaS)
        Try
            'DATOS GENERALES
            sSQL = "SELECT TOP 1 ISNULL(Iva," & ivaAJ & ") AS Iva, ISNULL(EsPuntodeVenta,'NO') AS EsPuntodeVenta, ISNULL(TieneVentaElectronicos,'NO') AS TieneVentaElectronicos, ISNULL(TieneVentaJoyeria,'NO') AS TieneVentaJoyeria, "
            sSQL &= "ISNULL(ServerCompaqSQL,'') AS ServerCompaqSQL, ISNULL(ServerCompaqBD,'') AS ServerCompaqBD, ISNULL(ServerCompaqUsr,'') AS ServerCompaqUsr, ISNULL(ServerCompaqPwd,'') AS ServerCompaqPwd, "
            sSQL &= "ISNULL(ServerJoySQL,'') AS ServerJoySQL, ISNULL(ServerJoyBD,'') AS ServerJoyBD, ISNULL(ServerJoyUsr,'') AS ServerJoyUsr, ISNULL(ServerJoyPwd,'') AS ServerJoyPwd, "
            sSQL &= "LTRIM(RTRIM(ISNULL(AreaServicioTimbrado,''))) AS AreaServicioTimbrado, LTRIM(RTRIM(ISNULL(UsuarioServicioTimbrado,''))) AS UsuarioServicioTimbrado, LTRIM(RTRIM(ISNULL(CuentaServicioTimbrado,''))) AS CuentaServicioTimbrado, LTRIM(RTRIM(ISNULL(ContrasenaServicioTimbrado,''))) AS ContrasenaServicioTimbrado, "
            sSQL &= "LTRIM(RTRIM(ISNULL(SerieFacturas,''))) AS SerieFacturas, ISNULL(UltimoFolioFactura,0)+1 AS SiguienteFolioFactura, ISNULL(UltimoFolioNotaCredito,0)+1 AS SiguienteFolioNotaCredito, LTRIM(RTRIM(ISNULL(FACTELECTRONICAAMBIENTE,''))) AS Ambiente "
            sSQL &= ""
            sSQL &= "FROM BPFCatalogoSucursales"
            dtParam = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoSucursales")




            If dtParam Is Nothing OrElse dtParam.Rows.Count <= 0 Then
                MsgBox("No se pueden obtener los parámetros! Por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturacion")
                End
            End If

            'Se llena Tabla con CatalogoSucursales
            drParam = dtParam.Rows(0)

            strAmbiente = drParam("Ambiente").ToString.Trim

            sSQL = "SELECT TOP 1 Elemento AS Elemento,LTRIM(RTRIM(ISNULL(DescLarga,''))) AS CliFechaNacimientoObligado, LTRIM(RTRIM(ISNULL(Valor1T,''))) AS AreaServicioTimbrado, ISNULL(Valor1N,0) AS CliRFCObligado, LTRIM(RTRIM(ISNULL(Valor2T,''))) AS UsuarioServicioTimbrado, ISNULL(Valor2N,0) AS CliOcupacionObligado, "
            sSQL &= "LTRIM(RTRIM(ISNULL(Valor3T,''))) AS CuentaServicioTimbrado, LTRIM(RTRIM(ISNULL(Valor4T,''))) AS ContrasenaServicioTimbrado, ISNULL(Valor3N,0)+1 AS SiguienteFolioFactura, ISNULL(Valor4N,0)+1 AS SiguienteFolioNotaCredito, LTRIM(RTRIM(ISNULL(Valor5T,''))) AS SerieFacturas "
            sSQL &= " FROM BPFCatalogos WHERE Tabla = 38 AND DescCorta = '" & strAmbiente & "' "
            dtParam2 = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")

            'Se llena tabla con BPFCatalogos
            drParam2 = dtParam2.Rows(0)

            bolTienePuntodeVenta = (drParam("EsPuntodeVenta").ToString.Trim.ToUpper = "SI")
            bolTieneVentaAparatos = (drParam("TieneVentaElectronicos").ToString.Trim.ToUpper = "SI")
            bolTieneVentaJoyeria = (drParam("TieneVentaJoyeria").ToString.Trim.ToUpper = "SI")
            dblPorcentajeIVA = (drParam("Iva") / 100)
            'datos de conexion por si es punto de venta
            'electronicos
            strServerAQ = drParam("ServerCompaqSQL").ToString.Trim
            strBDAQ = drParam("ServerCompaqBD").ToString.Trim
            strBDAQGlobal = "PE_BI"
            strUsrAQ = drParam("ServerCompaqUsr").ToString.Trim
            If strServerAQ = "192.168.2.5\SQLSUCUR" Then
                strPwdAQ = "masterkey"
            Else
                strPwdAQ = "M@st3rkey"
            End If
            'strPwdAQ = drParam("ServerCompaqPwd").ToString.Trim
            'joyeria
            strServerJY = drParam("ServerJoySQL").ToString.Trim
            strBDJY = drParam("ServerJoyBD").ToString.Trim
            strUsrJY = drParam("ServerJoyUsr").ToString.Trim
            strPwdJY = "masterkey"  ' drParam("ServerJoyPwd").ToString.Trim

            'datos de conexion con el servicio
            strAreaServicioTimbrado = drParam2("AreaServicioTimbrado").ToString.Trim.ToUpper
            strCuentaServicioTimbrado = drParam2("CuentaServicioTimbrado").ToString.Trim
            strUsuarioServicioTimbrado = drParam2("UsuarioServicioTimbrado").ToString.Trim
            strContrasenaServicioTimbrado = drParam2("ContrasenaServicioTimbrado").ToString.Trim

            'Serie y folio de la factura
            strSerieFactura = drParam2("SerieFacturas").ToString.Trim
            If MovBorrados = False Then
                intSiguienteFolio = drParam2("SiguienteFolioFactura")
                intSiguienteFolioNC = drParam2("SiguienteFolioFactura")
            End If
            'FOLIO QUE TIMBRARA CONCATENADO LA SERIE
            strSiguienteFolio = strSerieFactura & intSiguienteFolio
            'Elemento de Catalgos Tabla-->38
            intElementoCata = drParam2("Elemento")


            'FECHA DEL ULTIMO CIERRE
            sSQL = "SELECT MAX(Fecha) AS UltimoCierre FROM BPFCierreDiario WHERE Cierre='S';"
            dtParam = New DataTable
            dtParam = SQLServer.ExecSQLReturnDT(sSQL, "BPFCierreDiario")
            If dtParam Is Nothing OrElse dtParam.Rows.Count <= 0 Then
                strFechaUltimoCierre = Format(Now, "yyyy-MM-dd")
            Else
                strFechaUltimoCierre = dtParam.Rows(0).Item("UltimoCierre").ToString
                strFechaUltimoCierre = Mid(strFechaUltimoCierre, 1, 4) & "-" & Mid(strFechaUltimoCierre, 5, 2) & "-" & Mid(strFechaUltimoCierre, 7, 2)
            End If

            'RFC genérico, se toma del cliente PUBLICO EN GENERAL
            'valor default
            strRFCGenerico = "XAXX010101000"
            sSQL = "SELECT * FROM BDSPEXPRESS.dbo.BPFCatalogoClientes WHERE UPPER(LTRIM(RTRIM(NombreCliente))) LIKE '%PUBLICO EN GENERAL%';"
            dtParam = New DataTable
            dtParam = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoClientes")
            If Not dtParam Is Nothing Then
                If dtParam.Rows.Count > 0 Then
                    If Not IsDBNull(dtParam.Rows(0).Item("RFC")) Then
                        strRFCGenerico = dtParam.Rows(0).Item("RFC")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try
    End Sub

    Public Sub GeneraFactura(ByVal TipoDocumento As enTipoDocumento,
                             ByVal SubTotal As Double, _
                             ByVal Descuento As Double, _
                             ByVal IVA As Double, _
                             ByVal Total As Double, _
                             ByVal Datos As DataTable, _
                             ByVal CondicionesPago As String, _
                             ByRef RespuestaoXML As String, _
                             ByVal IncluyeDireccionFiscal As Boolean, _
                             ByVal IncluyeDireccionSucursal As Boolean, _
                             ByVal IncluyeDireccionCliente As Boolean, _
                             Optional ByRef CBB As String = Nothing, _
                             Optional ByVal CFDIRelacionado As String = "", _
                             Optional ByVal TipoRelacion As String = "", _
                             Optional ByVal TipoDocumentoAfectarPorNC As enTipoDocumentoAfectar = enTipoDocumentoAfectar.FacturaIndividual, _
                             Optional ByVal UUIDsRealcionados As ArrayList = Nothing)

        ObtenerParametros()




        'OBJETOS USADOS PARA EL SERVICIO DE FEL
        Dim ConexionRemota33 As Object
        Dim datosUsuario As Object
        Dim Comprobante As Object
        Dim listaCFDIRel As Object
        Dim CFDIRel1 As Object
        Dim listaConcepto As Object
        Dim Concepto1 As Object
        Dim ConceptoImpuestos1 As Object
        Dim ListaTraslado1 As Object
        Dim traslado1 As Object
        Dim COMAdenda As Object
        Dim oDomicilioEmisor As Object
        Dim oDomicilioSucursal As Object
        Dim oDomicilioCliente As Object
        Dim RespuestaServicio As Object
        Dim oRespuestaPDF As Object
        Dim sSQL As String = ""
        Dim dtEmail As New DataTable
        Dim drEmail As DataRow
        Dim ImporteSub As Decimal
        Dim ImporteIVA As Decimal
        strEstatusGeneracion = "ERROR"

        'VARIABLE ETIQUETA


        dtClavesFiscales = New DataTable
        'drClavesFiscales As DataRow

        strRegimenFiscal = ""
        strClaveProductoSAT = ""
        strUnidadMedidaSAT = ""
        strUnidadMedidaPE = ""





        If strTipoFactura = "GLOBAL" Then
            frmFacturaGlobalDiaria.lblTextoAnuncio.Text = "Extrayendo datos del Ticket..."
            frmFacturaGlobalDiaria.lblTextoAnuncio.Visible = True
            frmFacturaGlobalDiaria.lblTextoAnuncio.Refresh()
        Else
            frmFacturaIndividual.lblTextoAnuncio.Text = "Extrayendo datos del Ticket..."
            frmFacturaIndividual.lblTextoAnuncio.Visible = True
            frmFacturaIndividual.lblTextoAnuncio.Refresh()
        End If

            Try

            'PRUEBA DE ESCRITURA BLOC DE NOTA
            'nombreArchi = "C:\SPE\VINO\LOG\" & "LogFactura" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
            If (System.IO.File.Exists(nombreArchi)) Then
                File.Delete(nombreArchi)
            End If

            'Const fic As String = nombreArchi.
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Recopilando información inicial" & vbNewLine
            Else
                If strTipoFactura = "GLOBAL" Then
                    texto = Format(Now, "HH:mm:ss").ToString & "~" & "INICIANDO FACTURA GLOBAL MANUAL........................................................." & vbNewLine
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "SUCURSAL: " & Format(intNoSucursal, "000").ToString & " " & strNombreSuc & vbNewLine
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FECHA MOVIMIENTO: " & strFechaBusqueda.ToString & " " & vbNewLine
                Else
                    texto = Format(Now, "HH:mm:ss").ToString & "~" & "INICIANDO FACTURA INDIVIDUAL........................................................." & vbNewLine
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "SUCURSAL: " & Format(intNoSucursal, "000").ToString & " " & strNombreSuc & vbNewLine
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FECHA MOVIMIENTO: " & strFechaBusqueda.ToString & " " & vbNewLine
                End If
            End If

            If TipoDocumento = enTipoDocumento.Factura Then
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_FA_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                nombreArchi = sRuta & "LOG\" & "LogFactura_FA_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FOLIO FACTURA: " & intSiguienteFolio & vbNewLine
            ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_NC_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                nombreArchi = sRuta & "\LOG\" & "LogFactura_NC_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                texto = Format(Now, "HH:mm:ss").ToString & "~" & "INICIANDO NOTA DE CREDITO........................................................." & vbNewLine
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "SUCURSAL: " & Format(intNoSucursal, "000").ToString & " " & strNombreSuc & vbNewLine
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FOLIO FACTURA: " & intSiguienteFolioNC & vbNewLine
            End If

            If (System.IO.File.Exists(nombreArchi)) Then
                File.Delete(nombreArchi)
            End If


            'Tipo Error
            TipoError = "PE001"
            'obteniendo las claves fiscales (Regimen Fiscal, Forma de Pago, Moneda, Uso CFDI, Metodo de Pago)
            sSQL = "SELECT * FROM BPFCatalogoEmpresas WHERE NoEmpresa=1"
            dtClavesFiscales = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoEmpresas")
            If dtClavesFiscales Is Nothing OrElse dtClavesFiscales.Rows.Count <= 0 Then
                If strmodoFactura = "AUTOMATICA" Then
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: No hay información de Claves Del SAT" & vbNewLine
                    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    FechaLog = Format(Now, "yyyy-MM-dd HHmm").ToString
                    nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                    EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                    End
                Else
                    MsgBox("No hay información de Claves Del SAT, por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturación")
                    Exit Sub
                End If
            End If

            drClavesFiscales = dtClavesFiscales.Rows(0)
            strEmiNombreCliente = drClavesFiscales.Item("Descripcion").ToString.Trim.ToUpper
            strRegimenFiscal = drClavesFiscales.Item("ClaveRegimenFiscalSAT").ToString.Trim.ToUpper

            'Tipo Error
            TipoError = "PE002"
            If strTipoFactura = "GLOBAL" Then
                With drClavesFiscales
                    strEmiNombreCliente = .Item("Descripcion").ToString.Trim.ToUpper
                    strRegimenFiscal = .Item("ClaveRegimenFiscalSAT").ToString.Trim.ToUpper
                    strMonedaClave = .Item("ClaveMonedaSAT").ToString.Trim.ToUpper
                    strUsoCFDIClave = .Item("ClaveUsoCFDISATFAC").ToString.Trim.ToUpper
                    strFormaPagoClave = .Item("ClaveFormaPagoSAT").ToString.Trim.ToUpper
                    strMetodoPagoClave = .Item("ClaveMetodoPagoSAT").ToString.Trim.ToUpper
                End With
                If TipoDocumento = enTipoDocumento.NotaCredito Then
                    strUsoCFDIClave = drClavesFiscales.Item("ClaveUsoCFDISATCRE").ToString.Trim.ToUpper
                End If
            Else
                strMonedaClave = strMonedaClaveIND
                If TipoDocumento = enTipoDocumento.Factura Then
                    strUsoCFDIClave = strUsoCFDIClaveIND
                Else
                    strUsoCFDIClave = drClavesFiscales.Item("ClaveUsoCFDISATCRE").ToString.Trim.ToUpper
                End If
                strFormaPagoClave = strFormaPagoClaveIND
                strMetodoPagoClave = strMetodoPagoClaveIND
            End If

            'Tipo Error
            TipoError = "PE003: No hay Archivo de Configuracion "
            '**********************************************
            ' Instanciar al Web Service de Conexión Remota.
            '**********************************************
            If strAreaServicioTimbrado = "PRUEBAS" Then
                ConexionRemota33 = New FelTest.ConexionRemotaClient
            Else
                ConexionRemota33 = New FelProd.ConexionRemotaClient
            End If

            '*************************************************************************************
            ' Sección de variables para la autenticación del usuario remoto.
            ' Ingreso de credenciales para la autenticacion del usuario remoto.
            '*************************************************************************************
            'Tipo Error
            TipoError = "PE004: Error en Credenciales de Conexion"
            If strAreaServicioTimbrado = "PRUEBAS" Then
                datosUsuario = New FelTest.Credenciales
            Else
                datosUsuario = New FelProd.Credenciales
            End If
            'texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FOLIO FACTURA: " & intSiguienteFolio & vbNewLine
            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DATOS DEL USUARIO......................................................... " & vbNewLine
            If strCuentaServicioTimbrado <> "" Then
                datosUsuario.Cuenta = strCuentaServicioTimbrado
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DATOS DE USUARIO (CUENTA): " & strCuentaServicioTimbrado & vbNewLine
            End If
            If strContrasenaServicioTimbrado <> "" Then
                datosUsuario.Password = strContrasenaServicioTimbrado
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DATOS DE USUARIO (CONTRASEÑA): " & strContrasenaServicioTimbrado & vbNewLine
            End If
            If strUsuarioServicioTimbrado <> "" Then
                datosUsuario.Usuario = strUsuarioServicioTimbrado
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DATOS DE USUARIO (USUARIO): " & strUsuarioServicioTimbrado & vbNewLine
            End If




            '*************************************************************************************
            ' Sección de variables para agregar los valores al comprobante CFDi.
            '*************************************************************************************
            'Tipo Error
            TipoError = "PE005: Error en Comprobante"
            If strAreaServicioTimbrado = "PRUEBAS" Then
                Comprobante = New FelTest.Comprobante33R
            Else
                Comprobante = New FelProd.Comprobante33R
            End If
            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE............................................................... " & vbNewLine

            If strAreaServicioTimbrado = "PRUEBAS" Then
                COMAdenda = New FelTest.AddendaCFDR
                oDomicilioEmisor = New FelTest.DomicilioClienteR
                oDomicilioSucursal = New FelTest.DomicilioClienteR
                oDomicilioCliente = New FelTest.DomicilioClienteR
            Else
                COMAdenda = New FelProd.AddendaCFDR
                oDomicilioEmisor = New FelProd.DomicilioClienteR
                oDomicilioSucursal = New FelProd.DomicilioClienteR
                oDomicilioCliente = New FelProd.DomicilioClienteR
            End If

            '**********************************************
            ' Etiquetas Perzonalizadas.
            '**********************************************
            If TipoDocumento = enTipoDocumento.Factura Then
                If strAreaServicioTimbrado = "PRUEBAS" Then
                    Dim ListaEtiquetaPerso As List(Of FelTest.EtiquetaPersonalizadaR) = New List(Of FelTest.EtiquetaPersonalizadaR)
                    Dim EtiquetaPerso = New FelTest.EtiquetaPersonalizadaR
                    strFechaBusqueda = Mid(strFechaBusqueda, 1, 4) & "-" & Mid(strFechaBusqueda, 5, 2) & "-" & Mid(strFechaBusqueda, 7, 2)
                    EtiquetaPerso.Valor = Utilerias.FechaFormato(CDate(strFechaBusqueda))
                    EtiquetaPerso.Nombre = "FECHA OPERACION"

                    ListaEtiquetaPerso.Add(EtiquetaPerso)
                    COMAdenda.EtiquetasPersonalizadas = ListaEtiquetaPerso.ToArray
                Else
                    Dim ListaEtiquetaPerso As List(Of FelProd.EtiquetaPersonalizadaR) = New List(Of FelProd.EtiquetaPersonalizadaR)
                    Dim EtiquetaPerso = New FelProd.EtiquetaPersonalizadaR
                    strFechaBusqueda = Mid(strFechaBusqueda, 1, 4) & "-" & Mid(strFechaBusqueda, 5, 2) & "-" & Mid(strFechaBusqueda, 7, 2)
                    EtiquetaPerso.Valor = Utilerias.FechaFormato(CDate(strFechaBusqueda))
                    EtiquetaPerso.Nombre = "FECHA OPERACION"

                    ListaEtiquetaPerso.Add(EtiquetaPerso)
                    COMAdenda.EtiquetasPersonalizadas = ListaEtiquetaPerso.ToArray
                End If
            End If


            'Tipo Error
            TipoError = "PE006: Error en Datos Fiscales"
            If IncluyeDireccionFiscal = True Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DATOS DEL EMISOR.......................................................... " & vbNewLine
                If dtOrganizacion.Rows(0).Item("Calle").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.Calle = dtOrganizacion.Rows(0).Item("Calle").ToString.Trim.ToUpper
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(CALLE): " & dtOrganizacion.Rows(0).Item("Calle").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtOrganizacion.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.CodigoPostal = dtOrganizacion.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(CODIGO POSTAL): " & dtOrganizacion.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtOrganizacion.Rows(0).Item("Colonia").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.Colonia = dtOrganizacion.Rows(0).Item("Colonia").ToString.Trim.ToUpper
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(COLONIA): " & dtOrganizacion.Rows(0).Item("Colonia").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtOrganizacion.Rows(0).Item("Estado").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.Estado = dtOrganizacion.Rows(0).Item("Estado").ToString.Trim.ToUpper
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(ESTADO): " & dtOrganizacion.Rows(0).Item("Estado").ToString.Trim.ToUpper & vbNewLine
                End If
                'If dtOrganizacion.Rows(0).Item("Municipio").ToString.Trim.ToUpper <> "" Then
                '    oDomicilioEmisor.Localidad = dtOrganizacion.Rows(0).Item("Municipio").ToString.Trim.ToUpper
                '    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(LOCALIDAD): " & dtOrganizacion.Rows(0).Item("Municipio").ToString.Trim.ToUpper & vbNewLine
                'End If
                If dtOrganizacion.Rows(0).Item("Municipio").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.Municipio = dtOrganizacion.Rows(0).Item("Municipio").ToString.Trim.ToUpper     '"MONTEMORELOS"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(MUNICIPIO): " & dtOrganizacion.Rows(0).Item("Municipio").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.NumeroExterior = dtLugarEmision.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper     '"1201"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(NUM. EXTERIOR): " & dtLugarEmision.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.NumeroInterior = dtLugarEmision.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper     '"L-10"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(NUM. INTERIOR): " & dtLugarEmision.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.Pais = dtLugarEmision.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper     '"MEXICO"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(PAIS): " & dtLugarEmision.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtOrganizacion.Rows(0).Item("Telefono01").ToString.Trim.ToUpper <> "" Then
                    oDomicilioEmisor.Telefono = dtOrganizacion.Rows(0).Item("Telefono01").ToString.Trim.ToUpper     '"19-46-36-00"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO EMISOR(TELEFONO): " & dtOrganizacion.Rows(0).Item("Telefono01").ToString.Trim.ToUpper & vbNewLine
                End If
                COMAdenda.DomicilioEmisor = oDomicilioEmisor
            End If
            'Tipo Error
            TipoError = "PE007: Error en Datos de Sucursal"
            If IncluyeDireccionSucursal = True Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DATOS DE LA SUCURSAL....................................................... " & vbNewLine
                If dtLugarEmision.Rows(0).Item("Calle").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.Calle = dtLugarEmision.Rows(0).Item("Calle").ToString.Trim.ToUpper     '"SIMON BOLIVAR"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(CALLE): " & dtLugarEmision.Rows(0).Item("Calle").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.CodigoPostal = dtLugarEmision.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper     '"67550"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(CODIGO POSTAL): " & dtLugarEmision.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("Colonia").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.Colonia = dtLugarEmision.Rows(0).Item("Colonia").ToString.Trim.ToUpper     '"MEXIQUITO"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(COLONIA): " & dtLugarEmision.Rows(0).Item("Colonia").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("Estado").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.Estado = dtLugarEmision.Rows(0).Item("Estado").ToString.Trim.ToUpper     '"NUEVO LEON"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(ESTADO): " & dtLugarEmision.Rows(0).Item("Estado").ToString.Trim.ToUpper & vbNewLine
                End If
                'If dtLugarEmision.Rows(0).Item("Municipio").ToString.Trim.ToUpper <> "" Then
                '    oDomicilioSucursal.Localidad = dtLugarEmision.Rows(0).Item("Municipio").ToString.Trim.ToUpper     '"CENTRO"
                '    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(LOCALDAD): " & dtLugarEmision.Rows(0).Item("Municipio").ToString.Trim.ToUpper & vbNewLine
                'End If
                If dtLugarEmision.Rows(0).Item("Municipio").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.Municipio = dtLugarEmision.Rows(0).Item("Municipio").ToString.Trim.ToUpper     '"MONTEMORELOS"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(MUNICIPIO): " & dtLugarEmision.Rows(0).Item("Municipio").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.NumeroExterior = dtLugarEmision.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper     '"1201"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(NUM. EXTERIOR): " & dtLugarEmision.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.NumeroInterior = dtLugarEmision.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper     '"L-10"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(NUM. INTERIOR): " & dtLugarEmision.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.Pais = dtLugarEmision.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper     '"MEXICO"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(PAIS): " & dtLugarEmision.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtLugarEmision.Rows(0).Item("Telefono01").ToString.Trim.ToUpper <> "" Then
                    oDomicilioSucursal.Telefono = dtLugarEmision.Rows(0).Item("Telefono01").ToString.Trim.ToUpper     '"19-46-36-00"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO SUCURSAL(TELEFONO): " & dtLugarEmision.Rows(0).Item("Telefono01").ToString.Trim.ToUpper & vbNewLine
                End If
                COMAdenda.DomicilioSucursal = oDomicilioSucursal
            End If
            'Tipo Error
            TipoError = "PE008: Error en datos del Cliente"
            If IncluyeDireccionCliente = True Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DATOS DEL RECEPTOR........................................................ " & vbNewLine
                If dtCliente.Rows(0).Item("CalleFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.Calle = dtCliente.Rows(0).Item("CalleFiscal").ToString.Trim.ToUpper '"BRAVO"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(CALLE): " & dtCliente.Rows(0).Item("CalleFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("CodigoPostalFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.CodigoPostal = dtCliente.Rows(0).Item("CodigoPostalFiscal").ToString.Trim.ToUpper '"64345"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(CODIGO POSTAL): " & dtCliente.Rows(0).Item("CodigoPostalFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("ColoniaFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.Colonia = dtCliente.Rows(0).Item("ColoniaFiscal").ToString.Trim.ToUpper '"CENTRO"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(COLONIA): " & dtCliente.Rows(0).Item("ColoniaFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("EstadoFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.Estado = dtCliente.Rows(0).Item("EstadoFiscal").ToString.Trim.ToUpper '"NUEVO LEON"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(ESTADO): " & dtCliente.Rows(0).Item("EstadoFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("MunicipioFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.Municipio = dtCliente.Rows(0).Item("MunicipioFiscal").ToString.Trim.ToUpper '"SAN NICOLAS DE LOS GARZA"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(MUNICIPIO): " & dtCliente.Rows(0).Item("MunicipioFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("RazonSocial").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.NombreCliente = dtCliente.Rows(0).Item("RazonSocial").ToString.Trim.ToUpper '"NOMBRE DE CLIENTE, S.A. DE C.V."
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(NOMBRE CLIENTE): " & dtCliente.Rows(0).Item("RazonSocial").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.NumeroExterior = dtCliente.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper '"510"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(NUM. EXTERIOR): " & dtCliente.Rows(0).Item("NoExteriorFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.NumeroInterior = dtCliente.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper '"L-1"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(NUM. INTERIOR): " & dtCliente.Rows(0).Item("NoInteriorFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.Pais = dtCliente.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper '"MEXICO"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(PAIS): " & dtCliente.Rows(0).Item("PaisFiscal").ToString.Trim.ToUpper & vbNewLine
                End If
                If dtCliente.Rows(0).Item("Telefono01").ToString.Trim.ToUpper <> "" Then
                    oDomicilioCliente.Telefono = dtCliente.Rows(0).Item("Telefono01").ToString.Trim.ToUpper '"8376-0054"
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "DOMICILIO CLIENTE(TELEFONO): " & dtCliente.Rows(0).Item("Telefono01").ToString.Trim.ToUpper & vbNewLine
                End If
                COMAdenda.DomicilioReceptor = oDomicilioCliente
            End If

            Comprobante.Addenda = COMAdenda

            'Tipo Error
            TipoError = "PE009"
            If strTipoFactura = "GLOBAL" Then
                frmFacturaGlobalDiaria.lblTextoAnuncio.Text = "Buscando UUIDs relacionados..."
                frmFacturaGlobalDiaria.lblTextoAnuncio.Visible = True
                frmFacturaGlobalDiaria.lblTextoAnuncio.Refresh()
            Else
                frmFacturaIndividual.lblTextoAnuncio.Text = "Buscando UUIDs relacionados..."
                frmFacturaIndividual.lblTextoAnuncio.Visible = True
                frmFacturaIndividual.lblTextoAnuncio.Refresh()
            End If

            'Tipo Error
            TipoError = "PE010"
            'UUIDs RELACIONADOS
            strCFDIRel = ""
            strTipoRel = ""
            If Not UUIDsRealcionados Is Nothing Then
                If UUIDsRealcionados.Count > 0 Then
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "UUIDsRelacionados......................................................... " & vbNewLine
                    If strAreaServicioTimbrado = "PRUEBAS" Then
                        Comprobante.CfdiRelacionados = New FelTest.CfdiRelacionadosR
                        listaCFDIRel = New List(Of FelTest.CfdiRelacionadoR)()
                    Else
                        Comprobante.CfdiRelacionados = New FelProd.CfdiRelacionadosR
                        listaCFDIRel = New List(Of FelProd.CfdiRelacionadoR)()
                    End If
                    If TipoRelacion.Trim <> "" Then
                        strTipoRel = TipoRelacion.Trim
                        Comprobante.CfdiRelacionados.TipoRelacion = TipoRelacion.Trim
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (CFDI RELACIONADOS (TIPO RELACION)): " & TipoRelacion.Trim & vbNewLine
                    End If

                    Dim x As Integer = 0
                    For x = 0 To UUIDsRealcionados.Count - 1
                        If strAreaServicioTimbrado = "PRUEBAS" Then
                            CFDIRel1 = New FelTest.CfdiRelacionadoR
                        Else
                            CFDIRel1 = New FelProd.CfdiRelacionadoR
                        End If
                        CFDIRel1.UUID = UUIDsRealcionados(x).ToString
                        If strCFDIRel = "" Then
                            strCFDIRel = UUIDsRealcionados(x).ToString
                        Else
                            strCFDIRel = strCFDIRel & "," & UUIDsRealcionados(x).ToString
                        End If

                        listaCFDIRel.Add(CFDIRel1)
                    Next x
                    If strCFDIRel <> "" Then
                        Comprobante.CfdiRelacionados.CfdiRelacionado = listaCFDIRel.ToArray
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (CFDI RELACIONADOS (UUIDs)): " & strCFDIRel & vbNewLine
                    End If
                End If
            Else
                'Tipo Error
                TipoError = "PE011"
                'Documento relacionado (solo 1)
                If CFDIRelacionado.Trim <> "" Then
                    If strAreaServicioTimbrado = "PRUEBAS" Then
                        Comprobante.CfdiRelacionados = New FelTest.CfdiRelacionadosR
                    Else
                        Comprobante.CfdiRelacionados = New FelProd.CfdiRelacionadosR
                    End If

                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "UUIDsRelacionados........................................................ " & vbNewLine
                    strTipoRel = TipoRelacion.Trim
                    Comprobante.CfdiRelacionados.TipoRelacion = TipoRelacion.Trim
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (CFDI RELACIONADOS (TIPO RELACION)): " & TipoRelacion.Trim & vbNewLine

                    'Dim listaCFDIRel As List(Of FelTest.CfdiRelacionadoR) = New List(Of FelTest.CfdiRelacionadoR)()
                    'Dim CFDIRel1 As FelTest.CfdiRelacionadoR = New FelTest.CfdiRelacionadoR
                    If strAreaServicioTimbrado = "PRUEBAS" Then
                        listaCFDIRel = New List(Of FelTest.CfdiRelacionadoR)()
                        CFDIRel1 = New FelTest.CfdiRelacionadoR
                    Else
                        listaCFDIRel = New List(Of FelProd.CfdiRelacionadoR)()
                        CFDIRel1 = New FelProd.CfdiRelacionadoR
                    End If

                    CFDIRel1.UUID = CFDIRelacionado.Trim
                    strCFDIRel = CFDIRelacionado.Trim
                    listaCFDIRel.Add(CFDIRel1)
                    Comprobante.CfdiRelacionados.CfdiRelacionado = listaCFDIRel.ToArray
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (CFDI RELACIONADOS (UUID)): " & strCFDIRel.Trim & vbNewLine
                End If
            End If

            'Tipo Error
            TipoError = "PE012"
            If TipoDocumento = enTipoDocumento.Factura Then
                Comprobante.ClaveCFDI = "FAC"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (CLAVE CFDI): " & "FAC" & vbNewLine
            ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                Comprobante.ClaveCFDI = "CRE"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (CLAVE CFDI): " & "CRE" & vbNewLine
            Else
            End If

            'Tipo Error
            TipoError = "PE013"
            If strAreaServicioTimbrado = "PRUEBAS" Then
                listaConcepto = New List(Of FelTest.ConceptoR)()
                Concepto1 = New FelTest.ConceptoR
                ConceptoImpuestos1 = New FelTest.ImpuestosConceptoR
                ListaTraslado1 = New List(Of FelTest.TrasladoConceptoR)()
                traslado1 = New FelTest.TrasladoConceptoR
            Else
                listaConcepto = New List(Of FelProd.ConceptoR)()
                Concepto1 = New FelProd.ConceptoR
                ConceptoImpuestos1 = New FelProd.ImpuestosConceptoR
                ListaTraslado1 = New List(Of FelProd.TrasladoConceptoR)()
                traslado1 = New FelProd.TrasladoConceptoR
            End If

            'Tipo Error
            TipoError = "PE014"
            If strTipoFactura = "GLOBAL" Then
                frmFacturaGlobalDiaria.lblTextoAnuncio.Text = "LLenando conceptos..."
                frmFacturaGlobalDiaria.lblTextoAnuncio.Visible = True
                frmFacturaGlobalDiaria.lblTextoAnuncio.Refresh()
            Else
                frmFacturaIndividual.lblTextoAnuncio.Text = "LLenando conceptos..."
                frmFacturaIndividual.lblTextoAnuncio.Visible = True
                frmFacturaIndividual.lblTextoAnuncio.Refresh()
            End If

            'Tipo Error
            TipoError = "PE015"
            'LLENANDO LOS CONCEPTOS
            For Each dr As DataRow In Datos.Rows
                'Tipo Error
                TipoError = "PE015-1"
                If strTipoFactura = "GLOBAL" Then
                    strClaveProductoSAT = CodigoProductoSAT(TipoDocumento, dr("DescripcionSAT").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                    strUnidadMedidaSAT = CodigoUMSAT(TipoDocumento, dr("DescripcionSAT").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                    strUnidadMedidaPE = CodigoUMPE(dr("DescripcionSAT").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                Else
                    If dr("Tipo") = "VT" Then
                        strClaveProductoSAT = CodigoProductoSAT(TipoDocumento, dr("Concepto").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                        strUnidadMedidaSAT = CodigoUMSAT(TipoDocumento, dr("Concepto").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                        strUnidadMedidaPE = CodigoUMPE(dr("Concepto").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                    Else
                        strClaveProductoSAT = CodigoProductoSAT(TipoDocumento, dr("DescripcionSAT").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                        strUnidadMedidaSAT = CodigoUMSAT(TipoDocumento, dr("DescripcionSAT").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                        strUnidadMedidaPE = CodigoUMPE(dr("DescripcionSAT").ToString.Trim.ToUpper, TipoDocumentoAfectarPorNC)
                    End If
                End If
                'Tipo Error
                TipoError = "PE015-2"
                If strAreaServicioTimbrado = "PRUEBAS" Then
                    Concepto1 = New FelTest.ConceptoR()
                Else
                    Concepto1 = New FelProd.ConceptoR()
                End If

                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS................................................................. " & vbNewLine

                Concepto1.Cantidad = "1.0"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (CANTIDAD): " & "1.0" & vbNewLine
                'Tipo Error
                TipoError = "PE015-3"
                If strTipoFactura = "GLOBAL" Or TipoDocumento = enTipoDocumento.NotaCredito Then
                    If strClaveProductoSAT <> "" Then
                        Concepto1.ClaveProdServ = strClaveProductoSAT
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (CLAVE PRODUCTO O SERVICIO): " & strClaveProductoSAT & vbNewLine
                    End If
                Else
                    If dr("ClaveSAT").ToString.Trim.ToUpper <> "" Then
                        Concepto1.ClaveProdServ = dr("ClaveSAT").ToString.Trim.ToUpper
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (CLAVE PRODUCTO O SERVICIO): " & dr("ClaveSAT").ToString.Trim.ToUpper & vbNewLine
                    End If
                End If
                If strUnidadMedidaSAT <> "" Then
                    Concepto1.ClaveUnidad = strUnidadMedidaSAT    'UNIDAD DE MEDIDA DEL SAT
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (CLAVE UNIDAD): " & strUnidadMedidaSAT & vbNewLine
                End If
                'Tipo Error
                TipoError = "PE015-4"
                If strTipoFactura = "GLOBAL" Then
                    If TipoDocumento = enTipoDocumento.NotaCredito Then
                        If dr("DescripcionSAT").ToString.Trim.ToUpper <> "" And dr("UUIDOriginal").ToString.Trim <> "" Then
                            Concepto1.Descripcion = dr("DescripcionSAT").ToString.Trim.ToUpper & " " & dr("UUIDOriginal").ToString.Trim
                            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (DESCRIPCION): " & dr("DescripcionSAT").ToString.Trim.ToUpper & " " & dr("UUIDOriginal").ToString.Trim & vbNewLine
                        End If
                    Else
                        If dr("DescripcionSAT").ToString.Trim.ToUpper <> "" Then
                            Concepto1.Descripcion = dr("DescripcionSAT").ToString.Trim.ToUpper
                            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (DESCRIPCION): " & dr("DescripcionSAT").ToString.Trim.ToUpper & vbNewLine
                        End If
                    End If
                Else
                    If dr("DescripcionSAT").ToString.Trim.ToUpper <> "" Then
                        Concepto1.Descripcion = dr("DescripcionSAT").ToString.Trim.ToUpper
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (DESCRIPCION): " & dr("DescripcionSAT").ToString.Trim.ToUpper & vbNewLine
                    End If
                End If

                'Tipo Error
                TipoError = "PE015-5"
                Dim ConcepImporte As Double = 0
                Dim ConcepImporte2 As Double = 0
                Dim Ticket As String
                Ticket = dr("NoTicket").ToString
                If Format(dr("Interes"), "#0.000000").ToString > "0.000000" Then
                    ConcepImporte = ConcepImporte + dr("Interes")
                End If
                If Format(dr("Recargo"), "#0.000000").ToString > "0.000000" Then
                    ConcepImporte = ConcepImporte + dr("Recargo")
                End If
                If Format(dr("Importe"), "#0.000000").ToString > "0.000000" Then
                    ConcepImporte = ConcepImporte + dr("Importe")
                End If
                'Si el Importe es Negativo
                If Format(dr("Importe"), "#0.000000").ToString < "0.000000" Then
                    ConcepImporte2 = ConcepImporte2 + dr("Importe")
                End If
                '-----
                If Format(dr("Descuento"), "#0.000000").ToString > "0.000000" Then
                    ConcepImporte = ConcepImporte + dr("Descuento")
                End If
                Concepto1.Importe = Format(Math.Round(ConcepImporte, 6), "#0.000000").ToString
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (IMPORTE): " & Format(Math.Round(ConcepImporte, 6), "#0.000000").ToString & vbNewLine

                ImporteSub = ImporteSub + Math.Round(ConcepImporte, 2)

                'Tipo Error
                TipoError = "PE015-6"
                If strAreaServicioTimbrado = "PRUEBAS" Then
                    traslado1 = New FelTest.TrasladoConceptoR
                Else
                    traslado1 = New FelProd.TrasladoConceptoR
                End If

                'Tipo Error
                TipoError = "PE015-7"
                'TRASLADO(BASE)
                If dr("IVA") > 0 Then

                    Dim TrasBase As Double = 0
                    If Format(dr("Interes"), "#0.000000").ToString > "0.000000" Then
                        TrasBase = TrasBase + dr("Interes")
                    End If
                    If Format(dr("Recargo"), "#0.000000").ToString > "0.000000" Then
                        TrasBase = TrasBase + dr("Recargo")
                    End If
                    If Format(dr("Importe"), "#0.000000").ToString > "0.000000" Then
                        TrasBase = TrasBase + dr("Importe")
                    End If

                    traslado1.Base = Format(Math.Round(TrasBase, 6), "#0.000000").ToString
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "TRASLADO (BASE): " & Format(Math.Round(TrasBase, 6), "#0.000000").ToString & vbNewLine

                    'Tipo Error
                    TipoError = "PE015-8"
                    'TRASLADO (IMPORTE)
                    If Format(dr("IVA"), "#0.000000").ToString <> "" Then
                        traslado1.Importe = Format(Math.Round(dr("IVA"), 6), "#0.000000").ToString
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "TRASLADO (IMPORTE): " & Format(Math.Round(dr("IVA"), 6), "#0.000000").ToString & vbNewLine
                        ImporteIVA = ImporteIVA + Math.Round(dr("IVA"), 6)
                    End If
                    'TRASLADO (IMPUESTO)
                    traslado1.Impuesto = "002"      'TO DO: OBTENER DE LA TABLA
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "TRASLADO (IMPUESTO): " & "002" & vbNewLine
                    'TRASLADO (TASA CUOTA)
                    If Format(dblPorcentajeIVA, "#0.000000").ToString <> "" Then
                        traslado1.TasaOCuota = Format(dblPorcentajeIVA, "#0.000000").ToString  '"0.160000"   TO DO: OBTENER DE LA TABLA
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "TRASLADO (TASA CUOTA): " & Format(dblPorcentajeIVA, "#0.000000").ToString & vbNewLine
                    End If
                    'TRASLADO (TIPO FACTOR)
                    traslado1.TipoFactor = "Tasa"   'TO DO: OBTENER DE LA TABLA
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "TRASLADO (TIPO FACTOR): " & "Tasa" & vbNewLine

                    'Tipo Error
                    TipoError = "PE015-9"
                    If strAreaServicioTimbrado = "PRUEBAS" Then
                        ListaTraslado1 = New List(Of FelTest.TrasladoConceptoR)()
                        ListaTraslado1.Add(traslado1)
                        ConceptoImpuestos1 = New FelTest.ImpuestosConceptoR
                        ConceptoImpuestos1.Traslados = ListaTraslado1.ToArray()
                    Else
                        ListaTraslado1 = New List(Of FelProd.TrasladoConceptoR)()
                        ListaTraslado1.Add(traslado1)
                        ConceptoImpuestos1 = New FelProd.ImpuestosConceptoR
                        ConceptoImpuestos1.Traslados = ListaTraslado1.ToArray()
                    End If
                End If

                'fin de impuesto del concepto
                'Tipo Error
                TipoError = "PE015-10"
                If dr("IVA") > 0 Then
                    Concepto1.Impuestos = ConceptoImpuestos1
                    'texto = texto & vbLf & "CONCEPTOS (IMPUESTOS): " & ConceptoImpuestos1
                End If
                'CONCEPTOS (NO. IDENTIFICACION)
                If dr("NoTicket").ToString.Trim.ToUpper <> "" Then
                    Concepto1.NoIdentificacion = dr("NoTicket").ToString.Trim.ToUpper
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (NO. IDENTIFICACION): " & dr("NoTicket").ToString.Trim.ToUpper & vbNewLine
                End If
                'CONCEPTOS (UNIDAD)
                If strTipoFactura = "GLOBAL" Or TipoDocumento = enTipoDocumento.NotaCredito Then
                    Concepto1.Unidad = "SERVICIO"   'UNIDAD DE MEDIDA DE NOSOTROS
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (UNIDAD): " & "SERVICIO" & vbNewLine
                Else
                    If strUnidadMedidaPE <> "" Then
                        Concepto1.Unidad = strUnidadMedidaPE
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (UNIDAD): " & strUnidadMedidaPE & vbNewLine
                    End If
                End If

                Dim ConValorUni As Double = 0
                'Tipo Error
                TipoError = "PE015-11"
                If Format(dr("Interes"), "#0.000000").ToString > "0.000000" Then
                    ConValorUni = ConValorUni + dr("Interes")
                End If
                If Format(dr("Recargo"), "#0.000000").ToString > "0.000000" Then
                    ConValorUni = ConValorUni + dr("Recargo")
                End If
                If Format(dr("Importe"), "#0.000000").ToString > "0.000000" Then
                    ConValorUni = ConValorUni + dr("Importe")
                End If
                If Format(dr("Descuento"), "#0.000000").ToString > "0.000000" Then
                    ConValorUni = ConValorUni + dr("Descuento")
                End If
                Concepto1.ValorUnitario = Format(Math.Round(ConValorUni, 6), "#0.000000").ToString
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (VALOR UNITARIO): " & Format(Math.Round(ConValorUni, 6), "#0.000000").ToString & vbNewLine

                'Tipo Error
                TipoError = "PE015-12"
                'CONCEPTOS (DESCUENTO)
                If Format(dr("Descuento"), "#0.000000").ToString > 0 Then
                    Concepto1.Descuento = Format(Math.Round(dr("Descuento"), 6), "#0.000000").ToString       'PARA LAS NOTAS DE CREDITO O BONIFICACIONES
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "CONCEPTOS (DESCUENTO): " & Format(Math.Round(dr("Descuento"), 6), "#0.000000").ToString & vbNewLine
                End If
                listaConcepto.Add(Concepto1)

            Next

            'Tipo Error
            TipoError = "PE016"
            'SE AGREGAN LOS CONCEPTOS AL COMPROBANTE
            Comprobante.Conceptos = listaConcepto.ToArray
            '*************************************************************************************
            'Tipo Error
            TipoError = "PE017"
            If strTipoFactura = "GLOBAL" Then
                frmFacturaGlobalDiaria.lblTextoAnuncio.Text = "Extrayendo datos del comprobante..."
                frmFacturaGlobalDiaria.lblTextoAnuncio.Visible = True
                frmFacturaGlobalDiaria.lblTextoAnuncio.Refresh()
            Else
                frmFacturaIndividual.lblTextoAnuncio.Text = "Extrayendo datos del comprobante..."
                frmFacturaIndividual.lblTextoAnuncio.Visible = True
                frmFacturaIndividual.lblTextoAnuncio.Refresh()
            End If

            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE............................................................... " & vbNewLine
            'Tipo Error
            TipoError = "PE018"
            If strCondicionesPago <> "" And enTipoDocumento.Factura Then
                Comprobante.CondicionesDePago = strCondicionesPago
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (CONDICIONES DE PAGO): " & strCondicionesPago & vbNewLine
            End If

            '*************************************************************************************
            '<tes:Emisor>
            '*************************************************************************************
            'Tipo Error
            TipoError = "PE019"
            If strAreaServicioTimbrado = "PRUEBAS" Then
                Comprobante.Emisor = New FelTest.EmisorR
            Else
                Comprobante.Emisor = New FelProd.EmisorR
            End If
            'Tipo Error
            TipoError = "PE020"
            If strEmiNombreCliente <> "" Then
                Comprobante.Emisor.Nombre = strEmiNombreCliente
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (EMISOR (NOMBRE)): " & strEmiNombreCliente & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE021"
            If strRegimenFiscal <> "" Then
                Comprobante.Emisor.RegimenFiscal = strRegimenFiscal
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (EMISOR (REGIMEN FISCAL)): " & strRegimenFiscal & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE022"
            Comprobante.Fecha = Format(Date.Now, "yyyy-MM-ddThh:mm:ss")
            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (FECHA): " & Format(Date.Now, "yyyy-MM-ddThh:mm:ss") & vbNewLine
            If TipoDocumento = enTipoDocumento.Factura Then
                'Tipo Error
                TipoError = "PE022-1"
                If intSiguienteFolio.ToString <> "" Then
                    'Comprobante.Folio = strSiguienteFolio.ToString
                    Comprobante.Folio = intSiguienteFolio.ToString
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (FOLIO): " & intSiguienteFolio.ToString & vbNewLine
                End If
            ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                'Tipo Error
                TipoError = "PE022-2"
                If intSiguienteFolioNC.ToString <> "" Then
                    Comprobante.Folio = intSiguienteFolioNC.ToString
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (FOLIO): " & intSiguienteFolioNC.ToString & vbNewLine
                End If
            Else
                'Tipo Error
                TipoError = "PE022-3"
                Comprobante.Folio = "1"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (FOLIO): " & "1" & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE023"
            If strFormaPagoClave <> "" Then
                Comprobante.FormaPago = strFormaPagoClave
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (FORMA DE PAGO): " & strFormaPagoClave & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE024"
            If dtLugarEmision.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper <> "" Then
                Comprobante.LugarExpedicion = dtLugarEmision.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper '"91700"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (LUGAR DE EXPEDICION): " & dtLugarEmision.Rows(0).Item("CodigoPostal").ToString.Trim.ToUpper & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE025"
            If strMetodoPagoClave <> "" Then
                Comprobante.MetodoPago = strMetodoPagoClave
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (METODO DE PAGO): " & strMetodoPagoClave & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE026"
            If strMonedaClave <> "" Then
                Comprobante.Moneda = strMonedaClave
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (MONEDA): " & strMonedaClave & vbNewLine
            End If
            '*************************************************************************************
            ' Sección de variables para identificar y actualizar los datos del Cliente(Receptor).
            '*************************************************************************************
            'Tipo Error
            TipoError = "PE027"
            If strAreaServicioTimbrado = "PRUEBAS" Then
                Comprobante.Receptor = New FelTest.ReceptorR
            Else
                Comprobante.Receptor = New FelProd.ReceptorR
            End If
            'Tipo Error
            TipoError = "PE028"
            If dtCliente.Rows(0).Item("NombreCliente").ToString.Trim.ToUpper <> "" Then
                Comprobante.Receptor.Nombre = dtCliente.Rows(0).Item("NombreCliente").ToString.Trim.ToUpper       '"ASESORIA Y TRAMITACION ADUANAL, SC"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (RECEPTOR (NOMBRE)): " & dtCliente.Rows(0).Item("NombreCliente").ToString.Trim.ToUpper & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE029"
            If dtCliente.Rows(0).Item("RFC").ToString.Trim.ToUpper <> "" Then
                Comprobante.Receptor.Rfc = dtCliente.Rows(0).Item("RFC").ToString.Trim.ToUpper          '"XAXX010101000"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (RECEPTOR (RFC)): " & dtCliente.Rows(0).Item("RFC").ToString.Trim.ToUpper & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE030"
            If strUsoCFDIClave <> "" Then
                Comprobante.Receptor.UsoCFDI = strUsoCFDIClave
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (RECEPTOR (USO CFDI)): " & strUsoCFDIClave & vbNewLine
            End If
            '*************************************************************************************
            'Tipo Error
            TipoError = "PE031"
            If TipoDocumento = enTipoDocumento.Factura Then
                'Tipo Error
                TipoError = "PE031-1"
                If intSiguienteFolio.ToString <> "" Then
                    Comprobante.Referencia = strSerieFactura & intSiguienteFolio.ToString
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (REFERENCIA): " & strSerieFactura & intSiguienteFolio.ToString & vbNewLine
                End If
            ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                'Tipo Error
                TipoError = "PE031-2"
                If intSiguienteFolioNC.ToString <> "" Then
                    Comprobante.Referencia = strSerieFactura & intSiguienteFolioNC.ToString
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (REFERENCIA): " & strSerieFactura & intSiguienteFolioNC.ToString & vbNewLine
                End If
            Else
                'Tipo Error
                TipoError = "PE031-3"
                Comprobante.Folio = "26"
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (FOLIO): " & "26" & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE032"
            If strSerieFactura <> "" Then
                Comprobante.Serie = strSerieFactura
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (SERIE): " & strSerieFactura & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE033"
            If Descuento > 0 Then
                Comprobante.Descuento = Format(Math.Round(Descuento, 8), "#0.00")
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (DESCUENTO): " & Format(Math.Round(Descuento, 8), "#0.00") & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE034"
            If Format(Math.Round(SubTotal, 6), "#0.000000") > 0 Then
                Comprobante.SubTotal = Format(Math.Round(SubTotal, 8), "#0.00")
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (SUBTOTAL): " & Format(Math.Round(SubTotal, 8), "#0.00") & vbNewLine
            End If
            'Tipo Error
            TipoError = "PE035"
            If Format(Math.Round(Total, 6), "#0.000000") > 0 Then
                Comprobante.Total = Format(Math.Round(Total, 8), "#0.00")
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "COMPROBANTE (TOTAL): " & Format(Math.Round(Total, 8), "#0.00") & vbNewLine
            End If

            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "FINALIZANDO FACTURA........................................................." & vbNewLine
            'PRUEBA DE ESCRITURA BLOC DE NOTA

            'My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
            'Tipo Error
            TipoError = "PE036"
            If strAreaServicioTimbrado = "PRUEBAS" Then
                RespuestaServicio = New FelTest.RespuestaOperacionCR
            Else
                RespuestaServicio = New FelProd.RespuestaOperacionCR
            End If
            'Tipo Error
            TipoError = "PE037"
            If strTipoFactura = "GLOBAL" Then
                frmFacturaGlobalDiaria.lblTextoAnuncio.Text = "Esperando respuesta de timbrado..."
                frmFacturaGlobalDiaria.lblTextoAnuncio.Visible = True
                frmFacturaGlobalDiaria.lblTextoAnuncio.Refresh()
            Else
                frmFacturaIndividual.lblTextoAnuncio.Text = "Esperando respuesta de timbrado..."
                frmFacturaIndividual.lblTextoAnuncio.Visible = True
                frmFacturaIndividual.lblTextoAnuncio.Refresh()
            End If

            'GUARDO DATOS
            '------------------------------------------------
            If TipoDocumento = enTipoDocumento.Factura Then
                MarcaMovimientosFacturados(TipoDocumento, Datos)
            ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                MarcaMovimientosFacturados(TipoDocumento, Datos)
            End If
            '-----------------------------------------------------

            'Tipo Error
            TipoError = "PE046"
            'CONSULTA CREDITOS DISPONIBLES
            Dim NumCreditosFel As String = ""
            If Factura = "GLOBAL" Then
                NumCreditosFel = obtenerNoCreditos()
                If bolObtuvoCred Then
                    BuscaCreditosLimite()
                    If NumCreditosFel <= CreditosLimite Then
                        EnviarCorreo(NumCreditosFel)
                    End If
                Else
                    EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                    Exit Sub
                End If
            End If


            'NO HAY CREDITOS SALGO DE FUNCION
            If Factura = "GLOBAL" Then
                If NumCreditosFel = 0 Then
                    Exit Sub
                End If
            End If

            Try
                'MANDO FACTURA
                RespuestaServicio = ConexionRemota33.GenerarCFDI(datosUsuario, Comprobante)
                'SON 2 VARIABLES DE TIPO OBJETO QUE TRAEN LOS NODOS DEL WEB SERVICE, LOS DATOS DEL USUARIO Y LOS DATOS DEL COMPROBANTE
            Catch ex As Exception
                'Error #PE01000
                If strmodoFactura = "AUTOMATICA" Then
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error PE01000: " & ex.Message & vbNewLine
                    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                Else
                    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
                End If
            End Try
            'Tipo Error
            TipoError = "PE038"
            frmDatosClienteFacturacion.lblTextoAnuncio.Visible = False

            frmDatosClienteFacturacion.Cursor = Cursors.Default

            strNombreArchivoPDF = ""
            strNombreArchivoXML = ""
            'Tipo Error
            TipoError = "PE039"
            If RespuestaServicio.OperacionExitosa Then

BuscaDatos:
                Dim strCarpetaFacturas As String = VerificaCarpetaFacturacion(intNoSucursal, Comprobante.Fecha)
                strNombreArchivoXML = Format(intNoSucursal, "000") & "_" & FechaFact & "_" & Comprobante.ClaveCFDI & "_" & Format(CLng(Comprobante.Folio), "000000") & "_" & Comprobante.Serie & "_" & Comprobante.Receptor.Rfc & ".XML"
                strNombreArchivoPDF = Format(intNoSucursal, "000") & "_" & FechaFact & "_" & Comprobante.ClaveCFDI & "_" & Format(CLng(Comprobante.Folio), "000000") & "_" & Comprobante.Serie & "_" & Comprobante.Receptor.Rfc & ".PDF"

                Dim strDatosArchivoPDF As String = ""
                'Tipo Error
                TipoError = "PE040: Proceso de Guardar XML"
                'OBTENER XML
                If RespuestaServicio.XML IsNot Nothing Then
                    RespuestaoXML = RespuestaServicio.XML
                    GuardaXML(strCarpetaFacturas & "\" & strNombreArchivoXML, RespuestaoXML)
                End If
                If RespuestaServicio.CBB IsNot Nothing Then
                    CBB = RespuestaServicio.CBB
                End If
                'Tipo Error
                TipoError = "PE041"
                strUUID = GetXML(RespuestaoXML, "<tfd:TimbreFiscalDigital", "UUID", Chr(34))
                strFechaTimbrado = GetXML(RespuestaoXML, "<tfd:TimbreFiscalDigital", "FechaTimbrado", Chr(34))
                'Tipo Error
                TipoError = "PE042"
                'ACTUALIZO REGISTROS
                If TipoDocumento = enTipoDocumento.Factura Then
                    ActualizaMovimientosFacturados(TipoDocumento, intSiguienteFolio)
                ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                    ActualizaMovimientosFacturados(TipoDocumento, intSiguienteFolioNC)
                End If

                'GUARDAR FACTURA EN TABLAS
                'If TipoDocumento = enTipoDocumento.Factura Then
                '    MarcaMovimientosFacturados(TipoDocumento, Datos)
                'ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                '    MarcaMovimientosFacturados(TipoDocumento, Datos)
                'End If
                'Tipo Error
                TipoError = "PE043"
                'MENSAJE DE EXITO EN TIMBRADO
                'If strmodoFactura = "" Then
                If TipoDocumento = enTipoDocumento.Factura Then
                    If strmodoFactura = "AUTOMATICA" Then
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Factura generada con éxito!" & vbNewLine
                        My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    Else
                        MsgBox("Factura generada con éxito!", MsgBoxStyle.Exclamation, "Facturación")
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Factura generada con éxito!" & vbNewLine
                        My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    End If
                ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                    If strmodoFactura = "AUTOMATICA" Then
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Nota de Crédito generada con éxito!" & vbNewLine
                        My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    Else
                        MsgBox("Nota de Crédito generada con éxito!", MsgBoxStyle.Exclamation, "Facturación")
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Nota de Crédito generada con éxito!" & vbNewLine
                        My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    End If
                End If
                'End If
                'Tipo Error
                TipoError = "PE044"
                'OBTENER PDF
                If strAreaServicioTimbrado = "PRUEBAS" Then
                    oRespuestaPDF = New FelTest.RespuestaOperacionCR
                Else
                    oRespuestaPDF = New FelProd.RespuestaOperacionCR
                End If
                'Tipo Error
                TipoError = "PE045: Proceso de Guardar PDF"
                oRespuestaPDF = ConexionRemota33.ObtenerPDF(datosUsuario, strUUID, "")
                If oRespuestaPDF.OperacionExitosa Then
                    'Tipo Error
                    TipoError = "PE045-1"
                    Dim oDatosPDF() As Byte = Convert.FromBase64String(oRespuestaPDF.PDF)
                    Dim ms As MemoryStream = New MemoryStream
                    ms.Write(oDatosPDF, 0, oDatosPDF.Length)
                    My.Computer.FileSystem.WriteAllBytes(strCarpetaFacturas & "\" & strNombreArchivoPDF, oDatosPDF, False)
                    ms.Dispose()
                Else
                    'Tipo Error
                    TipoError = "PE045-2"
                    If strmodoFactura = "AUTOMATICA" Then
                        'ERROR #PE01201
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error General PE01201: " & vbNewLine & oRespuestaPDF.ErrorGeneral & vbNewLine & "Error Detallado: " & vbNewLine & oRespuestaPDF.ErrorDetallado & vbNewLine
                        My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                        EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                    Else
                        MsgBox("Error General: " & vbCrLf & vbCrLf & oRespuestaPDF.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & oRespuestaPDF.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                        texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error General PE01201: " & vbNewLine & oRespuestaPDF.ErrorGeneral & vbNewLine & "Error Detallado: " & vbNewLine & oRespuestaPDF.ErrorDetallado & vbNewLine
                        My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                        EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                    End If
                End If
                strEstatusGeneracion = "OK"

                ''Tipo Error
                'TipoError = "PE046"
                ''CONSULTA CREDITOS DISPONIBLES
                'If Factura = "GLOBAL" Then
                '    Dim NumCreditosFel As String = ""
                '    NumCreditosFel = obtenerNoCreditos()
                '    BuscaCreditosLimite()
                '    If NumCreditosFel <= CreditosLimite Then
                '        EnviarCorreo(NumCreditosFel)
                '    End If
                'End If


                'Tipo Error
                TipoError = "PE047"
                'ENVIA CORREO CON PDF Y XML
                If Factura = "INDIVIDUAL" Then
                    If correoFact <> "" Then
                        dtEmail.Clear()
                        dtEmail.Columns.Add("FolioFiscal", GetType(String))
                        dtEmail.Columns.Add("Estatus", GetType(String))

                        drEmail = dtEmail.NewRow
                        drEmail("FolioFiscal") = strUUID
                        drEmail("Estatus") = "A"
                        dtEmail.Rows.Add(drEmail)
                        dtEmail.AcceptChanges()
                        enviarEmail(dtEmail, correoFact)
                    End If
                End If

                'Tipo Error
                TipoError = "PE048"
                'ABRIR PDF
                If Factura = "INDIVIDUAL" Then
                    If File.Exists(strCarpetaFacturas & "\" & strNombreArchivoPDF) Then
                        Process.Start(strCarpetaFacturas & "\" & strNombreArchivoPDF)
                    Else
                        If strmodoFactura = "AUTOMATICA" Then
                            'ERROR #PE01203
                            texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error General PE01203: " & vbNewLine & oRespuestaPDF.ErrorGeneral & vbNewLine & "Error Detallado: " & vbNewLine & oRespuestaPDF.ErrorDetallado & vbNewLine
                            My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                        Else
                            MsgBox("No se pudo obtener el archivo PDF, descarguelo en Consulta de Facturas!", MsgBoxStyle.Exclamation, "Facturacion")
                        End If
                    End If
                End If

                'Tipo Error
                TipoError = "PE049"
                frmDatosClienteFacturacion.Cursor = Cursors.WaitCursor

            Else
                'Tipo Error
                TipoError = "PE050"
                If strmodoFactura = "AUTOMATICA" Then
                    'ERROR #PE01202
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "SUB-TOTAL: " & ImporteSub & vbNewLine
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error General PE01202: " & vbNewLine & RespuestaServicio.ErrorGeneral & vbNewLine & "Error Detallado: " & vbNewLine & RespuestaServicio.ErrorDetallado & vbNewLine
                    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                Else
                    MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "SUB-TOTAL: " & ImporteSub & vbNewLine
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error General PE01202: " & vbNewLine & RespuestaServicio.ErrorGeneral & vbNewLine & "Error Detallado: " & vbNewLine & RespuestaServicio.ErrorDetallado & vbNewLine
                    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End If
                'Tipo Error
                TipoError = "PE051"
                RespuestaoXML = RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado
                If TipoDocumento = enTipoDocumento.NotaCredito Then
                    errorNC = True
                Else
                    If strTipoFactura = "GLOBAL" Then
                        errorFG = True
                    End If
                End If
            End If

        Catch e As TimeoutException
            'Error #PE01100
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet & vbNewLine" & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
            Else
                MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
                If strTipoFactura = "GLOBAL" Then
                    frmFacturaGlobalDiaria.lblTextoAnuncio.Text = "Tratando de recuperar información..."
                    frmFacturaGlobalDiaria.lblTextoAnuncio.Visible = True
                    frmFacturaGlobalDiaria.lblTextoAnuncio.Refresh()
                Else
                    frmFacturaIndividual.lblTextoAnuncio.Text = "Tratando de recuperar información..."
                    frmFacturaIndividual.lblTextoAnuncio.Visible = True
                    frmFacturaIndividual.lblTextoAnuncio.Refresh()
                End If
            End If
            GoTo BuscaDatos
        Catch ex As Exception
            'Error #PE01200
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error PE01200--Tipo Error: " & TipoError & vbNewLine
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Descripcion Error VS: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If

        End Try
    End Sub

    Public Sub GeneraNotaCreditoIndividual(ByVal Datos As DataTable)
        Dim dtDatosParaNC, dtDatosNCAvr, dtDatNCAVR, drNvaBusAVR As New DataTable
        Dim drNew, drNuevo As DataRow
        Dim Respuesta As String = "", CodigoBarras As String = ""
        Dim strTicket As String = ""
        Dim bolPendienteGenerar As Boolean = False
        Dim strUUIDRelacionado As String = ""
        Dim dtClienteNC As New DataTable
        Dim EsAparatos(2) As String
        Dim yaRegistrado As Boolean = False
        Dim Concepto As String = ""
        Dim NvoConcepto As String = ""

        'guardando el cliente para la factura individual
        dtClienteNC = dtCliente.Copy

        'como se va a generar una nota de credito de una factura global, el cliente tiene que ser publico en general
        strTipoFactura = "GLOBAL"
        DatosCliente()
        strTipoFactura = "INDIVIDUAL"

        'si hay registros con marca de factura global, se procede a generar las notas de credito para cada uno
        Try
            'ESTRUCTURA DE LA TABLA
            dtDatosParaNC = New DataTable
            dtDatosParaNC = Datos.Clone

            dtDatosNCAvr = New DataTable
            dtDatosNCAvr = Datos.Clone

            dtDatNCAVR = New DataTable
            dtDatNCAVR = Datos.Clone

            drNvaBusAVR = New DataTable
            drNvaBusAVR = Datos.Clone

            'TOMO EL TICKET DEL PRIMER REGISTRO
            strTicket = Datos.Rows(0).Item("NoTicket").ToString.Trim.ToUpper
            bolPendienteGenerar = False

            Dim dv As New DataView
            dv = Datos.DefaultView
            dv.Sort = "UUIDFacturaGlobal"
            Dim Datos2 As New DataTable
            Datos2 = dv.Table
            strUUIDRelacionado = Datos2.Rows(0).Item("UUIDFacturaGlobal").ToString.Trim

            For Each dr As DataRow In Datos2.Rows
                EsAparatos = Split(dr("NoTicket").ToString, "-")
                If Not IsDBNull(dr("UUIDFacturaGlobal")) Then
                    If dr("UUIDFacturaGlobal").ToString.Trim <> "" Then
                        'tiene un uuid relacionado
                        If EsAparatos(0) = "A" Then
                            For Each dr1 As DataRow In dtDatNCAVR.Rows
                                If dr("Noticket") = dr1("NoTicket") Then
                                    yaRegistrado = True
                                End If
                            Next
                            If yaRegistrado = False Then
                                drNuevo = dtDatNCAVR.NewRow
                                drNuevo("Concepto") = "APARATOS AL CONTADO"
                                drNuevo("Fecha") = dr("Fecha")
                                drNuevo("Tipo") = dr("Tipo")
                                drNuevo("NoTicket") = dr("NoTicket")
                                drNuevo("TipoMov") = dr("TipoMov")
                                drNuevo("Importe") = dr("Importe")
                                drNuevo("Descuento") = dr("Descuento")
                                drNuevo("IVA") = dr("IVA")
                                drNuevo("Total") = dr("Total")
                                drNuevo("Costo") = dr("Costo")
                                drNuevo("ImportePagado") = dr("ImportePagado")
                                drNuevo("Interes") = dr("Interes")
                                drNuevo("Recargo") = dr("Recargo")
                                drNuevo("DescripcionSAT") = dr("DescripcionSAT")
                                dtDatNCAVR.Rows.Add(drNuevo)
                                dtDatNCAVR.AcceptChanges()
                            Else
                                yaRegistrado = False
                            End If
                        Else
                            If dr("UUIDFacturaGlobal").ToString.Trim = strUUIDRelacionado Then
                                'es el actual, se agrega el registro
                                drNew = dtDatosParaNC.NewRow
                                drNew("Concepto") = dr("Concepto")
                                drNew("Fecha") = dr("Fecha")
                                drNew("Tipo") = dr("Tipo")
                                drNew("NoTicket") = dr("NoTicket")
                                drNew("TipoMov") = dr("TipoMov")
                                drNew("Importe") = dr("Importe")
                                drNew("Descuento") = dr("Descuento")
                                drNew("IVA") = dr("IVA")
                                drNew("Total") = dr("Total")
                                drNew("Costo") = dr("Costo")
                                drNew("ImportePagado") = dr("ImportePagado")
                                drNew("Interes") = dr("Interes")
                                drNew("Recargo") = dr("Recargo")
                                drNew("DescripcionSAT") = dr("DescripcionSAT")
                                dtDatosParaNC.Rows.Add(drNew)
                                dtDatosParaNC.AcceptChanges()
                                bolPendienteGenerar = True
                            Else
                                'es diferente, se genera la nc para los que se agregaron
                                'GeneraFactura(enTipoDocumento.NotaCredito, dblImporte, dblDescuento, dblIVA, dblTotal, dtDatosParaNC, "", Respuesta, False, False, False, CodigoBarras, strUUIDRelacionado, "01", enTipoDocumentoAfectar.FacturaGlobal, )
                                bolPendienteGenerar = False
                                ObtenerParametros()
                                dtDatosParaNC = New DataTable
                                dtDatosParaNC = Datos.Clone
                                strTicket = dr("NoTicket").ToString.Trim.ToUpper
                                strUUIDRelacionado = dr("UUIDFacturaGlobal").ToString.Trim
                                'se agregan los datos para el registro actual
                                'se limpia la tabla
                                dtDatosParaNC = New DataTable
                                dtDatosParaNC = Datos.Clone
                                drNew = dtDatosParaNC.NewRow
                                drNew("Concepto") = dr("Concepto")
                                drNew("Fecha") = dr("Fecha")
                                drNew("Tipo") = dr("Tipo")
                                drNew("NoTicket") = dr("NoTicket")
                                drNew("TipoMov") = dr("TipoMov")
                                drNew("Importe") = dr("Importe")
                                drNew("Descuento") = dr("Descuento")
                                drNew("IVA") = dr("IVA")
                                drNew("Total") = dr("Total")
                                drNew("Costo") = dr("Costo")
                                drNew("ImportePagado") = dr("ImportePagado")
                                drNew("Interes") = dr("Interes")
                                drNew("Recargo") = dr("Recargo")
                                drNew("DescripcionSAT") = dr("DescripcionSAT")
                                dtDatosParaNC.Rows.Add(drNew)
                                dtDatosParaNC.AcceptChanges()
                                bolPendienteGenerar = True
                            End If
                        End If
                    End If
                End If
            Next dr

            dblSumaImporte = 0
            dblSumaDescuento = 0
            dblSumaIVA = 0
            dblSumaTotal = 0
            dblSumaInteres = 0
            dblSumaRecargo = 0
            dblSubtotal = 0

            ' GENERA NOTA DE CREDITO NORMAL PARA EMPEÑO Y JOYERIA
            If bolPendienteGenerar Then
                For Each dr As DataRow In dtDatosParaNC.Rows
                    dblSumaTotal += CDbl(dr("ImportePagado"))
                    dblSumaImporte += CDbl(dr("Importe"))
                    dblSumaDescuento += CDbl(dr("Descuento"))
                    dblSumaInteres += CDbl(dr("Interes"))
                    dblSumaRecargo += CDbl(dr("Recargo"))
                    dblSumaIVA += CDbl(dr("IVA"))
                Next
                dblSubtotal = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")

                'Para nota de Credito NORMAL
                GeneraFactura(enTipoDocumento.NotaCredito, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDatosParaNC, strCondicionesPago, Respuesta, False, False, False, CodigoBarras, strUUIDRelacionado, "01", enTipoDocumentoAfectar.FacturaGlobal, )
            End If

            dblSumaImporte = 0
            dblSumaDescuento = 0
            dblSumaIVA = 0
            dblSumaTotal = 0
            dblSumaInteres = 0
            dblSumaRecargo = 0
            dblSubtotal = 0

            'GENERA NOTA DE CREDITO CON AVR PARA APARATOS
            If dtDatNCAVR.Rows.Count > 0 Then
                drNvaBusAVR = NuevaBusquedaAVR(dtDatNCAVR)

                For Each dr As DataRow In drNvaBusAVR.Rows
                    Concepto = ""
                    NombreMov(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto)
                    dr("TipoMov") = Concepto
                Next dr

                dtDatosNCAvr = GeneraTablaDetAVR(drNvaBusAVR)

                For Each dr As DataRow In dtDatosNCAvr.Rows
                    Concepto = dr("Concepto").ToString
                    NombreMovFac(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto, Mid(dr("NoTicket").ToString, 1, 1), NvoConcepto)
                    dr("TipoMov") = NvoConcepto
                    dr("DescripcionSAT") = NvoConcepto
                Next dr

                For Each dr As DataRow In dtDatosNCAvr.Rows
                    dblSumaTotal += Math.Round(dr("ImportePagado"), 6)
                    dblSumaImporte += Math.Round(dr("Importe"), 6)
                    dblSumaDescuento += Math.Round(dr("Descuento"), 6)
                    dblSumaInteres += Math.Round(dr("Interes"), 6)
                    dblSumaRecargo += Math.Round(dr("Recargo"), 6)
                    dblSumaIVA += Math.Round(dr("IVA"), 6)
                Next

                dblSubtotal = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")

                'Para nota de Credito AVR
                GeneraFactura(enTipoDocumento.NotaCredito, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDatosNCAvr, strCondicionesPago, Respuesta, False, False, False, CodigoBarras, strUUIDRelacionado, "01", enTipoDocumentoAfectar.FacturaGlobal, )
            End If

            dtCliente = New DataTable
            dtCliente = dtClienteNC.Copy

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try
    End Sub

    Public Function GeneraTablaDetDev(ByVal Datos As DataTable) As DataTable
        Dim intFila As Integer = 0
        Dim SumoCosto As Boolean = False
        Dim dtReturn As New DataTable
        Dim drNew As DataRow

        dtReturn = dtDevsDeta.Clone
        Try
            For intFila = 0 To Datos.Rows.Count - 1
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
                    drNew("DocOriginal") = Datos.Rows(intFila).Item("DocOriginal").ToString
                    drNew("SerieOrigen") = Datos.Rows(intFila).Item("SerieOrigen").ToString
                    drNew("FolioOrigen") = Datos.Rows(intFila).Item("FolioOrigen").ToString
                    drNew("FechaOrigen") = Datos.Rows(intFila).Item("FechaOrigen").ToString
                    drNew("UUIDOriginal") = Datos.Rows(intFila).Item("UUIDOriginal").ToString
                    drNew("DescripcionSAT") = Datos.Rows(intFila).Item("DescripcionSAT").ToString
                    dtReturn.Rows.Add(drNew)
                    dtReturn.AcceptChanges()
                End If
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
                    drNew("DocOriginal") = Datos.Rows(intFila).Item("DocOriginal").ToString
                    drNew("SerieOrigen") = Datos.Rows(intFila).Item("SerieOrigen").ToString
                    drNew("FolioOrigen") = Datos.Rows(intFila).Item("FolioOrigen").ToString
                    drNew("FechaOrigen") = Datos.Rows(intFila).Item("FechaOrigen").ToString
                    drNew("UUIDOriginal") = Datos.Rows(intFila).Item("UUIDOriginal").ToString
                    drNew("DescripcionSAT") = Datos.Rows(intFila).Item("DescripcionSAT").ToString
                    dtReturn.Rows.Add(drNew)
                    dtReturn.AcceptChanges()
                End If
            Next intFila

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            GeneraTablaDetDev = dtReturn
        End Try
    End Function

    Public Function GeneraTablaDetAVR(ByVal Datos As DataTable) As DataTable
        Dim intFila As Integer = 0
        Dim SumoCosto As Boolean = False
        Dim dtReturn As New DataTable
        Dim drNew As DataRow

        dtReturn = dtDetalle.Clone
        Try
            For intFila = 0 To Datos.Rows.Count - 1
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
                    drNew("DescripcionSAT") = Datos.Rows(intFila).Item("DescripcionSAT").ToString
                    dtReturn.Rows.Add(drNew)
                    dtReturn.AcceptChanges()
                End If
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
                    drNew("DescripcionSAT") = Datos.Rows(intFila).Item("DescripcionSAT").ToString
                    dtReturn.Rows.Add(drNew)
                    dtReturn.AcceptChanges()
                End If
            Next intFila

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        Finally
            GeneraTablaDetAVR = dtReturn
        End Try
    End Function

    Public Sub GeneraNotasdeCredito(ByRef Respuesta As String, ByRef CodigoBarras As String)
        Dim strUUIDRelacionado As String = ""
        Dim strUUIDRelacionadoAVR As String = ""
        Dim arrUUIDRelacionados As New ArrayList
        Dim arrUUIDRelacionadosAVR As New ArrayList
        Dim sSQL As String = ""
        Dim tipoFact As String = ""
        Dim dtBusca As New DataTable
        Dim dtDetaNC, dtDetaNCInd, drNvaBusDevAVR As New DataTable
        Dim drNew, drNuevo As DataRow
        Dim dblImporte As Double = 0
        Dim dblDescuento As Double = 0
        Dim dblIVA As Double = 0
        Dim dblTotal As Double = 0
        Dim Concepto As String = ""
        Dim NvoConcepto As String = ""

        Try
            dblSumaImporte = 0
            dblSumaDescuento = 0
            dblSumaIVA = 0
            dblSumaTotal = 0
            dblSumaInteres = 0
            dblSumaRecargo = 0
            dblSubtotal = 0

            dtDetaNC = New DataTable
            dtDetaNCInd = New DataTable
            dtDetaNC = dtDevsDeta.Copy
            dtDetaNCInd = dtDevsDeta.Copy
            dtDetaNC.Rows.Clear()
            dtDetaNCInd.Rows.Clear()
            drNvaBusDevAVR = dtDevsDeta.Clone()

            'Dim Cuenta As Integer = 1
            For Each dr As DataRow In dtDevsDeta.Rows
                tipoFact = ""
                strUUIDRelacionado = ""
                strUUIDRelacionadoAVR = ""
                'BUSCANDO LA FACTURA TICKET EN LA FECHA DEL DOCUMENT0 ORIGEN
                Dim fechaOrigen As String = Mid(dr("FechaOrigen"), 1, 4) & Mid(dr("FechaOrigen"), 6, 2) & Mid(dr("FechaOrigen"), 9, 2)
                sSQL = "SELECT TOP 1 a.FolioFiscal,a.TipoFactura "
                sSQL &= "FROM BPFFacturas a "
                sSQL &= "INNER JOIN BPFFacturasPartidas b ON a.NoSucursal=b.NoSucursal AND a.Folio=b.Folio AND a.Serie=b.Serie AND a.TipoFactura=b.TipoFactura "
                sSQL &= "WHERE a.TipoComprobante = 'I' AND a.Estatus = 'A' AND b.FechaTicket = '" & fechaOrigen & "' and b.NoTicket = '" & dr("FolioOrigen") & "'"
                dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "Busca")
                If Not dtBusca Is Nothing AndAlso dtBusca.Rows.Count > 0 Then
                    tipoFact = dtBusca.Rows(0).Item("TipoFactura").ToString
                End If
                If tipoFact = "INDIVIDUAL" Then
                    strUUIDRelacionado = dtBusca.Rows(0).Item("FolioFiscal").ToString
                    If Not arrUUIDRelacionados.Contains(dtBusca.Rows(0).Item("FolioFiscal").ToString) And dr("Fecha") <> fechaOrigen Then
                        arrUUIDRelacionados.Add(dtBusca.Rows(0).Item("FolioFiscal").ToString)
                    End If
                    If strUUIDRelacionado <> "" Then
                        drNuevo = dtDetaNCInd.NewRow
                        drNuevo("Concepto") = dr("Concepto")
                        drNuevo("Fecha") = dr("Fecha")
                        drNuevo("Tipo") = dr("Tipo")
                        drNuevo("Prefijo") = dr("Prefijo")
                        drNuevo("NoTicket") = dr("NoTicket")
                        drNuevo("TipoMov") = dr("TipoMov")
                        drNuevo("Importe") = dr("Importe")
                        drNuevo("Descuento") = dr("Descuento")
                        drNuevo("IVA") = dr("IVA")
                        drNuevo("Total") = dr("Total")
                        drNuevo("Costo") = dr("Costo")
                        drNuevo("ImportePagado") = dr("ImportePagado")
                        drNuevo("Interes") = dr("Interes")
                        drNuevo("Recargo") = dr("Recargo")
                        drNuevo("DocOriginal") = dr("DocOriginal")
                        drNuevo("SerieOrigen") = dr("SerieOrigen")
                        drNuevo("FolioOrigen") = dr("FolioOrigen")
                        drNuevo("FechaOrigen") = dr("FechaOrigen")
                        drNuevo("UUIDOriginal") = strUUIDRelacionado
                        drNuevo("DescripcionSAT") = dr("DescripcionSAT")
                        dtDetaNCInd.Rows.Add(drNuevo)
                        dtDetaNCInd.AcceptChanges()
                    End If
                Else
                    If tipoFact = "GLOBAL" Then
                        strUUIDRelacionadoAVR = dtBusca.Rows(0).Item("FolioFiscal").ToString
                        If Not arrUUIDRelacionadosAVR.Contains(dtBusca.Rows(0).Item("FolioFiscal").ToString) And dr("Fecha") <> fechaOrigen Then
                            arrUUIDRelacionadosAVR.Add(dtBusca.Rows(0).Item("FolioFiscal").ToString)
                        End If
                        If strUUIDRelacionadoAVR <> "" And dr("Fecha") <> fechaOrigen Then
                            drNew = dtDetaNC.NewRow
                            drNew("Concepto") = dr("Concepto")
                            drNew("Fecha") = dr("Fecha")
                            drNew("Tipo") = dr("Tipo")
                            drNew("Prefijo") = dr("Prefijo")
                            drNew("NoTicket") = dr("NoTicket")
                            drNew("TipoMov") = dr("TipoMov")
                            drNew("Importe") = dr("Importe")
                            drNew("Descuento") = dr("Descuento")
                            drNew("IVA") = dr("IVA")
                            drNew("Total") = dr("Total")
                            drNew("Costo") = dr("Costo")
                            drNew("ImportePagado") = dr("ImportePagado")
                            drNew("Interes") = dr("Interes")
                            drNew("Recargo") = dr("Recargo")
                            drNew("DocOriginal") = dr("DocOriginal")
                            drNew("SerieOrigen") = dr("SerieOrigen")
                            drNew("FolioOrigen") = dr("FolioOrigen")
                            drNew("FechaOrigen") = dr("FechaOrigen")
                            drNew("UUIDOriginal") = strUUIDRelacionadoAVR
                            drNew("DescripcionSAT") = dr("DescripcionSAT")
                            dtDetaNC.Rows.Add(drNew)
                            dtDetaNC.AcceptChanges()
                        End If
                    End If
                End If
            Next dr

            If dtDetaNCInd.Rows.Count > 0 Then
                For Each dr As DataRow In dtDetaNCInd.Rows
                    Concepto = ""
                    NombreMov(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto)
                    dr("TipoMov") = Concepto
                Next dr

                dtDetalleDev = GeneraTablaDetDev(dtDetaNCInd)

                For Each dr As DataRow In dtDetalleDev.Rows
                    Concepto = dr("Concepto").ToString
                    NombreMovFac(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto, Mid(dr("NoTicket").ToString, 1, 1), NvoConcepto)
                    dr("TipoMov") = NvoConcepto
                    dr("DescripcionSAT") = NvoConcepto
                Next dr

                For Each dr As DataRow In dtDetalleDev.Rows
                    dblSumaTotal += Math.Round(dr("ImportePagado"), 6)
                    dblSumaImporte += Math.Round(dr("Importe"), 6)
                    dblSumaDescuento += Math.Round(dr("Descuento"), 6)
                    dblSumaInteres += Math.Round(dr("Interes"), 6)
                    dblSumaRecargo += Math.Round(dr("Recargo"), 6)
                    dblSumaIVA += Math.Round(dr("IVA"), 6)
                Next

                dblSubtotal = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")

                GeneraFactura(enTipoDocumento.NotaCredito, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetalleDev, strCondicionesPago, Respuesta, False, False, False, CodigoBarras, strUUIDRelacionado, "03", , arrUUIDRelacionados)
            End If

            dblSumaImporte = 0
            dblSumaDescuento = 0
            dblSumaIVA = 0
            dblSumaTotal = 0
            dblSumaInteres = 0
            dblSumaRecargo = 0
            dblSubtotal = 0

            If dtDetaNC.Rows.Count > 0 Then
                drNvaBusDevAVR = NuevaBusquedaAVR(dtDetaNC)

                For Each dr As DataRow In drNvaBusDevAVR.Rows
                    Concepto = ""
                    NombreMov(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto)
                    dr("TipoMov") = Concepto
                Next dr

                dtDetDevAvr = GeneraTablaDetDev(drNvaBusDevAVR)

                For Each dr As DataRow In dtDetDevAvr.Rows
                    Concepto = dr("Concepto").ToString
                    NombreMovFac(dr("Tipo").ToString, dr("TipoMov").ToString, Concepto, Mid(dr("NoTicket").ToString, 1, 1), NvoConcepto)
                    dr("TipoMov") = NvoConcepto
                    dr("DescripcionSAT") = NvoConcepto
                Next dr

                For Each dr As DataRow In dtDetDevAvr.Rows
                    dblSumaTotal += Math.Round(dr("ImportePagado"), 6)
                    dblSumaImporte += Math.Round(dr("Importe"), 6)
                    dblSumaDescuento += Math.Round(dr("Descuento"), 6)
                    dblSumaInteres += Math.Round(dr("Interes"), 6)
                    dblSumaRecargo += Math.Round(dr("Recargo"), 6)
                    dblSumaIVA += Math.Round(dr("IVA"), 6)
                Next

                dblSubtotal = Format((dblSumaTotal + dblSumaDescuento) - dblSumaIVA, "$ #,##0.00")

                GeneraFactura(enTipoDocumento.NotaCredito, dblSubtotal, dblSumaDescuento, dblSumaIVA, dblSumaTotal, dtDetDevAvr, strCondicionesPago, Respuesta, False, False, False, CodigoBarras, strUUIDRelacionadoAVR, "03", , arrUUIDRelacionadosAVR)
            End If

            ObtenerParametros()

        Catch ex As Exception
            'MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion - Genera Notas de Crédito")
        End Try
    End Sub

    Public Function FolioFiscalOrigen(ByVal FechaDocumentoOrigen As String, ByVal ImporteMinimo As Double, ByVal FechaFacturaActual As String, Optional ByVal Primero As Boolean = True) As String
        Dim strReturn As String = ""
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim strFechaFacturaActual As String = FechaFacturaActual
        Dim strFechaParaBuscar As String = ""

        Try

            If Primero Then
                strFechaParaBuscar = FechaDocumentoOrigen
            Else
                strFechaParaBuscar = strFechaFacturaActual
            End If
            'buscando en la tabla local de la sucursal el documeno original de acuerdo a la fecha
            sSQL = "SELECT a.FolioFiscal, a.ImporteTotal "
            sSQL &= "FROM BPFFacturas a "
            sSQL &= "WHERE CONVERT(VARCHAR(10),a.FechaFactura,120)='" & strFechaParaBuscar & "' "

            dtBusca = New DataTable
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "Relacionado")

            If Not dtBusca Is Nothing AndAlso dtBusca.Rows.Count > 0 Then
                'si lo encontró, validar el importe
                If dtBusca.Rows(0).Item("ImporteTotal") >= ImporteMinimo Then
                    'si cumple el importe
                    strReturn = dtBusca.Rows(0).Item("FolioFiscal").ToString
                    Exit Function
                Else
                    'no cumple el importe, buscar otro
                    strReturn = FolioFiscalOrigen(FechaDocumentoOrigen, ImporteMinimo, strFechaParaBuscar, False)
                    Exit Function
                End If
            Else
                'no lo encontró, buscar otro
                strReturn = FolioFiscalOrigen(FechaDocumentoOrigen, ImporteMinimo, Format(CDate(strFechaFacturaActual).AddDays(-1), "yyyy-MM-dd"), False)
                Exit Function
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion - FoliofiscalOrigen")
        Finally
            FolioFiscalOrigen = strReturn
        End Try
    End Function

    Public Function NuevaBusquedaAVR(ByVal nvaBusqueda As DataTable) As DataTable
        Dim SQL As String = ""
        Dim nvoParam(12) As SqlClient.SqlParameter
        Dim drNuevo As DataRow
        Dim nvoDetalleNormal, nvaBusAVR As DataTable
        Dim sbuscaTicket(2) As String

        nvoDetalleNormal = nvaBusqueda.Clone
        nvaBusAVR = nvaBusqueda.Clone

        SQLServer.Init(, strBDAQGlobal, strServerAQ, strUsrAQ, strPwdAQ)
        SQL = "sps_AVR_FacturaGlobal"

        Try
            If Sistema = "ADMINPAQ" Then
                For Each dr As DataRow In nvaBusqueda.Rows
                    sbuscaTicket = Split(dr("NoTicket").ToString, "-")

                    nvoParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                    nvoParam(1) = New SqlClient.SqlParameter("@pFechaIni", DBNull.Value)
                    nvoParam(2) = New SqlClient.SqlParameter("@pFechaFin", DBNull.Value)
                    nvoParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                    nvoParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", LTrim(sbuscaTicket(1)))
                    nvoParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                    nvoParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
                    nvoParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "INDIVIDUAL")
                    nvoParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ / 100)
                    nvoParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", DBNull.Value)
                    nvoParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DBNull.Value)
                    nvoParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", DBNull.Value)
                    nvoParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
                    nvaBusAVR = SQLServer.ExecSPReturnDT(SQL, nvoParam, "Detalle")

                    If Not nvaBusAVR Is Nothing AndAlso nvaBusAVR.Rows.Count > 0 Then
                        For Each dr1 As DataRow In nvaBusAVR.Rows
                            drNuevo = nvoDetalleNormal.NewRow
                            drNuevo("Concepto") = dr1("Concepto")
                            drNuevo("Fecha") = dr1("Fecha")
                            drNuevo("Tipo") = dr1("Tipo")
                            drNuevo("Prefijo") = dr1("Prefijo")
                            drNuevo("NoTicket") = dr1("NoTicket")
                            drNuevo("TipoMov") = dr1("TipoMov")
                            drNuevo("Importe") = dr1("Importe")
                            drNuevo("Costo") = dr1("Costo")
                            drNuevo("Descuento") = dr1("Descuento")
                            drNuevo("Total") = dr1("Total")
                            drNuevo("ImportePagado") = dr1("ImportePagado")
                            drNuevo("Interes") = dr1("Interes")
                            drNuevo("Recargo") = dr1("Recargo")
                            drNuevo("IVA") = dr1("IVA")
                            drNuevo("DescripcionSAT") = dr1("DescripcionSAT")
                            nvoDetalleNormal.Rows.Add(drNuevo)
                            nvoDetalleNormal.AcceptChanges()
                        Next dr1
                    End If
                Next
            Else
                For Each dr As DataRow In nvaBusqueda.Rows
                    nvoParam(0) = New SqlClient.SqlParameter("@pNoSucursal", intNoSucursal)
                    nvoParam(1) = New SqlClient.SqlParameter("@pFechaIni", DBNull.Value)
                    nvoParam(2) = New SqlClient.SqlParameter("@pFechaFin", DBNull.Value)
                    nvoParam(3) = New SqlClient.SqlParameter("@pFolioBoleta", DBNull.Value)
                    nvoParam(4) = New SqlClient.SqlParameter("@pFolioOperacion", dr("FolioOrigen"))
                    nvoParam(5) = New SqlClient.SqlParameter("@pNombreCliente", DBNull.Value)
                    nvoParam(6) = New SqlClient.SqlParameter("@pSerieDoc", DBNull.Value)
                    nvoParam(7) = New SqlClient.SqlParameter("@pTipoFactura", "INDIVIDUAL")
                    nvoParam(8) = New SqlClient.SqlParameter("@pIva", ivaAJ / 100)
                    nvoParam(9) = New SqlClient.SqlParameter("@pCodigoSatInt", DBNull.Value)
                    nvoParam(10) = New SqlClient.SqlParameter("@pDescricionSatInt", DBNull.Value)
                    nvoParam(11) = New SqlClient.SqlParameter("@pCodigoSatApa", DBNull.Value)
                    nvoParam(12) = New SqlClient.SqlParameter("@pDescricionSatApa", DescApaSat)
                    nvaBusAVR = SQLServer.ExecSPReturnDT(SQL, nvoParam, "Detalle")

                    If Not nvaBusAVR Is Nothing AndAlso nvaBusAVR.Rows.Count > 0 Then
                        For Each dr1 As DataRow In nvaBusAVR.Rows
                            drNuevo = nvoDetalleNormal.NewRow
                            drNuevo("Concepto") = dr("Concepto")
                            drNuevo("Fecha") = dr("Fecha")
                            drNuevo("Tipo") = dr("Tipo")
                            drNuevo("Prefijo") = dr("Prefijo")
                            drNuevo("NoTicket") = dr("NoTicket")
                            drNuevo("TipoMov") = dr("TipoMov")
                            drNuevo("Importe") = dr1("Importe")
                            drNuevo("Costo") = dr1("Costo")
                            drNuevo("Descuento") = dr1("Descuento")
                            drNuevo("Total") = dr1("Total")
                            drNuevo("ImportePagado") = dr1("ImportePagado")
                            drNuevo("Interes") = dr1("Interes")
                            drNuevo("Recargo") = dr1("Recargo")
                            drNuevo("IVA") = dr1("IVA")
                            drNuevo("DocOriginal") = dr("DocOriginal")
                            drNuevo("SerieOrigen") = dr("SerieOrigen")
                            drNuevo("FolioOrigen") = dr("FolioOrigen")
                            drNuevo("FechaOrigen") = dr("FechaOrigen")
                            drNuevo("UUIDOriginal") = dr("UUIDOriginal")
                            drNuevo("DescripcionSAT") = dr("DescripcionSAT")
                            nvoDetalleNormal.Rows.Add(drNuevo)
                            nvoDetalleNormal.AcceptChanges()
                        Next dr1
                    End If
                Next
            End If

            ConectaBD()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        Finally
            NuevaBusquedaAVR = nvoDetalleNormal
        End Try
    End Function

    Public Sub cancelaFactura(ByVal Datos As DataTable)
        Dim RespuestaAcuse As String = ""
        Dim strNombreArchivoXML As String = ""
        Dim fecha As Date
        Dim claveCFDI As String = ""
        Dim strCarpetaFacturas As String = ""
        Dim oRespuestaPDF As Object
        Dim oRespuestaXML As Object
        Dim uuidpdf As String = ""
        Dim datosUsuario As Object
        Dim ConexionRemota33 As Object
        Dim RespuestaServicio As Object

        seCancelo = False
        conAcuse = False
        Try

            If strAreaServicioTimbrado = "PRUEBAS" Then
                ConexionRemota33 = New FelTest.ConexionRemotaClient
            Else
                ConexionRemota33 = New FelProd.ConexionRemotaClient
            End If

            If strAreaServicioTimbrado = "PRUEBAS" Then
                datosUsuario = New FelTest.Credenciales
            Else
                datosUsuario = New FelProd.Credenciales
            End If

            If strAreaServicioTimbrado = "PRUEBAS" Then
                RespuestaServicio = New FelTest.RespuestaOperacionCR
            Else
                RespuestaServicio = New FelProd.RespuestaOperacionCR
            End If

            Dim ListaUUID As List(Of String) = New List(Of String)()


            datosUsuario.Cuenta = strCuentaServicioTimbrado
            datosUsuario.Password = strContrasenaServicioTimbrado
            datosUsuario.Usuario = strUsuarioServicioTimbrado


            For Each dr As DataRow In Datos.Rows
                fecha = CDate(Mid(dr("FechaFactura"), 7, 2) & "/" & Mid(dr("FechaFactura"), 5, 2) & "/" & Mid(dr("FechaFactura"), 1, 4))
                strCarpetaFacturas = VerificaCarpetaFacturacion(intNoSucursal, fecha)
                If dr("TipoFactura") = "INDIVIDUAL" Or dr("TipoFactura") = "GLOBAL" Then
                    claveCFDI = "FAC"
                Else
                    claveCFDI = "CRE"
                End If
                strNombreArchivoXML = Format(intNoSucursal, "000") & "_" & Format(fecha, "yyyyMMdd") & "_" & claveCFDI & "_" & Format(dr("Folio"), "000000") & "_" & dr("Serie") & "_" & dr("RFC") & "_CANCELADA" & ".XML"
                strNombreArchivoPDF = Format(intNoSucursal, "000") & "_" & Format(fecha, "yyyyMMdd") & "_" & claveCFDI & "_" & Format(dr("Folio"), "000000") & "_" & dr("Serie") & "_" & dr("RFC") & "_CANCELADA" & ".PDF"
                ListaUUID.Add(dr("FolioFiscal"))
                uuidpdf = dr("FolioFiscal")
            Next

            RespuestaServicio = ConexionRemota33.CancelarCFDIsConValidacion(datosUsuario, ListaUUID.ToArray())

            If RespuestaServicio.OperacionExitosa = True Then

                oRespuestaXML = New FelProd.RespuestaCancelacionCR
                oRespuestaXML = ConexionRemota33.ObtenerAcuseCancelacion(datosUsuario, uuidpdf)
                If oRespuestaXML.XML IsNot Nothing Then
                    RespuestaAcuse = oRespuestaXML.XML
                    GuardaXML(strCarpetaFacturas & "\" & strNombreArchivoXML, RespuestaAcuse)
                    conAcuse = True
                End If

                seCancelo = True
                MsgBox("Factura cancelada en el sistema!" & vbCrLf & vbCrLf & "El Proceso de Cancelación Fiscal para este movimiento se vera reflejado dentro de las siguientes 72 Horas.", MsgBoxStyle.Exclamation, "Facturación")

                oRespuestaPDF = New FelProd.RespuestaCancelacionCR
                oRespuestaPDF = ConexionRemota33.ObtenerPDF(datosUsuario, uuidpdf, "")
                If oRespuestaPDF.OperacionExitosa Then
                    Dim oDatosPDF() As Byte = Convert.FromBase64String(oRespuestaPDF.PDF)
                    Dim ms As MemoryStream = New MemoryStream
                    ms.Write(oDatosPDF, 0, oDatosPDF.Length)
                    My.Computer.FileSystem.WriteAllBytes(strCarpetaFacturas & "\" & strNombreArchivoPDF, oDatosPDF, False)

                    ms.Dispose()
                Else
                    MsgBox("No se pudo obtener el archivo PDF de Cancelación, por favor avise a sistemas!", MsgBoxStyle.Exclamation, "Facturacion - Obtener PDF")
                End If

            Else
                MsgBox("Error General: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorGeneral & vbCrLf & vbCrLf & "Error Detallado: " & vbCrLf & vbCrLf & RespuestaServicio.ErrorDetallado & vbCrLf & vbCrLf & "Por favor avise a sistemas", MsgBoxStyle.Exclamation, "Facturación")
            End If

        Catch e As TimeoutException
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Tiempo de espera demasiado largo para realizar la operación, puede deberse a lentitud o falla en el servicio de internet, por favor avise a sistemas", MsgBoxStyle.Critical, "Facturacion")
        Catch ex As Exception
            frmDatosClienteFacturacion.Cursor = Cursors.Default
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
        End Try

    End Sub

    Private Sub equis()
        Dim DirPfx As String = ""       'RUTA AL ARCHIVO DE CERTIFICADO
        Dim PASSWORD As String = ""     'CONTRASEÑA DEL ARCHIVO CERTIFICADO
        Dim GenerarSello As String
        Dim privateCert As New X509Certificate2(DirPfx, PASSWORD, X509KeyStorageFlags.Exportable)
        Dim privateKey As RSACryptoServiceProvider = DirectCast(privateCert.PrivateKey, RSACryptoServiceProvider)
        Dim privateKey1 As New RSACryptoServiceProvider()
        privateKey1.ImportParameters(privateKey.ExportParameters(True))
        Dim stringCadenaOriginal() As Byte = System.Text.Encoding.UTF8.GetBytes("CADENAORIGNALGENERADA")
        Dim signature As Byte() = privateKey1.SignData(stringCadenaOriginal, "SHA256")
        Dim sello256 As String = Convert.ToBase64String(signature)
        'para verificar el sello
        Dim isValid As Boolean = privateKey1.VerifyData(stringCadenaOriginal, "SHA256", signature)
        GenerarSello = sello256
    End Sub

    Public Function Bytes2Image(ByVal bytes() As Byte) As Image
        If bytes Is Nothing Then Return Nothing
        '
        Dim ms As New MemoryStream(bytes)
        Dim bm As Bitmap = Nothing
        Try
            bm = New Bitmap(ms)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try
        Return bm
    End Function

    Public Function VerificaCarpetaFacturacion(ByVal NoSucursal As Integer, ByVal Fecha As Date) As String

        Dim strCarpetaAplicacion As String = ""
        Dim strCarpetaFacturas As String = ""

        If strmodoFactura <> "AUTOMATICA" Then
            Try
                strCarpetaAplicacion = "R:"
                strCarpetaFacturas = strCarpetaAplicacion & "\" & Format(NoSucursal, "000") & "\" & Format(Fecha, "yyyy") & "\" & Format(Fecha, "yyyyMM")

                If Not Directory.Exists(strCarpetaFacturas) Then
                    Directory.CreateDirectory(strCarpetaFacturas)
                End If

            Catch ex As Exception
                If strmodoFactura = "AUTOMATICA" Then
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: No existe Carpeta R: para almacenar Comprobante de Factura, favor de configurar "
                    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                    nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                    EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                Else
                    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Adminpaq EsperaActualizacion")
                End If
            Finally
                VerificaCarpetaFacturacion = strCarpetaFacturas
            End Try
        Else
            Try
                strCarpetaAplicacion = "D:"
                strCarpetaFacturas = strCarpetaAplicacion & "\" & "SAT-CFDI" & "\" & Format(NoSucursal, "000") & "\" & Format(Fecha, "yyyy") & "\" & Format(Fecha, "yyyyMM")

                If Not Directory.Exists(strCarpetaFacturas) Then
                    Directory.CreateDirectory(strCarpetaFacturas)
                End If

            Catch ex As Exception
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: No existe Carpeta D: para almacenar Comprobante de Factura, favor de configurar "
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
            Finally
                VerificaCarpetaFacturacion = strCarpetaFacturas
            End Try
        End If

    End Function

    Public Sub GuardaXML(ByVal NombreArchivoXML As String, ByVal DatosXML As String)

        Dim UTF8NoBOM As New UTF8Encoding()
        Dim sw As New StreamWriter(NombreArchivoXML, False, UTF8NoBOM)

        Try
            sw.Write(DatosXML)
            sw.Flush()
            sw.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, "Facturacion - GuardaXML")
        End Try
    End Sub

    Public Function GetXML(ByVal sXML As String, _
                       ByVal sTopPath As String, _
                       ByVal sToken As String, _
                       Optional ByVal sDel As String = "'", _
                       Optional ByVal iNum As Integer = 1) As String
        Dim iCntr As Integer
        Dim iPos As Integer
        Dim iMul As Integer
        Dim stemp As String
        Dim sValue As String
        Dim sPar() As String
        Dim strReturn As String
        'Dim sQuote() As String

        '
        ' see if there is a path
        '
        stemp = sXML                                            ' starting point

        If sTopPath = "" Then
            For iMul = 1 To iNum
                iPos = InStr(stemp, sToken)                     ' find the token
                If iPos = 0 Then
                    sValue = ""
                    strReturn = sValue
                End If
                stemp = Mid(stemp, iPos + Len(sToken))        ' start the string with only the token
            Next

            '
            ' parse off the delimiter
            '
            If sDel = ">" Then
                sPar = Split(stemp, ">")                         ' get value right of >
                sPar = Split(sPar(1), "<")                       ' get value left of <
                sValue = sPar(0)                                ' get value
            Else
                sPar = Split(stemp, sDel)                        ' split the delimiter
                sValue = sPar(1)                                ' get the value were looking for
            End If
        Else
            sPar = Split(sTopPath, "^")

            For iCntr = 0 To UBound(sPar)
                iPos = InStr(stemp, sPar(iCntr))                ' find the search token
                If iPos = 0 Then
                    sValue = ""
                    strReturn = sValue
                End If
                stemp = Mid(stemp, iPos + Len(sPar(iCntr)))   ' chip away
            Next

            For iMul = 1 To iNum
                iPos = InStr(stemp, sToken)                     ' find the token
                If iPos = 0 Then
                    sValue = ""
                    strReturn = sValue
                End If
                stemp = Mid(stemp, iPos + Len(sToken))        ' start the string with only the token
            Next

            If sDel = ">" Then
                sPar = Split(stemp, ">")                        ' get value right of >
                sPar = Split(sPar(1), "<")                      ' get value left of <
                sValue = sPar(0)                                ' get value
            Else
                sPar = Split(stemp, sDel)                       ' split the delimiter
                sValue = sPar(1)                                ' get the value
            End If
        End If

        sValue = Trim$(sValue)
        'sValue = sValue.Replace(Chr(11), "")                    ' remove lf
        'sValue = sValue.Replace(Chr(13), "")                    ' remove cr


        sValue = Replace(sValue, "&amp;", "&")
        sValue = Replace(sValue, "&apos;", "'")

        strReturn = sValue

        GetXML = strReturn

    End Function

    Public Sub AdminpaqEsperaActualizacion()
        Dim rs As New DataTable
        Try
            Do
                rs = New DataTable
                rs = SQLServer.ExecSQLReturnDT("SELECT DescLarga FROM PE.dbo.Catalogos WHERE CatalogoID=6 AND Elemento=1 AND DescLarga='SI'")
            Loop Until rs.Rows.Count <= 0
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Adminpaq EsperaActualizacion")
            End If

        End Try
    End Sub

    Public Function CodigoProductoSAT(ByVal TipoDocumento As enTipoDocumento, ByVal Concepto As String, ByVal TipoDocumentoAfectar As enTipoDocumentoAfectar) As String
        Dim sSQL As String = ""
        Dim dtCPSAT As New DataTable
        Dim strReturn As String = ""

        Try
            If TipoDocumento = enTipoDocumento.NotaCredito Then
                sSQL = "SELECT Valor4T AS Codigo FROM BPFCatalogos WHERE Tabla=101 AND UPPER(LTRIM(RTRIM(DescLarga)))='" & Concepto.Trim.ToUpper & "'"
            Else
                If strTipoFactura = "GLOBAL" Or TipoDocumentoAfectar = enTipoDocumentoAfectar.FacturaGlobal Then
                    sSQL = "SELECT Valor1T AS Codigo FROM BPFCatalogos WHERE Tabla=101 AND UPPER(LTRIM(RTRIM(DescLarga)))='" & Concepto.Trim.ToUpper & "'"
                Else
                    sSQL = "SELECT Valor3T AS Codigo FROM BPFCatalogos WHERE Tabla=101 AND UPPER(LTRIM(RTRIM(DescLarga)))='" & Concepto.Trim.ToUpper & "'"
                End If
            End If

            dtCPSAT = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")
            If Not dtCPSAT Is Nothing AndAlso dtCPSAT.Rows.Count > 0 Then
                strReturn = dtCPSAT.Rows(0).Item("Codigo").ToString.Trim.ToUpper
            End If

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If

        Finally
            CodigoProductoSAT = strReturn
        End Try
    End Function

    Public Sub BuscaCodyDescProd()
        Dim sSQL As String = ""
        Dim dtIASAT As New DataTable
        Try
            If Sistema = "EMPEÑO" Or Sistema = "" Then
                sSQL = "SELECT Valor3T, DescLarga FROM BPFCatalogos WHERE Tabla = 101 AND (Elemento = 1 or Elemento = 2)"
            End If
            If Sistema = "ADMINPAQ" Then
                sSQL = "SELECT Valor3T, DescLarga FROM BPFCatalogos WHERE Tabla = 101 AND (Elemento = 1 or Elemento = 2)"
            End If
            If Sistema = "JOYERIA" Then
                sSQL = "SELECT Valor3T, DescLarga FROM BPFCatalogos WHERE Tabla = 101 AND (Elemento = 1 or Elemento = 4)"
            End If
            dtIASAT = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")
            If Not dtIASAT Is Nothing AndAlso dtIASAT.Rows.Count > 0 Then
                CodIntSat = dtIASAT.Rows(0).Item("Valor3T").ToString
                DescIntSat = dtIASAT.Rows(0).Item("DescLarga").ToString.Trim.ToUpper
                CodApaSat = dtIASAT.Rows(1).Item("Valor3T").ToString
                DescApaSat = dtIASAT.Rows(1).Item("DescLarga").ToString.Trim.ToUpper
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If

        End Try
    End Sub

    Public Sub BuscaFechaLimite()
        Dim sSQL As String = ""
        Dim dtIASAT As New DataTable
        Try
            FechaLimite = ""
            sSQL = "SELECT CONVERT(VARCHAR(10),(GETDATE()) - (CONVERT(INTEGER,Valor1T)),102) AS FechaActual FROM BPFCatalogos WHERE Tabla = 109 and Elemento = 1"
            dtIASAT = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")

            If Not dtIASAT Is Nothing AndAlso dtIASAT.Rows.Count > 0 Then
                FechaLimite = Mid(dtIASAT.Rows(0).Item("FechaActual").ToString, 1, 4) & Mid(dtIASAT.Rows(0).Item("FechaActual").ToString, 6, 2) & Mid(dtIASAT.Rows(0).Item("FechaActual").ToString, 9, 2)
            End If

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If

        End Try
    End Sub

    Public Sub BuscaCreditosLimite()
        Dim strSQL As String = ""
        Dim dtcreLim As New DataTable
        Try
            CreditosLimite = ""
            strSQL = "SELECT Valor1T AS limiteCreditos FROM BPFCatalogos WHERE Tabla = 110 and Elemento = 1"
            dtcreLim = SQLServer.ExecSQLReturnDT(strSQL, "BPFCatalogos")

            If Not dtcreLim Is Nothing AndAlso dtcreLim.Rows.Count > 0 Then
                CreditosLimite = dtcreLim.Rows(0).Item("limiteCreditos").ToString
            End If

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If
        End Try
    End Sub

    Public Function BuscaIvaSuc(ByVal ivaSuc As Double) As Double
        Dim sSQL As String = ""
        Dim dtIvaSuc As New DataTable
        Dim strReturn As Double = 0.0
        Try
            sSQL = "USE BDSPEXPRESS SELECT Iva FROM BPFCatalogoSucursales"
            dtIvaSuc = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")
            If Not dtIvaSuc Is Nothing AndAlso dtIvaSuc.Rows.Count > 0 Then
                strReturn = Convert.ToDouble(dtIvaSuc.Rows(0).Item("Iva"))
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If
        Finally
            BuscaIvaSuc = strReturn
        End Try
    End Function

    Public Function CodigoUMSAT(ByVal TipoDocumento As enTipoDocumento, ByVal Concepto As String, ByVal TipoDocumentoAfectar As enTipoDocumentoAfectar) As String
        Dim sSQL As String = ""
        Dim dtCPSAT As New DataTable
        Dim strReturn As String = ""

        Try
            If TipoDocumento = enTipoDocumento.NotaCredito Then
                sSQL = "SELECT UPPER(LTRIM(RTRIM(DescCorta))) AS Codigo FROM BPFCatalogos WHERE Tabla=102 AND UPPER(LTRIM(RTRIM(DescLarga)))='" & Concepto.Trim.ToUpper & "'"
            Else
                If strTipoFactura = "GLOBAL" Or TipoDocumentoAfectar = enTipoDocumentoAfectar.FacturaGlobal Then
                    sSQL = "SELECT UPPER(LTRIM(RTRIM(DescCorta))) AS Codigo FROM BPFCatalogos WHERE Tabla=102 AND UPPER(LTRIM(RTRIM(DescLarga)))='" & Concepto.Trim.ToUpper & "'"
                Else
                    sSQL = "SELECT Valor1T AS Codigo FROM BPFCatalogos WHERE Tabla=102 AND UPPER(LTRIM(RTRIM(DescLarga)))='" & Concepto.Trim.ToUpper & "' AND UPPER(LTRIM(RTRIM(Valor4T))) = 'INDIVIDUAL'"
                End If
            End If
            dtCPSAT = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")
            If Not dtCPSAT Is Nothing AndAlso dtCPSAT.Rows.Count > 0 Then
                strReturn = dtCPSAT.Rows(0).Item("Codigo").ToString.Trim.ToUpper
            End If

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If
        Finally
            CodigoUMSAT = strReturn
        End Try
    End Function

    Public Function CodigoUMPE(ByVal Concepto As String, ByVal TipoDocumentoAfectar As enTipoDocumentoAfectar) As String
        Dim sSQL As String = ""
        Dim dtCPPE As New DataTable
        Dim strReturn As String = ""

        Try
            If strTipoFactura = "GLOBAL" Or TipoDocumentoAfectar = enTipoDocumentoAfectar.FacturaGlobal Then
                sSQL = "SELECT Valor3T AS Codigo FROM BPFCatalogos WHERE Tabla=102 AND UPPER(LTRIM(RTRIM(DescLarga)))='" & Concepto.Trim.ToUpper & "' AND UPPER(LTRIM(RTRIM(Valor4T))) = 'GLOBAL'"
            Else
                sSQL = "SELECT Valor3T AS Codigo FROM BPFCatalogos WHERE Tabla=102 AND UPPER(LTRIM(RTRIM(DescLarga)))='" & Concepto.Trim.ToUpper & "' AND UPPER(LTRIM(RTRIM(Valor4T))) = 'INDIVIDUAL'"
            End If
            dtCPPE = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")
            If Not dtCPPE Is Nothing AndAlso dtCPPE.Rows.Count > 0 Then
                strReturn = dtCPPE.Rows(0).Item("Codigo").ToString.Trim.ToUpper
            End If
        Catch ex As Exception
            TipoError = TipoError & " Error en Codigo UMPE"
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If
        Finally
            CodigoUMPE = strReturn
        End Try
    End Function

    Public Sub DatosCliente(Optional ByVal NoCliente As Integer = 0, Optional ByVal TicketEmpeno As String = "")
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Try
            dtCliente = New DataTable
            If TicketEmpeno <> "" Then
                'buscando la operacion del ticket de empeño para obtener el cliente
                sSQL = ""
                sSQL = "SELECT a.FolioOperacion, b.NoCliente "
                sSQL &= "FROM BPFMovimientosCaja a "
                sSQL &= "INNER JOIN BPFBoletasPagosFijos b ON a.NoSucursal=b.NoSucursal AND a.Folio=b.Folio "
                sSQL &= "WHERE a.FolioOperacion = " & TicketEmpeno & " "
                sSQL &= "UNION ALL "
                sSQL &= "SELECT a.FolioOperacion, b.NoCliente "
                sSQL &= "FROM BPFPagosAcumulados a "
                sSQL &= "INNER JOIN BPFBoletasPagosFijos b ON a.NoSucursal=b.NoSucursal AND a.FolioBoleta=b.Folio "
                sSQL &= "WHERE a.FolioOperacion = " & TicketEmpeno & " "
                sSQL &= "UNION ALL "
                sSQL &= "SELECT a.FolioOperacion, b.NoCliente "
                sSQL &= "FROM BPFBoletasRecuperadas a "
                sSQL &= "INNER JOIN BPFBoletasPagosFijos b ON a.NoSucursal=b.NoSucursal AND a.FolioBoleta=b.Folio "
                sSQL &= "WHERE a.FolioOperacion = " & TicketEmpeno & " "
                dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "BuscaCliente")

                If Not dtBusca Is Nothing Then
                    If dtBusca.Rows.Count > 0 Then
                        If Not IsDBNull(dtBusca.Rows(0).Item("NoCliente")) Then
                            sSQL = ""
                            sSQL = "SELECT * FROM BDSPEXPRESS.dbo.BPFCatalogoClientes WHERE NoCliente=" & dtBusca.Rows(0).Item("NoCliente").ToString
                        End If
                    End If
                End If
            Else
                If strTipoFactura = "GLOBAL" Then
                    sSQL = "SELECT * FROM BDSPEXPRESS.dbo.BPFCatalogoClientes WHERE UPPER(LTRIM(RTRIM(NombreCliente))) LIKE '%PUBLICO EN GENERAL%';"
                Else
                    sSQL = "SELECT * FROM BDSPEXPRESS.dbo.BPFCatalogoClientes WHERE NoCliente=" & NoCliente.ToString
                End If
            End If
            dtCliente = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoClientes")
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                If strmodoFactura = "AUTOMATICA" Then
                    texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                    My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                    FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                    nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                    EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                    End
                Else
                    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion - Datos de Cliente")
                End If

            End If
        End Try
    End Sub

    Public Sub DatosLugarEmision()
        Dim sSQL As String = ""
        Try
            dtLugarEmision = New DataTable
            sSQL = "SELECT TOP 1 * FROM BDSPEXPRESS.dbo.BPFCatalogoSucursales WHERE SysKey=1;"
            dtLugarEmision = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoSucursales")

            dtOrganizacion = New DataTable
            sSQL = "SELECT TOP 1 * FROM BDSPEXPRESS.dbo.BPFCatalogoEmpresas;"
            dtOrganizacion = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogoSucursales")

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion - Datos de Lugar de Emision")
            End If
        End Try
    End Sub

    Public Sub MarcaMovimientosFacturados(ByVal TipoDocumento As enTipoDocumento, Optional ByVal Detalle As DataTable = Nothing)
        Dim sSQL As String = ""
        Dim intNoPartida As Integer = 1
        Dim fechaActual As String = ""
        If TipoCancelacion = "SUSTITUCION" Then
            fechaActual = FechaCancelado
        Else
            fechaActual = FechaFact
        End If
        Dim sTipoTicket(2) As String
        Dim subtotal As Double = 0
        'Dim Cuenta As Integer = 1
        Try
            'actualizando el folio utilizado
            If TipoDocumento = enTipoDocumento.Factura Then
                If MovBorrados = False Then
                    sSQL = "UPDATE BPFCatalogoSucursales SET UltimoFolioFactura=" & intSiguienteFolio.ToString
                    SQLServer.ExecSQL(sSQL)
                    'Actualizo UltimoFolio en Catalogos
                    sSQL = "UPDATE BPFCatalogos SET Valor3N=" & intSiguienteFolio.ToString & " WHERE Tabla = 38 AND Elemento = " & intElementoCata.ToString
                    SQLServer.ExecSQL(sSQL)
                End If
                'agregando el encabezado
                sSQL = "INSERT INTO BPFFacturas(NoSucursal,Folio,Serie,TipoFactura,TipoComprobante,FechaFactura,NoCliente,RFC,NombreCliente,ImporteAntesIVA,Descuento,ImporteIVA,ImporteTotal,FolioFiscal,FechaTimbrado,AltaUsu,AltaFecha,UsoCFDI,FormaPago,MetodoPago,Moneda,TipoRelacion,UUIDRelacionado,Estatus,MotivoCancelacion,Acuse,NombreArchivoPDF,NombreArchivoXML,EstatusFEL) "
                sSQL &= "VALUES (" & intNoSucursal.ToString & "," & IIf(TipoDocumento = enTipoDocumento.Factura, intSiguienteFolio.ToString, intSiguienteFolioNC.ToString) & ",'" & strSerieFactura & "','" & strTipoFactura & "','" & IIf(TipoDocumento = enTipoDocumento.Factura, "I", "E") & "','" & fechaActual & "'," & dtCliente.Rows(0).Item("NoCliente").ToString & ",'" & dtCliente.Rows(0).Item("RFC").ToString.Trim.ToUpper & "','" & dtCliente.Rows(0).Item("NombreCliente").ToString.Trim.ToUpper & "',"
                sSQL &= dblSubtotal.ToString & "," & dblSumaDescuento.ToString & "," & dblSumaIVA.ToString & "," & dblSumaTotal.ToString & ",'" & strUUID & "','" & strFechaTimbrado & "'," & strUsuario & ",GETDATE(),'" & strUsoCFDIClave & "','" & strFormaPagoClave & "','" & strMetodoPagoClave & "','" & strMonedaClave & "','" & TipoRelacionCancelado & "','" & CFDIRelacionadoCancelado & "','A','','','" & strNombreArchivoPDF & "','" & strNombreArchivoXML & "','P')"
                SQLServer.ExecSQL(sSQL)
                'agregando el detalle
                subtotal = 0
                For Each dr As DataRow In Detalle.Rows
                    sTipoTicket = Split(dr("NoTicket").ToString, "-")
                    subtotal = Format(dr("Importe") + dr("Interes") + dr("Recargo"), "$ #,##0.000000")
                    sSQL = "INSERT INTO BPFFacturasPartidas (NoSucursal,Folio,Serie,TipoFactura,TipoComprobante,NoPartida,Cantidad,TipoTicket,NoTicket,FechaTicket,Descripcion,ImporteAntesIVA,Descuento,ImporteIVA,ImporteTotal,AltaUsu,AltaFecha,EstatusFEL) "
                    sSQL &= "VALUES (" & intNoSucursal.ToString & "," & IIf(TipoDocumento = enTipoDocumento.Factura, intSiguienteFolio.ToString, intSiguienteFolioNC.ToString) & ",'" & strSerieFactura & "','" & strTipoFactura & "','" & IIf(TipoDocumento = enTipoDocumento.Factura, "I", "E") & "'," & intNoPartida.ToString & ",1,'" & sTipoTicket(0) & "'," & sTipoTicket(1) & ",'" & dr("Fecha").ToString & "','" & dr("DescripcionSAT").ToString & "'," & subtotal.ToString & "," & dr("Descuento").ToString & "," & dr("IVA").ToString & "," & dr("ImportePagado").ToString & "," & strUsuario & ",GETDATE(), 'P');"
                    SQLServer.ExecSQL(sSQL)
                    intNoPartida += 1
                Next dr
            ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                If MovBorrados = False Then
                    sSQL = "UPDATE BPFCatalogoSucursales SET UltimoFolioNotaCredito=" & intSiguienteFolioNC.ToString
                    SQLServer.ExecSQL(sSQL)
                    'Actualizo UltimoFolio en Catalogos
                    sSQL = "UPDATE BPFCatalogos SET Valor3N=" & intSiguienteFolioNC.ToString & " WHERE Tabla = 38 AND Elemento = " & intElementoCata.ToString
                    SQLServer.ExecSQL(sSQL)
                End If
                'agregando el encabezado
                sSQL = "INSERT INTO BPFFacturas(NoSucursal,Folio,Serie,TipoFactura,FechaFactura,NoCliente,RFC,NombreCliente,ImporteAntesIVA,Descuento,ImporteIVA,ImporteTotal,FolioFiscal,FechaTimbrado,AltaUsu,AltaFecha,TipoComprobante,UsoCFDI,FormaPago,MetodoPago,Moneda,TipoRelacion,UUIDRelacionado,Estatus,MotivoCancelacion,Acuse,NombreArchivoPDF,NombreArchivoXML,EstatusFEL) "
                sSQL &= "VALUES (" & intNoSucursal.ToString & "," & IIf(TipoDocumento = enTipoDocumento.Factura, intSiguienteFolio.ToString, intSiguienteFolioNC.ToString) & ",'" & strSerieFactura & "','" & strTipoFactura & "','" & fechaActual & "'," & dtCliente.Rows(0).Item("NoCliente").ToString & ",'" & dtCliente.Rows(0).Item("RFC").ToString.Trim.ToUpper & "','" & dtCliente.Rows(0).Item("NombreCliente").ToString.Trim.ToUpper & "',"
                sSQL &= dblSubtotal.ToString & "," & dblSumaDescuento.ToString & "," & dblSumaIVA.ToString & "," & dblSumaTotal.ToString & ",'" & strUUID & "','" & strFechaTimbrado & "'," & strUsuario & ",GETDATE(),'" & IIf(TipoDocumento = enTipoDocumento.Factura, "I", "E") & "','" & strUsoCFDIClave & "','" & strFormaPagoClave & "','" & strMetodoPagoClave & "','" & strMonedaClave & "','" & strTipoRel & "','" & strCFDIRel & "','A','','','" & strNombreArchivoPDF & "','" & strNombreArchivoXML & "','P')"
                SQLServer.ExecSQL(sSQL)
                'agregando el detalle
                subtotal = 0
                For Each dr As DataRow In Detalle.Rows
                    subtotal = Format(dr("Importe") + dr("Interes") + dr("Recargo"), "$ #,##0.000000")
                    sTipoTicket = Split(dr("NoTicket").ToString, "-")
                    sSQL = "INSERT INTO BPFFacturasPartidas (NoSucursal,Folio,Serie,TipoFactura,TipoComprobante,NoPartida,Cantidad,TipoTicket,NoTicket,FechaTicket,Descripcion,ImporteAntesIVA,Descuento,ImporteIVA,ImporteTotal,AltaUsu,AltaFecha,EstatusFEL) "
                    sSQL &= "VALUES (" & intNoSucursal.ToString & "," & IIf(TipoDocumento = enTipoDocumento.Factura, intSiguienteFolio.ToString, intSiguienteFolioNC.ToString) & ",'" & strSerieFactura & "','" & strTipoFactura & "','" & IIf(TipoDocumento = enTipoDocumento.Factura, "I", "E") & "'," & intNoPartida.ToString & ",1,'" & sTipoTicket(0) & "'," & sTipoTicket(1) & ",'" & dr("Fecha").ToString & "','" & dr("DescripcionSAT").ToString & "'," & subtotal.ToString & "," & dr("Descuento").ToString & "," & dr("IVA").ToString & "," & dr("ImportePagado").ToString & "," & strUsuario & ",GETDATE(), 'P');"
                    SQLServer.ExecSQL(sSQL)
                    intNoPartida += 1
                Next dr
            End If

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion - Marca Movimientos Facturados")
            End If

        End Try
    End Sub
    Public Sub ActualizaMovimientosFacturados(ByVal TipoDocumento As enTipoDocumento, ByVal FolioFactura As Integer)
        Dim sSQL As String = ""
        Try
            'actualizando el folio utilizado
            If TipoDocumento = enTipoDocumento.Factura Then
                sSQL = "UPDATE BPFFacturas SET EstatusFEL= 'F', FolioFiscal = '" & strUUID & "', FechaTimbrado = '" & strFechaTimbrado & "', NombreArchivoPDF = '" & strNombreArchivoPDF & "', NombreArchivoXML = '"& strNombreArchivoXML & "'  WHERE Folio = " & FolioFactura
                SQLServer.ExecSQL(sSQL)
                'Actualizo UltimoFolio en Catalogos
                sSQL = "UPDATE BPFFacturasPartidas SET EstatusFEL = 'F' WHERE Folio = " & FolioFactura
                SQLServer.ExecSQL(sSQL)
            ElseIf TipoDocumento = enTipoDocumento.NotaCredito Then
                sSQL = "UPDATE BPFFacturas SET EstatusFEL = 'F', FolioFiscal = '" & strUUID & "', FechaTimbrado = '" & strFechaTimbrado & "', NombreArchivoPDF = '" & strNombreArchivoPDF & "', NombreArchivoXML = '" & strNombreArchivoXML & "'  WHERE Folio = " & FolioFactura
                SQLServer.ExecSQL(sSQL)
                'Actualizo UltimoFolio en Catalogos
                sSQL = "UPDATE BPFFacturasPartidas SET EstatusFEL = 'F' WHERE Folio = " & FolioFactura
                SQLServer.ExecSQL(sSQL)
            End If

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion - Actualiza Movimientos Facturados")
            End If

        End Try
    End Sub
    Public Sub ValidaRedondeos(ByVal Cantidad As Double, _
                               ByVal DecimalesEnCantidad As Integer, _
                               ByVal ImporteAntesIVA As Double, _
                               ByVal DecimalesEnImporte As Integer, _
                               ByVal PorcentajeIVA As Double, _
                               ByRef IVA As Double, _
                               ByRef Total As Double)

        Dim dblLimiteInferiorVU As Double = 0
        Dim dblLimiteSuperiorVU As Double = 0
        Dim dblLimiteInferiorIVA As Double = 0
        Dim dblLimiteSuperiorIVA As Double = 0
        Dim dblDiferenciaLimitesIVA As Double = 0
        Dim dblTotalNuevo As Double = 0

        Try
            'obteniendo el limite inferior para valor unitario
            '(Cantidad - 10^-NumDecimalesCantidad/2)*(ValorUnitario - 10^-NumDecimalesValorUnitario/2)
            dblLimiteInferiorVU = (Cantidad - 10 ^ -DecimalesEnCantidad / 2) * (ImporteAntesIVA - 10 ^ -DecimalesEnImporte / 2)
            'obteniendo el limite superior para valor unitario
            '(Cantidad + 10^-NumDecimalesCantidad/2 -10^-12)*(ValorUnitario + 10^-NumDecimalesValorUnitario/2 -10^-12) 
            dblLimiteSuperiorVU = (Cantidad + 10 ^ -DecimalesEnCantidad / 2 - 10 ^ -12) * (ImporteAntesIVA + 10 ^ -DecimalesEnImporte / 2 - 10 ^ -12)
            'obteniendo el limite inferior para el iva
            '(Base - 10^-NumDecimalesBase /2)*(TasaOCuota)
            dblLimiteInferiorIVA = (ImporteAntesIVA - 10 ^ -DecimalesEnImporte / 2) * PorcentajeIVA
            'obteniendo el limite superior para el iva
            '(Base + 10^-NumDecimalesCantidad/2 - 10^-12) *(TasaOCuota)
            dblLimiteSuperiorIVA = (ImporteAntesIVA + 10 ^ -DecimalesEnImporte / 2 - 10 ^ -12) * PorcentajeIVA

            'verificando iva
            If IVA >= dblLimiteInferiorIVA And IVA <= dblLimiteSuperiorIVA Then
                'correcto, se queda todo así
            Else
                'incorrecto, recalcular iva y total

                dblDiferenciaLimitesIVA = dblLimiteSuperiorIVA - dblLimiteInferiorIVA
                dblDiferenciaLimitesIVA = dblDiferenciaLimitesIVA / 2
                IVA = dblLimiteInferiorIVA + dblDiferenciaLimitesIVA
                Total = ImporteAntesIVA + IVA
            End If

        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion - Valida Redondeos")
            End If
        End Try
    End Sub

    Public Function DameFormaPagoIDDefault() As Integer
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim intResult As Integer = 0
        Try
            If strTipoFactura = "GLOBAL" Then
                sSQL = "SELECT Elemento FROM BPFCatalogos WHERE Tabla=104 AND Elemento<>0 AND Valor3T='GLOBAL'"
            Else
                sSQL = "SELECT Elemento FROM BPFCatalogos WHERE Tabla=104 AND Elemento<>0 AND Valor4T='DEFAULT'"
            End If
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "FormasdePago")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    If Not IsDBNull(dtBusca.Rows(0).Item("Elemento")) Then
                        intResult = dtBusca.Rows(0).Item("Elemento")
                    End If
                End If
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If

        Finally
            DameFormaPagoIDDefault = intResult
        End Try
    End Function

    Public Function DameMonedaIDDefault() As Integer
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim intResult As Integer = 0
        Try
            If strTipoFactura = "GLOBAL" Then
                sSQL = "SELECT Elemento FROM BPFCatalogos WHERE Tabla=107 AND Elemento<>0 AND Valor3T='GLOBAL'"
            Else
                sSQL = "SELECT Elemento FROM BPFCatalogos WHERE Tabla=107 AND Elemento<>0 AND Valor4T='DEFAULT'"
            End If
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "Moneda")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    If Not IsDBNull(dtBusca.Rows(0).Item("Elemento")) Then
                        intResult = dtBusca.Rows(0).Item("Elemento")
                    End If
                End If
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If

        Finally
            DameMonedaIDDefault = intResult
        End Try
    End Function

    Public Function DameMetodoPagoIDDefault() As Integer
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim intResult As Integer = 0
        Try
            If strTipoFactura = "GLOBAL" Then
                sSQL = "SELECT Elemento FROM BPFCatalogos WHERE Tabla=103 AND Elemento<>0 AND Valor3T='GLOBAL'"
            Else
                sSQL = "SELECT Elemento FROM BPFCatalogos WHERE Tabla=103 AND Elemento<>0 AND Valor4T='DEFAULT'"
            End If
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "MetodoPago")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    If Not IsDBNull(dtBusca.Rows(0).Item("Elemento")) Then
                        intResult = dtBusca.Rows(0).Item("Elemento")
                    End If
                End If
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If
        Finally
            DameMetodoPagoIDDefault = intResult
        End Try
    End Function

    Public Function DameUsoCFDIIDDefault() As Integer
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim intResult As Integer = 0
        Try
            If strTipoFactura = "GLOBAL" Then
                sSQL = "SELECT Elemento FROM BPFCatalogos WHERE Tabla=105 AND Elemento<>0 AND Valor3T='GLOBAL'"
            Else
                sSQL = "SELECT Elemento FROM BPFCatalogos WHERE Tabla=105 AND Elemento<>0 AND Valor4T='DEFAULT'"
            End If
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "UsoCFDI")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    If Not IsDBNull(dtBusca.Rows(0).Item("Elemento")) Then
                        intResult = dtBusca.Rows(0).Item("Elemento")
                    End If
                End If
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If
        Finally
            DameUsoCFDIIDDefault = intResult
        End Try
    End Function
    Public Function DameCondicionesPagoIDDefault(ByVal CondPago, ByVal diasAplazados) As String
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Dim Result As String = ""
        Try
            sSQL = "SELECT * FROM BPFCatalogos WHERE Tabla=108 AND Elemento<>0 and DescLarga = '" & CondPago & "'"
            dtBusca = SQLServer.ExecSQLReturnDT(sSQL, "CondicionesPago")
            If Not dtBusca Is Nothing Then
                If dtBusca.Rows.Count > 0 Then
                    If Not IsDBNull(dtBusca.Rows(0).Item("Valor1T")) Then
                        If diasAplazados = "" Then
                            Result = dtBusca.Rows(0).Item("Valor1T")
                        Else
                            Result = dtBusca.Rows(0).Item("Valor1T")
                            Result = Result & " " & diasAplazados & " DIAS"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            If strmodoFactura = "AUTOMATICA" Then
                texto = texto & Format(Now, "HH:mm:ss").ToString & "~" & "Error: " & ex.Message & vbNewLine
                My.Computer.FileSystem.WriteAllText(nombreArchi, texto, True)
                FechaLog = Format(Now, "yyyy-MM-dd HH:mm").ToString
                nombreLog = "LogFactura_" & Format(intNoSucursal, "000").ToString & "_" & Format(Now, "yyyyMMddHHmm").ToString & ".txt"
                EnviarCorreoLOG(nombreLog, FechaLog, nombreArchi)
                End
            Else
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturacion")
            End If
        Finally
            DameCondicionesPagoIDDefault = Result
        End Try
    End Function
End Module

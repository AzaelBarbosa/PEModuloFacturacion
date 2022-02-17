
Public Class frmEnviarCorreo

    Public Sub guardaCorreo(ByVal datos As DataTable, ByVal correos As String)
        Dim sSQL As String = ""
        Dim dtBusca As New DataTable
        Try
            For Each dr As DataRow In dtEnviar.Rows
                sSQL = "UPDATE BDSPEXPRESS.dbo.BPFCatalogoClientes SET CorreoE = '" & correos & "' WHERE NoCliente = " & dr("NoCliente") & " and NombreCliente <> 'PUBLICO EN GENERAL'"
                SQLServer.ExecSQL(sSQL)
            Next
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Facturación")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEnviarCorreo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim separa() As String
        Dim separa1() As String
        Dim DatosEnviar As String = ""
        Dim CorreoGuardado As String = ""
        Me.BackgroundImage = Pantallazo
        Me.Text = "EnviarCorreo - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)

        For Each dr As DataRow In dtEnviar.Rows
            DatosEnviar = ""
            If dr("Estatus") = "A" Then
                DatosEnviar = "Asunto: Envio Comprobante CFDI" & vbNewLine
            Else
                DatosEnviar = "Asunto: Envio Comprobante de Cancelación" & vbNewLine
            End If
            DatosEnviar = DatosEnviar & "Factura: " & dr("Serie") & " " & dr("Folio") & vbNewLine
            DatosEnviar = DatosEnviar & "Folio Fiscal: " & dr("FolioFiscal") & vbNewLine
            If dr("Estatus") = "A" Then
                DatosEnviar = DatosEnviar & "PDF Adjunto: " & dr("NombreArchivoPDF") & vbNewLine
                DatosEnviar = DatosEnviar & "XML Adjunto: " & dr("NombreArchivoXML") & vbNewLine
            Else
                separa = Split(dr("NombreArchivoPDF"), ".")
                separa1 = Split(dr("NombreArchivoXML"), ".")
                DatosEnviar = DatosEnviar & "PDF Adjunto: " & separa(0) & "_CANCELADA." & separa(1) & vbNewLine
                DatosEnviar = DatosEnviar & "XML Adjunto: " & separa1(0) & "_CANCELADA." & separa1(1) & vbNewLine
            End If
            DatosEnviar = DatosEnviar & vbNewLine
            CorreoGuardado = dr("CorreoE")
        Next
        txtCorreo.Text = CorreoGuardado
        txtDatos.Text = DatosEnviar

    End Sub

    Private Sub btnEnviarEmail_Click(sender As Object, e As EventArgs) Handles btnEnviarEmail.Click
        'variables para almacenar el email destino, asunto
        'y mensaje a enviar
        Dim correo As String = txtCorreo.Text.Trim
        Dim asunto As String = "Envío electrónico de Comprobante Fiscal Digital"

        ErrorProvider1.Clear()

        If String.IsNullOrEmpty(correo) Then
            ErrorProvider1.SetError(txtCorreo, "Falta el correo del destinatario")

        End If
        If validar_Mail(LCase(txtCorreo.Text)) = False Then
            ErrorProvider1.SetError(txtCorreo, "Dirección de correo electronico invalida, el correo debe tener el formato: " & vbNewLine & _
                                    "nombre@dominio.com, por favor seleccione un correo valido")
            txtCorreo.Focus()
            txtCorreo.SelectAll()
            Exit Sub
        End If

        Try
            correo = txtCorreo.Text
            enviarEmail(dtEnviar, correo)
            guardaCorreo(dtEnviar, correo)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Excepción: " & ex.Message)
            Do Until (ex.InnerException Is Nothing)
                MessageBox.Show("Excepción interna: " & _
                    ex.InnerException.ToString())
                ex = ex.InnerException
            Loop
        End Try

    End Sub

    Private Sub btnEnviarEmail_MouseLeave(sender As Object, e As EventArgs) Handles btnEnviarEmail.MouseLeave
        Label2.Visible = False
    End Sub

    Private Sub btnEnviarEmail_MouseMove(sender As Object, e As MouseEventArgs) Handles btnEnviarEmail.MouseMove
        Label2.Visible = True
    End Sub

    Private Sub btnCancelar_MouseLeave(sender As Object, e As EventArgs) Handles btnCancelar.MouseLeave
        Label20.Visible = False
    End Sub

    Private Sub btnCancelar_MouseMove(sender As Object, e As MouseEventArgs) Handles btnCancelar.MouseMove
        Label20.Visible = True
    End Sub

End Class
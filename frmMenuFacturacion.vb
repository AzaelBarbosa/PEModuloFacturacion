Public Class frmMenuFacturacion
    Private Sub btnFacturaIndividual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFacturaIndividual.Click
        If frmFactInd Is Nothing Then
            frmFactInd = New frmFacturaIndividual
        End If
        strTipoFactura = "INDIVIDUAL"
        strmodoFactura = ""
        frmFactInd.ShowDialog()
        frmFactInd = Nothing
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        End
    End Sub

    Private Sub btnFacturaDiaria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFacturaDiaria.Click
        If frmFactGlbl Is Nothing Then
            frmFactGlbl = New frmFacturaGlobalDiaria
        End If
        strTipoFactura = "GLOBAL"
        strmodoFactura = ""
        frmFactGlbl.ShowDialog()
        frmFactGlbl = Nothing
    End Sub

    Private Sub btnManejoFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManejoFactura.Click
        If frmManFact Is Nothing Then
            frmManFact = New frmManejoFactura
        End If
        frmManFact.ShowDialog()
        frmManFact = Nothing
    End Sub

    Private Sub frmMenuFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        strmodoFactura = ""
        Me.BackgroundImage = Pantallazo
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        Me.Text = "Menú Facturación Electronica - Ver." & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        strTipoFactura = "GLOBAL"
        strmodoFactura = "AUTOMATICA"
        Dim frmFGA As New frmFacGlobalAutomatica
        frmFGA.ShowDialog()
        If frmFGA.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EnviarCorreoPrueba()
    End Sub
End Class
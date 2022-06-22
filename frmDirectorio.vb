Imports System.IO
Imports System

Public Class frmDirectorio



    Public Sub Proceso()
        Dim strFechaProceso As String
        Dim dtFechaProceso As Date
        Dim dir As New ArrayList
        Dim strRutaArchivosFactura As String
        Dim strFechaAnio As String
        Dim strFechaMes As String
        Dim strFechaDia As String
        Dim dtArchivos As Date

        Dim fileArray() As String
        Dim sSQL As String
        Dim dtParam As New DataTable
        Dim drParam As DataRow

        Try
            sSQL = "SELECT * FROM BPFCatalogos WHERE Tabla = 40 AND Elemento = 2"
            dtParam = SQLServer.ExecSQLReturnDT(sSQL, "BPFCatalogos")

            If dtParam Is Nothing OrElse dtParam.Rows.Count <= 0 Then
                End
            End If

            drParam = dtParam.Rows(0)

            strFechaProceso = drParam("Valor1T").ToString.Trim.ToUpper

            If strFechaProceso <> "" Then

                dtFechaProceso = CDate(Mid(strFechaProceso, 1, 4) & "/" & Mid(strFechaProceso, 5, 2) & "/" & Mid(strFechaProceso, 7, 2))

                strFechaAnio = Format(dtFechaProceso.Year, "#0000")
                strFechaMes = Format(dtFechaProceso.Month, "#00")
                strFechaDia = Format(dtFechaProceso.Day, "#00")


                strRutaArchivosFactura = "D:\SAT-CFDI\" & Format(intNoSucursal, "#000") & "\" & strFechaAnio & "\" & strFechaAnio & strFechaMes & "\"

                For Each File As String In Directory.GetFiles(strRutaArchivosFactura)
                    dir.Add(File)
                Next

                For i As Integer = 0 To dir.Count - 1

                    fileArray = dir.Item(i).ToString.Split("\")

                    dtArchivos = File.GetLastWriteTime(dir.Item(i))

                    If Not Directory.Exists(strRutaArchivosFactura & Format(dtArchivos.Day, "#00")) Then
                        Directory.CreateDirectory(strRutaArchivosFactura & Format(dtArchivos.Day, "#00"))
                    End If

                    My.Computer.FileSystem.MoveFile(dir.Item(i), strRutaArchivosFactura & Format(dtArchivos.Day, "#00") & "\" & fileArray(5).ToString)

                Next

                'MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Facturacion")
                End

            Else

                End

            End If

        Catch ex As Exception
            End
        End Try


    End Sub
    Private Sub frmDirectorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Proceso()

    End Sub
End Class
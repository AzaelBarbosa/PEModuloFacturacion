'Imports PESQLServer
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Management
Imports VB = Microsoft.VisualBasic

Public Enum enCoordImprDoc As Integer
    Factura = 1
End Enum

Public Enum eSexoMoneda
    Femenino '= 0
    Masculino '= 1
End Enum

Public Enum enTipoValidaNulo As Integer
    Texto = 1
    Numero
    Fecha
End Enum

Public Enum enAccionForma As Integer
    Nuevo = 1
    Buscar
    Modificar
    Guardar
    Eliminar
    Imprimir
    Entrega
    Lista
End Enum


Public Class Utilerias

    Public Shared SoloLetras As String = "abcdefghijklmnñopqrstuvwxyzáéíóú"
    Public Shared SoloNumeros As String = "01234567890"

    '
    'Variables usadas para convertir nueros a letras
    '
    'Declaradas a nivel de módulo
    Shared unidad(0 To 9) As String
    Shared decena(0 To 9) As String
    Shared centena(0 To 10) As String
    Shared deci(0 To 9) As String
    Shared otros(0 To 15) As String

    Private Shared m_Sexo1 As String
    Private Shared m_Sexo2 As String
    Private Shared m_LenSexo1 As Long

    Const chars = "ABCDEFGHIJKLMNOPQRSTyvwxyzabcdefghijklmnopqrstyvwxyz123456789"

    Public Shared Sub ConvierteGrafica(ByVal strModelo As String, ByVal intProveedor As Integer)
        Try
            Dim adorsSql1 As DataTable
            Dim strGrafica As String
            Dim sqltxt As String
            Dim MiImagen As Image

            'Dim pasoModelo As String
            'Convierte la foto a binario para que se pueda mostrar en el reporte
            'de Crystal Report en el detalle, se guarda en la tabla tblmodelos en el campo grafica


            sqltxt = "Select * from TblModelos  where modelo = '" & strModelo & "' and proveedor = " & intProveedor
            adorsSql1 = SQLServer.ExecSQLReturnDT(sqltxt, "TblModelos")

            If adorsSql1.Rows.Count <= 0 Then
                Exit Sub
            End If
            ''ruta+foto
            strGrafica = Trim(adorsSql1.Rows(0).Item("Ruta")) + Trim(adorsSql1.Rows(0).Item("Foto")) + ".jpg"

            If Not File.Exists(strGrafica) Then
                Exit Sub
            End If

            MiImagen = Image.FromFile(strGrafica)

            adorsSql1.Rows(0).Item("Grafica").Value = Image2Bytes(MiImagen)
            SQLServer.UpdateByDataTable(adorsSql1)
            adorsSql1.AcceptChanges()

        Catch ex As Exception
        End Try

    End Sub

    Public Shared Function FormatoFecha(ByVal StrFecha As String) As String

        Dim lnAnio As Integer, lnDia, lnMes

        lnAnio = DatePart("yyyy", StrFecha)
        lnDia = IIf(DatePart("d", StrFecha) < 10, "0", "") & DatePart("d", StrFecha)
        lnMes = IIf(DatePart("m", StrFecha) < 10, "0", "") & DatePart("m", StrFecha)

        FormatoFecha = lnAnio & "/" & lnMes & "/" & lnDia

    End Function


    Public Shared Function SiguienteConsecutivo(ByVal Seccion As Integer, ByVal Clave As Integer) As Integer

        Try

            SiguienteConsecutivo = -1

            Dim sSQL As String = "spsu_siguientecons"
            Dim oParam(1) As SqlClient.SqlParameter
            Dim dt As DataTable

            oParam(0) = New SqlClient.SqlParameter("@Seccion", Seccion)
            oParam(1) = New SqlClient.SqlParameter("@Clave", Clave)

            dt = SQLServer.ExecSPReturnDT(sSQL, oParam, "descripciones")

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0).Item(0)) Then
                SiguienteConsecutivo = dt.Rows(0).Item(0)
            End If

        Catch ex As Exception
        End Try
        Return False

    End Function

    Public Shared Sub Log(ByVal Mensaje As String, Optional ByVal Forma As String = "", Optional ByVal UsuarioID As Integer = 0)

        Using sw As StreamWriter = System.IO.File.AppendText("C:\LogR.txt")

            sw.WriteLine(Format(Now, "yyyy-MM-dd hh:mm:ss") + "~" + Mensaje + "~" + Forma + "~" + UsuarioID.ToString)

            sw.Flush()
            sw.Close()
        End Using

    End Sub

    Public Shared Sub ActualizaPwd(ByVal VendID As Integer, ByVal Password As String)

        Dim sSQL As String

        sSQL = "UPDATE m_vendedores SET vpwd='" + Password + "' WHERE vclave=" + VendID.ToString

        SQLServer.ExecSQL(sSQL)

    End Sub

    Public Shared Function CreaPwd(ByVal Longitud As Integer) As String
        Dim r, i
        Dim strReturn As String = ""

        For i = 1 To Longitud
            Randomize()
            r = Int((Rnd() * 61) + 1)
            strReturn = strReturn & Mid(chars, r, 1)
        Next i

        CreaPwd = strReturn

    End Function


    Public Shared Function QuitaDobleEspacio(ByVal Dato As String) As String

        Try

            Dim bolSale As Boolean
            Dim intPos As Integer
            Dim intPos1 As Integer
            Dim intPos2 As Integer
            Dim PASO As String

            bolSale = False

            Do

                PASO = Dato
                Do

                    intPos = InStr(PASO, "  ")
                    If intPos > 0 Then
                        PASO = Replace(PASO, "  ", " ")
                        bolSale = False
                    Else
                        bolSale = True
                    End If

                    intPos1 = InStr(PASO, Chr(13))
                    If intPos1 > 0 Then
                        PASO = Replace(PASO, Chr(13), " ")
                        bolSale = False
                    Else
                        bolSale = True
                    End If

                    intPos2 = InStr(PASO, Chr(10))
                    If intPos2 > 0 Then
                        PASO = Replace(PASO, Chr(10), " ")
                        bolSale = False
                    Else
                        bolSale = True
                    End If

                Loop Until intPos = 0 And intPos1 = 0 And intPos2 = 0

                PASO = Trim$(PASO)

            Loop Until bolSale

            QuitaDobleEspacio = PASO

        Catch ex As Exception
            QuitaDobleEspacio = Dato
        End Try

    End Function

    Public Shared Function QuitaAcentos(ByVal Dato As String) As String

        Try
            Dim strReturn As String
            strReturn = Dato

            strReturn.Replace("á", "a")
            strReturn.Replace("Á", "A")
            strReturn.Replace("é", "e")
            strReturn.Replace("É", "E")
            strReturn.Replace("í", "i")
            strReturn.Replace("Í", "I")
            strReturn.Replace("ó", "o")
            strReturn.Replace("Ó", "O")
            strReturn.Replace("ú", "u")
            strReturn.Replace("Ú", "U")

            QuitaAcentos = strReturn

        Catch ex As Exception
            QuitaAcentos = Dato
        End Try

    End Function

    '***************************************************
    ' FUNCIONES PARA CONVERTIR NUMEROS A LETRAS
    '***************************************************
    Public Shared Function NumeroALetra(ByVal strNum As String, _
                                Optional ByVal Lo As Long = 0&, _
                                Optional ByVal NumDecimales As Integer = 2&, _
                                Optional ByVal sMoneda As String = "", _
                                Optional ByVal sCentimos As String = "", _
                                Optional ByVal SexoMoneda As eSexoMoneda = eSexoMoneda.Femenino, _
                                Optional ByVal SexoCentimos As eSexoMoneda = eSexoMoneda.Masculino) As String
        '----------------------------------------------------------
        ' Convierte el número strNum en letras          (28/Feb/91)
        ' Versión para Windows                          (25/Oct/96)
        ' Variables estáticas                           (15/May/97)
        ' Parche de "Esteve" <esteve@mur.hnet.es>       (20/May/97)
        ' Revisión para decimales                       (10/Jul/97)
        ' Permite indicar el sexo de la moneda          ( 6/Ene/99)
        ' y de los centimos... nunca se sabe...
        ' Corregido fallo de los decimales cuando       (13/Ene/99)
        ' tienen ceros a la derecha.
        '
        ' La moneda debe especificarse en singular, ya que la función
        ' se encarga de convertirla en plural.
        ' Se puede indicar el número de decimales a devolver
        ' por defecto son dos.
        '----------------------------------------------------------
        ''Dim i As Long
        Dim iHayDecimal As Long             'Posición del signo decimal
        Dim sDecimal As String              'Signo decimal a usar
        Dim sDecimalNo As String            'Signo no decimal
        Dim sEntero As String
        Dim sFraccion As String
        Dim fFraccion As Single
        Dim sNumero As String
        Static SexoAntMoneda As eSexoMoneda
        ''Static SexoAntCentimos As eSexoMoneda
        Dim sSexoCents As String
        '
        sDecimal = ""
        sDecimalNo = ""
        ' Para tener en cuenta el sexo de los céntimos                  (20/Jul/00)
        ' m_Sexo2 se usa para indicar el plural de las monedas,
        ' sSexoCents sustituirá a esa variable cuando se calculen los céntimos
        If SexoCentimos = eSexoMoneda.Femenino Then
            sSexoCents = "as"
        Else
            sSexoCents = "os"
        End If
        '
        'Dependiendo del "sexo" indicado, usar las terminaciones
        If SexoMoneda = eSexoMoneda.Femenino Then
            m_Sexo1 = "a"
            m_Sexo2 = "as"
        Else
            m_Sexo1 = ""
            m_Sexo2 = "os"
        End If
        'por si se cambia en el trascurso el sexo de la moneda
        If SexoMoneda <> SexoAntMoneda Then
            unidad(1) = "" ' Aquí ponía: unidad(2) = ""                 (08/Sep/01)
            SexoAntMoneda = SexoMoneda
        End If
        m_LenSexo1 = Len(m_Sexo1)

        'Si se especifica, se usarán
        sMoneda = Trim$(sMoneda)
        If Len(Trim$(sMoneda)) Then
            sMoneda = " " & sMoneda & " "
        Else
            sMoneda = " "
        End If

        sCentimos = Trim$(sCentimos)
        If Len(Trim$(sCentimos)) Then
            sCentimos = " " & sCentimos & " "
        Else
            sCentimos = " "
        End If

        'Si no se especifica el ancho...
        '
        If Lo Then
            sNumero = Space$(Lo)
        Else
            sNumero = ""
        End If

        'Comprobar el signo decimal y devolver los adecuados a la config. regional
        strNum = ConvDecimal(strNum, sDecimal, sDecimalNo)

        'Comprobar si tiene decimales
        iHayDecimal = InStr(strNum, sDecimal)
        If iHayDecimal Then
            sEntero = Left$(strNum, iHayDecimal - 1)
            sFraccion = Mid$(strNum, iHayDecimal + 1) & StrDup(NumDecimales, "0")
            'obligar a que tenga dos cifras
            '
            'pero habría que redondear el resto...
            'por ejemplo:
            '   .256 sería .26 y
            '   .254 sería .25
            'Pero esto otro no se haría:
            '.25499 no pasaría a .255 y después a .26
            '
            '*sFraccion = Left$(sFraccion, NumDecimales + 1)
            '*fFraccion = Int((Val(sFraccion) / 100) * 10 + 0.5) * 10
            '*sFraccion = Left$(CStr(fFraccion), NumDecimales)
            '
            ' NO hacer cálculos de redondeo ni nada de nada             (08/Jul/00)
            '
            ' De esta forma se dirá:
            '   ,06 con seis
            '   ,50 con cincuenta
            '
            sFraccion = Left$(sFraccion, NumDecimales)
            '
            '* En las fracciones los ceros a la derecha no tienen significado
            '----------------------------------------------------------------------
            ' Pero si tenemos: 125.50 si que tiene significado,         (08/Jul/00)
            ' ya que tal y como está ahora, diría con 5 en lugar de cincuenta
            ' Así que si se ponen NumDecimales mayor de 2,
            ' hay que ser consecuentes con los resultados.
            '----------------------------------------------------------------------
            '*Do While Right$(sFraccion, 1) = "0"
            '*    sFraccion = Left$(sFraccion, Len(sFraccion) - 1)
            '*Loop
            '
            fFraccion = Val(sFraccion)
            ' Si no hay decimales... no agregar nada...
            If fFraccion < 1 Then
                If Len(Trim$(sMoneda)) Then
                    sMoneda = Pluralizar(sNumero, sMoneda)
                End If
                strNum = RTrim$(UnNumero(sEntero, m_Sexo1) & sMoneda)
                If Lo Then
                    ''LSet(sNumero = strNum)
                Else
                    sNumero = strNum
                End If
                NumeroALetra = sNumero
                Exit Function
            End If

            If Len(Trim$(sMoneda)) Then
                sMoneda = Pluralizar(sEntero, sMoneda)
            End If

            sEntero = UnNumero(sEntero, m_Sexo1)

            If Len(Trim$(sCentimos)) Then
                sCentimos = Pluralizar(sFraccion, sCentimos)
            End If

            ' Para el sexo de los decimales
            ' no se si esto puede cambiar, pero por si ocurre...
            '
            ' Sustituimos el plural de las monedas,                     (20/Jul/00)
            ' para adecuarla a los céntimos,
            ' ya que en España, la moneda es femenino, pero los céntimos masculino.
            m_Sexo2 = sSexoCents
            If SexoCentimos = eSexoMoneda.Masculino Then
                sFraccion = UnNumero(sFraccion, "")
            Else
                sFraccion = UnNumero(sFraccion, "a")
            End If
            '
            strNum = sEntero & sMoneda & "con " & sFraccion & sCentimos
            If Lo Then
                ''LSet(sNumero = RTrim$(strNum))
            Else
                sNumero = RTrim$(strNum)
            End If
            NumeroALetra = sNumero
        Else
            If Len(Trim$(sMoneda)) Then
                sMoneda = Pluralizar(strNum, sMoneda)
            End If
            strNum = RTrim$(UnNumero(strNum, m_Sexo1) & sMoneda)
            If Lo Then
                ''LSet(sNumero = strNum)
            Else
                sNumero = strNum
            End If
            NumeroALetra = sNumero
        End If
    End Function

    Private Shared Function UnNumero(ByVal strNum As String, ByVal Sexo1 As String) As String
        '----------------------------------------------------------
        'Esta es la rutina principal                    (10/Jul/97)
        'Está separada para poder actuar con decimales
        '----------------------------------------------------------
        Dim dblNumero As Double

        Dim Negativo As Boolean
        Dim L As Integer
        Dim Una As Boolean
        Dim Millon As Boolean
        Dim Millones As Boolean
        Dim vez As Long
        Dim MaxVez As Long
        Dim k As Long
        Dim strQ As String
        Dim strB As String
        Dim strU As String
        Dim strD As String
        Dim strC As String
        Dim iA As Long
        '
        Dim strN() As String
        Dim Sexo1Ant As String

        'Si se amplia este valor... no se manipularán bien los números
        Const cAncho = 12
        Const cGrupos = cAncho \ 3

        'Por si se especifica el sexo, para el caso de los decimales
        'que siempre será masculino
        Sexo1Ant = m_Sexo1
        m_Sexo1 = Sexo1

        m_LenSexo1 = Len(m_Sexo1)
        '
        ' idea aportada por Harvey Triana
        ' para no tener que estar reinicializando continuamente los arrays
        '
        ' Se ve que lo anterior fallaba si se usaba varias veces seguidas (05/Mar/99)
        If unidad(1) <> "un" & Sexo1 Then
            InicializarArrays()
        End If
        '
        '    If m_Sexo1 <> Sexo1Ant Then
        '        unidad(2) = ""
        '    End If
        '    '
        '    If unidad(2) <> "dos" Then
        '        InicializarArrays
        '    End If
        '

        'Si se produce un error que se pare el mundo!!!
        ''On Local Error GoTo 0

        If Len(strNum) = 0 Then
            strNum = "0"
        End If

        dblNumero = Math.Abs(CDbl(strNum))
        Negativo = (dblNumero <> CDbl(strNum))
        strNum = LTrim$(RTrim$(Str$(dblNumero)))
        L = Len(strNum)

        If dblNumero < 1 Then
            UnNumero = "cero"
            Exit Function
        End If
        '
        Una = True
        Millon = False
        Millones = False
        If L < 4 Then Una = False
        If dblNumero > 999999 Then Millon = True
        If dblNumero > 1999999 Then Millones = True
        strB = ""
        strQ = strNum
        vez = 0

        ReDim strN(cGrupos)
        strQ = Right$(StrDup(cAncho, "0") & strNum, cAncho)
        For k = Len(strQ) To 1 Step -3
            vez = vez + 1
            strN(vez) = Mid$(strQ, k - 2, 3)
        Next
        MaxVez = cGrupos
        For k = cGrupos To 1 Step -1
            If strN(k) = "000" Then
                MaxVez = MaxVez - 1
            Else
                Exit For
            End If
        Next
        For vez = 1 To MaxVez
            strU = ""
            strD = ""
            strC = ""
            strNum = strN(vez)
            L = Len(strNum)
            k = Val(Right$(strNum, 2))
            If Right$(strNum, 1) = "0" Then
                k = k \ 10
                strD = decena(k)
            ElseIf k > 10 And k < 16 Then
                k = Val(Mid$(strNum, L - 1, 2))
                strD = otros(k)
            Else
                strU = unidad(Val(Right$(strNum, 1)))
                If L - 1 > 0 Then
                    k = Val(Mid$(strNum, L - 1, 1))
                    strD = deci(k)
                End If
            End If
            '---Parche de Esteve
            If L - 2 > 0 Then
                k = Val(Mid$(strNum, L - 2, 1))
                'Con esto funcionará bien el 100100, por ejemplo...
                If k = 1 Then                       'Parche
                    If Val(strNum) = 100 Then       'Parche
                        k = 10                      'Parche
                    End If                          'Parche
                End If
                strC = centena(k) & " "
            End If
            '------
            If strU = "uno" And Left$(strB, 4) = " mil" Then strU = ""
            strB = strC & strD & strU & " " & strB

            If (vez = 1 Or vez = 3) Then
                If strN(vez + 1) <> "000" Then strB = " mil " & strB
            End If
            If vez = 2 And Millon Then
                If Millones Then
                    strB = " millones " & strB
                Else
                    strB = "un millón " & strB
                End If
            End If
        Next
        strB = Trim$(strB)
        If Right$(strB, 3) = "uno" Then
            strB = Left$(strB, Len(strB) - 1) & m_Sexo1 '"a"
        End If
        Do                              'Quitar los espacios dobles que haya por medio
            iA = InStr(strB, "  ")
            If iA = 0 Then Exit Do
            strB = Left$(strB, iA - 1) & Mid$(strB, iA + 1)
        Loop
        '
        If Left$(strB, 5 + m_LenSexo1) = "un" & m_Sexo1 & " un" Then
            strB = Mid$(strB, 4 + m_LenSexo1)
        End If
        '---Nueva comparación                                     (01:16 25/Ene/99)
        If Left$(strB, 5) = "un un" Then
            strB = Mid$(strB, 4)
        End If
        '
        ' Comprobar sólo si se especifica "un* mil ",                   (05/Mar/99)
        ' no "un* mil" ya que puede ser "un* millón"
        'If Left$(strB, 6 + m_LenSexo1) = "un" & m_Sexo1 & " mil" Then
        If Left$(strB, 7 + m_LenSexo1) = "un" & m_Sexo1 & " mil " Then
            strB = Mid$(strB, 4 + m_LenSexo1)
            ' Puede que el importe sea sólo "un mil" o "una mil"            (19/Ago/00)
        ElseIf strB = "un" & m_Sexo1 & " mil" Then
            strB = Mid$(strB, 4 + m_LenSexo1)
        End If
        '
        '---Nueva comparación                                     (15:11 25/Ene/99)
        'If Left$(strB, 6) = "un mil" Then
        ' Que debe estar así, para que no quite "un millón"             (05/Mar/99)
        If Left$(strB, 7) = "un mil " Then
            strB = Mid$(strB, 4)
        End If
        '
        If Right$(strB, 15 + m_LenSexo1) <> "millones mil un" & m_Sexo1 Then
            iA = InStr(strB, "millones mil un" & m_Sexo1)
            If iA Then strB = Left$(strB, iA + 8) & Mid$(strB, iA + 13)
        End If
        '---Nueva comparación                                   (15:13 25/Ene/99)
        If Right$(strB, 15) <> "millones mil un" Then
            iA = InStr(strB, "millones mil un")
            If iA Then strB = Left$(strB, iA + 8) + Mid$(strB, iA + 13)
        End If
        '
        ' De algo sirve que la gente pruebe las rutinas...              (05/Mar/99)
        ' ¡¡¡ Gracias gente !!!
        If Millones Then
            ' Comprobación de -as ??? millones
            ' convertir en -os ??? millones
            ' Pero sólo si el sexo es femenino
            If m_Sexo1 = "a" Then
                'If (strB Like "*as * millones*") Then
                ' Usar un bucle Do por si hay varias coincidencias      (07/Dic/00)
                Do While (strB Like "*as * millones*")
                    ' Buscar la primera terminación "as " y cambiar por "os "
                    k = InStr(strB, "as ")
                    If k Then
                        Mid$(strB, k) = "os "
                    End If
                Loop
                'End If
                ' La comparación anterior no funciona con x00 millones  (30/Jun/00)
                'If (strB Like "*as millones*") Then
                ' Usar un bucle Do por si hay varias coincidencias      (07/Dic/00)
                Do While (strB Like "*as millones*")
                    ' Buscar la primera terminación "as " y cambiar por "os "
                    k = InStr(strB, "as millones")
                    If k Then
                        Mid$(strB, k) = "os millones"
                    End If
                Loop
                'End If
                '
                '
                '------------------------------------------------------------------
                ' Comprobar si dice algo así ...una millones            (08/Jul/00)
                ' Por ejemplo en 821.xxx.xxx decia ochocientos veintiuna millones
                '------------------------------------------------------------------
                k = InStr(strB, "una mill")
                If k Then
                    strB = Left$(strB, k + 1) & Mid$(strB, k + 3)
                End If
                '
                '
            End If
        End If
        '
        '
        '--------------------------------------------------------------------------
        ' Cambiar los veintiun por veintiún, etc por sus acentuadas     (08/Jul/00)
        Do
            k = InStr(strB, "veintiun ")
            If k Then
                Mid$(strB, k) = "veintiún "
            End If
        Loop While k
        ' El veintidos creo que nunca lo he acentuado...                (08/Jul/00)
        ' pero en la enciclopedia consultada lo acentúa
        Do
            k = InStr(strB, "veintidos ")
            If k Then
                Mid$(strB, k) = "veintidós "
            End If
        Loop While k
        Do
            k = InStr(strB, "veintitres ")
            If k Then
                Mid$(strB, k) = "veintitrés "
            End If
        Loop While k
        Do
            k = InStr(strB, "veintiseis ")
            If k Then
                Mid$(strB, k) = "veintiséis "
            End If
        Loop While k
        '--------------------------------------------------------------------------
        '
        '
        If Right$(strB, 6) = "ciento" Then
            strB = Left$(strB, Len(strB) - 2)
        End If
        If Negativo Then strB = "menos " & strB

        UnNumero = Trim$(strB)

        ' Restablecer el valor anterior
        m_Sexo1 = Sexo1Ant
        m_LenSexo1 = Len(m_Sexo1)
    End Function

    Private Shared Sub InicializarArrays()
        'Asignar los valores
        unidad(1) = "un" & m_Sexo1
        unidad(2) = "dos"
        unidad(3) = "tres"
        unidad(4) = "cuatro"
        unidad(5) = "cinco"
        unidad(6) = "seis"
        unidad(7) = "siete"
        unidad(8) = "ocho"
        unidad(9) = "nueve"
        '
        decena(1) = "diez"
        decena(2) = "veinte"
        decena(3) = "treinta"
        decena(4) = "cuarenta"
        decena(5) = "cincuenta"
        decena(6) = "sesenta"
        decena(7) = "setenta"
        decena(8) = "ochenta"
        decena(9) = "noventa"
        '
        centena(1) = "ciento"
        centena(2) = "doscient" & m_Sexo2
        centena(3) = "trescient" & m_Sexo2
        centena(4) = "cuatrocient" & m_Sexo2
        centena(5) = "quinient" & m_Sexo2
        centena(6) = "seiscient" & m_Sexo2
        centena(7) = "setecient" & m_Sexo2
        centena(8) = "ochocient" & m_Sexo2
        centena(9) = "novecient" & m_Sexo2
        centena(10) = "cien"                'Parche
        '
        deci(1) = "dieci"
        deci(2) = "veinti"
        deci(3) = "treinta y "
        deci(4) = "cuarenta y "
        deci(5) = "cincuenta y "
        deci(6) = "sesenta y "
        deci(7) = "setenta y "
        deci(8) = "ochenta y "
        deci(9) = "noventa y "
        '
        otros(1) = "1"
        otros(2) = "2"
        otros(3) = "3"
        otros(4) = "4"
        otros(5) = "5"
        otros(6) = "6"
        otros(7) = "7"
        otros(8) = "8"
        otros(9) = "9"
        otros(10) = "10"
        otros(11) = "once"
        otros(12) = "doce"
        otros(13) = "trece"
        otros(14) = "catorce"
        otros(15) = "quince"
    End Sub

    Private Sub Init()
        m_Sexo1 = "a"
        m_Sexo2 = "as"
    End Sub

    Public Shared Function Pluralizar( _
                    ByVal sNumero As String, _
                    ByVal sMoneda As String, _
                    Optional ByVal bCadaPalabra As Boolean = False) As String
        '--------------------------------------------------------------------------
        ' Pluraliza la moneda, si el valor de número es distinto de uno
        '
        ' Ahora es una función pública                                  (07/Jul/00)
        '
        ' Parámetros:
        '   sNumero         Importe, para saber si hay que pluralizar o no
        '   sMoneda         Cadena con la palabra a pluralizar
        '   bCadaPalabra    Si se pluralizan todas las palabras         (08/Jul/00)
        '--------------------------------------------------------------------------
        Dim dblTotal As Double
        Dim sTmp As String
        Dim i As Long

        If Len(Trim$(sMoneda)) Then
            ' He quitado el Val             (08/Jul/00)
            'dblTotal = Val(sNumero)
            '
            ' Si entra una cadena vacia, da error                       (08/Jul/00)
            If Len(sNumero) = 0 Then
                sNumero = "0"
            End If
            dblTotal = (sNumero)
            '
            If dblTotal <> 1.0# Then
                sMoneda = Trim$(sMoneda)
                ' Si se pluralizan todas las palabras                   (08/Jul/00)
                If bCadaPalabra Then
                    sMoneda = sMoneda & " "
                    sTmp = ""
                    For i = 1 To Len(sMoneda)
                        If Mid$(sMoneda, i, 1) = " " Then
                            ' pluralizar
                            If InStr("aeiou", Right$(sTmp, 1)) Then
                                sTmp = sTmp & "s"
                            Else
                                sTmp = sTmp & "es"
                            End If
                        End If
                        sTmp = sTmp & Mid$(sMoneda, i, 1)
                    Next
                    sMoneda = " " & Trim$(sTmp) & " "
                Else
                    If InStr("aeiou", Right$(sMoneda, 1)) Then
                        sMoneda = " " & sMoneda & "s "
                    Else
                        sMoneda = " " & sMoneda & "es "
                    End If
                End If
            End If
        End If
        Pluralizar = sMoneda
    End Function

    Public Shared Function ConvDecimal(ByVal strNum As String, _
                                Optional ByRef sDecimal As String = ",", _
                                Optional ByRef sDecimalNo As String = ".") As String
        ' Asigna el signo decimal adecuado (o lo intenta)               (10/Ene/99)
        ' Devuelve una cadena con el signo decimal del sistema
        Dim sNumero As String
        Dim i As Integer
        Dim j As Integer

        On Error Resume Next        ' Si se produce un error, continuar (07/Jul/00)

        ' Averiguar el signo decimal
        sNumero = Format$(25.5, "#.#")
        If InStr(sNumero, ".") Then
            sDecimal = "."
            sDecimalNo = ","
        Else
            sDecimal = ","
            sDecimalNo = "."
        End If

        strNum = Trim$(strNum)
        If Left$(strNum, 1) = sDecimalNo Then
            Mid$(strNum, 1, 1) = sDecimal
        End If

        ' Si el número introducido contiene signos no decimales
        j = 0
        i = 1
        Do
            i = VB.InStr(i, strNum, sDecimalNo)
            If i Then
                j = j + 1
                i = i + 1
            End If
        Loop While i

        If j = 1 Then
            ' cambiar ese símbolo por un espacio, si sólo hay uno de esos signos
            i = InStr(strNum, sDecimalNo)
            If i Then
                If InStr(strNum, sDecimal) Then
                    Mid$(strNum, i, 1) = " "
                Else
                    Mid$(strNum, i, 1) = sDecimal
                End If
            End If
        Else
            'En caso de que tenga más de uno de estos símbolos
            'convertirlos de manera adecuada.
            'Por ejemplo:
            'si el signo decimal es la coma:
            '   1,250.45 sería 1.250,45 y quedaría en 1250,45
            'si el signo decimal es el punto:
            '   1.250,45 sería 1,250.45 y quedaría en 1250.45
            '
            'Aunque no se arreglará un número erróneo:
            'si el signo decimal es la coma:
            '   1,250,45 será lo mismo que 1,25
            '   12,500.25 será lo mismo que 12,50
            'si el signo decimal es el punto:
            '   1.250.45 será lo mismo que 1.25
            '   12.500,25 será lo mismo que 12.50
            '
            i = 1
            Do
                i = VB.InStr(i, strNum, sDecimalNo)
                If i Then
                    j = j - 1
                    If j = 0 Then
                        Mid$(strNum, i, 1) = sDecimal
                    Else
                        Mid$(strNum, i, 1) = " "
                    End If
                    i = i + 1
                End If
            Loop While i
        End If

        j = 0
        ' Quitar los espacios que haya por medio
        Do
            i = InStr(strNum, " ")
            If i = 0 Then Exit Do
            strNum = Left$(strNum, i - 1) & Mid$(strNum, i + 1)
        Loop

        ConvDecimal = strNum

    End Function

    '***************************************************
    '***************************************************
    '***************************************************

    Public Shared Function CoordenadasImpresionDocumento(ByVal TipoDocumento As enCoordImprDoc) As DataTable

        Try

            Dim sSQL As String
            Dim oParam(0) As SqlClient.SqlParameter

            sSQL = "usp_Util_CoordDoc"
            oParam(0) = New SqlClient.SqlParameter("@intTipoDoc", TipoDocumento)

            CoordenadasImpresionDocumento = SQLServer.ExecSPReturnDT(sSQL, oParam)


        Catch ex As Exception
        End Try

    End Function

    Public Shared Function EsRFCValido(ByVal RFC As String) As Boolean

        Try

            Dim strPaso As String = RFC.ToUpper
            Dim x As Integer

            EsRFCValido = False

            If strPaso.Length < 12 Then
                Exit Function
            End If

            If strPaso.Length > 13 Then
                Exit Function
            End If

            If strPaso.Length = 12 Then
                'LAS PRIMERAS 3 DEBEN SER LETRAS
                For x = 1 To 3
                    If InStr(SoloLetras, Mid(strPaso, x, 1).ToLower) <= 0 Then
                        Exit Function
                    End If
                Next
                'LOS SIGUIENTES 6 DEBEN SER NUMEROS
                For x = 4 To 9
                    If InStr(SoloNumeros, Mid(strPaso, x, 1).ToLower) <= 0 Then
                        Exit Function
                    End If
                Next
            ElseIf strPaso.Length = 13 Then
                'LAS PRIMERAS 4 DEBEN SER LETRAS
                For x = 1 To 4
                    If InStr(SoloLetras, Mid(strPaso, x, 1).ToLower) <= 0 Then
                        Exit Function
                    End If
                Next
                'LOS SIGUIENTES 6 DEBEN SER NUMEROS
                For x = 5 To 10
                    If InStr(SoloNumeros, Mid(strPaso, x, 1).ToLower) <= 0 Then
                        Exit Function
                    End If
                Next
            End If

            EsRFCValido = True

        Catch ex As Exception
        End Try
        Return False

    End Function

    Public Shared Function FechaServer() As Date

        Try

            Dim sSQL As String
            Dim dt As DataTable

            sSQL = "usp_sys_fecha"

            dt = SQLServer.ExecSPReturnDT(sSQL)

            If Not dt Is Nothing AndAlso _
               dt.Rows.Count > 0 AndAlso _
               Not IsDBNull(dt.Rows(0).Item("FechaActual")) AndAlso _
               IsDate(dt.Rows(0).Item("FechaActual")) Then

                FechaServer = dt.Rows(0).Item("FechaActual")

            Else

                FechaServer = Date.Now

            End If

        Catch ex As Exception
            FechaServer = Date.Now
        End Try

    End Function

    Public Shared Function PuedeConectarBD() As Boolean

        Try

            PuedeConectarBD = False

            Dim dt As DataTable

            dt = SQLServer.ExecSQLReturnDT("SELECT * FROM System")

            PuedeConectarBD = True

        Catch ex As Exception

        End Try

    End Function

    Public Shared Function EsEquipoValido(ByRef Servidor As String, ByRef MBSerie As String) As Boolean

        Try

            EsEquipoValido = False

            Dim strWinSysDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.System)
            Dim strConfigFile = strWinSysDir & "\gmsys.jem"

            If File.Exists(strConfigFile) Then

                Dim fs As New FileStream(strConfigFile, FileMode.OpenOrCreate)
                Dim br As New BinaryReader(fs)

                If fs.CanRead Then
                    Try
                        Servidor = br.ReadString()
                        MBSerie = br.ReadString

                        If Servidor = "" Then
                            Exit Function
                        End If

                        Servidor = EncDec(Servidor, 2)

                        'Dim query As New ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard")
                        'Dim strmbserial As String = ""

                        'For Each wmiDrive As ManagementObject In query.Get()
                        '    strmbserial = wmiDrive("SerialNumber").ToString()
                        'Next

                        'MBSerie = EncDec(MBSerie, 2)

                        'If MBSerie <> strmbserial Then
                        '    Exit Function
                        'End If

                    Catch
                    End Try
                End If
            Else
                Exit Function
            End If

            EsEquipoValido = True

        Catch ex As Exception
        End Try

    End Function

    Public Shared Function EncDec(ByVal Dato As String, ByVal Accion As Integer) As String

        Dim Republica As String
        Dim x As Integer
        Dim PASO As String
        Dim PASO2 As String
        Dim PosLetras As String     'AQUI SE GUARDA CADA 2 CARACTERES LA POSICION DE UNA LETRA Y LA LETRA
        Dim Longitud As Integer     'AQUI SE OBTIENE LA LONGITUD DEL TEXTO YA DESENCRIPTADO
        Dim Inicio As Integer           'AQUI SE GUARDA EN QUE POSICION DEBE EMPEZAR LA "SEMILLA"

        Try

            PASO = ""
            PosLetras = ""
            Republica = ""

            If Accion = 1 Then
                'ENCRIPTANDO *******************************************
                'Convirtiendo a mayusculas
                Dato = UCase$(Dato)

                'COMO EL dato PUEDE TENER LETRAS, ESTAS SE TIENEN QUE CONVERTIR A NUMEROS, AL MISMO TIEMPO SE GUARDA LA POSICION EN DONDE VAN LAS LETRAS
                For x = 1 To Len(Dato)
                    If IsNumeric(Mid$(Dato, x, 1)) Then
                        PASO = PASO & Mid$(Dato, x, 1)
                    Else
                        PosLetras = PosLetras & Chr(x) & Mid$(Dato, x, 1)
                        Select Case Mid$(Dato, x, 1)
                            Case "A", "J", "R", " "
                                PASO = PASO & "1"
                            Case "B", "K", "S", ","
                                PASO = PASO & "2"
                            Case "C", "L", "T", "."
                                PASO = PASO & "3"
                            Case "D", "M", "U", "-"
                                PASO = PASO & "4"
                            Case "E", "N", "V", "#"
                                PASO = PASO & "5"
                            Case "F", "Ñ", "W"
                                PASO = PASO & "6"
                            Case "G", "O", "X"
                                PASO = PASO & "7"
                            Case "H", "P", "Y"
                                PASO = PASO & "8"
                            Case "I", "Q", "Z"
                                PASO = PASO & "9"
                        End Select
                    End If
                Next x

                'EN QUE POSICION EMPIEZA
                'PosLetras = PosLetras & Format$(CInt(Left$(PASO, 1)), "00")
                PosLetras = PosLetras & Chr(CInt(Left$(PASO, 1)))
                'QUE LONGITUD TIENE
                'PosLetras = PosLetras & Format$(Len(dato), "000")
                PosLetras = PosLetras & Chr(Len(Dato))

                'ACOMODANDO REPUBLICA DE ACUERDO AL INICIO Y LAS VECES QUE QUEPA
                For x = 1 To (Len(PASO) \ Len("REPUBLICA")) + 1
                    Select Case CInt(Left$(PASO, 1))
                        Case 0, 1
                            Republica = Republica & "REPUBLICAS"
                        Case 2
                            Republica = Republica & "EPUBLICASR"
                        Case 3
                            Republica = Republica & "PUBLICASRE"
                        Case 4
                            Republica = Republica & "UBLICASREP"
                        Case 5
                            Republica = Republica & "BLICASREPU"
                        Case 6
                            Republica = Republica & "LICASREPUB"
                        Case 7
                            Republica = Republica & "ICASREPUBL"
                        Case 8
                            Republica = Republica & "CASREPUBLI"
                        Case 9
                            Republica = Republica & "ASREPUBLIC"
                    End Select
                Next x

                'CODIFICANDO
                For x = 1 To Len(PASO)
                    PASO2 = PASO2 & Mid$(Republica, CInt(Mid$(PASO, x, 1)) + 1, 1)
                Next x

                PASO2 = PASO2 & PosLetras
            Else
                'DESENCRIPTANDO
                'obtengo la longitud
                'Longitud = CLng(Right$(dato, 3))
                Longitud = Asc(Right$(Dato, 1))
                'obtengo en donde empieza la "semilla"
                Inicio = Asc(Mid$(Dato, Len(Dato) - 1, 1))
                'obtengo los indicadores de texto
                If Len(Dato) = Longitud + 2 Then
                    'no hay letras, son puros numeros
                    PosLetras = ""
                Else
                    'si hay letras!!!
                    PosLetras = Mid$(Dato, Longitud + 1, (Len(Dato) - 2 - Longitud))
                End If
                'ACOMODANDO REPUBLICA DE ACUERDO AL INICIO
                Select Case Inicio
                    Case 0, 1
                        Republica = Republica & "REPUBLICAS"
                    Case 2
                        Republica = Republica & "EPUBLICASR"
                    Case 3
                        Republica = Republica & "PUBLICASRE"
                    Case 4
                        Republica = Republica & "UBLICASREP"
                    Case 5
                        Republica = Republica & "BLICASREPU"
                    Case 6
                        Republica = Republica & "LICASREPUB"
                    Case 7
                        Republica = Republica & "ICASREPUBL"
                    Case 8
                        Republica = Republica & "CASREPUBLI"
                    Case 9
                        Republica = Republica & "ASREPUBLIC"
                End Select

                For x = 1 To Longitud
                    PASO = PASO & Trim$(Str$(InStr(1, Republica, Mid$(Dato, x, 1)) - 1))
                Next x

                'SI EN EL TEXTO ORIGINAL HABIA LETRAS, LAS REPONGO
                If PosLetras <> "" Then
                    For x = 1 To Len(PosLetras) Step 2
                        Mid(PASO, Asc(Mid$(PosLetras, x, 1)), 1) = Mid$(PosLetras, x + 1, 1)
                    Next x
                End If
                PASO2 = PASO
            End If

            EncDec = PASO2

        Catch ex As Exception
            EncDec = "ERROR"
        End Try

    End Function

    Public Shared Function Image2Bytes(ByVal img As Image) As Byte()
        Dim sTemp As String = Path.GetTempFileName()
        Dim fs As New FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        img.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg)
        fs.Position = 0
        '
        Dim imgLength As Integer = CInt(fs.Length)
        Dim bytes(0 To imgLength - 1) As Byte
        fs.Read(bytes, 0, imgLength)
        fs.Close()
        Return bytes
    End Function

    Public Shared Function Bytes2Image(ByVal bytes() As Byte) As Image
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

    Public Shared Function BuildComboArrayDT(ByVal dtWork As DataTable, _
                                       ByVal sDescFld As String, _
                                       Optional ByVal sIDFld As String = "", _
                                       Optional ByVal sCodeFld As String = "", _
                                       Optional ByVal sCodeFmt As String = "", _
                                       Optional ByVal sFilter As String = "", _
                                       Optional ByVal sOrderBy As String = "", _
                                       Optional ByVal blnRemoveDups As Boolean = True) As ArrayList
        Dim iCounter As Integer
        ''Dim sDefaultTmp As String
        'Dim strSQL As String
        'Dim strWhere As String

        Dim arlComboData As New ArrayList
        'Dim oSQL As New VisualMatrix.Data.SQLServer()
        'Dim dtWork As DataTable

        Try

            'strSQL = "Select * From " & sTableName

            'If sFilter <> "" Then
            '    strWhere = " Where " & sFilter
            'Else
            '    strWhere = ""
            'End If

            'If strWhere <> "" Then
            '    strSQL = strSQL & strWhere
            'End If

            'If sOrderBy <> "*Free*" Then
            '    If sOrderBy = "" Then
            '        If sCodeFld <> "" Then
            '            strSQL = strSQL & " Order By " & sCodeFld
            '        Else
            '            strSQL = strSQL & " Order By " & sDescFld
            '        End If
            '    Else
            '        strSQL = strSQL & " Order By " & sOrderBy
            '    End If
            'End If


            'dtWork = SQLServer.ExecSQLReturnDT(strSQL)

            If Not dtWork Is Nothing And dtWork.Rows.Count > 0 Then
                ' No ID Field, do not fill in ItemData
                If sCodeFld = "" Then
                    ' No User Code, Only Description in list items
                    For iCounter = 0 To dtWork.Rows.Count - 1
                        With dtWork.Rows(iCounter)
                            If Not IsDBNull(.Item(sDescFld)) Then
                                If sIDFld <> "" Then
                                    arlComboData.Add(New ComboArray(Convert.ToString(.Item(sDescFld)), Convert.ToInt32(IIf(IsDBNull(.Item(sIDFld)), 0, .Item(sIDFld)))))
                                Else
                                    arlComboData.Add(New ComboArray(Convert.ToString(.Item(sDescFld))))
                                End If
                            End If
                        End With
                    Next
                Else
                    If sCodeFmt = "" Then
                        ' Add User code to beginning of Description WITHOUT format
                        For iCounter = 0 To dtWork.Rows.Count - 1
                            With dtWork.Rows(iCounter)
                                If Not IsDBNull(.Item(sDescFld)) Then
                                    If sIDFld <> "" Then
                                        arlComboData.Add(New ComboArray(RTrim(CStr(.Item(sCodeFld))) & " - " & Convert.ToString(.Item(sDescFld)), Convert.ToInt32(IIf(IsDBNull(.Item(sIDFld)), 0, .Item(sIDFld)))))
                                    Else
                                        arlComboData.Add(New ComboArray(RTrim(CStr(.Item(sCodeFld))) & " - " & Convert.ToString(.Item(sDescFld))))
                                    End If
                                End If
                            End With
                        Next
                    Else
                        ' Add User code to beginning of Description WITH format
                        For iCounter = 0 To dtWork.Rows.Count - 1
                            With dtWork.Rows(iCounter)
                                If Not IsDBNull(.Item(sDescFld)) And Not IsDBNull(.Item(sCodeFld)) Then
                                    If sDescFld = sCodeFld Then
                                        If sIDFld <> "" Then
                                            arlComboData.Add(New ComboArray(Format(.Item(sCodeFld), sCodeFmt), Convert.ToInt32(IIf(IsDBNull(.Item(sIDFld)), 0, .Item(sIDFld)))))
                                        Else
                                            arlComboData.Add(New ComboArray(Format(.Item(sCodeFld), sCodeFmt)))
                                        End If
                                    Else
                                        If sIDFld <> "" Then
                                            arlComboData.Add(New ComboArray(Format(.Item(sCodeFld), sCodeFmt) & " - " & Convert.ToString(.Item(sDescFld)), Convert.ToInt32(IIf(IsDBNull(.Item(sIDFld)), 0, .Item(sIDFld)))))
                                        Else
                                            arlComboData.Add(New ComboArray(Format(.Item(sCodeFld), sCodeFmt) & " - " & Convert.ToString(.Item(sDescFld))))
                                        End If
                                    End If
                                End If
                            End With
                        Next
                    End If
                End If
            End If

            If blnRemoveDups Then
                '
                'remove all duplicates
                '
                For iCounter = arlComboData.Count - 1 To 1 Step -1
                    If Trim(UCase(CType(arlComboData.Item(iCounter), ComboArray).Description)) = Trim(UCase(CType(arlComboData.Item(iCounter - 1), ComboArray).Description)) Then
                        'case insensitive
                        arlComboData.RemoveAt(iCounter)
                    End If
                Next
            End If

        Catch e As Exception

            MsgBox("Error: " & e.Message, MsgBoxStyle.Information)

        Finally

            If Not dtWork Is Nothing Then
                dtWork.Dispose()
            End If

        End Try

        Return arlComboData

    End Function

    Public Shared Function BuildComboArray(ByVal sTableName As String, _
                                       ByVal sDescFld As String, _
                                       Optional ByVal sIDFld As String = "", _
                                       Optional ByVal sCodeFld As String = "", _
                                       Optional ByVal sCodeFmt As String = "", _
                                       Optional ByVal sFilter As String = "", _
                                       Optional ByVal sOrderBy As String = "", _
                                       Optional ByVal blnRemoveDups As Boolean = True, _
                                       Optional ByVal blnSourceIsSP As Boolean = False, _
                                       Optional ByVal blnSourceIsSQL As Boolean = False) As ArrayList

        Dim iCounter As Integer
        ''Dim sDefaultTmp As String
        Dim strSQL As String
        Dim strWhere As String

        Dim arlComboData As New ArrayList
        'Dim oSQL As New VisualMatrix.Data.SQLServer()
        Dim dtWork As DataTable

        Try

            If blnSourceIsSP OrElse blnSourceIsSQL Then

                strSQL = sTableName

                If blnSourceIsSP Then
                    strSQL = "EXEC " & strSQL
                    If sFilter <> "" Then
                        strSQL = strSQL & " " & sFilter
                    End If
                    dtWork = SQLServer.ExecSQLReturnDT(strSQL)
                ElseIf blnSourceIsSQL Then
                    dtWork = SQLServer.ExecSQLReturnDT(strSQL)
                End If

            Else

                strSQL = "Select * From " & sTableName

                If sFilter <> "" Then
                    strWhere = " Where " & sFilter
                Else
                    strWhere = ""
                End If

                If strWhere <> "" Then
                    strSQL = strSQL & strWhere
                End If

                If sOrderBy <> "*Free*" Then
                    If sOrderBy = "" Then
                        If sCodeFld <> "" Then
                            strSQL = strSQL & " Order By " & sCodeFld
                        Else
                            strSQL = strSQL & " Order By " & sDescFld
                        End If
                    Else
                        strSQL = strSQL & " Order By " & sOrderBy
                    End If
                End If

                dtWork = SQLServer.ExecSQLReturnDT(strSQL)

            End If


            If Not dtWork Is Nothing And dtWork.Rows.Count > 0 Then
                ' No ID Field, do not fill in ItemData
                If sCodeFld = "" Then
                    ' No User Code, Only Description in list items
                    For iCounter = 0 To dtWork.Rows.Count - 1
                        With dtWork.Rows(iCounter)
                            If Not IsDBNull(.Item(sDescFld)) Then
                                If sIDFld <> "" Then
                                    arlComboData.Add(New ComboArray(Convert.ToString(.Item(sDescFld)).Trim, Convert.ToInt32(IIf(IsDBNull(.Item(sIDFld)), 0, .Item(sIDFld)))))
                                Else
                                    arlComboData.Add(New ComboArray(Convert.ToString(.Item(sDescFld)).Trim))
                                End If
                            End If
                        End With
                    Next
                Else
                    If sCodeFmt = "" Then
                        ' Add User code to beginning of Description WITHOUT format
                        For iCounter = 0 To dtWork.Rows.Count - 1
                            With dtWork.Rows(iCounter)
                                If Not IsDBNull(.Item(sDescFld)) Then
                                    If sIDFld <> "" Then
                                        arlComboData.Add(New ComboArray(RTrim(CStr(.Item(sCodeFld))) & " - " & Convert.ToString(.Item(sDescFld)), Convert.ToInt32(IIf(IsDBNull(.Item(sIDFld)), 0, .Item(sIDFld)))))
                                    Else
                                        arlComboData.Add(New ComboArray(RTrim(CStr(.Item(sCodeFld))) & " - " & Convert.ToString(.Item(sDescFld))))
                                    End If
                                End If
                            End With
                        Next
                    Else
                        ' Add User code to beginning of Description WITH format
                        For iCounter = 0 To dtWork.Rows.Count - 1
                            With dtWork.Rows(iCounter)
                                If Not IsDBNull(.Item(sDescFld)) And Not IsDBNull(.Item(sCodeFld)) Then
                                    If sDescFld = sCodeFld Then
                                        If sIDFld <> "" Then
                                            arlComboData.Add(New ComboArray(Format(.Item(sCodeFld), sCodeFmt), Convert.ToInt32(IIf(IsDBNull(.Item(sIDFld)), 0, .Item(sIDFld)))))
                                        Else
                                            arlComboData.Add(New ComboArray(Format(.Item(sCodeFld), sCodeFmt)))
                                        End If
                                    Else
                                        If sIDFld <> "" Then
                                            arlComboData.Add(New ComboArray(Format(.Item(sCodeFld), sCodeFmt) & " - " & Convert.ToString(.Item(sDescFld)), Convert.ToInt32(IIf(IsDBNull(.Item(sIDFld)), 0, .Item(sIDFld)))))
                                        Else
                                            arlComboData.Add(New ComboArray(Format(.Item(sCodeFld), sCodeFmt) & " - " & Convert.ToString(.Item(sDescFld))))
                                        End If
                                    End If
                                End If
                            End With
                        Next
                    End If
                End If
            End If

            If blnRemoveDups Then
                '
                'remove all duplicates
                '
                For iCounter = arlComboData.Count - 1 To 1 Step -1
                    If Trim(UCase(CType(arlComboData.Item(iCounter), ComboArray).Description)) = Trim(UCase(CType(arlComboData.Item(iCounter - 1), ComboArray).Description)) Then
                        'case insensitive
                        arlComboData.RemoveAt(iCounter)
                    End If
                Next
            End If

        Catch e As Exception

            MsgBox("Error: " & e.Message, MsgBoxStyle.Information)

        Finally

            If Not dtWork Is Nothing Then
                dtWork.Dispose()
            End If

        End Try

        Return arlComboData

    End Function

    Public Shared Sub ComboKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '
        'handels key down event in combo boxes

        'space bar pressed
        If e.KeyCode = Windows.Forms.Keys.Space Then
            'drop down combo box
            CType(sender, System.Windows.Forms.ComboBox).DroppedDown = True

        End If

    End Sub

    Public Shared Sub CentraForma(ByRef Forma As Form, ByVal EsMDIHija As Boolean)

        Dim x As Long
        Dim y As Long

        If EsMDIHija AndAlso Not Forma.Parent Is Nothing Then

            x = (Forma.MdiParent.Width - Forma.Width) / 2
            y = ((Forma.MdiParent.Height - Forma.Height) / 2) - 30

        Else

            x = (Screen.PrimaryScreen.WorkingArea.Width - Forma.Width) / 2
            y = (Screen.PrimaryScreen.WorkingArea.Height - Forma.Height) / 2

        End If

        Forma.Location = New Point(x, y)

    End Sub

    Public Shared Function FechaColumna(ByVal Fecha As Date) As String

        Dim strReturn As String = ""

        strReturn = Choose(Fecha.DayOfWeek + 1, "Domingo,", "Lunes,", "Martes,", "Miércoles,", "Jueves,", "Viernes,", "Sábado,") & Fecha.Day.ToString & " de " & _
                    Choose(Fecha.Month, "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre")

        Return strReturn

    End Function

    Public Shared Function FechaFormato(ByVal Fecha As Date) As String

        Dim strReturn As String = ""

        strReturn = Fecha.Day.ToString & " " & _
                    Choose(Fecha.Month, "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre") & _
                     " " & Fecha.Year.ToString

        Return strReturn

    End Function


    Public Shared Function FechaActual() As Date

        Dim sSQL As String
        Dim dt As DataTable

        sSQL = "SELECT CURRENT_TIMESTAMP()"

        dt = SQLServer.ExecSQLReturnDT(sSQL)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0).Item(0)) Then
            FechaActual = dt.Rows(0).Item(0)
        Else
            FechaActual = Now.Date
        End If

    End Function

    Public Shared Sub PorcentajesFiscales(ByRef PorcentajeIVA As Double, _
                                          ByRef PorcentajeRetIVA As Double, _
                                          ByRef PorcentajeRetISR As Double, _
                                          ByRef CalculaIVA As Boolean, _
                                          ByRef CalculaRetIVA As Boolean, _
                                          ByRef CalculaRetISR As Boolean)

        Try

            Dim sSQL As String
            Dim dt As DataTable

            sSQL = "usp_PorcentajesFiscales"

            dt = SQLServer.ExecSPReturnDT(sSQL, , "Porcentajes")

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                If Not IsDBNull(dt.Rows(0).Item("PorcIVA")) Then
                    PorcentajeIVA = dt.Rows(0).Item("PorcIVA") / 100
                End If

                If Not IsDBNull(dt.Rows(0).Item("PorcRetIVA")) Then
                    PorcentajeRetIVA = dt.Rows(0).Item("PorcRetIVA") / 100
                End If

                If Not IsDBNull(dt.Rows(0).Item("PorcRetISR")) Then
                    PorcentajeRetISR = dt.Rows(0).Item("PorcRetISR") / 100
                End If

                If Not IsDBNull(dt.Rows(0).Item("CalcularIVA")) Then
                    CalculaIVA = CBool(dt.Rows(0).Item("CalcularIVA"))
                End If

                If Not IsDBNull(dt.Rows(0).Item("CalcularRetIVA")) Then
                    CalculaRetIVA = dt.Rows(0).Item("CalcularRetIVA")
                End If

                If Not IsDBNull(dt.Rows(0).Item("CalcularRetISR")) Then
                    CalculaRetISR = dt.Rows(0).Item("CalcularRetISR")
                End If

            End If

        Catch ex As Exception
        End Try

    End Sub

    Public Shared Sub Test()

        'Dim drawFont As Font
        'Dim drawPoint As PointF
        'Dim drawBrush As SolidBrush
        'Dim pdDoc As New Printing.PrintDocument

        'drawFont = New Font("Arial", 12)


    End Sub

    Public Shared Function NullsHandler(ByVal PvValue As Object, Optional ByVal PsType As enTipoValidaNulo = enTipoValidaNulo.Texto) As Object

        Try

            If IsDBNull(PvValue) AndAlso PsType = enTipoValidaNulo.Numero Then
                NullsHandler = 0
            ElseIf IsDBNull(PvValue) AndAlso PsType = enTipoValidaNulo.Texto Then
                NullsHandler = ""
            Else
                NullsHandler = PvValue
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Function

End Class

Public Class ComboArray

    Private mintID As Integer
    Private mstrDescription As String
    Private mbolIncludeID As Boolean

    Public Sub New(ByVal strDescription As String)
        MyBase.New()
        Me.mstrDescription = strDescription
        Me.mintID = -1
    End Sub

    Public Sub New(ByVal strDescription As String, ByVal intID As Integer, Optional ByVal bolIncludeID As Boolean = False)
        MyBase.New()
        Me.mstrDescription = strDescription
        Me.mintID = intID
        Me.mbolIncludeID = bolIncludeID
    End Sub

    Public Property ID() As Integer
        Get
            Return mintID
        End Get
        Set(ByVal intValue As Integer)
            mintID = intValue
        End Set
    End Property

    Public Property Description() As String
        Get
            Return mstrDescription
        End Get
        Set(ByVal strValue As String)
            mstrDescription = strValue
        End Set
    End Property

    'Public Overrides Function ToString() As String
    '    If Me.mintID <> -1 AndAlso Me.mbolIncludeID Then
    '        Return CStr(Me.mintID) & " - " & Me.mstrDescription
    '    Else
    '        Return Me.mstrDescription
    '    End If
    'End Function

End Class
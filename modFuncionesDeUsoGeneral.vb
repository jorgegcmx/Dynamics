Public Class modFuncionesDeUsoGeneral

    ' Tipos ROOT de claves del Registro...
    Const HKEY_LOCAL_MACHINE As Integer = &H80000002
    Const SOLOMON_KEY As String = "SOFTWARE\wow6432Node\Microsoft\DynamicsSL"
    Const DIRECTORIO_SOLOMON As String = "ParentDirectory"

    ' Constantes de Ubicación de archivos
    Public Const gPathTransportes As String = "AG\TR\"
    Public Const gPathPlantaAlimentos As String = "AG\PA\"
    Public Const gPathEngorda As String = "AG\EN\"
    Public Const gPathReproductoras As String = "AG\RE\"
    Public Const gPathIncubacion As String = "AG\IN\"
    Public Const gPathRastro As String = "AG\RA\"
    Public Const gPathComercializadora As String = "AG\CO\"

    Public Enum genTipoDB
        genDatos
        genSistema
    End Enum


    Public Enum ggstrDirectorioSolomon
        gsdRaiz
        gsdContabilidad
        gsdCuentasPorCobrar
        gsdCuentasPorPagar
        gsdEventLog
        gsdVentas
        gsdArchivosDeControl
        gsdAdmonEfectivo
    End Enum

    Const gcContabilidad As String = "GL"
    Const gcCuentasPorCobrar As String = "AR"
    Const gcCuentasPorPagar As String = "AP"
    Const gcEventLog As String = "EventLog"
    Const gcVentas As String = "OM"
    Const gcArchivosDeControl As String = "ArchControl"
    Const gcAdmonEfectivo As String = "CA"

    ' Opciones de seguridad de claves del Registro...
    Const KEY_ALL_ACCESS As Integer = &H2003F

    ' Constantes agregadas para prueba por problema en Nutrypollo

    Const SYNCHRONIZE As Integer = &H100000
    Const STANDARD_RIGHTS_READ As Integer = &H20000
    Const STANDARD_RIGHTS_WRITE As Integer = &H20000
    Const STANDARD_RIGHTS_EXECUTE As Integer = &H20000
    Const STANDARD_RIGHTS_REQUIRED As Integer = &HF0000
    Const STANDARD_RIGHTS_ALL As Integer = &H1F0000
    Const KEY_QUERY_VALUE As Short = &H1S
    Const KEY_SET_VALUE As Short = &H2S
    Const KEY_CREATE_SUB_KEY As Short = &H4S
    Const KEY_ENUMERATE_SUB_KEYS As Short = &H8S
    Const KEY_NOTIFY As Short = &H10S
    Const KEY_CREATE_LINK As Short = &H20S
    Const KEY_READ As Boolean = ((STANDARD_RIGHTS_READ Or KEY_QUERY_VALUE Or KEY_ENUMERATE_SUB_KEYS Or KEY_NOTIFY) And (Not SYNCHRONIZE))



    Const ERROR_SUCCESS As Short = 0
    Const REG_SZ As Short = 1 ' Cadena Unicode terminada en null
    Const REG_DWORD As Short = 4 ' Número de 32 bits

    Private Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyExA" (ByVal HKEY As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
    Private Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueExA" (ByVal HKEY As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByVal lpData As String, ByRef lpcbData As Integer) As Integer
    Private Declare Function RegCloseKey Lib "advapi32" (ByVal HKEY As Integer) As Integer
    Public Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Integer)

    Public Function GetDirSolomon(ByRef nSolomonDir As ggstrDirectorioSolomon) As String
        Dim sRetVal As String = ""
        Dim sSolomonDir As String = ""

        'If GetKeyValue(HKEY_LOCAL_MACHINE, SOLOMON_KEY, DIRECTORIO_SOLOMON, sSolomonDir) Then
        sSolomonDir = ObtieneValor("Exec spObtieneValorTabla " & _
                               SParm("NuVariablesGlobales") & ", " & _
                               SParm("Valor") & ", " & _
                               SParm("Descripcion") & ", " & _
                               SParm("Directorio"))

        If Right(Trim(sSolomonDir), 1) <> "\" Then
            sSolomonDir = Trim(sSolomonDir) & "\"
        End If



        Select Case nSolomonDir

            Case ggstrDirectorioSolomon.gsdRaiz
                sRetVal = sSolomonDir
            Case ggstrDirectorioSolomon.gsdContabilidad
                sRetVal = sSolomonDir & gcContabilidad & "\"
            Case ggstrDirectorioSolomon.gsdCuentasPorCobrar
                sRetVal = sSolomonDir & gcCuentasPorCobrar & "\"
            Case ggstrDirectorioSolomon.gsdCuentasPorPagar
                sRetVal = sSolomonDir & gcCuentasPorPagar & "\"
            Case ggstrDirectorioSolomon.gsdEventLog
                sRetVal = sSolomonDir & gcEventLog & "\"
            Case ggstrDirectorioSolomon.gsdVentas
                sRetVal = sSolomonDir & gcVentas & "\"
            Case ggstrDirectorioSolomon.gsdArchivosDeControl
                sRetVal = sSolomonDir & gcArchivosDeControl & "\"
            Case ggstrDirectorioSolomon.gsdAdmonEfectivo
                sRetVal = sSolomonDir & gcAdmonEfectivo & "\"

        End Select

        'End If

        GetDirSolomon = sRetVal

    End Function

    Public Function GetKeyValue(ByRef KeyRoot As Integer, ByRef KeyName As String, ByRef SubKeyRef As String, ByRef keyval As String) As Boolean
        Dim i As Integer ' Bucle de contador
        Dim rc As Integer ' Código de retorno
        'UPGRADE_NOTE: HKEY was upgraded to HKEY_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim HKEY_Renamed As Integer ' Controlador para una clave abierta del Registro
        'Dim hDepth As Integer '
        Dim KeyValType As Integer ' Tipo de datos de una clave del Registro
        Dim tmpVal As String ' Almacenamiento temporal para un valor de clave del Registro
        Dim KeyValSize As Integer ' Tamaño de variable de clave del Registro
        '------------------------------------------------------------
        ' Abre clave del Registro bajo una clave raíz {HKEY_LOCAL_MACHINE...}
        '------------------------------------------------------------


        '************************************************************************
        ' Linea temporalmente cancelada para prueba de la siguiente linea
        'rc = RegOpenKeyEx(KeyRoot, KeyName, 0, KEY_ALL_ACCESS, HKEY) ' Abre clave del Registro

        '************************************************************************
        ' Prueba con diferente constante para ver si lee la llave del Registry
        rc = RegOpenKeyEx(KeyRoot, KeyName, 0, KEY_READ, HKEY_Renamed)

        '************************************************************************


        If (rc <> ERROR_SUCCESS) Then GoTo GetKeyError ' Controla el error...


        tmpVal = New String(Chr(0), 1024) ' Asigna espacio de variable
        KeyValSize = 1024 ' Marca tamaño de variable


        '------------------------------------------------------------
        ' Recupera valor de clave del Registro...
        '------------------------------------------------------------
        rc = RegQueryValueEx(HKEY_Renamed, SubKeyRef, 0, KeyValType, tmpVal, KeyValSize) ' Obtiene/crea valor de clave


        If (rc <> ERROR_SUCCESS) Then GoTo GetKeyError ' Controla errores


        If (Asc(Mid(tmpVal, KeyValSize, 1)) = 0) Then ' Win95 agrega cadena terminada en Null...
            tmpVal = Left(tmpVal, KeyValSize - 1) ' Se encontró un Null, extrae de cadena
        Else ' WinNT NO termina en Null la cadena...
            tmpVal = Left(tmpVal, KeyValSize) ' No se encontró Null, extrae sólo la cadena
        End If
        '------------------------------------------------------------
        ' Determina el tipo de valor de clave para su conversión...
        '------------------------------------------------------------
        Select Case KeyValType ' Busca tipos de datos...
            Case REG_SZ ' Tipo de datos String de clave del Registro
                keyval = tmpVal ' Copia valor de cadena
            Case REG_DWORD ' Tipo de datos Double Word de clave del Registro
                For i = Len(tmpVal) To 1 Step -1 ' Convierte cada bit
                    keyval = keyval & Hex(Asc(Mid(tmpVal, i, 1))) ' Genera valor carácter a carácter
                Next
                keyval = Format("&h" & keyval) ' Convierte tipo Double Word a String
        End Select


        GetKeyValue = True ' Devuelve éxito
        rc = RegCloseKey(HKEY_Renamed) ' Cierra clave del Registro
        Exit Function ' Sale


GetKeyError:  ' Limpieza después de producirse un error...
        keyval = "" ' Establece valor de retorno a cadena vacía
        GetKeyValue = False ' Devuelve fallo
        rc = RegCloseKey(HKEY_Renamed) ' Cierra clave del Registro
    End Function

    Function NombreAleatorio() As Object

        Randomize()
        NombreAleatorio = Str(Int(Rnd() * 1000000))

    End Function
    Public Sub SetSql(ByVal strSqlQry As String, Optional ByVal enTipoDB As genTipoDB = genTipoDB.genDatos)

        On Error GoTo ManejaError

        Dim intCurTmp As Integer

        ' Creo un Cursor para realizar el proceso
        If enTipoDB = genTipoDB.genDatos Then
            Call SqlCursor(intCurTmp, NOLEVEL)
        Else
            Call SqlCursor(intCurTmp, NOLEVEL + SqlSystemDb)
        End If

        ' Ejecuto el Query
        Call sql(intCurTmp, strSqlQry)

        ' Destruyo el cursor
        Call SqlFree(intCurTmp)

        Exit Sub


ManejaError:

        MsgBox("Este error es controlado: " & Err.Description)
        Resume Next

    End Sub

    Function ObtieneValor(ByVal strSqlStr As String) As String
        Dim Valor As String
        Dim CSR_Generico As Integer

        Valor = ""

        Call sql(CSR_Generico, strSqlStr)
        serr1 = SGroupFetch1(CSR_Generico, Valor)

        'Call SFetch1(CSR_Generico, Cantidad)
        If serr1 = 0 Then ObtieneValor = Trim(Valor) Else ObtieneValor = "-1"

        If Trim(Valor) = "" Then ObtieneValor = ""

        Call SqlFree(CSR_Generico)

    End Function
    Function ObtieneValor2(ByVal strSqlStr As String) As Double
        Dim Valor As Double
        Dim CSR_Generico As Integer

        Valor = 0

        Call sql(CSR_Generico, strSqlStr)
        serr1 = SGroupFetch1(CSR_Generico, Valor)

        'Call SFetch1(CSR_Generico, Cantidad)
        If serr1 = 0 Then ObtieneValor2 = Valor Else ObtieneValor2 = 0

        If Valor = 0 Then ObtieneValor2 = 0
        Call SqlFree(CSR_Generico)

    End Function

    Sub CreacionActualizacion(ByRef dFechaIns As Integer, _
                                          ByRef sProgIns As String, _
                                          ByRef sUserIns As String, _
                                          ByRef dFechaUpd As Integer, _
                                          ByRef sProgUpd As String, _
                                          ByRef sUserUpd As String, _
                                          ByVal sProgram As String, _
                                          ByRef sCompany As String, _
                                          ByVal bNuevo As Boolean)

        ' si es registro nuevo guardo el usuario que esta agregando este registro
        If bNuevo Then
            sCompany = bpes.CpnyID
            dFechaIns = bpes.Today
            sProgIns = sProgram
            sUserIns = bpes.UserId
        End If

        ' guardo el usuario que esta modificando.
        sCompany = bpes.CpnyID
        dFechaUpd = bpes.Today
        sProgUpd = sProgram
        sUserUpd = bpes.UserId

    End Sub
    Sub CreacionActualizacionHora(ByRef sHoraIns As String, _
                                 ByRef sHoraUpd As String, _
                                 ByVal bNuevo As Boolean)

        ' si es registro nuevo guardo el usuario que esta agregando este registro
        If bNuevo Then
            sHoraIns = Format(Now, "HH:mm:ss")
        End If

        ' guardo el usuario que esta modificando.
        sHoraUpd = Format(Now, "HH:mm:ss")



    End Sub
End Class

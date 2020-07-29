'*********************************************************
'
'    Copyright (c) Microsoft. All rights reserved.
'    This code is licensed under the Microsoft Public License.
'    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
'    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
'    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
'    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
'
'*********************************************************
Option Explicit On
Option Strict Off
Imports System.Reflection
Imports System.IO
Friend Class Form1
    Inherits System.Windows.Forms.Form
	Protected m_IsInitializing As Boolean
	Protected ReadOnly Property IsInitializing() As Boolean
		Get
			Return m_IsInitializing
		End Get
	End Property
    Dim funciones As modFuncionesDeUsoGeneral
    Public appName As String
    Dim CSR_nuDivisiones As Integer

    Dim MemHandle_Spread1 As Integer
    Dim MemHandle_Spread2 As Integer
    Dim MemHandle_Spread3 As Integer
    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        appName = Path.GetFileName(Assembly.GetExecutingAssembly().Location)
        appName = Replace(appName, ".exe", "")
        ' Load all the forms needed for this application
        'Call LoadForm(fSL01001)
        ' Initialize the application as a Solomon Application
        Call ApplInit()
        ' Call Set Address for the tables that will have fields displayed on the scree,
        ' or that you would like customization manager to be able to use
        Call SetAddr(LEVEL0, "bnuHitorialMVHdr", bnuHitorialMVHdr, nnuHitorialMVHdr)
        Call SetAddr(LEVEL1, "bnuHitorialMV", bnuHitorialMV, nnuHitorialMV)
        Call SetAddr(LEVEL2, "bnucaRqGeneradas", bnucaRqGeneradas, nnucaRqGeneradas)
        Call SetAddr(LEVEL3, "bordComMV", bordComMV, nordComMV)
        ' Define the cursors that are used by the application

        ' This is an example for a table in the System Database
        'Call SqlCursor(c1, LEVEL0 + SqlSystemDb)

        'This is an example for a table in an Application Database
        'Call SqlCursor(c1, LEVEL0 )

        'Codigo Copiado de el proyecto convertido de Solomon IV
        'SqlCursor call(s)
        Call SqlCursorEx(CSR_nuHitorialMVHdr, LEVEL0, "CSR_nuHitorialMVHdr", "nuHitorialMVHdr", "nuHitorialMVHdr")
        Call SqlCursorEx(CSR_nuHitorialMV, LEVEL1, "CSR_nuHitorialMV", "nuHitorialMV", "nuHitorialMV")
        Call SqlCursorEx(CSR_nucaRqGeneradas, LEVEL2, "CSR_nucaRqGeneradas", "nucaRqGeneradas", "nucaRqGeneradas")
        Call SqlCursorEx(CSR_ordComMV, LEVEL3, "CSR_ordComMV", "ordComMV", "ordComMV")

        'Fin de codigo Copiado de el proyecto convertido de Solomon IV

        ' Call the screen init function
        Call ScreenInit()

        'DetailSetup call for simple grid
        MemHandle_Spread1 = DetailSetup(CSR_nuHitorialMV, gridreport, PNULL, bnuHitorialMV, PNULL, PNULL, PNULL)
        MemHandle_Spread2 = DetailSetup(CSR_nucaRqGeneradas, DvgGrid3, PNULL, bnucaRqGeneradas, PNULL, PNULL, PNULL)
        MemHandle_Spread3 = DetailSetup(CSR_ordComMV, gridOrdenes, PNULL, bordComMV, PNULL, PNULL, PNULL)

        funciones = New modFuncionesDeUsoGeneral
        SetProps(Me, btnCargarInformacion, btnCargarInformacion, PROP_VISIBLE, False)
        SetProps(Me, lblmensage, lblmensage, PROP_VISIBLE, False)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        'Call SetButton(TbSaveButton, LEVEL0, False)
    End Sub

    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'Standard Screen Exit Call
        Call ScreenExit("", "")

    End Sub
#Region "EVENTO SEMANA"
    Private Sub txtNoLote_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtNoLote.ChkEvent
        Dim strSql As String

        Dim intRetVal As Short
        intRetVal = DBNavFetch1(PNULL, CSR_nuHitorialMVHdr, ChkStrg, bnuHitorialMVHdr)
        If intRetVal = 9 Then
            SetProps(Me, txtObservaciones, txtObservaciones, PROP_ENABLED, True)
        End If
        RetVal = NoAutoChk
        If Trim(intRetVal) <> 0 Then
            Call Status(StartProcess, False, "", 0)
            Call Status(SaveGoodArgVals, False, "Cargando Información... espere un momento", DISP_ONLY)
            'strSql = "EXEC nuspReporteMVNEW " & SParm(ChkStrg)
            'Call funciones.SetSql(strSql)
            strSql = "EXEC sp_observaciones " & SParm(ChkStrg)
            Call funciones.SetSql(strSql)
            Call Status(EndProcess, 0, "Información cargada con Exito", True)
            Timer1.Start()
            'boton cargar Informacion
            SetProps(Me, btnCargarInformacion, btnCargarInformacion, PROP_VISIBLE, False)
            SetProps(Me, lblmensage, lblmensage, PROP_VISIBLE, False)
            Call SetButton(TbSaveButton, LEVEL0, True)
            Call SetButton(TbDeleteButton, LEVEL0, True)
            Call SetButton(TbSaveButton, LEVEL1, True)
            Call SetButton(TbDeleteButton, LEVEL1, True)
            SetProps(Me, txtObservaciones, txtObservaciones, PROP_ENABLED, True)
            SetProps(Me, txtobservacionescost, txtobservacionescost, PROP_ENABLED, True)
        Else
            If bnuHitorialMVHdr.Status = "CE" Then
                Call SetButton(TbSaveButton, LEVEL0, False)
                Call SetButton(TbDeleteButton, LEVEL0, False)
                Call SetButton(TbSaveButton, LEVEL1, False)
                Call SetButton(TbDeleteButton, LEVEL1, False)
                SetProps(Me, txtObservaciones, txtObservaciones, PROP_ENABLED, False)
                SetProps(Me, txtobservacionescost, txtobservacionescost, PROP_ENABLED, False)
                SetProps(Me, btnCargarInformacion, btnCargarInformacion, PROP_VISIBLE, False)
                SetProps(Me, lblmensage, lblmensage, PROP_VISIBLE, False)
            Else
                Call SetButton(TbSaveButton, LEVEL0, True)
                Call SetButton(TbDeleteButton, LEVEL0, True)
                Call SetButton(TbSaveButton, LEVEL1, True)
                Call SetButton(TbDeleteButton, LEVEL1, True)
                SetProps(Me, btnCargarInformacion, btnCargarInformacion, PROP_VISIBLE, False)
                SetProps(Me, lblmensage, lblmensage, PROP_VISIBLE, True)
                SetProps(Me, txtObservaciones, txtObservaciones, PROP_ENABLED, True)
                SetProps(Me, txtobservacionescost, txtobservacionescost, PROP_ENABLED, True)
            End If
        End If
    End Sub
#End Region
#Region "LLENA PRIMER GRID"
    Private Sub LlenarGridinfoGeneral(ByVal strSemana As String)
        Dim strQuery As String
        Dim intCursor As Integer
        Dim intRetval As Integer
        Dim item As Double = 0.0
        Dim itemNumber As Double = 0.0

        Dim totalAutorizado As Double = 0.0
        Dim totalComprado As Double = 0.0

        Dim totalExtra As Double = 0.0
        Dim totalOrdExtra As Double = 0.0

        Dim totalReordem As Double = 0.0
        Dim totalOrdReorden As Double = 0.0

        Dim Boehringer As Double = 0.0
        Dim totalOrdBoehringer As Double = 0.0

        Dim totalgeneralmxn As Double = 0.0

        SqlCursor(intCursor, NOLEVEL)
        strQuery = "select * from  nuMVReporte Where semana  = '" & Trim(strSemana) & "' "
        intRetval = SqlFetch1(intCursor, strQuery, bnuMVReporte)
        'LIMPIA EL GRID PARA CARGAR LOS DATOS DE CADA FILTRO
        Call MClear(MemHandle_Spread1)
        'CICLO QUE RECORRE CADA UNO DE LOS REGISTROS QUE CONTIENE EL strQuery que es llenado por medio de la consulta
        Do While intRetval = 0

            Call MInsert(MemHandle_Spread1)
            bnuHitorialMV.Semana = bnuMVReporte.Semana

            If Trim(bnuMVReporte.Proveedor) = "" Then
                bnuHitorialMV.Proveedor = "Partidas"
                bnuHitorialMV.NombreProveedor = "No Procesadas para Orden de Compra"
            Else
                bnuHitorialMV.Proveedor = bnuMVReporte.Proveedor
                bnuHitorialMV.NombreProveedor = bnuMVReporte.NombreProveedor
            End If
            bnuHitorialMV.Articulo = bnuMVReporte.Articulo
            bnuHitorialMV.Art = bnuMVReporte.Art
            bnuHitorialMV.Descripcion = bnuMVReporte.Descripcion
            bnuHitorialMV.CantAutorizada = bnuMVReporte.CantAutorizada
            bnuHitorialMV.CostoUnitAutorizado = bnuMVReporte.CostoUnitAutorizado
            bnuHitorialMV.ImporteTotalAuto = bnuMVReporte.CantAutorizada * bnuMVReporte.CostoUnitAutorizado
            bnuHitorialMV.CantEnOrdenCompra = bnuMVReporte.CantEnOrdenCompra
            bnuHitorialMV.CostoEnOrden = bnuMVReporte.CostoEnOrden
            bnuHitorialMV.ImporteEnorden = bnuMVReporte.CantEnOrdenCompra * bnuMVReporte.CostoEnOrden

            'calculamos el importe con el tipo de cambio en caso de que sea moneda extrangera
            bnuHitorialMV.CantRecibida = bnuMVReporte.CantRecibida
            DispField(dblPesos)
            totalgeneralmxn = totalgeneralmxn + bnuHitorialMV.CantRecibida
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            bnuHitorialMV.observaciones = bnuMVReporte.observaciones
            item = item + 1
            itemNumber = item
            bnuHitorialMV.Cantdiferencia = itemNumber
            DispField(floDiferencia)

            If bnuHitorialMV.CantEnOrdenCompra = 0.0 And bnuMVReporte.CantAutorizada > 0.0 Then
                bnuHitorialMV.CantidaddeInvetario = bnuMVReporte.CantAutorizada - bnuMVReporte.CantEnOrdenCompra
                DispField(floAmacen)
                bnuHitorialMV.CantRedondeo = 0.0
                DispField(floRedondeo)
            Else
                If bnuMVReporte.CantAutorizada > bnuHitorialMV.CantEnOrdenCompra Then
                    bnuHitorialMV.CantidaddeInvetario = bnuMVReporte.CantAutorizada - bnuMVReporte.CantEnOrdenCompra
                    DispField(floAmacen)
                    bnuHitorialMV.CantRedondeo = 0.0
                    DispField(floRedondeo)
                End If
                If bnuMVReporte.CantAutorizada < bnuHitorialMV.CantEnOrdenCompra Then
                    bnuHitorialMV.CantRedondeo = bnuMVReporte.CantEnOrdenCompra - bnuMVReporte.CantAutorizada
                    DispField(floRedondeo)
                    bnuHitorialMV.CantidaddeInvetario = 0.0
                    DispField(floAmacen)
                End If
                If bnuMVReporte.CantAutorizada = bnuHitorialMV.CantEnOrdenCompra Then
                    bnuHitorialMV.CantRedondeo = 0.0
                    DispField(floRedondeo)
                    bnuHitorialMV.CantidaddeInvetario = 0.0
                    DispField(floAmacen)
                End If
            End If

            If bnuMVReporte.CostoEnOrden = 0.0 Then
                bnuHitorialMV.CostoRecepcion = 0.0
            Else
                bnuHitorialMV.CostoRecepcion = bnuMVReporte.CostoUnitAutorizado - bnuMVReporte.CostoEnOrden
            End If
            bnuHitorialMV.tipo = bnuMVReporte.tipo
            'TOTALES DE SOLO LO PRESUPUESTADO

            If Trim(bnuHitorialMV.tipo) = "MSPE" Then
                Boehringer = Boehringer + bnuHitorialMV.ImporteTotalAuto
                totalOrdBoehringer = totalOrdBoehringer + bnuHitorialMV.ImporteEnorden
            ElseIf Trim(bnuHitorialMV.tipo) = "PRPE" Then
                ' CAMBIOMOS PAERA QUE MUESTRE TODO EN MONEDA NACIONAL
                totalAutorizado = totalAutorizado + bnuHitorialMV.ImporteTotalAuto
                totalComprado = totalComprado + bnuHitorialMV.CantRecibida 'bnuHitorialMV.ImporteEnorden
            ElseIf Trim(bnuHitorialMV.tipo) = "EXPE" Then
                totalExtra = totalExtra + bnuHitorialMV.ImporteTotalAuto
                totalOrdExtra = totalOrdExtra + bnuHitorialMV.ImporteEnorden
            ElseIf Trim(bnuHitorialMV.tipo) = "REORDEN" Then
                totalReordem = totalReordem + bnuHitorialMV.ImporteTotalAuto
                totalOrdReorden = totalOrdReorden + bnuHitorialMV.ImporteEnorden
            End If
            'Contador de Progreso
            Call MUpdate(MemHandle_Spread1)
            Call SetLevelChg(LEVEL1, INSERTED)
            intRetval = SFetch1(intCursor, bnuMVReporte)
        Loop
        'PRSUPUESTADO
        bnuHitorialMVHdr.TotalAutorizado = totalAutorizado
        DispField(dbltotalAuto)
        bnuHitorialMVHdr.TotalOrdenado = totalComprado
        DispField(dbltotalcompra)
        'EXTRAORDINARIO
        bnuHitorialMVHdr.TotalExtra = totalExtra
        DispField(dblExtra)
        bnuHitorialMVHdr.TotalOrdExtra = totalOrdExtra
        DispField(dblOrdExtra)
        'REORDEN
        bnuHitorialMVHdr.TotalReorden = totalReordem
        DispField(dblReorden)
        bnuHitorialMVHdr.TotalOrdReord = totalOrdReorden
        DispField(dblOrdReorden)
        'Boehringer
        bnuHitorialMVHdr.TotalProve = Boehringer
        DispField(dblProve)
        bnuHitorialMVHdr.TotalOrdProve = totalOrdBoehringer
        DispField(dblOrdProve)
        'General MXN
        bnuHitorialMVHdr.TotalMXN = totalgeneralmxn
        DispField(dblTotalGeneralMXN)

        Call MSetRow(MemHandle_Spread1, 1)
        Call MDisplay(MemHandle_Spread1)
        Call SqlFree(intCursor)
        SetProps(Me, btnCargarInformacion, btnCargarInformacion, PROP_VISIBLE, False)
    End Sub
#End Region
#Region "Cargamos la informacion de la Semana Que se Seleccione"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarInformacion.Click
        LlenarGridinfoGeneral(bnuHitorialMVHdr.Semana)
        LlenarGridTodaslasRequis(bnuHitorialMVHdr.Semana)
        LlenarGridOrdenes(bnuHitorialMVHdr.Semana)
    End Sub
#End Region
#Region "Evento que edita el Status al Guardar y cerrar el Reporte"
    Private Sub Update1_FinishEvent(ByVal Level As Short, ByVal Updated As Short, ByRef RetVal As Short) Handles Update1.FinishEvent
        Dim strSql As String
        If Trim(bnuHitorialMVHdr.Manejo) = "CE" And Trim(bnuHitorialMVHdr.Status) = "EN" Then
            strSql = "Update nuHitorialMVHdr Set Status='CE',Manejo='CE' Where Semana = " & SParm(bnuHitorialMVHdr.Semana)
            Call funciones.SetSql(strSql)
        End If
    End Sub
#End Region
#Region "CALCULAMOS LA DIFERENCIA DE LO SOLICITADO A LO QUE ESTA EN LA ORDEN COMPRA"
    Private Sub SafFloat10_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16)
        bnuHitorialMV.Cantdiferencia = (bnuHitorialMV.CantAutorizada - ChkStrg) - bnuHitorialMV.CantEnOrdenCompra
    End Sub

    Private Sub SafFloat11_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16)
        bnuHitorialMV.Cantdiferencia = (bnuHitorialMV.CantAutorizada + ChkStrg) - bnuHitorialMV.CantEnOrdenCompra
    End Sub
#End Region
    Private Sub LlenarGridTodaslasRequis(ByVal strSemana As String)
        Dim strQuery As String
        Dim intCursor As Integer
        Dim intRetval As Integer

        SqlCursor(intCursor, NOLEVEL)
        strQuery = "select *  from nurqReqHdr H (nolock)" & _
        "Where H.DivSolic ='PE'  and  H.User2 in( 'MEDYVAC','QUIMICO','ARTLIMP') " & _
        "AND H.Status in('U','C','A') and H.MotivoRet in('EXPE','MSPE','PRPE') AND H.S4Future02 = '" & Trim(strSemana) & "'" & _
         "order by H.MotivoRet"

        intRetval = SqlFetch1(intCursor, strQuery, bnurqReqHdr)
        'LIMPIA EL GRID PARA CARGAR LOS DATOS DE CADA FILTRO
        Call MClear(MemHandle_Spread2)
        'CICLO QUE RECORRE CADA UNO DE LOS REGISTROS QUE CONTIENE EL strQuery que es llenado por medio de la consulta
        Do While intRetval = 0

            Call MInsert(MemHandle_Spread2)
            bnucaRqGeneradas.BatNbr = bnurqReqHdr.BatNbr
            DispField(txtNoLote3)
            bnucaRqGeneradas.SemanaAno = bnurqReqHdr.MotivoRet
            DispField(SafMaskedText1)
            bnucaRqGeneradas.DivSolic = bnurqReqHdr.Status
            DispField(cboStatus0)
            bnucaRqGeneradas.AreaSolic = bnurqReqHdr.AreaSolic
            DispField(txtAreaSoli3)
            bnucaRqGeneradas.PersonaSol = bnurqReqHdr.PersonaSol
            DispField(txtPersonaSol3)
            Call MUpdate(MemHandle_Spread2)
            intRetval = SFetch1(intCursor, bnurqReqHdr)
        Loop
        Call MSetRow(MemHandle_Spread2, 1)
        Call MDisplay(MemHandle_Spread2)
        Call SqlFree(intCursor)

    End Sub
    Private Sub LlenarGridOrdenes(ByVal strSemana As String)
        Dim strQuery As String
        Dim intCursor As Integer
        Dim intRetval As Integer

        SqlCursor(intCursor, NOLEVEL)

        strQuery = "SELECT * FROM ordCompraMVCh WHERE S4Future02 = '" & Trim(strSemana) & "'"

        intRetval = SqlFetch1(intCursor, strQuery, bordCompraMVCh)

        'LIMPIA EL GRID PARA CARGAR LOS DATOS DE CADA FILTRO
        Call MClear(MemHandle_Spread3)
        'CICLO QUE RECORRE CADA UNO DE LOS REGISTROS QUE CONTIENE EL strQuery que es llenado por medio de la consulta
        Do While intRetval = 0
            Call MInsert(MemHandle_Spread3)
            'bordComMV.Buyer = bordCompraMVCh.id
            bordComMV.PONbr = bordCompraMVCh.PONbr
            bordComMV.batNbr = bordCompraMVCh.batNbr
            bordComMV.S4Future02 = bordCompraMVCh.S4Future02
            bordComMV.Buyer = bordCompraMVCh.Buyer
            Call MUpdate(MemHandle_Spread3)
            intRetval = SFetch1(intCursor, bordCompraMVCh)
        Loop
        Call MSetRow(MemHandle_Spread3, 1)
        Call MDisplay(MemHandle_Spread3)
        Call SqlFree(intCursor)

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            MSQBOX()
            ProgressBar1.Value = 0
        End If
    End Sub
#Region "MENSAJE BOX PARA TERMINO DE PROCESO"
    Private Sub MSQBOX()
        Dim Msg, Style, Title, Response
        Msg = "Proceso de Actualización de la Información Terminado"    ' Define message.
        Style = vbOKOnly + vbInformation + vbDefaultButton2    ' Define buttons.
        Title = "Notificación"    ' Define title.       
        ' Display message.
        Response = MsgBox(Msg, Style, Title)
        If Response = 1 Then    ' User chose Yes.
            LlenarGridinfoGeneral(bnuHitorialMVHdr.Semana)
            LlenarGridTodaslasRequis(bnuHitorialMVHdr.Semana)
            LlenarGridOrdenes(bnuHitorialMVHdr.Semana)
        End If
    End Sub
#End Region
#Region "NO PERMITE COMENTARIO DONDE NO HAY DIFERENCIA"
    Private Sub txtObservaciones_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16)
        If Trim(bnuHitorialMV.CantRedondeo) = 0.0 And Trim(bnuHitorialMV.CantidaddeInvetario) = 0.0 Then
            MsgBox("¡Campo deshabilitado no se encontro diferencias en Cantidades!", MsgBoxStyle.Critical, "Mensaje")
            RetVal = ErrNoMess
        End If
    End Sub
    Private Sub txtobservacionescost_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16)
        If Trim(bnuHitorialMV.CostoRecepcion) = 0.0 Then
            MsgBox("¡Campo deshabilitado no se enctontro diferencia en costos!", MsgBoxStyle.Critical, "Mensaje")
            RetVal = ErrNoMess
        End If
    End Sub
#End Region
#Region "EJECUTAMOS LA BUSQUEDA DE LAS REQUISICIONES Y ORDENES DE COMPRA"
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strSql2 As String
        If Trim(bnuHitorialMVHdr.Semana) = "" Then
        Else
            strSql2 = "EXEC OrdCompraMV " & SParm(bnuHitorialMVHdr.Semana)
            Call funciones.SetSql(strSql2)
            LlenarGridTodaslasRequis(bnuHitorialMVHdr.Semana)
            LlenarGridOrdenes(bnuHitorialMVHdr.Semana)
        End If
    End Sub
#End Region
#Region "PROCESAMOS Y RECLASIFICAMOS LAS REQUISICIONES"
    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Call LecturadelGrid2()
    'End Sub
    'Public Sub LecturadelGrid2()
    '    Dim intRegActual As Short
    '    Dim intRegInicial As Short
    '    Dim striRequi As String
    '    Dim striSemana As String
    '    Dim striMotivoR As String
    '    Dim msgRespuesta As MsgBoxResult
    '    Dim strSql As String
    '    Dim item As Integer = 0

    '    intRegInicial = MGetRowNum(MemHandle_Spread3)
    '    For intRegActual = 1 To MArrayCnt(MemHandle_Spread3)
    '        Call MSetRow(MemHandle_Spread3, intRegActual)
    '        item = item + 1
    '        striRequi = bordComMV.batNbr
    '        striSemana = bordComMV.S4Future02
    '        striMotivoR = bordComMV.Buyer
    '        msgRespuesta = MsgBox("La Requisicón : " & Trim(striRequi) & " se reclasifica a la Semana  " & Trim(striSemana) & " Tipo " & Trim(striMotivoR) & "  , ¿desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pregunta")
    '        If msgRespuesta = MsgBoxResult.Yes Then
    '            strSql = "Exec cambiaclasificacion" & SParm(striSemana) & SParm(striRequi) & SParm(striMotivoR)
    '            Call funciones.SetSql(strSql)
    '        End If
    '        MUpdate(MemHandle_Spread3)
    '    Next
    '    Call MSetRow(MemHandle_Spread3, intRegInicial)
    '    MDisplay(MemHandle_Spread3)
    '    If item = 0 Then
    '        MessageBox.Show("No existen ordenes que Reclasificar", "Información")
    '    Else
    '        MessageBox.Show("Proceso Terminado, Las Requisiciones fueron raclasificadas", "Información")
    '    End If
    'End Sub
#End Region
#Region "VALIDAMOS QUE ESTEN LOS COMENTARIOS "
    Public Sub validacomentario()
        Dim intRegActual As Short
        Dim intRegInicial As Short
        Dim msgRespuesta As MsgBoxResult
        Dim NoPartida As String
        Dim correcto As Integer = 0

        intRegInicial = MGetRowNum(MemHandle_Spread1)
        For intRegActual = 1 To MArrayCnt(MemHandle_Spread1)
            Call MSetRow(MemHandle_Spread1, intRegActual)
            NoPartida = bnuHitorialMV.Cantdiferencia

            If bnuHitorialMV.CantRedondeo <> 0 And Trim(bnuHitorialMV.observaciones) = "" Then
                correcto = correcto + 1
                msgRespuesta = MsgBox("Agrega Observacion,hay diferencia en Redondeo, el la partida No: " + NoPartida, MsgBoxStyle.Critical)
            End If
            If bnuHitorialMV.CostoRecepcion <> 0 And Trim(bnuHitorialMV.observaCostos) = "" Then
                correcto = correcto + 1
                msgRespuesta = MsgBox("Agrega Observacion,hay diferencia en Costo Unitario, el la partida No: " + NoPartida, MsgBoxStyle.Critical)
            End If

            MUpdate(MemHandle_Spread1)
        Next
        Call MSetRow(MemHandle_Spread1, intRegInicial)
        MDisplay(MemHandle_Spread1)

        If correcto = 0 Then
            msgRespuesta = MsgBox("Registro de Comentarios Correcto ", MsgBoxStyle.Information)
        End If

    End Sub
#End Region
#Region "EVENTO QUE VALIDA QUE TODOS LO COMENTARIOS ESTEN REGISTRADOS"
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        validacomentario()
    End Sub
#End Region

    Private Sub txtObservaciones_ChkEvent_1(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtObservaciones.ChkEvent
        If Trim(bnuHitorialMV.CantRedondeo) = 0.0 And Trim(bnuHitorialMV.CantidaddeInvetario) = 0.0 Then
            MsgBox("¡Campo deshabilitado no se encontro diferencias en Cantidades!", MsgBoxStyle.Critical, "Mensaje")
            RetVal = ErrNoMess
        End If
    End Sub

    Private Sub txtobservacionescost_ChkEvent_1(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles txtobservacionescost.ChkEvent
        If Trim(bnuHitorialMV.CostoRecepcion) = 0.0 Then
            MsgBox("¡Campo deshabilitado no se enctontro diferencia en costos!", MsgBoxStyle.Critical, "Mensaje")
            RetVal = ErrNoMess
        End If
    End Sub
    
    Private Sub cboTipoRequi_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles cboTipoRequi.ChkEvent
        Dim striRequi As String
        Dim striSemana As String
        Dim striMotivoR As String
        Dim msgRespuesta As MsgBoxResult
        Dim strSql As String
        striRequi = bordComMV.batNbr
        striSemana = bordComMV.S4Future02
        striMotivoR = ChkStrg
        msgRespuesta = MsgBox("La Requisicón : " & Trim(striRequi) & " se reclasifica a la Semana  " & Trim(striSemana) & " Tipo " & Trim(striMotivoR) & "  , ¿desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pregunta")
        If msgRespuesta = MsgBoxResult.Yes Then
            strSql = "Exec cambiaclasificacion" & SParm(Trim(striSemana)) & SParm(Trim(striRequi)) & SParm(Trim(striMotivoR))
            Call funciones.SetSql(strSql)
        End If
    End Sub

    Private Sub SafMaskedText3_ChkEvent(ByRef ChkStrg As System.String, ByRef RetVal As System.Int16) Handles SafMaskedText3.ChkEvent
        Dim striRequi As String
        Dim striSemana As String
        Dim striMotivoR As String
        Dim msgRespuesta As MsgBoxResult
        Dim strSql As String
        striRequi = bordComMV.batNbr
        striSemana = ChkStrg
        striMotivoR = bordComMV.Buyer
        msgRespuesta = MsgBox("La Requisicón : " & Trim(striRequi) & " se reclasifica a la Semana  " & Trim(striSemana) & " Tipo " & Trim(striMotivoR) & "  , ¿desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Pregunta")
        If msgRespuesta = MsgBoxResult.Yes Then
            strSql = "Exec cambiaclasificacion" & SParm(Trim(striSemana)) & SParm(Trim(striRequi)) & SParm(Trim(striMotivoR))
            Call funciones.SetSql(strSql)
        End If
    End Sub
End Class

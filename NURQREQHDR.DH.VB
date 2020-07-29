 Option Strict Off

 Option Explicit On

 Imports Solomon.Kernel

 Module sdonurqReqHdr

Public Class nurqReqHdr

    Inherits SolomonDataObject

    'Definicion de Variables para manejo de valores de Propiedades


    < _
    DataBinding(PropertyIndex:=0, StringSize:=10) _
    > _
    Public Property BatNbr() As String
        Get
            Return Me.GetPropertyValue("BatNbr")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("BatNbr", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=1, StringSize:=10) _
    > _
    Public Property Periodo() As String
        Get
            Return Me.GetPropertyValue("Periodo")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Periodo", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=2, StringSize:=30) _
    > _
    Public Property DivSolic() As String
        Get
            Return Me.GetPropertyValue("DivSolic")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("DivSolic", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=3, StringSize:=30) _
    > _
    Public Property AreaSolic() As String
        Get
            Return Me.GetPropertyValue("AreaSolic")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("AreaSolic", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=4, StringSize:=30) _
    > _
    Public Property PersonaSol() As String
        Get
            Return Me.GetPropertyValue("PersonaSol")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("PersonaSol", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=5) _
    > _
    Public Property Fecha() As Integer
        Get
            Return Me.GetPropertyValue("Fecha")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("Fecha", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=6, StringSize:=12) _
    > _
    Public Property Hora() As String
        Get
            Return Me.GetPropertyValue("Hora")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Hora", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=7, StringSize:=1) _
    > _
    Public Property Prioridad() As String
        Get
            Return Me.GetPropertyValue("Prioridad")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Prioridad", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=8, StringSize:=10) _
    > _
    Public Property Cuenta() As String
        Get
            Return Me.GetPropertyValue("Cuenta")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Cuenta", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=9, StringSize:=24) _
    > _
    Public Property Entidad() As String
        Get
            Return Me.GetPropertyValue("Entidad")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Entidad", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=10, StringSize:=1) _
    > _
    Public Property Status() As String
        Get
            Return Me.GetPropertyValue("Status")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Status", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=11, StringSize:=1) _
    > _
    Public Property Manejo() As String
        Get
            Return Me.GetPropertyValue("Manejo")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Manejo", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=12, StringSize:=1) _
    > _
    Public Property SIM_TComp() As String
        Get
            Return Me.GetPropertyValue("SIM_TComp")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("SIM_TComp", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=13, StringSize:=10) _
    > _
    Public Property SIM_Unidad() As String
        Get
            Return Me.GetPropertyValue("SIM_Unidad")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("SIM_Unidad", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=14, StringSize:=10) _
    > _
    Public Property SIM_OS() As String
        Get
            Return Me.GetPropertyValue("SIM_OS")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("SIM_OS", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=15, StringSize:=10) _
    > _
    Public Property SIM_SubFolio() As String
        Get
            Return Me.GetPropertyValue("SIM_SubFolio")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("SIM_SubFolio", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=16, StringSize:=250) _
    > _
    Public Property MotivoRet() As String
        Get
            Return Me.GetPropertyValue("MotivoRet")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("MotivoRet", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=17, StringSize:=30) _
    > _
    Public Property TipoSurtido() As String
        Get
            Return Me.GetPropertyValue("TipoSurtido")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("TipoSurtido", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=18, StringSize:=10) _
    > _
    Public Property Formatek() As String
        Get
            Return Me.GetPropertyValue("Formatek")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Formatek", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=19, StringSize:=30) _
    > _
    Public Property CompRap() As String
        Get
            Return Me.GetPropertyValue("CompRap")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("CompRap", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=20, StringSize:=30) _
    > _
    Public Property ImpresoPor() As String
        Get
            Return Me.GetPropertyValue("ImpresoPor")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("ImpresoPor", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=21, StringSize:=10) _
    > _
    Public Property CpnyID() As String
        Get
            Return Me.GetPropertyValue("CpnyID")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("CpnyID", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=22) _
    > _
    Public Property Crtd_DateTime() As Integer
        Get
            Return Me.GetPropertyValue("Crtd_DateTime")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("Crtd_DateTime", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=23, StringSize:=8) _
    > _
    Public Property Crtd_Time() As String
        Get
            Return Me.GetPropertyValue("Crtd_Time")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Crtd_Time", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=24, StringSize:=8) _
    > _
    Public Property Crtd_Prog() As String
        Get
            Return Me.GetPropertyValue("Crtd_Prog")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Crtd_Prog", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=25, StringSize:=10) _
    > _
    Public Property Crtd_User() As String
        Get
            Return Me.GetPropertyValue("Crtd_User")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Crtd_User", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=26) _
    > _
    Public Property LUpd_DateTime() As Integer
        Get
            Return Me.GetPropertyValue("LUpd_DateTime")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("LUpd_DateTime", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=27, StringSize:=8) _
    > _
    Public Property LUpd_Time() As String
        Get
            Return Me.GetPropertyValue("LUpd_Time")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("LUpd_Time", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=28, StringSize:=8) _
    > _
    Public Property LUpd_Prog() As String
        Get
            Return Me.GetPropertyValue("LUpd_Prog")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("LUpd_Prog", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=29, StringSize:=10) _
    > _
    Public Property LUpd_User() As String
        Get
            Return Me.GetPropertyValue("LUpd_User")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("LUpd_User", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=30) _
    > _
    Public Property NoteId() As Integer
        Get
            Return Me.GetPropertyValue("NoteId")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("NoteId", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=31, StringSize:=30) _
    > _
    Public Property S4Future01() As String
        Get
            Return Me.GetPropertyValue("S4Future01")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("S4Future01", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=32, StringSize:=30) _
    > _
    Public Property S4Future02() As String
        Get
            Return Me.GetPropertyValue("S4Future02")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("S4Future02", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=33) _
    > _
    Public Property S4Future03() As Double
        Get
            Return Me.GetPropertyValue("S4Future03")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("S4Future03", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=34) _
    > _
    Public Property S4Future04() As Double
        Get
            Return Me.GetPropertyValue("S4Future04")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("S4Future04", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=35) _
    > _
    Public Property S4Future05() As Double
        Get
            Return Me.GetPropertyValue("S4Future05")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("S4Future05", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=36) _
    > _
    Public Property S4Future06() As Double
        Get
            Return Me.GetPropertyValue("S4Future06")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("S4Future06", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=37) _
    > _
    Public Property S4Future07() As Integer
        Get
            Return Me.GetPropertyValue("S4Future07")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("S4Future07", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=38) _
    > _
    Public Property S4Future08() As Integer
        Get
            Return Me.GetPropertyValue("S4Future08")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("S4Future08", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=39) _
    > _
    Public Property S4Future09() As Integer
        Get
            Return Me.GetPropertyValue("S4Future09")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("S4Future09", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=40) _
    > _
    Public Property S4Future10() As Integer
        Get
            Return Me.GetPropertyValue("S4Future10")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("S4Future10", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=41, StringSize:=10) _
    > _
    Public Property S4Future11() As String
        Get
            Return Me.GetPropertyValue("S4Future11")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("S4Future11", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=42, StringSize:=10) _
    > _
    Public Property S4Future12() As String
        Get
            Return Me.GetPropertyValue("S4Future12")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("S4Future12", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=43, StringSize:=30) _
    > _
    Public Property User1() As String
        Get
            Return Me.GetPropertyValue("User1")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("User1", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=44, StringSize:=30) _
    > _
    Public Property User2() As String
        Get
            Return Me.GetPropertyValue("User2")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("User2", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=45) _
    > _
    Public Property User3() As Double
        Get
            Return Me.GetPropertyValue("User3")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("User3", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=46) _
    > _
    Public Property User4() As Double
        Get
            Return Me.GetPropertyValue("User4")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("User4", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=47) _
    > _
    Public Property User5() As Double
        Get
            Return Me.GetPropertyValue("User5")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("User5", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=48) _
    > _
    Public Property User6() As Double
        Get
            Return Me.GetPropertyValue("User6")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("User6", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=49, StringSize:=10) _
    > _
    Public Property User7() As String
        Get
            Return Me.GetPropertyValue("User7")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("User7", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=50, StringSize:=10) _
    > _
    Public Property User8() As String
        Get
            Return Me.GetPropertyValue("User8")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("User8", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=51, StringSize:=10) _
    > _
    Public Property User9() As String
        Get
            Return Me.GetPropertyValue("User9")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("User9", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=52) _
    > _
    Public Property User10() As Integer
        Get
            Return Me.GetPropertyValue("User10")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("User10", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=53) _
    > _
    Public Property User11() As Integer
        Get
            Return Me.GetPropertyValue("User11")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("User11", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=54) _
    > _
    Public Property User12() As Integer
        Get
            Return Me.GetPropertyValue("User12")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("User12", Value)
        End Set 
    End Property

End Class

    Public bnurqReqHdr As nurqReqHdr = New nurqReqHdr, nnurqReqHdr As nurqReqHdr = New nurqReqHdr
    Public CSR_nurqReqHdr As Short

    Sub Init_nurqReqHdr(ByRef x_Level As Short, ByRef x_Cursor As Boolean)
        Call SetAddr(x_Level, "bnurqReqHdr", bnurqReqHdr, nnurqReqHdr)
        If x_Cursor = True Then
            Call SqlCursorEx(CSR_nurqReqHdr, x_Level, "CSR_nurqReqHdr", "nurqReqHdr", "")
        End If
   End Sub
End Module



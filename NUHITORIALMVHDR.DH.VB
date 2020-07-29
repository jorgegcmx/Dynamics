 Option Strict Off

 Option Explicit On

 Imports Solomon.Kernel

 Module sdonuHitorialMVHdr

Public Class nuHitorialMVHdr

    Inherits SolomonDataObject

    'Definicion de Variables para manejo de valores de Propiedades


    < _
    DataBinding(PropertyIndex:=0, StringSize:=10) _
    > _
    Public Property Semana() As String
        Get
            Return Me.GetPropertyValue("Semana")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Semana", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=1, StringSize:=2) _
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
    DataBinding(PropertyIndex:=2, StringSize:=2) _
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
    DataBinding(PropertyIndex:=3) _
    > _
    Public Property TotalAutorizado() As Double
        Get
            Return Me.GetPropertyValue("TotalAutorizado")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalAutorizado", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=4) _
    > _
    Public Property TotalOrdenado() As Double
        Get
            Return Me.GetPropertyValue("TotalOrdenado")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalOrdenado", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=5) _
    > _
    Public Property TotalExtra() As Double
        Get
            Return Me.GetPropertyValue("TotalExtra")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalExtra", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=6) _
    > _
    Public Property TotalOrdExtra() As Double
        Get
            Return Me.GetPropertyValue("TotalOrdExtra")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalOrdExtra", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=7) _
    > _
    Public Property TotalReorden() As Double
        Get
            Return Me.GetPropertyValue("TotalReorden")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalReorden", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=8) _
    > _
    Public Property TotalOrdReord() As Double
        Get
            Return Me.GetPropertyValue("TotalOrdReord")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalOrdReord", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=9) _
    > _
    Public Property TotalProve() As Double
        Get
            Return Me.GetPropertyValue("TotalProve")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalProve", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=10) _
    > _
    Public Property TotalOrdProve() As Double
        Get
            Return Me.GetPropertyValue("TotalOrdProve")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalOrdProve", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=11) _
    > _
    Public Property TotalMXN() As Double
        Get
            Return Me.GetPropertyValue("TotalMXN")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("TotalMXN", Value)
        End Set 
    End Property

End Class

    Public bnuHitorialMVHdr As nuHitorialMVHdr = New nuHitorialMVHdr, nnuHitorialMVHdr As nuHitorialMVHdr = New nuHitorialMVHdr
    Public CSR_nuHitorialMVHdr As Short

    Sub Init_nuHitorialMVHdr(ByRef x_Level As Short, ByRef x_Cursor As Boolean)
        Call SetAddr(x_Level, "bnuHitorialMVHdr", bnuHitorialMVHdr, nnuHitorialMVHdr)
        If x_Cursor = True Then
            Call SqlCursorEx(CSR_nuHitorialMVHdr, x_Level, "CSR_nuHitorialMVHdr", "nuHitorialMVHdr", "")
        End If
   End Sub
End Module



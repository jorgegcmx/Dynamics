 Option Strict Off

 Option Explicit On

 Imports Solomon.Kernel

 Module sdonucaRqGeneradas

Public Class nucaRqGeneradas

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
    DataBinding(PropertyIndex:=1) _
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
    DataBinding(PropertyIndex:=5, StringSize:=4) _
    > _
    Public Property SemanaAno() As String
        Get
            Return Me.GetPropertyValue("SemanaAno")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("SemanaAno", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=6, StringSize:=2) _
    > _
    Public Property button() As String
        Get
            Return Me.GetPropertyValue("button")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("button", Value)
        End Set 
    End Property

End Class

    Public bnucaRqGeneradas As nucaRqGeneradas = New nucaRqGeneradas, nnucaRqGeneradas As nucaRqGeneradas = New nucaRqGeneradas
    Public CSR_nucaRqGeneradas As Short

    Sub Init_nucaRqGeneradas(ByRef x_Level As Short, ByRef x_Cursor As Boolean)
        Call SetAddr(x_Level, "bnucaRqGeneradas", bnucaRqGeneradas, nnucaRqGeneradas)
        If x_Cursor = True Then
            Call SqlCursorEx(CSR_nucaRqGeneradas, x_Level, "CSR_nucaRqGeneradas", "nucaRqGeneradas", "")
        End If
   End Sub
End Module



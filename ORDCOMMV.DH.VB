 Option Strict Off

 Option Explicit On

 Imports Solomon.Kernel

 Module sdoordComMV

Public Class ordComMV

    Inherits SolomonDataObject

    'Definicion de Variables para manejo de valores de Propiedades


    < _
    DataBinding(PropertyIndex:=0, StringSize:=10) _
    > _
    Public Property PONbr() As String
        Get
            Return Me.GetPropertyValue("PONbr")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("PONbr", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=1, StringSize:=10) _
    > _
    Public Property Buyer() As String
        Get
            Return Me.GetPropertyValue("Buyer")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Buyer", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=2, StringSize:=10) _
    > _
    Public Property batNbr() As String
        Get
            Return Me.GetPropertyValue("batNbr")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("batNbr", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=3, StringSize:=30) _
    > _
    Public Property S4Future02() As String
        Get
            Return Me.GetPropertyValue("S4Future02")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("S4Future02", Value)
        End Set 
    End Property

End Class

    Public bordComMV As ordComMV = New ordComMV, nordComMV As ordComMV = New ordComMV
    Public CSR_ordComMV As Short

    Sub Init_ordComMV(ByRef x_Level As Short, ByRef x_Cursor As Boolean)
        Call SetAddr(x_Level, "bordComMV", bordComMV, nordComMV)
        If x_Cursor = True Then
            Call SqlCursorEx(CSR_ordComMV, x_Level, "CSR_ordComMV", "ordComMV", "")
        End If
   End Sub
End Module



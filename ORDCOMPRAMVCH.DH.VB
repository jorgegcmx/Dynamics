 Option Strict Off

 Option Explicit On

 Imports Solomon.Kernel

 Module sdoordCompraMVCh

Public Class ordCompraMVCh

    Inherits SolomonDataObject

    'Definicion de Variables para manejo de valores de Propiedades


    < _
    DataBinding(PropertyIndex:=0) _
    > _
    Public Property id() As Integer
        Get
            Return Me.GetPropertyValue("id")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("id", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=1, StringSize:=10) _
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
    DataBinding(PropertyIndex:=2, StringSize:=10) _
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
    DataBinding(PropertyIndex:=3, StringSize:=10) _
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
    DataBinding(PropertyIndex:=4, StringSize:=30) _
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

    Public bordCompraMVCh As ordCompraMVCh = New ordCompraMVCh, nordCompraMVCh As ordCompraMVCh = New ordCompraMVCh
    Public CSR_ordCompraMVCh As Short

    Sub Init_ordCompraMVCh(ByRef x_Level As Short, ByRef x_Cursor As Boolean)
        Call SetAddr(x_Level, "bordCompraMVCh", bordCompraMVCh, nordCompraMVCh)
        If x_Cursor = True Then
            Call SqlCursorEx(CSR_ordCompraMVCh, x_Level, "CSR_ordCompraMVCh", "ordCompraMVCh", "")
        End If
   End Sub
End Module



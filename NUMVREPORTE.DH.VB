 Option Strict Off

 Option Explicit On

 Imports Solomon.Kernel

 Module sdonuMVReporte

Public Class nuMVReporte

    Inherits SolomonDataObject

    'Definicion de Variables para manejo de valores de Propiedades


    < _
    DataBinding(PropertyIndex:=0) _
    > _
    Public Property ID() As Integer
        Get
            Return Me.GetPropertyValue("ID")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("ID", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=1, StringSize:=10) _
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
    DataBinding(PropertyIndex:=2, StringSize:=10) _
    > _
    Public Property Proveedor() As String
        Get
            Return Me.GetPropertyValue("Proveedor")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Proveedor", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=3, StringSize:=100) _
    > _
    Public Property NombreProveedor() As String
        Get
            Return Me.GetPropertyValue("NombreProveedor")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("NombreProveedor", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=4, StringSize:=10) _
    > _
    Public Property Articulo() As String
        Get
            Return Me.GetPropertyValue("Articulo")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Articulo", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=5, StringSize:=10) _
    > _
    Public Property Art() As String
        Get
            Return Me.GetPropertyValue("Art")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Art", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=6, StringSize:=100) _
    > _
    Public Property Descripcion() As String
        Get
            Return Me.GetPropertyValue("Descripcion")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("Descripcion", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=7) _
    > _
    Public Property CantAuto_Requi() As Double
        Get
            Return Me.GetPropertyValue("CantAuto_Requi")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CantAuto_Requi", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=8) _
    > _
    Public Property CantAutorizada() As Double
        Get
            Return Me.GetPropertyValue("CantAutorizada")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CantAutorizada", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=9) _
    > _
    Public Property CostoUnitAutorizado() As Double
        Get
            Return Me.GetPropertyValue("CostoUnitAutorizado")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CostoUnitAutorizado", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=10) _
    > _
    Public Property ImporteTotalAutorizado() As Double
        Get
            Return Me.GetPropertyValue("ImporteTotalAutorizado")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("ImporteTotalAutorizado", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=11) _
    > _
    Public Property CantEnOrdenCompra() As Double
        Get
            Return Me.GetPropertyValue("CantEnOrdenCompra")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CantEnOrdenCompra", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=12) _
    > _
    Public Property CostoEnOrden() As Double
        Get
            Return Me.GetPropertyValue("CostoEnOrden")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CostoEnOrden", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=13) _
    > _
    Public Property ImporteEnorden() As Double
        Get
            Return Me.GetPropertyValue("ImporteEnorden")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("ImporteEnorden", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=14) _
    > _
    Public Property CantRecibida() As Double
        Get
            Return Me.GetPropertyValue("CantRecibida")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CantRecibida", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=15) _
    > _
    Public Property CostoRecepcion() As Double
        Get
            Return Me.GetPropertyValue("CostoRecepcion")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CostoRecepcion", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=16) _
    > _
    Public Property CantRedondeo() As Double
        Get
            Return Me.GetPropertyValue("CantRedondeo")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CantRedondeo", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=17) _
    > _
    Public Property CantidaddeInvetario() As Double
        Get
            Return Me.GetPropertyValue("CantidaddeInvetario")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CantidaddeInvetario", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=18) _
    > _
    Public Property CantDiferencia() As Double
        Get
            Return Me.GetPropertyValue("CantDiferencia")
        End Get

        Set(ByVal value As Double)
            Me.SetPropertyValue("CantDiferencia", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=19, StringSize:=225) _
    > _
    Public Property observaciones() As String
        Get
            Return Me.GetPropertyValue("observaciones")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("observaciones", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=20, StringSize:=225) _
    > _
    Public Property observaCostos() As String
        Get
            Return Me.GetPropertyValue("observaCostos")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("observaCostos", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=21, StringSize:=10) _
    > _
    Public Property tipo() As String
        Get
            Return Me.GetPropertyValue("tipo")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("tipo", Value)
        End Set 
    End Property

End Class

    Public bnuMVReporte As nuMVReporte = New nuMVReporte, nnuMVReporte As nuMVReporte = New nuMVReporte
    Public CSR_nuMVReporte As Short

    Sub Init_nuMVReporte(ByRef x_Level As Short, ByRef x_Cursor As Boolean)
        Call SetAddr(x_Level, "bnuMVReporte", bnuMVReporte, nnuMVReporte)
        If x_Cursor = True Then
            Call SqlCursorEx(CSR_nuMVReporte, x_Level, "CSR_nuMVReporte", "nuMVReporte", "")
        End If
   End Sub
End Module



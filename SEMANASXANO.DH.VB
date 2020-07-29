 Option Strict Off

 Option Explicit On

 Imports Solomon.Kernel

 Module sdoSemanasXAno

Public Class SemanasXAno

    Inherits SolomonDataObject

    'Definicion de Variables para manejo de valores de Propiedades


    < _
    DataBinding(PropertyIndex:=0) _
    > _
    Public Property ano() As Integer
        Get
            Return Me.GetPropertyValue("ano")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("ano", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=1) _
    > _
    Public Property semana() As Integer
        Get
            Return Me.GetPropertyValue("semana")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("semana", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=2) _
    > _
    Public Property FechaInicial() As Integer
        Get
            Return Me.GetPropertyValue("FechaInicial")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("FechaInicial", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=3) _
    > _
    Public Property FechaFinal() As Integer
        Get
            Return Me.GetPropertyValue("FechaFinal")
        End Get

        Set(ByVal value As Integer)
            Me.SetPropertyValue("FechaFinal", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=4, StringSize:=4) _
    > _
    Public Property SemAno() As String
        Get
            Return Me.GetPropertyValue("SemAno")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("SemAno", Value)
        End Set 
    End Property

    < _
    DataBinding(PropertyIndex:=5, StringSize:=10) _
    > _
    Public Property SemanaAno() As String
        Get
            Return Me.GetPropertyValue("SemanaAno")
        End Get

        Set(ByVal value As String)
            Me.SetPropertyValue("SemanaAno", Value)
        End Set 
    End Property

End Class

    Public bSemanasXAno As SemanasXAno = New SemanasXAno, nSemanasXAno As SemanasXAno = New SemanasXAno
    Public CSR_SemanasXAno As Short

    Sub Init_SemanasXAno(ByRef x_Level As Short, ByRef x_Cursor As Boolean)
        Call SetAddr(x_Level, "bSemanasXAno", bSemanasXAno, nSemanasXAno)
        If x_Cursor = True Then
            Call SqlCursorEx(CSR_SemanasXAno, x_Level, "CSR_SemanasXAno", "SemanasXAno", "")
        End If
   End Sub
End Module



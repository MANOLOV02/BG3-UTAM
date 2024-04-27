Public Class BG3Editor_Template_DyeColorView

    Private _ColorIndex As Integer = 0
    Public Property ColorIndex As Integer
        Get
            Return _ColorIndex
        End Get
        Set(value As Integer)
            _ColorIndex = value
            Cambia_Indice()
        End Set
    End Property
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Label1.Image = New Bitmap(23, 23)
        Cambia_Indice()
    End Sub
    Private Sub Cambia_Indice()
        Label1.Text = FuncionesHelpers.ColorMaterialsNames(_ColorIndex)
    End Sub

End Class

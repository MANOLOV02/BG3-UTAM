Public Class Explorer_Form_Icons
    Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub New(ParentMDI As Form)
        MyBase.New(ParentMDI)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ObjectsTree.ObjectList = FuncionesHelpers.GameEngine.ProcessedIcons
        ObjectsTree.DetailsVisiblesOrNot.Visible = False
        ObjectsTree.ComboBoxParent.Enabled = False
    End Sub


    Public Overrides Sub BackgroundWork_Finished_Sub()
        MyBase.BackgroundWork_Finished_Sub()
        ObjectsTree.ObjectList = FuncionesHelpers.GameEngine.ProcessedIcons
        If ObjectsTree.ArbolWorker.IsBusy = False Then ObjectsTree.Reload_Arbol(False)
    End Sub

    Public Sub Selected(sender As Object, e As TreeViewEventArgs) Handles ObjectsTree.NodeSelected
        Cursor.Current = Cursors.WaitCursor

        If IsNothing(CType(e.Node, Object).objeto) Then
            PictureBox1.Image = Nothing
            PictureBox2.Image = Nothing
            PictureBox3.Image = Nothing
            Label3.Text = "None"
            Label4.Text = "None"
        Else
            PictureBox1.Image = CType(CType(e.Node, Object).objeto, BG3_Obj_IconUV_Class).Get_Icon_FromAtlass
            PictureBox2.Image = CType(CType(e.Node, Object).objeto, BG3_Obj_IconUV_Class).Get_Icon_FromFile
            PictureBox3.Image = CType(CType(e.Node, Object).objeto, BG3_Obj_IconUV_Class).Get_Icon_FromAtlass_or_File
            Label3.Text = "None"
            Label4.Text = "None"
            If Not IsNothing(PictureBox1.Image) Then Label3.Text = PictureBox1.Image.Width.ToString + " x " + PictureBox1.Image.Height.ToString
            If Not IsNothing(PictureBox2.Image) Then Label4.Text = PictureBox2.Image.Width.ToString + " x " + PictureBox2.Image.Height.ToString

        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
Public Class Explorer_Form_Icons
    Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private pict3 As New PictureBox
    Sub New(ParentMDI As Form)
        MyBase.New(ParentMDI)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ObjectsTree.ObjectList = FuncionesHelpers.GameEngine.ProcessedIcons
        ObjectsTree.DetailsVisiblesOrNot.Visible = False
        ObjectsTree.ComboBoxParent.Enabled = False
        TableLayoutPanel1.RowStyles(1).Height = 64
        TableLayoutPanel1.RowStyles(2).Height = 4
        TableLayoutPanel2.ColumnStyles(0).Width = 64
        TableLayoutPanel2.RowStyles(0).Height = 20
        TableLayoutPanel2.RowStyles(1).Height = 44
        TableLayoutPanel2.Height = 64
        TableLayoutPanel3.ColumnStyles(0).Width = 64
        TableLayoutPanel3.RowStyles(0).Height = 20
        TableLayoutPanel3.RowStyles(1).Height = 44
        TableLayoutPanel3.Height = 64
        ObjectsTree.Controls.Add(pict3)
        pict3.Left = ObjectsTree.DetailsVisiblesOrNot.Left
        pict3.Top = ObjectsTree.DetailsVisiblesOrNot.Top
        pict3.Width = Math.Min(ObjectsTree.DetailsVisiblesOrNot.Width, ObjectsTree.DetailsVisiblesOrNot.Height)
        pict3.Height = Math.Min(ObjectsTree.DetailsVisiblesOrNot.Width, ObjectsTree.DetailsVisiblesOrNot.Height)
        pict3.SizeMode = PictureBoxSizeMode.StretchImage
        pict3.Anchor = AnchorStyles.Right Or AnchorStyles.Top
        pict3.BringToFront()
    End Sub

    Public Event TreeNodeSelected(sender As Object, e As TreeViewEventArgs)
    Public Event TreeNodeDoubleClicked(Node As TreeNode)
    Private Sub ObjectsTree_NodeSelected(sender As Object, e As TreeViewEventArgs) Handles ObjectsTree.NodeSelected
        RaiseEvent TreeNodeSelected(sender, e)
    End Sub
    Private Sub ObjectsTree_NodeDoubleClicked(e As TreeNode) Handles ObjectsTree.Node_DobbleClick
        RaiseEvent TreeNodeDoubleClicked(e)
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
            Label3.Text = "None"
            Label4.Text = "None"
        Else
            PictureBox1.Image = CType(CType(e.Node, Object).objeto, BG3_Obj_IconUV_Class).Get_Icon_FromAtlass
            PictureBox2.Image = CType(CType(e.Node, Object).objeto, BG3_Obj_IconUV_Class).Get_Icon_FromFile
            pict3.Image = CType(CType(e.Node, Object).objeto, BG3_Obj_IconUV_Class).Get_Icon_FromAtlass_or_File
            Label3.Text = "None"
            Label4.Text = "None"
            If Not IsNothing(PictureBox1.Image) Then Label3.Text = PictureBox1.Image.Width.ToString + " x " + PictureBox1.Image.Height.ToString
            If Not IsNothing(PictureBox2.Image) Then Label4.Text = PictureBox2.Image.Width.ToString + " x " + PictureBox2.Image.Height.ToString

        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub
End Class
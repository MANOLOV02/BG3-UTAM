Imports System.ComponentModel
Partial Public MustInherit Class Explorer_Generic_Designer
    Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Flickering.EnableDoubleBuffering(TreeView1)
        Me.DoubleBuffered = True
    End Sub
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Try
            TreeView1.SelectedNode = e.Node
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TreeView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles TreeView1.ItemDrag
        Try
            TreeView1.SelectedNode = e.Item
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        Try
            TreeView1.SelectedNode = e.Node
            RaiseEvent Node_DobbleClick(e.Node)
        Catch ex As Exception
        End Try

    End Sub

    Public Event Node_DobbleClick(Node As TreeNode)
End Class

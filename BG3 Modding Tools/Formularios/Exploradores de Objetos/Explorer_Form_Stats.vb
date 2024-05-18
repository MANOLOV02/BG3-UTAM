Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net
Imports System.Reflection.Metadata
Imports System.Runtime.CompilerServices
Imports System.Xml
Imports BG3_Modding_Tools.Funciones
Imports BG3_Modding_Tools.FuncionesHelpers
Imports LSLib.Granny
Imports LSLib.LS.Enums

Public Class Explorer_Form_Stats

    Public Sub New(ByRef MdiParent As Main)
        MyBase.New(MdiParent)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True

    End Sub
    Public Event Hide_Unhide_Details(Show As Boolean)
    Public Event TreeNodeSelected(sender As Object, e As TreeViewEventArgs)
    Public Event TreeNodeDoubleClicked(Node As TreeNode)
    Private Sub ObjectsTree_NodeSelected(sender As Object, e As TreeViewEventArgs) Handles ObjectsTree.NodeSelected
        RaiseEvent TreeNodeSelected(sender, e)
    End Sub
    Private Sub ObjectsTree_NodeDoubleClicked(e As TreeNode) Handles ObjectsTree.Node_DobbleClick
        RaiseEvent TreeNodeDoubleClicked(e)
    End Sub
    Private Sub Template_Explorer_Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim visual As New Information_Form_Stats(MdiParent, Me) With {.StartPosition = FormStartPosition.Manual, .Location = New Point(Left + Width, Top), .Height = Height}
        If CType(Me.MdiParent, Main).OpenDetailsWindowsAlsoToolStripMenuItem.Checked Then
            Hide_Unhide(True)
        Else
            ObjectsTree.DetailsVisibles = False
            Hide_Unhide(False)
        End If
    End Sub

    Public Overrides Sub BackgroundWork_Finished_Sub()
        MyBase.BackgroundWork_Finished_Sub()
        ObjectsTree.ObjectList = FuncionesHelpers.GameEngine.ProcessedStatList
        If ObjectsTree.ArbolWorker.IsBusy = False Then ObjectsTree.Reload_Arbol(False)
    End Sub
    Public Sub Hide_Unhide(Show As Boolean) Handles ObjectsTree.Hide_Unhide_Details
        RaiseEvent Hide_Unhide_Details(Show)
    End Sub
End Class

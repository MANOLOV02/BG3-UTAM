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
Imports LSLib.VirtualTextures

Public Class Explorer_Form_VisualTemplates

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
    Private _Last_Obj As BG3_Obj_VisualBank_Class = Nothing
    Private Sub ObjectsTree_NodeSelected(sender As Object, e As TreeViewEventArgs) Handles ObjectsTree.NodeSelected
        RaiseEvent TreeNodeSelected(sender, e)
        Dim obj = CType(e.Node, BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))
        If IsNothing(obj.Objeto) OrElse IsNothing(CType(obj.Objeto, BG3_Obj_VisualBank_Class).Asset) Then
            _Last_Obj = Nothing
            Button1.Enabled = False
        Else
            _Last_Obj = CType(obj.Objeto, BG3_Obj_VisualBank_Class)
            Button1.Enabled = True
        End If
    End Sub
    Private Sub ObjectsTree_NodeDoubleClicked(e As TreeNode) Handles ObjectsTree.Node_DobbleClick
        RaiseEvent TreeNodeDoubleClicked(e)
    End Sub
    Private Sub Template_Explorer_Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim visual As New Information_Form_VisualTemplates(MdiParent, Me) With {.StartPosition = FormStartPosition.Manual, .Location = New Point(Left + Width, Top), .Height = Height}
        If CType(Me.MdiParent, Main).OpenDetailsWindowsAlsoToolStripMenuItem.Checked Then
            Hide_Unhide(True)
        Else
            ObjectsTree.DetailsVisibles = False
            Hide_Unhide(False)
        End If
    End Sub

    Public Overrides Sub BackgroundWork_Finished_Sub()
        MyBase.BackgroundWork_Finished_Sub()
        ObjectsTree.ObjectList = FuncionesHelpers.GameEngine.ProcessedVisualBanksList
        If ObjectsTree.ArbolWorker.IsBusy = False Then ObjectsTree.Reload_Arbol(False)
    End Sub
    Public Sub Hide_Unhide(Show As Boolean) Handles ObjectsTree.Hide_Unhide_Details
        RaiseEvent Hide_Unhide_Details(Show)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ext = Path.GetExtension(_Last_Obj.AssetName)
        Dim xx As New SaveFileDialog With {.FileName = Path.GetFileName(_Last_Obj.AssetName), .AddExtension = True, .Filter = ext + " Files|*" + ext}

        If xx.ShowDialog = DialogResult.OK Then
            Dim fil As New FileStream(xx.FileName, FileMode.Create)
            _Last_Obj.Asset.CopyTo(fil)
            fil.Flush()
            fil.Close()

            If Path.GetExtension(_Last_Obj.AssetName).ToLower = ".gtp" Then
                If MsgBox("Do you want to export the embedded dds files", vbOKCancel, "Virtual texture") = MsgBoxResult.Ok Then ExtractGPT(_Last_Obj.AssetName, xx.FileName)
            End If
        End If


    End Sub

    Private Shared Sub ExtractGPT(GtpFile As String, NewnameFull As String)
        Try
            Dim savepath As String = IO.Path.GetDirectoryName(NewnameFull)
            Dim newfilename As String = IO.Path.GetFileNameWithoutExtension(NewnameFull)
            Dim Guid = IO.Path.GetFileNameWithoutExtension(GtpFile).Split("_").Last()
            Dim guidIndex = IO.Path.GetFileNameWithoutExtension(GtpFile).IndexOf(Guid)
            Dim gtsFile = IO.Path.GetFileNameWithoutExtension(GtpFile).Substring(0, guidIndex - 1)
            Dim originalgtpFile = IO.Path.Combine(savepath, IO.Path.GetFileName(GtpFile))
            If NewnameFull <> originalgtpFile Then IO.File.Copy(NewnameFull, originalgtpFile)
            gtsFile = GtpFile.Replace(IO.Path.GetFileNameWithoutExtension(GtpFile), gtsFile).Replace(".gtp", ".gts")
            Dim gts As Stream = BG3_Pak_Packages_List_Class.Find_Asset("", gtsFile)
            If Not IsNothing(gts) Then
                gtsFile = IO.Path.Combine(savepath, newfilename + ".gts")
                Dim fil As New FileStream(gtsFile, FileMode.Create)
                gts.CopyTo(fil)
                fil.Flush()
                fil.Close()
                Dim tileSet = New VirtualTileSet(gtsFile)
                Dim textures = tileSet.FourCCMetadata.ExtractTextureMetadata()
                For Each texture In textures.Where(Function(tex) tex.Name = Guid).ToList()
                    For layer = 0 To tileSet.TileSetLayers.Length - 1
                        Dim tex As LSLib.VirtualTextures.BC5Image = Nothing
                        Dim level As Integer = 0

                        Do
                            texture.Name = newfilename
                            tex = tileSet.ExtractTexture(level, layer, texture)
                            level += 1
                        Loop While tex Is Nothing AndAlso level < tileSet.TileSetLevels.Length

                        If Not IsNothing(tex) Then
                            Dim outputPath = IO.Path.Combine(savepath, newfilename + $"_{layer}.dds")
                            tex.SaveDDS(outputPath)
                        End If
                    Next
                Next
                tileSet.Dispose()
                If NewnameFull <> originalgtpFile Then IO.File.Delete(originalgtpFile)
                IO.File.Delete(gtsFile)
            End If
        Catch ex As Exception
            MsgBox("Error exporting virtual texture", MsgBoxStyle.Information + vbOKOnly, "Error")
        End Try
    End Sub

End Class

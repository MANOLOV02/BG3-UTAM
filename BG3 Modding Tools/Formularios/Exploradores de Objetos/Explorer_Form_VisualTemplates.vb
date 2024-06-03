Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.DirectoryServices.ActiveDirectory
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
        If IsNothing(obj.Objeto) OrElse IsNothing(CType(obj.Objeto, BG3_Obj_VisualBank_Class).VisualAsset) Then
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
        Dim utammod = CType(Me.MdiParent, Main).ActiveMod
        If Not IsNothing(utammod) Then
            If _Last_Obj.Type = BG3_Enum_VisualBank_Type.MaterialShader Then
                xx.InitialDirectory = utammod.CurrentMod.MaterialsPath
            Else
                xx.InitialDirectory = utammod.CurrentMod.AssetsPath
            End If
        End If
        If xx.ShowDialog = DialogResult.OK Then
            Select Case True
                Case _Last_Obj.Type = BG3_Enum_VisualBank_Type.VirtualTextureBank
                    If MsgBox("Do you want to export the embedded dds files", vbOKCancel, "Virtual texture") = MsgBoxResult.Ok Then
                        ExtractGPT(_Last_Obj.AssetName, xx.FileName)
                    Else
                        Save_as_Is(xx.FileName)
                    End If
                Case _Last_Obj.Type = BG3_Enum_VisualBank_Type.VisualBank
                    Save_as_Is(xx.FileName)
                Case _Last_Obj.Type = BG3_Enum_VisualBank_Type.TextureBank
                    Save_as_Is(xx.FileName)
                Case BG3_Enum_VisualBank_Type.MaterialShader
                    Extractshader(_Last_Obj.AssetName, xx.FileName)
                Case Else
                    Debugger.Break()
            End Select
        End If


    End Sub
    Private Sub Extractshader(ShaderFile As String, NewnameFull As String)
        Try
            Dim oldpath As String = IO.Path.GetDirectoryName(ShaderFile)
            Dim BasePath As String = ShaderFile.Replace(IO.Path.GetExtension(ShaderFile), "")
            Dim NewBasePath As String = NewnameFull.Replace(IO.Path.GetExtension(NewnameFull), "")
            For Each ass In BG3_Pak_Packages_List_Class.Find_Assets("", BasePath + "_ST", ".bshd")
                Dim fil As New FileStream(ass.MapKey.Replace(BasePath, NewBasePath), FileMode.Create)
                ass.SourceOfResorce.CreateContentReader.CopyTo(fil)
                ass.SourceOfResorce.ReleaseMem()
                fil.Flush()
                fil.Close()
                fil.Dispose()
            Next
            Save_as_Is(NewnameFull)
            Try
                Dim utammod = CType(Me.MdiParent, Main).ActiveMod
                If Not IsNothing(utammod) Then
                    Dim modfolderTeorical = IO.Path.Combine(GameEngine.Settings.UTAMModFolder, utammod.CurrentMod.SaveFolder)
                    If NewnameFull.StartsWith(modfolderTeorical) Then
                        Dim source As New BG3_Pak_SourceOfResource_Class(modfolderTeorical, NewnameFull, BG3_Enum_Package_Type.UTAM_Mod)
                        Dim Recurso = source.ReadResource
                        For Each reg In Recurso.Regions
                            Dim result = GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(reg.Value, source, BG3_Enum_VisualBank_Type.MaterialShader))
                            ' Lo agrego ademas como asset!
                            GameEngine.ProcessedAssets.Manage_Overrides(New BG3_Obj_Assets_Class(source))
                        Next
                        source.ReleaseMem()
                        LSLib.LS.ResourceUtils.SaveResource(Recurso, NewnameFull.Replace(".lsf", ".lsf.lsx", StringComparison.OrdinalIgnoreCase), Funciones.ConversionParams_LSLIB)
                    End If
                End If
            Catch ex As Exception
                MsgBox("Error reading shader. It must be in the 'ModFolder'\Public\'Modfolder'\Assets\Materials folder.", MsgBoxStyle.Information + vbOKOnly, "Error")
            End Try

        Catch ex As Exception
            MsgBox("Error exporting shader", MsgBoxStyle.Information + vbOKOnly, "Error")
        End Try
    End Sub
    Private Sub Save_as_Is(NewnameFull As String)
        Dim fil As New FileStream(NewnameFull, FileMode.Create)
        _Last_Obj.VisualAsset.SourceOfResorce.CreateContentReader.CopyTo(fil)
        _Last_Obj.VisualAsset.SourceOfResorce.ReleaseMem()
        fil.Flush()
        fil.Close()
        fil.Dispose()
    End Sub

    Private Sub ExtractGPT(GtpFile As String, NewnameFull As String)
        Dim gts As BG3_Obj_Assets_Class = Nothing
        Dim tileSet As VirtualTileSet = Nothing
        Try
            Dim savepath As String = IO.Path.GetDirectoryName(NewnameFull)
            Dim newfilename As String = IO.Path.GetFileNameWithoutExtension(NewnameFull)
            Dim Guid = IO.Path.GetFileNameWithoutExtension(GtpFile).Split("_").Last()
            Dim guidIndex = IO.Path.GetFileNameWithoutExtension(GtpFile).IndexOf(Guid)
            Dim temporaryPath As String = IO.Path.GetTempPath
            Dim originalgtpFile = IO.Path.Combine(temporaryPath, IO.Path.GetFileName(GtpFile))
            Dim gtsFile = String.Concat(Path.GetFileNameWithoutExtension(GtpFile).AsSpan(0, guidIndex - 1), ".gts")
            gts = BG3_Pak_Packages_List_Class.Find_Asset(IO.Path.GetDirectoryName(GtpFile), gtsFile)
            If Not IsNothing(gts) Then
                Save_as_Is(originalgtpFile)
                gtsFile = IO.Path.Combine(temporaryPath, newfilename + ".gts")
                Dim fil As New FileStream(gtsFile, FileMode.Create)
                gts.SourceOfResorce.CreateContentReader.CopyTo(fil)
                gts.SourceOfResorce.ReleaseMem()
                fil.Flush()
                fil.Close()
                fil.Dispose()
                tileSet = New VirtualTileSet(gtsFile)
                Dim textures = tileSet.FourCCMetadata.ExtractTextureMetadata()
                For Each texture In textures.Where(Function(tex) tex.Name = Guid).ToList()
                    For layer = 0 To tileSet.TileSetLayers.Length - 1
                        Dim tex As LSLib.VirtualTextures.BC5Image = Nothing
                        Dim level As Integer = 0

                        Do
                            Dim idx As Integer
                            idx = tileSet.FindPageFile(Guid)

                            If idx <> -1 Then
                                Dim file = tileSet.PageFileInfos(idx).FileName
                                If file <> IO.Path.GetFileName(GtpFile) Then Debugger.Break()
                            End If
                            Try
                                tex = tileSet.ExtractTexture(level, layer, texture)
                            Catch ex As Exception
                                Debugger.Break()
                            End Try
                            level += 1
                        Loop While tex Is Nothing AndAlso level < tileSet.TileSetLevels.Length

                        If Not IsNothing(tex) Then
                            Dim outputPath = IO.Path.Combine(savepath, newfilename + $"_level_{level}" + $"_{layer}.dds")
                            tex.SaveDDS(outputPath)
                        End If
                    Next
                Next
                tileSet.Dispose()
                If NewnameFull <> originalgtpFile Then IO.File.Delete(originalgtpFile)

            End If
            IO.File.Delete(gtsFile)
            IO.File.Delete(originalgtpFile)
        Catch ex As Exception
            MsgBox("Error exporting virtual texture", MsgBoxStyle.Information + vbOKOnly, "Error")
        Finally
            If Not IsNothing(tileSet) Then tileSet.Dispose()
            If Not IsNothing(gts) Then gts.SourceOfResorce.ReleaseMem()

        End Try
    End Sub

End Class

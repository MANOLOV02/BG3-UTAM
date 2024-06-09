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
Imports LSLib.Granny.Model
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
                    If MsgBox("Do you want to also convert to a DAE file", vbOKCancel, "Virtual bank") = MsgBoxResult.Ok Then
                        Extract_DAE(xx.FileName)
                    End If
                Case _Last_Obj.Type = BG3_Enum_VisualBank_Type.TextureBank
                    Save_as_Is(xx.FileName)
                Case BG3_Enum_VisualBank_Type.MaterialShader
                    Extractshader(_Last_Obj.AssetName, xx.FileName)
                Case Else
                    Debugger.Break()
            End Select
        End If


    End Sub

    Private Sub Extract_Dae(NewnameFull As String)
        Try
            Dim reader As New LSLib.Granny.GR2.GR2Reader(_Last_Obj.VisualAsset.SourceOfResorce.CreateContentReader)
            Dim exporter As New LSLib.Granny.Model.Exporter
            Dim root As New LSLib.Granny.Model.Root
            Dim settings = exporter.Options

            reader.Read(root)
            root.PostLoad(reader.Tag)
            ' Common setting TO DAE
            settings.FlipUVs = True
            settings.BuildDummySkeleton = True
            settings.DeduplicateUVs = False
            settings.ApplyBasisTransforms = True
            settings.FlipMesh = True
            settings.FlipSkeleton = False
            settings.LoadGameSettings(Game.BaldursGate3)
            settings.ModelType = 0
            settings.ConformGR2Path = Nothing
            settings.ConformSkeletonsCopy = False
            'InputStatus
            Dim skinned As Boolean = root.Skeletons IsNot Nothing AndAlso root.Skeletons.Count > 0
            Dim animationsOnly As Boolean = Not skinned AndAlso (root.Models Is Nothing OrElse root.Models.Count = 0) AndAlso root.Animations IsNot Nothing AndAlso root.Animations.Count > 0
            If skinned Then settings.BuildDummySkeleton = False
            If skinned Then
                settings.BuildDummySkeleton = False
            ElseIf animationsOnly Then
                settings.BuildDummySkeleton = False
            Else
                settings.BuildDummySkeleton = True
            End If
            Dim hasUndeterminedModelTypes As Boolean = False
            Dim accumulatedModelFlags As DivinityModelFlag = 0
            For Each mesh In If(root.Meshes, Enumerable.Empty(Of LSLib.Granny.Model.Mesh)())
                If mesh.ExtendedData?.UserMeshProperties Is Nothing OrElse mesh.ExtendedData.UserMeshProperties.MeshFlags = 0 Then
                    hasUndeterminedModelTypes = True
                ElseIf mesh.ExtendedData?.UserMeshProperties Is Nothing Then
                    accumulatedModelFlags = accumulatedModelFlags Or mesh.ExtendedData.UserMeshProperties.MeshFlags
                End If
            Next
            If accumulatedModelFlags.IsRigid() Then settings.ModelType = settings.ModelType Or DivinityModelFlag.Rigid
            If accumulatedModelFlags.IsCloth() Then settings.ModelType = settings.ModelType Or DivinityModelFlag.Cloth
            If accumulatedModelFlags.IsMeshProxy() Then settings.ModelType = settings.ModelType Or DivinityModelFlag.MeshProxy Or DivinityModelFlag.HasProxyGeometry

            UpdateExportableObjects(root)
            UpdateResourceFormats(root)

            For Each item As ListViewItem In exportableObjects.Items
                If Not item.Checked Then
                    Dim name = item.SubItems(0).Text
                    Dim itemType = item.SubItems(1).Text
                    If itemType = "Model" Then
                        settings.DisabledModels.Add(name)
                    ElseIf itemType = "Skeleton" Then
                        settings.DisabledSkeletons.Add(name)
                    ElseIf itemType = "Animation" Then
                        settings.DisabledAnimations.Add(name)
                    End If
                End If
            Next

            For Each setting As ListViewItem In From item In resourceFormats.Items Select TryCast(item, ListViewItem)
                Dim name As String = setting.SubItems(0).Text
                Dim type As String = setting.SubItems(1).Text
                Dim value As String = setting.SubItems(2).Text
                If type = "Mesh" AndAlso value <> "Automatic" Then
                    Throw New NotImplementedException("Custom vertex formats not supported")
                End If
            Next

            exporter.Options.Input = root
            exporter.Options.OutputFormat = ExportFormat.DAE
            exporter.Options.OutputPath = NewnameFull.Replace(".GR2", ".DAE", StringComparison.OrdinalIgnoreCase)
            exporter.Export()
        Catch ex As Exception
            MsgBox("Error exporting DAE. Make sure the Granny dll is in the application directory", MsgBoxStyle.Information + vbOKOnly, "Error")
        End Try
    End Sub
    Private exportableObjects As New ListView
    Private resourceFormats As New ListView
    Private Sub UpdateResourceFormats(ByRef _root As LSLib.Granny.Model.Root)
        resourceFormats.Items.Clear()

        If _root.Meshes IsNot Nothing Then

            For Each mesh As LSLib.Granny.Model.Mesh In _root.Meshes
                Dim item = New ListViewItem({mesh.Name, "Mesh", "Automatic"})
                resourceFormats.Items.Add(item)
            Next
        End If

        If _root.TrackGroups IsNot Nothing Then

            For Each trackGroup As TrackGroup In _root.TrackGroups

                For Each track As TransformTrack In trackGroup.TransformTracks

                    If track.PositionCurve.CurveData.NumKnots() > 2 Then
                        Dim item = New ListViewItem({track.Name, "Position Track", "Automatic"})
                        resourceFormats.Items.Add(item)
                    End If

                    If track.OrientationCurve.CurveData.NumKnots() > 2 Then
                        Dim item = New ListViewItem({track.Name, "Rotation Track", "Automatic"})
                        resourceFormats.Items.Add(item)
                    End If

                    If track.ScaleShearCurve.CurveData.NumKnots() > 2 Then
                        Dim item = New ListViewItem({track.Name, "Scale/Shear Track", "Automatic"})
                        resourceFormats.Items.Add(item)
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub UpdateExportableObjects(ByRef _root As LSLib.Granny.Model.Root)
        exportableObjects.Items.Clear()

        If _root.Models IsNot Nothing Then

            For Each model As Model In _root.Models
                Dim item = New ListViewItem({model.Name, "Model"})
                item.Checked = True
                exportableObjects.Items.Add(item)
            Next
        End If

        If _root.Skeletons IsNot Nothing Then

            For Each skeleton As Skeleton In _root.Skeletons
                Dim item = New ListViewItem({skeleton.Name, "Skeleton"})
                item.Checked = True
                exportableObjects.Items.Add(item)
            Next
        End If

        If _root.Animations IsNot Nothing Then

            For Each animation As LSLib.Granny.Model.Animation In _root.Animations
                Dim item = New ListViewItem({animation.Name, "Animation"})
                item.Checked = True
                exportableObjects.Items.Add(item)
            Next
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

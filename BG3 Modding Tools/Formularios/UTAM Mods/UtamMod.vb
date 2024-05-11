Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Resources
Imports System.Text
Imports System.Text.Json.Nodes
Imports System.Text.Json.Serialization.Metadata
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports LSLib.Granny
Imports LSLib.Granny.Model
Imports LSLib.LS
Imports LSLib.LS.Enums
Imports LSLib.LS.Story

Public Class UtamMod

    Public CurrentMod As New Utam_CurrentModClass
    Public Source As BG3_Pak_SourceOfResource_Class
    Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByRef MdiParent As Main, Optional Isnew As Boolean = False)
        MyBase.New(MdiParent)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted_Sub
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished_Sub
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report_SuB
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd_sub
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart_sub
        If Isnew Then
            CurrentMod.Isnew = True
            CurrentMod.ModLsx = New BG3_Mod_Module_Class With {.Name = "Utam_Mod", .Folder = "Utam_Mod_Folder", .Description = "Utam_Mod_Description", .Author = "ManoloV02"}
            CurrentMod.ModLsx.SaveChanges()
            ButtonEdit.Enabled = False
            ButtonSave.Enabled = True
            ButtonCancel.Enabled = True
            TextBoxFolder.Enabled = True
            Me.Source = New BG3_Pak_SourceOfResource_Class(CurrentMod.Paths_Mod, BG3_Enum_Package_Type.UTAM_Mod)
            Habilita_Deshabilita_edicion(True)
        End If
    End Sub

    Public Sub Load_finished(CurrentMod As Utam_CurrentModClass)
        Me.CurrentMod = CurrentMod
        Me.NumericUpDown1.Value = CurrentMod.Versionconverter.Major
        Me.NumericUpDown2.Value = CurrentMod.Versionconverter.Minor
        Me.NumericUpDown3.Value = CurrentMod.Versionconverter.Revision
        Me.NumericUpDown4.Value = CurrentMod.Versionconverter.Build
        CheckBoxBuildpak.Checked = CurrentMod.BuildPak
        CheckBoxBuildzip.Checked = CurrentMod.BuildZip
        CheckBoxModFixer.Checked = CurrentMod.BuildModFixer
        CheckBoxmultitoolcomp.Checked = CurrentMod.ShinyhoboCompatible
        CheckBoxAddtogame.Checked = CurrentMod.AddToGame
        TextBoxFolder.Enabled = False
        Me.Source = New BG3_Pak_SourceOfResource_Class(CurrentMod.Paths_Mod, BG3_Enum_Package_Type.UTAM_Mod)
        Habilita_Deshabilita_edicion(False)
    End Sub

    Public Sub Habilita_Deshabilita_edicion(Edicion As Boolean, Optional repintar As Boolean = True)
        ButtonEdit.Enabled = Not Edicion
        ButtonSave.Enabled = Edicion
        ButtonCancel.Enabled = Edicion
        GroupBox1.Enabled = Edicion
        GroupBox2.Enabled = Edicion
        If repintar Then Repinta()
    End Sub
    Public Sub Repinta()
        Me.Text = "UTAM Mod - " + CurrentMod.ModLsx.Name
        TextBoxName.Text = CurrentMod.ModLsx.Name
        TextBoxFolder.Text = CurrentMod.ModLsx.Folder
        TextBoxDescription.Text = CurrentMod.ModLsx.Description
        TextBoxAuthor.Text = CurrentMod.ModLsx.Author
        TextBoxUUID.Text = CurrentMod.ModLsx.UUID
        TextBoxVersion.Text = CurrentMod.ModLsx.Version.ToString
        XmLtoRichText1.Process_XML(CurrentMod.ModLsx.MetaLSLIB.To_XML) ' Uso el intermedio hasta que se grabe

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged, NumericUpDown2.ValueChanged, NumericUpDown3.ValueChanged, NumericUpDown4.ValueChanged
        CurrentMod.Versionconverter.Major = NumericUpDown1.Value
        CurrentMod.Versionconverter.Minor = NumericUpDown2.Value
        CurrentMod.Versionconverter.Revision = NumericUpDown3.Value
        CurrentMod.Versionconverter.Build = NumericUpDown4.Value
        CurrentMod.ModLsx.Version = CurrentMod.Versionconverter.ToVersion64
        CurrentMod.ModLsx.PublishVersion = CurrentMod.Versionconverter.ToVersion64
        Repinta()
    End Sub

    Private Sub TextBoxName_Leave(sender As Object, e As EventArgs) Handles TextBoxName.Leave
        CurrentMod.ModLsx.Name = TextBoxName.Text
        Repinta()
    End Sub
    Private Sub TextBoxAuthor_Leave(sender As Object, e As EventArgs) Handles TextBoxAuthor.Leave
        CurrentMod.ModLsx.Author = TextBoxAuthor.Text
        Repinta()
    End Sub
    Private Sub TextBoxDescription_Leave(sender As Object, e As EventArgs) Handles TextBoxDescription.Leave
        CurrentMod.ModLsx.Description = TextBoxDescription.Text
        Repinta()
    End Sub
    Private Sub TextBoxFolder_Leave(sender As Object, e As EventArgs) Handles TextBoxFolder.Leave
        CurrentMod.ModLsx.Folder = TextBoxFolder.Text
        Repinta()
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        If CurrentMod.Isnew = True AndAlso IO.File.Exists(IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CurrentMod.ModLsx.Name + ".utam")) Then
            MsgBox("The name is already in use by other mod.", vbCritical, "Name already used")
            Exit Sub
        End If
        If CurrentMod.Isnew = True AndAlso IO.Path.Exists(CurrentMod.Paths_Save) Then
            MsgBox("The path is already in use by other mod.", vbCritical, "Path already used")
            Exit Sub
        End If
        Save_mod()
        Habilita_Deshabilita_edicion(False)
        RaiseEvent Changed_status()
    End Sub
    Public Sub Save_mod()
        CurrentMod.ModLsx.SaveChanges()
        Dim Utam_CFG As String = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CurrentMod.ModLsx.Name + ".utam")
        CurrentMod.SaveFolder = CurrentMod.ModLsx.Folder
        CurrentMod.SaveUUID = CurrentMod.ModLsx.UUID
        CurrentMod.Isnew = False
        CurrentMod.BuildPak = CheckBoxBuildpak.Checked
        CurrentMod.BuildZip = CheckBoxBuildzip.Checked
        CurrentMod.BuildModFixer = CheckBoxModFixer.Checked
        CurrentMod.ShinyhoboCompatible = CheckBoxmultitoolcomp.Checked
        CurrentMod.AddToGame = CheckBoxAddtogame.Checked
        LSLib.LS.ResourceUtils.SaveResource(CurrentMod.ModLsx.MetaLSLIB, CurrentMod.MetaFilePath, Funciones.ConversionParams_LSLIB)
        Dim str = System.Text.Json.JsonSerializer.Serialize(CurrentMod, FuncionesHelpers.Jsonoptions)
        Using writer = New StreamWriter(Utam_CFG, False)
            writer.Write(str)
            writer.Close()
        End Using

        Save_Files()
    End Sub

    Public Sub Save_Files()
        CurrentMod.Create_folders()

        ' Is mod Fixer included
        Dim modfixpath As String = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, IO.Path.Combine(CurrentMod.SaveFolder, "Mods\Gustav\Story\RawFiles\Goals"))
        If CheckBoxModFixer.Checked = True Then
            If IO.Directory.Exists(modfixpath) = False Then IO.Directory.CreateDirectory(modfixpath)
            Dim ArchivoMF As New IO.StreamWriter(IO.Path.Combine(modfixpath, "ForceRecompile.txt"), False)
            ArchivoMF.WriteLine("Version 1")
            ArchivoMF.WriteLine("SubGoalCombiner SGC_AND")
            ArchivoMF.WriteLine("INITSECTION")
            ArchivoMF.WriteLine("KBSECTION")
            ArchivoMF.WriteLine("")
            ArchivoMF.WriteLine("IF")
            ArchivoMF.WriteLine("NRD_KillStory(_)")
            ArchivoMF.WriteLine("THEN")
            ArchivoMF.WriteLine("NRD_BadCall(_NONEXISTENT, _REF);")
            ArchivoMF.WriteLine("")
            ArchivoMF.WriteLine("EXITSECTION")
            ArchivoMF.WriteLine("ENDEXITSECTION")
            ArchivoMF.Flush()
            ArchivoMF.Close()
        Else
            If IO.File.Exists(IO.Path.Combine(modfixpath, "ForceRecompile.txt")) Then IO.File.Delete(IO.Path.Combine(modfixpath, "ForceRecompile.txt"))
            Try
                If IO.Directory.Exists(modfixpath) Then
                    IO.Directory.Delete(modfixpath)
                    IO.Directory.Delete(modfixpath.Replace("\Goals", ""))
                    IO.Directory.Delete(modfixpath.Replace("\RawFiles\Goals", ""))
                    IO.Directory.Delete(modfixpath.Replace("\Story\RawFiles\Goals", ""))
                End If
            Catch ex As Exception
                Debugger.Break()
            End Try

        End If

        ' Genera treasure Table
        Dim ArchivoTT As New IO.StreamWriter(CurrentMod.TreasureTableFilePath, False)
        For Each tt In FuncionesHelpers.GameEngine.UtamTreasures
            ArchivoTT.WriteLine("new treasuretable " + Chr(34) + tt.Mapkey_WithoutOverride + Chr(34) + "")
            If tt.CanMerge = True Then ArchivoTT.WriteLine("CanMerge 1")
            For Each subt In tt.Subtables.Where(Function(pf) pf.Source.Pak_Or_Folder = Source.Pak_Or_Folder)
                ArchivoTT.WriteLine("new subtable " + Chr(34) + subt.Definition + Chr(34) + "")
                If subt.MinLevel <> "" Then ArchivoTT.WriteLine("StartLevel " + Chr(34) + subt.MinLevel + Chr(34) + "")
                If subt.MaxLevel <> "" Then ArchivoTT.WriteLine("EndLevel " + Chr(34) + subt.MaxLevel + Chr(34) + "")
                For Each lis In subt.Lista
                    ArchivoTT.WriteLine("object category " + Chr(34) + lis.Item + Chr(34) + lis.Conditions)
                Next
            Next
            ArchivoTT.WriteLine("")
        Next
        ArchivoTT.Flush()
        ArchivoTT.Close()

        ' Genera Stats File
        Dim ArchivoST As New IO.StreamWriter(CurrentMod.StatsObjectsFilePath, False)
        For Each stat In FuncionesHelpers.GameEngine.Utamstats.Where(Function(pf) pf.Type <> BG3_Enum_StatType.ItemCombination)
            ArchivoST.WriteLine("new entry " + Chr(34) + stat.Name + Chr(34) + "")
            ArchivoST.WriteLine("type " + Chr(34) + stat.Type.ToString + Chr(34) + "")
            If stat.Using <> "" Then ArchivoST.WriteLine("using " + Chr(34) + stat.Using + Chr(34) + "")
            For Each dat In stat.Data
                ArchivoST.WriteLine("data " + Chr(34) + dat.Key + Chr(34) + " " + Chr(34) + dat.Value + Chr(34) + "")
            Next
            ArchivoST.WriteLine("")
        Next
        ArchivoST.Flush()
        ArchivoST.Close()

        'Genera ItemCombination
        Dim ArchivoIC As New IO.StreamWriter(CurrentMod.StatsCombinationsFilePath, False)
        For Each stat In FuncionesHelpers.GameEngine.Utamstats.Where(Function(pf) pf.Type = BG3_Enum_StatType.ItemCombination)
            Dim current As BG3_Obj_Stats_Class = stat
            ArchivoIC.WriteLine("new ItemCombination " + Chr(34) + current.Name + Chr(34) + "")
            Dim x As Integer = 1
                While current.Data.ContainsKey("Object " + x.ToString) = True
                If current.Data.ContainsKey("Type " + x.ToString) Then
                    ArchivoIC.WriteLine("data " + Chr(34) + "Type " + x.ToString + Chr(34) + " " + Chr(34) + current.Data("Type " + x.ToString) + Chr(34))
                End If
                If current.Data.ContainsKey("Object " + x.ToString) Then
                    ArchivoIC.WriteLine("data " + Chr(34) + "Object " + x.ToString + Chr(34) + " " + Chr(34) + current.Data("Object " + x.ToString) + Chr(34))
                End If
                If current.Data.ContainsKey("Combine " + x.ToString) Then
                    ArchivoIC.WriteLine("data " + Chr(34) + "Combine " + x.ToString + Chr(34) + " " + Chr(34) + current.Data("Combine " + x.ToString) + Chr(34))
                End If
                If current.Data.ContainsKey("Transform " + x.ToString) Then
                    ArchivoIC.WriteLine("data " + Chr(34) + "Transform " + x.ToString + Chr(34) + " " + Chr(34) + current.Data("Transform " + x.ToString) + Chr(34))
                End If
                x += 1
            End While
            For Each dat In current.Data.Keys.Where(Function(pf) pf.StartsWith("Type ") = False And pf.StartsWith("Object ") = False And pf.StartsWith("Combine ") = False And pf.StartsWith("Transform ") = False)
                ArchivoIC.WriteLine("data " + Chr(34) + dat + Chr(34) + " " + Chr(34) + current.Data(dat) + Chr(34))
            Next

            ArchivoIC.WriteLine("")

            current = stat.Itemresult

            ArchivoIC.WriteLine("new ItemCombinationResult" + " " + Chr(34) + current.Name + Chr(34))

            x = 1
            While current.Data.ContainsKey("Result " + x.ToString) = True Or current.Data.ContainsKey("ResultAmount " + x.ToString) = True
                If current.Data.ContainsKey("ResultAmount " + x.ToString) Then
                    ArchivoIC.WriteLine("data " + Chr(34) + "ResultAmount " + x.ToString + Chr(34) + " " + Chr(34) + current.Data("ResultAmount " + x.ToString) + Chr(34))
                End If
                If current.Data.ContainsKey("Result " + x.ToString) Then
                    ArchivoIC.WriteLine("data " + Chr(34) + "Result " + x.ToString + Chr(34) + " " + Chr(34) + current.Data("Result " + x.ToString) + Chr(34))
                End If
                x += 1
            End While
            For Each dat In current.Data.Keys.Where(Function(pf) pf.StartsWith("ResultAmount ") = False And pf.StartsWith("Result ") = False)
                ArchivoIC.WriteLine("data " + Chr(34) + dat + Chr(34) + " " + Chr(34) + current.Data(dat) + Chr(34))
            Next

            ArchivoIC.WriteLine("")

        Next
        ArchivoIC.Flush()
        ArchivoIC.Close()

        ' Genera Localizations
        Dim langs = [Enum].GetValues(Of Bg3_Enum_Languages)
        Dim Loca(langs.Length) As LSLib.LS.LocaResource
        For x = 0 To langs.Length - 1
            Loca(x) = New LSLib.LS.LocaResource With {.Entries = New List(Of LocalizedText)}
        Next

        For Each Local In FuncionesHelpers.GameEngine.ProcessedLocalizationList.Values.Where(Function(pf) Not IsNothing(pf.SourceOfResorce) AndAlso pf.SourceOfResorce.Pak_Or_Folder = Source.Pak_Or_Folder)
            For x = 0 To langs.Length - 1
                If FuncionesHelpers.GameEngine.ProcessedLocalizationList.Key_Has_Language(Local.Handle + ";" + Local.Version.ToString, CType(x, Bg3_Enum_Languages)) Then
                    Dim locali As String = FuncionesHelpers.GameEngine.ProcessedLocalizationList.Localize(Local.Handle + ";" + Local.Version.ToString, CType(x, Bg3_Enum_Languages))
                    If Not IsNothing(locali) Then
                        Loca(x).Entries.Add(New LocalizedText() With {.Key = Local.Handle, .Text = locali, .Version = Local.Version})
                    End If
                End If
            Next
        Next

        For x = 0 To langs.Length - 1
            If Not IsNothing(Loca(x).Entries) AndAlso Loca(x).Entries.Count > 0 Then
                If CheckBoxmultitoolcomp.Checked Then
                    LSLib.LS.LocaUtils.Save(Loca(x), CurrentMod.LocalizationFilePath(CType(x, Bg3_Enum_Languages)) + ".xml")
                Else
                    If IO.File.Exists(CurrentMod.LocalizationFilePath(CType(x, Bg3_Enum_Languages)) + ".xml") Then IO.File.Delete(CurrentMod.LocalizationFilePath(CType(x, Bg3_Enum_Languages)) + ".xml")
                End If
                LSLib.LS.LocaUtils.Save(Loca(x), CurrentMod.LocalizationFilePath(CType(x, Bg3_Enum_Languages)))
            End If
        Next x

        ' Genera VisualTemplates (Only Material, it goes to a separate file each one)
        For Each temp In FuncionesHelpers.GameEngine.UtamVisuals.Where(Function(pf) pf.Type = BG3_Enum_VisualBank_Type.Material)
            Dim RootV2 As New LSLib.LS.Resource
            RootV2.Metadata.MajorVersion = Funciones.Default_LS_Version_Major
            RootV2.Metadata.MinorVersion = Funciones.Default_LS_Version_Minor
            RootV2.Metadata.Revision = Funciones.Default_LS_Version_Revision
            RootV2.Metadata.BuildNumber = Funciones.Default_LS_Version_Build
            Dim Configv7 As New LSLib.LS.Region With {.Name = "Material", .RegionName = "Material"}
            RootV2.Regions.Add("Material", Configv7)

            Dim nodeclone As String = temp.NodeLSLIB.To_XML.To_UTAMXML
            Dim nod As LSLib.LS.Node = ResourceUtils.LoadResource(New MemoryStream(Encoding.UTF8.GetBytes(nodeclone)), Enums.ResourceFormat.LSX, Funciones.LoadParams_LSLIB).Regions(Funciones.ManoloRegion).Children.First.Value.First
            Select Case temp.Type
                Case BG3_Enum_VisualBank_Type.Material
                    nod.Name = "Resource"
                    nod.Parent = Configv7
                    Configv7.AppendChild(nod)
                Case Else
                    Debugger.Break()
            End Select
            If CheckBoxmultitoolcomp.Checked Then
                LSLib.LS.ResourceUtils.SaveResource(RootV2, CurrentMod.MaterialFilePath(temp) + ".lsx", Funciones.ConversionParams_LSLIB)
            Else
                If IO.File.Exists(CurrentMod.VisualBanksFilePath + ".lsx") Then IO.File.Delete(CurrentMod.VisualBanksFilePath + ".lsx")
            End If
            LSLib.LS.ResourceUtils.SaveResource(RootV2, CurrentMod.MaterialFilePath(temp), Funciones.ConversionParams_LSLIB)
        Next


        ' Genera VisualTemplates (Except Material)
        Dim RootV As New LSLib.LS.Resource
        RootV.Metadata.MajorVersion = Funciones.Default_LS_Version_Major
        RootV.Metadata.MinorVersion = Funciones.Default_LS_Version_Minor
        RootV.Metadata.Revision = Funciones.Default_LS_Version_Revision
        RootV.Metadata.BuildNumber = Funciones.Default_LS_Version_Build

        Dim Configv1 As New LSLib.LS.Region With {.Name = "CharacterVisualBank", .RegionName = "CharacterVisualBank"}
        RootV.Regions.Add("CharacterVisualBank", Configv1)
        Dim Configv2 As New LSLib.LS.Region With {.Name = "VisualBank", .RegionName = "VisualBank"}
        RootV.Regions.Add("VisualBank", Configv2)
        Dim Configv3 As New LSLib.LS.Region With {.Name = "MaterialBank", .RegionName = "MaterialBank"}
        RootV.Regions.Add("MaterialBank", Configv3)
        Dim Configv4 As New LSLib.LS.Region With {.Name = "TextureBank", .RegionName = "TextureBank"}
        RootV.Regions.Add("TextureBank", Configv4)
        Dim Configv5 As New LSLib.LS.Region With {.Name = "MaterialPresetBank", .RegionName = "MaterialPresetBank"}
        RootV.Regions.Add("MaterialPresetBank", Configv5)
        Dim Configv6 As New LSLib.LS.Region With {.Name = "VirtualTextureBank", .RegionName = "VirtualTextureBank"}
        RootV.Regions.Add("VirtualTextureBank", Configv6)

        For Each temp In FuncionesHelpers.GameEngine.UtamVisuals.Where(Function(pf) pf.Type <> BG3_Enum_VisualBank_Type.Material)
            Dim nodeclone As String = temp.NodeLSLIB.To_XML.To_UTAMXML
            Dim nod As LSLib.LS.Node = ResourceUtils.LoadResource(New MemoryStream(Encoding.UTF8.GetBytes(nodeclone)), Enums.ResourceFormat.LSX, Funciones.LoadParams_LSLIB).Regions(Funciones.ManoloRegion).Children.First.Value.First
            Select Case temp.Type
                Case BG3_Enum_VisualBank_Type.CharacterVisualBank
                    nod.Name = "Resource"
                    nod.Parent = Configv1
                    Configv1.AppendChild(nod)
                Case BG3_Enum_VisualBank_Type.VisualBank
                    nod.Name = "Resource"
                    nod.Parent = Configv2
                    Configv2.AppendChild(nod)
                Case BG3_Enum_VisualBank_Type.MaterialBank
                    nod.Name = "Resource"
                    nod.Parent = Configv3
                    Configv3.AppendChild(nod)
                Case BG3_Enum_VisualBank_Type.TextureBank
                    nod.Name = "Resource"
                    nod.Parent = Configv4
                    Configv4.AppendChild(nod)
                Case BG3_Enum_VisualBank_Type.MaterialPresetBank
                    nod.Name = "Resource"
                    nod.Parent = Configv5
                    Configv5.AppendChild(nod)
                Case BG3_Enum_VisualBank_Type.VirtualTextureBank
                    nod.Name = "Material"
                    nod.Parent = Configv6
                    Configv6.AppendChild(nod)

                Case Else
                    Debugger.Break()
            End Select
        Next
        If CheckBoxmultitoolcomp.Checked Then
            LSLib.LS.ResourceUtils.SaveResource(RootV, CurrentMod.VisualBanksFilePath + ".lsx", Funciones.ConversionParams_LSLIB)
        Else
            If IO.File.Exists(CurrentMod.VisualBanksFilePath + ".lsx") Then IO.File.Delete(CurrentMod.VisualBanksFilePath + ".lsx")
        End If
        LSLib.LS.ResourceUtils.SaveResource(RootV, CurrentMod.VisualBanksFilePath, Funciones.ConversionParams_LSLIB)


        ' Genera RootTemplate
        Dim RootT As New LSLib.LS.Resource
        RootT.Metadata.MajorVersion = Funciones.Default_LS_Version_Major
        RootT.Metadata.MinorVersion = Funciones.Default_LS_Version_Minor
        RootT.Metadata.Revision = Funciones.Default_LS_Version_Revision
        RootT.Metadata.BuildNumber = Funciones.Default_LS_Version_Build
        Dim ConfigR As New LSLib.LS.Region With {.Name = "Templates", .RegionName = "Templates"}
        RootT.Regions.Add("Templates", ConfigR)
        For Each temp In FuncionesHelpers.GameEngine.UtamTemplates
            Dim nodeclone As String = temp.NodeLSLIB.To_XML.To_UTAMXML
            Dim nod As LSLib.LS.Node = ResourceUtils.LoadResource(New MemoryStream(Encoding.UTF8.GetBytes(nodeclone)), Enums.ResourceFormat.LSX, Funciones.LoadParams_LSLIB).Regions(Funciones.ManoloRegion).Children.First.Value.First
            'temp.NodeLSLIB.Attributes.TryAdd("id", "GameObjects")
            nod.Name = "GameObjects"
            nod.Parent = ConfigR
            ConfigR.AppendChild(nod)
        Next
        If CheckBoxmultitoolcomp.Checked Then
            LSLib.LS.ResourceUtils.SaveResource(RootT, CurrentMod.RootTemplateFilePath + ".lsx", Funciones.ConversionParams_LSLIB)
        Else
            If IO.File.Exists(CurrentMod.RootTemplateFilePath + ".lsx") Then IO.File.Delete(CurrentMod.RootTemplateFilePath + ".lsx")
        End If
        LSLib.LS.ResourceUtils.SaveResource(RootT, CurrentMod.RootTemplateFilePath, Funciones.ConversionParams_LSLIB)

        Pack_and_zip()
    End Sub
    Private Sub Pack_and_zip()
        Dim build As New PackageBuildData()
        Dim packfile As String = System.IO.Path.GetTempFileName
        Dim jsonfile As String = System.IO.Path.GetTempFileName
        Dim directorio As String = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CurrentMod.ModLsx.Folder)
        Dim Zipfile As String = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CurrentMod.ModLsx.Folder + ".zip")
        Dim FinalPackfile As String = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CurrentMod.ModLsx.Folder + ".pak")
        Dim ModPackfile As String = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.GameModFolder, CurrentMod.ModLsx.Folder + ".pak")

        Dim modtojson As New BG3_Pak_InfoJson_Details_Class With {.Author = CurrentMod.ModLsx.Author, .Created = Now, .Description = CurrentMod.ModLsx.Description, .Folder = CurrentMod.ModLsx.Folder, .Name = CurrentMod.ModLsx.Name, .UUID = CurrentMod.ModLsx.UUID, .Version = CurrentMod.ModLsx.Version.ToString}
        Dim modlist As New List(Of BG3_Pak_InfoJson_Details_Class) From {modtojson}
        Dim jsoninfo As New BG3_Pak_InfoJson_Class With {.Mods = modlist}
        'Add dependencies to json

        ' Pack
        build.Version = 18
        build.Compression = CompressionMethod.LZ4
        build.CompressionLevel = LSCompressionLevel.Fast
        build.Priority = 0
        Dim Packager As New Packager()
        Packager.CreatePackage(packfile, directorio, build).Wait()

        If CheckBoxBuildpak.Checked Then
            IO.File.Copy(packfile, FinalPackfile, True)
        End If

        If CheckBoxAddtogame.Enabled = True AndAlso CheckBoxAddtogame.Checked Then
#Disable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia
            FuncionesHelpers.GameEngine.IncludeModInGame(CurrentMod.ModLsx)
#Enable Warning BC42025 ' Acceso del miembro compartido, el miembro de constante, el miembro de enumeración o el tipo anidado a través de una instancia
            IO.File.Copy(packfile, ModPackfile, True)
        End If

        If CheckBoxBuildzip.Checked Then
            Dim md5 = System.Security.Cryptography.MD5.Create
            Dim contentBytes As Byte() = File.ReadAllBytes(packfile)
            md5.TransformFinalBlock(contentBytes, 0, contentBytes.Length)
            jsoninfo.MD5 = BitConverter.ToString(md5.Hash).Replace("-", "").ToLower()
            If Funciones.SerializeObjetc(jsonfile, jsoninfo) = False Then Throw New Exception
            If IO.File.Exists(Zipfile) Then IO.File.Delete(Zipfile)
            Using archive As ZipArchive = System.IO.Compression.ZipFile.Open(Zipfile, ZipArchiveMode.Create)
                archive.CreateEntryFromFile(jsonfile, "Info.json")
                archive.CreateEntryFromFile(packfile, CurrentMod.ModLsx.Folder + ".pak")
            End Using
        End If

        IO.File.Delete(packfile)
        IO.File.Delete(jsonfile)
    End Sub

    Public Sub Cancel_mod()
        CurrentMod.ModLsx.RejectChanges()
        CurrentMod.Versionconverter = LSLib.LS.PackedVersion.FromInt64(CurrentMod.ModLsx.Version)
        NumericUpDown1.Value = CurrentMod.Versionconverter.Major
        NumericUpDown2.Value = CurrentMod.Versionconverter.Minor
        NumericUpDown3.Value = CurrentMod.Versionconverter.Revision
        NumericUpDown4.Value = CurrentMod.Versionconverter.Build
        Repinta()
    End Sub
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Cancel_mod()
        If CurrentMod.Isnew = True Then Me.ButtonSave.Enabled = False : Me.Close()
        Habilita_Deshabilita_edicion(False)
        RaiseEvent Changed_status()
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        Habilita_Deshabilita_edicion(True)
    End Sub


    Private Sub UtamMod_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ButtonSave.Enabled = True Then
            MsgBox("Save or cancel changes before closing", vbOKOnly, "Changes not saved")
            e.Cancel = True
        End If
    End Sub

    Public Event Changed_status()

End Class
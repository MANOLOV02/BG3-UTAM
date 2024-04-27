﻿Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.Json
Imports LSLib.LS
Imports LSLib.LS.Enums
Imports BG3_Modding_Tools.FuncionesHelpers
Imports System.Runtime.InteropServices
Imports Pfim
Imports System.Drawing.Imaging
Imports System.Text
Imports System.IO.Compression
Imports System.Security.Cryptography.X509Certificates
Imports System.DirectoryServices
Imports System.Net.WebRequestMethods
Imports LSLib.Granny

Module Extensions




    <Extension>
    Public Function TryGetOrEmpty(str As String) As String
        If IsNothing(str) Then Return "Nothing"
        Return str
    End Function
    <Extension>
    Public Function ZippedString(str As String) As Byte()
        Dim Result As Byte() = Nothing
        Using OriginalStream = New MemoryStream(Encoding.UTF8.GetBytes(str))
            Using CompressedString As New MemoryStream()
                Using compressor = New GZipStream(CompressedString, CompressionLevel.Optimal, False)
                    OriginalStream.CopyTo(compressor)
                    compressor.Close()
                    Result = CompressedString.ToArray
                End Using
            End Using
        End Using
        Return Result
    End Function
    <Extension>
    Public Function UnZippedString(Zipped As Byte()) As String
        If IsNothing(Zipped) OrElse Zipped.Length = 0 Then Return Funciones.Manolo_Node_Not_Found
        Dim Result As String
        Using CompressedString = New MemoryStream(Zipped)
            Using DecompressedStream As New MemoryStream()
                Using decompressor = New GZipStream(CompressedString, CompressionMode.Decompress, False)
                    decompressor.CopyTo(DecompressedStream)
                    decompressor.Close()
                    Result = Encoding.UTF8.GetString(DecompressedStream.ToArray())
                End Using
            End Using
        End Using
        Return Result
    End Function

    <Extension>
    Public Function TryGetOrNothing(Quien As LSLib.LS.Node, str As String) As String
        If Quien.Attributes.ContainsKey(str) = False Then
            Return Nothing
        End If
        If Quien.Attributes(str).Type = AttributeType.TranslatedString Then
            If CType(Quien.Attributes(str).Value, TranslatedString).Handle = "" Then Return ""
            If CType(Quien.Attributes(str).Value, TranslatedString).Handle.StartsWith("h"c) = False Then Return ""
            Return CType(Quien.Attributes(str).Value, TranslatedString).Handle + ";" + CType(Quien.Attributes(str).Value, TranslatedString).Version.ToString
        End If
        If Quien.Attributes(str).Type = AttributeType.UUID Then
            Return Quien.Attributes(str).AsString(Funciones.Guid_to_string)
        End If
        Return Quien.Attributes(str).Value
    End Function

    <Extension>
    Public Function TryGetOrEmpty(Quien As LSLib.LS.Node, str As String) As String
        If Quien.Attributes.ContainsKey(str) = False Then
            Return ""
        End If
        Return Quien.TryGetOrNothing(str)
    End Function

    <Extension>
    Public Function TryGetOrzero(Quien As LSLib.LS.Node, str As String) As Long
        If Quien.Attributes.ContainsKey(str) = False Then
            Return 0
        End If
        Return Quien.Attributes(str).Value
    End Function

    <Extension>
    Public Function To_XML(node As LSLib.LS.Node, Optional Indented As Boolean = True) As String
        Dim str As String
        ' Get Node
        Using memoria As New MemoryStream
            Using reader As New StreamReader(memoria)
                Dim Converter As New LSLib.LS.LSXWriter(memoria) With {.PrettyPrint = Indented, .Version = LSXVersion.V4}
                Converter.Write(node)
                memoria.Position = 0
                str = reader.ReadToEnd
            End Using
        End Using
        ' Put Region
        Return str
    End Function

    <Extension>
    Public Function To_UTAMXML(XML As String) As String
        Dim result As String
        Dim Final As New StringBuilder()
        Using original As New StringReader(XML)
            Using Template As New StringReader(Funciones.TemplateXML)
                Dim Coretabs As String = "".PadLeft(4, vbTab)
                Dim lin As String = ""
                Final.AppendLine(original.ReadLine)
                Final.AppendLine(Template.ReadLine)
                Final.AppendLine(Template.ReadLine)
                Final.AppendLine(Template.ReadLine)
                Final.AppendLine(Template.ReadLine)
                Final.AppendLine(Template.ReadLine)
                lin = original.ReadLine()
                While Not IsNothing(lin)
                    Final.AppendLine(Coretabs + lin)
                    lin = original.ReadLine()
                End While

                Final.AppendLine(Template.ReadLine)
                Final.AppendLine(Template.ReadLine)
                Final.AppendLine(Template.ReadLine)
                Final.AppendLine(Template.ReadLine)
                result = Final.ToString
            End Using
        End Using
        Return result
    End Function

    <Extension>
    Public Function To_XML(node As LSLib.LS.Resource) As String
        Dim str = ""
        Using memoria As New MemoryStream
            Using reader As New StreamReader(memoria)
                Dim Converter As New LSLib.LS.LSXWriter(memoria) With {.PrettyPrint = True, .Version = LSXVersion.V4}
                Converter.Write(node)
                memoria.Position = 0
                str = reader.ReadToEnd
            End Using
        End Using
        Return str
    End Function
End Module

Public Class Funciones


#Region "Globales"
    Public Shared ReadOnly LoadParams_LSLIB As ResourceLoadParameters = ResourceLoadParameters.FromGameVersion(Game.BaldursGate3)
    Public Shared ReadOnly ConversionParams_LSLIB As ResourceConversionParameters = ResourceConversionParameters.FromGameVersion(Game.BaldursGate3)
    Public Shared ReadOnly Lista_UtamTypes = [Enum].GetNames(Of BG3_Enum_UTAM_Type).ToList
    Public Shared ReadOnly ManoloSep = "!!MANOLOSEP!!"
    Public Shared ReadOnly ManoloRegion = "UTAM - Extracted Node"
    Public Shared ReadOnly Guid_to_string = New NodeSerializationSettings With {.DefaultByteSwapGuids = True, .ByteSwapGuids = True}
    Public Shared ReadOnly GameObjectsType_EnumNames As List(Of String) = [Enum].GetNames(GetType(BG3_Enum_Templates_Type)).ToList
    Public Shared ReadOnly Default_LS_Version_Major As Integer = 4
    Public Shared ReadOnly Default_LS_Version_Minor As Integer = 0
    Public Shared ReadOnly Default_LS_Version_Revision As Integer = 9
    Public Shared ReadOnly Default_LS_Version_Build As Integer = 331
    Public Shared ReadOnly TemplateXML As String =
        "<save>" + vbCrLf _
       + vbTab + "<version major=" + Chr(34) + Default_LS_Version_Major.ToString + Chr(34) + " minor=" + Chr(34) + Default_LS_Version_Minor.ToString + Chr(34) + " revision=" + Chr(34) + Default_LS_Version_Revision.ToString + Chr(34) + " build=" + Chr(34) + Default_LS_Version_Build.ToString + Chr(34) + " lslib_meta=" + Chr(34) + "v1,bswap_guids" + Chr(34) + " />" + vbCrLf _
       + vbTab + "<region id=" + Chr(34) + Funciones.ManoloRegion + Chr(34) + ">" + vbCrLf _
       + vbTab + vbTab + "<node id=" + Chr(34) + "root" + Chr(34) + ">" + vbCrLf _
       + vbTab + vbTab + vbTab + "<children>" + vbCrLf _
       + vbTab + vbTab + vbTab + "</children>" + vbCrLf _
       + vbTab + vbTab + "</node>" + vbCrLf _
       + vbTab + "</region>" + vbCrLf _
       + "</save>" + vbCrLf
    Public Shared ReadOnly Manolo_Node_Not_Found = ("<node id=" + Chr(34) + "Not Found" + Chr(34) + vbCrLf + "</node>").To_UTAMXML

#End Region
    Public Shared Function NewGUID(localization As Boolean) As String
        If localization = False Then
            Return Guid.NewGuid.ToString
        Else
            Return "h" + Guid.NewGuid.ToString.Replace("-", "g")
        End If
    End Function
    Public Shared Sub ProcesaPacksBackground(Worker As Object, e As DoWorkEventArgs)
        Dim result As Boolean
        'Starting
        SyncLock (Progreso)
            Progreso.MaxP1 = 100
            Progreso.MaxP2 = 100
            Progreso.ValueP1 = 0
            Progreso.ValueP2 = 0
        End SyncLock


        Try
            result = Ordena_Paquetes(Worker, e.Argument)
            Worker.ReportProgress(1, Progreso)
            If result = True Then result = Lee_Paquetes(Worker)
            Worker.ReportProgress(1, Progreso)
            If result = True And e.Argument = True Then result = Lee_Losse_Files(Worker)
            Worker.ReportProgress(1, Progreso)
            e.Result = result


        Catch ex As Exception
            Debugger.Break()
            e.Result = False
        End Try
    End Sub
    Public Shared Sub ProcesoParaleloArbol_DoWork(sender As Object, e As DoWorkEventArgs)
        Try
            e.Result = e.Argument.Reload
        Catch ex As Exception
            e.Result = False
            Debugger.Break()
        End Try

    End Sub

    Public Shared Function Ordena_Paquetes(ByRef Worker As Object, includeMods As Boolean) As Boolean
        Try
            Dim result As Boolean = True
            Dim Filtro1 = New DirectoryInfo(GameEngine.Settings.GameDataFolder).GetFiles("*.pak", SearchOption.AllDirectories).Where(Function(pf)
                                                                                                                                         Return IO.Path.GetFileNameWithoutExtension(pf.Name).StartsWith("Textures_", StringComparison.OrdinalIgnoreCase) = False _
                                                                                                                                  AndAlso IO.Path.GetFileNameWithoutExtension(pf.Name).StartsWith("VirtualTextures_", StringComparison.OrdinalIgnoreCase) = False
                                                                                                                                     End Function)
            Dim filtro3 As FileInfo() = New DirectoryInfo(GameEngine.Settings.GameModFolder).GetFiles("*.pak")

            SyncLock (Progreso)
                Progreso.ValueP1 = 0
                Progreso.ValueP2 = 0
                Progreso.MaxP2 = Filtro1.Count
                If includeMods Then Progreso.MaxP2 += filtro3.Length
            End SyncLock

            Dim SenderL As BackgroundWorker = Worker
            Parallel.ForEach(Filtro1, Sub(fil)
                                          If SenderL.CancellationPending = True Then result = False : Exit Sub
                                          SyncLock GameEngine.ProcessedPackList
                                              GameEngine.ProcessedPackList.AddPackageContainer(fil.FullName, BG3_Enum_Package_Type.BaseGame)
                                          End SyncLock

                                          SyncLock (Progreso)
                                              Progreso.ValueP2 += 1
                                              SenderL.ReportProgress(1, Progreso)
                                          End SyncLock

                                      End Sub)
            If includeMods = True Then
                Parallel.ForEach(filtro3, Sub(fil)
                                              If SenderL.CancellationPending = True Then result = False : Exit Sub
                                              SyncLock GameEngine.ProcessedPackList
                                                  GameEngine.ProcessedPackList.AddPackageContainer(fil.FullName, BG3_Enum_Package_Type.BaseMod)
                                              End SyncLock
                                              SyncLock (Progreso)
                                                  Progreso.ValueP2 += 1
                                                  SenderL.ReportProgress(1, Progreso)
                                              End SyncLock
                                          End Sub)
            End If

            SyncLock GameEngine.ProcessedPackList
                GameEngine.ProcessedPackList.Re_Sort()
            End SyncLock
            Return result
        Catch ex As Exception
            Debugger.Break()
            Return False
        End Try

    End Function
    Private Shared Function Fix_Split(que As String) As String
        If que <> "" AndAlso que.EndsWith(Chr(34)) Then que = que.Remove(que.Length - 1, 1)
        Return que
    End Function
    Public Shared Sub Read_lsf(ByRef source As BG3_Pak_SourceOfResource_Class)

        Dim Recurso = source.ReadResource
        For Each reg In Recurso.Regions
            'Parallel.ForEach(Pack.ReadResource(fil).Regions, Sub(reg)

            Select Case reg.Key
                Case "CharacterVisualBank"
                    For Each Nod In reg.Value.Children
                        For Each child In Nod.Value
                            Dim result = GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(child, source, BG3_Enum_VisualBank_Type.CharacterVisualBank))
                        Next
                    Next
                Case "VisualBank"
                    For Each Nod In reg.Value.Children
                        For Each child In Nod.Value
                            Dim result = GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(child, source, BG3_Enum_VisualBank_Type.VisualBank))
                        Next
                    Next
                Case "MaterialBank"
                    For Each Nod In reg.Value.Children
                        For Each child In Nod.Value
                            Dim result = GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(child, source, BG3_Enum_VisualBank_Type.MaterialBank))
                        Next
                    Next
                Case "TextureBank"
                    For Each Nod In reg.Value.Children
                        For Each child In Nod.Value
                            Dim result = GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(child, source, BG3_Enum_VisualBank_Type.TextureBank))
                        Next
                    Next
                Case "MaterialPresetBank"
                    For Each Nod In reg.Value.Children
                        For Each child In Nod.Value
                            Dim result = GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(child, source, BG3_Enum_VisualBank_Type.MaterialPresetBank))
                        Next
                    Next
                Case "Material"
                    Dim result = GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(reg.Value, source, BG3_Enum_VisualBank_Type.Material))

                Case "VirtualTextureBank"
                    For Each Nod In reg.Value.Children
                        For Each child In Nod.Value
                            Dim result = GameEngine.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(child, source, BG3_Enum_VisualBank_Type.VirtualTextureBank))
                        Next
                    Next

                Case "MaterialPreset"
                    'Dim result = GameSettings.ProcessedVisualBanksList.Manage_Overrides(New BG3_Obj_VisualBank_Class(reg.Value, source, BG3_Enum_VisualBank_Type.MaterialPreset))
                Case "Resource"
                Case "Tags", "Flags"
                    GameEngine.ProcessedFlagsAndTags.Manage_Overrides(New BG3_Obj_FlagsAndTags_Class(reg.Value, source))
                Case "Templates"
                    For Each Nod In reg.Value.Children
                        Select Case Nod.Key
                            Case "GameObjects"
                                For Each child In Nod.Value
                                    Dim result = GameEngine.ProcessedGameObjectList.Manage_Overrides(New BG3_Obj_Template_Class(child, source))
                                Next
                            Case Else
                                Debugger.Break()
                        End Select
                    Next
                Case "IconUVList"
                    Dim child = Recurso.Regions("TextureAtlasInfo")
                    Dim atlas = GameEngine.ProcessedIconAtlassList.Manage_Overrides(New BG3_Obj_IconAtlass_Class(child, source))
                    For Each uv In Recurso.Regions("IconUVList").Children.First.Value
                        GameEngine.ProcessedIcons.Manage_Overrides(New BG3_Obj_IconUV_Class(uv, source, atlas))
                    Next
                Case "TextureAtlasInfo"
                    ' Overrided with IconUVList
                Case "root"
                Case "AnimationBank"
                Case "AnimationBlueprintBank"
                Case "AnimationSetBank"
                Case "AnimationSourceId"
                Case "AtmosphereBank"
                Case "Attitudes"
                Case "Batches"
                Case "BlendSpaceBank"
                Case "Chasms"
                Case "ClothColliderBank"
                Case "ColorListBank"
                Case "CombatCameraParams"
                Case "config"
                Case "dialog"
                Case "DialogBank"
                Case "DiffusionProfileBank"
                Case "EffectBank"
                Case "Emotions"
                Case "EnterPhaseSoundEvents"
                Case "EnterSoundEvents"
                Case "ExitPhaseSoundEvents"
                Case "ExitSoundEvents"
                Case "FCurveBank"
                Case "HLODs"
                Case "IKRigBank"
                Case "InstanceGroup"
                Case "LevelData"
                Case "LightCookieBank"
                Case "LightingBank"

                Case "MeshProxyBank"
                Case "MultiEffectInfos"
                Case "PhysicsBank"
                Case "PortalData"
                Case "ScriptBank"
                Case "SkeletonBank"
                Case "Sound"
                Case "SoundBank"
                Case "SoundBanks"
                Case "SoundListenerSpatializationSettings"
                Case "SoundOcclusionMaterialSettings"
                Case "SoundOcclusionSchedulerSettings"
                Case "SoundPreloadSettings"
                Case "VoiceMetaData"
                Case "SpeakerGroups"
                Case "SplineSetBank"
                Case "TerrainBrushBank"
                Case "TileSetBank"
                Case "TimelineBank"
                Case "TimelineCombatCameraEvaluator"
                Case "TimelineContent"
                Case "TimelineEmotionalMaterials"
                Case "TimelineSceneBank"
                Case "TimelineVTPrefetch"
                Case "TLScene"
                Case "TLSystemConfig"
                Case "TranslatedStringKeys"
                Case "VisualSetSlotsSystem"
                Case "VoiceBarkBank"
                Case "WallSetBank"
                Case "FallbackPaths"
                Case "Hints"
                Case "TutorialInputEvents"
                Case "Config"
                Case "CustomDice"
                Case "DLC"
                Case "SceneConfig"

                Case "GfxDeviceData"
                Case "Origins"
                Case "TadpolePowersTree"
                Case "LevelMapValues"
                Case "ExperienceRewards"
                Case "MetaData"
                Case "Layers"
                Case "EquipmentRaces"
                Case "EquipmentSlots"
                Case "DialogVariables"
                Case "Gods"
                Case "Voices"
                Case "ConditionErrors"
                Case "EquipmentTypes"
                Case "PassiveLists"
                Case "AbilityLists"
                Case "SpellLists"
                Case "SkillLists"
                Case "PassivesVFX"
                Case "CharacterCreationPresets"
                Case "CharacterCreationMaterialOverrides"
                Case "CharacterCreationSkinColors"
                Case "AbilityDistributionPresets"


                Case "Backgrounds"
                Case "DifficultyClasses"
                Case "Crime"
                Case "Rulebook"
                Case "FactionContainer"
                Case "FactionManager"
                Case "AnimationSetPriorities"
                Case "SurfaceCursorMessages"
                Case "ProjectileDefaults"
                Case "DefaultValues"
                Case "MetaConditions"
                Case "ActionResourceGroupDefinitions"
                Case "SpellSoundTrajectoryRules"
                Case "TrajectoryRules"
                Case "Feats"
                Case "FeatSoundStates"
                Case "FeatDescriptions"
                Case "Types"
                Case "TagSoundStates"
                Case "FlagSoundStates"
                Case "ProgressionDescriptions"
                Case "Progressions"
                Case "Color"
                Case "AvatarContainerTemplates"
                Case "EquipmentLists"
                Case "CampChestTemplates"
                Case "ColorDefinitions"
                Case "GameplayVFXs"
                Case "DeathEffects"
                Case "ItemThrowParams"
                Case "CompanionPresets"
                Case "CrowdCharacterMaterialPresets"
                Case "CharacterCreationHairColors"
                Case "CrowdCharacterEyeColors"
                Case "CrowdCharacterTemplates"
                Case "CharacterCreationEyeColors"
                Case "CrowdCharacterClothsColors"
                Case "CrowdCharacterSkinColors"
                Case "Tutorials"
                Case "UnifiedTutorials"
                Case "LimbsMapping"
                Case "ModalTutorials"
                Case "Races"
                Case "ActionResourceDefinitions"
                Case "ItemWallTemplates"
                Case "ClassDescriptions"
                Case "AiPathSettings"
                Case "FixedHotBarSlots"
                Case "ScriptFlags"
                Case "CharacterCreationAppearanceVisuals"
                Case "Outcomes"
                Case "ManagedStatusVFX"
                Case "CombatCameraGroups"
                Case "TutorialEvents"
                Case "DayRanges"
                Case "StatusSoundStates"
                Case "WeaponAnimationSetData"
                Case "WeightCategories"
                Case "CinematicArenaFrequencyGroups"
                Case "TooltipUpcastDescriptions"
                Case "TooltipExtraTexts"
                Case "VisualLocatorAttachments"
                Case "CharacterCreationIconSettings"
                Case "CharacterCreationPassiveAppearances"
                Case "CharacterCreationAppearanceMaterials"
                Case "LongRestCosts"
                Case "CharacterCreationAccessorySets"
                Case "CharacterCreationVOLines"
                Case "RulesetModifiers"
                Case "LightbarHaptics"
                Case "Rulesets"
                Case "RulesetSelectionPresets"
                Case "RulesetModifierOptions"
                Case "RulesetValues"
                Case "DisturbanceProperties"
                Case "GoldValues"
                Case "CharacterCreationEquipmentIcons"
                Case "CharacterCreationSharedVisuals"
                Case "WorldMapMetaData"
                Case "PartyPreset"
                Case "AreaLevelOverrides"
                Case "ScriptMaterialOverridePresets"
                Case "ScriptMaterialOverrideParameters"
                Case "BackgroundGoals"
                Case "Reactions"
                Case "Markers"
                Case "Quests"
                Case "Objectives"
                Case "QuestCategories"
                Case "Gossips"
                Case "OriginIntroEntities"
                Case Else
                    Debugger.Break()
            End Select
            'End Sub)
        Next
    End Sub
    Public Shared Sub Read_loca(source As BG3_Pak_SourceOfResource_Class)
        Dim Language As Bg3_Enum_Languages = Bg3_Enum_Languages.English
        Dim Gender As Bg3_Enum_Genders = Bg3_Enum_Genders.Male
        Dim Genderto As Bg3_Enum_GendersTo = Bg3_Enum_GendersTo.M_to_M

        If Path.GetDirectoryName(source.Filename_Relative).ToLower.EndsWith("gender\female") Then Gender = Bg3_Enum_Genders.Female
        If Path.GetDirectoryName(source.Filename_Relative).ToLower.EndsWith("gender\neutral") Then Gender = Bg3_Enum_Genders.Neutral

        Select Case IO.Path.GetDirectoryName(IO.Path.GetRelativePath("Localization", source.Filename_Relative)).ToLower
            Case "english", "english\gender\female", "english\gender\neutral"
                Language = Bg3_Enum_Languages.English
            Case "brazilianportuguese", "brazilianportuguese\gender\female", "brazilianportuguese\gender\neutral"
                Language = Bg3_Enum_Languages.BrazilianPortuguese
            Case "chinese", "chinese\gender\female", "chinese\gender\neutral"
                Language = Bg3_Enum_Languages.Chinese
            Case "chinesetraditional", "chinesetraditional\gender\female", "chinesetraditional\gender\neutral"
                Language = Bg3_Enum_Languages.ChineseTraditional
            Case "french", "french\gender\female", "french\gender\neutral"
                Language = Bg3_Enum_Languages.French
            Case "german", "german\gender\female", "german\gender\neutral"
                Language = Bg3_Enum_Languages.German
            Case "italian", "italian\gender\female", "italian\gender\neutral"
                Language = Bg3_Enum_Languages.Italian
            Case "korean", "korean\gender\female", "korean\gender\neutral"
                Language = Bg3_Enum_Languages.Korean
            Case "latinspanish", "latinspanish\gender\female", "latinspanish\gender\neutral"
                Language = Bg3_Enum_Languages.LatinSpanish
            Case "polish", "polish\gender\female", "polish\gender\neutral"
                Language = Bg3_Enum_Languages.Polish
            Case "russian", "russian\gender\female", "russian\gender\neutral"
                Language = Bg3_Enum_Languages.Russian
            Case "spanish", "spanish\gender\female", "spanish\gender\neutral"
                Language = Bg3_Enum_Languages.Spanish
            Case "turkish", "turkish\gender\female", "turkish\gender\neutral"
                Language = Bg3_Enum_Languages.Turkish
            Case "ukrainian", "ukrainian\gender\female", "ukrainian\gender\neutral"
                Language = Bg3_Enum_Languages.Ukrainian
            Case Else
                Debugger.Break()
        End Select

        Select Case Gender
            Case Bg3_Enum_Genders.Male
                Genderto = Bg3_Enum_GendersTo.M_to_M
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_F") Then Genderto = Bg3_Enum_GendersTo.M_to_F
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_M") Then Genderto = Bg3_Enum_GendersTo.M_to_M
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_X") Then Genderto = Bg3_Enum_GendersTo.M_to_X
            Case Bg3_Enum_Genders.Female
                Genderto = Bg3_Enum_GendersTo.F_to_F
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_F") Then Genderto = Bg3_Enum_GendersTo.F_to_F
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_M") Then Genderto = Bg3_Enum_GendersTo.F_to_M
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_X") Then Genderto = Bg3_Enum_GendersTo.F_to_X
            Case Bg3_Enum_Genders.Neutral
                Genderto = Bg3_Enum_GendersTo.X_to_X
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_F") Then Genderto = Bg3_Enum_GendersTo.X_to_F
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_M") Then Genderto = Bg3_Enum_GendersTo.X_to_M
                If Path.GetFileNameWithoutExtension(source.Filename_Relative).EndsWith("_to_X") Then Genderto = Bg3_Enum_GendersTo.X_to_X
        End Select

        Dim loca = source.ReadLocaResource
        For Each Entry In loca.Entries
            SyncLock (GameEngine.ProcessedLocalizationList)
                Dim objl As BG3_Loca_Localization_Class
                If GameEngine.ProcessedLocalizationList.ContainsKey(Entry.Key + ";" + Entry.Version.ToString) Then
                    objl = GameEngine.ProcessedLocalizationList(Entry.Key + ";" + Entry.Version.ToString)
                    objl.AddSpecific(Language, Gender, Genderto, Entry.Text, source)
                Else
                    objl = New BG3_Loca_Localization_Class(Language, Gender, Genderto, Entry, source)
                End If
                If GameEngine.ProcessedLocalizationList.TryAdd(objl.Keymap, objl) = False Then
                    GameEngine.ProcessedLocalizationList(objl.Keymap) = objl
                End If
            End SyncLock
        Next
        source.ReleaseMem()
    End Sub

    Public Shared Sub Read_Txt_Stats(ByRef Source As BG3_Pak_SourceOfResource_Class)
        Dim ShortName = IO.Path.GetFileNameWithoutExtension(Source.Filename_Relative)
        Select Case ShortName
            Case "ItemProgressionVisuals", "ItemProgressionNames", "XPData", "BloodTypes", "Data", "ItemColor"
                ' IGNORED
            Case Else
                Using fileStream = New StreamReader(Source.CreateContentReader)
                    Dim line As String = fileStream.ReadLine
                    Dim name As String = ""
                    Dim stobj As BG3_Obj_Stats_Class = Nothing
                    Dim lines As String()
                    While line IsNot Nothing
                        If line <> "" Then
                            lines = line.Split(" " + Chr(34)).Select(Function(pq) Fix_Split(pq)).ToArray
                            Try
                                Select Case lines(0)
                                    Case "new entry"
                                        name = lines(1)
                                        stobj = New BG3_Obj_Stats_Class(Source, name)
                                        stobj = GameEngine.ProcessedStatList.Manage_Overrides(stobj)
                                    Case "new ItemCombination"
                                        name = lines(1)
                                        stobj = New BG3_Obj_Stats_Class(Source, name) With {.Type = BG3_Enum_StatType.ItemCombination}
                                        stobj = GameEngine.ProcessedStatList.Manage_Overrides(stobj)
                                    Case "new ItemCombinationResult"
                                        name = lines(1)
                                        stobj = New BG3_Obj_Stats_Class(Source, name) With {.Type = BG3_Enum_StatType.ItemCombination, .[Using] = stobj.MapKey}
                                        stobj = GameEngine.ProcessedStatList.Manage_Overrides(stobj)
                                    Case "using"
                                        If lines(1) <> stobj.MapKey Then
                                            If stobj.Using <> "" And stobj.Using <> lines(1) Then
                                                GameEngine.ProcessedStatList.RemoveHyerarchy(stobj)
                                            End If
                                            If stobj.Using <> lines(1) Then
                                                stobj.Using = lines(1)
                                                GameEngine.ProcessedStatList.AddHyerarchy(stobj)
                                            End If
                                        End If
                                    Case "type"
                                        stobj.Type = [Enum].GetNames(GetType(BG3_Enum_StatType)).ToList.IndexOf(lines(1))
                                        If stobj.Type = -1 Then Debugger.Break()
                                    Case "data"
                                        If stobj.Data.TryAdd(lines(1), lines(2)) = False Then
                                            stobj.Data(lines(1)) = lines(2)
                                        End If
                                    Case Else
                                        Debugger.Break()
                                End Select
                            Catch ex As Exception
                                Debugger.Break()
                            End Try
                        End If
                        line = fileStream.ReadLine
                    End While
                    fileStream.Close()
                    fileStream.Dispose()
                End Using
        End Select
        Source.ReleaseMem()
    End Sub
    Public Shared Sub Read_Txt_Treasure(ByRef Source As BG3_Pak_SourceOfResource_Class)
        Dim ShortName = IO.Path.GetFileNameWithoutExtension(Source.Filename_Relative)
        Using fileStream = New StreamReader(Source.CreateContentReader)
            Dim line As String = fileStream.ReadLine
            Dim name As String = ""
            Dim stobj As BG3_Obj_TreasureTable_Class = Nothing
            Dim stsub As BG3_Obj_TreasureTable_Subtable_Class = Nothing
            While line IsNot Nothing
                If line <> "" Then
                    Dim lines As String()
                    lines = line.Split(" " + Chr(34)).Select(Function(pq) Fix_Split(pq)).ToArray
                    Try
                        Select Case True
                            Case line.StartsWith("new treasuretable", StringComparison.OrdinalIgnoreCase)
                                name = lines(1)
                                stobj = New BG3_Obj_TreasureTable_Class(Source, name)
                                stobj = GameEngine.ProcessedTTables.Manage_Overrides(stobj)
                                stsub = Nothing
                            Case line.StartsWith("CanMerge 1", StringComparison.OrdinalIgnoreCase)
                                stobj.CanMerge = True
                            Case line.StartsWith("new subtable", StringComparison.OrdinalIgnoreCase)
                                stsub = New BG3_Obj_TreasureTable_Subtable_Class(Source, lines(1))
                                stobj.Subtables.Add(stsub)
                            Case line.StartsWith("object category", StringComparison.OrdinalIgnoreCase)
                                Dim it As New BG3_Obj_TreasureTable_TableItem_Class(line.Remove(0, "object category ".Length))
                                stsub.Lista.Add(it)
                            Case line.StartsWith("treasure itemtypes", StringComparison.OrdinalIgnoreCase)
                                ' I have no idea what this is for. It states all rarity allways
                            Case line.StartsWith("StartLevel", StringComparison.OrdinalIgnoreCase)
                                stsub.MinLevel = lines(1)
                            Case line.StartsWith("EndLevel", StringComparison.OrdinalIgnoreCase)
                                stsub.MaxLevel = lines(1)
                            Case Else
                                Debugger.Break()
                        End Select
                    Catch ex As Exception
                        Debugger.Break()
                    End Try
                End If
                line = fileStream.ReadLine
            End While
            fileStream.Close()
            fileStream.Dispose()
        End Using

        Source.ReleaseMem()
    End Sub
    Public Shared Sub Read_Txt(ByRef Source As BG3_Pak_SourceOfResource_Class)
        Dim ShortName = IO.Path.GetFileNameWithoutExtension(Source.Filename_Relative)
        Dim directorio = IO.Path.GetDirectoryName(Source.Filename_Relative)
        Select Case True
            Case directorio.EndsWith("Stats\Generated\Data", StringComparison.OrdinalIgnoreCase)
                Read_Txt_Stats(Source)
            Case Else
                Select Case ShortName
                    Case "ItemCombos"
                        Read_Txt_Stats(Source)
                    Case "TreasureTable"
                        Read_Txt_Treasure(Source)
                    Case "ReConHistory"
                    Case "credits"
                    Case "pakgenerator"
                    Case "README_Custom_Templates"
                    Case "story_orphanqueries_ignore_local"
                    Case "Equipment"
                    Case "SpellSet"
                    Case "ObjectCategoriesItemComboPreviewData"
                    Case "ItemTypes"
                    Case "ValueLists"
                    Case "Modifiers"
                    Case "combos"
                    Case "healer_melee"
                    Case "base"
                    Case "modifiers"
                    Case "gnoll_ranger"
                    Case "imp_melee"
                    Case "melee_large"
                    Case "harpy_melee"
                    Case "melee_smart"
                    Case "necromancer_ranged"
                    Case "melee"
                    Case "harpy_ranged"
                    Case "zombie"
                    Case "madness"
                    Case "beast"
                    Case "ranged_smart"
                    Case "necromancer_melee"
                    Case "spider_phase_queen"
                    Case "melee_ignoresurfacedamage"
                    Case "gnoll_melee"
                    Case "mage_smart"
                    Case "minotaur"
                    Case "spider_phase"
                    Case "merregon"
                    Case "myconid_ranged"
                    Case "mage"
                    Case "act1_wyll"
                    Case "bulette"
                    Case "beast_ranged"
                    Case "goblin_mage"
                    Case "cinematic_melee"
                    Case "hag_green"
                    Case "owlbear"
                    Case "melee_magic_smart"
                    Case "ranged_ignoresurfacedamage"
                    Case "scryingeye"
                    Case "golem_adamantine"
                    Case "ranged_stupid"
                    Case "goblin_ranged"
                    Case "melee_stupid"
                    Case "ranged"
                    Case "act2_TWN_nurse"
                    Case "beholder"
                    Case "imp_ranged"
                    Case "healer_ranged"
                    Case "melee_magic"
                    Case "goblin_melee"
                    Case "hookhorror"
                    Case "mindflayer"
                    Case "goblin_sapper"
                    Case "mimic"
                    Case "rogue_smart"
                    Case "ogre_melee"
                    Case "rogue"
                    Case "act1_GOB_gut"
                    Case "zombie_HalsinLakeside"
                    Case "act2_Jaheira"
                    Case "act2_TWN_TollCollector_Head"
                    Case "act3_LOW_Melee_IgnorePreferredTarget"
                    Case "act3_LOW_cazador_melee"
                    Case "steel_watcher_biped"
                    Case "act3_LOW_Felogyr_melee_magic"
                    Case "act3_LOW_Guildhall_NineFingers"
                    Case "monk_mage"
                    Case "steelWatcher"
                    Case "act2_HAV_flying_ghouls"
                    Case "act3_WYR_Gortash_melee"
                    Case "Act1_FOR_Fezzerk"
                    Case "mage_SCL"
                    Case "act2_TWN_surgeon_nurse"
                    Case "act2_TWN_surgeon"
                    Case "act3_LOW_MurderTribunal_melee"
                    Case "act2_HAV_FlamingSpy"
                    Case "shadow_parents"
                    Case "act3_FireWizard"
                    Case "act3_LOW_Felogyr_melee_magic_smart"
                    Case "meazel_shadowteleport"
                    Case "act3_WYR_Gortash_ranged"
                    Case "orthon_ranged"
                    Case "act3_LOW_StranglerLuke"
                    Case "koboldinventor_drunk"
                    Case "act3_LOW_Raphael"
                    Case "monk_melee"
                    Case "apostle"
                    Case "act3_LOW_Felogyr_mage"
                    Case "Act2_GLO_Nightsong"
                    Case "act3_WYR_alioramus"
                    Case "act3_LOW_BhaalCultistRanger"
                    Case "act3_LOW_Ranged_PreferredTarget"
                    Case "act3_FireWizard2"
                    Case "act3_LOW_Mage_PreferredTarget"
                    Case "shadow_HalsinLakeside"
                    Case "Act2_COL_Ketheric"
                    Case "orthon_melee"
                    Case "act2_TWN_brewer"
                    Case "fey_mastiff"
                    Case "shadow_Creeper_HalsinLakeside"
                    Case "goblin_melee_SCL"
                    Case "act2_TWN_GithyankiMelee"
                    Case "mage_no_inventory_items"
                    Case "act3_LOW_Mage_IgnorePreferredTarget"
                    Case "act3_LOW_DevellaFountainHead"
                    Case "ranged_SCL"
                    Case "act3_LOW_cazador"
                    Case "cloaker_phantasm"
                    Case "act3_LOW_Ranged_IgnorePreferredTarget"
                    Case "act3_LOW_Felogyr_melee"
                    Case "act3_LOW_Mage_Smart_Gondian"
                    Case "act2_SHA_LastJusticiar"
                    Case "act3_LOW_SteelWatcher_Titan"
                    Case "melee_smart_SCL"
                    Case "act3_LOW_GithyankiProdigy"
                    Case "shadow"
                    Case "ranged_smart_SCL"
                    Case "Act1b_CRE_HatcheryRaider"
                    Case "act2_TWN_TollCollector"
                    Case "drider"
                    Case "goblin_ranged_SCL"
                    Case "act3_LOW_MurderTribunal"
                    Case "act2_SHA_necromancer"
                    Case "rogue_SCL"
                    Case "act3_WYR_Dribbles_Thug"
                    Case "cloaker"
                    Case "deathKnight"
                    Case "melee_HalsinLakeside"
                    Case "deathShepherd"
                    Case "melee_SCL"
                    Case "act3_LOW_ghost_nurse"
                    Case "shadow_mastiff"
                    Case "act3_LOW_Melee_PreferredTarget"
                    Case "shadow_mastiff_HalsinLakeside"
                    Case "dragon"
                    Case "act3_LOW_CazadorRitual_Wolf"
                    Case "story_orphanqueries_found"
                    Case "story_orphanqueries_ignore"
                    Case "LOW_poltergeist_melee"
                    Case "ForceRecompile"
                    Case Else
                        Debugger.Break()
                End Select


        End Select

    End Sub

    Public Shared Sub Lee_Resource_From_Source(ByRef Source As BG3_Pak_SourceOfResource_Class)
        Select Case IO.Path.GetExtension(Source.Filename_Relative).ToLower
            Case ""
             ' Do nothing
            Case ".txt"
                Read_Txt(Source)
            Case ".anc", ".anm", ".ann"
            Case ".bin", ".bk2", ".bnk", ".bshd"
            Case ".chroma", ".clc", ".clm", ".cln", ".cur"
            Case ".dat", ".data", ".fnt"
            Case ".gamescript", ".itemscript", ".patch", ".psocache", ".khn"
            Case ".gr2", ".gtp", ".gts"
            Case ".js", ".json"
            Case ".dds"
                GameEngine.ProcessedAssets.Manage_Overrides(New BG3_Obj_Assets_Class(Source))
                If IO.Path.GetDirectoryName(Source.Filename_Relative).Contains("GUI\Assets\Tooltips", StringComparison.OrdinalIgnoreCase) Then
                    GameEngine.ProcessedIcons.Manage_Overrides(New BG3_Obj_IconUV_Class(Source))
                End If
                If IO.Path.GetDirectoryName(Source.Filename_Relative).Contains("GUI\Assets\Portraits", StringComparison.OrdinalIgnoreCase) Then
                    GameEngine.ProcessedIcons.Manage_Overrides(New BG3_Obj_IconUV_Class(Source))
                End If
            Case ".jpg", ".png"
            ' Do nothing
            Case ".loca"
                Read_loca(Source)
            Case ".lsbc", ".lsbs"
            Case ".lsf", ".lsx"
                If Source.Filename_Relative.EndsWith(".lsf.lsx", StringComparison.OrdinalIgnoreCase) = False Then
                    Read_lsf(Source)
                Else
                    If Source.PackageType <> BG3_Enum_Package_Type.UTAM_Mod Then Debugger.Break()
                End If
            Case ".meta"
            Case ".lsfx"
            Case ".lsj"
            Case ".osi", ".otf", ".tmpl", ".ttf", ".wem"
            Case ".xaml", ".xml"
            Case ".lua"
            Case ".cfg", ".bak"
            Case ".ffxbones"
            Case ".ffxanim"
            Case ".ffxanim"
            Case ".ffxanim"
            Case ".ffxactor"
            Case Else
                Debugger.Break()
        End Select
        Source.ReleaseMem()

    End Sub
    Public Shared Function Lee_Losse_Files(Worker As Object) As Boolean
        Dim result As Boolean = True
        Dim filtro = IO.Directory.GetFiles(GameEngine.Settings.GameDataFolder, "*.*", SearchOption.AllDirectories).Where(Function(pf) pf.EndsWith(".pak") = False)
        SyncLock Progreso
            Progreso.ValueP2 = 0
            Progreso.MaxP2 = filtro.Count
            Worker.ReportProgress(1, Progreso)
        End SyncLock
        GameEngine.ProcessedModuleList.ProcessMetas(GameEngine.Settings.GameDataFolder, BG3_Enum_Package_Type.Loose_Files)
        Parallel.ForEach(filtro, Sub(fil)
                                     If Worker.CancellationPending = True Or result = False Then Exit Sub
                                     'If GameSettings.ProcessedGameObjectList.Count > 10 Then Exit Sub
                                     Try
                                         Lee_Resource_From_Source(New BG3_Pak_SourceOfResource_Class(GameEngine.Settings.GameDataFolder, fil))
                                     Catch ex As Exception
                                         Debugger.Break()
                                         result = False
                                     End Try

                                     SyncLock (Progreso)
                                         Progreso.ValueP2 += 1
                                         Worker.ReportProgress(1, Progreso)
                                     End SyncLock
                                 End Sub)
        Return result
    End Function

    Public Shared Function Clear_Current_Mod_Loaded(path As String) As Boolean
        GameEngine.UtamTemplates.Clear()
        GameEngine.UtamVisuals.Clear()
        If path <> "" Then
            For Each Tabl In GameEngine.ProcessedTTables.Elements.Values.Where(Function(pf) pf.Subtables.Where(Function(pq) pq.Source.Pak_Or_Folder = path).Any)
                For Each subt In Tabl.Subtables.Where(Function(pq) pq.Source.Pak_Or_Folder = path).ToList
                    Tabl.Subtables.Remove(subt)
                Next
            Next
        End If
        Return True
    End Function
    Public Shared Function Lee_UtamMod(path As String) As Boolean
        Dim result As Boolean = True
        Dim filtro = IO.Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(Function(pf) pf.EndsWith(".pak") = False)
        GameEngine.ProcessedModuleList.ProcessMetas(path, BG3_Enum_Package_Type.UTAM_Mod)
        Clear_Current_Mod_Loaded(path)


        Parallel.ForEach(filtro, Sub(fil)
                                     If result = False Then Exit Sub
                                     Try
                                         Lee_Resource_From_Source(New BG3_Pak_SourceOfResource_Class(path, fil, BG3_Enum_Package_Type.UTAM_Mod))
                                     Catch ex As Exception
                                         Debugger.Break()
                                         result = False
                                     End Try
                                 End Sub)
        Return result
    End Function


    Public Shared Function Lee_Paquetes(Worker As BackgroundWorker) As Boolean
        SyncLock (Progreso)
            Progreso.ValueP1 = 0
            Progreso.MaxP1 = GameEngine.ProcessedPackList.Count + 1
            Worker.ReportProgress(1, Progreso)
        End SyncLock
        Dim result As Boolean = True
        Try
            For Each pack In GameEngine.ProcessedPackList.OrderBy(Function(pf) pf.SortIndex)
                If Worker.CancellationPending = True Or result = False Then Return False

                If Not IsNothing(pack.Package) Then
                    SyncLock Progreso
                        Progreso.ValueP2 = 0
                        Progreso.MaxP2 = pack.Package.Files.Count
                        Worker.ReportProgress(1, Progreso)
                    End SyncLock
                    result = True
                    'GameSettings.ProcessedModuleList.ProcessMetas(pack.PackFileName, pack.PackageType)
                    Parallel.ForEach(pack.Package.Files, Sub(fil)
                                                             If Worker.CancellationPending = True Or result = False Then Exit Sub
                                                             'If GameSettings.ProcessedGameObjectList.Count > 10 Then Exit Sub
                                                             Try
                                                                 Lee_Resource_From_Source(New BG3_Pak_SourceOfResource_Class(pack, fil))
                                                             Catch ex As Exception
                                                                 Debugger.Break()
                                                                 result = False
                                                             End Try

                                                             SyncLock (Progreso)
                                                                 Progreso.ValueP2 += 1
                                                                 Worker.ReportProgress(1, Progreso)
                                                             End SyncLock
                                                         End Sub)
                Else
                    If pack.PackFileName.StartsWith("LowTex") = False Then Debugger.Break()
                End If
                SyncLock (Progreso)
                    Progreso.ValueP1 += 1
                    Worker.ReportProgress(1, Progreso)
                End SyncLock
            Next

            'Debugger.Break()
            Return result
        Catch ex As Exception
            Debugger.Break()
            Return False
        End Try
    End Function

    Public Shared Function SerializeObjetc(Archivo As String, Obj As Object) As Boolean
        Dim writer As StreamWriter = Nothing
        Try
            Dim str = Text.Json.JsonSerializer.Serialize(Obj, Jsonoptions)
            writer = New StreamWriter(Archivo, False)
            writer.Write(str)
            writer.Close()
        Catch ex As Exception
            Debugger.Break()
            If Not IsNothing(writer) Then writer.Close()
            Return False
        End Try
        Return True
    End Function

    Public Shared Function DeserializeObject(Archivo As String, ByRef Obj As Object) As Boolean
        Try
            Obj = Text.Json.JsonSerializer.Deserialize(IO.File.ReadAllText(Archivo), Obj.GetType, Jsonoptions)

        Catch ex As Exception
            Debugger.Break()
            Return False
        End Try
        Return True
    End Function

    Public Shared Function Clear_Loaded() As Boolean
        Try
            For Each que In GameEngine.Cache_Object_List
                que.clear
            Next

        Catch ex As Exception
            Debugger.Break()
            Return False
        End Try
        Return True
    End Function

    Public Shared Function Clear_Cache(Worker As BackgroundWorker) As Boolean
        Worker.ReportProgress(-GameEngine.Cache_String_List.Count)
        Parallel.For(0, GameEngine.Cache_String_List.Count, Sub(x)
                                                                  If Worker.CancellationPending = True Then Exit Sub
                                                                  Try
                                                                      If IO.File.Exists(GameEngine.Cache_String_List(x)) Then IO.File.Delete(GameEngine.Cache_String_List(x))
                                                                  Catch ex As Exception
                                                                      Worker.CancelAsync()
                                                                  End Try
                                                                  If Worker.IsBusy Then Worker.ReportProgress(1)
                                                              End Sub)

        If Worker.CancellationPending = True Then Return False
        Return True
    End Function

    Public Shared Function Load_Cache(Worker As BackgroundWorker) As Boolean
        Worker.ReportProgress(-GameEngine.Cache_String_List.Count)
        Parallel.For(0, GameEngine.Cache_String_List.Count, Sub(x)
                                                                  Dim erro As Boolean
                                                                  If Worker.CancellationPending = True Then Exit Sub
                                                                  erro = DeserializeObject(GameEngine.Cache_String_List(x), GameEngine.Cache_Object_List(x))
                                                                  If Worker.IsBusy Then Worker.ReportProgress(1)
                                                                  If erro = False Then Worker.CancelAsync()
                                                              End Sub)
        If Worker.CancellationPending = True Then Return False
        Return True
    End Function

    Public Shared Function Save_Cache(Worker As BackgroundWorker) As Boolean
        Worker.ReportProgress(-GameEngine.Cache_String_List.Count)
        Parallel.For(0, GameEngine.Cache_String_List.Count, Sub(x)
                                                                  Dim erro As Boolean
                                                                  If Worker.CancellationPending = True Then Exit Sub
                                                                  erro = SerializeObjetc(GameEngine.Cache_String_List(x), GameEngine.Cache_Object_List(x))
                                                                  If Worker.IsBusy Then Worker.ReportProgress(1)
                                                                  If erro = False Then Worker.CancelAsync()
                                                              End Sub)
        If Worker.CancellationPending = True Then Return False
        Return True
    End Function

    Public Shared Function Check_Cache(Worker As BackgroundWorker) As Boolean
        Worker.ReportProgress(-GameEngine.Cache_String_List.Count)
        Parallel.For(0, GameEngine.Cache_String_List.Count, Sub(x)
                                                                  If Worker.CancellationPending = True Then Exit Sub
                                                                  Dim erro As Boolean = IO.File.Exists(GameEngine.Cache_String_List(x))
                                                                  If erro = False Then Worker.CancelAsync()
                                                              End Sub)
        If Worker.CancellationPending = True Then Return False
        Return True
    End Function

    Public Shared Sub ProcesaCacheBackground(Worker As Object, e As DoWorkEventArgs)
        Dim result As Boolean = True
        Dim argumento As Tuple(Of String, BackgroundWorker)
        If e.Argument.GetType = GetType(String) Then
            argumento = Tuple.Create(CType(e.Argument, String), CType(Nothing, BackgroundWorker))
        Else
            argumento = e.Argument
        End If
        If argumento.Item1.ToString.Equals("load") Then result = Load_Cache(Worker) : GameEngine.Relink_Caches()
        If argumento.Item1.ToString.Equals("check") Then result = Check_Cache(Worker)
        If argumento.Item1.ToString.Equals("checkandload") Then result = Check_Cache(Worker)
        If argumento.Item1.ToString.Equals("clear") Then result = Clear_Cache(Worker)
        If argumento.Item1.ToString.Equals("save") Then result = Save_Cache(Worker)

        e.Result = Tuple.Create(result, argumento.Item1.ToString)
    End Sub

    Public Shared Function PfmiToBitmap(stream As Stream) As Bitmap
        Dim bitmap As Bitmap
        Dim stream2 As New MemoryStream
        Using image = Pfimage.FromStream(stream)

            Dim format As New PixelFormat
            Select Case image.Format
                Case Pfim.ImageFormat.Rgba32
                    format = PixelFormat.Format32bppArgb
                Case Pfim.ImageFormat.Rgba16
                    Debugger.Break()
                Case Pfim.ImageFormat.Rgb8
                    Debugger.Break()
                Case Pfim.ImageFormat.Rgb24
                    Debugger.Break()
                Case Pfim.ImageFormat.R5g6b5
                    Debugger.Break()
                Case Pfim.ImageFormat.R5g5b5a1
                    Debugger.Break()
                Case Pfim.ImageFormat.R5g5b5
                    Debugger.Break()
            End Select

            Dim handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned)
            Try
                Dim data = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0)
                bitmap = New Bitmap(image.Width, image.Height, image.Stride, format, data)
                bitmap.Save(stream2, Imaging.ImageFormat.Png)
            Catch ex As Exception
                Debugger.Break()
            Finally
                handle.Free()
            End Try
        End Using

        Return New Bitmap(stream2)
    End Function


End Class
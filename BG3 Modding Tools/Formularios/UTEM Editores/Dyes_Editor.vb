Imports System.Net.Sockets
Imports LSLib.LS

Public Class Dyes_Editor

    Private Pictc() As PictureBox

    Protected Overrides ReadOnly Property Prefix As String = "UTAM_Dye_"
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Dyes
    Protected Overrides ReadOnly Property DefaulStatUsing As String = "_Dyes"
    Protected Overrides ReadOnly Property DefaulParent As String = "1a750a66-e5c2-40be-9f62-0a4bf3ddb403"
    Protected Overrides ReadOnly Property DefaulStat_Type As BG3_Enum_StatType = BG3_Enum_StatType.Object

    ' Dyes
    Protected Overridable Property Color_template_guid As String = Funciones.NewGUID(False)
    Protected Overridable Property SelectedColor As BG3_Obj_VisualBank_Class
    Protected Overridable Property SelectedCombo As BG3_Obj_Stats_Class
    Protected Overridable Property SelectedComboResult As BG3_Obj_Stats_Class

    Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        Me.DoubleBuffered = True
        TabControl1.TabPages.Remove(TabPageDyes)
        TabControl1.TabPages.Insert(1, TabPageDyes)
    End Sub
    Protected Overrides Sub Initialize_Specifics()
        AddHanlders_Dyes()
        HandledAttributes.Add("ColorPreset")
    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        BG3Editor_Complex_Dyecolor1.Enabled = Edicion
        GroupBoxColors.Enabled = Edicion
    End Sub
    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As Node)
        BG3Editor_Template_ColorPreset1.Create_Attribute(nuevonod, Color_template_guid)
    End Sub
    Protected Overrides Sub Add_UTAM_Attribute_Specific(ByRef nuevonod As Node)
        ' Do nothing
    End Sub
    Protected Overrides Sub Capture_Clone_specific(obj As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype)
        Color_template_guid = Funciones.NewGUID(False)
        Select Case tipo
            Case BG3Cloner.Clonetype.None
                BG3Editor_Template_ColorPreset1.Replace_Attribute(Clone_Nuevonod, Color_template_guid)
                BG3Editor_Complex_Dyecolor1.Create(Template_guid, Clone_Stat_Name, Color_template_guid, ActiveModSource)
                SelectedCombo = BG3Editor_Complex_Dyecolor1.ComboItem_Parent
                SelectedComboResult = BG3Editor_Complex_Dyecolor1.ComboItem_Parent.Itemresult
                SelectedColor = BG3Editor_Complex_Dyecolor1.Color_Preset
            Case BG3Cloner.Clonetype.Clone, BG3Cloner.Clonetype.Inherit
                BG3Editor_Template_ColorPreset1.Replace_Attribute(Clone_Nuevonod, Color_template_guid)
                BG3Editor_Complex_Dyecolor1.Create(Template_guid, Clone_Stat_Name, Color_template_guid, ActiveModSource)
                SelectedCombo = BG3Editor_Complex_Dyecolor1.ComboItem_Parent
                SelectedComboResult = BG3Editor_Complex_Dyecolor1.ComboItem_Parent.Itemresult
                SelectedColor = BG3Editor_Complex_Dyecolor1.Color_Preset
                BG3Editor_Complex_Dyecolor1.Drop_OBJ(obj)
                BG3Editor_Complex_Dyecolor1.Write(SelectedColor)
            Case BG3Cloner.Clonetype.Override
                If obj.NodeLSLIB.Attributes.ContainsKey("ColorPreset") Then Color_template_guid = obj.NodeLSLIB.TryGetOrEmpty("ColorPreset")
                BG3Editor_Complex_Dyecolor1.Drop_OBJ(obj)
                BG3Editor_Complex_Dyecolor1.CopyColors()
                BG3Editor_Complex_Dyecolor1.Create(Template_guid, Clone_Stat_Name, Color_template_guid, ActiveModSource)
                BG3Editor_Complex_Dyecolor1.PasteColors()
                SelectedCombo = BG3Editor_Complex_Dyecolor1.ComboItem_Parent
                SelectedComboResult = BG3Editor_Complex_Dyecolor1.ComboItem_Parent.Itemresult
                SelectedColor = BG3Editor_Complex_Dyecolor1.Color_Preset
                BG3Editor_Complex_Dyecolor1.Write(SelectedColor)
            Case Else
                Debugger.Break()
        End Select
    End Sub

    Protected Overrides Sub Select_Objects_Specifics()
        If Not IsNothing(SelectedTmp) Then
            Dim Color_template_guid As String = SelectedTmp.ReadAttribute_Or_Nothing("ColorPreset")
            If IsNothing(Color_template_guid) Then Color_template_guid = Funciones.NewGUID(False)
            BG3Editor_Complex_Dyecolor1.Change_selected(SelectedTmp.MapKey, SelectedStat.Name, Color_template_guid, ActiveModSource)
            SelectedColor = BG3Editor_Complex_Dyecolor1.Color_Preset
            SelectedCombo = BG3Editor_Complex_Dyecolor1.ComboItem_Parent
            SelectedComboResult = BG3Editor_Complex_Dyecolor1.ComboItem_Parent.Itemresult
        Else
            SelectedColor = Nothing
            SelectedCombo = Nothing
            SelectedComboResult = Nothing
        End If
    End Sub
    Protected Overrides Sub Process_Selection_Change_specific()
        If Not IsNothing(SelectedTmp) Then
            BG3Editor_Template_ColorPreset1.Read(SelectedTmp)
            BG3Editor_Stat_Special_UnlimitedDye1.Read(SelectedCombo)
            BG3Editor_Stat_Special_RemoverDye1.Read(SelectedCombo)
            BG3Editor_Complex_Dyecolor1.Read(SelectedColor)
        Else
            BG3Editor_Template_ColorPreset1.Clear()
            BG3Editor_Stat_Special_UnlimitedDye1.Clear()
            BG3Editor_Stat_Special_RemoverDye1.Clear()
            BG3Editor_Complex_Dyecolor1.Clear()
        End If
    End Sub
    Protected Overrides Sub Process_Cancel_Specifics()
        SelectedColor.Cancel_Edit()
        SelectedCombo.Cancel_Edit()
        SelectedComboResult.Cancel_Edit()
    End Sub
    Protected Overrides Sub Process_Delete_Specifics()
        FuncionesHelpers.GameEngine.Utamstats.Remove(SelectedCombo)
        FuncionesHelpers.GameEngine.ProcessedStatList.Remove(SelectedCombo)
        FuncionesHelpers.GameEngine.UtamVisuals.Remove(SelectedColor)
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.Remove(SelectedColor)
    End Sub
    Protected Overrides Sub Process_Edit_Specifics()
        SelectedColor.Edit_start()
        SelectedCombo.Edit_start()
        SelectedComboResult.Edit_start()
    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Template_ColorPreset1.Write(SelectedTmp)
        BG3Editor_Stat_Special_UnlimitedDye1.Write(SelectedCombo)
        BG3Editor_Stat_Special_RemoverDye1.Write(SelectedCombo, SelectedColor.MapKey)
        BG3Editor_Complex_Dyecolor1.Write(SelectedColor)
    End Sub
    Protected Overrides Sub Process_Save_Objetos_Specifics()
        SelectedColor.Write_Data()
        SelectedCombo.Write_Data()
        SelectedComboResult.Write_Data()
    End Sub
    Protected Overrides Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Lista.AddRange({
            New ToolStripMenuItem("Dye specific|Dye Remover|False|Custom", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"DyeRemover"}},
            New ToolStripMenuItem("Dye specific|Unlimited dye|False|Custom", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Unlimiteddye"}}
            })
#Enable Warning CA1861 ' Evitar matrices constantes como argumentos
    End Sub
    Protected Overrides Sub Transfer_SaveOriginal_Specific()
        Transfer_Combo = SelectedCombo
    End Sub

    Protected Transfer_Combo As BG3_Obj_Stats_Class
    Protected Overrides Sub Transfer_stats_specifics(Template As BG3_Obj_Template_Class, statsList() As String)
        For Each stat In statsList
            Select Case stat
                Case "Unlimiteddye"
                    BG3Editor_Stat_Special_UnlimitedDye1.Read(Transfer_Combo)
                    BG3Editor_Stat_Special_UnlimitedDye1.Write(SelectedCombo)
                Case "DyeRemover"
                    BG3Editor_Stat_Special_RemoverDye1.Read(Transfer_Combo)
                    BG3Editor_Stat_Special_RemoverDye1.Write(SelectedCombo, SelectedColor.MapKey)
            End Select
        Next
    End Sub

    ' Subs Especificos Dyes
    Private Sub AddHanlders_Dyes()
        Pictc = {BG3Editor_Template_DyeColorView1.PictureBox1, BG3Editor_Template_DyeColorView2.PictureBox1, BG3Editor_Template_DyeColorView3.PictureBox1, BG3Editor_Template_DyeColorView4.PictureBox1, BG3Editor_Template_DyeColorView5.PictureBox1, BG3Editor_Template_DyeColorView6.PictureBox1, BG3Editor_Template_DyeColorView7.PictureBox1, BG3Editor_Template_DyeColorView8.PictureBox1, BG3Editor_Template_DyeColorView9.PictureBox1, BG3Editor_Template_DyeColorView10.PictureBox1, BG3Editor_Template_DyeColorView11.PictureBox1, BG3Editor_Template_DyeColorView12.PictureBox1, BG3Editor_Template_DyeColorView13.PictureBox1, BG3Editor_Template_DyeColorView14.PictureBox1, BG3Editor_Template_DyeColorView15.PictureBox1}
        For x = 0 To FuncionesHelpers.ColorMaterialsNames.Count - 1
            Pictc(x).BackColor = Color.FromKnownColor(KnownColor.White)
            AddHandler BG3Editor_Complex_Dyecolor1.Pictures(x).BackColorChanged, AddressOf PictureBoxxx_BackColorChanged
        Next
    End Sub
    Private Sub Remover_Changed(sender As Object) Handles BG3Editor_Stat_Special_RemoverDye1.Inside_Text_Changed
        If Not IsNothing(Pictc) Then
            For index = 0 To Pictc.Length - 1
                If Not IsNothing(Pictc(index)) Then
                    If BG3Editor_Stat_Special_RemoverDye1.Text = "True" Then
                        Pictc(index).BackColor = Color.FromKnownColor(KnownColor.Transparent)
                    Else
                        Pictc(index).BackColor = BG3Editor_Complex_Dyecolor1.Pictures(index).BackColor
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub PictureBoxxx_BackColorChanged(sender As Object, e As EventArgs)
        Dim index As Integer = BG3Editor_Complex_Dyecolor1.Pictures.IndexOf(sender)
        If index <> -1 Then
            If BG3Editor_Stat_Special_RemoverDye1.Text = "True" Then
                Pictc(index).BackColor = Color.FromKnownColor(KnownColor.Transparent)
            Else
                Pictc(index).BackColor = BG3Editor_Complex_Dyecolor1.Pictures(index).BackColor
            End If
        End If
    End Sub

End Class
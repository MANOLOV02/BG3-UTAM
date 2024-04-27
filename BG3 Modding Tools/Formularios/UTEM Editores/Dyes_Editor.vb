Imports System.Collections.Concurrent
Imports System.DirectoryServices
Imports System.Runtime.InteropServices.Marshalling
Imports System.Windows.Forms.VisualStyles
Imports System.Xml
Imports Accessibility
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class Dyes_Editor
    Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private ModSource As BG3_Pak_SourceOfResource_Class
    Private SelectedTmp As BG3_Obj_Template_Class
    Private SelectedStat As BG3_Obj_Stats_Class
    Private SelectedColor As BG3_Obj_VisualBank_Class
    Private SelectedCombo As BG3_Obj_Stats_Class
    Private SelectedComboResult As BG3_Obj_Stats_Class
    Private ReadOnly Pictc() As PictureBox

    Public Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
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
        Pictc =
        {BG3Editor_Template_DyeColorView1.PictureBox1,
            BG3Editor_Template_DyeColorView2.PictureBox1,
            BG3Editor_Template_DyeColorView3.PictureBox1,
            BG3Editor_Template_DyeColorView4.PictureBox1,
            BG3Editor_Template_DyeColorView5.PictureBox1,
            BG3Editor_Template_DyeColorView6.PictureBox1,
            BG3Editor_Template_DyeColorView7.PictureBox1,
            BG3Editor_Template_DyeColorView8.PictureBox1,
            BG3Editor_Template_DyeColorView9.PictureBox1,
            BG3Editor_Template_DyeColorView10.PictureBox1,
            BG3Editor_Template_DyeColorView11.PictureBox1,
            BG3Editor_Template_DyeColorView12.PictureBox1,
            BG3Editor_Template_DyeColorView13.PictureBox1,
            BG3Editor_Template_DyeColorView14.PictureBox1,
            BG3Editor_Template_DyeColorView15.PictureBox1}
        ModSource = Source
        Habilita_Edicion_Botones(False)
        PictureBox3.AllowDrop = True
        For x = 0 To FuncionesHelpers.ColorMaterialsNames.Count - 1
            Pictc(x).BackColor = Color.FromKnownColor(KnownColor.White)
            AddHandler BG3Editor_Complex_Dyecolor1.Pictures(x).BackColorChanged, AddressOf PictureBoxxx_BackColorChanged
        Next
        BG3Editor_Complex_Localization1.Link_Controls({BG3Editor_Template_DisplayName1, BG3Editor_Template_Description1, BG3Editor_Template_TechnicalDescription1}, ModSource)
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BG3Selector_Template1.Load_Templates()
    End Sub
    Private Sub Remover_Changed(sender As Object) Handles BG3Editor_Stat_Special_RemoverDye1.Inside_Text_Changed
        For index = 0 To Pictc.Length - 1
            If Not IsNothing(Pictc(index)) Then
                If BG3Editor_Stat_Special_RemoverDye1.Text = "True" Then
                    Pictc(index).BackColor = Color.FromKnownColor(KnownColor.Transparent)
                Else
                    Pictc(index).BackColor = BG3Editor_Complex_Dyecolor1.Pictures(index).BackColor
                End If
            End If
        Next
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

    Private isnew As Boolean = False

    Private Function AddNew_DyeTemplate(Group As String) As BG3_Obj_Template_Class
        Dim Template_guid As String = Funciones.NewGUID(False)
        Dim Color_template_guid As String = Funciones.NewGUID(False)
        Dim Stat_Name As String = "UTAM_Dye_OBJ_" + Template_guid
        Dim nuevonod As New LSLib.LS.Node
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonod, "UTAM_Type", BG3_Enum_UTAM_Type.Dyes.ToString, AttributeType.FixedString)
        Editor_Generic_GenericAttribute.Create_Attribute_Generic(nuevonod, "UTAM_Group", Group, AttributeType.FixedString)
        BG3Editor_Template_Mapkey1.Create_Attribute(nuevonod, Template_guid)
        BG3Editor_Template_Name1.Create_Attribute(nuevonod, "UTAM_Dye_" + Template_guid)
        BG3Editor_Template_Type1.Create_Attribute(nuevonod, "item")
        BG3Editor_Template_Parent1.Create_Attribute(nuevonod, "1a750a66-e5c2-40be-9f62-0a4bf3ddb403")
        BG3Editor_Template_Stats1.Create_Attribute(nuevonod, Stat_Name)
        BG3Editor_Template_DisplayName1.Create_Attribute(nuevonod, Funciones.NewGUID(True))
        BG3Editor_Template_Description1.Create_Attribute(nuevonod, Funciones.NewGUID(True))
        BG3Editor_Template_TechnicalDescription1.Create_Attribute(nuevonod, Funciones.NewGUID(True))
        BG3Editor_Template_ColorPreset1.Create_Attribute(nuevonod, Color_template_guid)
        Dim nuevo As New BG3_Obj_Template_Class(nuevonod, ModSource)
        SelectedTmp = FuncionesHelpers.GameEngine.ProcessedGameObjectList.Manage_Overrides(nuevo)

        Dim nuevoStat As New BG3_Obj_Stats_Class(ModSource, Stat_Name) With {.Using = "_Dyes"}
        nuevoStat = FuncionesHelpers.GameEngine.ProcessedStatList.Manage_Overrides(nuevoStat)
        BG3Editor_Stat_Type1.Create("Object", nuevoStat)
        Editor_Stats_Generic.Create_Generic("RootTemplate", Template_guid, nuevoStat)
        SelectedStat = nuevoStat

        BG3Editor_Complex_Dyecolor1.Create(Template_guid, Stat_Name, Color_template_guid, ModSource)
        SelectedCombo = BG3Editor_Complex_Dyecolor1.ComboItem_Parent
        SelectedComboResult = BG3Editor_Complex_Dyecolor1.ComboItem_Child
        SelectedColor = BG3Editor_Complex_Dyecolor1.Color_Preset

        Return SelectedTmp
    End Function

    Private Sub Habilita_Edicion_Botones(Edicion As Boolean)
        GroupBox1.Enabled = Edicion
        GroupBox2.Enabled = Edicion
        GroupBox4.Enabled = Edicion
        GroupBox5.Enabled = Edicion
        BG3Editor_Complex_Localization1.DataGridView1.Enabled = Edicion
        BG3Editor_Complex_WorldInjection1.Enabled = Edicion
        BG3Editor_Complex_Dyecolor1.Enabled = Edicion
        Process_Selection_Change()
    End Sub
    Private Sub PictureBox3_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox3.DragEnter
        If GroupBox2.Enabled = True Then BG3Editor_Template_Icon1.Control_DragEnter(sender, e)
    End Sub
    Private Sub PictureBox3_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox3.DragDrop
        If GroupBox2.Enabled = True Then BG3Editor_Template_Icon1.Control_DragDrop(sender, e)
    End Sub
    Private Sub Capture_Icon_Changed(sender As Object) Handles BG3Editor_Template_Icon1.Inside_Text_Changed
        Dim ic As BG3_Obj_IconUV_Class = Nothing
        PictureBox3.Image = Nothing
        If FuncionesHelpers.GameEngine.ProcessedIcons.TryGetValue(BG3Editor_Template_Icon1.TextBox1.Text, ic) Then
            PictureBox3.Image = ic.Get_Icon_FromAtlass_or_File
        End If
    End Sub

    Private Sub Capture_Names_Changed(sender As Object) Handles BG3Editor_Template_DisplayName1.Inside_Text_Changed, BG3Editor_Template_Description1.Inside_Text_Changed, BG3Editor_Template_TechnicalDescription1.Inside_Text_Changed
        If Not IsNothing(SelectedTmp) Then
            LabelInfoName.Text = "Name:  " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_Template_DisplayName1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
            LabelInfoDescription.Text = "Description: " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_Template_Description1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
            LabelTechnical.Text = "Technical: " + BG3Editor_Complex_Localization1.Get_Localization(BG3Editor_Template_TechnicalDescription1, SelectedTmp, FuncionesHelpers.GameEngine.Settings.SelectedLocalization)
        End If
    End Sub
    Private Sub Capturle_Localization_Changed(Makpek As String, sender As Object) Handles BG3Editor_Complex_Localization1.Cell_EndEdit
        Capture_Names_Changed(sender)
    End Sub

    Private Sub Capture_AddNew(Group As String) Handles BG3Selector_Template1.Add_New_Click
        isnew = True
        Dim nuevo As BG3_Obj_Template_Class = AddNew_DyeTemplate(Group)
        BG3Selector_Template1.Add_Item(nuevo)
        Habilita_Edicion_Botones(True)
    End Sub
    Private Sub Capture_Edit(template As BG3_Obj_Template_Class) Handles BG3Selector_Template1.Edit_Click
        If IsNothing(template) Then Exit Sub
        isnew = False
        Process_Edit()
    End Sub
    Private Sub Capture_Cancel() Handles BG3Selector_Template1.Cancel_Click
        Process_Cancel()
    End Sub
    Private Sub Capture_Save() Handles BG3Selector_Template1.Save_Click
        CType(Me.MdiParent, Main).ChangedMod()
        Process_Save()
    End Sub
    Private Sub Process_Edit()
        SelectedTmp.Edit_start()
        SelectedColor.Edit_start()
        SelectedStat.Edit_start()
        SelectedCombo.Edit_start()
        SelectedComboResult.Edit_start()
        Habilita_Edicion_Botones(True)
    End Sub
    Private Sub Capture_Selection_Change(Template As BG3_Obj_Template_Class) Handles BG3Selector_Template1.Change_Selected
        If Not IsNothing(Template) AndAlso FuncionesHelpers.GameEngine.ProcessedStatList.Elements.TryGetValue(Template.Stats, SelectedStat) Then
            SelectedTmp = Template
            Dim Color_template_guid As String = SelectedTmp.ReadAttribute_Or_Nothing("ColorPreset")
            If IsNothing(Color_template_guid) Then
                Color_template_guid = Funciones.NewGUID(False)
            End If
            BG3Editor_Complex_Dyecolor1.Change_selected(SelectedTmp.MapKey, SelectedStat.Name, Color_template_guid, ModSource)
            SelectedColor = BG3Editor_Complex_Dyecolor1.Color_Preset
            SelectedCombo = BG3Editor_Complex_Dyecolor1.ComboItem_Parent
            SelectedComboResult = BG3Editor_Complex_Dyecolor1.ComboItem_Child
        Else
            SelectedTmp = Nothing
            SelectedStat = Nothing
            SelectedColor = Nothing
            SelectedCombo = Nothing
            SelectedComboResult = Nothing
        End If
        Process_Selection_Change()
    End Sub
    Private Sub Process_Selection_Change()
        If Not IsNothing(SelectedTmp) Then
            BG3Editor_Template_Mapkey1.Read(SelectedTmp)
            BG3Editor_Template_Name1.Read(SelectedTmp)
            BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Read(SelectedTmp)
            BG3Editor_Template_Parent1.Read(SelectedTmp)
            BG3Editor_Template_Type1.Read(SelectedTmp)
            BG3Editor_Template_VisualTemplate1.Read(SelectedTmp)
            BG3Editor_Template_Icon1.Read(SelectedTmp)
            BG3Editor_Template_ColorPreset1.Read(SelectedTmp)
            BG3Editor_Template_DisplayName1.Read(SelectedTmp)
            BG3Editor_Template_Description1.Read(SelectedTmp)
            BG3Editor_Template_TechnicalDescription1.Read(SelectedTmp)
            BG3Editor_Template_Stats1.Read(SelectedTmp)
            BG3Editor_Stat_Type1.Read(SelectedStat)
            BG3Editor_Stat_Rarity1.Read(SelectedStat)
            BG3Editor_Stat_Weight1.Read(SelectedStat)
            BG3Editor_Stat_ValueOverride1.Read(SelectedStat)
            BG3Editor_Stat_Using1.Read(SelectedStat)
            BG3Editor_Stat_Special_UnlimitedDye1.Read(SelectedCombo)
            BG3Editor_Stat_Special_RemoverDye1.Read(SelectedCombo)
            BG3Editor_Complex_Dyecolor1.Read(SelectedColor)
            BG3Editor_Complex_Localization1.Read_Data(SelectedTmp)
            BG3Editor_Complex_WorldInjection1.Read_Data(SelectedStat, ModSource)
        Else
            BG3Editor_Template_Mapkey1.Clear()
            BG3Editor_Template_Name1.Clear()
            BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Clear()
            BG3Editor_Template_Parent1.Clear()
            BG3Editor_Template_Type1.Clear()
            BG3Editor_Template_VisualTemplate1.Clear()
            BG3Editor_Template_Icon1.Clear()
            BG3Editor_Template_ColorPreset1.Clear()
            BG3Editor_Template_DisplayName1.Clear()
            BG3Editor_Template_Description1.Clear()
            BG3Editor_Template_TechnicalDescription1.Clear()
            BG3Editor_Template_Stats1.Clear()
            BG3Editor_Stat_Type1.Clear()
            BG3Editor_Stat_Rarity1.Clear()
            BG3Editor_Stat_Weight1.Clear()
            BG3Editor_Stat_ValueOverride1.Clear()
            BG3Editor_Stat_Using1.Clear()
            BG3Editor_Stat_Special_UnlimitedDye1.Clear()
            BG3Editor_Stat_Special_RemoverDye1.Clear()
            BG3Editor_Complex_Dyecolor1.Clear()
            BG3Editor_Complex_Localization1.clear
            BG3Editor_Complex_WorldInjection1.Clear()
        End If
    End Sub
    Private Sub Process_Cancel()
        SelectedTmp.Cancel_Edit()
        SelectedColor.Cancel_Edit()
        SelectedStat.Cancel_Edit()
        SelectedCombo.Cancel_Edit()
        SelectedComboResult.Cancel_Edit()
        Habilita_Edicion_Botones(False)
        BG3Selector_Template1.Edit_Ended(SelectedTmp)
    End Sub
    Private Sub Process_Save()
        BG3Editor_Template_Mapkey1.Write(SelectedTmp)
        If BG3Editor_Template_Name1.Text <> "" Then BG3Editor_Template_Name1.Write(SelectedTmp)
        BG3Selector_Template1.BG3Editor_Template_UtamGroup1.Write(SelectedTmp)
        BG3Editor_Template_Parent1.Write(SelectedTmp)
        BG3Editor_Template_Type1.Write(SelectedTmp)
        BG3Editor_Template_VisualTemplate1.Write(SelectedTmp)
        BG3Editor_Template_Icon1.Write(SelectedTmp)
        BG3Editor_Template_ColorPreset1.Write(SelectedTmp)
        BG3Editor_Template_DisplayName1.Write(SelectedTmp)
        BG3Editor_Template_Description1.Write(SelectedTmp)
        BG3Editor_Template_TechnicalDescription1.Write(SelectedTmp)
        BG3Editor_Template_Stats1.Write(SelectedTmp)
        BG3Editor_Stat_Type1.Write(SelectedStat)
        BG3Editor_Stat_Rarity1.Write(SelectedStat)
        BG3Editor_Stat_Unique1.Write(SelectedStat)
        BG3Editor_Stat_Weight1.Write(SelectedStat)
        BG3Editor_Stat_ValueOverride1.Write(SelectedStat)
        BG3Editor_Stat_Using1.Write(SelectedStat)
        BG3Editor_Stat_Special_UnlimitedDye1.Write(SelectedCombo)
        BG3Editor_Stat_Special_RemoverDye1.Write(SelectedCombo, SelectedColor.MapKey)
        BG3Editor_Complex_Dyecolor1.Write(SelectedColor)
        SelectedTmp.Write_Data()
        SelectedColor.Write_Data()
        SelectedStat.Write_Data()
        SelectedCombo.Write_Data()
        SelectedComboResult.Write_Data()
        BG3Editor_Complex_Localization1.Write_Data()
        BG3Editor_Complex_WorldInjection1.Write_Data()
        Habilita_Edicion_Botones(False)
        BG3Selector_Template1.Edit_Ended(SelectedTmp)
    End Sub



End Class
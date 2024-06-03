Imports System.IO
Imports LSLib.LS

Public Class MaterialBank_Editor
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        TabControl1.TabPages.Remove(TabPageDyes)
        TabControl1.TabPages.Insert(1, TabPageDyes)
    End Sub
    Protected Overrides Property Visualtype As BG3_Enum_VisualBank_Type = BG3_Enum_VisualBank_Type.MaterialBank
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.MaterialBank

    Protected Overrides Sub Initialize_Specifics()
        HandledAttributes.Add("ID")
        HandledAttributes.Add("Name")
        HandledAttributes.Add("SourceFile")
        HandledAttributes.Add("DiffusionProfileUUID")
        HandledAttributes.Add("MaterialType")
        'HandledAttributes.Add("SRGB")
        'HandledAttributes.Add("Type")
        'HandledAttributes.Add("Format")
        'HandledAttributes.Add("Localized")
        'HandledAttributes.Add("Depth")
        'HandledAttributes.Add("Template")
        HandledNodes.Add("Resource\VirtualTextureParameters;ParameterName=virtualtexture")
        HandledNodes.Add("Resource\Texture2DParameters;ParameterName=MSKColor")
        HandledNodes.Add("Resource\Texture2DParameters;ParameterName=MSKcloth")
        HandledNodes.Add("Resource\Texture2DParameters;ParameterName=VertexColor_MSK")
        HandledNodes.Add("Resource\Texture2DParameters;ParameterName=normalmap")
        HandledNodes.Add("Resource\Texture2DParameters;ParameterName=physicalmap")
        HandledNodes.Add("Resource\Texture2DParameters;ParameterName=basecolor")
        For Each col In FuncionesHelpers.ColorMaterialsNames
            HandledNodes.Add("Resource\Vector3Parameters;ParameterName=" + col)
        Next
    End Sub

    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As Node)
        BG3Editor_Textures_iD_Fixed1.Create_Attribute(nuevonod, Template_guid)
        BG3Editor_Textures_Name1.Create_Attribute(nuevonod, "New_Material")
        BG3Editor_Textures_SourceFile1.Create_Attribute(nuevonod, "Public/Shared/Assets/Materials/Characters/CHAR_BASE.lsf")
        BG3Editor_Visuals_MaterialType1.Create_Attribute(nuevonod, "0")
    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        GroupboxAsset.Enabled = Edicion
        GroupBoxTexture.Enabled = Edicion
        GroupBoxVT.Enabled = Edicion
        GroupBoxTextures2d.Enabled = Edicion
        GroupBoxMsk.Enabled = Edicion
        BG3Editor_Complex_Dyecolor1.Enabled = Edicion
    End Sub
    Protected Overrides Sub Process_Selection_Change_specific()
        If Not IsNothing(SelectedTmp) Then
            BG3Editor_Complex_Dyecolor1.Read(SelectedTmp)
            BG3Editor_Textures_iD_Fixed1.Read(SelectedTmp)
            BG3Editor_Textures_Name1.Read(SelectedTmp)
            BG3Editor_Textures_SourceFile1.Read(SelectedTmp)
            BG3Editor_Visuals_MaterialType1.Read(SelectedTmp)
            BG3Editor_Visuals_DiffusionProfileuuid1.Read(SelectedTmp)
            BG3Editor_Visuals_VirtualTexture1.Read(SelectedTmp)
            BG3Editor_Visuals_BasecolorMap1.Read(SelectedTmp)
            BG3Editor_Visuals_NormalMap1.Read(SelectedTmp)
            BG3Editor_Visuals_MaskTexture1.Read(SelectedTmp)
            BG3Editor_Visuals_PhisicalMap1.Read(SelectedTmp)
            BG3Editor_Visuals_VertexColor_msk1.Read(SelectedTmp)
            BG3Editor_Visuals_msKcloth1.Read(SelectedTmp)
        Else
            BG3Editor_Complex_Dyecolor1.Clear()
            BG3Editor_Textures_iD_Fixed1.Clear()
            BG3Editor_Textures_Name1.Clear()
            BG3Editor_Textures_SourceFile1.Clear()
            BG3Editor_Visuals_MaterialType1.Clear()
            BG3Editor_Visuals_DiffusionProfileuuid1.Clear()
            BG3Editor_Visuals_VirtualTexture1.Clear()
            BG3Editor_Visuals_BasecolorMap1.Clear()
            BG3Editor_Visuals_NormalMap1.Clear()
            BG3Editor_Visuals_MaskTexture1.Clear()
            BG3Editor_Visuals_PhisicalMap1.Clear()
            BG3Editor_Visuals_VertexColor_msk1.Clear()
            BG3Editor_Visuals_msKcloth1.Clear()
        End If
    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Complex_Dyecolor1.Write(SelectedTmp)
        BG3Editor_Textures_iD_Fixed1.Write(SelectedTmp)
        BG3Editor_Textures_Name1.Write(SelectedTmp)
        BG3Editor_Textures_SourceFile1.Write(SelectedTmp)
        BG3Editor_Visuals_MaterialType1.Write(SelectedTmp)
        BG3Editor_Visuals_DiffusionProfileuuid1.Write(SelectedTmp)
        BG3Editor_Visuals_VirtualTexture1.Write(SelectedTmp)
        BG3Editor_Visuals_BasecolorMap1.Write(SelectedTmp)
        BG3Editor_Visuals_NormalMap1.Write(SelectedTmp)
        BG3Editor_Visuals_MaskTexture1.Write(SelectedTmp)
        BG3Editor_Visuals_PhisicalMap1.Write(SelectedTmp)
        BG3Editor_Visuals_VertexColor_msk1.Write(SelectedTmp)
        BG3Editor_Visuals_msKcloth1.Write(SelectedTmp)
    End Sub
    Protected Overrides Sub Capture_Clone_specific(obj As BG3_Obj_VisualBank_Class, tipo As BG3Cloner.Clonetype)
        Select Case tipo
            Case BG3Cloner.Clonetype.Clone
                BG3Editor_Textures_iD_Fixed1.Replace_Attribute(Clone_Nuevonod, Template_guid)
                BG3Editor_Textures_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Cloned")
            Case BG3Cloner.Clonetype.Override
                BG3Editor_Textures_iD_Fixed1.Replace_Attribute(Clone_Nuevonod, obj.MapKey)
                BG3Editor_Textures_Name1.Replace_Attribute(Clone_Nuevonod, obj.Name + "_Overrided")
        End Select

    End Sub

    Private Sub Capture_VT_Change(sender As Object) Handles BG3Editor_Visuals_VertexColor_msk1.Inside_Text_Changed, BG3Editor_Visuals_msKcloth1.Inside_Text_Changed, BG3Editor_Visuals_VirtualTexture1.Inside_Text_Changed, BG3Editor_Visuals_PhisicalMap1.Inside_Text_Changed, BG3Editor_Visuals_NormalMap1.Inside_Text_Changed, BG3Editor_Visuals_BasecolorMap1.Inside_Text_Changed, BG3Editor_Visuals_MaskTexture1.Inside_Text_Changed
        Dim st As BG3_Obj_VisualBank_Class = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_VirtualTexture1.TextBox1.Text, st)
        If IsNothing(st) Then LabelVT.Text = "(None)" Else LabelVT.Text = "(" + st.Name + ")"
        st = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_PhisicalMap1.TextBox1.Text, st)
        If IsNothing(st) Then LabelPM.Text = "(None)" Else LabelPM.Text = "(" + st.Name + ")"
        st = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_NormalMap1.TextBox1.Text, st)
        If IsNothing(st) Then LabelNM.Text = "(None)" Else LabelNM.Text = "(" + st.Name + ")"
        st = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_BasecolorMap1.TextBox1.Text, st)
        If IsNothing(st) Then LabelBM.Text = "(None)" Else LabelBM.Text = "(" + st.Name + ")"
        st = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_MaskTexture1.TextBox1.Text, st)
        If IsNothing(st) Then LabelColorMSK.Text = "(None)" Else LabelColorMSK.Text = "(" + st.Name + ")"
        st = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_msKcloth1.TextBox1.Text, st)
        If IsNothing(st) Then LabelMskclt.Text = "(None)" Else LabelMskclt.Text = "(" + st.Name + ")"
        st = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_VertexColor_msk1.TextBox1.Text, st)
        If IsNothing(st) Then LabelVertexMSK.Text = "(None)" Else LabelVertexMSK.Text = "(" + st.Name + ")"
    End Sub

    Private Sub ButtonVT_Click(sender As Object, e As EventArgs) Handles ButtonVT.Click
        BG3Editor_Visuals_VirtualTexture1.TextBox1.Text = ""
    End Sub

    Private Sub ButtonBM_Click(sender As Object, e As EventArgs) Handles ButtonBM.Click
        BG3Editor_Visuals_BasecolorMap1.TextBox1.Text = ""
    End Sub

    Private Sub ButtonNM_Click(sender As Object, e As EventArgs) Handles ButtonNM.Click
        BG3Editor_Visuals_NormalMap1.TextBox1.Text = ""
    End Sub

    Private Sub ButtonPM_Click(sender As Object, e As EventArgs) Handles ButtonPM.Click
        BG3Editor_Visuals_PhisicalMap1.TextBox1.Text = ""
    End Sub

    Private Sub ButtonMSK_Click(sender As Object, e As EventArgs) Handles ButtonMSK.Click
        BG3Editor_Visuals_MaskTexture1.TextBox1.Text = ""
    End Sub

    Private Sub ButtonMSKClt_Click(sender As Object, e As EventArgs) Handles ButtonMSKClt.Click
        BG3Editor_Visuals_msKcloth1.TextBox1.Text = ""
    End Sub

    Private Sub ButtonVertexMsk_Click(sender As Object, e As EventArgs) Handles ButtonVertexMsk.Click
        BG3Editor_Visuals_VertexColor_msk1.TextBox1.Text = ""
    End Sub
End Class
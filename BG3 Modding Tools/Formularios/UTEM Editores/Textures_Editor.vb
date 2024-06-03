Imports System.IO
Imports LSLib.LS

Public Class Textures_Editor
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
    End Sub
    Protected Overrides Sub Initialize_Specifics()
        HandledAttributes.Add("ID")
        HandledAttributes.Add("Height")
        HandledAttributes.Add("Width")
        HandledAttributes.Add("SourceFile")
        HandledAttributes.Add("SRGB")
        HandledAttributes.Add("Type")
        HandledAttributes.Add("Format")
        HandledAttributes.Add("Localized")
        HandledAttributes.Add("Depth")
        HandledAttributes.Add("Name")
        HandledAttributes.Add("Template")
    End Sub

    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As Node)
        BG3Editor_Textures_iD_Fixed1.Create_Attribute(nuevonod, Template_guid)
        BG3Editor_Textures_Name1.Create_Attribute(nuevonod, "New_Texture")
        BG3Editor_Textures_Template1.Create_Attribute(nuevonod, "New_Texture")
        BG3Editor_Texture_Depth1.Create_Attribute(nuevonod, "1")
        BG3Editor_Texture_Height1.Create_Attribute(nuevonod, "16")
        BG3Editor_Texture_Width1.Create_Attribute(nuevonod, "16")
        BG3Editor_Visuals_srgb1.Create_Attribute(nuevonod, "False")
        'BG3Editor_Visuals_Localized1.Create_Attribute(nuevonod, "False")
        BG3Editor_Texture_Type1.Create_Attribute(nuevonod, "1")
        BG3Editor_Textures_SourceFile1.Create_Attribute(nuevonod, "")
        'BG3Editor_Texture_Format1.Create_Attribute(nuevonod,"64")
    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        GroupboxAsset.Enabled = Edicion
        GroupBoxTexture.Enabled = Edicion
    End Sub
    Protected Overrides Sub Process_Selection_Change_specific()
        If Not IsNothing(SelectedTmp) Then
            BG3Editor_Textures_iD_Fixed1.Read(SelectedTmp)
            BG3Editor_Textures_Name1.Read(SelectedTmp)
            BG3Editor_Textures_Template1.Read(SelectedTmp)
            BG3Editor_Texture_Depth1.Read(SelectedTmp)
            BG3Editor_Texture_Height1.Read(SelectedTmp)
            BG3Editor_Texture_Width1.Read(SelectedTmp)
            BG3Editor_Visuals_srgb1.Read(SelectedTmp)
            BG3Editor_Visuals_Localized1.Read(SelectedTmp)
            BG3Editor_Texture_Type1.Read(SelectedTmp)
            BG3Editor_Textures_SourceFile1.Read(SelectedTmp)
            BG3Editor_Texture_Format1.Read(SelectedTmp)

        Else
            BG3Editor_Textures_iD_Fixed1.Clear()
            BG3Editor_Textures_Name1.Clear()
            BG3Editor_Textures_Template1.Clear()
            BG3Editor_Texture_Depth1.Clear()
            BG3Editor_Texture_Height1.Clear()
            BG3Editor_Texture_Width1.Clear()
            BG3Editor_Visuals_srgb1.Clear()
            BG3Editor_Visuals_Localized1.Clear()
            BG3Editor_Texture_Type1.Clear()
            BG3Editor_Textures_SourceFile1.Clear()
            BG3Editor_Texture_Format1.Clear()
            PictureBox1.Image = Nothing
        End If
    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Textures_iD_Fixed1.Write(SelectedTmp)
        BG3Editor_Textures_Name1.Write(SelectedTmp)
        BG3Editor_Textures_Template1.Write(SelectedTmp)
        BG3Editor_Texture_Depth1.Write(SelectedTmp)
        BG3Editor_Texture_Height1.Write(SelectedTmp)
        BG3Editor_Texture_Width1.Write(SelectedTmp)
        BG3Editor_Visuals_srgb1.Write(SelectedTmp)
        BG3Editor_Visuals_Localized1.Write(SelectedTmp)
        BG3Editor_Texture_Type1.Write(SelectedTmp)
        BG3Editor_Textures_SourceFile1.Write(SelectedTmp)
        BG3Editor_Texture_Format1.Write(SelectedTmp)
    End Sub

    Private Sub ButtonAsset_Click(sender As Object, e As EventArgs) Handles ButtonAsset.Click
        Dim xx As New OpenFileDialog With {.Filter = "dds files|*.dds", .InitialDirectory = CType(MdiParent, Main).ActiveMod.CurrentMod.AssetsPath}
        If xx.ShowDialog = DialogResult.OK Then
            Dim path = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CType(MdiParent, Main).ActiveMod.CurrentMod.SaveFolder)
            Dim ass = FuncionesHelpers.GameEngine.ProcessedAssets.Manage_Overrides(New BG3_Obj_Assets_Class(New BG3_Pak_SourceOfResource_Class(path, xx.FileName, BG3_Enum_Package_Type.UTAM_Mod)))
            BG3Editor_Textures_SourceFile1.TextBox1.Text = IO.Path.GetRelativePath(path, xx.FileName).Replace("\", "/")
            If Not IsNothing(PictureBox1.Image) Then
                BG3Editor_Texture_Width1.TextBox1.Text = PictureBox1.Image.Width
                BG3Editor_Texture_Height1.TextBox1.Text = PictureBox1.Image.Height
            End If
        End If
    End Sub

    Private Sub Capture_Texture_changed(sender As Object) Handles BG3Editor_Textures_SourceFile1.Inside_Text_Changed
        Dim stream = BG3_Pak_Packages_List_Class.Find_Asset("", BG3Editor_Textures_SourceFile1.TextBox1.Text)
        If Not IsNothing(stream) Then
            Try
                PictureBox1.Image = Funciones.PfmiToBitmap(stream.SourceOfResorce.CreateContentReader).Clone()
                stream.SourceOfResorce.ReleaseMem()
                Label1.Text = "Asset witdth: " + PictureBox1.Image.Width.ToString
                Label2.Text = "Asset height: " + PictureBox1.Image.Height.ToString
            Catch ex As Exception
                PictureBox1.Image = Nothing
            End Try
        Else
            PictureBox1.Image = Nothing
            Label1.Text = "Asset witdth: None"
            Label2.Text = "Asset height: None"
        End If
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
End Class
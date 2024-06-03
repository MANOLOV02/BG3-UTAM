Imports System.IO
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LSLib.LS

Public Class VisualBank_Editor
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
    Protected Overrides Property Visualtype As BG3_Enum_VisualBank_Type = BG3_Enum_VisualBank_Type.VisualBank
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.VisualBank

    Protected Overrides Sub Initialize_Specifics()
        HandledAttributes.Add("ID")
        HandledAttributes.Add("Name")
        HandledAttributes.Add("SourceFile")
        HandledAttributes.Add("MaterialType")
        HandledAttributes.Add("Template")
        HandledAttributes.Add("Slot")
        HandledAttributes.Add("SupportsVertexColorMask")

        HandledNodes.Add("Resource\VertexColorMaskSlots")
        HandledNodes.Add("Resource\Objects")
    End Sub

    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As Node)
        BG3Editor_Textures_iD_Fixed1.Create_Attribute(nuevonod, Template_guid)
        BG3Editor_Textures_Name1.Create_Attribute(nuevonod, "New_Material")
        BG3Editor_VisualBank_SourceFile1.Create_Attribute(nuevonod, "Generated/Public/Shared/Assets/Characters/_Models/Humans/_Female/Resources/HUM_F_NKD_Body_A.GR2")
        BG3Editor_Visuals_TemplategR21.Create_Attribute(nuevonod, "Generated/Public/Shared/Assets/Characters/_Models/Humans/_Female/Resources/HUM_F_NKD_Body_A.Dummy_Root.0")
        BG3Editor_Visuals_MaterialType1.Create_Attribute(nuevonod, "0")
    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        GroupboxAsset.Enabled = Edicion
        GroupBoxTexture.Enabled = Edicion
        GroupBoxObjects.Enabled = Edicion
        GroupBoxVertex.Enabled = Edicion
    End Sub
    Protected Overrides Sub Process_Selection_Change_specific()
        If Not IsNothing(SelectedTmp) Then
            BG3Editor_Textures_iD_Fixed1.Read(SelectedTmp)
            BG3Editor_Textures_Name1.Read(SelectedTmp)
            BG3Editor_VisualBank_SourceFile1.Read(SelectedTmp)
            BG3Editor_Visuals_MaterialType1.Read(SelectedTmp)
            BG3Editor_Visuals_TemplategR21.Read(SelectedTmp)
            BG3Editor_Visuals_Slot1.Read(SelectedTmp)
            BG3Editor_Visuals_SupportsVertexColorMask1.Read(SelectedTmp)
        Else
            BG3Editor_Textures_iD_Fixed1.Clear()
            BG3Editor_Textures_Name1.Clear()
            BG3Editor_VisualBank_SourceFile1.Clear()
            BG3Editor_Visuals_MaterialType1.Clear()
            BG3Editor_Visuals_TemplategR21.Clear()
            BG3Editor_Visuals_Slot1.Clear()
            BG3Editor_Visuals_SupportsVertexColorMask1.Clear()
        End If
        Read_Listboxes()

    End Sub
    Private Sub Read_Listboxes()
        Dim idx1 = Math.Max(ListBoxVertex.SelectedIndex, 0)
        Dim idx2 = Math.Max(ListBoxObjects.SelectedIndex, 0)
        ListBoxObjects.Items.Clear()
        ListBoxVertex.Items.Clear()
        ButtonDeleteObject.Enabled = False
        ButtonDeleteMaskSlot.Enabled = False
        BG3Editor_Visuals_lod1.Clear()
        BG3Editor_Visuals_Materialid1.Clear()
        BG3Editor_Visuals_oBjectid1.Clear()
        If Not IsNothing(SelectedTmp) Then
            Dim value As LSLib.LS.Node
            Dim values As List(Of LSLib.LS.Node) = Nothing
            If SelectedTmp.NodeLSLIB.Children.TryGetValue("Objects", values) Then
                For Each value In values
                    Dim value2 As NodeAttribute = Nothing
                    If value.Attributes.TryGetValue("LOD", value2) Then
                        Dim cust As New BG3_Custom_ComboboxItem With {.Text = "Object (LOD:" + value2.AsString(Funciones.Guid_to_string) + ")", .Value = value}
                        ListBoxObjects.Items.Add(cust)
                    End If
                Next
            End If

            Dim values2 As List(Of LSLib.LS.Node) = Nothing

            If SelectedTmp.NodeLSLIB.Children.TryGetValue("VertexColorMaskSlots", values2) Then
                For Each value In values2
                    Dim value2 As NodeAttribute = Nothing
                    If value.Attributes.TryGetValue("Object", value2) Then
                        ListBoxVertex.Items.Add(value2.AsString(Funciones.Guid_to_string))
                    End If
                Next
            End If
        End If
        If idx1 <= ListBoxVertex.Items.Count - 1 Then ListBoxVertex.SelectedIndex = idx1 Else If ListBoxVertex.Items.Count > 0 Then ListBoxVertex.SelectedIndex = 0
        If idx2 <= ListBoxObjects.Items.Count - 1 Then ListBoxObjects.SelectedIndex = idx2 Else If ListBoxObjects.Items.Count > 0 Then ListBoxObjects.SelectedIndex = 0
    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Textures_iD_Fixed1.Write(SelectedTmp)
        BG3Editor_Textures_Name1.Write(SelectedTmp)
        BG3Editor_VisualBank_SourceFile1.Write(SelectedTmp)
        BG3Editor_Visuals_MaterialType1.Write(SelectedTmp)
        BG3Editor_Visuals_TemplategR21.Write(SelectedTmp)
        BG3Editor_Visuals_Slot1.Write(SelectedTmp)
        BG3Editor_Visuals_SupportsVertexColorMask1.Write(SelectedTmp)
        Save_listboxes()
    End Sub
    Private Function Create_Node_Object() As LSLib.LS.Node
        Dim value As LSLib.LS.Node
        value = New LSLib.LS.Node With {.Name = "Objects", .KeyAttribute = "Objects"}
        value.Attributes.TryAdd("LOD", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.Byte) With {.Value = 0})
        value.Attributes.TryAdd("MaterialID", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString) With {.Value = ""})
        value.Attributes.TryAdd("ObjectID", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString) With {.Value = ""})
        SelectedTmp.NodeLSLIB.AppendChild(value)
        Return value
    End Function
    Private Sub Save_listboxes()
        SelectedTmp.NodeLSLIB.Children.Remove("Objects")
        SelectedTmp.NodeLSLIB.Children.Remove("VertexColorMaskSlots")

        For Each it In ListBoxVertex.Items
            Dim nnod As New LSLib.LS.Node With {.Name = "VertexColorMaskSlots"}
            nnod.Attributes.TryAdd("Object", New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = it.ToString})
            SelectedTmp.NodeLSLIB.AppendChild(nnod)
        Next

        For Each it In ListBoxObjects.Items
            SelectedTmp.NodeLSLIB.AppendChild(CType(it.value, LSLib.LS.Node).CloneNode)
        Next
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


    Private Sub ButtonAsset_Click(sender As Object, e As EventArgs) Handles ButtonAsset.Click
        Dim xx As New OpenFileDialog With {.Filter = "gr2 files|*.gr2", .InitialDirectory = CType(MdiParent, Main).ActiveMod.CurrentMod.AssetsPath}
        If xx.ShowDialog = DialogResult.OK Then
            Dim path = IO.Path.Combine(FuncionesHelpers.GameEngine.Settings.UTAMModFolder, CType(MdiParent, Main).ActiveMod.CurrentMod.SaveFolder)
            Dim ass = FuncionesHelpers.GameEngine.ProcessedAssets.Manage_Overrides(New BG3_Obj_Assets_Class(New BG3_Pak_SourceOfResource_Class(path, xx.FileName, BG3_Enum_Package_Type.UTAM_Mod)))
            BG3Editor_VisualBank_SourceFile1.TextBox1.Text = IO.Path.GetRelativePath(path, xx.FileName).Replace("\", "/")
            BG3Editor_Visuals_TemplategR21.TextBox1.Text = IO.Path.GetRelativePath(path, xx.FileName).Replace("\", "/").Replace(IO.Path.GetExtension(xx.FileName), "") + ".Dummy_Root.0"
        End If
    End Sub

    Private Sub ButtonDeletePropery_Click(sender As Object, e As EventArgs) Handles ButtonDeleteMaskSlot.Click
        If ListBoxVertex.SelectedIndex <> -1 Then
            ListBoxVertex.Items.RemoveAt(ListBoxVertex.SelectedIndex)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ButtonAddMaskSlot.Click
        If BG3Editor_Visuals_VertexMasks1.TextBox1.Text <> "" Then
            If ListBoxVertex.Items.IndexOf(BG3Editor_Visuals_VertexMasks1.TextBox1.Text) = -1 Then
                ListBoxVertex.Items.Add(BG3Editor_Visuals_VertexMasks1.TextBox1.Text)
            End If
        End If
    End Sub


    Private Sub ListBoxVertex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxVertex.SelectedIndexChanged
        ButtonDeleteMaskSlot.Enabled = Not (ListBoxVertex.SelectedIndex = -1)
    End Sub
    Private Sub ButtonDeleteObject_Click(sender As Object, e As EventArgs) Handles ButtonDeleteObject.Click
        If ListBoxObjects.SelectedIndex <> -1 Then
            ListBoxObjects.Items.RemoveAt(ListBoxObjects.SelectedIndex)
        End If
    End Sub
    Private Sub ListBoxObjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxObjects.SelectedIndexChanged
        ButtonDeleteObject.Enabled = Not (ListBoxObjects.SelectedIndex = -1)
        If ListBoxObjects.SelectedIndex <> -1 Then
            Dim objNode As LSLib.LS.Node = CType(ListBoxObjects.Items(ListBoxObjects.SelectedIndex).value, LSLib.LS.Node)
            BG3Editor_Visuals_lod1.Read(objNode)
            BG3Editor_Visuals_Materialid1.Read(objNode)
            BG3Editor_Visuals_oBjectid1.Read(objNode)
        Else
            BG3Editor_Visuals_lod1.Clear()
            BG3Editor_Visuals_Materialid1.Clear()
            BG3Editor_Visuals_oBjectid1.Clear()
        End If
    End Sub
    Private Sub Write_On_leave() Handles BG3Editor_Visuals_lod1.Leave, BG3Editor_Visuals_Materialid1.Leave, BG3Editor_Visuals_oBjectid1.Leave, BG3Editor_Visuals_Materialid1.Dropped
        If ListBoxObjects.SelectedIndex <> -1 Then
            Dim objNode As LSLib.LS.Node = CType(ListBoxObjects.Items(ListBoxObjects.SelectedIndex).value, LSLib.LS.Node)
            BG3Editor_Visuals_lod1.Write(objNode)
            BG3Editor_Visuals_Materialid1.Write(objNode)
            BG3Editor_Visuals_oBjectid1.Write(objNode)
            ListBoxObjects.Items(ListBoxObjects.SelectedIndex).text = "Object (LOD:" + BG3Editor_Visuals_lod1.TextBox1.Text + ")"
        End If
    End Sub

    Private Sub ButtonDeleteObject_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonDeleteObject.EnabledChanged
        GroupBoxObject.Enabled = ButtonDeleteObject.Enabled
    End Sub

    Private Sub ButtonAddObject_Click(sender As Object, e As EventArgs) Handles ButtonAddObject.Click
        Dim cust As New BG3_Custom_ComboboxItem With {.Text = "Object (LOD:" + BG3Editor_Visuals_lod1.TextBox1.Text + ")", .Value = Create_Node_Object()}
        ListBoxObjects.SelectedIndex = ListBoxObjects.Items.Add(cust)

    End Sub
End Class
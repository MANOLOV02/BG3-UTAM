Imports System.IO
Imports LSLib.LS

Public Class CharacterBank_Editor
    Protected Overrides Property Visualtype As BG3_Enum_VisualBank_Type = BG3_Enum_VisualBank_Type.CharacterVisualBank
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.CharacterBank
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Public Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True
        TabControl1.TabPages.Remove(TabPageScalars)
        TabControl1.TabPages.Insert(1, TabPageScalars)
        Initialize(MdiParent, Source)
    End Sub
    Protected Overrides Sub Initialize_Specifics()
        BG3Editor_Complex_ScalarsandVectors1.InitializeByType(Visualtype)
        HandledAttributes.Add("ID")
        HandledAttributes.Add("Localized")
        HandledAttributes.Add("Name")
        HandledAttributes.Add("BodySetVisual")
        HandledAttributes.Add("BaseVisual")
        HandledAttributes.Add("ShowEquipmentVisuals")
        HandledNodes.Add("Resource\Slots")
        HandledNodes.Add("Resource\MaterialOverrides\Vector3Parameters")
        HandledNodes.Add("Resource\MaterialOverrides\VectorParameters")
        HandledNodes.Add("Resource\MaterialOverrides\ScalarParameters")
    End Sub

    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As Node)
        BG3Editor_Textures_iD_Fixed1.Create_Attribute(nuevonod, Template_guid)
        BG3Editor_Textures_Name1.Create_Attribute(nuevonod, "New_Texture")
        'BG3Editor_Visuals_Streaming1.Create_Attribute(nuevonod, "True")
        'BG3Editor_Visuals_Localized1.Create_Attribute(nuevonod, "False")
        'BG3Editor_Texture_Format1.Create_Attribute(nuevonod,"64")
    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        GroupBoxCharacter.Enabled = Edicion
        BG3Editor_Complex_ScalarsandVectors1.ReadOnly = Not Edicion
        GroupSlots.Enabled = Edicion
    End Sub
    Protected Overrides Sub Process_Selection_Change_specific()
        If Not IsNothing(SelectedTmp) Then
            BG3Editor_Textures_iD_Fixed1.Read(SelectedTmp)
            BG3Editor_Textures_Name1.Read(SelectedTmp)
            BG3Editor_Visuals_Localized1.Read(SelectedTmp)
            BG3Editor_Visuals_ShowEquipmentVisuals1.Read(SelectedTmp)
            BG3Editor_Visuals_BodySetVisual1.Read(SelectedTmp)
            BG3Editor_Visuals_BaseVisual1.Read(SelectedTmp)
            BG3Editor_Complex_ScalarsandVectors1.Read_Data(SelectedTmp)
        Else
            BG3Editor_Textures_iD_Fixed1.Clear()
            BG3Editor_Textures_Name1.Clear()
            BG3Editor_Visuals_Localized1.Clear()
            BG3Editor_Visuals_ShowEquipmentVisuals1.Clear()
            BG3Editor_Visuals_BodySetVisual1.Clear()
            BG3Editor_Visuals_BaseVisual1.Clear()
            BG3Editor_Complex_ScalarsandVectors1.clear()
        End If
        Read_Listboxes()
    End Sub
    Private Sub Read_Listboxes()
        Dim idx2 = Math.Max(ListBoxSlots.SelectedIndex, 0)
        ListBoxSlots.Items.Clear()
        ButtonDeleteObject.Enabled = False
        BG3Editor_Visuals_Bone1.Clear()
        BG3Editor_Visuals_VisualResource1.Clear()
        BG3Editor_Visuals_Slot1.Clear()
        If Not IsNothing(SelectedTmp) Then
            Dim value As LSLib.LS.Node
            Dim values As List(Of LSLib.LS.Node) = Nothing
            If SelectedTmp.NodeLSLIB.Children.TryGetValue("Slots", values) Then
                For Each value In values
                    Dim value2 As NodeAttribute = Nothing
                    If value.Attributes.TryGetValue("Slot", value2) Then
                        Dim cust As New BG3_Custom_ComboboxItem With {.Text = value2.AsString(Funciones.Guid_to_string), .Value = value}
                        ListBoxSlots.Items.Add(cust)
                    End If
                Next
            End If
        End If

        If idx2 <= ListBoxSlots.Items.Count - 1 Then ListBoxSlots.SelectedIndex = idx2 Else If ListBoxSlots.Items.Count > 0 Then ListBoxSlots.SelectedIndex = 0
    End Sub

    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Textures_iD_Fixed1.Write(SelectedTmp)
        BG3Editor_Textures_Name1.Write(SelectedTmp)
        BG3Editor_Visuals_Localized1.Write(SelectedTmp)
        BG3Editor_Visuals_ShowEquipmentVisuals1.Write(SelectedTmp)
        BG3Editor_Visuals_BodySetVisual1.Write(SelectedTmp)
        BG3Editor_Visuals_BaseVisual1.Write(SelectedTmp)
        Save_listboxes()
    End Sub
    Private Function Create_Slot_Object() As LSLib.LS.Node
        Dim value As LSLib.LS.Node
        value = New LSLib.LS.Node With {.Name = "Slots", .KeyAttribute = "Slots"}
        value.Attributes.TryAdd("Bone", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString) With {.Value = ""})
        value.Attributes.TryAdd("VisualResource", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString) With {.Value = "Body"})
        value.Attributes.TryAdd("Slot", New LSLib.LS.NodeAttribute(LSLib.LS.AttributeType.FixedString) With {.Value = ""})
        SelectedTmp.NodeLSLIB.AppendChild(value)
        Return value
    End Function
    Private Sub Save_listboxes()
        SelectedTmp.NodeLSLIB.Children.Remove("Slots")
        For Each it In ListBoxSlots.Items
            SelectedTmp.NodeLSLIB.AppendChild(CType(it.value, LSLib.LS.Node).CloneNode)
        Next
    End Sub
    Protected Overrides Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))
        Lista.AddRange(
            {New ToolStripMenuItem("Character specific|Localized|True|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"Localized"}},
            New ToolStripMenuItem("Character specific|Base visual|False|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"BaseVisual"}},
            New ToolStripMenuItem("Character specific|Body set visual|False|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"BodySetVisual"}},
            New ToolStripMenuItem("Character specific|Show equipment visuals|True|Attribute", Nothing, AddressOf BG3Selector_Visuals1.TransferSibligsClick) With {.Tag = {"ShowEquipmentVisuals"}}
                       })

    End Sub
    Protected Overrides Sub Transfer_stats_specifics(Template As BG3_Obj_VisualBank_Class, statsList() As String)
        For Each stat In statsList
            Select Case stat
                Case "Localized"
                    BG3Editor_Visuals_Localized1.Read(Template)
                    BG3Editor_Visuals_Localized1.Write(SelectedTmp)
                Case "BaseVisual"
                    BG3Editor_Visuals_BaseVisual1.Read(Template)
                    BG3Editor_Visuals_BaseVisual1.Write(SelectedTmp)
                Case "BodySetVisual"
                    BG3Editor_Visuals_BodySetVisual1.Read(Template)
                    BG3Editor_Visuals_BodySetVisual1.Write(SelectedTmp)
                Case "ShowEquipmentVisuals"
                    BG3Editor_Visuals_ShowEquipmentVisuals1.Read(Template)
                    BG3Editor_Visuals_ShowEquipmentVisuals1.Write(SelectedTmp)
            End Select
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

    Private Sub ButtonBM_Click(sender As Object, e As EventArgs) Handles ButtonBM.Click
        BG3Editor_Visuals_BaseVisual1.TextBox1.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BG3Editor_Visuals_BodySetVisual1.TextBox1.Text = ""
    End Sub
    Private Sub Capture_Base_Change(sender As Object) Handles BG3Editor_Visuals_BodySetVisual1.Inside_Text_Changed, BG3Editor_Visuals_BaseVisual1.Inside_Text_Changed
        Dim st As BG3_Obj_VisualBank_Class = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_BaseVisual1.TextBox1.Text, st)
        If IsNothing(st) Then LabelBV.Text = "(None)" Else LabelBV.Text = "(" + st.Name + ")"
        st = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_BodySetVisual1.TextBox1.Text, st)
        If IsNothing(st) Then LabelBS.Text = "(None)" Else LabelBS.Text = "(" + st.Name + ")"
    End Sub

    Private Sub ButtonDeleteObject_Click(sender As Object, e As EventArgs) Handles ButtonDeleteObject.Click
        If ListBoxSlots.SelectedIndex <> -1 Then
            ListBoxSlots.Items.RemoveAt(ListBoxSlots.SelectedIndex)
        End If
    End Sub
    Private Sub ListBoxObjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxSlots.SelectedIndexChanged
        ButtonDeleteObject.Enabled = Not (ListBoxSlots.SelectedIndex = -1)
        If ListBoxSlots.SelectedIndex <> -1 Then
            Dim objNode As LSLib.LS.Node = CType(ListBoxSlots.Items(ListBoxSlots.SelectedIndex).value, LSLib.LS.Node)
            BG3Editor_Visuals_Bone1.Read(objNode)
            BG3Editor_Visuals_VisualResource1.Read(objNode)
            BG3Editor_Visuals_Slot1.Read(objNode)
        Else
            BG3Editor_Visuals_Bone1.Clear()
            BG3Editor_Visuals_VisualResource1.Clear()
            BG3Editor_Visuals_Slot1.Clear()
        End If
    End Sub
    Private Sub Write_On_leave() Handles BG3Editor_Visuals_Bone1.Leave, BG3Editor_Visuals_VisualResource1.Leave, BG3Editor_Visuals_Slot1.Leave, BG3Editor_Visuals_VisualResource1.Dropped
        If ListBoxSlots.SelectedIndex <> -1 Then
            Dim objNode = CType(ListBoxSlots.Items(ListBoxSlots.SelectedIndex).value, Node)
            BG3Editor_Visuals_Bone1.Write(objNode)
            BG3Editor_Visuals_VisualResource1.Write(objNode)
            BG3Editor_Visuals_Slot1.Write(objNode)
            ListBoxSlots.Items(ListBoxSlots.SelectedIndex).text = BG3Editor_Visuals_Slot1.TextBox1.Text
            ListBoxSlots.Items(ListBoxSlots.SelectedIndex) = ListBoxSlots.Items(ListBoxSlots.SelectedIndex)

        End If
    End Sub

    Private Sub ButtonDeleteObject_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonDeleteObject.EnabledChanged
        GroupBoxSlotsDetails.Enabled = ButtonDeleteObject.Enabled
    End Sub

    Private Sub ButtonAddObject_Click(sender As Object, e As EventArgs) Handles ButtonAddObject.Click
        Dim cust As New BG3_Custom_ComboboxItem With {.Text = "Body", .Value = Create_Slot_Object()}
        ListBoxSlots.SelectedIndex = ListBoxSlots.Items.Add(cust)

    End Sub

    Private Sub CaptureMaterialChange(sender As Object) Handles BG3Editor_Visuals_VisualResource1.Inside_Text_Changed
        Dim st As BG3_Obj_VisualBank_Class = Nothing
        FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(BG3Editor_Visuals_VisualResource1.TextBox1.Text, st)
        If IsNothing(st) Then LabelMat.Text = "(None)" Else LabelMat.Text = "(" + st.Name + ")"
    End Sub

    Private Sub BG3Editor_Complex_ScalarsandVectors1_Load(sender As Object, e As EventArgs) Handles BG3Editor_Complex_ScalarsandVectors1.Load

    End Sub
End Class
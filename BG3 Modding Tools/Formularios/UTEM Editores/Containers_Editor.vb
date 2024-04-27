Imports System.DirectoryServices
Imports System.Runtime.InteropServices.Marshalling
Imports System.Xml
Imports Accessibility
Imports LSLib.LS

Public Class Containers_Editor
    Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private ModSource As BG3_Pak_SourceOfResource_Class
    Private SelectedTmp As BG3_Obj_Template_Class
    Private SelectedStat As BG3_Obj_Stats_Class

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
        ModSource = Source
        Habilita_Edicion_Botones(False)
    End Sub

    Private Sub ButtonNew_Click(sender As Object, e As EventArgs) Handles ButtonNew.Click
        isnew = True
        Dim nuevonod As New LSLib.LS.Node
        Dim gui As String = Funciones.NewGUID(False)
        nuevonod.Attributes.Add("MapKey", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = gui}))
        nuevonod.Attributes.Add("Name", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = "UTAM_Container_" + gui}))
        nuevonod.Attributes.Add("Type", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = "item"}))
        nuevonod.Attributes.Add("ParentTemplateId", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = "3e6aac21-333b-4812-a554-376c2d157ba9"}))
        nuevonod.Attributes.Add("ContainerAutoAddOnPickup", (New LSLib.LS.NodeAttribute(AttributeType.Bool) With {.Value = "False"}))
        nuevonod.Attributes.Add("ContainerContentFilterCondition", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = ""}))
        nuevonod.Attributes.Add("Stats", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = "UTAM_Container_OBJ_" + gui}))
        nuevonod.Attributes.Add("UTAM_Type", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = BG3_Enum_UTAM_Type.Containers.ToString}))
        nuevonod.Attributes.Add("UTAM_h1", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = Funciones.NewGUID(True)}))
        nuevonod.Attributes.Add("UTAM_h2", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = Funciones.NewGUID(True)}))
        nuevonod.Attributes.Add("UTAM_h3", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = Funciones.NewGUID(True)}))
        Dim invit As New LSLib.LS.Node With {.Name = "InventoryItem"}
        invit.Attributes.Add("Object", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = "UTAM_Container_Treasure_" + gui}))
        Dim invlist As New LSLib.LS.Node With {.Name = "InventoryList"}
        invlist.Children.Add("children", New List(Of Node) From {invit})
        nuevonod.Children.Add("children", New List(Of Node) From {invlist})
        Dim nuevo As New BG3_Obj_Template_Class(nuevonod, ModSource)
        Dim nuevoStat As New BG3_Obj_Stats_Class(ModSource, "UTAM_Container_OBJ_" + gui) With {.Using = "OBJ_Bag"}
        nuevoStat = FuncionesHelpers.GameEngine.ProcessedStatList.Manage_Overrides(nuevoStat)
        nuevoStat.Type = BG3_Enum_StatType.Object
        nuevoStat.Data.Add("RootTemplate", gui)
        nuevoStat.Data.Add("Rarity", "Common")
        nuevoStat.Data.Add("Unique", "0")
        nuevoStat.Data.Add("Weight", "0.1")
        nuevoStat.Data.Add("ValueOverride", "1")
        SelectedStat = nuevoStat
        SelectedTmp = FuncionesHelpers.GameEngine.ProcessedGameObjectList.Manage_Overrides(nuevo)
        ListBox1.SelectedIndex = ListBox1.Items.Add(New BG3_Custom_ComboboxItem(nuevo.Name, nuevo.MapKey))
        Habilita_Edicion_Botones(True)
    End Sub
    Private isnew As Boolean = False
    Private Sub Habilita_Edicion_Botones(Edicion As Boolean)
        ButtonSave.Enabled = Edicion
        ButtonCancel.Enabled = Edicion
        ButtonNew.Enabled = Not Edicion
        If ListBox1.SelectedIndex <> -1 Then
            ButtonEdit.Enabled = Not Edicion
        Else
            ButtonEdit.Enabled = False
        End If
        ListBox1.Enabled = Not Edicion
        GroupBox1.Enabled = Edicion
        GroupBox2.Enabled = Edicion
        GroupBox4.Enabled = Edicion
        LocaTemplate1.DataGridView1.Enabled = Edicion
        WorldInjectTemplate1.Enabled = Edicion
        ComboBoxRarity.Enabled = Edicion
        Repinta()
    End Sub
    Private Sub Repinta()
        If Not IsNothing(SelectedTmp) Then
            TextBoxName.Text = SelectedTmp.ReadAttribute_Or_Nothing("Name")
            TextboxUUID.Text = SelectedTmp.ReadAttribute_Or_Nothing("MapKey")
            TextBoxType.Text = SelectedTmp.ReadAttribute_Or_Nothing("Type")
            TextBoxParent.Text = SelectedTmp.ReadAttribute_Or_Nothing("ParentTemplateId")
            TextBoxVisual.Text = SelectedTmp.GetVisualTemplate_Or_Inherited
            TextBoxDisplayName.Text = SelectedTmp.DisplayName(Bg3_Enum_Languages.English)
            TextBoxDescription.Text = SelectedTmp.Description(Bg3_Enum_Languages.English)
            TextBoxTechnical.Text = SelectedTmp.Technical(Bg3_Enum_Languages.English)
            TextBoxIcon.Text = SelectedTmp.GetIcon_Or_Inherited
            TextBoxAutosort.Text = SelectedTmp.ReadAttribute_Or_Nothing("ContainerContentFilterCondition")
            TextBoxStatName.Text = SelectedTmp.Stats
            TextBoxTreasure.Text = "UTAM_Container_Treasure_" + TextboxUUID.Text
            ComboBoxRarity.SelectedItem = SelectedStat.Data("Rarity")
            If SelectedStat.Data.ContainsKey("Weight") = False Then SelectedStat.Data.TryAdd("Weight", "0.1")
            If SelectedStat.Data.ContainsKey("ValueOverride") = False Then SelectedStat.Data.TryAdd("ValueOverride", "1")
            NumericUpDownWeight.Value = SelectedStat.Data("Weight")
            NumericUpDownValue.Value = SelectedStat.Data("ValueOverride")
            LabelInfoName.Text = "Name: " + TextBoxDisplayName.Text
            LabelInfoDescription.Text = "Description: " + TextBoxDescription.Text
            Update_icon()
        End If

    End Sub
    Private Sub Save()
        If Not IsNothing(SelectedTmp) Then
            If TextBoxName.Text <> "" Then
                SelectedTmp.NodeLSLIB.Attributes.Remove("Name")
                SelectedTmp.NodeLSLIB.Attributes.TryAdd("Name", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = TextBoxName.Text}))
            End If

            SelectedTmp.NodeLSLIB.Attributes.Remove("Icon")
            If CheckBoxIcon.Checked Then SelectedTmp.NodeLSLIB.Attributes.TryAdd("Icon", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = TextBoxIcon.Text}))

            SelectedTmp.NodeLSLIB.Attributes.Remove("DisplayName")
            If CheckBoxDisplayName.Checked Then SelectedTmp.NodeLSLIB.Attributes.TryAdd("DisplayName", (New LSLib.LS.NodeAttribute(AttributeType.TranslatedString) With {.Value = New LSLib.LS.TranslatedString With {.Version = 1, .Handle = SelectedTmp.ReadAttribute_Or_Nothing("UTAM_h1")}}))

            SelectedTmp.NodeLSLIB.Attributes.Remove("Description")
            If CheckBoxDescription.Checked Then SelectedTmp.NodeLSLIB.Attributes.TryAdd("Description", (New LSLib.LS.NodeAttribute(AttributeType.TranslatedString) With {.Value = New LSLib.LS.TranslatedString With {.Version = 1, .Handle = SelectedTmp.ReadAttribute_Or_Nothing("UTAM_h2")}}))

            SelectedTmp.NodeLSLIB.Attributes.Remove("TechnicalDescription")
            If CheckBoxTechnical.Checked Then SelectedTmp.NodeLSLIB.Attributes.TryAdd("TechnicalDescription", (New LSLib.LS.NodeAttribute(AttributeType.TranslatedString) With {.Value = New LSLib.LS.TranslatedString With {.Version = 1, .Handle = SelectedTmp.ReadAttribute_Or_Nothing("UTAM_h3")}}))

            SelectedTmp.NodeLSLIB.Attributes.Remove("VisualTemplate")
            If CheckBoxVisual.Checked Then
                If SelectedTmp.Parent.VisualTemplate <> TextBoxVisual.Text Then
                    SelectedTmp.NodeLSLIB.Attributes.TryAdd("VisualTemplate", (New LSLib.LS.NodeAttribute(AttributeType.FixedString) With {.Value = TextBoxVisual.Text}))
                End If
            End If

            SelectedTmp.NodeLSLIB.Attributes.Remove("ContainerAutoAddOnPickup")
            SelectedTmp.NodeLSLIB.Attributes.Remove("ContainerContentFilterCondition")

            If CheckBoxautosort.Checked = False Then
                SelectedTmp.NodeLSLIB.Attributes.Add("ContainerAutoAddOnPickup", (New LSLib.LS.NodeAttribute(AttributeType.Bool) With {.Value = "False"}))
            Else
                SelectedTmp.NodeLSLIB.Attributes.Add("ContainerAutoAddOnPickup", (New LSLib.LS.NodeAttribute(AttributeType.Bool) With {.Value = "True"}))
            End If

            SelectedTmp.NodeLSLIB.Attributes.Add("ContainerContentFilterCondition", (New LSLib.LS.NodeAttribute(AttributeType.LSString) With {.Value = TextBoxAutosort.Text}))
            SelectedStat.Data.TryAdd("Rarity", "Common")
            SelectedStat.Data.TryAdd("Unique", "0")
            SelectedStat.Data.TryAdd("Weight", "0.1")
            SelectedStat.Data.TryAdd("ValueOverride", "1")
            SelectedStat.Data("Rarity") = ComboBoxRarity.SelectedItem.ToString
            If ComboBoxRarity.SelectedItem.ToString = "Unique" Then
                SelectedStat.Data("Unique") = "1"
            Else
                SelectedStat.Data("Unique") = "0"
            End If
            SelectedStat.Data("ValueOverride") = NumericUpDownValue.Value
            SelectedStat.Data("Weight") = NumericUpDownWeight.Value.ToString("0.00")
            SelectedTmp.NodeXMLZip = SelectedTmp.NodeLSLIB.To_XML.To_UTAMXML.ZippedString
            SelectedTmp.Write_Data()
            SelectedStat.Write_Data()

            Dim TT As New BG3_Obj_TreasureTable_Class(ModSource, "UTAM_Container_Treasure_" + SelectedTmp.MapKey) With {.CanMerge = True}
            TT.Subtables.Add(New BG3_Obj_TreasureTable_Subtable_Class(ModSource, "1,1"))
            TT = FuncionesHelpers.GameEngine.ProcessedTTables.Manage_Overrides(TT)
        End If

    End Sub

    Private Sub Containers_Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each obj In FuncionesHelpers.GameEngine.UtamTemplates.Where(Function(pf) pf.Is_Utam_Container)
            ListBox1.Items.Add(New BG3_Custom_ComboboxItem(obj.Name, obj.MapKey))
        Next
        If ListBox1.Items.Count > 0 Then ListBox1.SelectedIndex = 0
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then
            ButtonEdit.Enabled = ButtonNew.Enabled
            SelectedTmp = FuncionesHelpers.GameEngine.ProcessedGameObjectList.Elements(ListBox1.SelectedItem.value)
            SelectedStat = FuncionesHelpers.GameEngine.ProcessedStatList.Elements(SelectedTmp.Stats)
            Create_loca()
            Create_WorldInject()

            CheckBoxVisual.Checked = Not IsNothing(SelectedTmp.VisualTemplate)
            CheckBoxDescription.Checked = Not IsNothing(SelectedTmp.DescriptionHandle)
            CheckBoxDisplayName.Checked = Not IsNothing(SelectedTmp.DisplayNameHandle)
            CheckBoxTechnical.Checked = Not IsNothing(SelectedTmp.TechnicalHandle)
            CheckBoxIcon.Checked = Not IsNothing(SelectedTmp.Icon)
            If Not IsNothing(SelectedTmp.ReadAttribute_Or_Nothing("ContainerAutoAddOnPickup")) Then
                CheckBoxautosort.Checked = SelectedTmp.ReadAttribute_Or_Nothing("ContainerAutoAddOnPickup")
            Else
                CheckBoxautosort.Checked = False
            End If
            Repinta()
            Update_Loca()
        Else
            ButtonEdit.Enabled = False
        End If
    End Sub

    Private Sub Create_WorldInject()
        WorldInjectTemplate1.Objeto = SelectedStat
        WorldInjectTemplate1.Modsource = ModSource
    End Sub

    Private Sub Create_loca()

    End Sub
    Private Sub Update_Loca()

    End Sub
    Private Sub Update_icon()
        Dim ic As BG3_Obj_IconUV_Class = Nothing
        PictureBox3.Image = Nothing
        If FuncionesHelpers.GameEngine.ProcessedIcons.TryGetValue(TextBoxIcon.Text, ic) Then
            PictureBox3.Image = ic.Get_Icon_FromAtlass_or_File()
        End If
    End Sub
    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        isnew = False
        Habilita_Edicion_Botones(True)
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        CType(Me.MdiParent, Main).ChangedMod()
        Save()
        LocaTemplate1.Write_Data()
        WorldInjectTemplate1.Write_Data()
        Update_Name_Listbox()
        Habilita_Edicion_Botones(False)
    End Sub
    Private Sub Update_Name_Listbox()
        If ListBox1.SelectedIndex <> -1 AndAlso ListBox1.Items(ListBox1.SelectedIndex).text <> SelectedTmp.Name Then
            ListBox1.Items(ListBox1.SelectedIndex) = New BG3_Custom_ComboboxItem(SelectedTmp.Name, SelectedTmp.MapKey)
        End If
    End Sub
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ' Borra Cache
        SelectedTmp.Cancel_Edit()
        Habilita_Edicion_Botones(False)
    End Sub

    Private Sub CheckBoxIcon_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIcon.CheckedChanged
        TextBoxIcon.ReadOnly = Not CheckBoxIcon.Checked
        If TextBoxIcon.ReadOnly = True Then TextBoxIcon.Text = SelectedTmp.Parent.Icon
        Update_icon()
    End Sub
    Private Sub CheckBoxVisual_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxVisual.CheckedChanged
        TextBoxVisual.ReadOnly = Not CheckBoxVisual.Checked
        If TextBoxVisual.ReadOnly = True Then TextBoxVisual.Text = SelectedTmp.Parent.VisualTemplate
    End Sub
    Private Sub CheckBoxDisplayNameCheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDisplayName.CheckedChanged
        TextBoxDisplayName.ReadOnly = Not CheckBoxDisplayName.Checked
        If TextBoxDisplayName.ReadOnly = True Then TextBoxDisplayName.Text = SelectedTmp.Parent.DisplayName(Bg3_Enum_Languages.English)
        Update_Loca()
    End Sub
    Private Sub CheckBoxTechnical_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTechnical.CheckedChanged
        TextBoxTechnical.ReadOnly = Not CheckBoxTechnical.Checked
        If TextBoxTechnical.ReadOnly = True Then TextBoxTechnical.Text = SelectedTmp.Parent.Technical(Bg3_Enum_Languages.English)
        Update_Loca()
    End Sub
    Private Sub CheckBoxDescription_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDescription.CheckedChanged
        TextBoxDescription.ReadOnly = Not CheckBoxDescription.Checked
        If TextBoxDescription.ReadOnly = True Then TextBoxDescription.Text = SelectedTmp.Parent.Description(Bg3_Enum_Languages.English)
        Update_Loca()
    End Sub
    Private Sub CheckBoxautosort_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxautosort.CheckedChanged
        TextBoxAutosort.ReadOnly = Not CheckBoxautosort.Checked
        If TextBoxAutosort.ReadOnly = True Then TextBoxAutosort.Text = ""
        Update_Loca()
    End Sub
    Private Sub TextBoxicon_DragDrop(sender As Object, e As DragEventArgs) Handles TextBoxIcon.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class)))
            TextBoxIcon.Text = obj.Objeto.MapKey
            Update_icon()
        End If
    End Sub
    Private Sub TextBoxVisual_DragDrop(sender As Object, e As DragEventArgs) Handles TextBoxVisual.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class)))
            TextBoxVisual.Text = obj.Objeto.MapKey
        End If
    End Sub
    Private Sub TextBoxVisuak_DragEnter(sender As Object, e As DragEventArgs) Handles TextBoxVisual.DragEnter
        If CheckBoxVisual.Checked = True AndAlso e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class)))
            If CType(obj.Objeto, BG3_Obj_VisualBank_Class).Type = BG3_Enum_VisualBank_Type.VisualBank Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub TextBoxicon_DragEnter(sender As Object, e As DragEventArgs) Handles TextBoxIcon.DragEnter
        If CheckBoxIcon.Checked = True AndAlso e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_IconUV_Class)))
            If CType(obj.Objeto, BG3_Obj_IconUV_Class).Type = BG3_Enum_Icon_Type.Items Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TextBoxDisplayName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDisplayName.Leave
        Update_Loca()
    End Sub
    Private Sub TextBoxDescription_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDescription.Leave
        Update_Loca()
    End Sub
    Private Sub TextBoxTechnical_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTechnical.Leave
        Update_Loca()
    End Sub
    Private Sub TextBoxIcon_TextChanged(sender As Object, e As EventArgs) Handles TextBoxIcon.Leave
        Update_icon()
    End Sub



    'Private Sub TextBoxParent_DragDrop(sender As Object, e As DragEventArgs) Handles TextBoxParent.DragDrop
    '    If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
    '        Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
    '        TextBoxParent.Text = obj.Objeto.MapKey
    '    End If
    'End Sub

    'Private Sub TextBoxParent_DragEnter(sender As Object, e As DragEventArgs) Handles TextBoxParent.DragEnter
    '    If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
    '        e.Effect = DragDropEffects.Copy
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub

End Class
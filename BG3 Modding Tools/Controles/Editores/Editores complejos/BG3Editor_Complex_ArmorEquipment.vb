Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports LSLib.Granny
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class BG3Editor_Complex_ArmorEquipment

    Private isinherited As Boolean = True
    Private RaceLists As New SortedList(Of String, String)
    Private Last_read As BG3_Obj_Template_Class = Nothing
    Private _readonly As Boolean = False

    <DefaultValue(False)>
    Public Property [Readonly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            _readonly = value
            ButtonsEnable()
        End Set
    End Property

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True
        Flickering.EnableDoubleBuffering(TreeView1)

        For Each ra In FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.Elements.Where(Function(pf) pf.Value.Type = BG3_Enum_FlagsandTagsType.EquipmentRaces And pf.Value.IsOverrided = False)
            RaceLists.Add(ra.Key, ra.Value.Name)
            TreeView1.Nodes.Add(New System.Windows.Forms.TreeNode With {.Name = ra.Key, .Text = ra.Value.Name})
        Next

        TreeView1.Sort()
        If TreeView1.Nodes.Count > 0 Then TreeView1.SelectedNode = TreeView1.Nodes(0)
        ButtonsEnable()

    End Sub
    Public Sub Clear()
        Clear_nodes()
        Last_read = Nothing
        BG3Editor_Complex_Dyecolor1.Clear()
    End Sub
    Public Function Write(template As BG3_Obj_Template_Class) As Boolean
        If CheckBox1.Checked = False Then Return True
        Dim EquipNod As LSLib.LS.Node
        Dim RaceNod As LSLib.LS.Node
        Dim ItemsEuipsNod As LSLib.LS.Node
        Dim Vset As LSLib.LS.Node
        Dim MAtOvrr As LSLib.LS.Node

        If template.NodeLSLIB.Children.ContainsKey("Equipment") = False Then
            EquipNod = New LSLib.LS.Node With {.Parent = template.NodeLSLIB, .Name = "Equipment"}
        Else
            EquipNod = template.NodeLSLIB.Children("Equipment").First
        End If

        If EquipNod.Children.ContainsKey("ParentRace") = False Then
            RaceNod = New LSLib.LS.Node With {.Parent = EquipNod, .Name = "ParentRace"}
            EquipNod.AppendChild(RaceNod)
        Else
            RaceNod = EquipNod.Children("ParentRace").First
        End If
        If EquipNod.Children.ContainsKey("Visuals") = False Then
            ItemsEuipsNod = New LSLib.LS.Node With {.Parent = EquipNod, .Name = "Visuals"}
            EquipNod.AppendChild(ItemsEuipsNod)
        Else
            ItemsEuipsNod = EquipNod.Children("Visuals").First
        End If
        If EquipNod.Children.ContainsKey("VisualSet") = False Then
            Vset = New LSLib.LS.Node With {.Parent = EquipNod, .Name = "VisualSet"}
            EquipNod.AppendChild(Vset)
        Else
            Vset = EquipNod.Children("VisualSet").First
        End If
        If Vset.Children.ContainsKey("MaterialOverrides") = False Then
            MAtOvrr = New LSLib.LS.Node With {.Parent = Vset, .Name = "MaterialOverrides"}
            Vset.AppendChild(MAtOvrr)
        Else
            MAtOvrr = Vset.Children("MaterialOverrides").First
        End If

        RaceNod.Children.Clear()
        ItemsEuipsNod.Children.Clear()
        For Each nod As System.Windows.Forms.TreeNode In TreeView1.Nodes
            If Not IsNothing(nod.Tag) Then RaceNod.AppendChild(CType(nod.Tag, LSLib.LS.Node).CloneNode)
            Dim nodls = New LSLib.LS.Node With {.Name = "Object"}
            Dim value As New NodeAttribute(AttributeType.UUID)
            value.FromString(nod.Name, Funciones.Guid_to_string)
            nodls.Attributes.TryAdd("MapKey", value)
            If nod.Nodes.Count > 0 Then ItemsEuipsNod.AppendChild(nodls)
            For Each vis In nod.Nodes
                If Not IsNothing(vis.Tag) Then nodls.AppendChild(CType(vis.Tag, LSLib.LS.Node).CloneNode)
            Next
        Next
        BG3Editor_Complex_Dyecolor1.Write(MAtOvrr)
        Return True
    End Function
    Public Function Read(template As BG3_Obj_Template_Class) As Boolean
        Last_read = template
        Dim current = template
        Clear_nodes()
        isinherited = False
        While Not IsNothing(current)
            Dim value As List(Of LSLib.LS.Node) = Nothing
            If current.NodeLSLIB.Children.TryGetValue("Equipment", value) Then
                Read_parent_races(value.First)
                Read_Equipment(value.First)
                Exit While
            End If
            isinherited = True
            current = current.Parent
        End While
        CheckBox1.Checked = Not isinherited
        BG3Editor_Complex_Dyecolor1.Read(template)
        ButtonsEnable()
        Return True
    End Function
    Private Sub Clear_nodes()
        For Each nod As System.Windows.Forms.TreeNode In TreeView1.Nodes
            nod.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            nod.Nodes.Clear()
            nod.Tag = Nothing
        Next
    End Sub
    Private Sub Read_parent_races(Node As LSLib.LS.Node)
        Dim value As List(Of LSLib.LS.Node) = Nothing
        If Node.Children.TryGetValue("ParentRace", value) Then
            Dim treenod As System.Windows.Forms.TreeNode
            Dim raceNode As LSLib.LS.NodeAttribute = Nothing
            Dim racestr As String
            Dim raceValue As String
            If value.First.Children.TryGetValue("Object", value) Then
                For Each pr In value
                    racestr = ""
                    raceValue = ""
                    If pr.Attributes.TryGetValue("MapKey", raceNode) Then racestr = raceNode.AsString(Funciones.Guid_to_string)
                    If pr.Attributes.TryGetValue("MapValue", raceNode) Then raceValue = raceNode.AsString(Funciones.Guid_to_string)
                    treenod = TreeView1.Nodes.Find(racestr, False).First
                    treenod.Tag = pr
                    colorNode(treenod, raceValue)
                Next
            End If
        End If
    End Sub
    Private Sub ColorNode(Treenod As System.Windows.Forms.TreeNode, raceValue As String)
        Select Case raceValue
            Case "00000000-0000-0000-0000-000000000000"
                Treenod.ForeColor = Color.FromKnownColor(KnownColor.Highlight)
            Case ""
                Treenod.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            Case Else
                Treenod.ForeColor = Color.FromKnownColor(KnownColor.Red)
        End Select
    End Sub
    Private Sub Read_Equipment(Node As LSLib.LS.Node)
        Dim raceNode As LSLib.LS.NodeAttribute = Nothing
        Dim racestr As String
        Dim treenod As System.Windows.Forms.TreeNode
        Dim value As List(Of LSLib.LS.Node) = Nothing
        If Node.Children("Visuals").First.Children.TryGetValue("Object", value) Then
            For Each vis In value
                If vis.Attributes.TryGetValue("MapKey", raceNode) Then
                    racestr = raceNode.AsString(Funciones.Guid_to_string)
                    treenod = TreeView1.Nodes.Find(racestr, False).First
                    Dim Objnode As LSLib.LS.NodeAttribute = Nothing
                    For Each ob In vis.Children("MapValue")
                        Dim objkey As String
                        Dim objName As String
                        Dim visual As BG3_Obj_VisualBank_Class = Nothing
                        If ob.Attributes.TryGetValue("Object", Objnode) Then
                            objkey = Objnode.AsString(Funciones.Guid_to_string)
                            If FuncionesHelpers.GameEngine.ProcessedVisualBanksList.TryGetValue(objkey, visual) Then
                                objName = visual.Name
                                treenod.Nodes.Add(New System.Windows.Forms.TreeNode With {.Name = objkey, .Text = objName, .Tag = ob})
                            End If
                        End If

                    Next
                End If
            Next
        End If
    End Sub

    Private ReadOnly Property Curr_Parent As System.Windows.Forms.TreeNode
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return Nothing
            If IsNothing(TreeView1.SelectedNode.Parent) Then Return TreeView1.SelectedNode
            Return TreeView1.SelectedNode.Parent
        End Get
    End Property
    Private ReadOnly Property Curr_Nod As System.Windows.Forms.TreeNode
        Get
            If IsNothing(TreeView1.SelectedNode) Then Return Nothing
            If IsNothing(TreeView1.SelectedNode.Parent) Then Return Nothing
            Return TreeView1.SelectedNode
        End Get
    End Property

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Not IsNothing(Curr_Parent) Then BG3Editor_Template_ParentRaceMapkey1.Read(CType(Curr_Parent.Tag, LSLib.LS.Node))
        ButtonsEnable()
    End Sub
    Private Sub ButtonsEnable()
        GroupboxElement.Enabled = Not isinherited And Not [Readonly] And Not IsNothing(Last_read)
        GroupboxRace.Enabled = Not isinherited And Not [Readonly] And Not IsNothing(Last_read)
        CheckBox1.Enabled = Not [Readonly] And Not IsNothing(Last_read)
        Button1.Enabled = Not IsNothing(Curr_Parent) AndAlso BG3Editor_Template_ParentRaceMapkey1.Text <> ""
        Button2.Enabled = Not IsNothing(Curr_Parent) AndAlso BG3Editor_Template_ParentRaceMapkey1.Text <> "00000000-0000-0000-0000-000000000000"
        Button3.Enabled = Not IsNothing(Curr_Nod)
        BG3Editor_Complex_Dyecolor1.Enabled = Not isinherited And Not [Readonly] And Not IsNothing(Last_read)
    End Sub

    Private Sub Button_DefaultRace_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IsNothing(Curr_Parent) Then Exit Sub
        BG3Editor_Template_ParentRaceMapkey1.TextBox1.Text = "00000000-0000-0000-0000-000000000000"
    End Sub
    Private Sub Button_Remove_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(Curr_Parent) Then Exit Sub
        BG3Editor_Template_ParentRaceMapkey1.TextBox1.Text = ""

    End Sub

    Private Sub Changed_Race_Capture() Handles BG3Editor_Template_ParentRaceMapkey1.Inside_Text_Changed
        If IsNothing(Curr_Parent) Then Exit Sub
        If BG3Editor_Template_ParentRaceMapkey1.TextBox1.Text = "" Then
            Curr_Parent.Tag = Nothing
        Else
            If IsNothing(Curr_Parent.Tag) Then Curr_Parent.Tag = Crea_Race_Replacement(Curr_Parent)
        End If
        BG3Editor_Template_ParentRaceMapkey1.Write(CType(Curr_Parent.Tag, LSLib.LS.Node))
        colorNode(Curr_Parent, BG3Editor_Template_ParentRaceMapkey1.Text)
        ButtonsEnable()
    End Sub


    Private Function Crea_Race_Replacement(Nod As System.Windows.Forms.TreeNode) As LSLib.LS.Node
        Dim nodls = New LSLib.LS.Node With {.Name = "Object"}
        Dim value As New NodeAttribute(AttributeType.UUID)
        value.FromString(Nod.Name, Funciones.Guid_to_string)
        nodls.Attributes.TryAdd("MapKey", value)
        Dim value2 As New NodeAttribute(AttributeType.UUID)
        value2.FromString(BG3Editor_Template_ParentRaceMapkey1.Text, Funciones.Guid_to_string)
        nodls.Attributes.TryAdd("MapValue", value)
        Return nodls
    End Function
    Private Function Crea_Race_Item(VisualKey As String) As LSLib.LS.Node
        Dim nodls = New LSLib.LS.Node With {.Name = "MapValue"}
        Dim value As New NodeAttribute(AttributeType.FixedString)
        value.FromString(VisualKey, Funciones.Guid_to_string)
        nodls.Attributes.TryAdd("Object", value)
        Return nodls
    End Function

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles DropArmorLabel.Click

    End Sub




    Private Sub Drop_OBJ(template As BG3_Obj_Template_Class)
        If RadioButton2.Checked = False Then Clear_nodes()
        Dim current As BG3_Obj_Template_Class = template
        While Not IsNothing(current)
            Dim value As List(Of LSLib.LS.Node) = Nothing
            If current.NodeLSLIB.Children.TryGetValue("Equipment", value) Then Read_Equipment(value.First) : Exit While
            current = template.Parent
        End While
    End Sub
    Private Sub Drop_OBJ(Visual As BG3_Obj_VisualBank_Class)
        Curr_Parent.Nodes.Add(New System.Windows.Forms.TreeNode With {.Name = Visual.Mapkey_WithoutOverride, .Text = Visual.Name, .Tag = Crea_Race_Item(Visual.Mapkey_WithoutOverride)})
    End Sub
    Private Function Drop_Verify_OBJ(template As BG3_Obj_Template_Class)
        If IsNothing(template) Then Return False
        If IsNothing(Curr_Parent) Then Return False
        Dim current As BG3_Obj_Template_Class = template
        While Not IsNothing(current)
            If current.NodeLSLIB.Children.ContainsKey("Equipment") Then Return True
            current = current.Parent
        End While
        Return False
    End Function
    Private Function Drop_Verify_OBJ(template As BG3_Obj_VisualBank_Class)
        If IsNothing(template) Then Return False
        If IsNothing(Curr_Parent) Then Return False
        If template.Type = BG3_Enum_VisualBank_Type.VisualBank Then Return True
        Return False
    End Function

    Private Sub DropArmorLabel_DragDrop(sender As Object, e As DragEventArgs) Handles DropArmorLabel.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_Template_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Obj_Template_Class)) Then
            Dim obj As BG3_Obj_Template_Class = e.Data.GetData(GetType(BG3_Obj_Template_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If
    End Sub
    Private Sub DropArmorLabel_DragEnter(sender As Object, e As DragEventArgs) Handles DropArmorLabel.DragEnter
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_Template_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_Template_Class)) Then
            Dim obj As BG3_Obj_Template_Class = e.Data.GetData(GetType(BG3_Obj_Template_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Private Sub DropVisualLabel_DragEnter(sender As Object, e As DragEventArgs) Handles DropVisualLabel.DragEnter
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class)))
            If Not IsNothing(obj.Objeto) Then
                If Drop_Verify_OBJ(CType(obj.Objeto, BG3_Obj_VisualBank_Class)) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If

        If e.Data.GetDataPresent(GetType(BG3_Obj_VisualBank_Class)) Then
            Dim obj As BG3_Obj_VisualBank_Class = e.Data.GetData(GetType(BG3_Obj_VisualBank_Class))
            If Not IsNothing(obj) Then
                If Drop_Verify_OBJ(obj) Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub DropVisualLabel_DragDrop(sender As Object, e As DragEventArgs) Handles DropVisualLabel.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_VisualBank_Class)))
            If Not IsNothing(obj.Objeto) Then
                Drop_OBJ(CType(obj.Objeto, BG3_Obj_VisualBank_Class))
                Exit Sub
            End If
        End If
        If e.Data.GetDataPresent(GetType(BG3_Obj_VisualBank_Class)) Then
            Dim obj As BG3_Obj_VisualBank_Class = e.Data.GetData(GetType(BG3_Obj_VisualBank_Class))
            If Not IsNothing(obj) Then
                Drop_OBJ(obj)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Curr_Nod.Remove()
        ButtonsEnable()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If IsNothing(Last_read) Then Exit Sub
        If Not [Readonly] And CheckBox1.Checked <> Not isinherited Then
            Select Case CheckBox1.Checked
                Case False
                    Last_read.NodeLSLIB.Children.Remove("Equipment")
                Case True
                    Last_read.NodeLSLIB.Children.Remove("Equipment")
                    Dim current As BG3_Obj_Template_Class = Last_read.Parent
                    While Not IsNothing(current)
                        Dim value As List(Of LSLib.LS.Node) = Nothing
                        If current.NodeLSLIB.Children.TryGetValue("Equipment", value) Then
                            Last_read.NodeLSLIB.AppendChild(value.First.CloneNode)
                            Exit While
                        End If
                        current = current.Parent
                    End While
            End Select
            Read(Last_read)
        End If
    End Sub
End Class

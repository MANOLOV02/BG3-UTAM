Imports System.Net.Sockets
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class Containers_Editor

    Protected Overrides ReadOnly Property Prefix As String = "UTAM_Container_"
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Container
    Protected Overrides ReadOnly Property DefaulStatUsing As String = "OBJ_Bag"
    Protected Overrides ReadOnly Property DefaulParent As String = "3e6aac21-333b-4812-a554-376c2d157ba9"
    Protected Overrides ReadOnly Property DefaulStat_Type As BG3_Enum_StatType = BG3_Enum_StatType.Object



    Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        Me.DoubleBuffered = True

    End Sub
    Protected Overrides Sub Initialize_Specifics()
        ' Nothing
        HandledAttributes.Add("ContainerContentFilterCondition")
        HandledAttributes.Add("ContainerAutoAddOnPickup")
    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        GroupBox5.Enabled = Edicion
    End Sub
    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As LSLib.LS.Node)
        BG3Editor_Template_Container_tt1.Create_Attribute(nuevonod, Prefix + "Treasure_" + Template_guid)
        BG3Editor_Template_ContainerContentFilterCondition1.Create_Attribute(nuevonod, "")
        BG3Editor_Template_ContainerAutoAddOnPickup1.Create_Attribute(nuevonod, "False")
    End Sub
    Protected Overrides Sub Add_UTAM_Attribute_Specific(ByRef nuevonod As LSLib.LS.Node)
        ' Do nothing
    End Sub
    Protected Overrides Sub Capture_Clone_specific(obj As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype)

        Select Case tipo
            Case BG3Cloner.Clonetype.None
                BG3Editor_Template_Container_tt1.Replace_Attribute(Clone_Nuevonod, Prefix + "Treasure_" + Template_guid)
            Case BG3Cloner.Clonetype.Clone
                BG3Editor_Template_Container_tt1.Replace_Attribute(Clone_Nuevonod, Prefix + "Treasure_" + Template_guid)
            Case BG3Cloner.Clonetype.Inherit
                BG3Editor_Template_Container_tt1.Replace_Attribute(Clone_Nuevonod, Prefix + "Treasure_" + Template_guid)
            Case BG3Cloner.Clonetype.Override
                BG3Editor_Template_Container_tt1.Replace_Attribute(Clone_Nuevonod, Prefix + "Treasure_" + Template_guid)

            Case Else
                Debugger.Break()
        End Select
    End Sub

    Protected Overrides Sub Select_Objects_Specifics()
        If Not IsNothing(SelectedTmp) Then

        Else

        End If
    End Sub
    Protected Overrides Sub Process_Selection_Change_specific()
        If Not IsNothing(SelectedTmp) Then
            BG3Editor_Template_Container_tt1.Read(SelectedTmp)
            BG3Editor_Template_ContainerContentFilterCondition1.Read(SelectedTmp)
            BG3Editor_Template_ContainerAutoAddOnPickup1.Read(SelectedTmp)
        Else
            BG3Editor_Template_Container_tt1.Clear()
            BG3Editor_Template_ContainerContentFilterCondition1.Clear()
            BG3Editor_Template_ContainerAutoAddOnPickup1.Clear()
        End If
    End Sub
    Protected Overrides Sub Process_Cancel_Specifics()

    End Sub
    Protected Overrides Sub Process_Delete_Specifics()
        RemoveTT()
    End Sub
    Protected Overrides Sub Process_Edit_Specifics()

    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Template_Container_tt1.Write(SelectedTmp)
        BG3Editor_Template_ContainerContentFilterCondition1.Write(SelectedTmp)
        BG3Editor_Template_ContainerAutoAddOnPickup1.Write(SelectedTmp)
    End Sub
    Protected Overrides Sub Process_Save_Objetos_Specifics()
        SaveTT()
    End Sub
    Protected Overrides Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Lista.AddRange({
            New ToolStripMenuItem("Container specific|Filter condition|False|Attribute", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"ContainerContentFilterCondition"}},
            New ToolStripMenuItem("Container specific|Auto pickup|True|Attribute", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"ContainerAutoAddOnPickup"}}
            })
#Enable Warning CA1861 ' Evitar matrices constantes como argumentos
    End Sub
    Protected Overrides Sub Transfer_SaveOriginal_Specific()

    End Sub

    Protected Transfer_Combo As BG3_Obj_Stats_Class
    Protected Overrides Sub Transfer_stats_specifics(Template As BG3_Obj_Template_Class, statsList() As String)
        For Each nod As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_Template_Class) In BG3Selector_Template1.Current_Nod.Parent.Nodes
            Dim obj As BG3_Obj_Template_Class = nod.Objeto
            If obj IsNot Template Then
                For Each stat In statsList
                    Select Case stat
                        Case "ContainerContentFilterCondition"
                            BG3Editor_Template_ContainerContentFilterCondition1.Read(Template)
                            BG3Editor_Template_ContainerContentFilterCondition1.Write(obj)
                        Case "ContainerAutoAddOnPickup"
                            BG3Editor_Template_ContainerAutoAddOnPickup1.Read(Template)
                            BG3Editor_Template_ContainerAutoAddOnPickup1.Write(obj)
                    End Select
                Next
            End If
        Next
    End Sub

    ' Subs Especificos Containers

    Public Sub SaveTT()
        Dim ttname As String = "UTAM_Container_Treasure_" + SelectedTmp.MapKey
        If FuncionesHelpers.GameEngine.UtamTreasures.Where(Function(pf) pf.Mapkey_WithoutOverride = ttname).Any = False Then
            Dim TT As New BG3_Obj_TreasureTable_Class(ActiveModSource, ttname) With {.CanMerge = False}
            TT.Subtables.Add(New BG3_Obj_TreasureTable_Subtable_Class(ActiveModSource, "1,1"))
            FuncionesHelpers.GameEngine.ProcessedTTables.Manage_Overrides(TT)
        End If
    End Sub
    Public Sub RemoveTT()
        Dim ttname As String = "UTAM_Container_Treasure_" + SelectedTmp.MapKey
        Dim TT As BG3_Obj_TreasureTable_Class = Nothing
        If FuncionesHelpers.GameEngine.ProcessedTTables.TryGetValue(ttname, tt) Then
            FuncionesHelpers.GameEngine.UtamTreasures.Remove(TT)
            FuncionesHelpers.GameEngine.ProcessedTTables.Remove(TT)
        End If
    End Sub

    Private Sub LabelDropTag_DragEnter(sender As Object, e As DragEventArgs) Handles LabelDropTag.DragEnter, BG3Editor_Template_ContainerContentFilterCondition1.DragEnter
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class)))
            If Not IsNothing(obj.Objeto) Then
                If CType(obj.Objeto, BG3_Obj_FlagsAndTags_Class).Type = BG3_Enum_FlagsandTagsType.Tags Then
                    e.Effect = DragDropEffects.Copy
                    Exit Sub
                End If
            End If
        End If
        e.Effect = DragDropEffects.None
    End Sub
    Private Sub LabelDropTag_DragDrop(sender As Object, e As DragEventArgs) Handles LabelDropTag.DragDrop, BG3Editor_Template_ContainerContentFilterCondition1.DragDrop
        If e.Data.GetDataPresent(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class))) Then
            Dim obj As BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class) = e.Data.GetData(GetType(BG3_Custom_TreeNode_Linked_Class(Of BG3_Obj_FlagsAndTags_Class)))
            Dim tag = CType(obj.Objeto, BG3_Obj_FlagsAndTags_Class)
            If tag.Type = BG3_Enum_FlagsandTagsType.Tags Then
                Process_tag_add(tag.Name)
            End If
        End If
    End Sub

    Private Sub Process_tag_add(Name As String)
        If BG3Editor_Template_ContainerContentFilterCondition1.AllowEdit = True Then
            Dim tagpart As String = "Tagged('" + Name + "')"
            Dim addorpart As String = ""
            Dim Notpart As String = ""

            Select Case True
                Case RadioButtonAnd.Checked
                    addorpart = " and "
                    Notpart = ""
                Case RadioButtonOr.Checked
                    addorpart = " or "
                    Notpart = ""
                Case RadioButtonAndNot.Checked
                    addorpart = " and "
                    Notpart = "not "
                Case RadioButtonOrNot.Checked
                    addorpart = " or "
                    Notpart = "not "
                Case Else
                    Debugger.Break()
            End Select

            If BG3Editor_Template_ContainerContentFilterCondition1.Text = "" Then
                tagpart = Notpart + tagpart
            Else
                tagpart = addorpart + Notpart + tagpart
            End If
            BG3Editor_Template_ContainerContentFilterCondition1.Text += tagpart
        End If
    End Sub

End Class
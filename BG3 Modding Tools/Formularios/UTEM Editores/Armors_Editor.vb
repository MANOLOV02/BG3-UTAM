Imports System.Net.Sockets
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class Armors_Editor

    Protected Overrides ReadOnly Property Prefix As String = "UTAM_Armor_"
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Armor
    Protected Overrides ReadOnly Property DefaulStatUsing As String = "_Body"
    Protected Overrides ReadOnly Property DefaulParent As String = "a09273ba-6549-4cf9-ba47-615a962baf9f"
    Protected Overrides ReadOnly Property DefaulStat_Type As BG3_Enum_StatType = BG3_Enum_StatType.Armor



    Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        Me.DoubleBuffered = True

    End Sub
    Protected Overrides Sub Initialize_Specifics()
        ' Nothing
        HandledStats.Add("Slot")
        HandledStats.Add("Boosts")
        HandledStats.Add("DefaultBoosts")
        HandledStats.Add("PassivesOnEquip")
        HandledStats.Add("StatusOnEquip")
        HandledStats.Add("ArmorType")
        HandledStats.Add("Armor Class Ability")
        HandledStats.Add("ArmorClass")
        HandledStats.Add("Proficiency Group")

    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        GroupBoxArmors1.Enabled = Edicion
        GroupBoxArmorsG.Enabled = Edicion
        GroupBoxArmorsS.Enabled = Edicion
        BG3Editor_Complex_ArmorEquipment1.Readonly = Not Edicion
    End Sub
    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As LSLib.LS.Node)
        ' Nothin yet
    End Sub
    Protected Overrides Sub Add_UTAM_Attribute_Specific(ByRef nuevonod As LSLib.LS.Node)
        ' Do nothing
    End Sub
    Protected Overrides Sub Capture_Clone_specific(obj As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype)

        Select Case tipo
            Case BG3Cloner.Clonetype.None
            Case BG3Cloner.Clonetype.Clone
            Case BG3Cloner.Clonetype.Inherit
            Case BG3Cloner.Clonetype.Override
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
            BG3Editor_Stats_PassivesOnEquip1.Read(SelectedStat)
            BG3Editor_Stats_Boosts1.Read(SelectedStat)
            BG3Editor_Stats_DefaultBoosts1.Read(SelectedStat)
            BG3Editor_Stat_Slots_Armor1.Read(SelectedStat)
            BG3Editor_Stats_ArmorType1.Read(SelectedStat)
            BG3Editor_Stats_StatusOnEquip1.Read(SelectedStat)
            BG3Editor_Stats_ProficiencyGroup1.Read(SelectedStat)
            BG3Editor_Stats_ArmorClassAbility1.Read(SelectedStat)
            BG3Editor_Stats_ArmorClass1.Read(SelectedStat)
            BG3Editor_Complex_StatusList1.Read(SelectedTmp)
            BG3Editor_Complex_ArmorEquipment1.Read(SelectedTmp)
        Else
            BG3Editor_Stats_Boosts1.Clear()
            BG3Editor_Stats_DefaultBoosts1.Clear()
            BG3Editor_Stats_PassivesOnEquip1.Clear()
            BG3Editor_Stat_Slots_Armor1.Clear()
            BG3Editor_Stats_ArmorType1.Clear()
            BG3Editor_Stats_StatusOnEquip1.Clear()
            BG3Editor_Stats_ProficiencyGroup1.Clear()
            BG3Editor_Stats_ArmorClassAbility1.Clear()
            BG3Editor_Stats_ArmorClass1.Clear()
            BG3Editor_Complex_StatusList1.Clear()
            BG3Editor_Complex_ArmorEquipment1.Clear()

        End If
    End Sub
    Protected Overrides Sub Process_Cancel_Specifics()

    End Sub
    Protected Overrides Sub Process_Delete_Specifics()

    End Sub
    Protected Overrides Sub Process_Edit_Specifics()

    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Stats_PassivesOnEquip1.Write(SelectedStat)
        BG3Editor_Stats_Boosts1.Write(SelectedStat)
        BG3Editor_Stats_DefaultBoosts1.Write(SelectedStat)
        BG3Editor_Stat_Slots_Armor1.Write(SelectedStat)
        BG3Editor_Stats_ArmorType1.Write(SelectedStat)
        BG3Editor_Stats_StatusOnEquip1.Write(SelectedStat)
        BG3Editor_Stats_ProficiencyGroup1.Write(SelectedStat)
        BG3Editor_Stats_ArmorClassAbility1.Write(SelectedStat)
        BG3Editor_Stats_ArmorClass1.Write(SelectedStat)
        BG3Editor_Complex_StatusList1.Write(SelectedTmp)
        BG3Editor_Complex_ArmorEquipment1.Write(SelectedTmp)
    End Sub
    Protected Overrides Sub Process_Save_Objetos_Specifics()

    End Sub
    Protected Overrides Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Lista.AddRange({
            New ToolStripMenuItem("Armor specific|Slot|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Slot"}},
            New ToolStripMenuItem("Armor specific|Type|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"ArmorType"}},
              New ToolStripMenuItem("Armor specific|Ability|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Armor Class Ability"}},
                New ToolStripMenuItem("Armor specific|Proficiency|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Proficiency Group"}},
                 New ToolStripMenuItem("Armor specific|Armor Class|False|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"ArmorClass"}},
           New ToolStripMenuItem("Armor specific|Status list|False|Custom", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"StatusList"}}
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
                        Case "Slot"
                            BG3Editor_Stat_Slots_Armor1.Read(Transfer_Stat)
                            BG3Editor_Stat_Slots_Armor1.Write(SelectedStat)
                        Case "ArmorType"
                            BG3Editor_Stats_ArmorType1.Read(Transfer_Stat)
                            BG3Editor_Stats_ArmorType1.Write(SelectedStat)
                        Case "Armor Class Ability"
                            BG3Editor_Stats_ArmorClassAbility1.Read(Transfer_Stat)
                            BG3Editor_Stats_ArmorClassAbility1.Write(SelectedStat)
                        Case "Proficiency Group"
                            BG3Editor_Stats_ProficiencyGroup1.Read(Transfer_Stat)
                            BG3Editor_Stats_ProficiencyGroup1.Write(SelectedStat)
                        Case "ArmorClass"
                            BG3Editor_Stats_ArmorClass1.Read(Transfer_Stat)
                            BG3Editor_Stats_ArmorClass1.Write(SelectedStat)
                        Case "StatusList"
                            BG3Editor_Complex_StatusList1.Read(Template)
                            BG3Editor_Complex_StatusList1.Write(SelectedTmp)
                    End Select
                Next
            End If
        Next
    End Sub

    Private Sub BG3Editor_Complex_ArmorEquipment1_Load(sender As Object, e As EventArgs) Handles BG3Editor_Complex_ArmorEquipment1.Load

    End Sub

    ' Subs Especificos Containers



End Class
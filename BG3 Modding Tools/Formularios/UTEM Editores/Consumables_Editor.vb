Imports System.Net.Sockets
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class Consumables_Editor

    Protected Overrides ReadOnly Property Prefix As String = "UTAM_Consumable_"
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Consumable
    Protected Overrides ReadOnly Property DefaulStatUsing As String = "_Consumable"
    Protected Overrides ReadOnly Property DefaulParent As String = "cdd2941e-aef8-4cc6-a58b-ccb1d73060e8"
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
        HandledStats.Add("ItemUseType")
        HandledStats.Add("DefaultBoosts")
        HandledStats.Add("SupplyValue")
        HandledStats.Add("UseConditions")
        HandledAttributes.Add("UTAM_h4")
        HandledAttributes.Add("OnUseDescription")
        BG3Editor_Complex_Localization1.Link_Controls({BG3Editor_Template_OnUseDescription1})

    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        GroupBox5.Enabled = Edicion
    End Sub
    Protected Overrides Sub Create_Initial_Specific(ByRef nuevonod As LSLib.LS.Node)
        ' Nothin yet
        BG3Editor_Template_OnUseDescription1.Create_Attribute(nuevonod, Funciones.NewGUID(True) + ";1")
    End Sub
    Protected Overrides Sub Add_UTAM_Attribute_Specific(ByRef nuevonod As LSLib.LS.Node)
        ' Do nothing
    End Sub
    Protected Overrides Sub Capture_Clone_specific(obj As BG3_Obj_Template_Class, tipo As BG3Cloner.Clonetype)

        Select Case tipo
            Case BG3Cloner.Clonetype.None
            Case BG3Cloner.Clonetype.Clone
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("OnUseDescription"), Clone_Nuevonod.TryGetOrEmpty("UTAM_h4"))
            Case BG3Cloner.Clonetype.Inherit
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("OnUseDescription"), Clone_Nuevonod.TryGetOrEmpty("UTAM_h4"))
            Case BG3Cloner.Clonetype.Override
                CLone_Loca(obj.NodeLSLIB.TryGetOrEmpty("OnUseDescription"), Clone_Nuevonod.TryGetOrEmpty("UTAM_h4"))
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
            BG3Editor_Stats_DefaultBoosts1.Read(SelectedStat)
            BG3Editor_Stats_ItemUseType1.Read(SelectedStat)
            BG3Editor_Stats_SupplyValue1.Read(SelectedStat)
            BG3Editor_Stats_UseConditions1.Read(SelectedStat)
            BG3Editor_Template_OnUseDescription1.Read(SelectedTmp)

        Else
            BG3Editor_Stats_DefaultBoosts1.Clear()
            BG3Editor_Stats_ItemUseType1.Clear()
            BG3Editor_Stats_SupplyValue1.Clear()
            BG3Editor_Stats_UseConditions1.Clear()
            BG3Editor_Template_OnUseDescription1.Clear()
        End If
    End Sub
    Protected Overrides Sub Process_Cancel_Specifics()

    End Sub
    Protected Overrides Sub Process_Delete_Specifics()

    End Sub
    Protected Overrides Sub Process_Edit_Specifics()

    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Stats_DefaultBoosts1.Write(SelectedStat)
        BG3Editor_Stats_ItemUseType1.Write(SelectedStat)
        BG3Editor_Stats_SupplyValue1.Write(SelectedStat)
        BG3Editor_Stats_UseConditions1.Write(SelectedStat)
        BG3Editor_Template_OnUseDescription1.Write(SelectedTmp)

    End Sub
    Protected Overrides Sub Process_Save_Objetos_Specifics()

    End Sub
    Protected Overrides Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Lista.AddRange({
            New ToolStripMenuItem("Consumables specific|Use type|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"ItemUseType"}},
              New ToolStripMenuItem("Consumables specific|Use type|False|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"SupplyValue"}},
                New ToolStripMenuItem("Consumables specific|Use type|False|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"UseConditions"}}
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
                        Case "ItemUseType"
                            BG3Editor_Stats_ItemUseType1.Read(Transfer_Stat)
                            BG3Editor_Stats_ItemUseType1.Write(SelectedStat)
                        Case "SupplyValue"
                            BG3Editor_Stats_SupplyValue1.Read(Transfer_Stat)
                            BG3Editor_Stats_SupplyValue1.Write(SelectedStat)
                        Case "UseConditions"
                            BG3Editor_Stats_UseConditions1.Read(Transfer_Stat)
                            BG3Editor_Stats_UseConditions1.Write(SelectedStat)
                    End Select
                Next
            End If
        Next
    End Sub

    ' Subs Especificos Containers



End Class
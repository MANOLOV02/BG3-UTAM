Imports System.Net.Sockets
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class Weapons_Editor

    Protected Overrides ReadOnly Property Prefix As String = "UTAM_Weapon_"
    Protected Overrides ReadOnly Property UtamType As BG3_Enum_UTAM_Type = BG3_Enum_UTAM_Type.Weapon
    Protected Overrides ReadOnly Property DefaulStatUsing As String = "_BaseWeapon"
    Protected Overrides ReadOnly Property DefaulParent As String = "f44c9c6f-bc71-42ad-9cad-2dae306e750e"
    Protected Overrides ReadOnly Property DefaulStat_Type As BG3_Enum_StatType = BG3_Enum_StatType.Weapon


    Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        Me.DoubleBuffered = True

    End Sub

    Private List_equipment As New SortedList(Of String, String)
    Protected Overrides Sub Initialize_Specifics()
        ' Nothing
        HandledStats.Add("Slot")
        HandledStats.Add("Boosts")
        HandledStats.Add("BoostsOnEquipMainHand")
        HandledStats.Add("BoostsOnEquipOffHand")
        HandledStats.Add("PassivesOnEquip")
        HandledStats.Add("PassivesMainHand")
        HandledStats.Add("PassivesOffHand")
        HandledStats.Add("StatusOnEquip")
        HandledStats.Add("Proficiency Group")
        HandledStats.Add("DefaultBoosts")
        HandledStats.Add("WeaponFunctors")
        HandledStats.Add("Weapon Group")
        HandledStats.Add("Weapon Properties")
        HandledStats.Add("Damage")
        HandledStats.Add("Damage Type")
        HandledStats.Add("Damage Range")
        HandledStats.Add("WeaponRange")
        HandledStats.Add("VersatileDamage")
        '
        '
        HandledAttributes.Add("EquipmentTypeID")

        For Each it In FuncionesHelpers.GameEngine.ProcessedFlagsAndTags.ElementValues.Where(Function(pf) pf.Type = BG3_Enum_FlagsandTagsType.EquipmentTypes)
            List_equipment.TryAdd(it.MapKey, it.Name)
        Next

    End Sub
    Protected Overrides Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
        GroupBoxWeapons1.Enabled = Edicion
        GroupBoxWeaponsG.Enabled = Edicion
        GroupBoxWeaponsD.Enabled = Edicion
        GroupBoxWeaponsS.Enabled = Edicion
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
            BG3Editor_Stats_PassivesOnEquip_MainHand1.Read(SelectedStat)
            BG3Editor_Stats_PassivesOnEquip_OffHand1.Read(SelectedStat)
            BG3Editor_Stats_Boosts1.Read(SelectedStat)
            BG3Editor_Stats_BoostsOnEquipMainHand1.Read(SelectedStat)
            BG3Editor_Stats_BoostsOnEquipOffHand1.Read(SelectedStat)
            BG3Editor_Stat_Slots_Armor1.Read(SelectedStat)
            BG3Editor_Stats_StatusOnEquip1.Read(SelectedStat)
            BG3Editor_Stats_WeaponsProficiencyGroup1.Read(SelectedStat)
            BG3Editor_Stats_DefaultBoosts1.Read(SelectedStat)
            BG3Editor_Stats_WeaponFunctors1.Read(SelectedStat)
            BG3Editor_Stats_WeaponGroup1.Read(SelectedStat)
            BG3Editor_Stats_WeaponProperties1.Read(SelectedStat)
            BG3Editor_Stats_Damage_Type1.Read(SelectedStat)
            BG3Editor_Stats_Damage1.Read(SelectedStat)
            BG3Editor_Stats_VersatileDamage1.Read(SelectedStat)
            BG3Editor_Stats_DamageRange1.Read(SelectedStat)
            BG3Editor_Stats_WeaponRange1.Read(SelectedStat)
            BG3Editor_Template_EquipmenTypeId1.Read(SelectedTmp)
            BG3Editor_Complex_StatusList1.Read(SelectedTmp)
        Else
            BG3Editor_Stats_PassivesOnEquip1.Clear()
            BG3Editor_Stats_PassivesOnEquip_MainHand1.Clear()
            BG3Editor_Stats_PassivesOnEquip_OffHand1.Clear()
            BG3Editor_Stats_Boosts1.Clear()
            BG3Editor_Stats_BoostsOnEquipMainHand1.Clear()
            BG3Editor_Stats_BoostsOnEquipOffHand1.Clear()
            BG3Editor_Stats_Boosts1.Clear()
            BG3Editor_Stat_Slots_Armor1.Clear()
            BG3Editor_Stats_StatusOnEquip1.Clear()
            BG3Editor_Stats_WeaponsProficiencyGroup1.Clear()
            BG3Editor_Stats_DefaultBoosts1.Clear()
            BG3Editor_Stats_WeaponFunctors1.Clear()
            BG3Editor_Stats_WeaponGroup1.Clear()
            BG3Editor_Stats_WeaponProperties1.Clear()
            BG3Editor_Stats_Damage_Type1.Clear()
            BG3Editor_Stats_Damage1.Clear()
            BG3Editor_Stats_VersatileDamage1.Clear()
            BG3Editor_Stats_DamageRange1.Clear()
            BG3Editor_Stats_WeaponRange1.Clear()
            BG3Editor_Template_EquipmenTypeId1.Clear()
            BG3Editor_Complex_StatusList1.Clear()

        End If
    End Sub
    Protected Overrides Sub Process_Cancel_Specifics()

    End Sub
    Protected Overrides Sub Process_Delete_Specifics()

    End Sub
    Protected Overrides Sub Process_Edit_Specifics()

    End Sub

    Private Sub EquipmentName() Handles BG3Editor_Template_EquipmenTypeId1.Inside_Text_Changed
        Dim nam As String = "Unknown"
        List_equipment.TryGetValue(BG3Editor_Template_EquipmenTypeId1.TextBox1.Text, nam)
        Label1.Text = "(" + nam + ")"
    End Sub
    Protected Overrides Sub Process_Save_Edits_Specifics()
        BG3Editor_Stats_PassivesOnEquip1.Write(SelectedStat)
        BG3Editor_Stats_PassivesOnEquip_MainHand1.Write(SelectedStat)
        BG3Editor_Stats_PassivesOnEquip_OffHand1.Write(SelectedStat)
        BG3Editor_Stats_Boosts1.Write(SelectedStat)
        BG3Editor_Stats_BoostsOnEquipMainHand1.Write(SelectedStat)
        BG3Editor_Stats_BoostsOnEquipOffHand1.Write(SelectedStat)
        BG3Editor_Stat_Slots_Armor1.Write(SelectedStat)
        BG3Editor_Stats_StatusOnEquip1.Write(SelectedStat)
        BG3Editor_Stats_WeaponsProficiencyGroup1.Write(SelectedStat)
        BG3Editor_Stats_DefaultBoosts1.Write(SelectedStat)
        BG3Editor_Stats_WeaponFunctors1.Write(SelectedStat)
        BG3Editor_Stats_WeaponGroup1.Write(SelectedStat)
        BG3Editor_Stats_WeaponProperties1.Write(SelectedStat)
        BG3Editor_Stats_Damage_Type1.Write(SelectedStat)
        BG3Editor_Stats_Damage1.Write(SelectedStat)
        BG3Editor_Stats_VersatileDamage1.Write(SelectedStat)
        BG3Editor_Stats_DamageRange1.Write(SelectedStat)
        BG3Editor_Stats_WeaponRange1.Write(SelectedStat)
        BG3Editor_Template_EquipmenTypeId1.Write(SelectedTmp)
        BG3Editor_Complex_StatusList1.Write(SelectedTmp)

    End Sub
    Protected Overrides Sub Process_Save_Objetos_Specifics()

    End Sub

    Protected Overrides Sub Create_Stat_Transfers_Specific(ByRef Lista As List(Of ToolStripMenuItem))
#Disable Warning CA1861 ' Evitar matrices constantes como argumentos
        Lista.AddRange({
            New ToolStripMenuItem("Weapons specific|Slot|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Slot"}},
            New ToolStripMenuItem("Weapons specific|Weapon group|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Weapon Group"}},
            New ToolStripMenuItem("Weapons specific|Damage|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Damage"}},
            New ToolStripMenuItem("Weapons specific|Weapon properties|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Weapon Properties"}},
            New ToolStripMenuItem("Weapons specific|Damage type|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Damage Type"}},
            New ToolStripMenuItem("Weapons specific|Damage range|False|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Damage Range"}},
            New ToolStripMenuItem("Weapons specific|Weapon range|False|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"WeaponRange"}},
            New ToolStripMenuItem("Weapons specific|Versatile damage|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"VersatileDamage"}},
            New ToolStripMenuItem("Weapons specific|Proficiency|True|Data", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"Proficiency Group"}},
            New ToolStripMenuItem("Weapons specific|Equipment type|True|Custom", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"EquipmentTypeID"}},
           New ToolStripMenuItem("Weapons specific|Status list|False|Custom", Nothing, AddressOf BG3Selector_Template1.TransferSibligsClick) With {.Tag = {"StatusList"}}
            })
#Enable Warning CA1861 ' Evitar matrices constantes como argumentos
    End Sub
    Protected Overrides Sub Transfer_SaveOriginal_Specific()

    End Sub

    Protected Transfer_Combo As BG3_Obj_Stats_Class
    Protected Overrides Sub Transfer_stats_specifics(Template As BG3_Obj_Template_Class, statsList() As String)
        For Each stat In statsList
            Select Case stat
                Case "Slot"
                    BG3Editor_Stat_Slots_Armor1.Read(Transfer_Stat)
                    BG3Editor_Stat_Slots_Armor1.Write(SelectedStat)
                Case "Weapon Group"
                    BG3Editor_Stat_Slots_Armor1.Read(Transfer_Stat)
                    BG3Editor_Stat_Slots_Armor1.Write(SelectedStat)
                Case "Damage"
                    BG3Editor_Stats_VersatileDamage1.Read(Transfer_Stat)
                    BG3Editor_Stats_VersatileDamage1.Write(SelectedStat)
                Case "Weapon Properties"
                    BG3Editor_Stats_WeaponProperties1.Read(Transfer_Stat)
                    BG3Editor_Stats_WeaponProperties1.Write(SelectedStat)
                Case "Damage Type"
                    BG3Editor_Stats_Damage_Type1.Read(Transfer_Stat)
                    BG3Editor_Stats_Damage_Type1.Write(SelectedStat)
                Case "Damage Range"
                    BG3Editor_Stats_WeaponRange1.Read(Transfer_Stat)
                    BG3Editor_Stats_WeaponRange1.Write(SelectedStat)
                Case "WeaponRange"
                    BG3Editor_Stats_WeaponRange1.Read(Transfer_Stat)
                    BG3Editor_Stats_WeaponRange1.Write(SelectedStat)
                Case "VersatileDamage"
                    BG3Editor_Stats_VersatileDamage1.Read(Transfer_Stat)
                    BG3Editor_Stats_VersatileDamage1.Write(SelectedStat)
                Case "Proficiency Group"
                    BG3Editor_Stats_WeaponsProficiencyGroup1.Read(Transfer_Stat)
                    BG3Editor_Stats_WeaponsProficiencyGroup1.Write(SelectedStat)
                Case "EquipmentTypeID Group"
                    BG3Editor_Template_EquipmenTypeId1.Read(Template)
                    BG3Editor_Template_EquipmenTypeId1.Write(SelectedTmp)
                Case "StatusList"
                    BG3Editor_Complex_StatusList1.Read(Template)
                    BG3Editor_Complex_StatusList1.Write(SelectedTmp)
            End Select
        Next
    End Sub

    Protected Overrides Sub FillSplit_specific(ByVal Attr_or_data As String, ByRef ProcessingTemplate As BG3_Obj_Template_Class, ByRef ProcessingStat As BG3_Obj_Stats_Class, ByRef suffix As String)
        Dim nam As String = "Unknown"
        Dim que As String = ProcessingTemplate.ReadAttribute_Or_Inhterithed_Or_Empty("EquipmentTypeID")
        List_equipment.TryGetValue(que, nam)
        suffix += nam
    End Sub

    ' Subs Especificos Containers



End Class
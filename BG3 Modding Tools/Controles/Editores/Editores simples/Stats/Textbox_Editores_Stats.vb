Imports LSLib.LS

Public Class BG3Editor_Stats_Undefined
    Inherits TextBox_Editor_Stats_GenericAttribute
    Public Shadows Property Key As String
        Get
            Return MyBase.Key
        End Get
        Set(value As String)
            MyBase.Key = value
        End Set
    End Property


    Sub New()
        MyBase.New("Undefined")
        Label = "Undefined"
    End Sub
End Class

Public Class BG3Editor_Stats_Name
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Name")
        Label = "Stat name"
    End Sub
    Public Overrides Function Write(Que As BG3_Obj_Stats_Class) As Boolean
        ' Can not change mapker
        If Me.AllowEdit = True Then Throw New Exception : Return False
        Return True
    End Function
End Class

Public Class BG3Editor_Stats_PassivesOnEquip
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("PassivesOnEquip")
        Label = "Passives on equip"
    End Sub
    Sub New(key As String)
        MyBase.New(key)
    End Sub
End Class
Public Class BG3Editor_Stats_PassivesOnEquip_MainHand
    Inherits BG3Editor_Stats_PassivesOnEquip
    Sub New()
        MyBase.New("PassivesMainHand")
        Label = "On equip main hand"
    End Sub
End Class
Public Class BG3Editor_Stats_PassivesOnEquip_OffHand
    Inherits BG3Editor_Stats_PassivesOnEquip
    Sub New()
        MyBase.New("PassivesOffHand")
        Label = "On equip off hand"
    End Sub
End Class

Public Class BG3Editor_Stats_StatusOnEquip
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("StatusOnEquip")
        Label = "Status on equip"
    End Sub
End Class
Public Class BG3Editor_Stats_WeaponFunctors
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("WeaponFunctors")
        Label = "Weapon functors"
    End Sub
End Class
Public Class BG3Editor_Stats_Boosts
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Boosts")
        Label = "Boosts"
    End Sub
    Sub New(key As String)
        MyBase.New(key)
    End Sub
End Class

Public Class BG3Editor_Stats_BoostsOnEquipMainHand
    Inherits BG3Editor_Stats_Boosts
    Sub New()
        MyBase.New("BoostsOnEquipMainHand")
        Label = "Boosts on main hand"
    End Sub
End Class
Public Class BG3Editor_Stats_DefaultBoosts
    Inherits BG3Editor_Stats_Boosts
    Sub New()
        MyBase.New("DefaultBoosts")
        Label = "Default boosts"
    End Sub
End Class
Public Class BG3Editor_Stats_BoostsOnEquipOffHand
    Inherits BG3Editor_Stats_Boosts
    Sub New()
        MyBase.New("BoostsOnEquipOffHand")
        Label = "Boosts on off hand"
    End Sub
End Class
Public Class BG3Editor_Stats_WeaponProperties
    Inherits BG3Editor_Stats_Boosts
    Sub New()
        MyBase.New("Weapon Properties")
        Label = "Weapon properties"
    End Sub
End Class
Public Class BG3Editor_Stats_WeaponProficiency
    Inherits BG3Editor_Stats_Boosts
    Sub New()
        MyBase.New("Proficiency Group")
        Label = "Proficiency groups"
    End Sub
End Class
Public Class BG3Editor_Stats_Damage
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Damage")
        Label = "Damage"
    End Sub
End Class
Public Class BG3Editor_Stats_VersatileDamage
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("VersatileDamage")
        Label = "Versatile damage"
    End Sub
End Class
Public Class BG3Editor_Stats_ObjectCategory
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("ObjectCategory")
        Label = "Object category"
    End Sub
End Class
Public Class BG3Editor_Stats_ValueUUID
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("ValueUUID")
        Label = "Value UUID"
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_FlagsAndTags_Class) As Boolean
        If IsNothing(Obj) OrElse Obj.Type <> BG3_Enum_FlagsandTagsType.GoldValues Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_FlagsAndTags_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If IsNothing(Obj.Get_Data_Or_Inherited(Key)) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Get_Data_Or_Inherited(Key)
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If IsNothing(Obj.AssociatedStats) Then Return False
        Return Drop_Verify_OBJ(Obj.AssociatedStats)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If IsNothing(Obj) Then Exit Sub
        If IsNothing(Obj.AssociatedStats) Then Exit Sub
        Drop_OBJ(Obj.AssociatedStats)
    End Sub
End Class


Public Class BG3Editor_Stat_Using
    Inherits TextBox_Editor_Stats_GenericAttribute
    Public Property MustDescendFrom As String()

    Sub New()
        MyBase.New("Using")
        Label = "Using"
    End Sub

    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If Me.AllowEdit = False Then Return False
        If Not IsNothing(Last_read) AndAlso Obj.Is_Descendant(CType(Last_read, BG3_Obj_Stats_Class).MapKey) Then Return False
        Return BG3Cloner.CheckDescendant_Generic(Obj, MustDescendFrom)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Mapkey_WithoutOverride
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If IsNothing(Obj.AssociatedStats) Then Return False
        Return Drop_Verify_OBJ(Obj.AssociatedStats)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If IsNothing(Obj) Then Exit Sub
        If IsNothing(Obj.AssociatedStats) Then Exit Sub
        Drop_OBJ(Obj.AssociatedStats)
    End Sub

End Class




Imports LSLib.LS
Public Class BG3Editor_Stat_Name
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
Public Class BG3Editor_Stat_Using
    Inherits TextBox_Editor_Stats_GenericAttribute
    Public Property MustDescendFrom As String()

    Sub New()
        MyBase.New("Using")
        Label = "Using"
    End Sub

    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Stats_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If MustDescendFrom.Length > 0 AndAlso MustDescendFrom.Where(Function(pf) Obj.Is_Descendant(pf) = True).Any = False Then Return False
        If Not IsNothing(Last_read) AndAlso Obj.Is_Descendant(CType(Last_read, BG3_Obj_Stats_Class).MapKey) Then Return False
        Return Me.AllowEdit
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Stats_Class)
        If Me.EditIsConditional = True Then Me.CheckBox1.Checked = True
        Me.TextBox1.Text = Obj.Stat_Name
    End Sub
    Public Overrides Function Drop_Verify_OBJ(Obj As BG3_Obj_Template_Class) As Boolean
        If IsNothing(Obj) Then Return False
        If IsNothing(Obj.AssociatedStats_Obj) Then Return False
        Return Drop_Verify_OBJ(Obj.AssociatedStats_Obj)
    End Function
    Public Overrides Sub Drop_OBJ(Obj As BG3_Obj_Template_Class)
        If IsNothing(Obj) Then Exit Sub
        If IsNothing(Obj.AssociatedStats_Obj) Then Exit Sub
        Drop_OBJ(Obj.AssociatedStats_Obj)
    End Sub

End Class




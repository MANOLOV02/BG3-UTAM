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
    Sub New()
        MyBase.New("Using")
        Label = "Using"
    End Sub
End Class




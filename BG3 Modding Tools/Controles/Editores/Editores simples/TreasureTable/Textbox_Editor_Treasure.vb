Imports System.Diagnostics.Metrics
Imports LSLib.Granny

Public Class BG3Editor_Treasure_Name
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Name")
        Label = "Stat name"
    End Sub

    Private oldname As String = Nothing
    Public Overrides Function Read(Que As BG3_Obj_TreasureTable_Class) As Boolean
        oldname = Que.Name_Write
        Last_read = Que
        TextBox1.Text = oldname
        Return True
    End Function
    Public Overrides Function Write(Que As BG3_Obj_TreasureTable_Class) As Boolean
        If Me.AllowEdit = True Then
            Last_read = Que
            oldname = Que.Name_Write
            If oldname <> TextBox1.Text Then
                Que.Name_Write = TextBox1.Text
                RaiseEvent WritedNewName(Last_read, oldname, TextBox1.Text)
            End If
        End If
        Return True
    End Function

    Public Event WritedNewName(Quien As BG3_Obj_TreasureTable_Class, Oldname As String, newname As String)
End Class
Public Class BG3Editor_Treasure_SubtableDefinition
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Name")
        Label = "Stat name"
    End Sub

    Public Overrides Function Read(Que As BG3_Obj_TreasureTable_Subtable_Class) As Boolean
        TextBox1.Text = Que.WriteDefinition
        Return True
    End Function
    Public Overrides Function Write(Que As BG3_Obj_TreasureTable_Subtable_Class) As Boolean
        If Me.AllowEdit = True Then
            Dim olddef As String = Que.WriteDefinition
            Try
                Dim ret = BG3_Obj_TreasureTable_Subtable_Class.Parsedefinitions(TextBox1.Text)
                Que.Counts = ret.Item1
                Que.Chances = ret.Item2
            Catch ex As Exception
                TextBox1.Text = Que.WriteDefinition
            End Try
        End If
        Return True
    End Function

End Class
Public Class BG3Editor_Treasure_SubItemDefinition
    Inherits TextBox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Name")
        Label = "Stat name"
    End Sub

    Public Overrides Function Read(Que As BG3_Obj_TreasureTable_TableItem_Class) As Boolean
        Dim cond As String = Que.WriteDefinition.Substring(1)
        TextBox1.Text = cond

        Return True
    End Function
    Public Overrides Function Write(Que As BG3_Obj_TreasureTable_TableItem_Class) As Boolean
        If Me.AllowEdit = True Then
            Dim olddef As String = Que.WriteDefinition
            Try
                Dim ret = BG3_Obj_TreasureTable_TableItem_Class.ParseConditions(TextBox1.Text)
                Que.ConditionArray = ret
            Catch ex As Exception
                TextBox1.Text = Que.WriteDefinition
            End Try
        End If
        Return True
    End Function

End Class
Public Class BG3Editor_Treasure_CanMerge
    Inherits Combobox_Editor_Stats_GenericAttribute
    Sub New()
        MyBase.New("Type")
        Label = "Stat type"
        ComboItems = New List(Of String) From {"True", "False"}
        Reload_Combo()
    End Sub
    Public Overrides Function Read(Que As BG3_Obj_TreasureTable_Class) As Boolean
        If Que.CanMerge = True Then
            ComboBox1.SelectedIndex = 0
        Else
            ComboBox1.SelectedIndex = 1
        End If
        Return True
    End Function
    Public Overrides Function Write(Que As BG3_Obj_TreasureTable_Class) As Boolean
        Dim oldvalue As Boolean = Que.CanMerge
        If Me.AllowEdit = True Then
            If ComboBox1.SelectedIndex = 0 Then
                Que.CanMerge = True
            Else
                Que.CanMerge = False
            End If
        End If
        If oldvalue <> Que.CanMerge Then
            RaiseEvent CanmergeChanged(Last_read, oldvalue, Not oldvalue)
        End If
        Return True
    End Function

    Public Event CanmergeChanged(Quien As BG3_Obj_TreasureTable_Class, Oldvalue As Boolean, Newvalue As Boolean)

End Class
Imports System.ComponentModel
Imports BG3_Modding_Tools.Funciones
Imports BG3_Modding_Tools.FuncionesHelpers
Imports LSLib.Granny
Imports LSLib.LS.Story
Public MustInherit Class Explorer_Generic_Code(Of T As BG3_Obj_Generic_Class)
    Inherits Explorer_Generic_Designer

    Public ArbolWorker As New BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Private filtro As BG3_CustomFilter_Class(Of T)
    Public SelectedDisplayformat As BG3_Enum_DisplayFormat = BG3_Enum_DisplayFormat.Name_and_DisplayName
    Private Old_Enabled As Boolean = False
    Private _ObjList As BG3_Obj_SortedList_Class(Of T)
    Private _SourceFilter As BG3_Pak_SourceOfResource_Class = Nothing
    Public Property SourceFilter As BG3_Pak_SourceOfResource_Class
        Get
            Return _SourceFilter
        End Get
        Set(value As BG3_Pak_SourceOfResource_Class)
            _SourceFilter = value
            filtro.SourceFilter = value
        End Set
    End Property

    Public Overridable Property ObjectList As BG3_Obj_SortedList_Class(Of T)
        Get
            Return _ObjList
        End Get
        Set(value As BG3_Obj_SortedList_Class(Of T))
            _ObjList = value
            If Not IsNothing(value) Then filtro.TreeSource = value
        End Set
    End Property
    Sub New()
        filtro = New BG3_CustomFilter_Class(Of T)(ArbolWorker, ObjectList) With {.Filter_Level1 = -1, .Filter_Level2 = "", .Textfilter = "", .SourceFilter = SourceFilter}
        ComboBoxItems.Items.Add(New BG3_Custom_ComboboxItem With {.Text = "(all)", .Value = -1})
        If [Enum].GetValues(BG3_CustomFilter_Class(Of T).Getenum).Length > 1 Then
            For type = 0 To [Enum].GetValues(BG3_CustomFilter_Class(Of T).Getenum).Length - 1
                ComboBoxItems.Items.Add(New BG3_Custom_ComboboxItem With {.Text = [Enum].GetNames(BG3_CustomFilter_Class(Of T).Getenum)(type), .Value = type})
            Next
        End If
        ComboBoxItems.SelectedIndex = 0
        AddHandler ArbolWorker.ProgressChanged, AddressOf ProcesoParaleloArbol_ProgressChanged
        AddHandler ArbolWorker.RunWorkerCompleted, AddressOf ProcesoParaleloArbol_RunWorkerCompleted
        AddHandler ArbolWorker.DoWork, AddressOf ProcesoParaleloArbol_DoWork
    End Sub

    Private Sub ComboBoxItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItems.SelectedIndexChanged
        If ComboBoxItems.SelectedIndex = -1 Then Exit Sub
        ComboBoxParent.Items.Clear()
        ComboBoxParent.Items.Add(New BG3_Custom_ComboboxItem With {.Text = "(all)", .Value = ""})
        Rellena_Comboparent()
        If ComboBoxParent.SelectedIndex = -1 Then ComboBoxParent.SelectedIndex = 0
    End Sub
    Public Sub Rellena_Comboparent()
        If ComboBoxItems.Items(ComboBoxItems.SelectedIndex).value <> -1 And Not IsNothing(ObjectList) Then
            Dim typ As Integer = ComboBoxItems.Items(ComboBoxItems.SelectedIndex).value
            Dim arr = ObjectList.ElementValues.AsParallel.Where(Function(pf) pf.Filter_Check_Level1(typ) AndAlso pf.GetParentId_Or_TemplateName_Empty = "").OrderBy(Function(pq) pq.Name).Select(Function(pq) New BG3_Custom_ComboboxItem With {.Text = pq.Name, .Value = pq.MapKey}).ToArray
            ComboBoxParent.Items.AddRange(arr)
        End If
    End Sub
    Private Sub ComboBoxParent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxParent.SelectedIndexChanged
        If ComboBoxParent.SelectedIndex = -1 Then Exit Sub
        filtro.Filter_Level1 = ComboBoxItems.Items(ComboBoxItems.SelectedIndex).value
        filtro.Filter_Level2 = ComboBoxParent.Items(ComboBoxParent.SelectedIndex).value
        filtro.Textfilter = TextBoxFilter.Text
        filtro.ToRefilter = True
        Reload_Arbol(False)
    End Sub
    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        filtro.Textfilter = TextBoxFilter.Text
        filtro.ToRefilter = True
        Process_filter()
    End Sub
    Public Sub Reload_Arbol(full As Boolean)
        Try
            If IsNothing(ObjectList) Then Exit Sub
            Old_Enabled = Enabled
            Enabled = False
            ProgressBarTree.Value = 0
            TreeView1.BeginUpdate()
            TreeView1.Nodes.Clear()
            TreeView1.EndUpdate()
            ProgressBarTree.Value = 0
            ProgressBarTree.Maximum = 0
            Label3.Text = "(of 0)"
            filtro = New BG3_CustomFilter_Class(Of T)(ArbolWorker, ObjectList) With {.Filter_Level1 = -1, .Filter_Level2 = "", .Textfilter = "", .SourceFilter = SourceFilter, .Deepfilter = False}
            filtro.Filter_Level1 = -1
            filtro.Filter_Level2 = ""
            filtro.Textfilter = ""
            filtro.Deepfilter = CheckBoxDeep.Checked
            filtro.DisplayFormat = SelectedDisplayformat
            filtro.ToRePaint = False
            filtro.ToRefilter = False
            filtro.ToReload = True
            If full = False AndAlso ComboBoxItems.SelectedIndex > 0 Then filtro.Filter_Level1 = ComboBoxItems.Items(ComboBoxItems.SelectedIndex).value
            If full = False AndAlso ComboBoxParent.SelectedIndex > 0 Then filtro.Filter_Level2 = ComboBoxParent.Items(ComboBoxParent.SelectedIndex).value
            If full = False AndAlso TextBoxFilter.Text <> "" Then filtro.Textfilter = TextBoxFilter.Text : filtro.ToRefilter = True
            If full = False AndAlso Not IsNothing(SourceFilter) Then filtro.ToRefilter = True
            RaiseEvent InititatedTask(ArbolWorker, New DoWorkEventArgs(filtro))
            ArbolWorker.RunWorkerAsync(filtro)
        Catch ex As Exception
            Debugger.Break()
        End Try

    End Sub

    Private Sub Process_filter()
        If IsNothing(ObjectList) Then Exit Sub
        Old_Enabled = Enabled
        Enabled = False
        filtro.Filter_Level1 = -1
        filtro.Filter_Level2 = ""
        filtro.Textfilter = ""
        filtro.Deepfilter = CheckBoxDeep.Checked
        If ComboBoxItems.SelectedIndex <> -1 Then filtro.Filter_Level1 = ComboBoxItems.Items(ComboBoxItems.SelectedIndex).value
        If ComboBoxParent.SelectedIndex <> -1 Then filtro.Filter_Level2 = ComboBoxParent.Items(ComboBoxParent.SelectedIndex).value
        If Not IsNothing(TextBoxFilter.Text) Then filtro.Textfilter = TextBoxFilter.Text
        filtro.DisplayFormat = SelectedDisplayformat
        TreeView1.BeginUpdate()
        TreeView1.Nodes.Clear()
        TreeView1.EndUpdate()
        ArbolWorker.RunWorkerAsync(filtro)
    End Sub


    Public Sub ProcesoParaleloArbol_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        ProgressBarTree.Refresh()
        If e.Cancelled = True Then
        Else
            TreeView1.BeginUpdate()
            TreeView1.Nodes.AddRange(filtro.Roots.Where(Function(pf) pf.Nodes.Count > 0).ToArray)
            TreeView1.EndUpdate()
        End If
        TreeView1.EndUpdate()
        ProgressBarTree.Value = 0
        ProgressBarTree.Maximum = filtro.Elementos_Totales
        Label3.Text = "(of " + CLng(ProgressBarTree.Maximum).ToString("#,##0") + ")"
        Enabled = Old_Enabled
        RaiseEvent FinishedTask(sender, New RunWorkerCompletedEventArgs(filtro.Elementos_Totales, e.Error, e.Cancelled))
    End Sub
    Public Sub ProcesoParaleloArbol_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        ProgressBarTree.Maximum = e.UserState(1)
        ProgressBarTree.Value = Math.Min(e.UserState(0), e.UserState(1))
        Label3.Text = "(of " + CLng(e.UserState(1)).ToString("#,##0") + ")"
        Label3.Refresh()
        RaiseEvent TaskReported(sender, e)
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        RaiseEvent NodeSelected(sender, e)
    End Sub
    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        RaiseEvent NodeDoubleClicked(sender, e)
    End Sub
    Private Sub TreeView1_Itemdrag(sender As Object, e As ItemDragEventArgs) Handles TreeView1.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Copy)
    End Sub
    Private Sub ExpandAll_Click(sender As Object, e As EventArgs) Handles ExpandAll.Click
        TreeView1.BeginUpdate()
        TreeView1.ExpandAll()
        TreeView1.EndUpdate()
    End Sub

    Private Sub CollapseAll_Click(sender As Object, e As EventArgs) Handles CollapseAll.Click
        TreeView1.BeginUpdate()
        TreeView1.CollapseAll()
        TreeView1.EndUpdate()
    End Sub

    Private _detailsVisibles As Boolean = True
    Public Property DetailsVisibles As Boolean
        Get
            Return _detailsVisibles
        End Get
        Set(value As Boolean)
            _detailsVisibles = value
            If _detailsVisibles Then
                DetailsVisiblesOrNot.BackgroundImage = My.Resources.layer_visible_on
            Else
                DetailsVisiblesOrNot.BackgroundImage = My.Resources.layer_visible_off
            End If
        End Set
    End Property

    Private Sub Details_Click(sender As Object, e As EventArgs) Handles DetailsVisiblesOrNot.Click
        DetailsVisibles = Not DetailsVisibles
        RaiseEvent Hide_Unhide_Details(DetailsVisibles)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyName
        filtro.ToRePaint = True
        Process_filter()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        SelectedDisplayformat = BG3_Enum_DisplayFormat.Name_and_DisplayName
        filtro.ToRePaint = True
        Process_filter()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyDisplayName
        filtro.ToRePaint = True
        Process_filter()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        SelectedDisplayformat = BG3_Enum_DisplayFormat.DisplayName_and_Name
        filtro.ToRePaint = True
        Process_filter()
    End Sub
    Private Sub CopyMapkeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyMapkeyToolStripMenuItem.Click
        If Not IsNothing(TreeView1.SelectedNode) Then
            Dim obj = CType(TreeView1.SelectedNode, BG3_Custom_TreeNode_Linked_Class(Of T)).Objeto
            If Not IsNothing(obj) Then
                Clipboard.SetText(obj.MapKey)
            End If
        End If
    End Sub
    Private Sub CopyNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyNameToolStripMenuItem.Click
        If Not IsNothing(TreeView1.SelectedNode) Then
            Dim obj = CType(TreeView1.SelectedNode, BG3_Custom_TreeNode_Linked_Class(Of T)).Objeto
            If Not IsNothing(obj) Then
                Clipboard.SetText(obj.Name)
            End If
        End If
    End Sub
    Private Sub SourceDataToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles SourceDataToolStripMenuItem.DropDownOpening
        If Not IsNothing(TreeView1.SelectedNode) Then
            Dim obj = CType(TreeView1.SelectedNode, BG3_Custom_TreeNode_Linked_Class(Of T)).Objeto
            If Not IsNothing(obj) Then
                If Not IsNothing(obj.SourceOfResorce) Then
                    Try
                        PackToolStripMenuItem.Text = "Pack: " + obj.SourceOfResorce.Pak_Or_Folder
                        FileToolStripMenuItem.Text = "File: " + obj.SourceOfResorce.Filename_Relative
                        Exit Sub
                    Catch ex As Exception
                        PackToolStripMenuItem.Text = "Pack: Unknown"
                        FileToolStripMenuItem.Text = "File: Unknown"
                    End Try
                End If
            End If
        End If

        PackToolStripMenuItem.Text = "Pack: Unknown"
        FileToolStripMenuItem.Text = "File: Unknown"
    End Sub


    Private Sub ToolStripMenuItem1_DropDownOpening(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.DropDownOpening
        ToolStripMenuItem2.Checked = SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyName
        ToolStripMenuItem3.Checked = SelectedDisplayformat = BG3_Enum_DisplayFormat.Name_and_DisplayName
        ToolStripMenuItem4.Checked = SelectedDisplayformat = BG3_Enum_DisplayFormat.OnlyDisplayName
        ToolStripMenuItem5.Checked = SelectedDisplayformat = BG3_Enum_DisplayFormat.DisplayName_and_Name
    End Sub

    Public Event Hide_Unhide_Details(Show As Boolean)
    Public Event FinishedTask(sender As Object, e As RunWorkerCompletedEventArgs)
    Public Event InititatedTask(sender As Object, e As DoWorkEventArgs)
    Public Event TaskReported(sender As Object, e As ProgressChangedEventArgs)
    Public Event NodeSelected(sender As Object, e As TreeViewEventArgs)
    Public Event NodeDoubleClicked(sender As Object, e As EventArgs)
End Class

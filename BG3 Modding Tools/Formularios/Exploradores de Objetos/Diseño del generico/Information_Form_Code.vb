Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net
Imports System.Reflection.Metadata
Imports System.Runtime.CompilerServices
Imports System.Xml
Imports BG3_Modding_Tools.Funciones
Imports BG3_Modding_Tools.FuncionesHelpers
Imports LSLib.Granny
Imports LSLib.LS.Enums

Public Class Information_Form_Code
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DoubleBuffered = True
    End Sub
    Private parentcontrol As Object = Nothing

    Public Sub New(ByRef MdiParent As Main, ObjectExplorer As Explorer_Form_Templates)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        Me.Text = "Template info from " + ObjectExplorer.Text
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        AddHandler ObjectExplorer.FormClosing, AddressOf Explorer_Closing
        AddHandler ObjectExplorer.Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
        AddHandler ObjectExplorer.TreeNodeSelected, AddressOf Node_Selected
        parentcontrol = ObjectExplorer
        Pone_info(Nothing)
    End Sub
    Public Sub New(ByRef MdiParent As Main, ByRef ExplorerControl As BG3Explorer_Templates)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        Me.Text = "Template info from " + ExplorerControl.ParentForm.Text
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        AddHandler ExplorerControl.ParentForm.FormClosing, AddressOf Explorer_Closing
        AddHandler ExplorerControl.Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
        AddHandler ExplorerControl.NodeSelected, AddressOf Node_Selected
        parentcontrol = ExplorerControl
        Pone_info(Nothing)
    End Sub
    Public Sub New(ByRef MdiParent As Main, ByRef ExplorerControl As BG3Explorer_Stats)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        Me.Text = "Stats info from " + ExplorerControl.ParentForm.Text
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        AddHandler ExplorerControl.ParentForm.FormClosing, AddressOf Explorer_Closing
        AddHandler ExplorerControl.Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
        AddHandler ExplorerControl.NodeSelected, AddressOf Node_Selected
        parentcontrol = ExplorerControl
        Pone_info(Nothing)
    End Sub
    Public Sub New(ByRef MdiParent As Main, ByRef ExplorerControl As BG3Explorer_TreasureTables)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        Me.Text = "Treasure table info from " + ExplorerControl.ParentForm.Text
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        AddHandler ExplorerControl.ParentForm.FormClosing, AddressOf Explorer_Closing
        AddHandler ExplorerControl.Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
        AddHandler ExplorerControl.NodeSelected, AddressOf Node_Selected
        parentcontrol = ExplorerControl
        Pone_info(Nothing)
    End Sub

    Public Sub New(ByRef MdiParent As Main, ObjectExplorer As Explorer_Form_Flags_and_Tags)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        Me.Text = "Flags and tags info from " + ObjectExplorer.Text
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        AddHandler ObjectExplorer.FormClosing, AddressOf Explorer_Closing
        AddHandler ObjectExplorer.Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
        AddHandler ObjectExplorer.TreeNodeSelected, AddressOf Node_Selected
        parentcontrol = ObjectExplorer
        Pone_info(Nothing)
    End Sub
    Public Sub New(ByRef MdiParent As Main, ObjectExplorer As Explorer_Form_VisualTemplates)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        Me.Text = "Visual bank info from " + ObjectExplorer.Text
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        AddHandler ObjectExplorer.FormClosing, AddressOf Explorer_Closing
        AddHandler ObjectExplorer.Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
        AddHandler ObjectExplorer.TreeNodeSelected, AddressOf Node_Selected
        parentcontrol = ObjectExplorer
        Pone_info(Nothing)
    End Sub

    Public Sub New(ByRef MdiParent As Main, ObjectExplorer As Explorer_Form_Stats)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        Me.Text = "Stats info from " + ObjectExplorer.Text
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        AddHandler ObjectExplorer.FormClosing, AddressOf Explorer_Closing
        AddHandler ObjectExplorer.Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
        AddHandler ObjectExplorer.TreeNodeSelected, AddressOf Node_Selected
        parentcontrol = ObjectExplorer
        Pone_info(Nothing)
    End Sub
    Public Sub New(ByRef MdiParent As Main, ObjectExplorer As Explorer_Form_TreasureTables)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.MdiParent = MdiParent
        Me.Text = "Treasure table info from " + ObjectExplorer.Text
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        AddHandler ObjectExplorer.FormClosing, AddressOf Explorer_Closing
        AddHandler ObjectExplorer.Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
        AddHandler ObjectExplorer.TreeNodeSelected, AddressOf Node_Selected
        parentcontrol = ObjectExplorer
        Pone_info(Nothing)
    End Sub

    Public Overridable Sub Node_Selected(sender As Object, e As TreeViewEventArgs)
        Pone_info(CType(e.Node, Object).objeto)
    End Sub

    Private Sub Explorer_Closing(sender As Object, e As FormClosingEventArgs)
        Me.Close()
    End Sub
    Public Overridable Sub Explorer_Hide_Unhide(Show As Boolean)
        Me.Visible = Show
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Public Sub BackgroundWork_WorkStarted()
        Pone_info(Nothing)
    End Sub
    Public Sub BackgroundWork_Finished()
        Pone_info(Nothing)
    End Sub
    Private Sub ObjectsTree_InititatedTask(sender As Object, e As DoWorkEventArgs)
        Pone_info(Nothing)
    End Sub
    Private Sub ObjectsTree_FinishedTask(sender As Object, e As RunWorkerCompletedEventArgs)
        Pone_info(Nothing)
    End Sub
    Private Sub BackgroundWork_Report(sender As Object, e As ProgressChangedEventArgs)
        If IsNothing(MdiParent) Then Exit Sub
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
            Case sender Is CType(MdiParent, Main).CacheWorker
        End Select
    End Sub
    Private Sub BackGround_SingleTaskStart(sender As Object, e As DoWorkEventArgs)
        If IsNothing(MdiParent) Then Exit Sub
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
            Case sender Is CType(MdiParent, Main).CacheWorker
        End Select
    End Sub
    Private Sub BackGround_SingleTaskEnd(sender As Object, e As RunWorkerCompletedEventArgs)
        If IsNothing(MdiParent) Then Exit Sub
        Select Case True
            Case sender Is CType(MdiParent, Main).ProcessWorker
            Case sender Is CType(MdiParent, Main).CacheWorker
        End Select
    End Sub
    Public Overridable Sub Habilita_deshabilita(Habilita As Boolean)
        Pone_info(Nothing)
    End Sub
    Public Overridable Sub Pone_info(obj As Object)

    End Sub

    Private Sub Information_Form_Code_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Select Case parentcontrol.GetType
                Case GetType(Explorer_Form_Templates)
                    CType(parentcontrol, Explorer_Form_Templates).ObjectsTree.DetailsVisibles = False
                Case GetType(BG3Explorer_Templates)
                    CType(parentcontrol, BG3Explorer_Templates).DetailsVisibles = False
                Case GetType(Explorer_Form_Stats)
                    CType(parentcontrol, Explorer_Form_Stats).ObjectsTree.DetailsVisibles = False
                Case GetType(BG3Explorer_Stats)
                    CType(parentcontrol, BG3Explorer_Stats).DetailsVisibles = False
                Case GetType(Explorer_Form_Flags_and_Tags)
                    CType(parentcontrol, Explorer_Form_Flags_and_Tags).ObjectsTree.DetailsVisibles = False
                Case GetType(Explorer_Form_VisualTemplates)
                    CType(parentcontrol, Explorer_Form_VisualTemplates).ObjectsTree.DetailsVisibles = False
                Case GetType(Explorer_Form_TreasureTables)
                    CType(parentcontrol, Explorer_Form_TreasureTables).ObjectsTree.DetailsVisibles = False
                Case Else
                    Debugger.Break()
            End Select
            Me.Hide()
            Exit Sub
        End If
        RemoveHandler CType(MdiParent, Main).BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted
        RemoveHandler CType(MdiParent, Main).BackGroundWorkFinished, AddressOf BackgroundWork_Finished
        RemoveHandler CType(MdiParent, Main).BackGroundReport, AddressOf BackgroundWork_Report
        RemoveHandler CType(MdiParent, Main).BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd
        RemoveHandler CType(MdiParent, Main).BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart
        Select Case parentcontrol.GetType
            Case GetType(Explorer_Form_Templates)
                RemoveHandler CType(parentcontrol, Explorer_Form_Templates).FormClosing, AddressOf Explorer_Closing
                RemoveHandler CType(parentcontrol, Explorer_Form_Templates).Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
                RemoveHandler CType(parentcontrol, Explorer_Form_Templates).TreeNodeSelected, AddressOf Node_Selected
            Case GetType(BG3Explorer_Templates)
                RemoveHandler CType(parentcontrol, BG3Explorer_Templates).ParentForm.FormClosing, AddressOf Explorer_Closing
                RemoveHandler CType(parentcontrol, BG3Explorer_Templates).Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
                RemoveHandler CType(parentcontrol, BG3Explorer_Templates).NodeSelected, AddressOf Node_Selected
            Case GetType(Explorer_Form_Stats)
                RemoveHandler CType(parentcontrol, Explorer_Form_Stats).FormClosing, AddressOf Explorer_Closing
                RemoveHandler CType(parentcontrol, Explorer_Form_Stats).Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
                RemoveHandler CType(parentcontrol, Explorer_Form_Stats).TreeNodeSelected, AddressOf Node_Selected
            Case GetType(BG3Explorer_Stats)
                RemoveHandler CType(parentcontrol, BG3Explorer_Stats).ParentForm.FormClosing, AddressOf Explorer_Closing
                RemoveHandler CType(parentcontrol, BG3Explorer_Stats).Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
                RemoveHandler CType(parentcontrol, BG3Explorer_Stats).NodeSelected, AddressOf Node_Selected
            Case GetType(Explorer_Form_Flags_and_Tags)
                RemoveHandler CType(parentcontrol, Explorer_Form_Flags_and_Tags).FormClosing, AddressOf Explorer_Closing
                RemoveHandler CType(parentcontrol, Explorer_Form_Flags_and_Tags).Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
                RemoveHandler CType(parentcontrol, Explorer_Form_Flags_and_Tags).TreeNodeSelected, AddressOf Node_Selected
            Case GetType(Explorer_Form_VisualTemplates)
                RemoveHandler CType(parentcontrol, Explorer_Form_VisualTemplates).FormClosing, AddressOf Explorer_Closing
                RemoveHandler CType(parentcontrol, Explorer_Form_VisualTemplates).Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
                RemoveHandler CType(parentcontrol, Explorer_Form_VisualTemplates).TreeNodeSelected, AddressOf Node_Selected
            Case GetType(Explorer_Form_TreasureTables)
                RemoveHandler CType(parentcontrol, Explorer_Form_TreasureTables).FormClosing, AddressOf Explorer_Closing
                RemoveHandler CType(parentcontrol, Explorer_Form_TreasureTables).Hide_Unhide_Details, AddressOf Explorer_Hide_Unhide
                RemoveHandler CType(parentcontrol, Explorer_Form_TreasureTables).TreeNodeSelected, AddressOf Node_Selected
            Case Else
                Debugger.Break()
        End Select


        parentcontrol = Nothing
    End Sub
End Class

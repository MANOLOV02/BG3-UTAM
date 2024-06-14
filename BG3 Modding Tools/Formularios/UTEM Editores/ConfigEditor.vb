Imports System.Collections.Concurrent
Imports System.DirectoryServices
Imports System.Runtime.InteropServices.Marshalling
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports Accessibility
Imports LSLib.Granny
Imports LSLib.Granny.Model
Imports LSLib.LS
Imports LSLib.LS.Story

Public Class Config_Editor
    Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public HandledStats As New List(Of String)
    Public HandledAttributes As New List(Of String)
    Public HandledNodes As New List(Of String)

    Public Property ActiveModSource As BG3_Pak_SourceOfResource_Class
    Protected Overridable Property SelectedConfig As BG3_Obj_Stats_Class

    Protected Overridable Property Template_guid As String = Funciones.NewGUID(False)
    Public Sub New(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        MyBase.New(MdiParent)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Initialize(MdiParent, Source)
        Me.DoubleBuffered = True

    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Protected Sub Initialize(ByRef MdiParent As Main, Source As BG3_Pak_SourceOfResource_Class)
        Me.DoubleBuffered = True
        Me.MinimumSize = New Size(Me.Width, Me.Height)
        Me.MaximumSize = New Size(2000, Me.Height)
        Me.MdiParent = MdiParent
        AddHandler MdiParent.BackGroundWorkstarted, AddressOf BackgroundWork_WorkStarted_Sub
        AddHandler MdiParent.BackGroundWorkFinished, AddressOf BackgroundWork_Finished_Sub
        AddHandler MdiParent.BackGroundReport, AddressOf BackgroundWork_Report_SuB
        AddHandler MdiParent.BackGround_SingleTaskEnd, AddressOf BackGround_SingleTaskEnd_sub
        AddHandler MdiParent.BackGround_SingleTaskStart, AddressOf BackGround_SingleTaskStart_sub
        ActiveModSource = New BG3_Pak_SourceOfResource_Class(Source.Pak_Or_Folder, MdiParent.ActiveMod.CurrentMod.StatsDataFilePath, BG3_Enum_Package_Type.UTAM_Mod)


        Habilita_Edicion_Botones(False)
        'BG3Editor_Complex_Localization1.Link_Controls({BG3Editor_Template_DisplayName1, BG3Editor_Template_Description1, BG3Editor_Template_TechnicalDescription1})
        Initialize_Specifics()
    End Sub

    Protected Overridable Sub Initialize_Specifics()
        If FuncionesHelpers.GameEngine.Utamstats.Where(Function(pf) pf.Type = BG3_Enum_StatType.ConfigKeys).Any Then
            SelectedConfig = FuncionesHelpers.GameEngine.Utamstats.Where(Function(pf) pf.Type = BG3_Enum_StatType.ConfigKeys).First
        Else
            Dim stobj = New BG3_Obj_Stats_Class(ActiveModSource, "DataKeys") With {.Type = BG3_Enum_StatType.ConfigKeys, .[Using] = ""}
            SelectedConfig = FuncionesHelpers.GameEngine.ProcessedStatList.Manage_Overrides(stobj)
        End If
        Habilita_Edicion_Botones(False)
    End Sub

    ' Procesos Comunes Editores
    Private Sub Habilita_Edicion_Botones(Edicion As Boolean)
        Button1.Enabled = Not Edicion
        Button2.Enabled = Edicion
        Button3.Enabled = Edicion
        Button4.Enabled = Edicion
        BG3Editor_Complex_Advanced_Stats1.ReadOnly = Not Edicion
        Habilita_Edicion_Botones_Specific(Edicion)
        Process_Selection_Change()
    End Sub
    Protected Overridable Sub Habilita_Edicion_Botones_Specific(Edicion As Boolean)
    End Sub


    Protected Clone_Stat_Name As String
    Protected Clone_Stat_Using As String
    Protected Clone_Nuevonod As LSLib.LS.Node

    Private Sub Capture_Edit()
        Process_Edit()
    End Sub
    Private Sub Capture_Cancel()
        Process_Cancel()
    End Sub
    Private Sub Capture_Save()
        Process_Save_Edits()
    End Sub
    Private Sub Capture_Delete()
        Process_delete()
    End Sub
    Private Sub Process_delete()
    End Sub

    Private Sub Process_Selection_Change()
        If Not IsNothing(SelectedConfig) Then
            BG3Editor_Complex_Advanced_Stats1.Read(SelectedConfig)
        Else
            BG3Editor_Complex_Advanced_Stats1.Clear()
        End If
    End Sub
    Protected Overridable Sub Process_Save_Edits_Specifics()
    End Sub

    Private Sub Process_Save_Edits()
        Process_Save_Edits_Specifics()
        Process_Save_Objetos()
        Process_Save_Final()
        Habilita_Edicion_Botones(False)
    End Sub

    Protected Overridable Sub Process_Save_Objetos_Specifics()

    End Sub
    Private Sub Process_Save_Objetos()
        SelectedConfig.Write_Data()
        Process_Save_Objetos_Specifics()
    End Sub
    Private Sub Process_Save_Final()
    End Sub

    Protected Overridable Sub Process_Edit_Specifics()
    End Sub

    Private Sub Process_Edit()
        SelectedConfig.Edit_start()
        Process_Edit_Specifics()
        Habilita_Edicion_Botones(True)
    End Sub
    Protected Overridable Sub Process_Cancel_Specifics()
    End Sub

    Private Sub Process_Cancel()
        SelectedConfig.Cancel_Edit()
        Process_Cancel_Specifics()
        Habilita_Edicion_Botones(False)
    End Sub

    Private Sub Generic_Editor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Button1.Enabled = False Then
            MsgBox("Save or cancel changes before closing", vbOKOnly, "Changes not saved")
            e.Cancel = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Capture_Edit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SelectedConfig.Data.Clear()
        BG3Editor_Complex_Advanced_Stats1.Read(SelectedConfig)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CType(Me.MdiParent, Main).ChangedMod()
        Capture_Save()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Capture_Cancel()
    End Sub
End Class
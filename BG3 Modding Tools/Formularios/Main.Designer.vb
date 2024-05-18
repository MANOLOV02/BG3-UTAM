<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        MenuStrip1 = New MenuStrip()
        ProcessAndNavigateObjectsToolStripMenuItem = New ToolStripMenuItem()
        ProcesserToolStripMenu = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        BackgroundWorkToolStripMenuItem = New ToolStripMenuItem()
        MenuProcessPackBackground = New ToolStripMenuItem()
        VanillaGameToolStripMenuItem = New ToolStripMenuItem()
        GamePlusModsToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        LoadCacheToolStripMenuItem1 = New ToolStripMenuItem()
        MenuClearCacheBackground = New ToolStripMenuItem()
        ToolsToolStripMenuItem = New ToolStripMenuItem()
        ObjectsExplorerToolStripMenuItem = New ToolStripMenuItem()
        AllTemplatesToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        ItemTemplatesToolStripMenuItem = New ToolStripMenuItem()
        CharacterTemplatesToolStripMenuItem = New ToolStripMenuItem()
        StatsExplorerToolStripMenuItem = New ToolStripMenuItem()
        TrasureTablesExplorerToolStripMenuItem = New ToolStripMenuItem()
        ObjectInformationToolStripMenuItem = New ToolStripMenuItem()
        FlagsExplorerToolStripMenuItem = New ToolStripMenuItem()
        VisualBankExplorerToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator5 = New ToolStripSeparator()
        OpenDetailsWindowsAlsoToolStripMenuItem = New ToolStripMenuItem()
        ModdsToolStripMenuItem = New ToolStripMenuItem()
        NewToolStripMenuItem = New ToolStripMenuItem()
        LoadToolStripMenuItem = New ToolStripMenuItem()
        ToolsToolStripMenuItem1 = New ToolStripMenuItem()
        ArmorsToolStripMenuItem = New ToolStripMenuItem()
        ContainersToolStripMenuItem = New ToolStripMenuItem()
        DyesToolStripMenuItem = New ToolStripMenuItem()
        FoldersToolStripMenuItem = New ToolStripMenuItem()
        UTAMModsToolStripMenuItem = New ToolStripMenuItem()
        UTAMCacheToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        BG3GameToolStripMenuItem = New ToolStripMenuItem()
        BG3ModsToolStripMenuItem = New ToolStripMenuItem()
        LaunchGameToolStripMenuItem = New ToolStripMenuItem()
        AboutAndAcknoulegementsToolStripMenuItem = New ToolStripMenuItem()
        StatusStrip1 = New StatusStrip()
        ObjectsStatusLabel = New ToolStripStatusLabel()
        ToolStripProgressBar = New ToolStripProgressBar()
        CancellButton = New ToolStripStatusLabel()
        InfoIcon = New ToolStripStatusLabel()
        LabelNumpacks = New ToolStripStatusLabel()
        LabeLNumObjects = New ToolStripStatusLabel()
        LabelNumStats = New ToolStripStatusLabel()
        LabelTreasureCount = New ToolStripStatusLabel()
        VisualsCount = New ToolStripStatusLabel()
        FlagsandTagsCount = New ToolStripStatusLabel()
        IconsCount = New ToolStripStatusLabel()
        AssetsCount = New ToolStripStatusLabel()
        LabelNumTraslations = New ToolStripStatusLabel()
        LocalizationButton = New ToolStripDropDownButton()
        WeaponsToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {ProcessAndNavigateObjectsToolStripMenuItem, ToolsToolStripMenuItem, ModdsToolStripMenuItem, ToolsToolStripMenuItem1, FoldersToolStripMenuItem, LaunchGameToolStripMenuItem, AboutAndAcknoulegementsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1793, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ProcessAndNavigateObjectsToolStripMenuItem
        ' 
        ProcessAndNavigateObjectsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ProcesserToolStripMenu, ToolStripSeparator1, BackgroundWorkToolStripMenuItem})
        ProcessAndNavigateObjectsToolStripMenuItem.Name = "ProcessAndNavigateObjectsToolStripMenuItem"
        ProcessAndNavigateObjectsToolStripMenuItem.Size = New Size(86, 20)
        ProcessAndNavigateObjectsToolStripMenuItem.Text = "Paks process"
        ' 
        ' ProcesserToolStripMenu
        ' 
        ProcesserToolStripMenu.Name = "ProcesserToolStripMenu"
        ProcesserToolStripMenu.Size = New Size(167, 22)
        ProcesserToolStripMenu.Text = "Processer"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(164, 6)
        ' 
        ' BackgroundWorkToolStripMenuItem
        ' 
        BackgroundWorkToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {MenuProcessPackBackground, ToolStripSeparator2, LoadCacheToolStripMenuItem1, MenuClearCacheBackground})
        BackgroundWorkToolStripMenuItem.Name = "BackgroundWorkToolStripMenuItem"
        BackgroundWorkToolStripMenuItem.Size = New Size(167, 22)
        BackgroundWorkToolStripMenuItem.Text = "Background work"
        ' 
        ' MenuProcessPackBackground
        ' 
        MenuProcessPackBackground.DropDownItems.AddRange(New ToolStripItem() {VanillaGameToolStripMenuItem, GamePlusModsToolStripMenuItem})
        MenuProcessPackBackground.Name = "MenuProcessPackBackground"
        MenuProcessPackBackground.Size = New Size(168, 22)
        MenuProcessPackBackground.Text = "Process from .pak"
        ' 
        ' VanillaGameToolStripMenuItem
        ' 
        VanillaGameToolStripMenuItem.Name = "VanillaGameToolStripMenuItem"
        VanillaGameToolStripMenuItem.Size = New Size(163, 22)
        VanillaGameToolStripMenuItem.Text = "Vanilla game"
        ' 
        ' GamePlusModsToolStripMenuItem
        ' 
        GamePlusModsToolStripMenuItem.Name = "GamePlusModsToolStripMenuItem"
        GamePlusModsToolStripMenuItem.Size = New Size(163, 22)
        GamePlusModsToolStripMenuItem.Text = "Game plus mods"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(165, 6)
        ' 
        ' LoadCacheToolStripMenuItem1
        ' 
        LoadCacheToolStripMenuItem1.Name = "LoadCacheToolStripMenuItem1"
        LoadCacheToolStripMenuItem1.Size = New Size(168, 22)
        LoadCacheToolStripMenuItem1.Text = "Load cache"
        ' 
        ' MenuClearCacheBackground
        ' 
        MenuClearCacheBackground.Name = "MenuClearCacheBackground"
        MenuClearCacheBackground.Size = New Size(168, 22)
        MenuClearCacheBackground.Text = "Clear cache"
        ' 
        ' ToolsToolStripMenuItem
        ' 
        ToolsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ObjectsExplorerToolStripMenuItem, StatsExplorerToolStripMenuItem, TrasureTablesExplorerToolStripMenuItem, ObjectInformationToolStripMenuItem, FlagsExplorerToolStripMenuItem, VisualBankExplorerToolStripMenuItem, ToolStripSeparator5, OpenDetailsWindowsAlsoToolStripMenuItem})
        ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        ToolsToolStripMenuItem.Size = New Size(112, 20)
        ToolsToolStripMenuItem.Text = "Objects exploring"
        ' 
        ' ObjectsExplorerToolStripMenuItem
        ' 
        ObjectsExplorerToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AllTemplatesToolStripMenuItem, ToolStripSeparator3, ItemTemplatesToolStripMenuItem, CharacterTemplatesToolStripMenuItem})
        ObjectsExplorerToolStripMenuItem.Name = "ObjectsExplorerToolStripMenuItem"
        ObjectsExplorerToolStripMenuItem.Size = New Size(216, 22)
        ObjectsExplorerToolStripMenuItem.Text = "Templates explorer"
        ' 
        ' AllTemplatesToolStripMenuItem
        ' 
        AllTemplatesToolStripMenuItem.Name = "AllTemplatesToolStripMenuItem"
        AllTemplatesToolStripMenuItem.Size = New Size(180, 22)
        AllTemplatesToolStripMenuItem.Text = "All templates"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(177, 6)
        ' 
        ' ItemTemplatesToolStripMenuItem
        ' 
        ItemTemplatesToolStripMenuItem.Name = "ItemTemplatesToolStripMenuItem"
        ItemTemplatesToolStripMenuItem.Size = New Size(180, 22)
        ItemTemplatesToolStripMenuItem.Text = "Item templates"
        ' 
        ' CharacterTemplatesToolStripMenuItem
        ' 
        CharacterTemplatesToolStripMenuItem.Name = "CharacterTemplatesToolStripMenuItem"
        CharacterTemplatesToolStripMenuItem.Size = New Size(180, 22)
        CharacterTemplatesToolStripMenuItem.Text = "Character templates"
        ' 
        ' StatsExplorerToolStripMenuItem
        ' 
        StatsExplorerToolStripMenuItem.Name = "StatsExplorerToolStripMenuItem"
        StatsExplorerToolStripMenuItem.Size = New Size(216, 22)
        StatsExplorerToolStripMenuItem.Text = "Stats explorer"
        ' 
        ' TrasureTablesExplorerToolStripMenuItem
        ' 
        TrasureTablesExplorerToolStripMenuItem.Name = "TrasureTablesExplorerToolStripMenuItem"
        TrasureTablesExplorerToolStripMenuItem.Size = New Size(216, 22)
        TrasureTablesExplorerToolStripMenuItem.Text = "Treasure tables explorer"
        ' 
        ' ObjectInformationToolStripMenuItem
        ' 
        ObjectInformationToolStripMenuItem.Name = "ObjectInformationToolStripMenuItem"
        ObjectInformationToolStripMenuItem.Size = New Size(216, 22)
        ObjectInformationToolStripMenuItem.Text = "Icon explorer"
        ' 
        ' FlagsExplorerToolStripMenuItem
        ' 
        FlagsExplorerToolStripMenuItem.Name = "FlagsExplorerToolStripMenuItem"
        FlagsExplorerToolStripMenuItem.Size = New Size(216, 22)
        FlagsExplorerToolStripMenuItem.Text = "Flags && tags explorer"
        ' 
        ' VisualBankExplorerToolStripMenuItem
        ' 
        VisualBankExplorerToolStripMenuItem.Name = "VisualBankExplorerToolStripMenuItem"
        VisualBankExplorerToolStripMenuItem.Size = New Size(216, 22)
        VisualBankExplorerToolStripMenuItem.Text = "Visual bank explorer"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(213, 6)
        ' 
        ' OpenDetailsWindowsAlsoToolStripMenuItem
        ' 
        OpenDetailsWindowsAlsoToolStripMenuItem.Checked = True
        OpenDetailsWindowsAlsoToolStripMenuItem.CheckState = CheckState.Checked
        OpenDetailsWindowsAlsoToolStripMenuItem.Name = "OpenDetailsWindowsAlsoToolStripMenuItem"
        OpenDetailsWindowsAlsoToolStripMenuItem.Size = New Size(216, 22)
        OpenDetailsWindowsAlsoToolStripMenuItem.Text = "Open with details windows"
        ' 
        ' ModdsToolStripMenuItem
        ' 
        ModdsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NewToolStripMenuItem, LoadToolStripMenuItem})
        ModdsToolStripMenuItem.Enabled = False
        ModdsToolStripMenuItem.Name = "ModdsToolStripMenuItem"
        ModdsToolStripMenuItem.Size = New Size(44, 20)
        ModdsToolStripMenuItem.Text = "Mod"
        ' 
        ' NewToolStripMenuItem
        ' 
        NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        NewToolStripMenuItem.Size = New Size(180, 22)
        NewToolStripMenuItem.Text = "New"
        ' 
        ' LoadToolStripMenuItem
        ' 
        LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        LoadToolStripMenuItem.Size = New Size(180, 22)
        LoadToolStripMenuItem.Text = "Load"
        ' 
        ' ToolsToolStripMenuItem1
        ' 
        ToolsToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {ArmorsToolStripMenuItem, ContainersToolStripMenuItem, DyesToolStripMenuItem, WeaponsToolStripMenuItem})
        ToolsToolStripMenuItem1.Enabled = False
        ToolsToolStripMenuItem1.Name = "ToolsToolStripMenuItem1"
        ToolsToolStripMenuItem1.Size = New Size(46, 20)
        ToolsToolStripMenuItem1.Text = "Tools"
        ' 
        ' ArmorsToolStripMenuItem
        ' 
        ArmorsToolStripMenuItem.Name = "ArmorsToolStripMenuItem"
        ArmorsToolStripMenuItem.Size = New Size(180, 22)
        ArmorsToolStripMenuItem.Text = "Armors"
        ' 
        ' ContainersToolStripMenuItem
        ' 
        ContainersToolStripMenuItem.Name = "ContainersToolStripMenuItem"
        ContainersToolStripMenuItem.Size = New Size(180, 22)
        ContainersToolStripMenuItem.Text = "Containers"
        ' 
        ' DyesToolStripMenuItem
        ' 
        DyesToolStripMenuItem.Name = "DyesToolStripMenuItem"
        DyesToolStripMenuItem.Size = New Size(180, 22)
        DyesToolStripMenuItem.Text = "Dyes"
        ' 
        ' FoldersToolStripMenuItem
        ' 
        FoldersToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UTAMModsToolStripMenuItem, UTAMCacheToolStripMenuItem, ToolStripSeparator4, BG3GameToolStripMenuItem, BG3ModsToolStripMenuItem})
        FoldersToolStripMenuItem.Name = "FoldersToolStripMenuItem"
        FoldersToolStripMenuItem.Size = New Size(57, 20)
        FoldersToolStripMenuItem.Text = "Folders"
        ' 
        ' UTAMModsToolStripMenuItem
        ' 
        UTAMModsToolStripMenuItem.Name = "UTAMModsToolStripMenuItem"
        UTAMModsToolStripMenuItem.Size = New Size(140, 22)
        UTAMModsToolStripMenuItem.Text = "UTAM mods"
        ' 
        ' UTAMCacheToolStripMenuItem
        ' 
        UTAMCacheToolStripMenuItem.Name = "UTAMCacheToolStripMenuItem"
        UTAMCacheToolStripMenuItem.Size = New Size(140, 22)
        UTAMCacheToolStripMenuItem.Text = "UTAM cache"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(137, 6)
        ' 
        ' BG3GameToolStripMenuItem
        ' 
        BG3GameToolStripMenuItem.Name = "BG3GameToolStripMenuItem"
        BG3GameToolStripMenuItem.Size = New Size(140, 22)
        BG3GameToolStripMenuItem.Text = "Game bin"
        ' 
        ' BG3ModsToolStripMenuItem
        ' 
        BG3ModsToolStripMenuItem.Name = "BG3ModsToolStripMenuItem"
        BG3ModsToolStripMenuItem.Size = New Size(140, 22)
        BG3ModsToolStripMenuItem.Text = "Game mods"
        ' 
        ' LaunchGameToolStripMenuItem
        ' 
        LaunchGameToolStripMenuItem.Enabled = False
        LaunchGameToolStripMenuItem.Name = "LaunchGameToolStripMenuItem"
        LaunchGameToolStripMenuItem.Size = New Size(91, 20)
        LaunchGameToolStripMenuItem.Text = "Launch game"
        ' 
        ' AboutAndAcknoulegementsToolStripMenuItem
        ' 
        AboutAndAcknoulegementsToolStripMenuItem.Name = "AboutAndAcknoulegementsToolStripMenuItem"
        AboutAndAcknoulegementsToolStripMenuItem.Size = New Size(61, 20)
        AboutAndAcknoulegementsToolStripMenuItem.Text = "About..."
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {ObjectsStatusLabel, ToolStripProgressBar, CancellButton, InfoIcon, LabelNumpacks, LabeLNumObjects, LabelNumStats, LabelTreasureCount, VisualsCount, FlagsandTagsCount, IconsCount, AssetsCount, LabelNumTraslations, LocalizationButton})
        StatusStrip1.Location = New Point(0, 840)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1793, 24)
        StatusStrip1.TabIndex = 2
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' ObjectsStatusLabel
        ' 
        ObjectsStatusLabel.ImageAlign = ContentAlignment.MiddleLeft
        ObjectsStatusLabel.Name = "ObjectsStatusLabel"
        ObjectsStatusLabel.Size = New Size(156, 19)
        ObjectsStatusLabel.Text = "Game objects not processed"
        ' 
        ' ToolStripProgressBar
        ' 
        ToolStripProgressBar.Name = "ToolStripProgressBar"
        ToolStripProgressBar.Size = New Size(100, 18)
        ' 
        ' CancellButton
        ' 
        CancellButton.BorderSides = ToolStripStatusLabelBorderSides.Left Or ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Right Or ToolStripStatusLabelBorderSides.Bottom
        CancellButton.BorderStyle = Border3DStyle.RaisedInner
        CancellButton.ImageAlign = ContentAlignment.MiddleLeft
        CancellButton.Name = "CancellButton"
        CancellButton.Size = New Size(47, 19)
        CancellButton.Text = "Cancel"
        CancellButton.Visible = False
        ' 
        ' InfoIcon
        ' 
        InfoIcon.Name = "InfoIcon"
        InfoIcon.Size = New Size(29, 19)
        InfoIcon.Text = "(IM)"
        ' 
        ' LabelNumpacks
        ' 
        LabelNumpacks.Name = "LabelNumpacks"
        LabelNumpacks.Size = New Size(54, 19)
        LabelNumpacks.Text = "Packs (0)"
        ' 
        ' LabeLNumObjects
        ' 
        LabeLNumObjects.Name = "LabeLNumObjects"
        LabeLNumObjects.Size = New Size(64, 19)
        LabeLNumObjects.Text = "Objects (0)"
        ' 
        ' LabelNumStats
        ' 
        LabelNumStats.Name = "LabelNumStats"
        LabelNumStats.Size = New Size(49, 19)
        LabelNumStats.Text = "Stats (0)"
        ' 
        ' LabelTreasureCount
        ' 
        LabelTreasureCount.Name = "LabelTreasureCount"
        LabelTreasureCount.Size = New Size(101, 19)
        LabelTreasureCount.Text = "Treasure tables (0)"
        ' 
        ' VisualsCount
        ' 
        VisualsCount.Name = "VisualsCount"
        VisualsCount.Size = New Size(89, 19)
        VisualsCount.Text = "Visual Banks (0)"
        ' 
        ' FlagsandTagsCount
        ' 
        FlagsandTagsCount.Name = "FlagsandTagsCount"
        FlagsandTagsCount.Size = New Size(100, 19)
        FlagsandTagsCount.Text = "Flags and Tags (0)"
        ' 
        ' IconsCount
        ' 
        IconsCount.Name = "IconsCount"
        IconsCount.Size = New Size(35, 19)
        IconsCount.Text = "Icons"
        ' 
        ' AssetsCount
        ' 
        AssetsCount.Name = "AssetsCount"
        AssetsCount.Size = New Size(57, 19)
        AssetsCount.Text = "Assets (0)"
        ' 
        ' LabelNumTraslations
        ' 
        LabelNumTraslations.Name = "LabelNumTraslations"
        LabelNumTraslations.Size = New Size(92, 19)
        LabelNumTraslations.Text = "Localizations (0)"
        ' 
        ' LocalizationButton
        ' 
        LocalizationButton.DisplayStyle = ToolStripItemDisplayStyle.Text
        LocalizationButton.Image = CType(resources.GetObject("LocalizationButton.Image"), Image)
        LocalizationButton.ImageTransparentColor = Color.Magenta
        LocalizationButton.Name = "LocalizationButton"
        LocalizationButton.Size = New Size(83, 22)
        LocalizationButton.Text = "Localization"
        ' 
        ' WeaponsToolStripMenuItem
        ' 
        WeaponsToolStripMenuItem.Name = "WeaponsToolStripMenuItem"
        WeaponsToolStripMenuItem.Size = New Size(180, 22)
        WeaponsToolStripMenuItem.Text = "Weapons"
        ' 
        ' Main
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1793, 864)
        Controls.Add(StatusStrip1)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip1
        Name = "Main"
        StartPosition = FormStartPosition.CenterScreen
        Text = "BG3 UTAM (Ultimate Tool for Amateur Modders)"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ProcessAndNavigateObjectsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModdsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutAndAcknoulegementsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ObjectsStatusLabel As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar As ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ProcesserToolStripMenu As ToolStripMenuItem
    Friend WithEvents BackgroundWorkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuProcessPackBackground As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents LoadCacheToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MenuClearCacheBackground As ToolStripMenuItem
    Friend WithEvents LabeLNumObjects As ToolStripStatusLabel
    Friend WithEvents LabelNumTraslations As ToolStripStatusLabel
    Friend WithEvents LabelNumStats As ToolStripStatusLabel
    Friend WithEvents LabelNumpacks As ToolStripStatusLabel
    Friend WithEvents InfoIcon As ToolStripStatusLabel
    Friend WithEvents VanillaGameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GamePlusModsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancellButton As ToolStripStatusLabel
    Friend WithEvents LocalizationButton As ToolStripDropDownButton
    Friend WithEvents VisualsCount As ToolStripStatusLabel
    Friend WithEvents IconsCount As ToolStripStatusLabel
    Friend WithEvents AssetsCount As ToolStripStatusLabel
    Friend WithEvents FlagsandTagsCount As ToolStripStatusLabel
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObjectsExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObjectInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FlagsExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllTemplatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ItemTemplatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CharacterTemplatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatsExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualBankExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LabelTreasureCount As ToolStripStatusLabel
    Friend WithEvents TrasureTablesExplorerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ContainersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DyesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArmorsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaunchGameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FoldersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UTAMModsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UTAMCacheToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BG3GameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BG3ModsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents OpenDetailsWindowsAlsoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WeaponsToolStripMenuItem As ToolStripMenuItem
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSplitButtonSettings = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItemNewTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEditTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTasks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLook = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemConfiguration = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemAlwaysOnTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDefault = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCompact = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemFullScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemHelpOnline = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemAboutEggzle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemCheckForUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonNewTimer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonStartPause = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonReset = New System.Windows.Forms.ToolStripButton()
        Me.PanelTimer = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButtonSettings, Me.ToolStripSeparator1, Me.ToolStripButtonNewTimer, Me.ToolStripButtonStartPause, Me.ToolStripButtonReset})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.TabStop = True
        '
        'ToolStripSplitButtonSettings
        '
        Me.ToolStripSplitButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButtonSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemNewTimer, Me.ToolStripMenuItemEditTimer, Me.ToolStripMenuItemTasks, Me.ToolStripMenuItemLook, Me.ToolStripSeparator2, Me.ToolStripMenuItemConfiguration, Me.ToolStripMenuItem2, Me.ToolStripMenuItemAlwaysOnTop, Me.ToolStripMenuItemWindow, Me.ToolStripSeparator3, Me.ToolStripMenuItemHelp, Me.ToolStripMenuItem5, Me.ToolStripMenuItemExit})
        resources.ApplyResources(Me.ToolStripSplitButtonSettings, "ToolStripSplitButtonSettings")
        Me.ToolStripSplitButtonSettings.Name = "ToolStripSplitButtonSettings"
        '
        'ToolStripMenuItemNewTimer
        '
        Me.ToolStripMenuItemNewTimer.Name = "ToolStripMenuItemNewTimer"
        resources.ApplyResources(Me.ToolStripMenuItemNewTimer, "ToolStripMenuItemNewTimer")
        '
        'ToolStripMenuItemEditTimer
        '
        Me.ToolStripMenuItemEditTimer.Name = "ToolStripMenuItemEditTimer"
        resources.ApplyResources(Me.ToolStripMenuItemEditTimer, "ToolStripMenuItemEditTimer")
        '
        'ToolStripMenuItemTasks
        '
        Me.ToolStripMenuItemTasks.Name = "ToolStripMenuItemTasks"
        resources.ApplyResources(Me.ToolStripMenuItemTasks, "ToolStripMenuItemTasks")
        '
        'ToolStripMenuItemLook
        '
        Me.ToolStripMenuItemLook.Name = "ToolStripMenuItemLook"
        resources.ApplyResources(Me.ToolStripMenuItemLook, "ToolStripMenuItemLook")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripMenuItemConfiguration
        '
        Me.ToolStripMenuItemConfiguration.Name = "ToolStripMenuItemConfiguration"
        resources.ApplyResources(Me.ToolStripMenuItemConfiguration, "ToolStripMenuItemConfiguration")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'ToolStripMenuItemAlwaysOnTop
        '
        Me.ToolStripMenuItemAlwaysOnTop.CheckOnClick = True
        Me.ToolStripMenuItemAlwaysOnTop.Name = "ToolStripMenuItemAlwaysOnTop"
        resources.ApplyResources(Me.ToolStripMenuItemAlwaysOnTop, "ToolStripMenuItemAlwaysOnTop")
        '
        'ToolStripMenuItemWindow
        '
        Me.ToolStripMenuItemWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemDefault, Me.ToolStripMenuItemCompact, Me.ToolStripMenuItemFullScreen})
        Me.ToolStripMenuItemWindow.Name = "ToolStripMenuItemWindow"
        resources.ApplyResources(Me.ToolStripMenuItemWindow, "ToolStripMenuItemWindow")
        '
        'ToolStripMenuItemDefault
        '
        Me.ToolStripMenuItemDefault.Name = "ToolStripMenuItemDefault"
        resources.ApplyResources(Me.ToolStripMenuItemDefault, "ToolStripMenuItemDefault")
        '
        'ToolStripMenuItemCompact
        '
        Me.ToolStripMenuItemCompact.Name = "ToolStripMenuItemCompact"
        resources.ApplyResources(Me.ToolStripMenuItemCompact, "ToolStripMenuItemCompact")
        '
        'ToolStripMenuItemFullScreen
        '
        Me.ToolStripMenuItemFullScreen.Name = "ToolStripMenuItemFullScreen"
        resources.ApplyResources(Me.ToolStripMenuItemFullScreen, "ToolStripMenuItemFullScreen")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'ToolStripMenuItemHelp
        '
        Me.ToolStripMenuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemHelpOnline, Me.ToolStripMenuItemAboutEggzle, Me.ToolStripMenuItem4, Me.ToolStripMenuItemCheckForUpdates})
        Me.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp"
        resources.ApplyResources(Me.ToolStripMenuItemHelp, "ToolStripMenuItemHelp")
        '
        'ToolStripMenuItemHelpOnline
        '
        Me.ToolStripMenuItemHelpOnline.Name = "ToolStripMenuItemHelpOnline"
        resources.ApplyResources(Me.ToolStripMenuItemHelpOnline, "ToolStripMenuItemHelpOnline")
        '
        'ToolStripMenuItemAboutEggzle
        '
        Me.ToolStripMenuItemAboutEggzle.Name = "ToolStripMenuItemAboutEggzle"
        resources.ApplyResources(Me.ToolStripMenuItemAboutEggzle, "ToolStripMenuItemAboutEggzle")
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'ToolStripMenuItemCheckForUpdates
        '
        Me.ToolStripMenuItemCheckForUpdates.Name = "ToolStripMenuItemCheckForUpdates"
        resources.ApplyResources(Me.ToolStripMenuItemCheckForUpdates, "ToolStripMenuItemCheckForUpdates")
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        '
        'ToolStripMenuItemExit
        '
        Me.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        resources.ApplyResources(Me.ToolStripMenuItemExit, "ToolStripMenuItemExit")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ToolStripButtonNewTimer
        '
        Me.ToolStripButtonNewTimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripButtonNewTimer, "ToolStripButtonNewTimer")
        Me.ToolStripButtonNewTimer.Name = "ToolStripButtonNewTimer"
        '
        'ToolStripButtonStartPause
        '
        Me.ToolStripButtonStartPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonStartPause.Image = Global.Eggzle.My.Resources.Resources.play_green
        resources.ApplyResources(Me.ToolStripButtonStartPause, "ToolStripButtonStartPause")
        Me.ToolStripButtonStartPause.Name = "ToolStripButtonStartPause"
        '
        'ToolStripButtonReset
        '
        Me.ToolStripButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonReset.Image = Global.Eggzle.My.Resources.Resources.arrow_redo
        resources.ApplyResources(Me.ToolStripButtonReset, "ToolStripButtonReset")
        Me.ToolStripButtonReset.Name = "ToolStripButtonReset"
        '
        'PanelTimer
        '
        resources.ApplyResources(Me.PanelTimer, "PanelTimer")
        Me.PanelTimer.Name = "PanelTimer"
        Me.PanelTimer.TabStop = True
        '
        'FormMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelTimer)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FormMain"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonStartPause As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonReset As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonNewTimer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelTimer As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSplitButtonSettings As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemNewTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemTasks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemLook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemConfiguration As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemAlwaysOnTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDefault As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCompact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFullScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemHelpOnline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAboutEggzle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemCheckForUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemEditTimer As System.Windows.Forms.ToolStripMenuItem

End Class

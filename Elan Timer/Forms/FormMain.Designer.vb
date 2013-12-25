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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSplitButtonSettings = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItemNewTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEditTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTasks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemStyle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemAlwaysOnTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDefault = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCompact = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemFullScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemHelpOnline = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemAboutElanTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemCheckForUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonNewTimer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonStartPause = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonReset = New System.Windows.Forms.ToolStripButton()
        Me.PanelTimer = New System.Windows.Forms.Panel()
        Me.ProgressBarMain = New System.Windows.Forms.ProgressBar()
        Me.NotifyIconMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NotifyIconToolStripMenuItemNewTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIconToolStripMenuItemEditTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIconToolStripMenuItemStartTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolNotifyIconStripMenuItemResetTimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIconToolStripMenuItemTasks = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIconToolStripMenuItemStyle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NotifyIconToolStripMenuItemSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.NotifyIconToolStripMenuItemShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.NotifyIconToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMain.SuspendLayout()
        Me.ContextMenuStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButtonSettings, Me.ToolStripSeparator1, Me.ToolStripButtonNewTimer, Me.ToolStripButtonStartPause, Me.ToolStripButtonReset})
        resources.ApplyResources(Me.ToolStripMain, "ToolStripMain")
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.TabStop = True
        '
        'ToolStripSplitButtonSettings
        '
        Me.ToolStripSplitButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButtonSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemNewTimer, Me.ToolStripMenuItemEditTimer, Me.ToolStripMenuItemTasks, Me.ToolStripMenuItemStyle, Me.ToolStripSeparator2, Me.ToolStripMenuItemSettings, Me.ToolStripMenuItem2, Me.ToolStripMenuItemAlwaysOnTop, Me.ToolStripMenuItemWindow, Me.ToolStripSeparator3, Me.ToolStripMenuItemHelp, Me.ToolStripMenuItem5, Me.ToolStripMenuItemExit})
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
        'ToolStripMenuItemStyle
        '
        Me.ToolStripMenuItemStyle.Name = "ToolStripMenuItemStyle"
        resources.ApplyResources(Me.ToolStripMenuItemStyle, "ToolStripMenuItemStyle")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripMenuItemSettings
        '
        Me.ToolStripMenuItemSettings.Name = "ToolStripMenuItemSettings"
        resources.ApplyResources(Me.ToolStripMenuItemSettings, "ToolStripMenuItemSettings")
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
        Me.ToolStripMenuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemHelpOnline, Me.ToolStripMenuItemAboutElanTimer, Me.ToolStripMenuItem4, Me.ToolStripMenuItemCheckForUpdates})
        Me.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp"
        resources.ApplyResources(Me.ToolStripMenuItemHelp, "ToolStripMenuItemHelp")
        '
        'ToolStripMenuItemHelpOnline
        '
        Me.ToolStripMenuItemHelpOnline.Name = "ToolStripMenuItemHelpOnline"
        resources.ApplyResources(Me.ToolStripMenuItemHelpOnline, "ToolStripMenuItemHelpOnline")
        '
        'ToolStripMenuItemAboutElanTimer
        '
        Me.ToolStripMenuItemAboutElanTimer.Name = "ToolStripMenuItemAboutElanTimer"
        resources.ApplyResources(Me.ToolStripMenuItemAboutElanTimer, "ToolStripMenuItemAboutElanTimer")
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
        Me.ToolStripButtonStartPause.Image = Global.ElanTimer.My.Resources.Resources.play_green
        resources.ApplyResources(Me.ToolStripButtonStartPause, "ToolStripButtonStartPause")
        Me.ToolStripButtonStartPause.Name = "ToolStripButtonStartPause"
        '
        'ToolStripButtonReset
        '
        Me.ToolStripButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonReset.Image = Global.ElanTimer.My.Resources.Resources.arrow_redo
        resources.ApplyResources(Me.ToolStripButtonReset, "ToolStripButtonReset")
        Me.ToolStripButtonReset.Name = "ToolStripButtonReset"
        '
        'PanelTimer
        '
        resources.ApplyResources(Me.PanelTimer, "PanelTimer")
        Me.PanelTimer.Name = "PanelTimer"
        Me.PanelTimer.TabStop = True
        '
        'ProgressBarMain
        '
        resources.ApplyResources(Me.ProgressBarMain, "ProgressBarMain")
        Me.ProgressBarMain.Maximum = 1000
        Me.ProgressBarMain.Name = "ProgressBarMain"
        Me.ProgressBarMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'NotifyIconMain
        '
        Me.NotifyIconMain.ContextMenuStrip = Me.ContextMenuStripMain
        resources.ApplyResources(Me.NotifyIconMain, "NotifyIconMain")
        '
        'ContextMenuStripMain
        '
        Me.ContextMenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotifyIconToolStripMenuItemNewTimer, Me.NotifyIconToolStripMenuItemEditTimer, Me.NotifyIconToolStripMenuItemStartTimer, Me.ToolNotifyIconStripMenuItemResetTimer, Me.NotifyIconToolStripMenuItemTasks, Me.NotifyIconToolStripMenuItemStyle, Me.ToolStripMenuItem1, Me.NotifyIconToolStripMenuItemSettings, Me.ToolStripMenuItem3, Me.NotifyIconToolStripMenuItemShow, Me.ToolStripMenuItem6, Me.NotifyIconToolStripMenuItemExit})
        Me.ContextMenuStripMain.Name = "ContextMenuStripMain"
        resources.ApplyResources(Me.ContextMenuStripMain, "ContextMenuStripMain")
        '
        'NotifyIconToolStripMenuItemNewTimer
        '
        Me.NotifyIconToolStripMenuItemNewTimer.Name = "NotifyIconToolStripMenuItemNewTimer"
        resources.ApplyResources(Me.NotifyIconToolStripMenuItemNewTimer, "NotifyIconToolStripMenuItemNewTimer")
        '
        'NotifyIconToolStripMenuItemEditTimer
        '
        Me.NotifyIconToolStripMenuItemEditTimer.Name = "NotifyIconToolStripMenuItemEditTimer"
        resources.ApplyResources(Me.NotifyIconToolStripMenuItemEditTimer, "NotifyIconToolStripMenuItemEditTimer")
        '
        'NotifyIconToolStripMenuItemStartTimer
        '
        Me.NotifyIconToolStripMenuItemStartTimer.Name = "NotifyIconToolStripMenuItemStartTimer"
        resources.ApplyResources(Me.NotifyIconToolStripMenuItemStartTimer, "NotifyIconToolStripMenuItemStartTimer")
        '
        'ToolNotifyIconStripMenuItemResetTimer
        '
        Me.ToolNotifyIconStripMenuItemResetTimer.Name = "ToolNotifyIconStripMenuItemResetTimer"
        resources.ApplyResources(Me.ToolNotifyIconStripMenuItemResetTimer, "ToolNotifyIconStripMenuItemResetTimer")
        '
        'NotifyIconToolStripMenuItemTasks
        '
        Me.NotifyIconToolStripMenuItemTasks.Name = "NotifyIconToolStripMenuItemTasks"
        resources.ApplyResources(Me.NotifyIconToolStripMenuItemTasks, "NotifyIconToolStripMenuItemTasks")
        '
        'NotifyIconToolStripMenuItemLook
        '
        Me.NotifyIconToolStripMenuItemStyle.Name = "NotifyIconToolStripMenuItemLook"
        resources.ApplyResources(Me.NotifyIconToolStripMenuItemStyle, "NotifyIconToolStripMenuItemLook")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'NotifyIconToolStripMenuItemSettings
        '
        Me.NotifyIconToolStripMenuItemSettings.Name = "NotifyIconToolStripMenuItemSettings"
        resources.ApplyResources(Me.NotifyIconToolStripMenuItemSettings, "NotifyIconToolStripMenuItemSettings")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'NotifyIconToolStripMenuItemShow
        '
        Me.NotifyIconToolStripMenuItemShow.Name = "NotifyIconToolStripMenuItemShow"
        resources.ApplyResources(Me.NotifyIconToolStripMenuItemShow, "NotifyIconToolStripMenuItemShow")
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        resources.ApplyResources(Me.ToolStripMenuItem6, "ToolStripMenuItem6")
        '
        'NotifyIconToolStripMenuItemExit
        '
        Me.NotifyIconToolStripMenuItemExit.Name = "NotifyIconToolStripMenuItemExit"
        resources.ApplyResources(Me.NotifyIconToolStripMenuItemExit, "NotifyIconToolStripMenuItemExit")
        '
        'FormMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ProgressBarMain)
        Me.Controls.Add(Me.PanelTimer)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Name = "FormMain"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ContextMenuStripMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonStartPause As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonReset As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonNewTimer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelTimer As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSplitButtonSettings As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemNewTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemTasks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemAlwaysOnTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDefault As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCompact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFullScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemHelpOnline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAboutElanTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemCheckForUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemEditTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBarMain As System.Windows.Forms.ProgressBar
    Friend WithEvents NotifyIconMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStripMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NotifyIconToolStripMenuItemNewTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIconToolStripMenuItemEditTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolNotifyIconStripMenuItemResetTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIconToolStripMenuItemStartTimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIconToolStripMenuItemTasks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIconToolStripMenuItemStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NotifyIconToolStripMenuItemSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NotifyIconToolStripMenuItemShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIconToolStripMenuItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator

End Class

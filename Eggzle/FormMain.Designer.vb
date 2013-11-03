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
        Me.ToolStripSplitButtonSettings = New System.Windows.Forms.ToolStripSplitButton()
        Me.GlobalSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpOnlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutEggzeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlwaysOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonStartPause = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.PanelTimer = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButtonSettings, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripButtonStartPause, Me.ToolStripButton2})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'ToolStripSplitButtonSettings
        '
        Me.ToolStripSplitButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButtonSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GlobalSettingsToolStripMenuItem, Me.ToolStripMenuItem2, Me.HelpToolStripMenuItem, Me.AlwaysOnTopToolStripMenuItem, Me.ToolStripMenuItem5, Me.ExitToolStripMenuItem})
        resources.ApplyResources(Me.ToolStripSplitButtonSettings, "ToolStripSplitButtonSettings")
        Me.ToolStripSplitButtonSettings.Name = "ToolStripSplitButtonSettings"
        '
        'GlobalSettingsToolStripMenuItem
        '
        Me.GlobalSettingsToolStripMenuItem.Name = "GlobalSettingsToolStripMenuItem"
        resources.ApplyResources(Me.GlobalSettingsToolStripMenuItem, "GlobalSettingsToolStripMenuItem")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpOnlineToolStripMenuItem, Me.AboutEggzeyToolStripMenuItem, Me.ToolStripMenuItem4, Me.CheckForUpdatesToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        '
        'HelpOnlineToolStripMenuItem
        '
        Me.HelpOnlineToolStripMenuItem.Name = "HelpOnlineToolStripMenuItem"
        resources.ApplyResources(Me.HelpOnlineToolStripMenuItem, "HelpOnlineToolStripMenuItem")
        '
        'AboutEggzeyToolStripMenuItem
        '
        Me.AboutEggzeyToolStripMenuItem.Name = "AboutEggzeyToolStripMenuItem"
        resources.ApplyResources(Me.AboutEggzeyToolStripMenuItem, "AboutEggzeyToolStripMenuItem")
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        resources.ApplyResources(Me.CheckForUpdatesToolStripMenuItem, "CheckForUpdatesToolStripMenuItem")
        '
        'AlwaysOnTopToolStripMenuItem
        '
        Me.AlwaysOnTopToolStripMenuItem.CheckOnClick = True
        Me.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem"
        resources.ApplyResources(Me.AlwaysOnTopToolStripMenuItem, "AlwaysOnTopToolStripMenuItem")
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripButton3, "ToolStripButton3")
        Me.ToolStripButton3.Name = "ToolStripButton3"
        '
        'ToolStripButtonStartPause
        '
        Me.ToolStripButtonStartPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonStartPause.Image = Global.Eggzle.My.Resources.Resources.play_green
        resources.ApplyResources(Me.ToolStripButtonStartPause, "ToolStripButtonStartPause")
        Me.ToolStripButtonStartPause.Name = "ToolStripButtonStartPause"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Eggzle.My.Resources.Resources.arrow_refresh
        resources.ApplyResources(Me.ToolStripButton2, "ToolStripButton2")
        Me.ToolStripButton2.Name = "ToolStripButton2"
        '
        'PanelTimer
        '
        resources.ApplyResources(Me.PanelTimer, "PanelTimer")
        Me.PanelTimer.Name = "PanelTimer"
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
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSplitButtonSettings As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpOnlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutEggzeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelTimer As System.Windows.Forms.Panel
    Friend WithEvents AlwaysOnTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GlobalSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

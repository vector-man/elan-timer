﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18444
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property AlwaysOnTop() As Boolean
            Get
                Return CType(Me("AlwaysOnTop"),Boolean)
            End Get
            Set
                Me("AlwaysOnTop") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property EnableAutomaticUpdateChecking() As Boolean
            Get
                Return CType(Me("EnableAutomaticUpdateChecking"),Boolean)
            End Get
            Set
                Me("EnableAutomaticUpdateChecking") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Setting() As String
            Get
                Return CType(Me("Setting"),String)
            End Get
            Set
                Me("Setting") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("90")>  _
        Public Property NumberOfDaysBetweenUpdateChecks() As Integer
            Get
                Return CType(Me("NumberOfDaysBetweenUpdateChecks"),Integer)
            End Get
            Set
                Me("NumberOfDaysBetweenUpdateChecks") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property OpacityLevel() As Integer
            Get
                Return CType(Me("OpacityLevel"),Integer)
            End Get
            Set
                Me("OpacityLevel") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Time Files (*.time)|*.time")>  _
        Public ReadOnly Property TimeDialogFilter() As String
            Get
                Return CType(Me("TimeDialogFilter"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Task Files (*.task)|*.task")>  _
        Public ReadOnly Property TaskDialogFilter() As String
            Get
                Return CType(Me("TaskDialogFilter"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Audio Files (*.wav; *.wave)|*.wav; *.wave")>  _
        Public ReadOnly Property AlarmDialogFilter() As String
            Get
                Return CType(Me("AlarmDialogFilter"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("330, 130")>  _
        Public Property WindowSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("WindowSize"),Global.System.Drawing.Size)
            End Get
            Set
                Me("WindowSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property WindowMaximized() As Boolean
            Get
                Return CType(Me("WindowMaximized"),Boolean)
            End Get
            Set
                Me("WindowMaximized") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property WindowFullScreen() As Boolean
            Get
                Return CType(Me("WindowFullScreen"),Boolean)
            End Get
            Set
                Me("WindowFullScreen") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("290")>  _
        Public ReadOnly Property DefaultCompactWindowWidth() As Integer
            Get
                Return CType(Me("DefaultCompactWindowWidth"),Integer)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Style Files (*.look)|*.look")>  _
        Public ReadOnly Property StyleDialogFilter() As String
            Get
                Return CType(Me("StyleDialogFilter"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Calibri, 24pt, style=Bold")>  _
        Public ReadOnly Property DefaultFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("DefaultFont"),Global.System.Drawing.Font)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Styles")>  _
        Public Property StyleFolder() As String
            Get
                Return CType(Me("StyleFolder"),String)
            End Get
            Set
                Me("StyleFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Timers")>  _
        Public Property TimeFolder() As String
            Get
                Return CType(Me("TimeFolder"),String)
            End Get
            Set
                Me("TimeFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property EnableDocumentsDataFolder() As Boolean
            Get
                Return CType(Me("EnableDocumentsDataFolder"),Boolean)
            End Get
            Set
                Me("EnableDocumentsDataFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Alarms")>  _
        Public Property AlarmFolder() As String
            Get
                Return CType(Me("AlarmFolder"),String)
            End Get
            Set
                Me("AlarmFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property CloseToSystemTray() As Boolean
            Get
                Return CType(Me("CloseToSystemTray"),Boolean)
            End Get
            Set
                Me("CloseToSystemTray") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ShowNoteAlertWhenTimerExpires() As Boolean
            Get
                Return CType(Me("ShowNoteAlertWhenTimerExpires"),Boolean)
            End Get
            Set
                Me("ShowNoteAlertWhenTimerExpires") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ShowInSystemTray() As String
            Get
                Return CType(Me("ShowInSystemTray"),String)
            End Get
            Set
                Me("ShowInSystemTray") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property ClickingTrayIconStopsAlarm() As Boolean
            Get
                Return CType(Me("ClickingTrayIconStopsAlarm"),Boolean)
            End Get
            Set
                Me("ClickingTrayIconStopsAlarm") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data")>  _
        Public Property DataFolder() As String
            Get
                Return CType(Me("DataFolder"),String)
            End Get
            Set
                Me("DataFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".time")>  _
        Public ReadOnly Property TimeFileExtension() As String
            Get
                Return CType(Me("TimeFileExtension"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".task")>  _
        Public ReadOnly Property TaskFileExtension() As String
            Get
                Return CType(Me("TaskFileExtension"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".look")>  _
        Public ReadOnly Property StyleFileExtension() As String
            Get
                Return CType(Me("StyleFileExtension"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("00:05:00")>  _
        Public Property TimerDuration() As Global.System.TimeSpan
            Get
                Return CType(Me("TimerDuration"),Global.System.TimeSpan)
            End Get
            Set
                Me("TimerDuration") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property TimerCountUp() As Boolean
            Get
                Return CType(Me("TimerCountUp"),Boolean)
            End Get
            Set
                Me("TimerCountUp") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property TimerRestarts() As Integer
            Get
                Return CType(Me("TimerRestarts"),Integer)
            End Get
            Set
                Me("TimerRestarts") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property TimerAlarmEnabled() As Boolean
            Get
                Return CType(Me("TimerAlarmEnabled"),Boolean)
            End Get
            Set
                Me("TimerAlarmEnabled") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property TimerAlarmFile() As String
            Get
                Return CType(Me("TimerAlarmFile"),String)
            End Get
            Set
                Me("TimerAlarmFile") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property TimerAlarmLoop() As Boolean
            Get
                Return CType(Me("TimerAlarmLoop"),Boolean)
            End Get
            Set
                Me("TimerAlarmLoop") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property TimerAlarmVolume() As Integer
            Get
                Return CType(Me("TimerAlarmVolume"),Integer)
            End Get
            Set
                Me("TimerAlarmVolume") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property TimerNoteEnabled() As Boolean
            Get
                Return CType(Me("TimerNoteEnabled"),Boolean)
            End Get
            Set
                Me("TimerNoteEnabled") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property TimerNote() As String
            Get
                Return CType(Me("TimerNote"),String)
            End Get
            Set
                Me("TimerNote") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property TimerAlertEnabled() As Boolean
            Get
                Return CType(Me("TimerAlertEnabled"),Boolean)
            End Get
            Set
                Me("TimerAlertEnabled") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property CustomStyleColors() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("CustomStyleColors"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("CustomStyleColors") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property UseToolbarStyling() As Boolean
            Get
                Return CType(Me("UseToolbarStyling"),Boolean)
            End Get
            Set
                Me("UseToolbarStyling") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property UseDocumentsDataFolder() As Boolean
            Get
                Return CType(Me("UseDocumentsDataFolder"),Boolean)
            End Get
            Set
                Me("UseDocumentsDataFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("330, 130")>  _
        Public ReadOnly Property DefaultWindowSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("DefaultWindowSize"),Global.System.Drawing.Size)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("LICENSE.txt")>  _
        Public Property LicenseFile() As String
            Get
                Return CType(Me("LicenseFile"),String)
            End Get
            Set
                Me("LicenseFile") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.ElanTimer.My.MySettings
            Get
                Return Global.ElanTimer.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace

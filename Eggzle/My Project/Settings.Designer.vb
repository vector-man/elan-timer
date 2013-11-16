﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18408
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
         Global.System.Configuration.DefaultSettingValueAttribute("data")>  _
        Public Property DefaultTaskFile() As String
            Get
                Return CType(Me("DefaultTaskFile"),String)
            End Get
            Set
                Me("DefaultTaskFile") = value
            End Set
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
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("data")>  _
        Public Property DefaultLookFile() As String
            Get
                Return CType(Me("DefaultLookFile"),String)
            End Get
            Set
                Me("DefaultLookFile") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("data")>  _
        Public Property DefaultTimeFile() As String
            Get
                Return CType(Me("DefaultTimeFile"),String)
            End Get
            Set
                Me("DefaultTimeFile") = value
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
         Global.System.Configuration.DefaultSettingValueAttribute("290, 145")>  _
        Public Property WindowSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("WindowSize"),Global.System.Drawing.Size)
            End Get
            Set
                Me("WindowSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("417, 208")>  _
        Public ReadOnly Property DefaultWindowSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("DefaultWindowSize"),Global.System.Drawing.Size)
            End Get
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
         Global.System.Configuration.DefaultSettingValueAttribute("Look Files (*.look)|*.look")>  _
        Public ReadOnly Property LookDialogFilter() As String
            Get
                Return CType(Me("LookDialogFilter"),String)
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
         Global.System.Configuration.DefaultSettingValueAttribute("Looks")>  _
        Public Property LookFolder() As String
            Get
                Return CType(Me("LookFolder"),String)
            End Get
            Set
                Me("LookFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Tasks")>  _
        Public Property TaskFolder() As String
            Get
                Return CType(Me("TaskFolder"),String)
            End Get
            Set
                Me("TaskFolder") = value
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
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
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
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("en-US")>  _
        Public ReadOnly Property DefaultLanguage() As String
            Get
                Return CType(Me("DefaultLanguage"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Language() As String
            Get
                Return CType(Me("Language"),String)
            End Get
            Set
                Me("Language") = value
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
        Friend ReadOnly Property Settings() As Global.Eggzle.My.MySettings
            Get
                Return Global.Eggzle.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace

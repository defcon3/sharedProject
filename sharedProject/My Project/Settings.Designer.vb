﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Dieser Code wurde von einem Tool generiert.
'     Laufzeitversion:4.0.30319.42000
'
'     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
'     der Code erneut generiert wird.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Automatische My.Settings-Speicherfunktion"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
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
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property me_cookie_ABE() As String
            Get
                Return CType(Me("me_cookie_ABE"),String)
            End Get
            Set
                Me("me_cookie_ABE") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("s295nbAa7hVNS7Pr")>  _
        Public Property me_delayKey() As String
            Get
                Return CType(Me("me_delayKey"),String)
            End Get
            Set
                Me("me_delayKey") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://api.betfair.com/exchange/heartbeat/json-rpc/v1")>  _
        Public ReadOnly Property me_heartbeat_uri() As String
            Get
                Return CType(Me("me_heartbeat_uri"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://api.betfair.com/exchange/betting/json-rpc/v1")>  _
        Public ReadOnly Property me_betting_uri() As String
            Get
                Return CType(Me("me_betting_uri"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://identitysso.betfair.com/api/keepAlive")>  _
        Public ReadOnly Property me_keepAlive_uri() As String
            Get
                Return CType(Me("me_keepAlive_uri"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public ReadOnly Property me_connection_application_intervall() As String
            Get
                Return CType(Me("me_connection_application_intervall"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public Property me_connection_user_intervall() As String
            Get
                Return CType(Me("me_connection_user_intervall"),String)
            End Get
            Set
                Me("me_connection_user_intervall") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("me_delay_key")>  _
        Public Property me_selected_key() As String
            Get
                Return CType(Me("me_selected_key"),String)
            End Get
            Set
                Me("me_selected_key") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("s295nbAa7hVNS7Pr")>  _
        Public Property me_normalKey() As String
            Get
                Return CType(Me("me_normalKey"),String)
            End Get
            Set
                Me("me_normalKey") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Temp")>  _
        Public Property me_temppath() As String
            Get
                Return CType(Me("me_temppath"),String)
            End Get
            Set
                Me("me_temppath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Temp\AutoBetEngine\Log")>  _
        Public Property me_logpath() As String
            Get
                Return CType(Me("me_logpath"),String)
            End Get
            Set
                Me("me_logpath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("s295nbAa7hVNS7Pr")>  _
        Public Property me_delayKey_backup() As String
            Get
                Return CType(Me("me_delayKey_backup"),String)
            End Get
            Set
                Me("me_delayKey_backup") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("s295nbAa7hVNS7Pr")>  _
        Public Property me_keyValue() As String
            Get
                Return CType(Me("me_keyValue"),String)
            End Get
            Set
                Me("me_keyValue") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Temp")>  _
        Public Property me_logpaht() As String
            Get
                Return CType(Me("me_logpaht"),String)
            End Get
            Set
                Me("me_logpaht") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://identitysso.betfair.com/api/login")>  _
        Public Property me_login_uri() As String
            Get
                Return CType(Me("me_login_uri"),String)
            End Get
            Set
                Me("me_login_uri") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=158.181.48.94;Initial Catalog=dbdata;Persist Security Info=True;User "& _ 
            "ID=326773;Password=Extaler11!")>  _
        Public ReadOnly Property dbdataConnectionString() As String
            Get
                Return CType(Me("dbdataConnectionString"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.sharedProject.My.MySettings
            Get
                Return Global.sharedProject.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace

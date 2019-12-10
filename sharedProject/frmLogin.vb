Imports System.Net
Imports System.IO
Imports System.Text
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports MongoDB.Driver.Core
Imports MongoDB.Bson.Serialization.Attributes
Imports MongoDB.Bson.Serialization.IdGenerators
Imports MongoDB.Bson.Serialization
Imports System
Imports System.Reflection
Imports System.Collections.Generic
Imports System.Collections

Imports System.ComponentModel
''' <summary>
''' Die Form, in der der Login gemacht wird.
''' </summary>
Public Class frmLogin



    Public Event getCookie(ByVal ssoid As String)
    Public Event writeToLog(ByVal logtext As System.String)

    Private Sub frmLogin_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim ar As String() = WebBrowser1.Document.Cookie.Split(";")

        Dim t = WebBrowser1.Document.Cookie.Split(";").ToList

        For Each ea In t
            Dim m
            m = ea.ToString.Split("=")(0)
            If Trim(m) = "ssoid" Then
                RaiseEvent getCookie(ea.ToString.Split("=")(1) & "=")
                My.Settings.me_cookie_ABE = ea.ToString.Split("=")(1) & "="
                My.Settings.Save()
                RaiseEvent writeToLog("tech-> Cookie """ & My.Settings.me_cookie_ABE & """ gespeichert.")
            End If
        Next

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            RaiseEvent writeToLog("tech-> " & Me.Name & " geöffnet.")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmLogin_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            RaiseEvent writeToLog("tech-> " & Me.Name & " geschlossen.")
        Catch ex As Exception

        End Try

    End Sub

End Class
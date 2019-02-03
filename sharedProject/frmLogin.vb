Imports System.ComponentModel

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
        RaiseEvent writeToLog("tech-> " & Me.Name & " geöffnet.")
    End Sub

    Private Sub frmLogin_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        RaiseEvent writeToLog("tech-> " & Me.Name & " geschlossen.")
    End Sub
End Class
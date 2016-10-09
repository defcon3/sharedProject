Imports System.ComponentModel

Public Class frmLogin

    Public Event getCookie(ByVal ssoid As String)

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub frmLogin_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim ar As String() = WebBrowser1.Document.Cookie.Split(";")

        Dim t = WebBrowser1.Document.Cookie.Split(";").ToList

        For Each ea In t
            Dim m
            m = ea.ToString.Split("=")(0)
            If Trim(m) = "ssoid" Then
                RaiseEvent getCookie(ea.ToString.Split("=")(1) & "=")
            End If
        Next

    End Sub

End Class
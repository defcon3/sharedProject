﻿Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1

    Property newClsAutoBetEngineSession As New clsAutoBetEngineSession

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim v_ABE As New clsAutoBetEngine

        Dim req As WebRequest = WebRequest.Create(v_ABE.bf_json_rpc_address)

        With req
            .Method = "GET" '~~> I believe we use Get if we are just retrieving and Post if putting something? both work
            .ContentType = "application/json" '~~> Normals
            'laber-rababer3
            '~~> Add Headers <~~'
            .Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8")
            .Headers.Add("X-Authentication", newClsAutoBetEngineSession.token) '~~> Mandatory
        End With

        Dim m '
        m = req.GetResponse()
    End Sub

    ''' <summary>
    ''' so funktioniert das hier?!
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox2.Text = "oj"



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtConnectionState.Text = "offline"
        Me.BackColor = Color.Brown
    End Sub

    Public Event t(ByVal tz As String)

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        newClsAutoBetEngineSession.token = txtToken.Text

    End Sub


    Private Sub LoginToolStripMenuItem_DoubleClick(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.DoubleClick

    End Sub

    Public WithEvents puplic As frmLogin
    Private Sub neu(ByVal nachricht As String) Handles puplic.getCookie

        TextBox2.Text = nachricht

    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click

        'Dim myNewLoginForm As frmLogin

        puplic = New frmLogin

        puplic.ShowDialog()

        'MsgBox(LoginToolStripMenuItem.Text)




        'Dim ar As String() = WebBrowser1.Document.Cookie.Split(";")

        'Dim t = WebBrowser1.Document.Cookie.Split(";").ToList

        'For Each ea In t
        '    Dim m
        '    m = ea.ToString.Split("=")(0)
        '    If Trim(m) = "ssoid" Then
        '        MsgBox(ea.ToString.Split("=")(1))
        '    End If
        'Next


    End Sub

    Private Sub txtToken_TextChanged(sender As Object, e As EventArgs) Handles txtToken.TextChanged

    End Sub
End Class

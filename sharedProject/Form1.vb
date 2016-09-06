Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim v_ABE As New clsAutoBetEngine

        Dim m As WebRequest = WebRequest.Create(v_ABE.connectionState)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show("hier isser")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtConnectionState.Text = "offline"
    End Sub



End Class

Public Class frmLog

    Property neu = 9


    Private Sub frmLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtPath.Text = My.Settings.me_logpath

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.me_logpath = txtPath.Text
        My.Settings.Save()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click

        neu = 8

        Me.Close()
    End Sub
End Class
Public Class frmLog

    Property neu = 9

    Public Event writeToLog(ByVal logtext As System.String)


    Private Sub frmLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtPath.Text = My.Settings.me_logpath

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.me_logpath = txtPath.Text
        My.Settings.Save()
    End Sub

    ''' <summary>
    ''' Schliessenknopf
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Try
            Me.Close()
            RaiseEvent writeToLog("Nachricht")
        Catch ex As Exception

        End Try

    End Sub
End Class
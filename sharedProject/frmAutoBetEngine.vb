Public Class frmAutoBetEngine


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim m As New frmLog

        m.ShowDialog()

        MsgBox(m.neu)

        'MsgBox(My.Settings.me_logpath)
    End Sub
End Class
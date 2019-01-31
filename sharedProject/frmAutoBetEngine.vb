Public Class frmAutoBetEngine

    Public Delegate Sub SetTextCallback(ByVal Text As String)


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim m As New frmLog
        'AddHandler m.writeToLog("lksjd"), AddressOf m.writeToLog()


        m.ShowDialog()

        MsgBox(m.neu)

        'MsgBox(My.Settings.me_logpath)
    End Sub
End Class
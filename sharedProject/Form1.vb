Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1

    Property newClsAutoBetEngineSession As New clsAutoBetEngineSession
    Public WithEvents puplic As frmLogin


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


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        newClsAutoBetEngineSession.token = txtToken.Text

    End Sub


    Private Sub neu(ByVal nachricht As String) Handles puplic.getCookie

        TextBox2.Text = nachricht

    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click

        'Dim myNewLoginForm As frmLogin

        puplic = New frmLogin

        puplic.ShowDialog()



    End Sub
End Class

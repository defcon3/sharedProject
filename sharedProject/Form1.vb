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


    ''' <summary>
    ''' diese Routine wird durch cas Schlíeßen der Login Form ausgelöst
    ''' Es muss der cookie ins filesystem geschrieben werden.
    ''' </summary>
    ''' <param name="nachricht">der coookie</param>
    Private Sub write_cookie(ByVal nachricht As String) Handles puplic.getCookie

        Dim sb As New System.Text.StringBuilder
        sb.Append(nachricht)
        txtCookie.Text = sb.ToString
        txtCookie.Width = 200
        'Dim writer As New System.IO.TextWriter()
        Dim writeFile As System.IO.TextWriter = New _
            StreamWriter("c:\temp\cookie_ABE.txt", False, encoding:=Encoding.UTF8)
        writeFile.WriteLine(sb.ToString)
        writeFile.Flush()
        writeFile.Close()
        writeFile = Nothing







        TextBox2.Text = nachricht

    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click

        'Dim myNewLoginForm As frmLogin

        puplic = New frmLogin

        puplic.ShowDialog()



    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click

    End Sub

End Class

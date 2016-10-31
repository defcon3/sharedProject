Imports System.Net
Imports System.IO
Imports System.Text



Public Class Form1


    Public WithEvents myNewLoginForm As frmLogin


    ''' <summary>
    ''' diese Routine wird durch cas Schlíeßen der Login Form ausgelöst
    ''' Es muss der cookie ins filesystem geschrieben werden.
    ''' </summary>
    ''' <param name="nachricht">der coookie</param>
    Private Sub write_cookie(ByVal nachricht As String) Handles myNewLoginForm.getCookie






        Dim sb As New System.Text.StringBuilder
        sb.Append(nachricht)
        txtCookie.Text = sb.ToString
        txtCookie.Width = 200
        'Dim writer As New System.IO.TextWriter()
        Dim writeFile As System.IO.TextWriter = New _
            StreamWriter("c:\temp\cookie_ABE.txt", False, encoding:=Encoding.ASCII)
        writeFile.WriteLine(sb.ToString)
        My.Settings.me_cookie_ABE = sb.ToString
        writeFile.Flush()
        writeFile.Close()
        writeFile = Nothing

    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click

        'Dim myNewLoginForm As frmLogin
        myNewLoginForm = New frmLogin

        myNewLoginForm.ShowDialog()

    End Sub


    Private Function SendSportsReq(ByVal jsonString As String) As String




        Dim myURI As New Uri(My.Settings.me_betting_uri)
        Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False



        Dim request As WebRequest = WebRequest.Create(myURI)

        'send_keepAlive()


        Dim byteArray As Byte() = Encoding.Default.GetBytes(jsonString)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers.Add(CStr("X-Application: " & My.Settings.me_delayKey))
        request.Headers.Add("X-Authentication: " & My.Settings.me_cookie_ABE)
        Dim bl = Encoding.Default.GetBytes(jsonString)
        request.ContentLength = bl.Length



        Dim datastream As Stream = request.GetRequestStream()
        datastream.Write(byteArray, 0, bl.Length)

        datastream.Close()

        Dim response As WebResponse = request.GetResponse()

        Dim myHttpWebResponse As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
            txtConnectionState.Text = "online"
        Else
            txtConnectionState.Text = "offline"
        End If


        datastream = response.GetResponseStream()

        Dim reader As New StreamReader(datastream)
        Dim responseFromServer As String = reader.ReadToEnd()



        reader.Close()
        datastream.Close()


        Debug.Print(responseFromServer.ToString)
        response.Close()

        Return responseFromServer

    End Function

    Public Class ListMarketCatalogue
        Public jsonrpc As String = "2.0"
        Public method As String = "SportsAPING/v1.0/listMarketCatalogue"
        Public params As New Params
        Public id As Integer = 1
    End Class

    Public Class Params
        Public filter As New Filter
        Public sort As String = "FIRST_TO_START"
        Public maxResults As String = "500"
        Public marketProjection As New List(Of String)
    End Class

    Public Class Filter
        Public eventTypeIds As New List(Of String)
        Public marketCountries As New List(Of String)
        Public marketTypeCodes As New List(Of String)
        Public marketStartTime As New StartTime
    End Class

    Public Class StartTime
        Public from As String
        Public [to] As String
    End Class

    Function serialisiereRequest(ByVal requestList As List(Of ListMarketCatalogue)) As String

        Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(requestList)
        'MsgBox(temp)
        Return temp

    End Function



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim neueListe As New List(Of ListMarketCatalogue)
        neueListe.Add(New ListMarketCatalogue)


        Dim serialisierteAnfrage As String
        serialisierteAnfrage = serialisiereRequest(neueListe)

        Dim serverResponse As String
        serverResponse = SendSportsReq(serialisierteAnfrage)



        Dim cls As New clsMarketCatalogueResponse

        Dim g1 As String

        g1 = serverResponse.Substring(1, serverResponse.Length - 2)
        serverResponse = g1.ToString

        Debug.Print(serverResponse)


        cls = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsMarketCatalogueResponse)(serverResponse)




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        getDelayKey()
        getAbeCookie()
        txtCookie.Text = My.Settings.me_cookie_ABE
        txtHeartbeatintervall.Text = My.Settings.me_connection_user_intervall




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As New bfObjects.ListMarketCatalogueRequest("3.0", "4.0")
        MsgBox(t._jsonrpc)
        MsgBox(t._nomore)

        Dim myNewKeepAliveConnection As New clsConnectionKeepAlive
    End Sub

    Public Function send_keepAlive() As HttpStatusCode
        Dim myNewKeepAliveConnection As New clsConnectionKeepAlive

        Return myNewKeepAliveConnection.status
    End Function

    Dim WithEvents newFormConnection As New frmConnection
    Private Sub ConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionToolStripMenuItem.Click

        newFormConnection = New frmConnection
        If sender.text = "Connection" Then
            newFormConnection.ShowDialog()
            newFormConnection = Nothing
        End If

    End Sub

    Private Sub refreshHearbeatintervall(ByVal intervall As Integer) Handles newFormConnection.setIntervall

        Me.txtHeartbeatintervall.Text = intervall

    End Sub

End Class

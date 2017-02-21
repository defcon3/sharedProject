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

    'Public Class ListMarketCatalogue
    '    Public jsonrpc As String = "2.0"
    '    Public method As String = "SportsAPING/v1.0/listMarketCatalogue"
    '    Public params As New Params
    '    Public id As Integer = 1
    'End Class

    'Public Class Params
    '    Public filter As New Filter
    '    Public sort As String = "FIRST_TO_START"
    '    Public maxResults As String = "500"
    '    Public marketProjection As New List(Of String)
    'End Class

    'Public Class Filter
    '    Public eventTypeIds As New List(Of String)
    '    Public marketCountries As New List(Of String)
    '    Public marketTypeCodes As New List(Of String)
    '    Public marketStartTime As New StartTime
    'End Class

    'Public Class StartTime
    '    Public from As String
    '    Public [to] As String
    'End Class

    'Function serialisiereRequest(ByVal requestList As List(Of ListMarketCatalogue)) As String

    '    Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(requestList)
    '    'MsgBox(temp)
    '    Return temp

    'End Function

    Function serialisiereRequest(ByVal requestList As List(Of bfObjects.clsListMarketCatalogue)) As String

        Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(requestList)

        Return temp

    End Function

    Function serialisiereListEventTypes(ByVal requestList As List(Of bfObjects.clsListEventTypes)) As String

        Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(requestList)

        Return temp

    End Function


    Function serialisiereListEvents(ByVal requestList As List(Of bfObjects.clsListEvents)) As String

        Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(requestList)

        Return temp

    End Function




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim neueListe As New List(Of bfObjects.clsListMarketCatalogue)
        Dim neueListfrage As New bfObjects.clsListMarketCatalogue

        neueListfrage.params.filter.eventIds.Add(txtMarket.Text)

        neueListe.Add(neueListfrage)


        Dim serialisierteAnfrage As String
        serialisierteAnfrage = serialisiereRequest(neueListe)


        Dim serverResponse As String
        serverResponse = SendSportsReq(serialisierteAnfrage)



        'Dim cls As New clsMarketCatalogueResponse
        Dim cls As New bfObjects.structMarketCatalogueResponse

        Dim g1 As String

        g1 = serverResponse.Substring(1, serverResponse.Length - 2)
        serverResponse = g1.ToString

        Debug.Print(serverResponse)



        cls = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.structMarketCatalogueResponse)(serverResponse)




        Dim dt As DataTable
        dt = getDatatableFromResponse(cls)

        DataGridView1.DataSource = dt.Copy


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        getDelayKey()
        getAbeCookie()
        txtCookie.Text = My.Settings.me_cookie_ABE
        txtHeartbeatintervall.Text = My.Settings.me_connection_user_intervall




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click



        Dim neueListe As New List(Of bfObjects.clsListEventTypes)
        Dim neueListfrage As New bfObjects.clsListEventTypes

        neueListe.Add(neueListfrage)


        Dim serialisierteAnfrage As String
        serialisierteAnfrage = serialisiereListEventTypes(neueListe)


        Dim serverResponse As String
        serverResponse = SendSportsReq(serialisierteAnfrage)


        'Dim cls As New clsMarketCatalogueResponse
        Dim eventTypeResults As New bfObjects.clsEventTypeResultResponse

        Dim response As String

        response = serverResponse.Substring(1, serverResponse.Length - 2)
        serverResponse = response.ToString

        Debug.Print(serverResponse)



        eventTypeResults = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsEventTypeResultResponse)(serverResponse)


        Dim dt As DataTable
        dt = getDatatableFromResponse(eventTypeResults)

        DataGridView2.DataSource = dt.Copy

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim filter As New bfObjects.clsMarketFilter
        filter.eventTypeIds = TextBox1.Text


        Dim neueListe As New List(Of bfObjects.clsListEvents)
        Dim neueListfrage As New bfObjects.clsListEvents
        neueListfrage.params.filter.eventTypeIds.Add(TextBox1.Text)

        neueListe.Add(neueListfrage)


        Dim serialisierteAnfrage As String
        serialisierteAnfrage = serialisiereListEvents(neueListe)


        Dim serverResponse As String
        serverResponse = SendSportsReq(serialisierteAnfrage)


        'Dim cls As New clsMarketCatalogueResponse
        Dim eventResults As New bfObjects.clsEventResultResponse

        Dim response As String

        response = serverResponse.Substring(1, serverResponse.Length - 2)
        serverResponse = response.ToString

        Debug.Print(serverResponse)



        eventResults = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsEventResultResponse)(serverResponse)


        Dim dt As DataTable
        dt = getDatatableFromResponse(eventResults)

        dgv1.DataSource = dt.Copy



    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        Dim temptable As DataTable
        temptable = DataGridView2.DataSource.copy
        TextBox1.Text = temptable.Rows(DataGridView2.CurrentRow.Index).Item(0).ToString

        'MsgBox(temptable.Rows(DataGridView2.CurrentRow.Index).Item(0).ToString)


    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Dim temptable As DataTable
        temptable = dgv1.DataSource.copy
        txtMarket.Text = temptable.Rows(dgv1.CurrentRow.Index).Item(0).ToString
    End Sub
End Class

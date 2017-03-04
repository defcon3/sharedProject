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

        'DataGridView1.DataSource = dt.Copy

        ListView1.Items.Clear()
        ListView1.Columns.Clear()



        Dim header1, header2 As ColumnHeader
        header1 = New ColumnHeader
        header1.TextAlign = HorizontalAlignment.Left
        header1.Text = "Market ID"
        header1.Width = ListView1.Width / 2 - 10
        header2 = New ColumnHeader
        header2.TextAlign = HorizontalAlignment.Left
        header2.Text = "Market Name"
        header2.Width = header1.Width
        ListView1.Columns.Add(header1)
        ListView1.Columns.Add(header2)
        ListView1.CheckBoxes = True
        ListView1.View = View.Details


        Dim ListItem1 As ListViewItem

        ' ListItem1 = ListView1.Items.Add("eins")
        'ListItem1.SubItems.Add("zwei")

        For Each rw As DataRow In dt.Rows
            ListItem1 = New ListViewItem
            ListItem1.Text = rw.Item(0).ToString
            ListItem1.SubItems.Add(rw.Item(1).ToString)
            ListView1.Items.Add(ListItem1)
        Next




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        getDelayKey()
        getAbeCookie()
        txtCookie.Text = My.Settings.me_cookie_ABE
        txtHeartbeatintervall.Text = My.Settings.me_connection_user_intervall

        TrackBar1.Value = 10
        TextBox2.Text = 1000

        Call Button7_Click(Nothing, Nothing)

        Me.WindowState = 2




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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim foundRow() As DataRow
        foundRow = DataGridView2.DataSource.copy.select("ID='" & TextBox1.Text & "'")

        eventtype = foundRow(0).ItemArray(1).ToString


        'Dim foundRow() As DataRow
        foundRow = dgv1.DataSource.copy.select("ID='" & txtMarket.Text & "'")

        Dim eventarrayitem As New bfObjects.clsEventResult
        Dim tempevent As New bfObjects.clsEvent
        With eventarrayitem
            tempevent.id = foundRow(0).ItemArray(0).ToString
            tempevent.name = foundRow(0).ItemArray(1).ToString
            tempevent.countryCode = foundRow(0).ItemArray(2).ToString
            tempevent.timezone = foundRow(0).ItemArray(3).ToString
            tempevent.openDate = foundRow(0).ItemArray(4).ToString
            .marketCount = foundRow(0).ItemArray(5).ToString
            .event = tempevent
        End With
        eventarray.Add(eventarrayitem)



        Dim ListItem1 As ListViewItem

        ' ListItem1 = ListView1.Items.Add("eins")
        'ListItem1.SubItems.Add("zwei")

        For Each itm As ListViewItem In ListView1.Items
            If itm.Checked Then
                ListItem1 = New ListViewItem
                ListItem1.Text = eventarrayitem.event.id
                ListItem1.SubItems.Add(itm.Text)
                ListItem1.SubItems.Add(eventtype)
                ListItem1.SubItems.Add(eventarrayitem.event.name)
                ListItem1.SubItems.Add(itm.SubItems(1).Text)
                ListView2.Items.Add(ListItem1)
            End If

        Next


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        TextBox2.Text = TrackBar1.Value * 100
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        TrackBar1.Value = TextBox2.Text / 100
    End Sub


    Public eventarray As New List(Of bfObjects.clsEventResult)
    Public eventtype As String


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim dtPriceData As New DataTable
        dtPriceData.Columns.Add("ID")
        dtPriceData.Columns.Add("Option")


        Dim items7
        items7 = System.Enum.GetValues(GetType(bfObjects.enumBetStatus))
        Dim dorchen As Object
        dorchen = items7(1)



        Dim names() As String = [Enum].GetNames(GetType(bfObjects.enumBetStatus))
        For Each Name1 In names
            Console.WriteLine("{0,3:D}     0x{0:X}     {1}",
                           [Enum].Parse(GetType(bfObjects.enumBetStatus), Name1),
                           Name1)
        Next








        Dim r As System.Enum
        r = dorchen





        Dim z = items7(1)


        Dim mm '= TypeOf (dorchen).ToString 
        mm = dorchen.GetType()



        'Dim items As Array
        'items = System.Enum.GetValues(GetType(bfObjects.enumBetStatus))
        'Dim item As String
        'For Each item In items
        '    MsgBox(item)
        'Next

        Dim items As Array
        items = System.Enum.GetNames(GetType(bfObjects.enumPriceData))
        Dim item As String
        For Each item In items
            MsgBox(item)
        Next





        Exit Sub


        Dim foundRow() As DataRow
        foundRow = DataGridView2.DataSource.copy.select("ID='" & TextBox1.Text & "'")

        eventtype = foundRow(0).ItemArray(1).ToString


        Exit Sub


        'Dim foundRow() As DataRow
        foundRow = dgv1.DataSource.copy.select("ID='" & txtMarket.Text & "'")

        Dim eventarrayitem As New bfObjects.clsEventResult
        Dim tempevent As New bfObjects.clsEvent
        With eventarrayitem
            tempevent.id = foundRow(0).ItemArray(0).ToString
            tempevent.name = foundRow(0).ItemArray(1).ToString
            tempevent.countryCode = foundRow(0).ItemArray(2).ToString
            tempevent.timezone = foundRow(0).ItemArray(3).ToString
            tempevent.openDate = foundRow(0).ItemArray(4).ToString
            .marketCount = foundRow(0).ItemArray(5).ToString
            .event = tempevent
        End With
        eventarray.Add(eventarrayitem)



        Dim ListItem1 As ListViewItem

        ' ListItem1 = ListView1.Items.Add("eins")
        'ListItem1.SubItems.Add("zwei")

        For Each itm As ListViewItem In ListView1.Items
            If itm.Checked Then
                ListItem1 = New ListViewItem
                ListItem1.Text = eventarrayitem.event.id
                ListItem1.SubItems.Add(itm.Text)
                ListView2.Items.Add(ListItem1)
            End If

        Next


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        ListView2.Items.Clear()
        ListView2.Columns.Clear()

        Dim header1, header2, header3, header4, header5 As ColumnHeader
        header1 = New ColumnHeader
        header1.TextAlign = HorizontalAlignment.Left
        header1.Text = "Event-ID"
        header1.Width = ListView2.Width / 5 - 5
        header2 = New ColumnHeader
        header2.TextAlign = HorizontalAlignment.Left
        header2.Text = "Market-ID"
        header2.Width = header1.Width

        header3 = New ColumnHeader
        header3.TextAlign = HorizontalAlignment.Left
        header3.Text = "Event-Type"
        header3.Width = header1.Width

        header4 = New ColumnHeader
        header4.TextAlign = HorizontalAlignment.Left
        header4.Text = "Event-Name"
        header4.Width = header1.Width

        header5 = New ColumnHeader
        header5.TextAlign = HorizontalAlignment.Left
        header5.Text = "Market-Name"
        header5.Width = header1.Width


        ListView2.Columns.Add(header1)
        ListView2.Columns.Add(header2)
        ListView2.Columns.Add(header3)
        ListView2.Columns.Add(header4)
        ListView2.Columns.Add(header5)



        ListView2.View = View.Details

    End Sub

    Private Sub btnGO_Click(sender As Object, e As EventArgs) Handles btnGO.Click

        ListView2.Enabled = False

    End Sub
End Class

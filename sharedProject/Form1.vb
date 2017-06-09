Imports System.Net
Imports System.IO
Imports System.Text
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports MongoDB.Driver.Core
Imports MongoDB.Bson.Serialization.Attributes
Imports MongoDB.Bson.Serialization.IdGenerators
Imports MongoDB.Bson.Serialization

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


        'Debug.Print(responseFromServer.ToString)
        response.Close()

        Return responseFromServer

    End Function

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


    Function serialisiereMarketBooks(ByVal requestList As List(Of bfObjects.clsMarketBookRequest)) As String

        Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(requestList)

        Return temp

    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim neueListe As New List(Of bfObjects.clsListMarketCatalogue)
        Dim neueListfrage As New bfObjects.clsListMarketCatalogue

        neueListfrage.params.filter.eventIds.Add(txtMarket.Text)
        neueListfrage.params.marketProjection.Add("EVENT")
        neueListfrage.params.marketProjection.Add("EVENT_TYPE")
        neueListfrage.params.marketProjection.Add("COMPETITION")
        neueListfrage.params.marketProjection.Add("MARKET_START_TIME")
        neueListfrage.params.marketProjection.Add("MARKET_DESCRIPTION")
        neueListfrage.params.marketProjection.Add("RUNNER_DESCRIPTION")
        neueListfrage.params.marketProjection.Add("RUNNER_METADATA")



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


        Dim xmlDoc As Xml.XmlDocument
        Dim DataSet = New DataSet()
        Dim xmlReader As Xml.XmlNodeReader

        'TextBox2.Text = serverResponse

        xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(serverResponse, "wurzel")

        xmlReader = New Xml.XmlNodeReader(xmlDoc)
        DataSet = New DataSet()
        DataSet.ReadXml(xmlReader)

        Dim sqlstrg As String
        Dim strg As String = Date.Now.ToString("MM/dd/yyyy HH:mm:ss.fff tt")


        For Each dta As DataTable In DataSet.Tables

            dta.Columns.Add("timestamp")
            For Each row In dta.Rows
                row("timestamp") = strg
            Next

            For Each rw In dta.Rows
                sqlstrg = getInsertString(rw, dta.TableName, dta.Columns)
                If sqlstrg.Length > 1 Then

                    writeToAccess(New OleDb.OleDbConnection, sqlstrg)

                End If
            Next

        Next





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

    Property antworttabelle As New DataTable
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        getDelayKey()
        getAbeCookie()
        txtCookie.Text = My.Settings.me_cookie_ABE
        txtHeartbeatintervall.Text = My.Settings.me_connection_user_intervall

        TrackBar1.Value = 10
        txtRefreshRate.Text = 1000

        Call Button7_Click(Nothing, Nothing)

        Me.WindowState = 2


        Dim dc9 As New DataColumn("ServerResponse")
        Dim dc8 As New DataColumn("Zeit")

        antworttabelle.Columns.Add(dc9)
        antworttabelle.Columns.Add(dc8)




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

        'Debug.Print(serverResponse)



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

        'Debug.Print(serverResponse)



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
                'ListItem1.Text = eventarrayitem.event.id
                'ListItem1.SubItems.Add(itm.Text)
                ListItem1.Text = itm.Text
                ListItem1.SubItems.Add(eventarrayitem.event.id)
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
        txtRefreshRate.Text = TrackBar1.Value * 100
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles txtRefreshRate.LostFocus
        TrackBar1.Value = txtRefreshRate.Text / 100
    End Sub


    Public eventarray As New List(Of bfObjects.clsEventResult)
    Public eventtype As String


    Public Property Requeststring As String

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click



        Dim neueListe As New List(Of bfObjects.clsMarketBookRequest)
        Dim neueListfrage As New bfObjects.clsMarketBookRequest
        Dim PriceProjection As New bfObjects.clsPriceProjection

        If cboPriceData1.SelectedValue >= 0 Then
            PriceProjection.priceData.Add(cboPriceData1.Text)
        End If
        If cboPriceData2.SelectedValue >= 0 And cboPriceData1.SelectedValue <> cboPriceData2.SelectedValue Then
            PriceProjection.priceData.Add(cboPriceData2.Text)
        End If


        Dim MarketBookParams As New bfObjects.clsMarketBookParams
        MarketBookParams.priceProjection = PriceProjection
        If cboOrderData.SelectedValue >= 0 Then
            MarketBookParams.orderProjection = cboOrderData.Text
        End If

        For Each i As ListViewItem In ListView2.Items
            MarketBookParams.marketIds.Add(i.Text.ToString)
        Next

        neueListfrage.params = MarketBookParams


        neueListe.Add(neueListfrage)

        Dim serialisierteAnfrage As String
        serialisierteAnfrage = serialisiereMarketBooks(neueListe)

        Requeststring = serialisierteAnfrage



        txtRequest.Text = Requeststring






    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        ListView2.Enabled = True
        ListView2.Items.Clear()
        ListView2.Columns.Clear()

        Dim header1, header2, header3, header4, header5 As ColumnHeader
        header1 = New ColumnHeader
        header1.TextAlign = HorizontalAlignment.Left
        header1.Text = "Market-ID"
        header1.Width = ListView2.Width / 5 - 5
        header2 = New ColumnHeader
        header2.TextAlign = HorizontalAlignment.Left
        header2.Text = "Event-ID"
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


        Dim dtPrice As New DataTable
        dtPrice = EnumToDataTable(GetType(bfObjects.enumPriceData), "", "")


        With cboPriceData1
            .DataSource = dtPrice.Copy
            .DisplayMember = "VALUE"
            .ValueMember = "KEY"
        End With
        With cboPriceData2
            .DataSource = dtPrice.Copy
            .DisplayMember = "VALUE"
            .ValueMember = "KEY"
        End With



        Dim dtOrder As New DataTable
        dtOrder = EnumToDataTable(GetType(bfObjects.enumOrderProjection), "", "")
        With cboOrderData
            .DataSource = dtOrder.Copy
            .DisplayMember = "VALUE"
            .ValueMember = "KEY"
        End With






    End Sub


    Dim läuft As Boolean = False
    Dim filesExistieren As Boolean = False

    Private Sub btnGO_Click(sender As Object, e As EventArgs) Handles btnGO.Click

        Timer1.Interval = txtRefreshRate.Text
        läuft = True

        ListView2.Enabled = False

        Dim serverResponse As String
        Dim xmlDoc As Xml.XmlDocument
        Dim DataSet = New DataSet()
        Dim xmlReader As Xml.XmlNodeReader


        Dim t1, t2, t3, t4, t5 As String



        ' write Metadata
        Using sw As System.IO.StreamWriter = System.IO.File.AppendText("c:\Temp\export\Metadata.txt")

            Dim sb = New System.Text.StringBuilder
            sb.Append("Market-ID;Event-ID;Event-Type;Event-Name;Market-Name")
            sw.WriteLine(sb.ToString)


            sb = New System.Text.StringBuilder

            For Each itm As ListViewItem In ListView2.Items
                sb.Append(itm.Text & ";" & itm.SubItems(1).Text & ";" & itm.SubItems(2).Text & ";" & itm.SubItems(3).Text & ";" & itm.SubItems(4).Text & vbCrLf)
                sw.WriteLine(sb.ToString)

                t1 = itm.Text
                t2 = itm.SubItems(1).Text
                t3 = itm.SubItems(2).Text
                t4 = itm.SubItems(3).Text
                t5 = itm.SubItems(4).Text
            Next

        End Using

        Dim sqlstrg As String = "INSERT INTO tabMetadata ([Market-ID],[Event-ID],[Event-Type],[Event-Name],[Market-Name]) VALUES ( '" & t1 & "', '" & t2 & "', '" & t3 & "', '" & t4 & "', '" & t5 & "')"


        Dim con As New OleDb.OleDbConnection
        con.ConnectionString = My.Settings.DB_EXPORTConnectionString
        Try
            con.Open()

            Dim commando As New OleDb.OleDbCommand(sqlstrg, con)
            commando.ExecuteNonQuery()



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try



        'Dim dt9 As New DataTable
        'Dim dc9 As DataColumn
        'dc9.ColumnName = "ServerResponse"
        ''dc.MaxLength = 10000








        While läuft = True

            Application.DoEvents()
            System.Threading.Thread.Sleep(txtRefreshRate.Text)

            serverResponse = SendSportsReq(Requeststring)

            'Dim cls As New clsMarketCatalogueResponse
            Dim cls As New bfObjects.clsMarketBookResponse
            Dim g1 As String
            g1 = serverResponse.Substring(1, serverResponse.Length - 2)
            serverResponse = g1.ToString
            '        Debug.Print(serverResponse)


            Call ausgabeZuDatatable(serverResponse)
        End While
        Exit Sub


        'cls = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketBookResponse)(serverResponse)

        'TextBox2.Text = serverResponse

        xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(serverResponse, "wurzel")

            xmlReader = New Xml.XmlNodeReader(xmlDoc)
            DataSet = New DataSet()
            DataSet.ReadXml(xmlReader)

            Dim strg As String = Date.Now.ToString("MM/dd/yyyy HH:mm:ss.fff tt")

            Dim obj As New Object

            For Each dt As DataTable In DataSet.Tables

                dt.Columns.Add("timestamp")
                For Each row In dt.Rows
                    row("timestamp") = strg
                Next

                ' hier müssen alle Tabellen in die Datenbank geschrieben werden
                'DataTable2CSV2(dt, "C:\Temp\export\" & dt.TableName & ".txt", ";")

                '' HIER EXPORT

                'For Each rw In dt.Rows
                '    sqlstrg = getInsertString(rw, dt.TableName, dt.Columns)
                '    If sqlstrg.Length > 1 Then
                '        writeToAccess(New OleDb.OleDbConnection, sqlstrg)
                '    End If
                'Next


                obj = DataSet.Tables
                'Stop




            Next


        'End While





    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        läuft = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim strg As String

        Dim n = System.DateTime.Now.Ticks

        'Dim t As New DB_EXPORTDataSetTableAdapters

        Dim con As New OleDb.OleDbConnection
        con.ConnectionString = My.Settings.DB_EXPORTConnectionString

        Try
            con.Open()
        Catch ex As Exception
            MsgBox(ex.InnerException.ToString)
        Finally
            con.Close()

        End Try




        'Dim queryString As String = "SELECT CustomerID, CompanyName FROM dbo.Customers"
        'Dim adapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(queryString, Connection)

        'Dim customers As DataSet = New DataSet
        'adapter.Fill(customers, "Customers")

        Exit Sub

        strg = "{""jsonrpc"":""2.0"",""result"":[{""marketId"":""1.130138285"",""isMarketDataDelayed"":true,""status"":""OPEN"",""betDelay"":0,""bspReconciled"":false,""complete"":true,""inplay"":false,""numberOfWinners"":1,""numberOfRunners"":2,""numberOfActiveRunners"":2,""totalMatched"":0.0,""totalAvailable"":54766.82,""crossMatching"":true,""runnersVoidable"":false,""version"":1578390911,""runners"":[{""selectionId"":5851482,""handicap"":0.0,""status"":""ACTIVE"",""totalMatched"":0.0,""ex"":{""availableToBack"":[{""price"":11.0,""size"":35.01},{""price"":8.2,""size"":17.99},{""price"":8.0,""size"":18.5}],""availableToLay"":[{""price"":12.5,""size"":1744.75},{""price"":13.5,""size"":1600.69},{""price"":15.5,""size"":690.62}],""tradedVolume"":[]}},{""selectionId"":5851483,""handicap"":0.0,""status"":""ACTIVE"",""totalMatched"":0.0,""ex"":{""availableToBack"":[{""price"":1.09,""size"":20008.67},{""price"":1.08,""size"":20008.67},{""price"":1.07,""size"":10004.33}],""availableToLay"":[{""price"":1.1,""size"":350.15},{""price"":1.14,""size"":129.45},{""price"":1.15,""size"":128.73}],""tradedVolume"":[]}}]}],""id"":1}"
        'strg = "?xml"":""{""@version"": ""1.0"",""standalone"": ""no""},{""jsonrpc"":""2.0"",""result"":[{""marketId"":""1.130138285"",""isMarketDataDelayed"":true,""status"":""OPEN"",""betDelay"":0,""bspReconciled"":false,""complete"":true,""inplay"":false,""numberOfWinners"":1,""numberOfRunners"":2,""numberOfActiveRunners"":2,""totalMatched"":0.0,""totalAvailable"":54766.82,""crossMatching"":true,""runnersVoidable"":false,""version"":1578390911,""runners"":[{""selectionId"":5851482,""handicap"":0.0,""status"":""ACTIVE"",""totalMatched"":0.0,""ex"":{""availableToBack"":[{""price"":11.0,""size"":35.01},{""price"":8.2,""size"":17.99},{""price"":8.0,""size"":18.5}],""availableToLay"":[{""price"":12.5,""size"":1744.75},{""price"":13.5,""size"":1600.69},{""price"":15.5,""size"":690.62}],""tradedVolume"":[]}},{""selectionId"":5851483,""handicap"":0.0,""status"":""ACTIVE"",""totalMatched"":0.0,""ex"":{""availableToBack"":[{""price"":1.09,""size"":20008.67},{""price"":1.08,""size"":20008.67},{""price"":1.07,""size"":10004.33}],""availableToLay"":[{""price"":1.1,""size"":350.15},{""price"":1.14,""size"":129.45},{""price"":1.15,""size"":128.73}],""tradedVolume"":[]}}]}],""id"":1}"

        Dim m As Xml.XmlDocument

        m = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(strg, "wurzel")


        Dim xmlReader = New Xml.XmlNodeReader(m)
        Dim DataSet = New DataSet()
        DataSet.ReadXml(xmlReader)


        DataTable2CSV2(DataSet.Tables(1), "C:\Temp\Mäuschen.txt", ";")


        'dt.ReadXml(m)


        'm.Save("C:\Temp\Maus.xml")


    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub




    Private Sub ausgabeZuDatatable(ByVal strg As String)

        Dim dr As DataRow

        dr = antworttabelle.NewRow
        dr("ServerResponse") = strg
        dr("Zeit") = Date.Now.ToString("MM/dd/yyyy HH:mm:ss.fff tt")
        antworttabelle.Rows.Add(dr)

        dr = Nothing

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        For Each rw As DataRow In antworttabelle.Rows
            'Debug.Print(rw("ServerResponse").ToString)
            Debug.Print(rw("Zeit").ToString)
        Next


    End Sub
End Class

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





    Private Property läuft As Boolean = False

    Property antworttabelle As New DataTable

    Private WithEvents newFormConnection As New frmConnection


    Public WithEvents myNewLoginForm As frmLogin


    Public Property Requeststring As String

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.



    End Sub
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

    ''' <summary>
    ''' Klickevent zum Öffnen der Login - Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click

        'Dim myNewLoginForm As frmLogin
        myNewLoginForm = New frmLogin

        myNewLoginForm.ShowDialog()

    End Sub


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

        UctlListEventTypes.myType = GetType(bfObjects.clsListEventTypes)

        UctlListEvents.myType = GetType(bfObjects.clsListEvents)
        UctlListEvents.parentcontrol = UctlListEventTypes


        UctlListMarketCatalogue.myType = GetType(bfObjects.clsListMarketCatalogue)
        UctlListMarketCatalogue.parentcontrol = UctlListEvents

        'Me.UctlListElement1 = New uctlListElement("lasd")
        'Me.UctlListElement1 = New uctlListElement("1")
        'Me.UctlListElement1 = New uctlListElement("2")


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim myNewKeepAliveConnection As New clsConnectionKeepAlive
    End Sub

    Public Function send_keepAlive() As HttpStatusCode
        Dim myNewKeepAliveConnection As New clsConnectionKeepAlive

        Return myNewKeepAliveConnection.status
    End Function

    Private Sub ConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionToolStripMenuItem.Click

        newFormConnection = New frmConnection
        If sender.text = "Connection" Then
            newFormConnection.ShowDialog()
            newFormConnection = Nothing
        End If

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


                t1 = itm.Text
                t2 = itm.SubItems(1).Text
                t3 = itm.SubItems(2).Text
                t4 = itm.SubItems(3).Text
                t5 = itm.SubItems(4).Text
            Next

            sw.WriteLine(sb.ToString)

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
            'End While



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
                DataTable2CSV2(dt, "C:\Temp\export\" & dt.TableName & ".txt", ";")

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


        End While





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


    Public Function SendSportsReq(ByVal jsonString As String) As String



        Dim myURI As New Uri(My.Settings.me_betting_uri)
        Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False



        Dim request As WebRequest = WebRequest.Create(myURI)



        Dim byteArray As Byte() = Encoding.Default.GetBytes(jsonString)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers.Add(CStr("X-Application: " & getKeyValue()))
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

        ergebnis = responseFromServer
        Return responseFromServer

    End Function




    Public Sub getreq(ByRef getrequest As Object) Handles UctlListEventTypes.getreq, UctlListEvents.getreq, UctlListMarketCatalogue.getreq

        Call serializeRequest(getrequest)

        For Each ctl In Me.Controls
            If ctl.name.ToString.Substring(0, 4).ToString.ToUpper = "uctl".ToUpper Then

                ctl.serializedRequestFromForm = getrequest

                'MsgBox("got it")
            End If
        Next


    End Sub

    Public Sub getresp(ByVal getresponse As String) Handles UctlListEventTypes.getresp, UctlListEvents.getresp, UctlListMarketCatalogue.getresp

        For Each ctl In Me.Controls
            If ctl.name.ToString.Substring(0, 4).ToString.ToUpper = "uctl".ToUpper Then

                ctl.serializedResponseFromForm = SendSportsReq(getresponse)

                'MsgBox("got it")
            End If
        Next

        'UctlListEventTypes.serializedResponseFromForm = SendSportsReq(getresponse)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim mc As New MongoClient("mongodb://127.0.0.1:27017")

        Dim db = mc.GetDatabase("dbSodexo")


        Dim collection As IMongoCollection(Of BsonDocument) = db.GetCollection(Of BsonDocument)("veit")

        Dim books As BsonDocument = New BsonDocument() _
        .Add("author", "Veit Luther") _
                                   .Add("title", "Krasser Mongo") _
                                   .Add("neuer Mongo", "Krasser Mongo")

        ' .Add("_id", BsonValue.Create(BsonType.ObjectId)) _



        Try
            collection.InsertOne(books)
        Catch ex As Exception
            Stop
        End Try



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim ev As New Event1 With {.DateTime = "kk", .Name = "Veit"}



        Dim ms As New System.IO.MemoryStream

        'Dim md As New Newtonsoft.Json.Bson.BsonWriter(ms)

        Dim ns As New Newtonsoft.Json.JsonSerializer

        Dim dba As New Newtonsoft.Json.Converters.KeyValuePairConverter




        Using writer As New Newtonsoft.Json.Bson.BsonDataWriter(ms)
            ns = New Newtonsoft.Json.JsonSerializer
            ns.Serialize(writer, ev)
        End Using

        Dim db As BsonDocument


    End Sub

    Public Class Event1
        Public Name
        Public DateTime

    End Class

    Structure PetOwner
        Public Name As String
        Public Pets() As String

    End Structure
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ' Create an array of PetOwner objects.
        Dim petOwners() As PetOwner =
    {New PetOwner With
     {.Name = "Higa, Sidney", .Pets = New String() {"Scruffy", "Sam"}},
     New PetOwner With
     {.Name = "Ashkenazi, Ronen", .Pets = New String() {"Walker", "Sugar"}},
     New PetOwner With
     {.Name = "Price, Vernette", .Pets = New String() {"Scratches", "Diesel"}}}

        ' Call SelectMany() to gather all pets into a "flat" sequence.
        Dim query1 As IEnumerable(Of String) =
    petOwners.SelectMany(Function(petOwner) petOwner.Pets)

        Dim output As New System.Text.StringBuilder("Using SelectMany():" & vbCrLf)
        ' Only one foreach loop is required to iterate through 
        ' the results because it is a one-dimensional collection.
        For Each pet As String In query1
            output.AppendLine(pet)
        Next

        ' This code demonstrates how to use Select() instead 
        ' of SelectMany() to get the same result.
        Dim query2 As IEnumerable(Of String()) =
    petOwners.Select(Function(petOwner) petOwner.Pets)
        output.AppendLine(vbCrLf & "Using Select():")
        ' Notice that two foreach loops are required to iterate through 
        ' the results because the query returns a collection of arrays.
        For Each petArray() As String In query2
            For Each pet As String In petArray
                output.AppendLine(pet)
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())






    End Sub

    Private Shared Sub FillTreeView(ByVal CurrentNodes As TreeNodeCollection,
    ByVal xNode As Xml.XmlNode)
        For Each xChild As Xml.XmlNode In xNode.ChildNodes
            FillTreeView(CurrentNodes.Add(xChild.Name).Nodes, xChild)
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim increment1 = Function(ByRef x) x + 1

        For i = 1 To 7

            Console.WriteLine((Function(increment As Integer) increment + 1)(5))

        Next


        Dim neu = {CDate("10.02.2011"), CDate("11.02.3214")}

        For Each t In neu
            MsgBox(t.ToString)
        Next

    End Sub
End Class

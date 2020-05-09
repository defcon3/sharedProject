Imports System.Net
Imports System.IO
Imports System.Text
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports MongoDB.Driver.Core
Imports MongoDB.Bson.Serialization.Attributes
Imports MongoDB.Bson.Serialization.IdGenerators
Imports MongoDB.Bson.Serialization
Imports System
Imports System.Reflection
Imports System.Collections.Generic
Imports System.Collections
Imports System.Collections.Immutable

Public Class frmAutoBetEngine
    Implements ILogWriter

    ''' <summary>
    ''' Öffentliches Event zum Schreiben ins Log
    ''' </summary>
    ''' <param name="logtext"></param>
    'Public Event writeToLog(ByVal logtext As System.String)
    Public Event ILogWriter_writeToLog(logtext As String) Implements ILogWriter.writeToLog



    ''' <summary>
    ''' Log-Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim myNewLogForm As New frmLog
        Dim myNewlogWriter As New clsLogWriter 'an die öffentliche Funktion muss der handler mit adresse mynewlogform eventname angeschlossen werden.

        Select Case sender.ToString
            Case = "Logging"
                AddHandler myNewLogForm.writeToLog, AddressOf myNewlogWriter.write_log
                myNewLogForm.ShowDialog()
                RemoveHandler myNewLogForm.writeToLog, AddressOf myNewlogWriter.write_log

        End Select


    End Sub


    ''' <summary>
    ''' Login-Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click

        Dim myNewLoginForm As New frmLogin
        Dim myNewlogWriter As New clsLogWriter

        Select Case sender.ToString
            Case = "Login"
                AddHandler myNewLoginForm.writeToLog, AddressOf myNewlogWriter.write_log
                myNewLoginForm.ShowDialog()
                RemoveHandler myNewLoginForm.writeToLog, AddressOf myNewlogWriter.write_log

        End Select
    End Sub


    ''' <summary>
    ''' Connection-Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionToolStripMenuItem.Click
        Dim myNewConnectionForm As New frmConnection
        Dim myNewlogWriter As New clsLogWriter

        Select Case sender.ToString
            Case = "Connection"
                AddHandler myNewConnectionForm.writeToLog, AddressOf myNewlogWriter.write_log
                myNewConnectionForm.ShowDialog()
                RemoveHandler myNewConnectionForm.writeToLog, AddressOf myNewlogWriter.write_log

        End Select
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="jsonString"></param>
    ''' <returns></returns>
    Public Function SendSportsReq(ByVal jsonString As String) As String




        Dim myURI As New Uri(My.Settings.me_betting_uri)
        Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False

        Dim request As WebRequest = WebRequest.Create(myURI)

        Dim byteArray As Byte() = Encoding.Default.GetBytes(jsonString)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers.Add(CStr("X-Application: " & My.Settings.me_delayKey_backup))
        request.Headers.Add("X-Authentication: " & My.Settings.me_cookie_ABE)
        request.ContentLength = byteArray.Length



        Dim datastream As Stream = request.GetRequestStream()
        datastream.Write(byteArray, 0, byteArray.Length)

        datastream.Close()


        ' Dim mmm As New clsBetConnection(jsonString)



        Dim response As WebResponse = request.GetResponse()

        Dim myHttpWebResponse As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
            ' txtConnectionState.Text = "online"
        Else
            ' txtConnectionState.Text = "offline"
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


    ''' <summary>
    ''' Button ListMarketCatalogue
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnListMarketCatalogue_Click(sender As Object, e As EventArgs) Handles btnListMarketCatalogue.Click


        ''' neues Auswahlfenster für ListMarketCatalogue öffnen
        Dim myNewListMarketCatalogue As New frmListMarketCatalogue
        Dim myNewlogWriter As New clsLogWriter
        AddHandler myNewListMarketCatalogue.writeToLog, AddressOf myNewlogWriter.write_log

        myNewListMarketCatalogue.ShowDialog()
        ''' das Auswahlfenster wieder schließen


        Dim f3j As String = "{@method@:@SportsAPING/v1.0/listMarketCatalogue@,@params@:{@filter@:{@eventTypeIds@:[],@marketCountries@:[],@marketTypeCodes@:[],@marketStartTime@:{@from@:null,@to@:null},@eventIds@:[]},@sort@:@FIRST_TO_START@,@maxResults@:@20@,@marketProjection@:[]},@jsonrpc@:@2.0@,@id@:1}".Replace("@", Chr(34))





        ' Dim fj As New clsBetConnection(f3j)
        'Stop




        Dim strg As System.String = ""
        strg = serializeRequest(myNewListMarketCatalogue.myNewListMarketCatalogue)

        Console.WriteLine(strg)

        Dim answer As String
        answer = SendSportsReq(strg)

        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(answer, "wurzel")

        'xmlDoc.Save("C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & DateTime.Now.Ticks & ".xml")



        Me.TextBox1.Text = answer


        Dim uu As bfObjects.structMarketCatalogueResponse



        'Dim mc As New MongoClient("mongodb://192.168.178.44:27017")  - das ist der derzeit nicht laufende server
        Dim mc As New MongoClient("mongodb://127.0.0.1:27017")


        Dim md As IMongoDatabase = mc.GetDatabase("neue")



        Dim t As BsonDocument = MongoDB.Bson.BsonDocument.Parse(answer)

        Dim userCollection As IMongoCollection(Of BsonDocument) = md.GetCollection(Of BsonDocument)("ljkl")

        Try
            userCollection.InsertOne(t)
        Catch ex As Exception
            Stop
        End Try


        'Dim dtvalue As New clsMarketCatalogue
        Dim dtvalue As New bfObjects.clsMarketBookResponse
        'dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsMarketCatalogue)(answer)
        dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketBookResponse)(answer)

        Dim uue = dtvalue.result.ToArray()



        Dim www As bfObjects.clsMarketBookResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketBookResponse)(answer)

        Dim asdf = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.structMarketCatalogueResponse)(answer)


        Dim dorit As bfObjects.structMarketCatalogueResponse.structMarketCatalogue.structCompetition
        dorit.id = 9




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim r As New clsBetConnection("afd")

        r.sendeAnfrage()


        Dim m As New clsJsonToDatatable
        m.zuParsenderString = r.Answerstring


        m.funcParseString(r.Requeststring, r.Answerstring)



    End Sub

    Private Sub frmAutoBetEngine_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\Temp\Text1.json",
          System.Text.Encoding.UTF8)



        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(fileReader, "wurzel")

        xmlDoc.Save("c:\temp\aaa.xml")
        MsgBox(xmlDoc.Schemas.Schemas.ToString())





        Dim bytes() As Byte




        Dim ms As New System.IO.MemoryStream
        Dim vvv As New DataTable("wurzel")

        xmlDoc.Save(ms)

        ms.Position = 0

        Dim t6 As New DataTable
        '   t6.ReadXml(ms)


        bytes = ms.ToArray

        Dim gg = bytes.ToList




        Dim jsadf = ms.ToArray

        vvv.WriteXml(ms)

        ms.Position = 0




        'Using (memStream = New MemoryStream(Convert.FromBase64String(extractedBaseString)))
        '    xmlDoc.Load(memStream)

        'End Using








        Dim xmlreader As Xml.XmlNodeReader

        xmlreader = New Xml.XmlNodeReader(xmlDoc)
        Dim dataset As DataSet
        dataset = New DataSet()
        dataset.ReadXml(xmlreader)

        Dim dta As New DataTable
        dta.ReadXml(xmlreader)


        dataset.Relations.Clear()

        Dim rr As New System.Xml.XmlDataDocument(dataset)



        'Dim xmlDoc As XmlDataDocument = New XmlDataDocument(dataset)
        'xmlDoc.Load("XMLDocument.xml")




        Dim dss As New DataSet
        dss.GetXml()



        DataGridView1.DataSource = dataset.Tables(0)
        DataGridView2.DataSource = dataset.Tables(1)
        DataGridView3.DataSource = dataset.Tables(2)
        DataGridView4.DataSource = dataset.Tables(3)

        'DataGrid1.DataSource = dataset

        'dataset.WriteXmlSchema("C:\temp\schema.xml")


        Dim dt2 = New DataTable("wurzel")
        dt2.ReadXmlSchema("C:\temp\schema.xml")
        dt2.ReadXml("c:\temp\aaa.xml")


        Dim t As New DataViewManager(dataset)

        'DataGridView3.DataSource = dt2


        Dim ds As New DataSet


        Dim dt As DataTable

        ' ds = Newtonsoft.Json.JsonConvert.DeserializeObject(fileReader, GetType(DataSet))



        '        DataSet DataSet = JsonConvert.DeserializeObject < DataSet > (json);

        'DataTable DataTable = DataSet.Tables["Table1"];

        'Console.WriteLine(DataTable.Rows.Count);
        '// 2

        'foreach(DataRow row In dataTable.Rows)
        '{
        '    Console.WriteLine(row["id"] + " - " + row["item"]);


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        Dim b As New clsJsonToDatatable
        DataGridView4.DataSource = b.funcParseString("", "")

        ' das xml welches gelesen werden soll

        ' das schema welches die struktur der zieltabelle erstellt

        ' die transformation welches das ausgangs-xml in die struktur der zieltabelle ueberfuehrt

        ' anpimmeln des xml's in die tabelle mittles readxml


        Exit Sub

        Dim rr As New DataTable
        rr.ReadXmlSchema("C:\Temp\AutoBetEngine\Schemas\auto_generated_market_catalogue.xsd")



        Dim zu As New DataTable

        With zu

            .Columns.Add("jsonrpc", GetType(System.String))
            .Columns.Add("marketId", GetType(System.String))
            .Columns.Add("marketName", GetType(System.String))
            .Columns.Add("totalMatched", GetType(System.Decimal))
            .Columns.Add("selectionId", GetType(System.Int64))
            .Columns.Add("runnerName", GetType(System.String))
            .Columns.Add("handicap", GetType(System.Decimal))
            .Columns.Add("sortPriority", GetType(System.Int64))
            .Columns.Add("id", GetType(System.Int64))
            .Columns.Add("Name", GetType(System.String))
            .TableName = "MarketCatalogue"
        End With


        zu.WriteXmlSchema("C:\Temp\AutoBetEngine\Schemas\auto_generated_market_catalogue.xsd")


        zu.ReadXmlSchema("C:\Temp\neu\xslt_schema.xml")

        zu.ReadXmlSchema("C:\Temp\AutoBetEngine\Schemas\MarketCatalogue.xsd")

        Stop



        Dim ds1 As New DataSet

        Dim xmlfile As XDocument = XDocument.Load("C:\temp\aaa.xml")

        Dim reader As Xml.XmlReader = xmlfile.CreateReader

        ds1.ReadXml(reader)

        Dim xslt As New Xml.Xsl.XslCompiledTransform()
        xslt.Load("C:\Temp\neu\datatable_test2.xsl")
        xslt.Transform("C:\Temp\neu\datatable_test2.xml", "C:\Temp\neu\xslt_transform_result.xml")
        'System.Diagnostics.Process.Start("")

        Dim tsttt As New DataSet

        tsttt.ReadXml("C:\Temp\neu\xslt.xml")







        Dim t2 As Xml.XmlReader


        Dim tttt As New DataTable("runners")
        'tttt.Columns.Add(getcol("dorit"))
        'tttt.Columns.Add(getcol("veit"))
        'tttt.Columns.Add("tyler")


        tttt.ReadXmlSchema("C:\Temp\neu\xslt_schema.xml")

        tttt.ReadXml("C:\Temp\neu\xslt.xml")

        'tttt.WriteXmlSchema("C:\Temp\neu\xslt_schema.xml")




        'marketId
        'marketName
        'totalMatched
        'id
        'Name
        'selectionId
        'runnerName
        'handicap
        'sortPriority


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Dim myNewListMarketCatalogue As New bfObjects.clsListMarketCatalogue

        myNewListMarketCatalogue.params.sort = cboSort.Text
        myNewListMarketCatalogue.params.maxResults = cboMaxResults.Text

        Dim myNewListOfString As New List(Of System.String)

        For Each ea In clbMarketProjection.CheckedItems
            myNewListOfString.Add(ea.ToString)
        Next

        myNewListMarketCatalogue.params.marketProjection = myNewListOfString

        Dim requeststring As String = ""

        requeststring = Newtonsoft.Json.JsonConvert.SerializeObject(myNewListMarketCatalogue)

        Dim myNewLogWriter As New clsLogWriter
        myNewLogWriter.write_log("requeststring geschrieben")



        TextBox2.Text = requeststring






        ' erstelle eine Connection zum Ziel

        ' erstelle eine Abfrage als String

        ' sende die Abfrage zum Ziel

        ' nimm die Antwort
        ' wandle das json in ein xml um
        ' mache aus dem xml ein dataset
        ' füge den Zeitstempel in jeder tabelle hinzu
        ' wandele es wieder in ein json zurück , hihi - mit zeitstempel
        ' speichere das json im mongo
        ' füge den zeitstempel 
        ' erstelle eine tabelle flat and wide


        ' deserialisiere die Antwort
        ' die Klasse muss das xsd und das xsl kennen
        ' wandle gib dann eine tabelle zurück

        ' setze die Antwort an ein steuerelement, welches noch gecustomiezed wird 







    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim m As New ColumnHeader
        m.Text = "Ausgabe"
        m.Width = ColumnHeaderAutoResizeStyle.ColumnContent


        Dim mf As New ListView.ColumnHeaderCollection(ListView1)


        ListView1.View = View.List
        ListView1.View = View.Details
        ListView1.Scrollable = True
        ListView1.FullRowSelect = True
        ListView1.Columns.Add(m)


        ListView1.HeaderStyle = ColumnHeaderStyle.Clickable


        If TextBox2.Text.Length > 50 Then
            ListView1.Items.Add(TextBox2.Text.PadRight(100, " "))
            For i As Integer = 0 To ListView1.Columns.Count() - 1 Step 1
                mf.Item(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

            Next

        End If




        For Each tt As ListViewItem In ListView1.Items
            tt.Selected = True
            ListView1.Select()
            'ListView1.SelectedItems.EnsureVisible()
            ListView1.Items(tt.Index).Font = New Font("Arial", 8, FontStyle.Regular)

        Next

        If ListView1.Items.Count > 0 Then
            ListView1.MultiSelect = False
            ListView1.CheckBoxes = True
            ListView1.Items(0).Selected = True
        End If




    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        For i As Integer = 0 To ListView1.Items.Count() - 1 Step 1
            If ListView1.Items(i).Selected = True Then
                '                MsgBox(ListView1.Items(i).ToString())
            End If
        Next



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim requeststring As String = ""
        For Each itm As ListViewItem In ListView1.Items
            If itm.Checked = True Then
                requeststring = itm.Text
            End If
        Next


        Dim betreq As New clsBetConnection(requeststring)

        ''' sendet die Anfrage an den Server
        betreq.sendeAnfrage()

        'MsgBox(betreq.Answerstring)


        Dim dtvalue = New bfObjects.clsMarketCatalogueResponse
        dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketCatalogueResponse)(betreq.Answerstring)

        'MsgBox(betreq.Answerstring)

        'Dim tn As TreeNode = New TreeNode()
        'tn.Text = "klsjdf"
        'TreeView1.Nodes.Add(tn)



        Dim j As Integer = 0
        Dim k As Integer = 0

        Dim ts = DateTime.UtcNow

        TreeView1.Nodes.Clear()

        Dim md As New ABEresponses.MarketDescription


        For Each le As ABEresponses.MarketCatalogue In dtvalue.result

            TreeView1.Nodes.Add(New TreeNode With {.Text = "marketName: " & le.marketName, .Name = j})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "ID : " & j, .Name = j})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "Zeitstempel: " & ts})

            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "marketId: " & le.marketId})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "marketName: " & le.marketName})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "marketStartTime: " & le.marketStartTime})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "totalMatched: " & le.totalMatched})

            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_persistenceEnabled: " & le.description.persistenceEnabled})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_bspMarket: " & le.description.bspMarket})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_marketTime: " & le.description.marketTime})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_suspendTime: " & le.description.suspendTime})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_bettingType: " & le.description.bettingType})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_turnInPlayEnabled: " & le.description.turnInPlayEnabled})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_marketType: " & le.description.marketType})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_regulator: " & le.description.regulator})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_marketBaseRate: " & le.description.marketBaseRate})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_discountAllowed: " & le.description.discountAllowed})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_wallet: " & le.description.wallet})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_rules: " & le.description.rules})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_rulesHasDate: " & le.description.rulesHasDate})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_priceLadderDescription_type: " & le.description.priceLadderDescription.type})


            For Each runner As ABEresponses.RunnerCatalog In le.runners
                TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "runner: " & runner.runnerName})

                TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "runnerName: " & runner.runnerName})
                TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "handicap: " & runner.handicap})
                TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "selectionId: " & runner.selectionId})
                TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "sortPriority: " & runner.sortPriority})

                If runner.metadata.runnerId <> "---" Then
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_runnerId: " & runner.metadata.runnerId})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_WEIGHT_UNITS: " & runner.metadata.WEIGHT_UNITS})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_ADJUSTED_RATING: " & runner.metadata.ADJUSTED_RATING})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAM_YEAR_BORN: " & runner.metadata.DAM_YEAR_BORN})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAYS_SINCE_LAST_RUN: " & runner.metadata.DAYS_SINCE_LAST_RUN})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_WEARING: " & runner.metadata.WEARING})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAMSIRE_YEAR_BORN: " & runner.metadata.DAMSIRE_YEAR_BORN})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_SIRE_BRED: " & runner.metadata.SIRE_BRED})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_TRAINER_NAME: " & runner.metadata.TRAINER_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_STALL_DRAW: " & runner.metadata.STALL_DRAW})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_SEX_TYPE: " & runner.metadata.SEX_TYPE})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_OWNER_NAME: " & runner.metadata.OWNER_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_SIRE_NAME: " & runner.metadata.SIRE_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_FORECASTPRICE_NUMERATOR: " & runner.metadata.FORECASTPRICE_NUMERATOR})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_FORECASTPRICE_DENOMINATOR: " & runner.metadata.FORECASTPRICE_DENOMINATOR})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_JOCKEY_CLAIM: " & runner.metadata.JOCKEY_CLAIM})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_WEIGHT_VALUE: " & runner.metadata.WEIGHT_VALUE})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAM_NAME: " & runner.metadata.DAM_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_AGE: " & runner.metadata.AGE})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_COLOUR_TYPE: " & runner.metadata.COLOUR_TYPE})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAMSIRE_BRED: " & runner.metadata.DAMSIRE_BRED})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAMSIRE_NAME: " & runner.metadata.DAMSIRE_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_SIRE_YEAR_BORN: " & runner.metadata.SIRE_YEAR_BORN})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_OFFICIAL_RATING: " & runner.metadata.OFFICIAL_RATING})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_FORM: " & runner.metadata.FORM})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_BRED: " & runner.metadata.BRED})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_JOCKEY_NAME: " & runner.metadata.JOCKEY_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAM_BRED: " & runner.metadata.DAM_BRED})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_COLOURS_DESCRIPTION: " & runner.metadata.COLOURS_DESCRIPTION})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_COLOURS_FILENAME: " & runner.metadata.COLOURS_FILENAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_CLOTH_NUMBER: " & runner.metadata.CLOTH_NUMBER})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_CLOTH_NUMBER_ALPHA: " & runner.metadata.CLOTH_NUMBER_ALPHA})
                End If

                k += 1
            Next



            j += 1

        Next



    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim xslt As New Xml.Xsl.XslCompiledTransform()
        xslt.Load("C:\Temp\attempt\transformationsdefinition.xslt")
        xslt.Transform("C:\Temp\attempt\quelle.xml", "C:\Temp\attempt\ziel.xml")

        Dim ds As New DataSet
        ds.ReadXml("C:\Temp\AutoBetEngine\jsons-files\MarketCatalogue_Competition.xml")

        Dim ttt As New System.Windows.Forms.DataGrid
        ttt.Visible = True

        'DataGrid1.DataSource = ds





        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\Temp\timo\1170265002.json",
          System.Text.Encoding.UTF8)



        'fileReader = My.Computer.FileSystem.ReadAllText("C:\Temp\AutoBetEngine\jsons-files\MarketCatalogue_alles.json",
        'System.Text.Encoding.UTF8)



        'Dim xmlDoc As New Xml.XmlDocument
        'xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(fileReader, "wurzel")

        'xmlDoc.Save("c:\temp\timo\1170265002.xml")
        'MsgBox(xmlDoc.Schemas.Schemas.ToString())

        Dim newxml As New Xml.XmlDocument


        Dim xmlnode As Xml.XmlNode


        Dim sb As New StringBuilder

        Dim i = 0
        For Each Line As String In File.ReadLines("C:\Temp\timo\1170265005.json")
            'If i <= 1 Then

            newxml = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(Line, "wurzel")
            newxml.Save("C:\Temp\timo\fertig.xml")

            fileReader = My.Computer.FileSystem.ReadAllText("C:\Temp\timo\fertig.xml",
          System.Text.Encoding.UTF8)

            sb.Append(fileReader)
            Debug.Print(i)
            'End If
            i += 1
        Next


        My.Computer.FileSystem.WriteAllText("C:\Temp\timo\1170265005.xml",
"<pennergaul>" & vbCrLf & sb.ToString & vbCrLf & "</pennergaul>" & vbCrLf, True)

        MsgBox(i)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click


    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TreeView1_Click(sender As Object, e As EventArgs) Handles TreeView1.Click

    End Sub

    Private Sub TreeView1_MouseUp(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseUp
        If TreeView1.SelectedNode Is Nothing Then
        Else
            MsgBox(TreeView1.SelectedNode.Text)

        End If
    End Sub
End Class
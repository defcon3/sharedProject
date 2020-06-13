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
Imports System.Resources
Imports Microsoft.Office.Interop.Excel
Imports System.Globalization
Imports System.Windows.Controls
Imports System.Windows.Forms

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

    Private Sub Button2_Click(sender As Object, e As EventArgs)


        Dim r As New clsBetConnection("afd")

        r.sendeAnfrage()


        Dim m As New clsJsonToDatatable
        m.zuParsenderString = r.Answerstring


        m.funcParseString(r.Requeststring, r.Answerstring)



    End Sub

    Private Sub frmAutoBetEngine_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.TabControl1.Width = Me.Width - 88
        Me.DateTimePicker1.Value = Date.Now
        Me.DateTimePicker2.Value = DateTime.UtcNow.AddDays(3)

        ListView2.Columns.Add("Sportart")
        Dim values() As Long = CType([Enum].GetValues(GetType(enumSportarten)), Long())
        Dim names() As String = CType([Enum].GetNames(GetType(enumSportarten)), String())
        For i = 0 To [Enum].GetValues(GetType(enumSportarten)).Length - 1
            'Debug.Print(values(i) & " uuunnnddddd " & names(i))
            ListView2.Items.Add(New System.Windows.Forms.ListViewItem With {.Text = names(i).ToString, .Tag = values(i), .Checked = IIf(values(i) = 1, True, False)})
        Next


        ListView3.Columns.Add("Laender")
        'Dim vals() As String = CType([Enum].GetValues(GetType(enumlaender)), String())
        Dim nmes() As String = CType([Enum].GetNames(GetType(enumlaender)), String())
        For i = 0 To [Enum].GetValues(GetType(enumlaender)).Length - 1
            'Debug.Print(values(i) & " uuunnnddddd " & names(i))
            ListView3.Items.Add(New System.Windows.Forms.ListViewItem With {.Text = nmes(i).ToString, .Tag = nmes(i), .Checked = IIf(nmes(i) = "DE", True, False)})
        Next




    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("C:\Temp\Text1.json",
          System.Text.Encoding.UTF8)



        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(fileReader, "wurzel")

        xmlDoc.Save("c:\temp\aaa.xml")
        MsgBox(xmlDoc.Schemas.Schemas.ToString())





        Dim bytes() As Byte




        Dim ms As New System.IO.MemoryStream
        Dim vvv As New System.Data.DataTable("wurzel")

        xmlDoc.Save(ms)

        ms.Position = 0

        Dim t6 As New System.Data.DataTable
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

        Dim dta As New System.Data.DataTable
        dta.ReadXml(xmlreader)


        dataset.Relations.Clear()

        Dim rr As New System.Xml.XmlDataDocument(dataset)



        'Dim xmlDoc As XmlDataDocument = New XmlDataDocument(dataset)
        'xmlDoc.Load("XMLDocument.xml")




        Dim dss As New DataSet
        dss.GetXml()



        'DataGrid1.DataSource = dataset

        'dataset.WriteXmlSchema("C:\temp\schema.xml")


        Dim dt2 = New System.Data.DataTable("wurzel")
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

    Private Sub Button4_Click(sender As Object, e As EventArgs)


        Dim b As New clsJsonToDatatable


        ' das xml welches gelesen werden soll

        ' das schema welches die struktur der zieltabelle erstellt

        ' die transformation welches das ausgangs-xml in die struktur der zieltabelle ueberfuehrt

        ' anpimmeln des xml's in die tabelle mittles readxml


        Exit Sub

        Dim rr As New System.Data.DataTable
        rr.ReadXmlSchema("C:\Temp\AutoBetEngine\Schemas\auto_generated_market_catalogue.xsd")



        Dim zu As New System.Data.DataTable

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


        Dim tttt As New System.Data.DataTable("runners")
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

        For Each checkeditemsinlistview2 As System.Windows.Forms.ListViewItem In ListView2.CheckedItems
            myNewListMarketCatalogue.params.filter.eventTypeIds.Add(checkeditemsinlistview2.Tag)
        Next

        For Each checkeditemsinlistview3 As System.Windows.Forms.ListViewItem In ListView3.CheckedItems
            myNewListMarketCatalogue.params.filter.marketCountries.Add(checkeditemsinlistview3.Tag)
        Next


        If RadioButton1.Checked = True Then
            myNewListMarketCatalogue.params.filter.turnInPlayEnabled = True
        End If

        If RadioButton2.Checked = True Then
            myNewListMarketCatalogue.params.filter.turnInPlayEnabled = False
        End If

        Dim m As New bfObjects.clsStartTime
        m.from = DateTimePicker1.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
        m.to = DateTimePicker2.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")
        myNewListMarketCatalogue.params.filter.marketStartTime = m




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


        Dim mf As New System.Windows.Forms.ListView.ColumnHeaderCollection(ListView1)


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




        For Each tt As System.Windows.Forms.ListViewItem In ListView1.Items
            tt.Selected = True
            ListView1.Select()
            'ListView1.SelectedItems.EnsureVisible()
            ListView1.Items(tt.Index).Font = New System.Drawing.Font("Arial", 8, FontStyle.Regular)

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
        For Each itm As System.Windows.Forms.ListViewItem In ListView1.Items
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
        'Dim k As Integer = 0

        Dim ts = DateTime.UtcNow

        TreeView1.Nodes.Clear()

        Dim md As New ABEresponses.MarketDescription


        For Each le As ABEresponses.MarketCatalogue In dtvalue.result

            TreeView1.Nodes.Add(New TreeNode With {.Text = "marketName: " & le.marketName, .Name = j, .Tag = le.marketName})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "ID : " & j, .Name = j, .Tag = j})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "Zeitstempel: " & ts, .Tag = ts})

            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "marketId: " & le.marketId, .Tag = le.marketId})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "marketName: " & le.marketName, .Tag = le.marketName})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "marketStartTime: " & le.marketStartTime, .Tag = le.marketStartTime})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "totalMatched: " & le.totalMatched, .Tag = le.totalMatched})

            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_persistenceEnabled: " & le.description.persistenceEnabled, .Tag = le.description.persistenceEnabled})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_bspMarket: " & le.description.bspMarket, .Tag = le.description.bspMarket})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_marketTime: " & le.description.marketTime, .Tag = le.description.marketTime})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_suspendTime: " & le.description.suspendTime, .Tag = le.description.suspendTime})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_bettingType: " & le.description.bettingType, .Tag = le.description.bettingType})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_turnInPlayEnabled: " & le.description.turnInPlayEnabled, .Tag = le.description.turnInPlayEnabled})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_marketType: " & le.description.marketType, .Tag = le.description.marketType})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_regulator: " & le.description.regulator, .Tag = le.description.regulator})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_marketBaseRate: " & le.description.marketBaseRate, .Tag = le.description.marketBaseRate})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_discountAllowed: " & le.description.discountAllowed, .Tag = le.description.discountAllowed})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_wallet: " & le.description.wallet, .Tag = le.description.wallet})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_rules: " & le.description.rules, .Tag = le.description.rules})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_rulesHasDate: " & le.description.rulesHasDate, .Tag = le.description.rulesHasDate})
            TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "description_priceLadderDescription_type: " & le.description.priceLadderDescription.type, .Tag = le.description.priceLadderDescription.type})


            For Each runner As ABEresponses.RunnerCatalog In le.runners
                TreeView1.Nodes(j).Nodes.Add(New TreeNode With {.Text = "runner: " & runner.runnerName, .Tag = runner.runnerName})

                TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "runnerName: " & runner.runnerName, .Tag = runner.runnerName})
                TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "handicap: " & runner.handicap, .Tag = runner.handicap})
                TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "selectionId: " & runner.selectionId, .Tag = runner.selectionId})
                TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "sortPriority: " & runner.sortPriority, .Tag = runner.sortPriority})

                If runner.metadata.runnerId <> "---" Then
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_runnerId: " & runner.metadata.runnerId, .Tag = runner.metadata.runnerId})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_WEIGHT_UNITS: " & runner.metadata.WEIGHT_UNITS, .Tag = runner.metadata.WEIGHT_UNITS})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_ADJUSTED_RATING: " & runner.metadata.ADJUSTED_RATING, .Tag = runner.metadata.ADJUSTED_RATING})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAM_YEAR_BORN: " & runner.metadata.DAM_YEAR_BORN, .Tag = runner.metadata.DAM_YEAR_BORN})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAYS_SINCE_LAST_RUN: " & runner.metadata.DAYS_SINCE_LAST_RUN, .Tag = runner.metadata.DAYS_SINCE_LAST_RUN})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_WEARING: " & runner.metadata.WEARING, .Tag = runner.metadata.WEARING})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAMSIRE_YEAR_BORN: " & runner.metadata.DAMSIRE_YEAR_BORN, .Tag = runner.metadata.DAMSIRE_YEAR_BORN})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_SIRE_BRED: " & runner.metadata.SIRE_BRED, .Tag = runner.metadata.SIRE_BRED})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_TRAINER_NAME: " & runner.metadata.TRAINER_NAME, .Tag = runner.metadata.TRAINER_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_STALL_DRAW: " & runner.metadata.STALL_DRAW, .Tag = runner.metadata.STALL_DRAW})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_SEX_TYPE: " & runner.metadata.SEX_TYPE, .Tag = runner.metadata.SEX_TYPE})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_OWNER_NAME: " & runner.metadata.OWNER_NAME, .Tag = runner.metadata.OWNER_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_SIRE_NAME: " & runner.metadata.SIRE_NAME, .Tag = runner.metadata.SIRE_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_FORECASTPRICE_NUMERATOR: " & runner.metadata.FORECASTPRICE_NUMERATOR, .Tag = runner.metadata.FORECASTPRICE_NUMERATOR})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_FORECASTPRICE_DENOMINATOR: " & runner.metadata.FORECASTPRICE_DENOMINATOR, .Tag = runner.metadata.FORECASTPRICE_DENOMINATOR})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_JOCKEY_CLAIM: " & runner.metadata.JOCKEY_CLAIM, .Tag = runner.metadata.JOCKEY_CLAIM})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_WEIGHT_VALUE: " & runner.metadata.WEIGHT_VALUE, .Tag = runner.metadata.WEIGHT_VALUE})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAM_NAME: " & runner.metadata.DAM_NAME, .Tag = runner.metadata.DAM_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_AGE: " & runner.metadata.AGE, .Tag = runner.metadata.AGE})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_COLOUR_TYPE: " & runner.metadata.COLOUR_TYPE, .Tag = runner.metadata.COLOUR_TYPE})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAMSIRE_BRED: " & runner.metadata.DAMSIRE_BRED, .Tag = runner.metadata.DAMSIRE_BRED})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAMSIRE_NAME: " & runner.metadata.DAMSIRE_NAME, .Tag = runner.metadata.DAMSIRE_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_SIRE_YEAR_BORN: " & runner.metadata.SIRE_YEAR_BORN, .Tag = runner.metadata.SIRE_YEAR_BORN})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_OFFICIAL_RATING: " & runner.metadata.OFFICIAL_RATING, .Tag = runner.metadata.OFFICIAL_RATING})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_FORM: " & runner.metadata.FORM, .Tag = runner.metadata.FORM})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_BRED: " & runner.metadata.BRED, .Tag = runner.metadata.BRED})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_JOCKEY_NAME: " & runner.metadata.JOCKEY_NAME, .Tag = runner.metadata.JOCKEY_NAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_DAM_BRED: " & runner.metadata.DAM_BRED, .Tag = runner.metadata.DAM_BRED})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_COLOURS_DESCRIPTION: " & runner.metadata.COLOURS_DESCRIPTION, .Tag = runner.metadata.COLOURS_DESCRIPTION})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_COLOURS_FILENAME: " & runner.metadata.COLOURS_FILENAME, .Tag = runner.metadata.COLOURS_FILENAME})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_CLOTH_NUMBER: " & runner.metadata.CLOTH_NUMBER, .Tag = runner.metadata.CLOTH_NUMBER})
                    TreeView1.Nodes(j).Nodes(TreeView1.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "metadata_CLOTH_NUMBER_ALPHA: " & runner.metadata.CLOTH_NUMBER_ALPHA, .Tag = runner.metadata.CLOTH_NUMBER_ALPHA})
                End If


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


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ListBox1.Items.Add(TreeView1.SelectedNode.Tag)

    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        MsgBox(TreeView2.Nodes.Count)

        Dim k As TreeNode

        For Each kk As TreeNode In TreeView2.Nodes

            k = kk

        Next





    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        For i As Integer = 0 To ListView2.Items.Count() - 1 Step 1
            If ListView2.Items(i).Selected = True Then
                '                MsgBox(ListView1.Items(i).ToString())
            End If
        Next

        For Each itm As System.Windows.Forms.ListViewItem In ListView2.Items
            If itm.Checked Then
                MsgBox(itm.Tag)
            End If
        Next

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox(DateTimePicker1.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"))
    End Sub

    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click
        Dim t = ListBox1.SelectedItem.ToString()

        ListBox1.Items.Remove(t)


    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        TabControl1.SelectedTab = TabControl1.TabPages(1)
        For Each li In ListBox1.Items
            ListBox2.Items.Add(li.ToString)
        Next
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Dim myNewListMarketBook As New bfObjects.clsListMarketBook
        For Each itm In ListBox2.Items
            myNewListMarketBook.params.marketIds.Add(itm)
        Next



        Dim priceprojection As New bfObjects.clsPriceProjection
        'priceprojection.priceData.Add("")

        priceprojection.virtualise = IIf(rbY.Checked, True, False)
        priceprojection.rolloverStakes = IIf(rbRY.Checked, True, False)

        'priceprojection abfragen
        For Each i In clbMarkets_PriceData.CheckedItems
            priceprojection.priceData.Add(i.ToString)
        Next
        myNewListMarketBook.params.priceProjection = priceprojection

        'orderprojection abfragen
        For Each i In clbMarkets_OrderProjection.CheckedItems
            'myNewListMarketBook.params.orderProjection.Add(i.ToString)
        Next

        'matchprojection abfragen
        For Each i In clbMarkets_MatchProjection.CheckedItems
            'myNewListMarketBook.params.matchProjection.Add(i.ToString)
        Next

        Dim requeststring As System.String = ""



        requeststring = Newtonsoft.Json.JsonConvert.SerializeObject(myNewListMarketBook)

        txtMarkets.Text = requeststring.ToString

        Dim betreq As New clsBetConnection(requeststring)

        ''' sendet die Anfrage an den Server
        betreq.sendeAnfrage()

        'MsgBox(betreq.Answerstring)


        Dim dtvalue = New bfObjects.clsMarketBookResponse

        dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketBookResponse)(betreq.Answerstring)

        txtAnswerstring.Text = betreq.Answerstring



        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim a As Integer = 0
        Dim b As Integer = 0
        Dim c As Integer = 0



        Dim ts = DateTime.UtcNow

        TreeView2.Nodes.Clear()


        Dim ff As ABEresponses.MarketBook = dtvalue.result(0)

        TreeView2.Nodes.Add(ff.getnode)
        'Dim t = 

        Exit Sub
        Dim et As New ABEresponses.MarketBook


        For Each le As ABEresponses.MarketBook In dtvalue.result

            TreeView2.Nodes.Add(New TreeNode With {.Text = "marketId: " & le.marketId, .Name = j, .Tag = le.marketId})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "Zeitstempel: " & DateAndTime.Now, .Tag = DateAndTime.Now})

            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "isMarketDataDelayed: " & le.isMarketDataDelayed, .Tag = le.isMarketDataDelayed})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "status: " & le.status, .Tag = le.status})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "betDelay: " & le.betDelay, .Tag = le.betDelay})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "totalMatched: " & le.totalMatched, .Tag = le.totalMatched})

            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "bspReconciled: " & le.bspReconciled, .Tag = le.bspReconciled})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "complete: " & le.complete, .Tag = le.complete})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "inplay: " & le.inplay, .Tag = le.inplay})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "numberOfWinners: " & le.numberOfWinners, .Tag = le.numberOfWinners})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "numberOfRunners: " & le.numberOfRunners, .Tag = le.numberOfRunners})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "numberOfActiveRunners: " & le.numberOfActiveRunners, .Tag = le.numberOfActiveRunners})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "lastMatchTime: " & le.lastMatchTime, .Tag = le.lastMatchTime})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "totalAvailable: " & le.totalAvailable, .Tag = le.totalAvailable})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "crossMatching: " & le.crossMatching, .Tag = le.crossMatching})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "runnersVoidable: " & le.runnersVoidable, .Tag = le.runnersVoidable})
            TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "Version: " & le.version, .Tag = le.version})
            ''TreeView2.Nodes(j).Nodes.Add()

            For Each ru In le.runners
                'TreeView2.Nodes(j).Nodes.Add(New TreeNode With {.Text = "selectionId: " & le.runners(j).selectionId, .Tag = le.runners(j).selectionId})
                TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "selectionId: " & ru.handicap, .Tag = ru.selectionId})
                TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "handicap: " & ru.handicap, .Tag = ru.handicap})
                TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "status: " & ru.status, .Tag = ru.status})
                TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "adjustmentFactor: " & ru.adjustmentFactor, .Tag = ru.adjustmentFactor})
                TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "lastPriceTraded: " & ru.lastPriceTraded, .Tag = ru.lastPriceTraded})
                TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "totalMatched: " & ru.totalMatched, .Tag = ru.totalMatched})
                TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "removalDate: " & ru.removalDate, .Tag = ru.removalDate})
                TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add(New TreeNode With {.Text = "ex: " & ru.ex.ToString, .Tag = ru.ex})

                For Each atb As ABEresponses.PriceSize In ru.ex.availableToBack
                    'TreeView2.Nodes(j).Nodes(8).Nodes(7).Nodes(5).Nodes.Add(New TreeNode With {.Text = "calling"})

                    'TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes(TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes).Count - 1)

                    'TreeView2.Nodes(j).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes(TreeView2.Nodes(j).Nodes.Count - 1).Nodes.Add("lkjdsf")
                Next


                a += 1


            Next





            j += 1



            a = 0
        Next






        '@@@


    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbMarkets_MatchProjection.SelectedIndexChanged

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub
End Class
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
Imports Microsoft.ReportingServices.ReportProcessing.ReportObjectModel
Imports Microsoft.ReportingServices.Diagnostics.Internal
Imports Microsoft.Reporting.WinForms
Imports System.Web.UI
Imports System.Xml
Imports System.Linq.Expressions
Imports System.Data.SqlClient
Imports sharedProject.dbdataDataSetHashtagTableAdapters

Public Class frmAutoBetEngine
    Implements ILogWriter

    ''' <summary>
    ''' Öffentliches Event zum Schreiben ins Log
    ''' </summary>
    ''' <param name="logtext"></param>
    'Public Event writeToLog(ByVal logtext As System.String)
    Public Event ILogWriter_writeToLog(logtext As String) Implements ILogWriter.writeToLog


    Private tabMarketCatalogue As New System.Data.DataTable("MarketCatalogue")
    Private tabMarketBook As New System.Data.DataTable("MarketBook")


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


        response.Close()

        ergebnis = responseFromServer
        Return responseFromServer

    End Function

    Private Sub frmAutoBetEngine_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "DbdataDataSetHashtag.tabHashtag". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.TabHashtagTableAdapter.Fill(Me.DbdataDataSetHashtag.tabHashtag)
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



        If chkMarketTypeCodes.Checked = True Then myNewListMarketCatalogue.params.filter.marketTypeCodes.Add(cmbMarketTypeCode.Text)



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
            ListView1.Items(tt.Index).Font = New System.Drawing.Font("Arial", 8, FontStyle.Regular)

        Next

        If ListView1.Items.Count > 0 Then
            ListView1.MultiSelect = False
            ListView1.CheckBoxes = True
            ListView1.Items(0).Selected = True
        End If




    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim requeststring As String = ""
        For Each itm As System.Windows.Forms.ListViewItem In ListView1.Items
            If itm.Checked = True Then
                requeststring = itm.Text
            End If
        Next


        Dim betreq As New clsBetConnection(requeststring)
        betreq.sendeAnfrage()




        Dim dtvalue = New bfObjects.clsMarketCatalogueResponse
        dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketCatalogueResponse)(betreq.Answerstring)


        Dim t4 As New System.Data.DataTable

        dtvalue.gettables()
        t4 = dtvalue.tabs



        TreeView1.Nodes.Clear()

        Dim tn, g As TreeNode




        For Each w As ABEresponses.MarketCatalogue In dtvalue.result
            tn = New TreeNode()
            tn = w.getnode
            'tn = w.getnode.Nodes.Find("EVENT_NAME", True)
            'tn.Text = w.getnode.Nodes.Find("EVENT_NAME", True).text

            g = w.getnode.Nodes.Find("EVENT_NAME", True)(0)


            tn.Text = w.getnode.Nodes.Find("EVENT_COUNTRYCODE", True)(0).Text _
                & " - " _
                & w.getnode.Nodes.Find("EVENTTYPE_ID", True)(0).Text _
                & " - " _
                & w.getnode.Nodes.Find("EVENTTYPE_NAME", True)(0).Text _
                & " - " _
                & w.getnode.Nodes.Find("COMPETITION_NAME", True)(0).Text _
                & " - " _
                & w.getnode.Nodes.Find("EVENT_NAME", True)(0).Text _
                & " - " _
                & w.getnode.Nodes.Find("MARKETCATALOGUE_MARKETSTARTTIME", True)(0).Text _
                & " - " _
                & w.getnode.Nodes.Find("MARKETCATALOGUE_MARKETNAME", True)(0).Text _
                & " - " _
                & w.getnode.Nodes.Find("RUNNERCATALOG_RUNNERNAME", True)(0).Text

            'MsgBox(tn.Find("EVENT_NAME", True).Clone.text.ToString)
            TreeView1.Nodes.Add(tn)

        Next



        Dim m As New clsAutoRequester


        m = New clsAutoRequester
        m.runonce = True
        m.add(requeststring, "tabMarketCatalogue")
        AddHandler m.sendTable, AddressOf aktualisiereTabelle
        m.StartStopp = clsAutoRequester.enumstartstop.start
        'listOfClsAutoRequester.Add(m)
        m.StartStopp = clsAutoRequester.enumstartstop.stopp
        'tabMarketCatalogue = m.tab

        DataGridView2.DataSource = tabMarketCatalogue

    End Sub


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ListBox1.Items.Add(TreeView1.SelectedNode.Tag)

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

        Next

        Dim requeststring As System.String = ""



        requeststring = Newtonsoft.Json.JsonConvert.SerializeObject(myNewListMarketBook)

        'requeststring = TextBox1.Text

        txtMarkets.Text = requeststring.ToString

        Dim betreq As New clsBetConnection(requeststring)

        ''' sendet die Anfrage an den Server
        betreq.sendeAnfrage()

        'MsgBox(betreq.Answerstring)


        Dim dtvalue = New bfObjects.clsMarketBookResponse

        dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketBookResponse)(betreq.Answerstring)

        txtAnswerstring.Text = betreq.Answerstring




        Dim mm As New ABEresponses.MarketBook

        'Dim ff As ABEresponses.MarketBook = dtvalue.result(0)
        TreeView2.Nodes.Clear()
        For Each mbr As ABEresponses.MarketBook In dtvalue.result
            TreeView2.Nodes.Add(mbr.getnode)
            mm = mbr
        Next

        DataGridView1.DataSource = mm.gettable

    End Sub

    Property col As New Collection
    Property listOfClsAutoRequester As New List(Of clsAutoRequester)
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'es wird eine instanz gestartet mit dem string aus dem mittleren steuerelement gestertet und in  der requesterklasse gestartet und diese wird in eine liste gepackt.
        'diese liste ist die grundlage für das listview steuerelement
        Dim anzahlListviewElemente As String = ListView4.Items.Count.ToString
        Dim i As Integer

        col.Add(txtMarkets.Text, anzahlListviewElemente)

        ListView4.Items.Clear()

        Dim lvitem As System.Windows.Forms.ListViewItem

        For i = 0 To col.Count - 1
            lvitem = New System.Windows.Forms.ListViewItem
            lvitem.Text = i
            lvitem.SubItems.Add(txtMarkets.Text)
            lvitem.SubItems.Add("tabMarketBook")
            ListView4.Items.Add(lvitem)
        Next

        For Each c As clsAutoRequester In listOfClsAutoRequester
            c.StartStopp = clsAutoRequester.enumstartstop.stopp
        Next

        listOfClsAutoRequester = New List(Of clsAutoRequester)

        Dim m As New clsAutoRequester

        For j = 0 To ListView4.Items.Count - 1

            m = New clsAutoRequester
            m.add(ListView4.Items(j).SubItems(1).Text, ListView4.Items(j).SubItems(2).Text)

            AddHandler m.sendTable, AddressOf aktualisiereTabelle

            m.StartStopp = clsAutoRequester.enumstartstop.start
            listOfClsAutoRequester.Add(m)

        Next



    End Sub

    Public Sub aktualisiereTabelle(ByVal tab As System.Data.DataTable)
        If tab.TableName = "MarketCatalogue" Then
            tabMarketCatalogue = tab
            DataGridView3.DataSource = Nothing
            DataGridView3.DataSource = tabMarketCatalogue
        ElseIf tab.TableName = "MarketBook" Then
            tabMarketBook = tab
            DataGridView2.DataSource = Nothing
            DataGridView2.DataSource = tabMarketBook
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'MsgBox(tabMarketBook.Rows.Count & " = tabmarketbook - Zeilen" & vbCrLf & tabMarketCatalogue.Rows.Count & " = tabMarketCatalogue - Zeilen")
        Dim rw() As DataRow = Me.DbdataDataSetHashtag.tabHashtag.Select()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MsgBox(tabMarketBook.Rows.Count & " = tabmarketbook - Zeilen" & vbCrLf & tabMarketCatalogue.Rows.Count & " = tabMarketCatalogue - Zeilen")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        For Each ae As clsAutoRequester In listOfClsAutoRequester
            MsgBox(ae.tab.TableName & ": Anzahl = " & ae.tab.Rows.Count)
        Next
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim t As New dbdataDataSetHashtag.tabHashtagDataTable



        TabHashtagTableAdapter.Fill(t)


    End Sub
End Class
﻿Imports System.Net
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

        Dim t4 As New System.Data.DataTable


        Dim u = 0

        t4 = dtvalue.result(0).gettable

        If dtvalue.result.Count > 1 Then
            For u = 1 To dtvalue.result.Count - 1
                't4.AsEnumerable.Union().CopyToDataTable(dtvalue.result(u).gettable)
            Next
        End If



        If dtvalue.result.Count > 0 Then
            DataGridView2.DataSource = dtvalue.result(6).gettable()
        End If

        'For Each col As DataColumn In DataGridView2.DataSource.columns
        '    Debug.Print(col.ColumnName.ToString & "|" & col.DataType.ToString)
        'Next


        Dim m As New clsAutoRequester


        m = New clsAutoRequester
        m.add(requeststring, "tabMarketCatalogue")
        m.StartStopp = clsAutoRequester.enumstartstop.start
        listOfClsAutoRequester.Add(m)
        'Threading.Thread.Sleep(10000)
        'm.StartStopp = clsAutoRequester.enumstartstop.stopp




        Dim j As Integer = 0
        'Dim k As Integer = 0

        Dim ts = DateTime.UtcNow

        TreeView1.Nodes.Clear()


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


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ListBox1.Items.Add(TreeView1.SelectedNode.Tag)

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




        Dim mm As New ABEresponses.MarketBook

        'Dim ff As ABEresponses.MarketBook = dtvalue.result(0)
        TreeView2.Nodes.Clear()
        For Each mbr As ABEresponses.MarketBook In dtvalue.result
            TreeView2.Nodes.Add(mbr.getnode)
            mm = mbr
        Next

        DataGridView1.DataSource = mm.gettable

        'Using connection As New SqlConnection("Server=158.181.48.94; Database=dbdata; User=326773; Password=" & getSqlServerPasswort())

        '    Using SqlBulkCopy As New SqlBulkCopy(connection)

        '        SqlBulkCopy.DestinationTableName = "tabMarketBook"

        '        connection.Open()
        '        SqlBulkCopy.WriteToServer(mm.gettable)
        '        connection.Close()
        '    End Using

        'End Using




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
            m.StartStopp = clsAutoRequester.enumstartstop.start
            listOfClsAutoRequester.Add(m)

        Next








    End Sub
End Class
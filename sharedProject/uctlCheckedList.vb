﻿''' <summary>
''' Klasse des Benutzersteuerelements mit dem CheckedListBox
''' </summary>
Public Class uctlCheckedList

    ''' <summary>
    ''' Übergibt die Abfrage zu serialisieren
    ''' </summary>
    ''' <param name="getreq"></param>
    Public Event getreq(ByRef getreq As Object)

    ''' <summary>
    ''' Übergibt die Antwort zu serialisieren
    ''' </summary>
    ''' <param name="resp"></param>
    Public Event getresp(ByVal resp As String)

    ''' <summary>
    ''' interne Typvariable des Controltypes
    ''' </summary>
    Private _mytype As Type = Nothing

    ''' <summary>
    ''' Nimmt den Inhaltstypen des Controls auf
    ''' </summary>
    ''' <returns></returns>
    Public Property myType() As Type
        ' Abholen des Eigenschaftenwerts 
        Get
            Return _myType
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Type)
            _mytype = Value
            If Not Value Is Nothing Then
                Call _subFormatMe(Value)
            End If
        End Set
    End Property


    ''' <summary>
    ''' Konstruktor der Klasse
    ''' </summary>
    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.


    End Sub

    ''' <summary>
    ''' Datenquelle, die der Checked List Box zugrunde liegt
    ''' </summary>
    ''' <returns>Datenqelle als DataTable</returns>
    Public Property DataSource As New DataTable

    'Public ReadOnly Property _BeschriftungButton As String
    ''' <summary>
    ''' Name der ersten Spalte im ListboxElement
    ''' </summary>
    ''' <returns>Gibt den Namen der ersten Spalte des ListboxElements zurück</returns>
    Public Property Spalte_1 As String = vbNullString

    ''' <summary>
    ''' Name der zweiten Spalte im ListboxElement
    ''' </summary>
    ''' <returns>Gibt den Namen der zweiten Spalte des ListboxElements zurück</returns>
    Public Property Spalte_2 As String = vbNullString

    ''' <summary>
    ''' Name der dritten Spalte im ListboxElement
    ''' </summary>
    ''' <returns>Gibt den Namen der dritten Spalte des ListboxElements zurück</returns>
    Public Property Spalte_3 As String = vbNullString

    ''' <summary>
    ''' Ausgewählte Elemente im CheckeListenElement
    ''' </summary>
    ''' <returns>Gibt die selektierten Element als Liste von Strings zurück</returns>
    Public Property selektierteMenge As List(Of String)

    ''' <summary>
    ''' Funktion, welche die übergebene Tabelle nach bestimmten Spalten durchsucht und dann die aufbereitete Tabelle als DataSource bereitstellt
    ''' </summary>
    ''' <returns></returns>
    Private Function transformTableToListSource() As DataTable
        Return Nothing
    End Function

    ''' <summary>
    ''' Anfrage an den Server
    ''' </summary>
    ''' <returns>serialisierte Anfrage</returns>
    Public Property serializedRequestFromForm As String = ""

    ''' <summary>
    ''' Antwort des Servers
    ''' </summary>
    ''' <returns>Antwortstring des Servers</returns>
    Public Property serializedResponseFromForm As String = ""

    ''' <summary>
    ''' Das Usercontrol von dem die Liste mit markierten Einträgen übernommen wird
    ''' </summary>
    Public WriteOnly Property parentcontrol As UserControl
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As UserControl)
            _parentcontrol = Value
        End Set
    End Property
    ''' <summary>
    ''' Klasseninterne Variable für das Usercontrol von dem die Liste mit den markierten Einträgen übernommen wird.
    ''' </summary>
    ''' <returns></returns>
    Private Property _parentcontrol As UserControl = Nothing


    ''' <summary>
    ''' Klickereignis des Buttons
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub btnButton_Click(sender As Object, e As EventArgs) Handles btnButton.Click

        Dim neueListe As New Object

        Dim serverResponse As String = vbNullString


        ' Fallunterscheidung welches Object das Klickereignis aufruft. Das bedeutet, welches Objekt hat das "UserControl im Bauch"
        ' Den Typnamen bekommt das Steuerelement von aussen eingepflanzt
        ' Es wird das Objekt für die Anfrage aufbereitet
        Select Case myType.FullName.ToString
            ' wenn es vom Typ clsListEventTypes ist ...
            Case = GetType(bfObjects.clsListEventTypes).ToString
                neueListe = New List(Of bfObjects.clsListEventTypes)
                neueListe.Add(New bfObjects.clsListEventTypes)
            Case = GetType(bfObjects.clsListEvents).ToString
                neueListe = New List(Of bfObjects.clsListEvents)
                neueListe.Add(New bfObjects.clsListEvents)



            Case = GetType(bfObjects.clsAvailableToBack).ToString
        End Select





        RaiseEvent getreq(serializeRequest(neueListe))
        RaiseEvent getresp(serializedRequestFromForm)
        serverResponse = serializedResponseFromForm


        ' Aufbereiten des Antwortsstrings
        Dim response As String = serverResponse.Substring(1, serverResponse.Length - 2)
        serverResponse = response.ToString

        ' Deserialisieren des Antwortstrings
        Dim eventTypeResults As New bfObjects.clsEventTypeResultResponse
        eventTypeResults = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsEventTypeResultResponse)(serverResponse)

        Dim xmlDoc As Xml.XmlDocument
        xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(serverResponse, "wurzel")

        Dim xmlreader, dataset
        xmlreader = New Xml.XmlNodeReader(xmlDoc)
        dataset = New DataSet()
        dataset.ReadXml(xmlreader)

        Dim dt As New DataTable
        dt = getDatatableFromResponse(eventTypeResults)


        Dim dt1 As New DataTable
        Dim dc As New DataColumn("col")
        dt1.Columns.Add(dc)
        Dim rw As DataRow

        For Each ea As DataRow In dt.Rows

            rw = dt1.NewRow

            rw("col") = ea.Item(0).ToString.PadLeft(10, " ") & " - " & ea.Item(1).ToString.PadRight(25, " ") & " - " & ea.Item(2)

            dt1.Rows.Add(rw)

        Next

        clbCheckedListBox.DataSource = dt1
        clbCheckedListBox.DisplayMember = "col"






    End Sub

    Private Sub _subFormatMe(ByVal Typ As Type)


        Select Case Typ.FullName.ToString
            ' wenn es vom Typ clsListEventTypes ist ...
            Case = GetType(bfObjects.clsListEventTypes).ToString
                Me.btnButton.Text = "ListEventTypes"
                'neueListe.Add(New bfObjects.clsListEventTypes)
            Case = GetType(bfObjects.clsListEvents).ToString
                Me.btnButton.Text = "ListEvents"



            Case = GetType(bfObjects.clsAvailableToBack).ToString
        End Select

    End Sub


    Private Sub clbCheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbCheckedListBox.ItemCheck

        Dim clb_ci As CheckedListBox.CheckedItemCollection
        clb_ci = clbCheckedListBox.CheckedItems

        Dim i As Integer = 0
        Dim dr As DataRowView



        If clb_ci.Count < 0 Then Exit Sub

        For i = 1 To clb_ci.Count
            Debug.Print(clb_ci.Item(i - 1).ToString)
            dr = clb_ci.Item(i - 1)

        Next


    End Sub
End Class

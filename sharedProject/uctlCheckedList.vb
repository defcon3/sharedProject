''' <summary>
''' Klasse des Benutzersteuerelements mit dem CheckedListBox
''' </summary>
Public Class uctlCheckedList

    Public Event getreq(ByVal getreq As Object)

    ''' <summary>
    ''' Nimmt den Inhaltstypen des Controls auf
    ''' </summary>
    ''' <returns></returns>
    Public Property myType As Type


    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    ''' <summary>
    ''' Datenquelle, die der Checked List Box zugrunde liegt
    ''' </summary>
    ''' <returns>Datenqelle als DataTable</returns>
    Public Property DataSource As DataTable

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

    Public Sub btnButton_Click(sender As Object, e As EventArgs) Handles btnButton.Click

        Dim neueListe As New Object

        ' Request wird durch Newtonsoft serialisiert
        Dim serializedRequest As String = serializeRequest(neueListe)
        serializedRequest = serializeRequest(neueListe)

        Dim serverResponse As String


        Select Case myType.FullName.ToString
            Case = GetType(bfObjects.clsListEventTypes).ToString
                neueListe = New List(Of bfObjects.clsListEventTypes)
                neueListe.Add(New bfObjects.clsListEventTypes)
                RaiseEvent getreq(serializeRequest(neueListe))



            Case = GetType(bfObjects.clsAvailableToBack).ToString
        End Select


        serverResponse = ergebnis


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

        clbListEventTypes.DataSource = dt1
        clbListEventTypes.DisplayMember = "col"






    End Sub




End Class

Public Class clsJsonToDatatable
    Public Property exportDatatable As DataTable

    Public Property zuParsenderString As String = Constants.vbNullString

    ''' <param name="str">Das ist der String der geparst werden soll.</param>
    Public Function funcParseString(ByVal request As String, ByVal answer As String) As DataTable
        Dim myNewLogWriter As New clsLogWriter

        If zuParsenderString = Constants.vbNullString Then
            myNewLogWriter.write_log("String ist Leerstring")
        End If


        Dim xmlDoc As New Xml.XmlDocument
        'Fallunterscheidung, was ist fuer eine Antwort
        If request.Contains("SportsAPING/v1.0/listMarketCatalogue") Then
            xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(answer, "listMarketCatalogue")
        End If

        xmlDoc.Save("c:\temp\tempdoc.xml")

        Dim xmlreader As Xml.XmlNodeReader

        xmlreader = New Xml.XmlNodeReader(xmlDoc)
        Dim dataset As DataSet
        dataset = New DataSet()
        dataset.ReadXml(xmlreader)


        Dim ds As New DataSet
        'ds.ReadXml(xmlDoc)



        ds.ReadXml(xmlDoc)

        Dim stream = New System.IO.MemoryStream



        Dim xw = New Xml.XmlTextWriter(stream, System.Text.Encoding.Default)
        xmlDoc.WriteContentTo(xw)
        ds.ReadXml(stream)


        '''json to xml convetieren
        '''Zeitstempel anfügen


        ''' was ist es für ein string?
        ''' Fallunterscheidung für die Strings



        '''Schemadatei erstellen
        '''xslt erstellen


        ''' datei abspeichern
        ''' in tabelle umstellen


        ''' tabelle an steuerelement anbinden


        Return exportDatatable

    End Function
End Class

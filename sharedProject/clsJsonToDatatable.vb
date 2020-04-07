''' <summary>
''' Die Klasse enthält die Funktion funcParseString, welche mit einer JSON Anfrage und der entsprechenden JSON Antwort eine Tabelle zurückgeben kann.
''' </summary>
Public Class clsJsonToDatatable
    ''' <summary>
    ''' Tabelle, die aus dem Antwortstring ausgeparst wurde.
    ''' </summary>
    ''' <returns></returns>
    Public Property exportDatatable As DataTable

    Public Property zuParsenderString As String = Constants.vbNullString

    ''' <summary>
    ''' Das ist der String der geparst werden soll.
    ''' </summary>
    ''' <param name="request">Das ist der Requeststring, der an den Betfair Server geschickt wurde. Er wird benötigt um das Stammelement des zu parsenden XMLs zu ermiiteln.</param>
    ''' <param name="answer">Das ist der Antwortstring, der vom Betfair Server zuruck kam.</param>
    ''' <returns>Eine Datentabelle, die aus dem Antworstring erstellt wurde</returns>
    Public Function funcParseString(ByVal request As String, ByVal answer As String) As DataTable
        Dim myNewLogWriter As New clsLogWriter

        If zuParsenderString = Constants.vbNullString Then
            myNewLogWriter.write_log("String ist Leerstring")
        End If



        Dim fileReader As System.IO.StreamReader
        fileReader =
        My.Computer.FileSystem.OpenTextFileReader("C:\Temp\AutoBetEngine\jsons-files\MarketCatalogue_Runnerdescription.json")
        Dim stringReader As String
        stringReader = fileReader.ReadToEnd







        ''' development
        Dim xmlDoc As New Xml.XmlDocument
        'xmlDoc.Load("C:\Temp\tempdoc.xml")  '' das wird in der unteren Schleife erstellt und dient an dieser Stelle nur Entwicklungszwecken.


        ''' wenn die Answer ein json ist, muss es noch in ein xml umgewandelt werden.
        xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(stringReader, "MarketCatalogue")


        Dim tt As New DataTable

        'Dim xm As Xml.XmlReader = New Xml.XmlNodeReader(xmlDoc)

        'Fallunterscheidung, was ist fuer eine Antwort
        If request.Contains("SportsAPING/v1.0/listMarketCatalogue") Or 1 = 1 Then
            ' xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(answer, "MarketCatalogue")

            ''' Einlesen des XML-Dokumentes um es in ein Dataset zu ueberfuehren.
            Dim xmlNodeRdr As New Xml.XmlNodeReader(xmlDoc) 'xmlDoc is your XmlDocument
            Dim ds1 As New DataSet()
            ds1.ReadXml(xmlNodeRdr)

            ''' Tick-Zeit manifestieren
            Dim ticks As ULong = 0
            ticks = System.DateTime.UtcNow.Ticks

            ''' Anfügen der Zeitspalte an die erste Tabelle im Dataset
            Dim dc As New DataColumn
            With dc
                .AllowDBNull = False
                .ColumnName = "Zeitstempel"
                .DataType = GetType(System.UInt64)
                .DefaultValue = ticks
            End With
            ds1.Tables(0).Columns.Add(dc)


            ''' Rueckumwandeln des Dataset in eine XML Datei und Schreiben dieser in Verzeichnis
            ds1.WriteXml("C:\Temp\AutoBetEngine\Responses\MarketCatalogue_" & ticks & ".xml")
            myNewLogWriter.write_log("File: C:\Temp\AutoBetEngine\Responses\MarketCatalogue_" & ticks & ".xml - geschrieben")




            'Dim xslt As New Xml.Xsl.XslCompiledTransform() -- wenn die Transformationsdatei zu 100% funzt, wird das xslt file kompiliert
            Dim xslt As New Xml.Xsl.XslTransform
            xslt.Load("C:\Temp\AutoBetEngine\Transformations\MarketCatalogue.xslt")
            xslt.Transform("C:\Temp\AutoBetEngine\Responses\MarketCatalogue_" & ticks & ".xml", "C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & ticks & ".xml")
            'xslt.Transform("C:\Temp\testshot.xml", "C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & System.DateTime.UtcNow.Ticks & ".xml")
            'xslt.Transform(xm, "C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & System.DateTime.UtcNow.Ticks & ".xml")


            ''' Einlesen des transformierten XML in eine Tabelle zur Anzeige
            tt.ReadXmlSchema("C:\Temp\AutoBetEngine\Schemas\MarketCatalogue2.xsd")
            tt.ReadXml("C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & ticks & ".xml")


        End If


        Return tt

    End Function
End Class

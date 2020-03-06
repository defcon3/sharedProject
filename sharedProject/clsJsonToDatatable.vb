Public Class clsJsonToDatatable
    Public Property exportDatatable As DataTable

    Public Property zuParsenderString As String = Constants.vbNullString

    ''' <param name="str">Das ist der String der geparst werden soll.</param>
    Public Function funcParseString(ByVal request As String, ByVal answer As String) As DataTable
        Dim myNewLogWriter As New clsLogWriter

        If zuParsenderString = Constants.vbNullString Then
            myNewLogWriter.write_log("String ist Leerstring")
        End If


        ''' development
        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc.Load("C:\Temp\tempdoc.xml")
        '''

        Dim tt As New DataTable

        Dim xm As Xml.XmlReader = New Xml.XmlNodeReader(xmlDoc)

        'Fallunterscheidung, was ist fuer eine Antwort
        If request.Contains("SportsAPING/v1.0/listMarketCatalogue") Or 1 = 1 Then
            ' xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(answer, "MarketCatalogue")


            Dim xmlNodeRdr As New Xml.XmlNodeReader(xmlDoc) 'xmlDoc is your XmlDocument
            Dim ds1 As New DataSet()
            ds1.ReadXml(xmlNodeRdr)

            Dim ticks As ULong = 0
            ticks = System.DateTime.UtcNow.Ticks


            Dim dc As New DataColumn
            With dc
                .AllowDBNull = False
                .ColumnName = "Zeitstempel"
                .DataType = GetType(System.UInt64)
                .DefaultValue = ticks
            End With

            ds1.Tables(0).Columns.Add(dc)



            'wegschreiben des XML ins Log
            ds1.WriteXml("C:\Temp\AutoBetEngine\Responses\MarketCatalogue_" & ticks & ".xml")


            Dim gg As New Xml.XmlDocument
            gg.Load("C:\Temp\AutoBetEngine\Responses\MarketCatalogue_" & ticks & ".xml")
            Dim js = Newtonsoft.Json.JsonConvert.SerializeXmlNode(gg)


            '  Newtonsoft.Json.JsonConverter()


            Dim ofa As New Object

            'Dim xslt As New Xml.Xsl.XslCompiledTransform() -- wenn die Transformationsdatei zu 100% funzt, wird das xslt file kompiliert
            Dim xslt As New Xml.Xsl.XslTransform
            xslt.Load("C:\Temp\AutoBetEngine\Transformations\MarketCatalogue.xslt")
            xslt.Transform("C:\Temp\MarketCatalogue.xml", "C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & ticks & ".xml")
            'xslt.Transform("C:\Temp\testshot.xml", "C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & System.DateTime.UtcNow.Ticks & ".xml")
            'xslt.Transform(xm, "C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & System.DateTime.UtcNow.Ticks & ".xml")

            gg.Load("C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & ticks & ".xml")

            Dim arglist As New Xml.Xsl.XsltArgumentList
            Dim t As New System.IO.MemoryStream
            ' xslt.Transform(gg, arglist, t)

            'Dim rr As New DataTable
            'Dim zz As New DataSet
            'zz.ReadXml("c:\temp\market_catalogue.xml")

            'rr = zz.Tables(0)
            'rr.WriteXmlSchema("C:\Temp\tempo.xsd")

            'Dim tt As New DataTable()
            'tt.Columns.Add("Zeitstempel", GetType(Int64))
            'tt.Columns.Add("marketId", GetType(Decimal))
            'tt.Columns.Add("marketName", GetType(String))
            'tt.Columns.Add("totalMatched", GetType(Decimal))
            'tt.Columns.Add("selectionId", GetType(Decimal))
            'tt.Columns.Add("runnerName", GetType(String))
            'tt.Columns.Add("handicap", GetType(Decimal))
            'tt.Columns.Add("sortPriority", GetType(Int64))
            'tt.Columns.Add("id", GetType(Int64))
            'tt.Columns.Add("name", GetType(String))

            'tt.WriteXmlSchema("C:\Temp\AutoBetEngine\Schemas\MarketCatalogue2.xsd")



            tt.ReadXmlSchema("C:\Temp\AutoBetEngine\Schemas\MarketCatalogue2.xsd")
            tt.ReadXml("C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & ticks & ".xml")


        End If

        '''json to xml convetieren
        '''Zeitstempel anfügen


        ''' was ist es für ein string?
        ''' Fallunterscheidung für die Strings



        '''Schemadatei erstellen
        '''xslt erstellen


        ''' datei abspeichern
        ''' in tabelle umstellen


        ''' tabelle an steuerelement anbinden



        Return tt

    End Function
End Class

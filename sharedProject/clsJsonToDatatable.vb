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
        xmlDoc.Load("C:\Temp\tempdoc.xml")

        Dim xm As Xml.XmlReader = New Xml.XmlNodeReader(xmlDoc)

        'Fallunterscheidung, was ist fuer eine Antwort
        If request.Contains("SportsAPING/v1.0/listMarketCatalogue") Or 1 = 1 Then
            ' xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(answer, "MarketCatalogue")


            Dim xmlNodeRdr As New Xml.XmlNodeReader(xmlDoc) 'xmlDoc is your XmlDocument
            Dim ds1 As New DataSet()
            ds1.ReadXml(xmlNodeRdr)

            Dim dc As New DataColumn
            With dc
                .AllowDBNull = False
                .ColumnName = "Zeitstempel"
                .DataType = GetType(System.UInt64)
                .DefaultValue = System.DateTime.UtcNow.Ticks
            End With


            Dim ofa As New Object

            Dim xslt As New Xml.Xsl.XslCompiledTransform()
            xslt.Load(GetType(MarketCatalogue))
            'xslt.Transform("C:\Temp\tempdoc.xml", "C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & System.DateTime.UtcNow.Ticks & ".xml")
            xslt.Transform(xm, "C:\Temp\AutoBetEngine\Responses\Market_Catalogue_" & System.DateTime.UtcNow.Ticks & ".xml")
            xslt.Transform(xmlNodeRdr, ofa)

            Dim s As New System.Xml.Xsl.XslCompiledTransform
            ' s.Load()


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


        Return exportDatatable

    End Function
End Class

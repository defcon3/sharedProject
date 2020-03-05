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

        'Fallunterscheidung, was ist fuer eine Antwort
        If request.Contains("SportsAPING/v1.0/listMarketCatalogue") Or 1 = 1 Then
            ' xmlDoc = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(answer, "listMarketCatalogue")


            Dim xmlNodeRdr As New Xml.XmlNodeReader(xmlDoc) 'xmlDoc is your XmlDocument
            Dim ds1 As New DataSet()
            ds1.ReadXml(xmlNodeRdr)

            ds1.Tables(0).Columns.Add("Zeitstempel")



            For Each tab As DataTable In ds1.Tables

                tab.Columns.Add(New DataColumn(ds1.name.tostring))
            Next


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

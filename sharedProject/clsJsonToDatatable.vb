Public Class clsJsonToDatatable
    Public Property exportDatatable As DataTable

    Public Property zuParsenderString As String = Constants.vbNullString

    ''' <param name="str">Das ist der String der geparst werden soll.</param>
    Public Function funcParseString(ByVal str As String) As DataTable
        Dim myNewLogWriter As New clsLogWriter

        If zuParsenderString = Constants.vbNullString Then
            myNewLogWriter.write_log("String ist Leerstring")
        End If

        Dim h
        h = enumRequest.listMarketCatalogue



        Return exportDatatable

    End Function
End Class

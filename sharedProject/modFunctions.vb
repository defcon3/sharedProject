Module modFunctions

    Public Function getPropertyList(ByVal obj As Object) As List(Of itemList)
        Dim t As New List(Of itemList)

        Dim m As itemList

        Dim footype = obj.GetType
        Dim fields = footype.GetFields
        For Each i In fields

            Dim FieldName = i.Name

            Dim FieldType = i.FieldType

            Debug.Print(FieldName.ToString + " " + FieldType.ToString)
            m.itemformat = FieldName.ToString
            m.itemformat = FieldType.ToString
            t.Add(m)
        Next



        Return t

    End Function

    Public Function getDatatableFromResponse(ByVal obj As Object) As DataTable

        Dim dt As New DataTable

        If TypeOf obj Is bfObjects.clsEventTypeResultResponse Then
            Dim etrr As bfObjects.clsEventTypeResultResponse
            etrr = TryCast(obj, bfObjects.clsEventTypeResultResponse)

            dt.Columns.Add("ID")
            dt.Columns.Add("Event-Type")
            dt.Columns.Add("Market Count")


            If etrr.result.Count > 0 Then

                For Each result As bfObjects.clsEventTypeResult In etrr.result
                    Dim dr As DataRow = dt.NewRow
                    dr("ID") = result.eventType.id.ToString
                    dr("Event-Type") = result.eventType.name.ToString
                    dr("Market Count") = result.marketCount.ToString
                    dt.Rows.Add(dr)
                Next

            Else

                dt = New DataTable

            End If



        ElseIf TypeOf obj Is bfObjects.clsEventResultResponse Then
            Dim err As bfObjects.clsEventResultResponse
            err = TryCast(obj, bfObjects.clsEventResultResponse)

            dt.Columns.Add("ID")
            dt.Columns.Add("Event-Name")
            dt.Columns.Add("Country Code")
            dt.Columns.Add("Timezone")
            dt.Columns.Add("open Date")
            dt.Columns.Add("Market Count")

            If err.result.Count > 0 Then

                For Each result As bfObjects.clsEventResult In err.result
                    Dim dr As DataRow = dt.NewRow

                    dr("ID") = result.event.id.ToString
                    dr("Event-Name") = result.event.name.ToString

                    If Not IsNothing(result.event.countryCode) Then
                        dr("Country Code") = result.event.countryCode.ToString
                    Else
                        dr("Country Code") = "XX"
                    End If

                    dr("Timezone") = result.event.timezone.ToString
                    dr("open Date") = result.event.openDate.ToString
                    dr("Market Count") = result.marketCount.ToString

                    dt.Rows.Add(dr)
                Next

            Else

                dt = New DataTable

            End If



        ElseIf TypeOf obj Is bfObjects.structMarketCatalogueResponse Then
            Dim mcr As bfObjects.structMarketCatalogueResponse
            'mcr = TryCast(obj, bfObjects.structMarketCatalogueResponse)

            dt.Columns.Add("Market ID")
            dt.Columns.Add("Market Name")

            If obj.result.Count > 0 Then

                For Each result As bfObjects.structMarketCatalogueResponse.structMarketCatalogue In obj.result
                    Dim dr As DataRow = dt.NewRow

                    dr("Market ID") = result.marketID
                    dr("Market Name") = result.marketName

                    dt.Rows.Add(dr)
                Next

            Else

                dt = New DataTable

            End If


        End If


        Return dt

    End Function


    '-------------------------------------------
    ' Desription: Convert a given enum into a datatable
    '
    ' Parameters: EnumObject - type of the enum
    '             KeyField   - name for the key column, if not 
    '                 supplied it will be set to "KEY" 
    '             ValueField - name for the vaue column, if not 
    '                 supplied it will be set to "VALUE" 
    '--------------------------------------------

    Public Function EnumToDataTable(ByVal EnumObject As Type,
       ByVal KeyField As String, ByVal ValueField As String) As DataTable

        Dim oData As DataTable = Nothing
        Dim oRow As DataRow = Nothing
        Dim oColumn As DataColumn = Nothing

        '-------------------------------------------------------------
        ' Sanity check
        If KeyField.Trim() = String.Empty Then
            KeyField = "KEY"
        End If

        If ValueField.Trim() = String.Empty Then
            ValueField = "VALUE"
        End If
        '-------------------------------------------------------------

        '-------------------------------------------------------------
        ' Create the DataTable
        oData = New DataTable

        oColumn = New DataColumn(KeyField, GetType(System.Int32))
        oData.Columns.Add(KeyField)

        oColumn = New DataColumn(ValueField, GetType(System.String))
        oData.Columns.Add(ValueField)
        '-------------------------------------------------------------

        oData.Rows.Add("-1", "———————")

        '-------------------------------------------------------------
        ' Add the enum items to the datatable
        For Each iEnumItem As Object In [Enum].GetValues(EnumObject)
            oRow = oData.NewRow()
            oRow(KeyField) = CType(iEnumItem, Int32)
            oRow(ValueField) = StrConv(Replace(iEnumItem.ToString(), "_", " "),
                  VbStrConv.ProperCase)
            oRow(ValueField) = iEnumItem.ToString

            oData.Rows.Add(oRow)
        Next
        '-------------------------------------------------------------

        Return oData

    End Function


    Sub DataTable2CSV(ByVal table As DataTable, ByVal filename As String)
        DataTable2CSV(table, filename, vbTab)
    End Sub
    Sub DataTable2CSV(ByVal table As DataTable, ByVal filename As String,
    ByVal sepChar As String)
        Dim writer As System.IO.StreamWriter
        Try
            writer = New System.IO.StreamWriter(filename)

            ' first write a line with the columns name
            Dim sep As String = ""
            Dim builder As New System.Text.StringBuilder
            For Each col As DataColumn In table.Columns
                builder.Append(sep).Append(col.ColumnName)
                sep = sepChar
            Next
            writer.WriteLine(builder.ToString())

            ' then write all the rows
            For Each row As DataRow In table.Rows
                sep = ""
                builder = New System.Text.StringBuilder

                For Each col As DataColumn In table.Columns
                    builder.Append(sep).Append(row(col.ColumnName))
                    sep = sepChar
                Next
                writer.WriteLine(builder.ToString())
            Next
        Finally
            If Not writer Is Nothing Then writer.Close()
        End Try
    End Sub




End Module

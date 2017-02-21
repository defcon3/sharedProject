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


End Module

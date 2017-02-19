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


        End If


        Return dt

    End Function


End Module

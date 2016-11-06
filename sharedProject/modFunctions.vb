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




End Module

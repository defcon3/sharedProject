Module modfunc


    Public Function rekursiv(ByVal obj As Object) As Object



        'Dim CurCols As Reflection.PropertyInfo() = GetType(ABEresponses.Runner).GetProperties
        ' Dim CurCols As Reflection.PropertyInfo() = GetType(ABEresponses.Runner).GetProperties


        Dim z As Object

        'For Each icols In CurCols
        For Each icols In obj.GetType.GetProperties
            Dim coltpye As Type = icols.PropertyType
            If coltpye.IsGenericType AndAlso coltpye.GetGenericTypeDefinition = GetType(List(Of)) Then


                Debug.Print(icols.Name.ToString & " is a generic list")


                z = obj.GetType.GetProperty(icols.Name.ToString)







            End If
        Next


    End Function
End Module

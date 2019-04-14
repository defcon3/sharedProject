Public Class frmListMarketCatalogue
    Property wert As Integer

    Public Property myNewListMarketCatalogue As New bfObjects.clsListMarketCatalogue

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        myNewListMarketCatalogue.params.sort = cboSort.Text
        myNewListMarketCatalogue.params.maxResults = cboMaxResults.Text

        Dim myNewListOfString As New List(Of System.String)

        For Each ea In clbMarketProjection.CheckedItems
            myNewListOfString.Add(ea.ToString)
        Next

        myNewListMarketCatalogue.params.marketProjection = myNewListOfString

        Me.Close()

    End Sub

    Private Sub ClbMarketProjection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbMarketProjection.SelectedIndexChanged

    End Sub
End Class
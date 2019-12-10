Public Class frmListMarketCatalogue
    Property wert As Integer

    Public Property myNewListMarketCatalogue As New bfObjects.clsListMarketCatalogue
    Public Event writeToLog(ByVal logtext As System.String)

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

    Private Sub frmListMarketCatalogue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RaiseEvent writeToLog("tech-> " & Me.Name & " geöffnet.")

    End Sub

    Private Sub frmListMarketCatalogue_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        RaiseEvent writeToLog("tech-> " & Me.Name & " geschlosssen")

    End Sub
End Class
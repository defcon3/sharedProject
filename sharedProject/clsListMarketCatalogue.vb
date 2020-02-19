''' <summary>
''' Klasse zur Abarbeitung des ListMarketCatalogue
''' </summary>
Public Class clsListMarketCatalogue
    Implements ILogWriter

    Public Event writeToLog(logtext As String) Implements ILogWriter.writeToLog
End Class

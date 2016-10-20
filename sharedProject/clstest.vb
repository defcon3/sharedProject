Public Class clstest
    Property jsonrpc
    Property result As List(Of MarketCatalogue)
    Property id
End Class

Public Class MarketCatalogue
    Public marketID As String
    Public marketName As String
    Public marketStartTime As Date
    Public description As MarketDescription
    Public totalMatched As Double
    Public runners As List(Of RunnerCatalog)
    Public eventType As EventType
    Public competition As Competition
    Public [event] As [Event]
End Class


Public Enum MarketBettingType
    ODDS
    LINE
    RANGE
    ASIAN_HANDICAP_DOUBLE_LINE
    ASIAN_HANDICAP_SINGLE_LINE
    FIXED_ODDS
End Enum

Public Class StartTime
    Public from As String
    Public [to] As String
End Class
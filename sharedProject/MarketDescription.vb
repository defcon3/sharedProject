''' <summary>
''' Die Klasse MarketDescription
''' </summary>
Public Class MarketDescription
    Public persistenceEnabled As Boolean
    Public bspMarket As Boolean
    Public marketTime As Date
    Public suspendTime As Date
    Public settleTime As Date
    Public bettingType As MarketBettingType
    Public turnInPlayEnabled As Boolean
    Public marketType As String
    Public regulator As String
    Public marketBaseRate As Double
    Public discountAllowed As Boolean
    Public wallet As String
    Public rules As String
    Public rulesHasDate As Boolean
    Public eachWayDivisor As Double
    Public clarifications As String
End Class

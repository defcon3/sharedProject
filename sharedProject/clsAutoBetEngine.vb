Public Class clsAutoBetEngine
    Public Sub New()

        '''connectionState muss in der Form gesetzt werden. Aber wie heißt di richtige Klasse?

    End Sub
    h
    Property connectionState
    Property bf_json_rpc_address As System.String = "https://api.betfair.com/exchange/betting/json-rpc/v1/"
    Friend Const bf_rest_address As System.String = "https://api.betfair.com/exchange/betting/rest/v1.0/"

End Class

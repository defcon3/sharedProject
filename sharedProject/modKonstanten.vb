Module modKonstanten

    Public delayKey As String
    Public ReadOnly Property myExchangeAdress = "https://api.betfair.com/exchange/betting/json-rpc/v1"
    Public myExchangeURI As New Uri(myExchangeAdress)





    Public Sub getDelayKey()

        Using reader As System.IO.StreamReader = New System.IO.StreamReader("C:\Temp\delayKey.txt")
            ' Read one line from file
            My.Settings.me_delayKey = reader.ReadLine
        End Using


    End Sub


End Module

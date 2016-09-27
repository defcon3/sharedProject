Module modKonstanten


    Public ReadOnly Property myExchangeAdress = "https://api.betfair.com/exchange/betting/json-rpc/v1"
    Public myExchangeURI As New Uri(myExchangeAdress)

    Public Sub getAbeCookie()

        Using reader As System.IO.StreamReader = New System.IO.StreamReader("C:\Temp\cookie_ABE.txt")
            ' Read one line from file
            My.Settings.me_cookie_ABE = reader.ReadLine
        End Using


    End Sub



    Public Sub getDelayKey()

        Using reader As System.IO.StreamReader = New System.IO.StreamReader("C:\Temp\delayKey.txt")
            ' Read one line from file
            My.Settings.me_delayKey = reader.ReadLine
        End Using


    End Sub


End Module

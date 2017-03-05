Imports System.Net
Imports System.IO
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

        'Using reader As System.IO.StreamReader = New System.IO.StreamReader("C:\Temp\delayKey.txt")
        '    ' Read one line from file
        '    My.Settings.me_delayKey = reader.ReadLine
        'End Using


    End Sub


    Public Function beat_heart() As String

        Dim myURI As New Uri(My.Settings.me_heartbeat_uri)
        Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False


        Dim request As WebRequest = WebRequest.Create(myURI)



        Return "Ö"


    End Function

    ''' <summary>
    ''' Enumeration des Requestes
    ''' </summary>
    Public Enum enumRequest

        keepAlive = 1


    End Enum

    Public Class itemList
        Property itemname As String
        Property itemformat As String
    End Class


End Module

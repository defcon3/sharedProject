Module modFunctions




    ''' <summary>
    ''' Die Funktion gibt den Key der gewählten Einstellung zurück
    ''' </summary>
    ''' <returns>Gibt den gewählten Wert aus den Settings zurück</returns>
    Public Function getKeyValue() As String

        Return My.Settings.me_delayKey_backup


        'If My.Settings.me_selected_key = "delay_key" Then
        '    Return My.Settings.me_delayKey.ToString
        'Else
        '    Return My.Settings.me_normalKey
        'End If

    End Function


    Public Function serialisiereRequest(ByVal requestList As List(Of bfObjects.clsListMarketCatalogue)) As String

        Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(requestList)

        Return temp

    End Function
    Public Function serializeRequest(ByVal requestList As Object) As String

        Return Newtonsoft.Json.JsonConvert.SerializeObject(requestList)

    End Function

    Public Function getSqlServerPasswort() As String
        Dim password As System.String = ""

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Temp\AutoBetEngine\Settings\SQLServerPassword.txt")
        password = fileReader.ReadLine()

        Return password
    End Function



End Module


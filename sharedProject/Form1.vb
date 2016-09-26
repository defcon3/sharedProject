Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1



    Public WithEvents puplic As frmLogin


    ''' <summary>
    ''' diese Routine wird durch cas Schlíeßen der Login Form ausgelöst
    ''' Es muss der cookie ins filesystem geschrieben werden.
    ''' </summary>
    ''' <param name="nachricht">der coookie</param>
    Private Sub write_cookie(ByVal nachricht As String) Handles puplic.getCookie

        Dim sb As New System.Text.StringBuilder
        sb.Append(nachricht)
        txtCookie.Text = sb.ToString
        txtCookie.Width = 200
        'Dim writer As New System.IO.TextWriter()
        Dim writeFile As System.IO.TextWriter = New _
            StreamWriter("c:\temp\cookie_ABE.txt", False, encoding:=Encoding.ASCII)
        writeFile.WriteLine(sb.ToString)
        My.Settings.me_cookie_ABE = sb.ToString
        writeFile.Flush()
        writeFile.Close()
        writeFile = Nothing




    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click

        'Dim myNewLoginForm As frmLogin

        puplic = New frmLogin

        puplic.ShowDialog()



    End Sub


    Private Function SendSportsReq(ByVal jsonString As String)

        Dim myURI As New Uri("https://api.betfair.com/exchange/betting/json-rpc/v1")
        Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False


        Dim request As WebRequest = WebRequest.Create(myURI)



        Dim byteArray As Byte() = Encoding.Default.GetBytes(jsonString)

        request.Method = "POST"

        request.ContentType = "application/json"
        request.Headers.Add(CStr("X-Application: " & My.Settings.me_delayKey))
        request.Headers.Add("X-Authentication: " & My.Settings.me_cookie_ABE)
        Dim bl = Encoding.Default.GetBytes(jsonString)
        request.ContentLength = bl.Length



        Dim datastream As Stream = request.GetRequestStream()
        datastream.Write(byteArray, 0, bl.Length)

        datastream.Close()

        Dim response As WebResponse = request.GetResponse()
        datastream = response.GetResponseStream()

        Dim reader As New StreamReader(datastream)
        Dim responseFromServer As String = reader.ReadToEnd()



        reader.Close()
        datastream.Close()


        Debug.Print(responseFromServer.ToString)
        response.Close()

        Return responseFromServer

    End Function

    Public Class mcr
        Public jsonrpc As String = "2.0"
        Public method As String = "SportsAPING/v1.0/listMarketCatalogue"
        Public params As New Params
        Public id As Integer = 1
    End Class

    Public Class Params
        Public filter As New Filter
        Public sort As String = "FIRST_TO_START"
        Public maxResults As String = "200"
        Public marketProjection As New List(Of String)
    End Class

    Public Class Filter
        Public eventTypeIds As New List(Of String)
        Public marketCountries As New List(Of String)
        Public marketTypeCodes As New List(Of String)
        Public marketStartTime As New startTime
    End Class

    Public Class StartTime
        Public from As String
        Public [to] As String
    End Class

    Function seria(ByVal requestList As List(Of mcr)) As String

        Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(requestList)
        'MsgBox(temp)
        Return temp

    End Function



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim neueListe As New List(Of mcr)

        neueListe.Add(New mcr)

        Dim t As String
        t = seria(neueListe)

        Dim g As String
        g = SendSportsReq(t)



        Dim cls As New clstest


        Dim sett As New Newtonsoft.Json.JsonSerializerSettings
        sett.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace




        Dim i = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clstest)(g)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        getDelayKey()
    End Sub

End Class

﻿Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1


    Property newClsAutoBetEngineSession As New clsAutoBetEngineSession
    Public WithEvents puplic As frmLogin


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim v_ABE As New clsAutoBetEngine

        Dim req As WebRequest = WebRequest.Create(v_ABE.bf_json_rpc_address)

        With req
            .Method = "GET" '~~> I believe we use Get if we are just retrieving and Post if putting something? both work
            .ContentType = "application/json" '~~> Normals
            'laber-rababer3
            '~~> Add Headers <~~'
            .Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8")
            .Headers.Add("X-Authentication", newClsAutoBetEngineSession.token) '~~> Mandatory
        End With

        Dim m '
        m = req.GetResponse()
    End Sub



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
            StreamWriter("c:\temp\cookie_ABE.txt", False, encoding:=Encoding.UTF8)
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

        Dim request As WebRequest = WebRequest.Create("https://api.betfair.com/exchange/betting/json-rpc/v1")
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(jsonString)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.ContentLength = byteArray.Length
        request.Headers.Add(CStr("X-Application: " & ""))
        request.Headers.Add("X-Authentication: " & My.Settings.me_cookie_ABE)

        Dim datastream As Stream = request.GetRequestStream()
        datastream.Write(byteArray, 0, byteArray.Length)

        Dim response As WebResponse = request.GetResponse()
        datastream = response.GetResponseStream()

        Dim reader As New StreamReader(datastream)
        Dim responseFromServer As String = reader.ReadToEnd()

        MsgBox(responseFromServer.ToString)

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
        MsgBox(temp)
        Return temp

    End Function



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim neueListe As New List(Of mcr)

        neueListe.Add(New mcr)

        Dim t As String
        t = seria(neueListe)
        SendSportsReq(t)

    End Sub
End Class

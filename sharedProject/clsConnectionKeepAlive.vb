﻿Imports System.IO
Imports System.Net
Imports System.Text

Public Class clsConnectionKeepAlive
    Inherits clsConnectionRoot
    Property properitaeten As String

    Dim myURI As New Uri(My.Settings.me_keepAlive_uri)
    Dim mySP As System.Net.ServicePoint = System.Net.ServicePointManager.FindServicePoint(myURI)
    Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(myURI)

    Public Sub New()
        mySP.Expect100Continue = False


        Dim neueListe As New List(Of keepClass)



        neueListe.Add(New keepClass)


        Dim serialisierteAnfrage As String
        serialisierteAnfrage = serialisiereRequest(neueListe)


        Dim byteArray As Byte() = Encoding.Default.GetBytes(serialisierteAnfrage)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers.Add(CStr("X-Application: " & My.Settings.me_delayKey))
        request.Headers.Add("X-Authentication: " & My.Settings.me_cookie_ABE)
        Dim bl = Encoding.Default.GetBytes(byteArray.ToString)
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



    End Sub

    Private Class keepClass
        Property token
        Property product
        Property status
        Property [error]



    End Class




    Dim asa As String

    Private Function serialisiereRequest(ByVal newlist As List(Of keepClass)) As String

        Dim temp As String = Newtonsoft.Json.JsonConvert.SerializeObject(newlist)
        'MsgBox(temp)
        Return temp


    End Function



    '    request.Method = "POST"
    '    request.ContentType = "application/json"
    '    request.Headers.Add(CStr("X-Application: " & My.Settings.me_delayKey))
    '    request.Headers.Add("X-Authentication: " & My.Settings.me_cookie_ABE)
    '    Dim bl = Encoding.Default.GetBytes(jsonString)
    '    request.ContentLength = bl.Length



    '    Dim datastream As Stream = request.GetRequestStream()
    '    datastream.Write(byteArray, 0, bl.Length)

    '    datastream.Close()

    '    Dim response As WebResponse = request.GetResponse()

    'Dim myHttpWebResponse As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
    'If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
    '        txtConnectionState.Text = "online"
    '    Else
    '        txtConnectionState.Text = "offline"
    '    End If


    '    datastream = response.GetResponseStream()

    '    Dim reader As New StreamReader(datastream)
    'Dim responseFromServer As String = reader.ReadToEnd()



    '    reader.Close()
    '    datastream.Close()


    '    Debug.Print(responseFromServer.ToString)
    '    response.Close()

    '    Return responseFromServer



End Class

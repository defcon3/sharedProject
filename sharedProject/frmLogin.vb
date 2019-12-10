Imports System.Net
Imports System.IO
Imports System.Text
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports MongoDB.Driver.Core
Imports MongoDB.Bson.Serialization.Attributes
Imports MongoDB.Bson.Serialization.IdGenerators
Imports MongoDB.Bson.Serialization
Imports System
Imports System.Reflection
Imports System.Collections.Generic
Imports System.Collections

Imports System.ComponentModel
''' <summary>
''' Die Form, in der der Login gemacht wird.
''' </summary>
Public Class frmLogin

    Public Event getCookie(ByVal ssoid As String)
    Public Event writeToLog(ByVal logtext As System.String)

    Private Sub frmLogin_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim ar As String() = WebBrowser1.Document.Cookie.Split(";")

        Dim t = WebBrowser1.Document.Cookie.Split(";").ToList

        For Each ea In t
            Dim m
            m = ea.ToString.Split("=")(0)
            If Trim(m) = "ssoid" Then
                RaiseEvent getCookie(ea.ToString.Split("=")(1) & "=")
                My.Settings.me_cookie_ABE = ea.ToString.Split("=")(1) & "="
                My.Settings.Save()
                RaiseEvent writeToLog("tech-> Cookie """ & My.Settings.me_cookie_ABE & """ gespeichert.")
            End If
        Next

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        RaiseEvent writeToLog("tech-> " & Me.Name & " geöffnet.")
    End Sub

    Private Sub frmLogin_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        RaiseEvent writeToLog("tech-> " & Me.Name & " geschlossen.")
    End Sub

    Dim jsonstring As String = "https://identitysso.betfair.com/api/login"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim jsstr As String = jsonstring
        Dim bl = Encoding.Default.GetBytes(jsstr)

        Dim data = Encoding.UTF8.GetBytes(jsstr)
        Dim myURI As New Uri(My.Settings.me_login_uri)
        Dim result_post = SendRequest(myURI, data, "application/json", "POST")


        'request.Method = "POST"
        'request.ContentType = "application/json"
        'request.Headers.Add(CStr("X-Application: " & getKeyValue()))






        'Dim myURI As New Uri(My.Settings.me_login_uri)
        Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False



        Dim request As WebRequest = WebRequest.Create(myURI)



        Dim byteArray As Byte() = Encoding.Default.GetBytes(jsonString)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers.Add(CStr("X-Application: " & getKeyValue()))
        'request.Headers.Add("X-Authentication: " & My.Settings.me_cookie_ABE)


        'jsstr = jsonstring & "&powmia&wass3rsti77"


        'Dim bl = Encoding.Default.GetBytes(jsstr)
        request.ContentLength = bl.Length



        Dim datastream As Stream = request.GetRequestStream()
        datastream.Write(byteArray, 0, bl.Length)

        datastream.Close()

        Dim txtConnectionState

        Dim response As WebResponse = request.GetResponse()

        Dim myHttpWebResponse As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
            ' txtConnectionState.Text = "online"
        Else
            ' txtConnectionState.Text = "offline"
        End If


        datastream = response.GetResponseStream()

        Dim reader As New StreamReader(datastream)
        Dim responseFromServer As String = reader.ReadToEnd()



        reader.Close()
        datastream.Close()


        'Debug.Print(responseFromServer.ToString)
        response.Close()

        ergebnis = responseFromServer
        'Return responseFromServer

    End Sub


    Private Function SendRequest(uri As Uri, jsonDataBytes As Byte(), contentType As String, method As String) As String
        Dim response As String
        Dim request As WebRequest

        request = WebRequest.Create(uri)
        ' request.Credentials = New NetworkCredential("powmia", "wass3rsti77")


        request.ContentLength = jsonDataBytes.Length
        request.ContentType = contentType
        request.Method = method

        Using requestStream = request.GetRequestStream
            requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
            requestStream.Close()

            Using responseStream = request.GetResponse.GetResponseStream
                Using reader As New StreamReader(responseStream)
                    response = reader.ReadToEnd()
                End Using
            End Using
        End Using

        Return response
    End Function


End Class
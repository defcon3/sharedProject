Imports System.Net
Imports System.IO
Imports System.Text
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports MongoDB.Driver.Core
Imports MongoDB.Bson.Serialization.Attributes
Imports MongoDB.Bson.Serialization.IdGenerators
Imports MongoDB.Bson.Serialization


Public Class frmAutoBetEngine


    ''' <summary>
    ''' Log-Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim myNewLogForm As New frmLog
        Dim myNewlogWriter As New clsLogWriter 'an die öffentliche Funktion muss der handler mit adresse mynewlogform eventname angeschlossen werden.

        Select Case sender.ToString
            Case = "Logging"
                AddHandler myNewLogForm.writeToLog, AddressOf myNewlogWriter.write_log
                myNewLogForm.ShowDialog()
                RemoveHandler myNewLogForm.writeToLog, AddressOf myNewlogWriter.write_log

        End Select


    End Sub


    ''' <summary>
    ''' Login-Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click

        Dim myNewLoginForm As New frmLogin
        Dim myNewlogWriter As New clsLogWriter

        Select Case sender.ToString
            Case = "Login"
                AddHandler myNewLoginForm.writeToLog, AddressOf myNewlogWriter.write_log
                myNewLoginForm.ShowDialog()
                RemoveHandler myNewLoginForm.writeToLog, AddressOf myNewlogWriter.write_log

        End Select
    End Sub


    ''' <summary>
    ''' Connection-Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionToolStripMenuItem.Click
        Dim myNewConnectionForm As New frmConnection
        Dim myNewlogWriter As New clsLogWriter

        Select Case sender.ToString
            Case = "Connection"
                AddHandler myNewConnectionForm.writeToLog, AddressOf myNewlogWriter.write_log
                myNewConnectionForm.ShowDialog()
                RemoveHandler myNewConnectionForm.writeToLog, AddressOf myNewlogWriter.write_log

        End Select
    End Sub



    Public Function SendSportsReq(ByVal jsonString As String) As String



        Dim myURI As New Uri(My.Settings.me_betting_uri)
        Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False



        Dim request As WebRequest = WebRequest.Create(myURI)



        Dim byteArray As Byte() = Encoding.Default.GetBytes(jsonString)

        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers.Add(CStr("X-Application: " & getKeyValue()))
        request.Headers.Add("X-Authentication: " & My.Settings.me_cookie_ABE)
        Dim bl = Encoding.Default.GetBytes(jsonString)
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
        Return responseFromServer

    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnListMarketCatalogue_Click(sender As Object, e As EventArgs) Handles btnListMarketCatalogue.Click


        Dim myNewListMarketCatalogue As New frmListMarketCatalogue
        myNewListMarketCatalogue.ShowDialog()



        Dim strg As System.String = ""
        strg = serializeRequest(myNewListMarketCatalogue.myNewListMarketCatalogue)


        Dim answer As String
        answer = SendSportsReq(strg)

        Dim mc As New MongoClient("mongodb://192.168.178.44:27017")

        Dim db = mc.GetDatabase("ListMarketCatalogue_" & CStr(Date.Now.Year) & "_" & CStr(Date.Now.Month) & "_" & CStr(Date.Now.Day))


        'answer in bson document umwandeln


        Dim t As BsonDocument = MongoDB.Bson.BsonDocument.Parse(answer)

        Dim collection = db.GetCollection(Of BsonDocument)("ListMarketCatalogue")

        'Dim dtvalue As New Object
        'dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(answer)



        'Dim collection As IMongoCollection(Of BsonDocument) = db.GetCollection()

        Dim eventTypeResults = New List(Of bfObjects.clsListMarketCatalogue)


        eventTypeResults.Add(Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsListMarketCatalogue)(answer))





        Try
            collection.InsertOne(t)
        Catch ex As Exception
            Stop
        End Try


        Dim veit As New bfObjects.clsAvailableToBack
        veit.price = 6

        'Dim eventTypeResults = New List(Of ABEresponses.clsMarketCatalogue)


        ' eventTypeResults.Add(Newtonsoft.Json.JsonConvert.DeserializeObject(Of ABEresponses.clsMarketCatalogue)(answer))


    End Sub
End Class
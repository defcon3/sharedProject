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


Public Class frmAutoBetEngine
    Implements ILogWriter

    ''' <summary>
    ''' Öffentliches Event zum Schreiben ins Log
    ''' </summary>
    ''' <param name="logtext"></param>
    'Public Event writeToLog(ByVal logtext As System.String)
    Public Event ILogWriter_writeToLog(logtext As String) Implements ILogWriter.writeToLog



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


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="jsonString"></param>
    ''' <returns></returns>
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
    ''' Button ListMarketCatalogue
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnListMarketCatalogue_Click(sender As Object, e As EventArgs) Handles btnListMarketCatalogue.Click


        Dim myNewListMarketCatalogue As New frmListMarketCatalogue
        Dim myNewlogWriter As New clsLogWriter
        AddHandler myNewListMarketCatalogue.writeToLog, AddressOf myNewlogWriter.write_log

        myNewListMarketCatalogue.ShowDialog()



        Dim myNewConnectionForm As New frmConnection


        Select Case sender.ToString
            Case = "Connection"
                AddHandler myNewConnectionForm.writeToLog, AddressOf myNewlogWriter.write_log
                myNewConnectionForm.ShowDialog()
                RemoveHandler myNewConnectionForm.writeToLog, AddressOf myNewlogWriter.write_log

        End Select





        Dim strg As System.String = ""
        strg = serializeRequest(myNewListMarketCatalogue.myNewListMarketCatalogue)


        Dim answer As String
        answer = SendSportsReq(strg)
        Me.TextBox1.Text = answer





        'Dim mc As New MongoClient("mongodb://192.168.178.44:27017")  - das ist der derzeit nicht laufende server
        Dim mc As New MongoClient("mongodb://127.0.0.1:27017")


        Dim md As IMongoDatabase = mc.GetDatabase("neue")



        Dim t As BsonDocument = MongoDB.Bson.BsonDocument.Parse(answer)




        Dim dtvalue As New clsMarketCatalogue
        dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of clsMarketCatalogue)(answer)

        Dim uu = dtvalue.result.ToArray()


        Dim dataset1 As New DataSet

        Dim www As bfObjects.clsMarketBookResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketBookResponse)(answer)




        Dim zzz As IMongoCollection(Of clsMarketCatalogue)

        Dim userCollection As IMongoCollection(Of BsonDocument) = md.GetCollection(Of BsonDocument)("ljkl")





        Try
            userCollection.InsertOne(t)
        Catch ex As Exception
            Stop
        End Try



    End Sub
    ''' <summary>
    ''' Public Class clsMarketCatalogue
    ''' </summary>
    Public Class clsMarketCatalogue
        Public Property jsonrpc As String
        Public result As List(Of ABEresponses.MarketCatalogue)
        Public id As Integer

    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim CurCols() As PropertyInfo = GetType(ABEresponses.MarketCatalogue).GetGenericArguments()(0).GetProperties

        'Dim CurCols() As PropertyInfo = GetType(ABEresponses.MarketCatalogue).GetGenericArguments()(0).GetProperties
        'Dim anzahla = GetType(ABEresponses.MarketCatalogue).GetGenericArguments.Count
        ' .GetProperties()

        Dim t As New ABEresponses.Runner
        Dim tt
        tt = modfunc.rekursiv(t)



        'Dim CurCols As Reflection.PropertyInfo() = GetType(ABEresponses.MarketCatalogue).GetProperties
        Dim CurCols As Reflection.PropertyInfo() = GetType(ABEresponses.Runner).GetProperties




        For Each icols In CurCols
            Dim coltpye As Type = icols.PropertyType
            If coltpye.IsGenericType AndAlso coltpye.GetGenericTypeDefinition = GetType(List(Of)) Then
                Debug.Print(icols.Name.ToString & " is a generic list")
            End If
        Next

        '.GetType.GetGenericArguments()(0).GetProperties

        'Dim type() As System.Reflection.PropertyInfo = ABEresponses.MarketCatalogue.GetType.GetGenericArguments()(0).GetProperties





        'Dim t1 As New ABEresponses.MarketCatalogue
        'Dim pi As Reflection.PropertyInfo() = t1.GetType.GetProperties()
        'For Each a1 In pi

        '    Debug.Print(a1.Name)

        'Next




    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.StatusStrip1.BringToFront()
        Me.StatusStrip1.BackColor = Color.Blue


        'Dim t As New ToolStripItemCollection
        Dim z As New ToolStripButton

        z.Text = "Veitele"
        Me.StatusStrip1.Items.Add(z)
        Dim z2 As New ToolStripButton

        z2.Text = "Veitele2"
        Me.StatusStrip1.Items.Add(z2)


    End Sub

    Private Sub frmAutoBetEngine_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub
End Class
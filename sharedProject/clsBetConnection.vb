Imports System.Net
Imports System.Text

Public Class clsBetConnection


    Inherits clsConnectionRoot

    ''' <summary>
    ''' interne Klassenvariable zum Uebergeben der Webrequest innerhalb der Klasse
    ''' </summary>
    ''' <returns></returns>
    Private Property _webrequest As WebRequest
    Private Property _requeststream As System.IO.Stream
    Private Property _serveranswer As System.String
    Private Property _requeststring As System.String

    Sub New()

        Dim f3j As String = "{@method@:@SportsAPING/v1.0/listMarketCatalogue@,@params@:{@filter@:{@eventTypeIds@:[],@marketCountries@:[],@marketTypeCodes@:[],@marketStartTime@:{@from@:null,@to@:null},@eventIds@:[]},@sort@:@FIRST_TO_START@,@maxResults@:@20@,@marketProjection@:[]},@jsonrpc@:@2.0@,@id@:1}".Replace("@", Chr(34))

        Me.Requeststring = f3j

        Dim byteArray As Byte() = System.Text.Encoding.Default.GetBytes(f3j)

        Dim rer = MyClass.webReq
        rer.ContentLength = byteArray.Length

        _webrequest = webReq


        MyClass.webReq.ContentLength = byteArray.Length

        _webrequest.ContentLength = byteArray.Length


        Dim datastream As System.IO.Stream = _webrequest.GetRequestStream()
        datastream.Write(byteArray, 0, byteArray.Length)

        datastream.Close()






        Dim response As WebResponse = rer.GetResponse()

        Dim myHttpWebResponse As HttpWebResponse = CType(rer.GetResponse(), HttpWebResponse)
        If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
            ' txtConnectionState.Text = "online"
        Else
            ' txtConnectionState.Text = "offline"
        End If


        datastream = response.GetResponseStream()

        Dim reader As New System.IO.StreamReader(datastream)
        Dim responseFromServer As String = reader.ReadToEnd()



        reader.Close()
        datastream.Close()




    End Sub

    ''' <param name="Anfrage">Der Konstruktor nimmt gleichzeitig den Anfragestring mit auf</param>
    Sub New(Anfrage As String)

        Dim f3j As String = "{@method@:@SportsAPING/v1.0/listMarketCatalogue@,@params@:{@filter@:{@eventTypeIds@:[],@marketCountries@:[],@marketTypeCodes@:[],@marketStartTime@:{@from@:null,@to@:null},@eventIds@:[]},@sort@:@FIRST_TO_START@,@maxResults@:@20@,@marketProjection@:[]},@jsonrpc@:@2.0@,@id@:1}".Replace("@", Chr(34))

        'Me.Requeststring = f3j



        Requeststring = f3j
        Requeststring = Anfrage



        Dim myNewLogWriter As New clsLogWriter
        'myNewLogWriter.write_log(Requeststring)


        Dim byteArray As Byte() = System.Text.Encoding.Default.GetBytes(Requeststring)


        _webrequest = webReq
        _webrequest.ContentLength = byteArray.Length


        'Dim datastream As System.IO.Stream = _webrequest.GetRequestStream()
        'datastream.Write(byteArray, 0, byteArray.Length)

        'datastream.Close()

        _requeststream = _webrequest.GetRequestStream
        _requeststream.Write(byteArray, 0, byteArray.Length)
        _requeststream.Close()




    End Sub

    Public Overrides Property webReq As WebRequest
        Get
            webReq = WebRequest.Create(myUri)

            webReq.Headers = MyBase.webHeaderColl
            webReq.ContentType = "application/json"
            webReq.Method = "POST"

        End Get
        Set(value As WebRequest)
            MyClass.webReq = value
        End Set
    End Property


    Public Overrides ReadOnly Property myUri As Uri
        Get
            myUri = New Uri(My.Settings.me_betting_uri)
        End Get
    End Property

    Public Overrides ReadOnly Property mySP As ServicePoint
        Get
            mySP = ServicePointManager.FindServicePoint(MyClass.myUri)
        End Get
    End Property




    Public Sub sendeAnfrage()

        Dim myNewLogWriter As New clsLogWriter

        Dim myHttpWebResponse As HttpWebResponse = CType(_webrequest.GetResponse(), HttpWebResponse)
        If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
            myNewLogWriter.write_log("Serverantwort OK")
        Else
            myNewLogWriter.write_log("Serverantwort NICHT OK")
        End If


        _requeststream = myHttpWebResponse.GetResponseStream()

        Dim reader As New System.IO.StreamReader(_requeststream)
        Dim responseFromServer As String = reader.ReadToEnd()



        reader.Close()
        _requeststream.Close()


        'Debug.Print(responseFromServer.ToString)
        myHttpWebResponse.Close()

        _serveranswer = responseFromServer

        Answerstring = _serveranswer


        'myNewLogWriter.write_log(_serveranswer)



    End Sub
End Class

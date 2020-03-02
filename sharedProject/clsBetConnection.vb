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

    Sub New()

        Dim f3j As String = "{@method@:@SportsAPING/v1.0/listMarketCatalogue@,@params@:{@filter@:{@eventTypeIds@:[],@marketCountries@:[],@marketTypeCodes@:[],@marketStartTime@:{@from@:null,@to@:null},@eventIds@:[]},@sort@:@FIRST_TO_START@,@maxResults@:@20@,@marketProjection@:[]},@jsonrpc@:@2.0@,@id@:1}".Replace("@", Chr(34))


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

        Requeststring = Anfrage

        Dim myNewLogWriter As New clsLogWriter
        myNewLogWriter.write_log(Requeststring)


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
            mySP.Expect100Continue = False
        End Get
    End Property

    ''' <summary>
    ''' Anfragestring als JSON
    ''' </summary>
    ''' <remarks>Eigenschaft um den Anfragestring aufzunehmen</remarks>
    ''' <value>""</value>
    Public Property Requeststring As String
        Get
            Return Nothing
        End Get
        Set(value As String)
        End Set
    End Property



    Public Function sendeAnfrage(ByVal sendRequest As String) As String





        Dim response As WebResponse = _webrequest.GetResponse()

        'Dim myHttpWebResponse As HttpWebResponse = CType(_webrequest.GetResponse(), HttpWebResponse)
        'If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
        '    ' txtConnectionState.Text = "online"
        'Else
        '    ' txtConnectionState.Text = "offline"
        'End If


        datastream = response.GetResponseStream()

        Dim reader As New StreamReader(datastream)
        Dim responseFromServer As String = reader.ReadToEnd()



        reader.Close()
        datastream.Close()


        'Debug.Print(responseFromServer.ToString)
        response.Close()







        datastream = response.GetResponseStream()

        Dim reader As New System.IO.StreamReader(datastream)
        Dim responseFromServer As String = reader.ReadToEnd()



        reader.Close()
        datastream.Close()


        Return ""

    End Function
End Class

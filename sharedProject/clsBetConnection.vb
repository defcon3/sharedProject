﻿Imports System.Net

Public Class clsBetConnection


    Inherits clsConnectionRoot

    Sub New()

        webReq = WebRequest.Create(myUri)


        mySP.Expect100Continue = False

        Dim f3j As String = "{@method@:@SportsAPING/v1.0/listMarketCatalogue@,@params@:{@filter@:{@eventTypeIds@:[],@marketCountries@:[],@marketTypeCodes@:[],@marketStartTime@:{@from@:null,@to@:null},@eventIds@:[]},@sort@:@FIRST_TO_START@,@maxResults@:@20@,@marketProjection@:[]},@jsonrpc@:@2.0@,@id@:1}".Replace("@", Chr(34))


        Dim byteArray As Byte() = System.Text.Encoding.Default.GetBytes(f3j)

        webReq.ContentLength = byteArray.Length


        Dim datastream As System.IO.Stream = webReq.GetRequestStream()
        datastream.Write(byteArray, 0, byteArray.Length)

        datastream.Close()


        Dim response As WebResponse = webReq.GetResponse()

        Dim myHttpWebResponse As HttpWebResponse = CType(webReq.GetResponse(), HttpWebResponse)
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


    Public Sub New(jsonstring As String)


        'myUri = New Uri("lkj ")


        'webReq = WebRequest.Create(MyBase.enumRequest.betting)
        ' myUri = New Uri(MyBase.get_request_type(MyBase.enumRequest.betting))

        webReq = WebRequest.Create(myUri)

        mySP.Expect100Continue = False


        'MyBase.New(0)

        'Dim myURI As New Uri(My.Settings.me_betting_uri)
        'Dim mySP As System.Net.ServicePoint = System.Net.ServicePointManager.FindServicePoint(myURI)
        'mySP.Expect100Continue = False
        'webReq = System.Net.WebRequest.Create(myURI)
        'webReq.Method = "POST"


        Dim byteArray As Byte() = System.Text.Encoding.Default.GetBytes(jsonstring)

        'MyBase.webReq.ContentLength = byteArray.Length
        'webReq.ContentLength = byteArray.Length



        Dim datastream As System.IO.Stream = webReq.GetRequestStream()
        datastream.Write(byteArray, 0, byteArray.Length)

        datastream.Close()


        Dim response As System.Net.WebResponse = webReq.GetResponse()



        '{"method":"SportsAPING/v1.0/listMarketCatalogue","params":{"filter":{"eventTypeIds":[],"marketCountries":[],"marketTypeCodes":[],"marketStartTime":{"from":null,"to":null},"eventIds":[]},"sort":"FIRST_TO_START","maxResults":"20","marketProjection":[]},"jsonrpc":"2.0","id":1}

        ''{@method@:@SportsAPING/v1.0/listMarketCatalogue@,@params@:{@filter@:{@eventTypeIds@:[],@marketCountries@:[],@marketTypeCodes@:[],@marketStartTime@:{@from@:null,@to@:null},@eventIds@:[]},@sort@:@FIRST_TO_START@,@maxResults@:@20@,@marketProjection@:[]},@jsonrpc@:@2.0@,@id@:1}




    End Sub

    Public Overrides Property webReq As WebRequest
        Get
            webReq = WebRequest.Create(myUri)
            webReq.Method = MyBase.webReq.Method
            webReq.Headers = MyBase.webHeaderColl
        End Get
        Set(value As WebRequest)
            'MyBase.webReq = WebRequest.Create(get_request_type(MyBase.enumRequest.betting))

            'Throw New NotImplementedException()
        End Set
    End Property


    Public Overrides ReadOnly Property myUri As Uri
        Get
            myUri = New Uri(My.Settings.me_betting_uri)
        End Get
    End Property

    Public Overrides ReadOnly Property mySP As ServicePoint
        Get
            mySP = ServicePointManager.FindServicePoint(myUri)
        End Get
    End Property
End Class

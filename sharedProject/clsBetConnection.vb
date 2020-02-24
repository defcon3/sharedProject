Imports System.Net

Public Class clsBetConnection


    Inherits clsConnectionRoot

    Public Sub New(jsonstring As String)

        'webReq = WebRequest.Create(MyBase.enumRequest.betting)
        myUri = New Uri(MyBase.get_request_type(MyBase.enumRequest.betting))

        webReq = WebRequest.Create(myUri)

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
            Throw New NotImplementedException()
        End Get
        Set(value As WebRequest)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Overrides Property myUri As Uri
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Uri)
            Throw New NotImplementedException()
        End Set
    End Property
End Class

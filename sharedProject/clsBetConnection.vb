Public Class clsBetConnection
    Inherits clsConnectionRoot
    Public Sub New(jsonstring As String)

        MyBase.New(1)

        Dim myURI As New Uri(My.Settings.me_betting_uri)
        Dim mySP As System.Net.ServicePoint = System.Net.ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False
        webReq = System.Net.WebRequest.Create(myURI)
        'webReq.Method = "POST"


        Dim byteArray As Byte() = System.Text.Encoding.Default.GetBytes(jsonstring)

        webReq.ContentLength = byteArray.Length



        Dim datastream As System.IO.Stream = webReq.GetRequestStream()
        datastream.Write(byteArray, 0, byteArray.Length)

        datastream.Close()




        '{"method":"SportsAPING/v1.0/listMarketCatalogue","params":{"filter":{"eventTypeIds":[],"marketCountries":[],"marketTypeCodes":[],"marketStartTime":{"from":null,"to":null},"eventIds":[]},"sort":"FIRST_TO_START","maxResults":"20","marketProjection":[]},"jsonrpc":"2.0","id":1}

        ''{@method@:@SportsAPING/v1.0/listMarketCatalogue@,@params@:{@filter@:{@eventTypeIds@:[],@marketCountries@:[],@marketTypeCodes@:[],@marketStartTime@:{@from@:null,@to@:null},@eventIds@:[]},@sort@:@FIRST_TO_START@,@maxResults@:@20@,@marketProjection@:[]},@jsonrpc@:@2.0@,@id@:1}




    End Sub

End Class

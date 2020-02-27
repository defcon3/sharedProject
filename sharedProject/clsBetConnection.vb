Imports System.Net

Public Class clsBetConnection


    Inherits clsConnectionRoot

    Sub New()




        Dim f3j As String = "{@method@:@SportsAPING/v1.0/listMarketCatalogue@,@params@:{@filter@:{@eventTypeIds@:[],@marketCountries@:[],@marketTypeCodes@:[],@marketStartTime@:{@from@:null,@to@:null},@eventIds@:[]},@sort@:@FIRST_TO_START@,@maxResults@:@20@,@marketProjection@:[]},@jsonrpc@:@2.0@,@id@:1}".Replace("@", Chr(34))


        Dim byteArray As Byte() = System.Text.Encoding.Default.GetBytes(f3j)

        Dim rer = MyClass.webReq
        rer.ContentLength = byteArray.Length



        MyClass.webReq.ContentLength = byteArray.Length


        Dim datastream As System.IO.Stream = rer.GetRequestStream()
        datastream.Write(byteArray, 0, byteArray.Length)

        datastream.Close()


        Dim response As WebResponse = rer.GetResponse()

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


    Public Overrides Property webReq As WebRequest
        Get
            webReq = WebRequest.Create(myUri)
            webReq.Headers = MyBase.webHeaderColl
            webReq.Method = "POST"
            webReq.ContentType = "application/json"
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
End Class

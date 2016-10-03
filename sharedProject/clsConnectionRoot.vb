Imports System.Net

Public MustInherit Class clsConnectionRoot

    Property webHeaderColl As New System.Net.WebHeaderCollection
    Property webReq As System.Net.WebRequest


    Sub New()

        webHeaderColl = New WebHeaderCollection

        webReq = System.Net.WebRequest.Create("http://www.dummyrequest.de")

        webHeaderColl.Add("X-Application", CStr(My.Settings.me_delayKey))
        webHeaderColl.Add("X-Authentication", CStr(My.Settings.me_cookie_ABE))
        webReq.Method = "POST"
        webReq.ContentType = "application/json"

    End Sub

End Class

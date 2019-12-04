Imports System.Net
''' <summary>
''' Abstrakte Klasse clsConnetionRoot, die nicht einzeln instanziierbar ist.
''' </summary>
Public MustInherit Class clsConnectionRoot
    ''' <summary>
    ''' WebHeaderCollection - Objekt
    ''' </summary>
    ''' <returns></returns>
    Property webHeaderColl As New System.Net.WebHeaderCollection
    Property webReq As System.Net.WebRequest

    ''' <summary>
    ''' Konstruktor der Klasse clsConnectionRooth
    ''' </summary>
    Sub New()

        webHeaderColl = New WebHeaderCollection

        webReq = System.Net.WebRequest.Create("http://www.dummyrequest.de")

        webHeaderColl.Add("X-Application", CStr(My.Settings.me_delayKey))
        webHeaderColl.Add("X-Authentication", CStr(My.Settings.me_cookie_ABE))
        webReq.Method = "POST"
        webReq.ContentType = "application/json"

    End Sub

End Class

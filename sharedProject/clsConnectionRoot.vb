Imports System.Net
''' <summary>
''' Abstrakte Klasse clsConnetionRoot, die nicht einzeln instanziierbar ist.
''' </summary>
Public MustInherit Class clsConnectionRoot


    Property webHeaderColl As New System.Net.WebHeaderCollection

    Public MustOverride ReadOnly Property myUri As System.Uri

    Public MustOverride Property webReq As System.Net.WebRequest

    Public Property mySP As ServicePoint



    Sub New()

    End Sub

    Public Sub New(enu As enumRequest)



        webHeaderColl = New WebHeaderCollection
        webHeaderColl.Add("X-Application", CStr(My.Settings.me_delayKey))
        webHeaderColl.Add("X-Authentication", CStr(My.Settings.me_cookie_ABE))

        webReq = System.Net.WebRequest.Create(get_request_type(enu))
        webReq.Method = "POST"
        webReq.ContentType = "application/json"

    End Sub




    ''' <summary>
    ''' Enumeration des Requestes
    ''' </summary>
    Public Enum enumRequest

        betting = 0
        heartbeat = 1
        keepalive = 2

    End Enum

    Public Function get_request_type(enu As enumRequest) As String

        Dim returnstring As System.String = ""

        Select Case enu
            Case = 0 ' betting
                returnstring = My.Settings.me_betting_uri
            Case = 1
                returnstring = My.Settings.me_heartbeat_uri
            Case = 2
                returnstring = My.Settings.me_keepAlive_uri
        End Select

        Return returnstring

    End Function


End Class

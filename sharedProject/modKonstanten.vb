Imports System.Net
Imports System.IO
Module modKonstanten

    Public ergebnis As String

    Public ReadOnly Property myExchangeAdress = "https://api.betfair.com/exchange/betting/json-rpc/v1"
    Public myExchangeURI As New Uri(myExchangeAdress)

    Public Sub getAbeCookie()

        Using reader As System.IO.StreamReader = New System.IO.StreamReader("C:\Temp\cookie_ABE.txt")
            ' Read one line from file
            'My.Settings.me_cookie_ABE = reader.ReadLine
        End Using


    End Sub



    Public Sub getDelayKey()

        'Using reader As System.IO.StreamReader = New System.IO.StreamReader("C:\Temp\delayKey.txt")
        '    ' Read one line from file
        '    My.Settings.me_delayKey = reader.ReadLine
        'End Using


    End Sub


    Public Function beat_heart() As String

        Dim myURI As New Uri(My.Settings.me_heartbeat_uri)
        Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myURI)
        mySP.Expect100Continue = False


        Dim request As WebRequest = WebRequest.Create(myURI)



        Return "Ö"


    End Function

    ''' <summary>
    ''' Enumeration des Requestes
    ''' </summary>
    Public Enum enumRequest

        keepAlive = 1


    End Enum

    Public Class itemList
        Property itemname As String
        Property itemformat As String
    End Class
    ''' <summary>
    ''' Enumeration für den normalen Key oder den Delay Key
    ''' </summary>
    Public Enum enumKey
        delay_key = 1
        normal_key = 2
    End Enum


    Public Enum enumlaender
        DE
        GB
        IT
        AT
        US
    End Enum


    Public Enum enumSportarten As System.Int64
        Soccer = 1
        Tennis = 2
        Golf = 3
        Cricket = 4
        Rugby_Union = 5
        Boxing = 6
        Horse_Racing = 7
        Motor_Sport = 8
        Soccer_Euro_2000 = 9
        Special_Bets = 10
        Cycling = 11
        Rowing = 12
        Rugby_League = 1477
        Darts = 3503
        Athletics = 3988
        Greyhound_Racing = 4339
        Financial_Bets = 6231
        Snooker = 6422
        American_Football = 6423
        Olympics___Sydney_2000 = 7228
        Baseball = 7511
        Basketball = 7522
        Hockey = 7523
        Ice_Hockey = 7524
        Sumo_Wrestling = 7525
        Australian_Rules = 61420
        Gaelic_Football = 66598
        Hurling = 66599
        Pool = 72382
        Test_Only = 104049
        Chess = 136332
        Winter_Olympics_2002 = 141540
        Poker_Room = 189929
        Trotting = 256284
        Commonwealth_Games = 300000
        Poker = 315220
        Winter_Sports = 451485
        Handball = 468328
        Netball = 606611
        Swimming = 620576
        Badminton = 627555
        International_Rules = 678378
        Bridge = 982477
        Yachting = 998916
        Volleyball = 998917
        Bowls = 998918
        Bandy = 998919
        Floorball = 998920
        Exchange_Poker = 1444073
        Exchange_Blackjack = 1444076
        Exchange_Baccarat = 1444085
        Exchange_Hi_Lo = 1444092
        Exchange_Omaha_Hi = 1444099
        Exchange_Card_Racing = 1444115
        Casino = 1444120
        Exchange_Roulette = 1444130
        Exchange_Bullseye_Roulette = 1444150
        Soccer___Euro_2004 = 1564529
        Olympics_2004 = 1896798
        Backgammon = 1938544
        GAA_Sports = 2030972
        Gaelic_Games = 2152880
        Internal_Markets = 2264869
        Politics = 2378961
        Table_Tennis = 2593174
        Yahoo_Racing = 2791893
        Beach_Volleyball = 2872194
        Canoeing = 2872196
        Water_Polo = 2901849
        Polo = 2977000
        Fishing = 3088925
        Roller_Hockey = 3130721
        Cross_Sport_Accumulators = 3145419
        Squash = 4609466
        Surfing = 4726642
        Combat_Sports = 4968929
        Exchange_Games = 5402258
        Pelota = 5412697
        Featured_Markets = 5545196
        Featured__Markets = 5545197
        Exchange_Casino = 10271443
        Ten_Pin_Bowling = 10390264
        Tradefair = 15242720
        Futsal = 15826206
        Fussball = 15826207
        Tradefair_Test = 16224213
        Harness_Racing = 16872235
        Olympics_2008 = 18051261
        Equestrian = 18643353
        Horse_Racing___Virtual = 26397698
        Mixed_Martial_Arts = 26420387
        Olympics_2012 = 26686903
        Paralympics_2012 = 26886906
        Triathlon = 27065662
        Winter_Olympics_2018 = 27105927
        tenniw = 27350698
        Current_Affairs = 27388198
        Virtual_Sports = 27438978
        E_Sports = 27454571
        Baku_2015 = 27456382
        Wrestling = 27485048
        Olympics_2016 = 27589895
        New_Customer_Offer = 27596832
        UFC = 27610222
        GAA_Football = 27610230
        GAA_Hurling = 27610231
        MMA___UFC = 27829360
        Kabbadi = 27979451
        Kabaddi = 27979456
        Gymnastics = 28347302
        TV_Specials = 28347303
        Music = 28347304
        Novelty_Bets = 28347305
        Lottery_Specials = 28361978
        Beach_Soccer = 28361979
        Hollywood = 28361980
        Weightlifting = 28361982
        Weather = 28361983
        Ski_Jumping = 28361984
        Nordic_Combined = 28361985
        Alpine_Skiing = 28361987
        Cross_Country = 28361988
        Biathlon = 28361989
        Freestyle_Skiing = 28361990
        Speed_Skating = 28361992
        Sports_Novelties = 28373540

    End Enum


End Module

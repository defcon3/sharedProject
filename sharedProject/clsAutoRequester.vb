Imports System.Data.SqlClient
Public Class clsAutoRequester

    Private _anfragestring As List(Of clsAnfragestring)
    Private _col As New Collection
    Private _startstopp As Boolean
    Private _intervall As Int16 = 1
    Private _i As Integer = 0
    Private _dread As System.Threading.Thread
    Private _tabellenname As String
    Private tabelle As DataTable
    Private str As String
    Private _runonce As Boolean

    Event undlos()

    Public WriteOnly Property StartStopp As enumstartstop
        Set(value As enumstartstop)
            _startstopp = value
            RaiseEvent undlos()
        End Set
    End Property

    Public Property Intervall As Integer
        Get
            Return _intervall
        End Get
        Set(value As Integer)
            _intervall = value
        End Set
    End Property

    Public Property runonce As Boolean
        Get
            Return _runonce
        End Get
        Set(value As Boolean)
            _runonce = value
        End Set
    End Property


    Public Enum enumstartstop
        start = True
        stopp = False
    End Enum

    Private Class clsAnfragestring
        Public Property Anfragestring As String
        Public Property Tabellenname As String
    End Class

    ''' <summary>
    ''' Hinzufügen vom Anfragestring und dem Tabellennamen
    ''' </summary>
    ''' <param name="Anfragestring"></param>
    ''' <param name="Tabellenname"></param>
    Public Sub add(ByVal Anfragestring As String, Tabellenname As String)
        Dim newClsAnfragesting As New clsAnfragestring
        newClsAnfragesting.Anfragestring = Anfragestring
        newClsAnfragesting.Tabellenname = Tabellenname
        _tabellenname = Tabellenname
        _col.Add(newClsAnfragesting, _i)
        _i += 1
        str = Anfragestring
    End Sub

    Private Sub _funcRequest() Handles Me.undlos


        If _startstopp = enumstartstop.start AndAlso _col.Count > 0 Then

            For Each a As clsAnfragestring In _col


                Do
                    _datenAbfragen()
                    _writeToDatabase(tabelle, _tabellenname)
                    Application.DoEvents()
                    Threading.Thread.Sleep(New TimeSpan(0, 0, 1))
                Loop While _runonce = False


            Next

        Else
            ''' thread stoppen



        End If
    End Sub

    ' es muss noch eine in den Server Schreibroutine implementiert werden.

    Private Sub _writeToDatabase(ByVal dt As System.Data.DataTable, ByVal tabellenname As String)

        'For Each col As DataColumn In dt.Columns
        '    Debug.Print(col.Ordinal.ToString & " - " & col.ColumnName & " - " & col.DataType.ToString)
        'Next


        If Not dt Is Nothing Then

            Using connection As New SqlConnection("Server=158.181.48.94; Database=dbdata; User=326773; Password=" & getSqlServerPasswort())

                Using SqlBulkCopy As New SqlBulkCopy(connection)

                    SqlBulkCopy.DestinationTableName = tabellenname

                    connection.Open()
                    Try
                        SqlBulkCopy.WriteToServer(dt)
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try

                    connection.Close()
                End Using

            End Using

        End If

    End Sub


    Private Sub _datenAbfragen()
        Dim betreq As New clsBetConnection(str)

        ''' sendet die Anfrage an den Server
        betreq.sendeAnfrage()

        'MsgBox(betreq.Answerstring)

        Dim dtvalue = New Object

        Select Case _tabellenname
            Case "tabMarketBook"


                dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketBookResponse)(betreq.Answerstring)

            Case "tabMarketCatalogue"

                dtvalue = Newtonsoft.Json.JsonConvert.DeserializeObject(Of bfObjects.clsMarketCatalogueResponse)(betreq.Answerstring)



        End Select

        Dim dt As New DataTable

        If dtvalue.result.count > 0 Then
            For Each ea In dtvalue.result
                dt.Merge(ea.gettable)
            Next
        End If

        tabelle = dt

    End Sub

End Class

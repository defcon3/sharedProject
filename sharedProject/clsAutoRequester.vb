Public Class clsAutoRequester

    Private _anfragestring As List(Of clsAnfragestring)
    Private _col As Collection
    Private _startstopp As Boolean
    Private _intervall As Int16 = 1
    Private _i As Integer = 0
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

    Public Enum enumstartstop
        start = True
        stopp = False
    End Enum

    Private Class clsAnfragestring
        Public Property Anfragestring As String
        Public Property Tabellenname As String
    End Class

    Public Sub add(ByVal Anfragestring As String, Tabellenname As String)
        Dim newClsAnfragesting As New clsAnfragestring
        newClsAnfragesting.Anfragestring = Anfragestring
        newClsAnfragesting.Tabellenname = Tabellenname
        _col.Add(newClsAnfragesting, _i)
        _i += 1
    End Sub

    Public Sub remove(ByVal Listennummer As Int16)
        _col.Remove(Listennummer)
    End Sub

    Private Sub _funcRequest() Handles Me.undlos
        If _startstopp = enumstartstop.start AndAlso _col.Count > 0 Then

            For Each a As clsAnfragestring In _col




            Next




        End If
    End Sub


End Class

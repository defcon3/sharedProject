Imports System.ComponentModel

Public Class frmConnection

    Public Event setIntervall(ByVal intervall As Integer)

    Public Sub New()


        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.



    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load




        Dim m As New List(Of String)

        For i As Integer = 1 To 20
            m.Add(CStr(i))
        Next
        Me.ComboBox1.DataSource = m

        Me.ComboBox1.Text = My.Settings.me_connection_user_intervall




    End Sub

    Private Sub frmConnection_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.me_connection_user_intervall = Me.ComboBox1.Text
        RaiseEvent setIntervall(Me.ComboBox1.Text)
        Me.Dispose()
    End Sub
End Class
Imports System.ComponentModel

Public Class frmConnection

    Public Event setIntervall(ByVal intervall As Integer)
    Public Event writeToLog(ByVal logtext As System.String)


    Public Sub New()


        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        'cboKey.Text = My.Settings.me_selected_key.ToString

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load




        Dim m As New List(Of String)

        For i As Integer = 1 To 20
            m.Add(CStr(i))
        Next
        Me.ComboBox1.DataSource = m

        Me.ComboBox1.Text = My.Settings.me_connection_user_intervall




        'Me.TextBox1.Text = My.Settings.me_selected_key.ToString
        Me.cboKey.Text = My.Settings.me_selected_key.ToString

        RaiseEvent writeToLog("tech-> " & Me.Name & " geöffnet.")


    End Sub

    Private Sub frmConnection_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.me_connection_user_intervall = Me.ComboBox1.Text
        RaiseEvent setIntervall(Me.ComboBox1.Text)
        Me.Dispose()
    End Sub

    Private Sub cboKey_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKey.SelectedIndexChanged
        Dim t = cboKey.Text.Substring(0, 5)

        If cboKey.Text.Substring(0, 5) = "me_de" Then
            Me.TextBox1.Text = My.Settings.me_delayKey
            My.Settings.me_keyValue = TextBox1.Text
            My.Settings.Save()
            RaiseEvent writeToLog("Systemwert me_keyValue (delay-Key) mit  """ & CStr(TextBox1.Text) & """ gespeichert.")
        Else
            Me.TextBox1.Text = My.Settings.me_normalKey
            My.Settings.me_keyValue = TextBox1.Text
            My.Settings.Save()
            RaiseEvent writeToLog("Systemwert me_keyValue (normal-Key) mit  """ & CStr(TextBox1.Text) & """ gespeichert.")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Try
            Me.Close()

        Catch ex As Exception

        Finally
            RaiseEvent writeToLog("tech-> " & Me.Name & " geschlossen.")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            MsgBox(My.Settings.me_keyValue)
        Catch ex As Exception

        End Try

    End Sub
End Class
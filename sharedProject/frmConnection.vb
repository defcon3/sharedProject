Imports System.ComponentModel

Public Class frmConnection

    Public Event setIntervall(ByVal intervall As Integer)

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



        'Dim values() As Integer = CType([Enum].GetValues(GetType(enumKey)), Integer())
        For Each s In [Enum].GetNames(GetType(enumKey))
            cboKey.Items.Add(s)
        Next

        'Me.TextBox1.Text = My.Settings.me_delayKey



    End Sub

    Private Sub frmConnection_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.me_connection_user_intervall = Me.ComboBox1.Text
        RaiseEvent setIntervall(Me.ComboBox1.Text)
        Me.Dispose()
    End Sub

    Private Sub cboKey_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboKey.SelectedValueChanged

        ' My.Settings.me_selected_key = cboKey.Text.ToString
        ' My.Settings.me_delayKey = Me.TextBox1.Text
        ' My.Settings.Save()

    End Sub

    Private Sub cboKey_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKey.SelectedIndexChanged
        Dim t = cboKey.Text.Substring(0, 5)
        If cboKey.Text.Substring(0, 5) = "delay" Then
            Me.TextBox1.Text = My.Settings.me_delayKey
        Else
            Me.TextBox1.Text = My.Settings.me_normalKey
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("delay: " & My.Settings.me_delayKey)
        MsgBox("normal: " & My.Settings.me_normalKey)
    End Sub
End Class
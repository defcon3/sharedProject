Public Class frmLog
    ''' <summary>
    ''' Event, welches die Nachricht abschießt.
    ''' </summary>
    ''' <param name="logtext"></param>
    Public Event writeToLog(ByVal logtext As System.String)

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.


    End Sub

    Private Sub frmLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtPath.Text = My.Settings.me_logpath

        'System.Text.Encoding

        RaiseEvent writeToLog("tech-> " & Me.Name & " geöffnet.")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.me_logpath = txtPath.Text
        My.Settings.Save()

        RaiseEvent writeToLog("Logpfad als """ & CStr(txtPath.Text) & """ gespeichert.")

    End Sub

    ''' <summary>
    ''' Schliessenknopf
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Try
            Me.Close()

        Catch ex As Exception

        Finally
            RaiseEvent writeToLog("tech-> " & Me.Name & " geschlossen.")
        End Try





    End Sub
End Class
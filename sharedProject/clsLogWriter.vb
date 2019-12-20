Imports System.IO
Imports System.Text

''' <summary>
''' Klassse zum Schreiben 
''' </summary>
Public Class clsLogWriter
    ''' <summary>
    ''' Subroutine zum Schreiben einer Nachricht ins LOG
    ''' </summary>
    ''' <param name="nachricht"></param>
    Public Sub write_log(ByVal nachricht As String)

        Dim sb As New System.Text.StringBuilder

        sb.Append(CStr(Date.UtcNow.Ticks) & " - " & CStr(Date.UtcNow) & " # " & nachricht)
        'Dim writer As New System.IO.TextWriter()
        Dim writeFile As System.IO.TextWriter = New _
            StreamWriter(My.Settings.me_logpath & "\" & CStr(DateTime.Now.ToString("yyyy-MM-dd")) & "_Log_ABE.txt", True, encoding:=Encoding.UTF8)
        Try
            writeFile.WriteLine(sb.ToString)
        Catch ex As Exception
            writeFile.WriteLine(ex.Message.ToString)
        Finally
            writeFile.Flush()
            writeFile.Close()
            writeFile = Nothing

        End Try




    End Sub


End Class

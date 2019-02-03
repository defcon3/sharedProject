Imports System.IO
Imports System.Text

Public Class clsLogWriter


    Public Sub write_log(ByVal nachricht As String)

        Dim sb As New System.Text.StringBuilder
        sb.Append(CStr(Date.UtcNow.Ticks) & " - " & CStr(Date.UtcNow) & " # " & nachricht)
        'Dim writer As New System.IO.TextWriter()
        Dim writeFile As System.IO.TextWriter = New _
            StreamWriter("c:\temp\" & CStr(DateTime.Now.ToString("yyyy-MM-dd")) & "_Log_ABE.txt", True, encoding:=Encoding.UTF8)
        writeFile.WriteLine(sb.ToString)
        My.Settings.me_cookie_ABE = sb.ToString
        writeFile.Flush()
        writeFile.Close()
        writeFile = Nothing

    End Sub


End Class

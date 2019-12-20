Public Interface ILogWriter
    ''' <summary>
    ''' Öffentliches Event zum Schreiben ins Log
    ''' </summary>
    ''' <param name="logtext"></param>
    Event writeToLog(ByVal logtext As System.String)
End Interface

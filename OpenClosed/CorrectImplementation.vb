
Imports System.Runtime.Serialization

Public Class GreeterDeclarative
        public sub New(messageService As MessageService)
            messageService.SendMessage("Greetings")
        End sub
    End Class
    
    Public Class AcknowledgerDeclarative
        public sub New(messageService As MessageService)
            messageService.SendMessage("OK")
        End sub
    End Class
    
    Public Class StreamerDeclarative
        public sub New(messageService As MessageService)
            messageService.SendStream("Streaming")
        End sub
    End Class
    
    Public Class MessageService
        private ReadOnly _connection As Connection
    
        Public sub new(connectionFactory As ConnectionFactory)
            _connection = connectionFactory.GetConnection()
        End sub
    
        Public Sub SendMessage(msg As String)
            _connection.Write(msg)
        End Sub
    
        Public Sub SendStream(msg As String)
            While true
                SendMessage(msg)
            End While
        End Sub
    End Class
    
    Public Class ConnectionFactory
        Private _dbProvider As String
    
        Public Sub New(configurationProvider As ConfigurationProvider)
            _dbProvider = configurationProvider.GetDatabaseConfiguration()
        End Sub
    
        Public Function GetConnection() As Connection
            If _dbProvider.Equals("Postgres") Then
                Return New Connection("Postgres")
            Else ' Default to Pervasive
                Return New Connection("Pervasive")
            End If
        End Function
    End Class
    
    Public Class ConfigurationProvider
        Public Function GetDatabaseConfiguration() as String
            return Environment.GetEnvironmentVariable("DB")
        End Function
    End Class


    Public Class FluxCapacitorQueueWriter
        Private ReadOnly _formatter As IFormatter
    
        public sub New (formatter As IFormatter)
            _formatter = formatter
        End sub
    
        public sub Write(msg As String)
            Dim formattedMsg = _formatter.Format(msg)
    
            ' write the formatted message to the queue
        End sub
    End Class
    
    Public Class FluxCapacitorFormatFormatter
        Implements IFormatter
    
        Public Function Format(info As String) As String Implements IFormatter.Format
            Return info.Replace("r", "2")
        End Function
    End Class

    Public Class FluxCapacitorFormatV2Formatter
        Implements IFormatter
    
        Public Function Format(info As String) As String Implements IFormatter.Format
            Return info.Replace("a", "b")
        End Function
    End Class
    
    Public Interface IFormatter
        Function Format(msg As String) As String
    End Interface

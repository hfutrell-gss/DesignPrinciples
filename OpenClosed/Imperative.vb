    Public Class GreeterImperative
        Public Sub New()
            Dim dbProvider = Environment.GetEnvironmentVariable("DB")
            If dbProvider.Equals("Postgres") Then
                Dim connection = New Connection("Postgres")
                connection.Write("Greetings")
            Else ' Make Pervasive the default
                Dim connection = New Connection("Pervasive")
                connection.Write("Greetings")
            End If
        End Sub
    End Class
    
    Public Class AcknowledgerImperative
        Public Sub New()
            Dim dbProvider = Environment.GetEnvironmentVariable("DB")
            If dbProvider.Equals("Postgres") Then
                Dim connection = New Connection("Postgres")
                connection.Write("OK")
            Else ' Default to Pervasive
                Dim connection = New Connection("Pervasive")
                connection.Write("OK")
            End If
        End Sub
    End Class
    
    Public Class StreamerImperative
        Public Sub New()
            Dim dbProvider = System.Environment.GetEnvironmentVariable("DB")
    
            If dbProvider.Equals("Postgres") Then
                Dim connection = New Connection("Postgres")
                While True
                    connection.Write("Streaming")
                End While
            Else
                Dim connection = New Connection("Pervasive")
                While True
                    connection.Write("Streaming")
                End While
            End If
        End Sub
    End Class
    
    
    

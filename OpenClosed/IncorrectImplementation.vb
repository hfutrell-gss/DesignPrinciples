Public Enum DatabaseType
    Pervasive
    Postgres
End Enum

Public Class Connection
    public sub new (p As String)

    End sub

    public sub Write(msg As String)
        ' sends message
    End sub
End Class

Public Class IncorrectImplementation
    Public Function Connect(dbType As DatabaseType) As Connection
        Select Case dbType
            Case DatabaseType.Pervasive
                MakeConnection(0, "Pervasive")
            Case DatabaseType.Postgres
                MakeConnection(1, "Postgres")
                New AcknowledgerDeclarative(new MessageService())
                New AcknowledgerImperative()
                New GreeterDeclarative()
                New GreeterImperative()
                New StreamerDeclarative
                New StreamerImperative
        End Select

        If dbType = DatabaseType.Pervasive Then
            Return New PervasiveConnection()
        ElseIf dbType = DatabaseType.Postgres Then
            return new PostgresConnection()
        Else
            Throw New Exception("Not Pervasive nor Postgres")
        End If
    End Function

    Private Sub MakeConnection(p1 As Integer, p2 As String)
        ' some implementation
    End Sub
End Class

Public Class Client
    public sub DoThing()
        Dim provider = Environment.GetEnvironmentVariable("DBTYPE")
        Dim implementation = new IncorrectImplementation

        If provider Is Nothing Then
            Throw New Exception("Not downstream of menu")
        ElseIf provider.Equals("Pervasive") Then
            implementation.Connect(DatabaseType.Pervasive)
        ElseIf provider.Equals("Postgres") Then
            implementation.Connect(DatabaseType.Postgres)
        Else
            implementation.Connect(DatabaseType.Pervasive)
        End If
    End sub
End Class

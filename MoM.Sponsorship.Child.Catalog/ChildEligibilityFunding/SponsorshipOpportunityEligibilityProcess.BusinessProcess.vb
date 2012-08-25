Imports System.Text
Imports Blackbaud.AppFx.Server
Imports System.Data.SqlClient


Public NotInheritable Class SponsorshipOpportunityEligibilityProcessBusinessProcess
    Inherits AppCatalog.AppBusinessProcess

    Private _parameters As SponsorshipOpportunityEligibilityProcessParameters = Nothing

    Private ReadOnly Property Parameters As SponsorshipOpportunityEligibilityProcessParameters
        Get
            If _parameters Is Nothing Then
                Throw New Exception("No parameters were set")
            End If

            Return _parameters
        End Get
    End Property



    ' This is a class used for the inventory process instance parameters.
    Private Class SponsorshipOpportunityEligibilityProcessParameters
        Public ReadOnly OUTPUTVIEWID As Guid = Guid.Empty
        Public ReadOnly IDSETID As Guid = Guid.Empty


        Public Sub New(ByVal parameterSetID As Guid, ByRef requestContext As RequestContext)
            Using con As SqlConnection = New SqlConnection(requestContext.AppDBConnectionString)
                Using command As SqlCommand = con.CreateCommand()
                    Try
                        command.CommandText = "USR_USP_SPONSORSHIPOPPORTUNITYELIGIBILITYPROCESS_GETPARAMETERS"
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@ID", parameterSetID)
                        con.Open()
                        Using reader As SqlDataReader = command.ExecuteReader()
                            reader.Read()
                            Me.IDSETID = reader.GetGuid(reader.GetOrdinal("IDSETREGISTERID"))
                            '    Me.OUTPUTVIEWID = reader.GetGuid(reader.GetOrdinal("OUTPUTVIEWID"))
                            reader.Close()
                        End Using
                        con.Close()
                    Catch
                        Throw New Exception("Unable to get parameter set found for the given Id")
                    End Try
                End Using
            End Using
        End Sub
    End Class

    ' Validate gets called first and if all goes well, it gets our parameters too.
    Public Overrides Sub Validate()
        MyBase.Validate()

        ' Get our business process parameters
        _parameters = New SponsorshipOpportunityEligibilityProcessParameters(RequestArgs.ParameterSetID, Me.RequestContext)

        If _parameters Is Nothing Then
            Throw New Exception("No parameters found with the given parameter")
        End If
    End Sub


    Public Overrides Function StartBusinessProcess() As Blackbaud.AppFx.Server.AppCatalog.AppBusinessProcessResult
        Dim ProcessResults As New Blackbaud.AppFx.Server.AppCatalog.AppBusinessProcessResult
        Dim SelectionCount As Integer = 0
        Dim Transaction As Data.SqlClient.SqlTransaction = Nothing

        Me.UpdateProcessStatus("Inserting records into output table...")
        ' Execute the command to populate the table



        Using Connection As SqlConnection = New SqlConnection(Me.RequestContext.AppDBConnectionString)
            Connection.Open()
            Using Command As SqlCommand = Connection.CreateCommand()
                With Command
                    Try
                        Transaction = Connection.BeginTransaction
                        .Transaction = Transaction

                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "dbo.USR_USP_GETIDSETCOUNT"
                        .CommandTimeout = Me.ProcessCommandTimeout
                        .Parameters.AddWithValue("IDSetRegisterID", Parameters.IDSETID.ToString())
                        .Parameters.AddWithValue("SelectionCount", 0)
                        .Parameters("SelectionCount").Direction = ParameterDirection.Output
                        .ExecuteNonQuery()
                        If IsDBNull(.Parameters("SelectionCount").Value) Then
                            SelectionCount = 0
                        Else
                            SelectionCount = CInt(.Parameters("SelectionCount").Value)
                        End If


                        .Parameters.Clear()
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "dbo.USR_USP_SPONSORSHIPOPPORTUNITYELIGIBILITYPROCESS_ELIGIBILITYCHECK"
                        .CommandTimeout = Me.ProcessCommandTimeout
                        .Parameters.AddWithValue("IDSETREGISTERID", Parameters.IDSETID.ToString())
                        .Parameters.AddWithValue("CHANGEAGENTID", DBNull.Value)
                        .Parameters.AddWithValue("DELETEDROWS", 0)
                        .Parameters("DELETEDROWS").Direction = ParameterDirection.Output
                        .Parameters.AddWithValue("INSERTEDROWS", 0)
                        .Parameters("INSERTEDROWS").Direction = ParameterDirection.Output
                        .ExecuteNonQuery()

                        ''t.NumberSuccessfullyProcessed = CInt(.Parameters("InsertedRows").Value)
                        .Parameters.Clear()
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "dbo.USR_USP_SPONSORSHIPOPPORTUNITYELIGIBILITYPROCESS_SETELIGIBILITY"
                        .CommandTimeout = Me.ProcessCommandTimeout
                        .Parameters.AddWithValue("IDSETREGISTERID", Parameters.IDSETID.ToString())
                        .Parameters.AddWithValue("CHANGEAGENTID", DBNull.Value)
                        .Parameters.AddWithValue("CHANGEDTOELIGIBLE", 0)
                        .Parameters("CHANGEDTOELIGIBLE").Direction = ParameterDirection.Output
                        .Parameters.AddWithValue("CHANGEDTOPENDING", 0)
                        .Parameters("CHANGEDTOPENDING").Direction = ParameterDirection.Output
                        .ExecuteNonQuery()

                        Transaction.Commit()

                        ProcessResults.NumberSuccessfullyProcessed = SelectionCount
                        ProcessResults.NumberOfExceptions = 0

                    Catch ex As Exception
                        Transaction.Rollback()

                        Throw ex
                    End Try


                End With

            End Using
        End Using



        Return ProcessResults
    End Function

    'optional overrides
    'Public Overrides Sub CheckForSimultaneousRuns()
    '    MyBase.CheckForSimultaneousRuns()
    'End Sub

    'Public Overrides Function GetAppLockNameForParameterSet() As String
    '    Return MyBase.GetAppLockNameForParameterSet()
    'End Function

End Class

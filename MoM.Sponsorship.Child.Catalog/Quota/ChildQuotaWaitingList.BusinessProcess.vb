Imports System.Text
Imports Blackbaud.AppFx.Server
Imports System.Data.SqlClient

''' <summary>
''' This business process checks all waiting list children and registers those that can be added.
''' </summary>
''' <remarks>This business process was created so that the waiting list process could be scheduled.  It does not allow the user to specify and parameters / selections.
'''				It assumes that the ID for the default parameter set is '2A580C34-C5DD-415D-BB60-0AC3E30BEB78'.  The is created in the "Populate MoM System Tables.sql"
'''
'''				This also includes the children added through batch who's project/country could not be locked.
''' </remarks>
''' <history>
''' Date			Modified By		Comments
''' 03-Jul-2012		CMayeda			Initial Version
''' </history>
Public NotInheritable Class ChildQuotaWaitingListBusinessProcess
    Inherits AppCatalog.AppBusinessProcess

    Private Const outputTablePrefix As String = "USR_CHILDQUOTA_WAITINGLISTPROCESS"
    Private Const exceptionTablePrefix As String = "_EXCEPTION"

    ' Validate isn't needed because a parameter set is not used.

    ' Validate gets called first and if all goes well, it gets our parameters too.
    ' Public Overrides Sub Validate()
    '    MyBase.Validate()

    '    ' Get our business process parameters
    '    _parameters = New InventoryParameters(RequestArgs.ParameterSetID, Me.RequestContext)

    '    If _parameters Is Nothing Then
    '        Throw New Exception("No parameters found with the given parameter")
    '    End If
    ' End Sub


    ''' <summary>
    ''' This is the main business process method, used to run the sproc USR_USP_CHILD_QUOTA_PROCESSWAITINGLIST
    ''' </summary>
    ''' <returns>AppBusinessProcessResult</returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' Date			Modified By		Comments
    ''' 03-Jul-2012		CMayeda			Initial Version
    ''' </history>
    Public Overrides Function StartBusinessProcess() As Blackbaud.AppFx.Server.AppCatalog.AppBusinessProcessResult
        Dim ProcessResults As New Blackbaud.AppFx.Server.AppCatalog.AppBusinessProcessResult

        Dim Transaction As Data.SqlClient.SqlTransaction = Nothing

        Me.UpdateProcessStatus("Processing Waiting List children...")
        ' Execute the command to populate the table

        Dim outputTableName As String = CreateOutputTable(outputTablePrefix, "Success", OutputTableColumns().ToArray())
        Dim exceptionTableName As String = CreateOutputTable(String.Concat(outputTablePrefix, exceptionTablePrefix), "Exception", ExceptionTableColumns().ToArray())

        Dim successParam As SqlParameter
        Dim exceptionParam As SqlParameter


        Using Connection As SqlConnection = New SqlConnection(Me.RequestContext.AppDBConnectionString)
            Connection.Open()
            Using Command As SqlCommand = Connection.CreateCommand()
                With Command
                    Try
                        Transaction = Connection.BeginTransaction
                        .Transaction = Transaction

                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "dbo.USR_USP_CHILDQUOTA_PROCESSWAITINGLIST"
                        .CommandTimeout = Me.ProcessCommandTimeout
                        .Parameters.AddWithValue("changeAgentID", DBNull.Value)             ' The sproc will get the Change Agent ID if we pass in null
                        .Parameters.AddWithValue("successTableName", outputTableName)       ' The table to insert the kids registered
                        .Parameters.AddWithValue("exceptionTableName", exceptionTableName)  ' The table to insert exceptions and kids put on the waiting list

                        successParam = New SqlParameter("successCount", SqlDbType.Int)      ' The number of kids registered
                        successParam.Direction = ParameterDirection.Output
                        .Parameters.Add(successParam)

                        exceptionParam = New SqlParameter("exceptionCount", SqlDbType.Int)  ' The number of exceptions and kids put on the waiting list
                        exceptionParam.Direction = ParameterDirection.Output
                        .Parameters.Add(exceptionParam)

                        .ExecuteNonQuery()

                        Transaction.Commit()

                        If successParam.Value IsNot Nothing AndAlso IsNumeric(successParam.Value) Then
                            ProcessResults.NumberSuccessfullyProcessed = CInt(successParam.Value)
                        Else
                            ProcessResults.NumberSuccessfullyProcessed = 7777777    ' We didn't get a value.  Unfortunately, I can't set this to -1, so I picked a value that we shouldn't ever have.
                        End If

                        If exceptionParam.Value IsNot Nothing AndAlso IsNumeric(exceptionParam.Value) Then
                            ProcessResults.NumberOfExceptions = CInt(exceptionParam.Value)
                        Else
                            ProcessResults.NumberOfExceptions = 7777777             ' We didn't get a value.  Unfortunately, I can't set this to -1, so I picked a value that we shouldn't ever have.
                        End If

                    Catch ex As Exception
                        Transaction.Rollback()

                        Throw ex
                    End Try


                End With

            End Using
        End Using

        Return ProcessResults
    End Function

    Private Function OutputTableColumns() As List(Of AppCatalog.TableColumn)

        Dim columns As New List(Of AppCatalog.TableColumn)
        columns.Add(New AppCatalog.TableColumn("CHILDPROJECTID", SqlDbType.UniqueIdentifier))
        columns.Add(New AppCatalog.TableColumn("COUNTRYID", SqlDbType.UniqueIdentifier))
        columns.Add(New AppCatalog.TableColumn("SPONSORSHIPOPPORTUNITYCHILDID", SqlDbType.UniqueIdentifier))
        Return columns

    End Function

    Private Function ExceptionTableColumns() As List(Of AppCatalog.TableColumn)

        Dim columns As New List(Of AppCatalog.TableColumn)
        columns.Add(New AppCatalog.TableColumn("CHILDPROJECTID", SqlDbType.UniqueIdentifier))
        columns.Add(New AppCatalog.TableColumn("COUNTRYID", SqlDbType.UniqueIdentifier))
        columns.Add(New AppCatalog.TableColumn("SPONSORSHIPOPPORTUNITYCHILDID", SqlDbType.UniqueIdentifier))
        columns.Add(New AppCatalog.TableColumn("ERRORMESSAGE", SqlDbType.NVarChar, 255))
        Return columns

    End Function

    'optional overrides
    'Public Overrides Sub CheckForSimultaneousRuns()
    '    MyBase.CheckForSimultaneousRuns()
    'End Sub

    'Public Overrides Function GetAppLockNameForParameterSet() As String
    '    Return MyBase.GetAppLockNameForParameterSet()
    'End Function

End Class

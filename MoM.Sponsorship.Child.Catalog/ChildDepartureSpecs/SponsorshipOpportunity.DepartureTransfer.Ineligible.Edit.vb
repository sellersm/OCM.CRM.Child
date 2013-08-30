Imports Blackbaud.AppFx.Server

' This was copied from the OOB - SponsorshipOpportunityIneligibleEditDataForm
' The only change is the additional call to USR_USP_SPONSORSHIPOPPORTUNITY_DEPARTURETRANSFER to add the proper interactions

Public NotInheritable Class SponsorshipOpportunityDepartureTransferIneligibleEditDataForm
	Inherits AppCatalog.AppEditDataForm
	Public oldSponsorshipOpportunityID As Guid
	Public newSponsorshipOpportunityID As Guid
	Public sponsorshipReasonId As Guid
	Public childSponsorships As Integer
	Public groupID As Guid
	Public createOutputIdSet As Boolean
	Public outputIdSetTypeCode As Integer
	Public outputIdSetName As String
	Public overwriteOutputIdSet As Boolean
	Public isSoleSponsorship As Boolean
	Public eligibilityCode As Integer
	Public typeCode As Integer
	Public dataLoaded As Boolean

	Public Overrides Function Load() As Blackbaud.AppFx.Server.AppCatalog.AppEditDataFormLoadResult
		Dim request As New DataFormLoadRequest
		request.RecordID = Me.ProcessContext.RecordID
		request.FormID = New Guid("92f92683-0c5d-4ce0-9357-1aca0a0d3ad0")
		'This is required to prevent an error on save that the timeout is too big.
		Me.RequestContext.ClientAppInfo.TimeOutSeconds = 180

		Dim reply As DataFormLoadReply
		reply = DataFormLoad(request, Me.RequestContext)

		reply.DataFormItem.TryGetValue("ACTIVESPONSORSHIPS", Me.childSponsorships)
		reply.DataFormItem.TryGetValue("SPONSORSHIPOPPORTUNITYGROUPID", Me.groupID)
		reply.DataFormItem.TryGetValue("ISSOLESPONSORSHIP", Me.isSoleSponsorship)
		reply.DataFormItem.TryGetValue("ELIGIBILITYCODE", Me.eligibilityCode)
		reply.DataFormItem.TryGetValue("SPONSORSHIPREASONID", Me.sponsorshipReasonId)

		'Using conn As SqlClient.SqlConnection = Me.RequestContext.OpenAppDBConnection(RequestContext.ConnectionContext.BusinessProcess)
		'    Dim cmd As SqlClient.SqlCommand = conn.CreateCommand()
		'    cmd.CommandText = "dbo.USP_SPONSORSHIPOPPORTUNITYINELIGIBLE_EDITLOAD"
		'    cmd.CommandType = CommandType.StoredProcedure
		'    cmd.Parameters.AddWithValue("ID", New Guid(Me.ProcessContext.RecordID))
		'    cmd.ex()

		'    'cmd.CommandText = "select dbo.UFN_SPONSORSHIPOPPORTUNITY_ACTIVESPONSORSHIPS(@ID)"
		'    'cmd.Parameters.AddWithValue("@ID", New Guid(Me.ProcessContext.RecordID))
		'    Me.childSponsorships = (CType(cmd.ExecuteScalar, Integer))

		'    'cmd.CommandText = "select sponsorshipopportunitygroupid from dbo.SPONSORSHIPOPPORTUNITY where ID=@IDD"
		'    'cmd.Parameters.AddWithValue("@IDD", New Guid(Me.ProcessContext.RecordID))
		'    Me.groupID = (CType(cmd.ExecuteScalar, Guid))
		'End Using
		oldSponsorshipOpportunityID = New Guid(Me.ProcessContext.RecordID)
		Return New Blackbaud.AppFx.Server.AppCatalog.AppEditDataFormLoadResult(True)
	End Function

	Public Overrides Function Save() As Blackbaud.AppFx.Server.AppCatalog.AppEditDataFormSaveResult
		Using conn As SqlClient.SqlConnection = Me.RequestContext.OpenAppDBConnection(RequestContext.ConnectionContext.BusinessProcess)
			Dim cmd As SqlClient.SqlCommand = conn.CreateCommand()
			Try
				cmd.CommandText = "select count(*) from dbo.SPONSORSHIPOPPORTUNITYTRANSFERPROCESS where ID = @OLDID"
				cmd.Parameters.AddWithValue("@OLDID", oldSponsorshipOpportunityID)

				If CType(cmd.ExecuteScalar, Integer) = 0 Then
					cmd.CommandText = "insert into dbo.SPONSORSHIPOPPORTUNITYTRANSFERPROCESS(ID, NAME, ADDEDBYID, CHANGEDBYID, DATEADDED, DATECHANGED, NEWSPONSORSHIPOPPORTUNITYID, SPONSORSHIPREASONID, CREATEOUTPUTIDSET, OUTPUTIDSETTYPECODE, OUTPUTIDSETNAME, OVERWRITEOUTPUTIDSET) "
					cmd.CommandText = cmd.CommandText & " values(@ID, dbo.UFN_SPONSORSHIPOPPORTUNITY_TRANSLATIONFUNCTION(@NAME), @CHANGEAGENTID, @CHANGEAGENTID, getdate(), getdate(),  @NEWSPONSORSHIPOPPORTUNITYID, @REASONID, @CREATEOUTPUTIDSET, @OUTPUTIDSETTYPECODE, @OUTPUTIDSETNAME, @OVERWRITEOUTPUTIDSET)"
				Else
					cmd.CommandText = "update dbo.SPONSORSHIPOPPORTUNITYTRANSFERPROCESS set CHANGEDBYID=@CHANGEAGENTID, DATECHANGED=getdate(), NEWSPONSORSHIPOPPORTUNITYID=@NEWSPONSORSHIPOPPORTUNITYID, SPONSORSHIPREASONID=@REASONID, CREATEOUTPUTIDSET=@CREATEOUTPUTIDSET, OUTPUTIDSETTYPECODE=@OUTPUTIDSETTYPECODE, OUTPUTIDSETNAME=@OUTPUTIDSETNAME, OVERWRITEOUTPUTIDSET=@OVERWRITEOUTPUTIDSET where ID=@ID"
				End If
				cmd.Parameters.AddWithValue("@ID", oldSponsorshipOpportunityID)
				cmd.Parameters.AddWithValue("@CHANGEAGENTID", Me.ProcessContext.ChangeAgentID)
				cmd.Parameters.AddWithValue("@NEWSPONSORSHIPOPPORTUNITYID", IIf(newSponsorshipOpportunityID.Equals(Guid.Empty), DBNull.Value, newSponsorshipOpportunityID))
				cmd.Parameters.AddWithValue("@REASONID", sponsorshipReasonId)
				cmd.Parameters.AddWithValue("@NAME", oldSponsorshipOpportunityID.ToString)

				cmd.Parameters.AddWithValue("@CREATEOUTPUTIDSET", createOutputIdSet)
				cmd.Parameters.AddWithValue("@OUTPUTIDSETTYPECODE", outputIdSetTypeCode)
				cmd.Parameters.AddWithValue("@OUTPUTIDSETNAME", outputIdSetName)
				cmd.Parameters.AddWithValue("@OVERWRITEOUTPUTIDSET", overwriteOutputIdSet)
				cmd.ExecuteNonQuery()

				' Beginning of added code - OCM
				cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = "dbo.USR_USP_SPONSORSHIPOPPORTUNITY_DEPARTURETRANSFER"
				cmd.Parameters.Clear()
				cmd.Parameters.AddWithValue("sponsorshipOpportunityChildID", Me.oldSponsorshipOpportunityID)
				cmd.Parameters.AddWithValue("changeAgentID", Me.ProcessContext.ChangeAgentID)
				cmd.ExecuteNonQuery()
				' End of added code - OCM

			Catch ex As Exception
				If ex.Message.IndexOf("CK_OPPORTUNITYTRANSFERPROCESS_VALIDIDSETNAME") > -1 Then
					Throw MyBase.CreateDataFormException("Please specify a valid Selection name", "OUTPUTIDSETNAME")
				ElseIf ex.Message.IndexOf("CK_OPPORTUNITYTRANSFERPROCESS_IDSETCANBECREATED") > -1 Then
					Throw MyBase.CreateDataFormException("A Selection with the same name already exists and is associated with a query and cannot be overwritten.  Please select a different Selection name.", "OUTPUTIDSETNAME")
				ElseIf ex.Message.IndexOf("CK_OPPORTUNITYTRANSFERPROCESS_IDSETEXISTS") > -1 Then
					Throw MyBase.CreateDataFormException("A Selection with the same name already exists.  Please select a different name or select to overwrite the existing Selection.", "OUTPUTIDSETNAME")
				Else
					Throw ex
				End If
			End Try
		End Using

		Return New Blackbaud.AppFx.Server.AppCatalog.AppEditDataFormSaveResult
	End Function

End Class

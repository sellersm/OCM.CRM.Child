Imports Blackbaud.AppFx.Server
Imports System.Globalization
Imports Blackbaud.AppFx.UIModeling.Core
Imports Blackbaud.AppFx
Imports Blackbaud.AppFx.Sponsorship.UIModel
Imports System.Web

' This was copied from the OOB - SponsorshipOpportunityPreprocessIneligibleHelper, because it's a Friend class.
' The only changes that were made was replacing the Resouces strings with hard coded values.

Friend Class SponsorshipOpportunityPreprocessIneligibleHelperDepartureTransfer
	Private Const REASONINFO As String = "10c9e6e4-3520-4f95-85d8-d249d3d71661"
	Private ReadOnly INFO1 As String = "This opportunity has" 'My.Resources.Content.Common_OppInfo1
	Private ReadOnly INFO2 As String = "sponsor(s)." 'My.Resources.Content.Common_oppInfo2
	Private ReadOnly MSGNOTRANS As String = "No transfers will occur." 'My.Resources.Content.Common_NoTransMsg
	Private ReadOnly MSGTRANS As String = "Transfer them to a:"	'My.Resources.Content.Common_TransMsg
	Private ReadOnly PROMPTCHILD As String = "Please specify a child or choose the 'Matching child' option"	'My.Resources.Content.Common_MatchChildPrompt
	Private ReadOnly PROMPTPROJECT As String = "Please specify a project or choose the 'Matching project' option" 'My.Resources.Content.Common_MatchProjectPrompt
	Private _cultureInfo As System.Globalization.CultureInfo
	Private WithEvents _parentModel As UIModeling.Core.DataFormUIModel
	Private WithEvents _choosingchild As UIField
	Private WithEvents _NewOpportunity As SearchListField
	Private _transfermsg As UIField
	Private _childsponsorships As Integer
	Private WithEvents _reasonid As SimpleDataListField
	Private _typecode As Integer
	Private WithEvents _createoutputidset As BooleanField
	Friend _reasontext As String
	Private sc As Blackbaud.AppFx.Server.RequestSecurityContext
	Private lockHelperFrom As SponsorshipOpportunityLockHelperUIModel
	Private lockHelperTo As SponsorshipOpportunityLockHelperUIModel
	Public ReadOnly Property getInvalidReason() As String
		Get
			Return _reasontext
		End Get
	End Property
	Friend Sub New(ByVal parentModel As UIModeling.Core.DataFormUIModel, ByVal typecode As Integer)

		_typecode = typecode
		_parentModel = parentModel
		_choosingchild = DirectCast(_parentModel.Fields("CHOOSINGCHILD"), UIField)
		_NewOpportunity = DirectCast(_parentModel.Fields("NEWSPONSORSHIPOPPORTUNITYID"), SearchListField)
		_transfermsg = _parentModel.Fields("TRANSFERMSG")
		_childsponsorships = DirectCast(_parentModel.Fields("CHILDSPONSORSHIPS").ValueObject, Integer)
		_reasonid = DirectCast(_parentModel.Fields("SPONSORSHIPREASONID"), SimpleDataListField)
		_createoutputidset = DirectCast(_parentModel.Fields("CREATEOUTPUTIDSET"), BooleanField)
		_choosingchild.Enabled = False
		_parentModel.Fields("NEWSPONSORSHIPOPPORTUNITYID").Enabled = False
		_parentModel.Fields("CREATEOUTPUTIDSET").Enabled = False
		_parentModel.Fields("OUTPUTIDSETTYPECODE").Enabled = False
		_parentModel.Fields("OUTPUTIDSETNAME").Enabled = False
		_parentModel.Fields("OVERWRITEOUTPUTIDSET").Enabled = False

		_transfermsg.ValueObject = INFO1 & " " & _childsponsorships.ToString(_cultureInfo) & " " & INFO2 & " "

		'Create lock helper objects.  Roll back if Current opportunity is locked.
		sc = _parentModel.GetRequestSecurityContext
		lockHelperFrom = New SponsorshipOpportunityLockHelperUIModel(sc)
		lockHelperTo = New SponsorshipOpportunityLockHelperUIModel(sc)
		Try
			lockHelperFrom.LockOpportunity(_parentModel.RecordId, SponsorshipOpportunityLockHelperUIModel.LockType.Edit, _parentModel.GetRequestContext)
		Catch ex As ServiceException
			Throw New ServiceException("The selected opportunity could not be locked for edit because another user is currently accessing the opportunity.") 'My.Resources.Errors.CouldNotLockOpportunity_Form)
		End Try

	End Sub
	Friend Sub HandleReason()
		_choosingchild.Enabled = False
		_transfermsg.ValueObject = INFO1 & " " & _childsponsorships.ToString(_cultureInfo) & " " & INFO2 & " " & MSGNOTRANS
		If _reasonid.Equals(Nothing) Then
			Exit Sub
		End If
		Dim dataListID As Guid

		dataListID = New Guid(REASONINFO)

		Dim request As New DataListLoadRequest

		With request
			.DataListID = dataListID
			.SecurityContext = _parentModel.GetRequestSecurityContext
		End With

		Dim svc = New AppFxWebService(_parentModel.GetRequestContext())
		Dim reply As DataListLoadReply = svc.DataListLoad(request)
		For Each row As DataListResultRow In reply.Rows
			If (row.Values(0).Equals(_reasonid.ValueObject.ToString) AndAlso row.Values(3).Equals("True") AndAlso _childsponsorships > 0) Then
				_choosingchild.Enabled = True
				_transfermsg.ValueObject = INFO1 & " " & _childsponsorships.ToString(_cultureInfo) & " " & INFO2 & " " & MSGTRANS
			End If
		Next
		_parentModel.Fields("CREATEOUTPUTIDSET").Enabled = True
	End Sub


	Private Sub _reasonid_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs) Handles _reasonid.ValueChanged
		HandleReason()
	End Sub
	'Radio button changed.
	Private Sub _choosingchild_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs) Handles _choosingchild.ValueChanged
		_parentModel.Fields("NEWSPONSORSHIPOPPORTUNITYID").Enabled = False
		'If specific child or project enable the opportunity search.
		'If (_typecode = 2 AndAlso _choosingchild.ValueObject.Equals(SponsorshipOpportunityProjectClosedPreprocessEditFormUIModel.CHOOSINGCHILDS.SpecificProject)) _
		'OrElse (_typecode = 1 AndAlso _choosingchild.ValueObject.Equals(SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModel.CHOOSINGCHILDS.SpecificChild)) Then
		If _typecode = 1 AndAlso _choosingchild.ValueObject.Equals(SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModelDepartureTransfer.CHOOSINGCHILDS.SpecificChild) Then
			_parentModel.Fields("NEWSPONSORSHIPOPPORTUNITYID").Enabled = True
		Else 'Matching child or project.  Unlock record and empty display string.
			_NewOpportunity.SearchDisplayText = String.Empty
			lockHelperTo.UnlockOpportunity(_parentModel.GetRequestContext)
		End If
	End Sub

	Private Sub _createoutputidset_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs) Handles _createoutputidset.ValueChanged
		If _createoutputidset.Value.Equals(True) Then
			_parentModel.Fields("OUTPUTIDSETTYPECODE").Enabled = True
			_parentModel.Fields("OUTPUTIDSETNAME").Enabled = True
			_parentModel.Fields("OVERWRITEOUTPUTIDSET").Enabled = True
		Else
			_parentModel.Fields("OUTPUTIDSETTYPECODE").Enabled = False
			_parentModel.Fields("OUTPUTIDSETNAME").Enabled = False
			_parentModel.Fields("OVERWRITEOUTPUTIDSET").Enabled = False
		End If
	End Sub

	Friend Function ValidateNewOpportunity() As Boolean

		If _parentModel.Fields("NEWSPONSORSHIPOPPORTUNITYID").ValueObject.Equals(Guid.Empty) AndAlso _
		 _typecode = 1 AndAlso _choosingchild.ValueObject.Equals(SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModel.CHOOSINGCHILDS.SpecificChild) Then
			'((_typecode = 2 AndAlso _choosingchild.ValueObject.Equals(SponsorshipOpportunityProjectClosedPreprocessEditFormUIModel.CHOOSINGCHILDS.SpecificProject)) _
			'OrElse (_typecode = 1 AndAlso _choosingchild.ValueObject.Equals(SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModel.CHOOSINGCHILDS.SpecificChild))) Then

			Select Case _typecode
				Case 1
					_reasontext = String.Format(Globalization.CultureInfo.CurrentCulture, PROMPTCHILD)

				Case 2
					_reasontext = String.Format(Globalization.CultureInfo.CurrentCulture, PROMPTPROJECT)

			End Select
			Return False
		End If

		Return True
	End Function

	Private Sub _NewOpportunity_SearchItemSelected(ByVal sender As Object, ByVal e As UIModeling.Core.SearchItemSelectedEventArgs) Handles _NewOpportunity.SearchItemSelected
		lockHelperTo.UnlockOpportunity(_NewOpportunity.ValueObject.ToString, _parentModel.GetRequestContext)
		Try
			lockHelperTo.LockOpportunity(_NewOpportunity.ValueObject.ToString, SponsorshipOpportunityLockHelperUIModel.LockType.Exclusive, _parentModel.GetRequestContext)
		Catch ex As ServiceException
			_NewOpportunity.ValueObject = Nothing
			Throw New ServiceException("The selected opportunity could not be locked for sponsorship.  This typically means another user is currently accessing the opportunity.  The opportunity may be available once that user has released it.")	'My.Resources.Errors.CouldNotLockOpportunity_Inline)
		End Try

	End Sub

	Private Sub _parentModel_Canceling(ByVal sender As Object, ByVal e As UIModeling.Core.CancelingEventArgs) Handles _parentModel.Canceling
		lockHelperTo.UnlockOpportunity(_parentModel.GetRequestContext)
		lockHelperFrom.UnlockOpportunity(_parentModel.GetRequestContext)
	End Sub
End Class

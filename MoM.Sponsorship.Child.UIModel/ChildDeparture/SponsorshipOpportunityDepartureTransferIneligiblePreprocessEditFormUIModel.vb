Imports Blackbaud.AppFx

' This was copied from the OOB SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModel
' The only change was to add the call to HandleReason so that the proper enabling / disabling would occur for the current Departure Sponsorship Reason

Public Class SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModelDepartureTransfer
	<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>
	Private ineligibleHelper As SponsorshipOpportunityPreprocessIneligibleHelperDepartureTransfer

	Private Sub SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		ineligibleHelper = New SponsorshipOpportunityPreprocessIneligibleHelperDepartureTransfer(Me, 1)

		' Added this call - OCM
		ineligibleHelper.HandleReason()

	End Sub

	Private Sub SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModel_Validating(ByVal sender As Object, ByVal e As UIModeling.Core.ValidatingEventArgs) Handles Me.Validating
		If Not ineligibleHelper.ValidateNewOpportunity() Then
			e.Valid = False
			e.InvalidReason = ineligibleHelper.getInvalidReason()
		End If
	End Sub
End Class
Imports Blackbaud.AppFx

' Copied from OOB - [SponsorshipOpportunityProjectClosedPreprocessEditFormUIModel]
' Nothing changed.  Just needed to include in the project because things in the partial class are referenced in the other classes related to DepartureTransfer
Public Class SponsorshipOpportunityProjectClosedPreprocessEditFormUIModelDepartureTransfer

	<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>
	Private ineligibleHelper As SponsorshipOpportunityPreprocessIneligibleHelperDepartureTransfer

	Private Sub SponsorshipOpportunityProjectClosedPreprocessEditFormUIModelLoaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		ineligibleHelper = New SponsorshipOpportunityPreprocessIneligibleHelperDepartureTransfer(Me, 2)

	End Sub



	Private Sub SponsorshipOpportunityProjectClosedPreprocessEditFormUIModel_Validating(ByVal sender As Object, ByVal e As UIModeling.Core.ValidatingEventArgs) Handles Me.Validating
		If Not ineligibleHelper.ValidateNewOpportunity() Then
			e.Valid = False
			e.InvalidReason = ineligibleHelper.getInvalidReason()
		End If
	End Sub
End Class
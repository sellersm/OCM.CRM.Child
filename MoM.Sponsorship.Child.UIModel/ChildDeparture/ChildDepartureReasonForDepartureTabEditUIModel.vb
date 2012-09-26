Public Class ChildDepartureReasonForDepartureTabEditUIModel

    Private Sub ChildDepartureReasonForDepartureTabEditUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Dim departureHelper As New DepartureFormsHelper(Me, Common.CRMHelper.FormMode.Edit)
        'departureHelper.HandleFormLoad(GetRequestContext().AppUserInfo.AppUserName)
        departureHelper.UserName = GetRequestContext().AppUserInfo.AppUserName
        departureHelper.InitializeCodeTableVars()
        departureHelper.SetRequiredFields()
        departureHelper.SetupDepartureFields()
    End Sub

End Class
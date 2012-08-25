Public Class ChildDepartureReasonForDepartureTabViewUIModel

    Private Sub ChildDepartureReasonForDepartureTabViewUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Dim departureHelper As New DepartureFormsHelper(Me, Common.CRMHelper.FormMode.View)
        'departureHelper.HandleFormLoad(GetRequestContext().AppUserInfo.AppUserName)\
        departureHelper.UserName = GetRequestContext().AppUserInfo.AppUserName
        departureHelper.SetupDepartureFields()
    End Sub

End Class
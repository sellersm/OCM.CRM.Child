Public Class ChildDepartureEditPageSummaryDataFormUIModel

    Private Sub ChildDepartureEditPageSummaryDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Dim departureHelper As New DepartureFormsHelper(Me, Common.CRMHelper.FormMode.Edit)
        'departureHelper.HandleFormLoad(GetRequestContext().AppUserInfo.AppUserName)\
        departureHelper.UserName = GetRequestContext().AppUserInfo.AppUserName
        departureHelper.InitializeCodeTableVars()
        departureHelper.SetRequiredFields()

        If Me.DEPARTURETYPECODE.Value <> DepartureFieldNames.DepartureType.Administrative Then
            Me.ADMINISTRATIVECODEID.Enabled = False
        End If
    End Sub

End Class
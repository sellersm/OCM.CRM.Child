Imports Blackbaud.AppFx.UIModeling.Core
Imports System.Linq

Public Class ChildDepartureAddFormUIModel

    Private Sub ChildDepartureAddFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Dim departureHelper As New DepartureFormsHelper(Me, Common.CRMHelper.FormMode.Edit)
        'departureHelper.HandleFormLoad(GetRequestContext().AppUserInfo.AppUserName)\
        departureHelper.UserName = GetRequestContext().AppUserInfo.AppUserName
        departureHelper.InitializeCodeTableVars()
        departureHelper.SetRequiredFields()

        'turn off all the departure/program completion fields until user selects the departure type:
        departureHelper.TurnOffDepartureFields(Me)
        departureHelper.TurnOffProgramCompletionFields(Me)

    End Sub

    

End Class
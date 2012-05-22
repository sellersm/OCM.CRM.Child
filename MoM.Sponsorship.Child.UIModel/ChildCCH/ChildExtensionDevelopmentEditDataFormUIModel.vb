Imports Blackbaud.AppFx.UIModeling.Core

Public Class ChildExtensionDevelopmentEditDataFormUIModel

    Private Sub ChildExtensionDevelopmentEditDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        'add code here to require the CHILDPERSONALITY field
        Dim cchHelper As New CCHFormsHelper(Me, Common.CRMHelper.FormMode.Edit)
        cchHelper.UserName = GetRequestContext().AppUserInfo.AppUserName
        cchHelper.InitializeCodeTableVars()
        'cchHelper.HandleFormLoad(GetRequestContext().AppUserInfo.AppUserName)
    End Sub

    'Private Sub AttendingSchool_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _attendingschool.ValueChanged

    '    '' set the not attending school reason required based on the attending school checkbox
    '    ' set the not attending school reason required based on the attending school checkbox
    '    If Me.ATTENDINGSCHOOL.HasValue Then
    '        Me.REASONNOTATTENDINGSCHOOL.Required = (Not Me.ATTENDINGSCHOOL.Value)
    '        Me.CLASSLEVEL.Required = (Me.ATTENDINGSCHOOL.Value)
    '        Me.CLASSLEVEL.Enabled = (Me.ATTENDINGSCHOOL.Value)
    '        If Not Me.REASONNOTATTENDINGSCHOOL.Required Then
    '            'disable the not attending school reason if the child is attending school:
    '            Me.REASONNOTATTENDINGSCHOOL.Enabled = False
    '        Else
    '            Me.REASONNOTATTENDINGSCHOOL.Enabled = True
    '        End If
    '    Else
    '        Me.REASONNOTATTENDINGSCHOOL.Required = False
    '        Me.REASONNOTATTENDINGSCHOOL.Enabled = False
    '        Me.CLASSLEVEL.Required = False
    '        Me.CLASSLEVEL.Enabled = False
    '    End If


    '    'If Me.ATTENDINGSCHOOL.HasValue Then
    '    '    Me.REASONNOTATTENDINGSCHOOL.Required = (Not Me.ATTENDINGSCHOOL.Value)
    '    '    If Not Me.REASONNOTATTENDINGSCHOOL.Required Then
    '    '        'disable the not attending school reason if the child is attending school:
    '    '        Me.REASONNOTATTENDINGSCHOOL.Enabled = False
    '    '    Else
    '    '        Me.REASONNOTATTENDINGSCHOOL.Enabled = True
    '    '    End If
    '    'Else
    '    '    Me.REASONNOTATTENDINGSCHOOL.Required = False
    '    '    Me.REASONNOTATTENDINGSCHOOL.Enabled = False
    '    'End If

    'End Sub

    Private Sub ShowMessage(ByVal message As String, ByVal buttonStyle As UIPromptButtonStyle, ByVal imageStyle As UIPromptImageStyle)
        Dim prompt As New UIPrompt
        prompt.Text = message
        prompt.ImageStyle = imageStyle
        prompt.ButtonStyle = buttonStyle
        Me.Prompts.Add(prompt)
    End Sub

End Class
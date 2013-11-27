Imports Blackbaud.AppFx.UIModeling.Core
Imports Blackbaud
Imports MoM.Common

Public Class ChildExtensionWhoILiveWithEditDataFormUIModel
    Private _cchHelper As CCHFormsHelper

    Private Sub ChildExtensionWhoILiveWithEditDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        _cchHelper = New CCHFormsHelper(Me, Common.CRMHelper.FormMode.Edit)
        _cchHelper.InitializeCodeTableVars()
        'set the initial state of the fields based on the data:
        SetupFields()

    End Sub

    'Private Sub FatherWorksAsCodeId_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _fatherworksascodeid.ValueChanged

    '    If Me.FATHERWORKSASCODEID.HasValue Then
    '        Select Case Me.FATHERWORKSASCODEID.GetDescription
    '            Case "Other"
    '                Me.FATHERWORKSASOTHER.Required = True
    '            Case Else
    '                Me.FATHERWORKSASOTHER.Required = False
    '        End Select
    '    Else
    '        Me.FATHERWORKSASOTHER.Required = False
    '    End If

    'End Sub

    'Private Sub MotherWorksAsCode_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _motherworksascodeid.ValueChanged

    '    If Me.MOTHERWORKSASCODEID.HasValue Then
    '        Select Case Me.MOTHERWORKSASCODEID.GetDescription
    '            Case "Other"
    '                Me.MOTHERWORKSASOTHER.Required = True
    '            Case Else
    '                Me.MOTHERWORKSASOTHER.Required = False
    '        End Select
    '    Else
    '        Me.MOTHERWORKSASOTHER.Required = False
    '    End If
    'End Sub

    'Private Sub CareGiverRelationCode_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _caregiverrelationcodeid.ValueChanged

    '    If Me.CAREGIVERRELATIONCODEID.HasValue Then
    '        Select Case Me.CAREGIVERRELATIONCODEID.GetDescription
    '            Case "Other"
    '                Me.CAREGIVERRELATIONOTHER.Required = True
    '            Case Else
    '                Me.CAREGIVERRELATIONOTHER.Required = False
    '        End Select
    '    Else
    '        Me.CAREGIVERRELATIONOTHER.Required = False
    '    End If
    'End Sub

    'Private Sub CareGiverWorksAsCode_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _caregiverworksascodeid.ValueChanged

    '    If Me.CAREGIVERWORKSASCODEID.HasValue Then
    '        Select Case Me.CAREGIVERWORKSASCODEID.GetDescription
    '            Case "Other"
    '                Me.CAREGIVERWORKSASOTHER.Required = True
    '            Case Else
    '                Me.CAREGIVERWORKSASOTHER.Required = False
    '        End Select
    '    Else
    '        Me.CAREGIVERWORKSASOTHER.Required = False
    '    End If
    'End Sub

    'Private Sub CareGiverReasonCode_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _caregiverreasoncodeid.ValueChanged

    '    If Me.CAREGIVERREASONCODEID.HasValue Then
    '        Select Case Me.CAREGIVERREASONCODEID.GetDescription
    '            Case "Other"
    '                Me.REASONFORCAREGIVEROTHER.Required = True
    '            Case Else
    '                Me.REASONFORCAREGIVEROTHER.Required = False
    '        End Select
    '    Else
    '        Me.REASONFORCAREGIVEROTHER.Required = False
    '    End If
    'End Sub

    'Private Sub ChildLivesWithCodeId_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _childliveswithcodeid.ValueChanged
    '    ' these rules are from the google doc spreadsheet, "CCH Logic" tab:
    '    If Me.CHILDLIVESWITHCODEID.HasValue Then
    '        Select Case Me.CHILDLIVESWITHCODEID.GetDescription().ToLower()
    '            Case "both parents at home"
    '                Me.FATHERWORKSASCODEID.Required = True
    '                Me.FATHERWORKSASCODEID.Enabled = True
    '                Me.FATHERWORKSASOTHER.Enabled = True
    '                Me.MOTHERWORKSASCODEID.Required = True
    '                Me.MOTHERWORKSASCODEID.Enabled = True
    '                Me.MOTHERWORKSASOTHER.Enabled = True
    '                SetCareGiverFields(False)

    '            Case "father only at home"
    '                Me.FATHERWORKSASCODEID.Required = True
    '                Me.FATHERWORKSASCODEID.Enabled = True
    '                Me.FATHERWORKSASOTHER.Enabled = True
    '                Me.MOTHERWORKSASCODEID.Required = False
    '                Me.MOTHERWORKSASCODEID.Enabled = False
    '                Me.MOTHERWORKSASOTHER.Enabled = False
    '                SetCareGiverFields(False)

    '            Case "mother only at home"
    '                Me.MOTHERWORKSASCODEID.Required = True
    '                Me.MOTHERWORKSASCODEID.Enabled = True
    '                Me.MOTHERWORKSASOTHER.Enabled = True
    '                Me.FATHERWORKSASCODEID.Required = False
    '                Me.FATHERWORKSASCODEID.Enabled = False
    '                Me.FATHERWORKSASOTHER.Enabled = False
    '                SetCareGiverFields(False)


    '            Case "does not live with parents"
    '                Me.FATHERWORKSASCODEID.Required = False
    '                Me.FATHERWORKSASCODEID.Enabled = False
    '                Me.FATHERWORKSASOTHER.Enabled = False
    '                Me.MOTHERWORKSASCODEID.Required = False
    '                Me.MOTHERWORKSASCODEID.Enabled = False
    '                Me.MOTHERWORKSASOTHER.Enabled = False
    '                SetCareGiverFields(True)

    '            Case Else
    '                Me.FATHERWORKSASCODEID.Required = False
    '                Me.FATHERWORKSASCODEID.Enabled = True
    '                Me.FATHERWORKSASOTHER.Enabled = True
    '                Me.MOTHERWORKSASCODEID.Required = False
    '                Me.MOTHERWORKSASCODEID.Enabled = True
    '                Me.MOTHERWORKSASOTHER.Enabled = True
    '                Me.CAREGIVERRELATIONCODEID.Required = False
    '                Me.CAREGIVERRELATIONCODEID.Enabled = True
    '                Me.CAREGIVERRELATIONOTHER.Enabled = True
    '                Me.CAREGIVERWORKSASCODEID.Required = False
    '                Me.CAREGIVERWORKSASCODEID.Enabled = True
    '                Me.CAREGIVERWORKSASOTHER.Enabled = True
    '                Me.CAREGIVERREASONCODEID.Required = False
    '                Me.CAREGIVERREASONCODEID.Enabled = True
    '                Me.REASONFORCAREGIVEROTHER.Required = False
    '                Me.REASONFORCAREGIVEROTHER.Enabled = True

    '        End Select
    '    Else
    '        Me.FATHERWORKSASCODEID.Enabled = True
    '        Me.FATHERWORKSASOTHER.Enabled = True
    '        Me.MOTHERWORKSASCODEID.Enabled = True
    '        Me.MOTHERWORKSASOTHER.Enabled = True
    '        Me.CAREGIVERRELATIONCODEID.Enabled = True
    '        Me.CAREGIVERRELATIONOTHER.Enabled = True
    '        Me.CAREGIVERWORKSASCODEID.Enabled = True
    '        Me.CAREGIVERWORKSASOTHER.Enabled = True
    '        Me.CAREGIVERREASONCODEID.Enabled = True
    '        Me.REASONFORCAREGIVEROTHER.Enabled = True
    '    End If

    'End Sub

    Private Sub ChildExtensionWhoILiveWithEditDataFormUIModel_Validating(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValidatingEventArgs) Handles Me.Validating
        'prompt the user that they must enter the Siblings in the Siblings Tab:
        If (Me.NUMBEROFBROTHERS.HasValue AndAlso Me.NUMBEROFBROTHERS.Value > 0) OrElse (Me.NUMBEROFSISTERS.HasValue AndAlso Me.NUMBEROFSISTERS.Value > 0) Then
            CRMHelper.ShowMessage("Please be sure to enter the Siblings information in the Siblings Tab on the Child Screen.", UIPromptButtonStyle.Ok, UIPromptImageStyle.Information, Me)
        End If

    End Sub



    'Private Sub SetCareGiverFields(ByVal value As Boolean)
    '    Me.CAREGIVERRELATIONCODEID.Required = value
    '    Me.CAREGIVERRELATIONCODEID.Enabled = value
    '    Me.CAREGIVERRELATIONOTHER.Enabled = value

    '    Me.CAREGIVERWORKSASCODEID.Required = value
    '    Me.CAREGIVERWORKSASCODEID.Enabled = value
    '    Me.CAREGIVERWORKSASOTHER.Enabled = value

    '    Me.CAREGIVERREASONCODEID.Required = value
    '    Me.CAREGIVERREASONCODEID.Enabled = value
    '    'Me.REASONFORCAREGIVEROTHER.Required = value
    '    Me.REASONFORCAREGIVEROTHER.Enabled = value
    'End Sub

    Private Sub SetupFields()
        If Me.CHILDLIVESWITHCODEID.HasValue Then
            Select Case Me.CHILDLIVESWITHCODEID.GetDescription().ToLower()
                Case "both parents at home"
                    Me.FATHERWORKSASCODEID.Required = True
                    Me.FATHERWORKSASCODEID.Enabled = True
                    Me.FATHERWORKSASOTHER.Enabled = True
                    Me.MOTHERWORKSASCODEID.Required = True
                    Me.MOTHERWORKSASCODEID.Enabled = True
                    Me.MOTHERWORKSASOTHER.Enabled = True
                    _cchHelper.SetCareGiverFields(False, Me)

                Case "father only at home"
                    Me.FATHERWORKSASCODEID.Required = True
                    Me.FATHERWORKSASCODEID.Enabled = True
                    Me.FATHERWORKSASOTHER.Enabled = True
                    Me.MOTHERWORKSASCODEID.Required = False
                    Me.MOTHERWORKSASCODEID.Enabled = False
                    Me.MOTHERWORKSASOTHER.Enabled = False
                    _cchHelper.SetCareGiverFields(False, Me)

                Case "mother only at home"
                    Me.MOTHERWORKSASCODEID.Required = True
                    Me.MOTHERWORKSASCODEID.Enabled = True
                    Me.MOTHERWORKSASOTHER.Enabled = True
                    Me.FATHERWORKSASCODEID.Required = False
                    Me.FATHERWORKSASCODEID.Enabled = False
                    Me.FATHERWORKSASOTHER.Enabled = False
                    _cchHelper.SetCareGiverFields(False, Me)


                Case "does not live with parents"
                    Me.FATHERWORKSASCODEID.Required = False
                    Me.FATHERWORKSASCODEID.Enabled = False
                    Me.FATHERWORKSASOTHER.Enabled = False
                    Me.MOTHERWORKSASCODEID.Required = False
                    Me.MOTHERWORKSASCODEID.Enabled = False
                    Me.MOTHERWORKSASOTHER.Enabled = False
                    _cchHelper.SetCareGiverFields(True, Me)

                Case Else
                    Me.FATHERWORKSASCODEID.Required = False
                    Me.FATHERWORKSASCODEID.Enabled = True
                    Me.FATHERWORKSASOTHER.Enabled = True
                    Me.MOTHERWORKSASCODEID.Required = False
                    Me.MOTHERWORKSASCODEID.Enabled = True
                    Me.MOTHERWORKSASOTHER.Enabled = True
                    Me.CAREGIVERRELATIONCODEID.Required = False
                    Me.CAREGIVERRELATIONCODEID.Enabled = True
                    Me.CAREGIVERRELATIONOTHER.Enabled = True
                    Me.CAREGIVERWORKSASCODEID.Required = False
                    Me.CAREGIVERWORKSASCODEID.Enabled = True
                    Me.CAREGIVERWORKSASOTHER.Enabled = True
                    Me.CAREGIVERREASONCODEID.Required = False
                    Me.CAREGIVERREASONCODEID.Enabled = True
                    Me.REASONFORCAREGIVEROTHER.Required = False
                    Me.REASONFORCAREGIVEROTHER.Enabled = True

            End Select
        Else
            Me.FATHERWORKSASCODEID.Enabled = True
            Me.FATHERWORKSASOTHER.Enabled = True
            Me.MOTHERWORKSASCODEID.Enabled = True
            Me.MOTHERWORKSASOTHER.Enabled = True
            Me.CAREGIVERRELATIONCODEID.Enabled = True
            Me.CAREGIVERRELATIONOTHER.Enabled = True
            Me.CAREGIVERWORKSASCODEID.Enabled = True
            Me.CAREGIVERWORKSASOTHER.Enabled = True
            Me.CAREGIVERREASONCODEID.Enabled = True
            Me.REASONFORCAREGIVEROTHER.Enabled = True
        End If
    End Sub


End Class
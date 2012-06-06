Imports Blackbaud.AppFx.UIModeling.Core

Public Class ChildExtensionSponsorshipOpportunityChildAddFormWrappedUIModel

    Private Sub ChildExtensionSponsorshipOpportunityChildAddFormWrappedUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Dim cchHelper As New CCHFormsHelper(Me, Common.CRMHelper.FormMode.Edit)
        cchHelper.HandleFormLoad(GetRequestContext().AppUserInfo.AppUserName)
        cchHelper.InitializeCodeTableVars()

        'Me.BIRTHDATEACCURACYCODEID.Required = True
        'Me.CHILDLIVESWITHCODEID.Required = True
        'Me.NUMBEROFBROTHERS.Required = True
        'Me.NUMBEROFSISTERS.Required = True
        'Me.AREADESCRIPTION.Required = True
        'Me.MYFAVORITETHINGTODO.Required = True
        'Me.WHENIPLAYWITHFRIENDSWE.Required = True
        'Me.WHENATHOMEIHELPOUTBY.Required = True
        'Me.WHENITALKTOGODIASKHIM.Required = True
        'Me.SOMEDAYI.Required = True
        'Me.TWOMOSTFAVORITETHINGS.Required = True
        'Me.CHILDPERSONALITY.Required = True

        ''disable all of the 'Other' fields until needed to prevent accidental data entry
        'Me.MOTHERWORKSASOTHER.Enabled = False
        'Me.REASONFORCAREGIVEROTHER.Enabled = False
        'Me.FATHERWORKSASOTHER.Enabled = False
        'Me.CAREGIVERRELATIONOTHER.Enabled = False
        'Me.CAREGIVERWORKSASOTHER.Enabled = False

        ''disable these fields until they select who they live with:
        'Me.FATHERWORKSASCODEID.Enabled = False
        'Me.MOTHERWORKSASCODEID.Enabled = False
        'Me.CAREGIVERWORKSASCODEID.Enabled = False
        'Me.CAREGIVERRELATIONCODEID.Enabled = False
        'Me.CAREGIVERREASONCODEID.Enabled = False

        ''ShowMessage(GetRequestContext().AppUserInfo.AppUserName.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)

        'Me.CCHENTEREDBY.Value = GetRequestContext().AppUserInfo.AppUserName

        'If Me.PHOTOSTORED.HasValue Then
        '    Me.CURRENTPHOTODATE.Required = (Me.PHOTOSTORED.Value)
        '    Me.CURRENTPHOTODATE.Enabled = (Me.PHOTOSTORED.Value)
        'Else
        '    Me.CURRENTPHOTODATE.Required = False
        '    Me.CURRENTPHOTODATE.Enabled = False
        'End If

        '' set the not attending school reason required based on the attending school checkbox
        'If Me.ATTENDINGSCHOOL.HasValue Then
        '    Me.REASONNOTATTENDINGSCHOOL.Required = (Not Me.ATTENDINGSCHOOL.Value)
        '    Me.CLASSLEVEL.Required = (Me.ATTENDINGSCHOOL.Value)
        '    Me.CLASSLEVEL.Enabled = (Me.ATTENDINGSCHOOL.Value)
        '    If Not Me.REASONNOTATTENDINGSCHOOL.Required Then
        '        'disable the not attending school reason if the child is attending school:
        '        Me.REASONNOTATTENDINGSCHOOL.Enabled = False
        '    Else
        '        Me.REASONNOTATTENDINGSCHOOL.Enabled = True
        '    End If
        'Else
        '    Me.REASONNOTATTENDINGSCHOOL.Required = False
        '    Me.REASONNOTATTENDINGSCHOOL.Enabled = False
        '    Me.CLASSLEVEL.Required = False
        '    Me.CLASSLEVEL.Enabled = False
        'End If

    End Sub

    'Private Sub ChildLivesWithCodeId_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _childliveswithcodeid.ValueChanged
    '    ' these rules are from the google doc spreadsheet, "CCH Logic" tab:
    '    If Me.CHILDLIVESWITHCODEID.HasValue Then
    '        Select Case Me.CHILDLIVESWITHCODEID.GetDescription().ToLower()
    '            Case "both parents at home"
    '                Me.FATHERWORKSASCODEID.Required = True
    '                Me.FATHERWORKSASCODEID.Enabled = True
    '                'Me.FATHERWORKSASOTHER.Enabled = True
    '                Me.MOTHERWORKSASCODEID.Required = True
    '                Me.MOTHERWORKSASCODEID.Enabled = True
    '                'Me.MOTHERWORKSASOTHER.Enabled = True
    '                SetCareGiverFields(False)

    '            Case "father only at home"
    '                Me.FATHERWORKSASCODEID.Required = True
    '                Me.FATHERWORKSASCODEID.Enabled = True
    '                'Me.FATHERWORKSASOTHER.Enabled = True
    '                Me.MOTHERWORKSASCODEID.Required = False
    '                Me.MOTHERWORKSASCODEID.Enabled = False
    '                Me.MOTHERWORKSASOTHER.Value = Nothing
    '                Me.MOTHERWORKSASOTHER.Enabled = False
    '                Me.MOTHERWORKSASCODEID.Value = Nothing
    '                SetCareGiverFields(False)

    '            Case "mother only at home"
    '                Me.MOTHERWORKSASCODEID.Required = True
    '                Me.MOTHERWORKSASCODEID.Enabled = True
    '                'Me.MOTHERWORKSASOTHER.Enabled = True
    '                Me.FATHERWORKSASCODEID.Required = False
    '                Me.FATHERWORKSASCODEID.Enabled = False
    '                Me.FATHERWORKSASOTHER.Value = Nothing
    '                Me.FATHERWORKSASOTHER.Enabled = False
    '                Me.FATHERWORKSASCODEID.Value = Nothing
    '                SetCareGiverFields(False)


    '            Case "does not live with parents"
    '                SetCareGiverFields(True)
    '                Me.FATHERWORKSASCODEID.Value = Nothing
    '                Me.FATHERWORKSASOTHER.Value = Nothing
    '                Me.MOTHERWORKSASCODEID.Value = Nothing
    '                Me.MOTHERWORKSASOTHER.Value = Nothing
    '                Me.FATHERWORKSASCODEID.Required = False
    '                Me.FATHERWORKSASCODEID.Enabled = False
    '                Me.FATHERWORKSASOTHER.Enabled = False
    '                Me.MOTHERWORKSASCODEID.Required = False
    '                Me.MOTHERWORKSASCODEID.Enabled = False
    '                Me.MOTHERWORKSASOTHER.Enabled = False


    '            Case Else
    '                Me.FATHERWORKSASCODEID.Required = False
    '                Me.FATHERWORKSASCODEID.Enabled = True
    '                'Me.FATHERWORKSASOTHER.Enabled = True
    '                Me.MOTHERWORKSASCODEID.Required = False
    '                Me.MOTHERWORKSASCODEID.Enabled = True
    '                'Me.MOTHERWORKSASOTHER.Enabled = True
    '                Me.CAREGIVERRELATIONCODEID.Required = False
    '                Me.CAREGIVERRELATIONCODEID.Enabled = True
    '                'Me.CAREGIVERRELATIONOTHER.Enabled = True
    '                Me.CAREGIVERWORKSASCODEID.Required = False
    '                Me.CAREGIVERWORKSASCODEID.Enabled = True
    '                'Me.CAREGIVERWORKSASOTHER.Enabled = True
    '                Me.CAREGIVERREASONCODEID.Required = False
    '                Me.CAREGIVERREASONCODEID.Enabled = True
    '                Me.REASONFORCAREGIVEROTHER.Required = False
    '                'Me.REASONFORCAREGIVEROTHER.Enabled = True

    '        End Select
    '    Else
    '        Me.FATHERWORKSASCODEID.Enabled = True
    '        'Me.FATHERWORKSASOTHER.Enabled = True
    '        Me.MOTHERWORKSASCODEID.Enabled = True
    '        'Me.MOTHERWORKSASOTHER.Enabled = True
    '        Me.CAREGIVERRELATIONCODEID.Enabled = True
    '        'Me.CAREGIVERRELATIONOTHER.Enabled = True
    '        Me.CAREGIVERWORKSASCODEID.Enabled = True
    '        'Me.CAREGIVERWORKSASOTHER.Enabled = True
    '        Me.CAREGIVERREASONCODEID.Enabled = True
    '        'Me.REASONFORCAREGIVEROTHER.Enabled = True
    '    End If

    'End Sub

    'Private Sub FatherWorksAsCodeId_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _fatherworksascodeid.ValueChanged

    '    If Me.FATHERWORKSASCODEID.HasValue Then
    '        Select Case Me.FATHERWORKSASCODEID.GetDescription
    '            Case "Other"
    '                Me.FATHERWORKSASOTHER.Enabled = True
    '                Me.FATHERWORKSASOTHER.Required = True
    '            Case Else
    '                Me.FATHERWORKSASOTHER.Required = False
    '                Me.FATHERWORKSASOTHER.Enabled = False
    '                Me.FATHERWORKSASOTHER.Value = Nothing
    '        End Select
    '    Else
    '        Me.FATHERWORKSASOTHER.Required = False
    '        Me.FATHERWORKSASOTHER.Enabled = False
    '        Me.FATHERWORKSASOTHER.Value = Nothing
    '    End If

    'End Sub

    'Private Sub MotherWorksAsCode_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _motherworksascodeid.ValueChanged

    '    If Me.MOTHERWORKSASCODEID.HasValue Then
    '        Select Case Me.MOTHERWORKSASCODEID.GetDescription
    '            Case "Other"
    '                Me.MOTHERWORKSASOTHER.Enabled = True
    '                Me.MOTHERWORKSASOTHER.Required = True
    '            Case Else
    '                Me.MOTHERWORKSASOTHER.Required = False
    '                Me.MOTHERWORKSASOTHER.Enabled = False
    '                Me.MOTHERWORKSASOTHER.Value = Nothing
    '        End Select
    '    Else
    '        Me.MOTHERWORKSASOTHER.Required = False
    '        Me.MOTHERWORKSASOTHER.Enabled = False
    '        Me.MOTHERWORKSASOTHER.Value = Nothing
    '    End If
    'End Sub

    'Private Sub CaregiverWorksAsCodeid_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _caregiverworksascodeid.ValueChanged

    '    If Me.CAREGIVERWORKSASCODEID.HasValue Then
    '        Select Case Me.CAREGIVERWORKSASCODEID.GetDescription
    '            Case "Other"
    '                Me.CAREGIVERWORKSASOTHER.Enabled = True
    '                Me.CAREGIVERWORKSASOTHER.Required = True
    '            Case Else
    '                Me.CAREGIVERWORKSASOTHER.Required = False
    '                Me.CAREGIVERWORKSASOTHER.Enabled = False
    '                Me.CAREGIVERWORKSASOTHER.Value = Nothing
    '        End Select
    '    Else
    '        Me.CAREGIVERWORKSASOTHER.Required = False
    '        Me.CAREGIVERWORKSASOTHER.Enabled = False
    '        Me.CAREGIVERWORKSASOTHER.Value = Nothing
    '    End If
    'End Sub

    'Private Sub CaregiverRelationCodeid_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _caregiverrelationcodeid.ValueChanged

    '    If Me.CAREGIVERRELATIONCODEID.HasValue Then
    '        Select Case Me.CAREGIVERRELATIONCODEID.GetDescription
    '            Case "Other"
    '                Me.CAREGIVERRELATIONOTHER.Enabled = True
    '                Me.CAREGIVERRELATIONOTHER.Required = True
    '            Case Else
    '                Me.CAREGIVERRELATIONOTHER.Required = False
    '                Me.CAREGIVERRELATIONOTHER.Enabled = False
    '                Me.CAREGIVERRELATIONOTHER.Value = Nothing
    '        End Select
    '    Else
    '        Me.CAREGIVERRELATIONOTHER.Required = False
    '        Me.CAREGIVERRELATIONOTHER.Enabled = False
    '        Me.CAREGIVERRELATIONOTHER.Value = Nothing
    '    End If
    'End Sub

    'Private Sub CaregiverReasonCodeid_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _caregiverreasoncodeid.ValueChanged

    '    If Me.CAREGIVERREASONCODEID.HasValue Then
    '        Select Case Me.CAREGIVERREASONCODEID.GetDescription
    '            Case "Other"
    '                Me.REASONFORCAREGIVEROTHER.Enabled = True
    '                Me.REASONFORCAREGIVEROTHER.Required = True
    '            Case Else
    '                Me.REASONFORCAREGIVEROTHER.Required = False
    '                Me.REASONFORCAREGIVEROTHER.Enabled = False
    '                Me.REASONFORCAREGIVEROTHER.Value = Nothing
    '        End Select
    '    Else
    '        Me.REASONFORCAREGIVEROTHER.Required = False
    '        Me.REASONFORCAREGIVEROTHER.Enabled = False
    '        Me.REASONFORCAREGIVEROTHER.Value = Nothing
    '    End If
    'End Sub

    'Private Sub AttendingSchool_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _attendingschool.ValueChanged

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

    'End Sub

    'Private Sub PhotoStored_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _photostored.ValueChanged

    '    ' set the Current Photo Date required based on the Photo Stored checkbox
    '    If Me.PHOTOSTORED.HasValue Then
    '        Me.CURRENTPHOTODATE.Required = (Me.PHOTOSTORED.Value)
    '        Me.CURRENTPHOTODATE.Enabled = (Me.PHOTOSTORED.Value)
    '    Else
    '        Me.CURRENTPHOTODATE.Required = False
    '        Me.CURRENTPHOTODATE.Enabled = False
    '    End If

    'End Sub

    'Private Sub ChildExtensionSponsorshipOpportunityChildAddFormWrappedUIModel_Validating(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValidatingEventArgs) Handles Me.Validating
    '    Dim isWallValid As Boolean = False
    '    Dim isRoofValid As Boolean = False
    '    Dim isWaterValid As Boolean = False
    '    Dim isLightValid As Boolean = False
    '    Dim isCookingValid As Boolean = False
    '    'Dim isNumberBrothersValid As Boolean = False
    '    'Dim isNumberSistersValid As Boolean = False
    '    Dim isValid As Boolean = True
    '    Dim requiredMessage As System.Text.StringBuilder = New System.Text.StringBuilder()

    '    'ShowMessage("Inside of Validating!", UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)


    '    'at least one Wall structure value must be entered:
    '    ' note that a checkbox will always have a value, even if it's not checked:
    '    ' value will be False if not checked.
    '    If Me.HOUSINGWALLBAMBOO.Value = False AndAlso Me.HOUSINGWALLBLOCK.Value = False AndAlso Me.HOUSINGWALLMUD.Value = False AndAlso Me.HOUSINGWALLWOOD.Value = False Then
    '        'check the other field:
    '        If Not Me.HOUSINGWALLOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.HOUSINGWALLOTHER.Value.ToString()) Then
    '            isWallValid = False
    '        Else
    '            isWallValid = True
    '        End If
    '    Else
    '        isWallValid = True
    '    End If

    '    'ShowMessage(isWallValid.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)

    '    'at least one Roofing Material value must be entered:
    '    If (Me.ROOFINGGRASSLEAVES.Value = False) AndAlso (Me.ROOFINGTILE.Value = False) AndAlso (Me.ROOFINGTIN.Value = False) AndAlso (Me.ROOFINGWOOD.Value = False) Then
    '        If Not Me.ROOFINGOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.ROOFINGOTHER.Value.ToString()) Then
    '            isRoofValid = False
    '        Else
    '            isRoofValid = True
    '        End If
    '    Else
    '        isRoofValid = True
    '    End If

    '    'ShowMessage(isRoofValid.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)

    '    'at least one Water Source value must be entered:
    '    If (Me.WATERSOURCEBOREHOLEWELL.Value = False) AndAlso (Me.WATERSOURCECOMMUNITYTAP.Value = False) AndAlso (Me.WATERSOURCEINDOOR.Value = False) AndAlso (Me.WATERSOURCERIVER.Value = False) Then
    '        If Not Me.WATERSOURCEOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.WATERSOURCEOTHER.Value.ToString()) Then
    '            isWaterValid = False
    '        Else
    '            isWaterValid = True
    '        End If
    '    Else
    '        isWaterValid = True
    '    End If

    '    'ShowMessage(isWaterValid.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)

    '    'at least one Light Source value must be entered:
    '    If (Me.LIGHTSOURCEELECTRICITY.Value = False) AndAlso (Me.LIGHTSOURCEGENERATOR.Value = False) AndAlso (Me.LIGHTSOURCENONE.Value = False) AndAlso (Me.LIGHTSOURCEOILLAMP.Value = False) Then
    '        If Not Me.LIGHTSOURCEOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.LIGHTSOURCEOTHER.Value.ToString()) Then
    '            isLightValid = False
    '            'ShowMessage("isLightValid is False!", UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)
    '        Else
    '            isLightValid = True
    '            'ShowMessage("isLightValid is True!", UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)
    '        End If
    '    Else
    '        isLightValid = True
    '        'ShowMessage("isLightValid is True!", UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)
    '    End If

    '    'at least one cooking source must be selected/entered:
    '    If (Me.COOKINGSOURCEELECTRICSTOVE.Value = False) AndAlso (Me.COOKINGSOURCEGASSTOVE.Value = False) AndAlso (Me.COOKINGSOURCEWOODFIRE.Value = False) Then
    '        If Not Me.COOKINGSOURCEOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.COOKINGSOURCEOTHER.Value.ToString()) Then
    '            isCookingValid = False
    '        Else
    '            isCookingValid = True
    '        End If
    '    Else
    '        isCookingValid = True
    '    End If


    '    'ShowMessage(isLightValid.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)


    '    If Not isWallValid Then
    '        requiredMessage.AppendLine("At least one Wall Structure value must be entered!")
    '        isValid = False
    '        'Else
    '        '    isValid = True
    '    End If

    '    If Not isRoofValid Then
    '        requiredMessage.AppendLine("At least one Roofing Material value must be entered!")
    '        isValid = False
    '        'Else
    '        '    isValid = True
    '    End If

    '    If Not isWaterValid Then
    '        requiredMessage.AppendLine("At least one Water Source value must be entered!")
    '        isValid = False
    '        'Else
    '        '    isValid = True
    '    End If

    '    If Not isLightValid Then
    '        requiredMessage.AppendLine("At least one Light Source value must be entered!")
    '        isValid = False
    '        'Else
    '        '    isValid = True
    '    End If

    '    If Not isCookingValid Then
    '        requiredMessage.AppendLine("At least one Cooking Source value must be entered!")
    '        isValid = False
    '        'Else
    '        '    isValid = True
    '    End If

    '    If Not isValid Then
    '        'ShowMessage(requiredMessage.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Warning)
    '        e.InvalidReason = requiredMessage.ToString()
    '        e.Valid = False
    '    Else
    '        e.Valid = True
    '    End If
    'End Sub

    'Private Sub ShowMessage(ByVal message As String, ByVal buttonStyle As UIPromptButtonStyle, ByVal imageStyle As UIPromptImageStyle)
    '    Dim prompt As New UIPrompt
    '    prompt.Text = message
    '    prompt.ImageStyle = imageStyle
    '    prompt.ButtonStyle = buttonStyle
    '    Me.Prompts.Add(prompt)
    'End Sub

    'Private Sub SetCareGiverFields(ByVal value As Boolean)
    '    Me.CAREGIVERRELATIONCODEID.Required = value
    '    Me.CAREGIVERRELATIONCODEID.Enabled = value
    '    'Me.CAREGIVERRELATIONOTHER.Enabled = value

    '    Me.CAREGIVERWORKSASCODEID.Required = value
    '    Me.CAREGIVERWORKSASCODEID.Enabled = value
    '    'Me.CAREGIVERWORKSASOTHER.Enabled = value

    '    Me.CAREGIVERREASONCODEID.Required = value
    '    Me.CAREGIVERREASONCODEID.Enabled = value
    '    'Me.REASONFORCAREGIVEROTHER.Enabled = value

    '    'If turning fields 'off', clear out any entries in the fields:
    '    If value = False Then
    '        If Me.CAREGIVERRELATIONCODEID.HasValue Then
    '            Me.CAREGIVERRELATIONCODEID.Value = Nothing
    '        End If

    '        If Me.CAREGIVERWORKSASCODEID.HasValue Then
    '            Me.CAREGIVERWORKSASCODEID.Value = Nothing
    '        End If

    '        If Me.CAREGIVERREASONCODEID.HasValue Then
    '            Me.CAREGIVERREASONCODEID.Value = Nothing
    '        End If

    '        Me.CAREGIVERRELATIONOTHER.Value = Nothing
    '        Me.CAREGIVERWORKSASOTHER.Value = Nothing
    '        Me.REASONFORCAREGIVEROTHER.Value = Nothing
    '    End If
    'End Sub

End Class
Imports Blackbaud.AppFx.UIModeling.Core
Imports Blackbaud

Public Class ChildDepartureEditFormUIModel

    Private Sub ChildDepartureEditFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Me.ADMINISTRATIVEEXPLANATION.Enabled = False
        Me.ADMINISTRATIVEEXPLANATION.Required = False

        'set the required fields:
        Me.CHILDCHRISTIANEXPERIENCE.Required = True
        Me.HEALTHCONDITIONS.Required = True
        Me.CHILDMATUREDCODE.Required = True
        Me.LEVELOFMATURITY.Required = True
        Me.HIGHESTCLASSLEVELCODEID.Required = True
        Me.GENERALCOMMENTS.Required = True

        'if there's a departure reason, turn off program completion fields
        If ThereAreDepartureReasons() Then
            SetProgramCompletionFieldsEnable(False)
            SetProgramCompletionFieldsRequire(False)
        End If

        'if there's a program completion, turn off departure fields
        If ThisIsProgramCompletion() Then
            SetDepartureReasonFields(False)
            Me.DETAILEDEXPLANATION.Enabled = False
            Me.DETAILEDEXPLANATION.Required = False
        End If
    End Sub

    Private Sub AdministrativeCodeID_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _administrativecodeid.ValueChanged
        If Me.ADMINISTRATIVECODEID.HasValue Then
            'make the admin explanation required
            Me.ADMINISTRATIVEEXPLANATION.Required = True
            Me.ADMINISTRATIVEEXPLANATION.Enabled = True
        Else
            Me.ADMINISTRATIVEEXPLANATION.Required = False
            Me.ADMINISTRATIVEEXPLANATION.Enabled = False
        End If
    End Sub

    Private Sub DepartureDeathOfChild_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departuredeathofchild.ValueChanged
        If Me.DEPARTURE_DEATHOFCHILD.HasValue Then
            If Me.DEPARTURE_DEATHOFCHILD.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureEmployed_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departureemployed.ValueChanged
        If Me.DEPARTURE_EMPLOYED.HasValue Then
            If Me.DEPARTURE_EMPLOYED.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If

    End Sub

    Private Sub DepartureFailed_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departurefailed.ValueChanged
        If Me.DEPARTURE_FAILED.HasValue Then
            If Me.DEPARTURE_FAILED.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureFamilyMoved_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departurefamilymoved.ValueChanged
        If Me.DEPARTURE_FAMILYMOVED.HasValue Then
            If Me.DEPARTURE_FAMILYMOVED.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureFamilyNowProvides_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departurefamilynowprovides.ValueChanged
        If Me.DEPARTURE_FAMILYNOWPROVIDES.HasValue Then
            If Me.DEPARTURE_FAMILYNOWPROVIDES.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureIllness_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departureillness.ValueChanged
        If Me.DEPARTURE_ILLNESS.HasValue Then
            If Me.DEPARTURE_ILLNESS.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureLackOfInterest_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departurelackofinterest.ValueChanged
        If Me.DEPARTURE_LACKOFINTEREST.HasValue Then
            If Me.DEPARTURE_LACKOFINTEREST.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureLivesWithRelatives_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departureliveswithrelatives.ValueChanged
        If Me.DEPARTURE_LIVESWITHRELATIVES.HasValue Then
            If Me.DEPARTURE_LIVESWITHRELATIVES.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureMarried_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departuremarried.ValueChanged
        If Me.DEPARTURE_MARRIED.HasValue Then
            If Me.DEPARTURE_MARRIED.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureNeededAtHome_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departureneededathome.ValueChanged
        If Me.DEPARTURE_NEEDEDATHOME.HasValue Then
            If Me.DEPARTURE_NEEDEDATHOME.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureOther_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departureother.ValueChanged
        If Me.DEPARTURE_OTHER.HasValue Then
            If Not String.IsNullOrEmpty(Me.DEPARTURE_OTHER.Value) Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DeparturePregnancy_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departurepregnancy.ValueChanged
        If Me.DEPARTURE_PREGNANCY.HasValue Then
            If Me.DEPARTURE_PREGNANCY.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureProjectTooFar_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departureprojecttoofar.ValueChanged
        If Me.DEPARTURE_PROJECTTOOFAR.HasValue Then
            If Me.DEPARTURE_PROJECTTOOFAR.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureRemovedByParents_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departureremovedbyparents.ValueChanged
        If Me.DEPARTURE_REMOVEDBYPARENTS.HasValue Then
            If Me.DEPARTURE_REMOVEDBYPARENTS.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureTransferred_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _departuretransferred.ValueChanged
        If Me.DEPARTURE_TRANSFERRED.HasValue Then
            If Me.DEPARTURE_TRANSFERRED.Value Then
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub IsProgramCompletion_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _isprogramcompletion.ValueChanged
        'if user checks this box, then new situation program completed field is required and all deparure reason fields are disabled
        If Me.ISPROGRAMCOMPLETION.HasValue Then
            If Me.ISPROGRAMCOMPLETION.Value Then
                SetDepartureReasonFields(False)
                SetRequireDepartureExplanation(False)
                SetProgramCompletionFieldsEnable(True)
                SetProgramCompletionFieldsRequire(True)
            Else
                SetDepartureReasonFields(True)
                SetProgramCompletionFieldsRequire(False)
                SetProgramCompletionFieldsEnable(True)
            End If
        Else
            SetDepartureReasonFields(True)
            SetProgramCompletionFieldsRequire(False)
            SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    'Sets the Departure Reason fields to the parameter value
    Private Sub SetDepartureReasonFields(ByVal isSet As Boolean)
        Me.DETAILEDEXPLANATION.Enabled = isSet
        'Me.DETAILEDEXPLANATION.Required = isSet
        Me.DEPARTURENEWSITUATION.Enabled = isSet
        'Me.DEPARTURENEWSITUATION.Required = isSet
        Me.DEPARTURE_DEATHOFCHILD.Enabled = isSet
        Me.DEPARTURE_EMPLOYED.Enabled = isSet
        Me.DEPARTURE_FAILED.Enabled = isSet
        Me.DEPARTURE_FAMILYMOVED.Enabled = isSet
        Me.DEPARTURE_FAMILYNOWPROVIDES.Enabled = isSet
        Me.DEPARTURE_ILLNESS.Enabled = isSet
        Me.DEPARTURE_LACKOFINTEREST.Enabled = isSet
        Me.DEPARTURE_LIVESWITHRELATIVES.Enabled = isSet
        Me.DEPARTURE_MARRIED.Enabled = isSet
        Me.DEPARTURE_NEEDEDATHOME.Enabled = isSet
        Me.DEPARTURE_OTHER.Enabled = isSet
        Me.DEPARTURE_PREGNANCY.Enabled = isSet
        Me.DEPARTURE_PROJECTTOOFAR.Enabled = isSet
        Me.DEPARTURE_REMOVEDBYPARENTS.Enabled = isSet
        Me.DEPARTURE_TRANSFERRED.Enabled = isSet
    End Sub

    Private Sub SetRequireDepartureExplanation(ByVal isSet As Boolean)
        Me.DETAILEDEXPLANATION.Required = isSet
        Me.DETAILEDEXPLANATION.Enabled = isSet
    End Sub

    'Sets the Program completion fields to the parameter value
    Private Sub SetProgramCompletionFieldsRequire(ByVal isSet As Boolean)
        Me.ISPROGRAMCOMPLETION.Required = isSet
        Me.PROGRAMCOMPLETIONNEWSITUATION.Required = isSet
    End Sub

    Private Sub SetProgramCompletionFieldsEnable(ByVal isSet As Boolean)
        Me.ISPROGRAMCOMPLETION.Enabled = isSet
        Me.PROGRAMCOMPLETIONNEWSITUATION.Enabled = isSet
    End Sub

    Private Sub ChildDepartureAddFormUIModel_Validating(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValidatingEventArgs) Handles Me.Validating
        'at least one spiritual impact checkbox is required
        Dim isSpiritualImpactValid As Boolean = False
        'Dim isRoofValid As Boolean = False
        'Dim isWaterValid As Boolean = False
        'Dim isLightValid As Boolean = False
        'Dim isCookingValid As Boolean = False
        'Dim isNumberBrothersValid As Boolean = False
        'Dim isNumberSistersValid As Boolean = False
        Dim isValid As Boolean = True
        Dim requiredMessage As System.Text.StringBuilder = New System.Text.StringBuilder()

        'at least one spiritual impact value must be entered:
        ' note that a checkbox will always have a value, even if it's not checked:
        ' value will be False if not checked.
        If Me.SHOWSCHRISTIANKNOWLEDGE.Value = False AndAlso Me.SHOWSCHRISTIANEVIDENCE.Value = False AndAlso Me.PARTICIPATESCHRISTIANACTIVITIES.Value = False AndAlso Me.OWNSBIBLEMATERIALS.Value = False Then
            isSpiritualImpactValid = False
        Else
            isSpiritualImpactValid = True
        End If

        If Not isSpiritualImpactValid Then
            requiredMessage.AppendLine("At least one Spiritual Impact checkbox value must be selected!")
            isValid = False
        End If

        'check that if there's a program completion reason, then the checkbox must be checked:
        If Me.PROGRAMCOMPLETIONNEWSITUATION.HasValue Then
            'always check the hasvalue first, before checking the value:
            If Not Me.ISPROGRAMCOMPLETION.HasValue Then
                isValid = False
                requiredMessage.AppendLine("If you have a Program Completion New Situation entry, then you must select the Is Program Completion checkbox.")
            Else
                ' it has a value, but it's not checked:
                If Not Me.ISPROGRAMCOMPLETION.Value Then
                    isValid = False
                    requiredMessage.AppendLine("If you have a Program Completion New Situation entry, then you must select the Is Program Completion checkbox.")
                End If
            End If
        End If

        If Not isValid Then
            'ShowMessage(requiredMessage.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Warning)
            e.InvalidReason = requiredMessage.ToString()
            e.Valid = False
        Else
            e.Valid = True
        End If
    End Sub

    Private Sub ShowMessage(ByVal message As String, ByVal buttonStyle As UIPromptButtonStyle, ByVal imageStyle As UIPromptImageStyle)
        Dim prompt As New UIPrompt
        prompt.Text = message
        prompt.ImageStyle = imageStyle
        prompt.ButtonStyle = buttonStyle
        Me.Prompts.Add(prompt)
    End Sub

    Private Sub HighestClassLevelCodeID_ValueChanged(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _highestclasslevelcodeid.ValueChanged
        If Me.HIGHESTCLASSLEVELCODEID.HasValue Then
            Select Case Me.HIGHESTCLASSLEVELCODEID.GetDescription().ToLower()
                Case "other"
                    Me.HIGHESTCLASSLEVELOTHER.Required = True
                    Me.HIGHESTCLASSLEVELOTHER.Enabled = True

                Case "vocational school"
                    Me.COURSEOFSTUDY.Required = True
                    Me.COURSEOFSTUDY.Enabled = True

                Case "apprenticeship"
                    Me.COURSEOFSTUDY.Required = True
                    Me.COURSEOFSTUDY.Enabled = True

                Case Else
                    Me.HIGHESTCLASSLEVELOTHER.Required = False
                    Me.HIGHESTCLASSLEVELOTHER.Enabled = False
                    Me.COURSEOFSTUDY.Required = False
                    Me.COURSEOFSTUDY.Enabled = False
            End Select
        Else
            Me.HIGHESTCLASSLEVELOTHER.Required = False
            Me.HIGHESTCLASSLEVELOTHER.Enabled = False
            Me.COURSEOFSTUDY.Required = False
            Me.COURSEOFSTUDY.Enabled = False

        End If
    End Sub

    Private Function ThereAreDepartureReasons() As Boolean
        Dim areDepartures As Boolean = False
        'check each departure boolean field for a True value and each textbox for Not IsNullOrEmpty
        If Me.DEPARTURE_DEATHOFCHILD.HasValue AndAlso Me.DEPARTURE_DEATHOFCHILD.Value Then
            areDepartures = True
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_EMPLOYED.HasValue AndAlso Me.DEPARTURE_EMPLOYED.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_FAILED.HasValue AndAlso Me.DEPARTURE_FAILED.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_FAMILYMOVED.HasValue AndAlso Me.DEPARTURE_FAMILYMOVED.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_FAMILYNOWPROVIDES.HasValue AndAlso Me.DEPARTURE_FAMILYNOWPROVIDES.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_ILLNESS.HasValue AndAlso Me.DEPARTURE_ILLNESS.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_LACKOFINTEREST.HasValue AndAlso Me.DEPARTURE_LACKOFINTEREST.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_LIVESWITHRELATIVES.HasValue AndAlso Me.DEPARTURE_LIVESWITHRELATIVES.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_MARRIED.HasValue AndAlso Me.DEPARTURE_MARRIED.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_NEEDEDATHOME.HasValue AndAlso Me.DEPARTURE_NEEDEDATHOME.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_OTHER.HasValue AndAlso (Not String.IsNullOrEmpty(Me.DEPARTURE_OTHER.Value)))
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_PREGNANCY.HasValue AndAlso Me.DEPARTURE_PREGNANCY.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_PROJECTTOOFAR.HasValue AndAlso Me.DEPARTURE_PROJECTTOOFAR.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_REMOVEDBYPARENTS.HasValue AndAlso Me.DEPARTURE_REMOVEDBYPARENTS.Value)
        Else
            Return areDepartures
        End If

        If Not areDepartures Then
            areDepartures = (Me.DEPARTURE_TRANSFERRED.HasValue AndAlso Me.DEPARTURE_TRANSFERRED.Value)
        Else
            Return areDepartures
        End If

        Return areDepartures
    End Function

    Private Function ThisIsProgramCompletion() As Boolean
        Dim isProgramCompletion As Boolean = False

        If Me.ISPROGRAMCOMPLETION.HasValue AndAlso Me.ISPROGRAMCOMPLETION.Value Then
            isProgramCompletion = True
        End If

        Return isProgramCompletion
    End Function

End Class
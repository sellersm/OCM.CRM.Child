Imports Blackbaud.AppFx.UIModeling.Core

Public Class ChildExtensionCCHWhereILiveDataFormUIModel

    Private Sub ChildExtensionCCHWhereILiveDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded

    End Sub

    Private Sub EditForm_Validating(ByVal sender As Object, ByVal e As ValidatingEventArgs) Handles Me.Validating
        'these are all flags for the different form sections:
        Dim isWallValid As Boolean = False
        Dim isRoofValid As Boolean = False
        Dim isWaterValid As Boolean = False
        Dim isLightValid As Boolean = False
        Dim isCookingValid As Boolean = False

        Dim isValid As Boolean = True           'flag for the entire form save
        Dim requiredMessage As System.Text.StringBuilder = New System.Text.StringBuilder()    'to hold the message if anything isn't valid, displayed to user via the ShowMessage() method.


        'at least one Wall structure value must be entered:
        ' note that a checkbox will always have a value, even if it's not checked:
        ' value will be False if not checked.
        If Me.HOUSINGWALLBAMBOO.Value = False AndAlso Me.HOUSINGWALLBLOCK.Value = False AndAlso Me.HOUSINGWALLMUD.Value = False AndAlso Me.HOUSINGWALLWOOD.Value = False Then
            'check the other field:
            If Not Me.HOUSINGWALLOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.HOUSINGWALLOTHER.Value.ToString()) Then
                isWallValid = False
            Else
                isWallValid = True
            End If
        Else
            isWallValid = True
        End If

        'at least one Roofing Material value must be entered:
        If (Me.ROOFINGGRASSLEAVES.Value = False) AndAlso (Me.ROOFINGTILE.Value = False) AndAlso (Me.ROOFINGTIN.Value = False) AndAlso (Me.ROOFINGWOOD.Value = False) Then
            If Not Me.ROOFINGOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.ROOFINGOTHER.Value.ToString()) Then
                isRoofValid = False
            Else
                isRoofValid = True
            End If
        Else
            isRoofValid = True
        End If

        'at least one Water Source value must be entered:
        If (Me.WATERSOURCEBOREHOLEWELL.Value = False) AndAlso (Me.WATERSOURCECOMMUNITYTAP.Value = False) AndAlso (Me.WATERSOURCEINDOOR.Value = False) AndAlso (Me.WATERSOURCERIVER.Value = False) Then
            If Not Me.WATERSOURCEOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.WATERSOURCEOTHER.Value.ToString()) Then
                isWaterValid = False
            Else
                isWaterValid = True
            End If
        Else
            isWaterValid = True
        End If

        'at least one Light Source value must be entered:
        If (Me.LIGHTSOURCEELECTRICITY.Value = False) AndAlso (Me.LIGHTSOURCEGENERATOR.Value = False) AndAlso (Me.LIGHTSOURCENONE.Value = False) AndAlso (Me.LIGHTSOURCEOILLAMP.Value = False) Then
            If Not Me.LIGHTSOURCEOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.LIGHTSOURCEOTHER.Value.ToString()) Then
                isLightValid = False
            Else
                isLightValid = True
            End If
        Else
            isLightValid = True
        End If

        'at least one cooking source must be selected/entered:
        If (Me.COOKINGSOURCEELECTRICSTOVE.Value = False) AndAlso (Me.COOKINGSOURCEGASSTOVE.Value = False) AndAlso (Me.COOKINGSOURCEWOODFIRE.Value = False) Then
            If Not Me.COOKINGSOURCEOTHER.HasValue Then 'AndAlso Not String.IsNullOrEmpty(Me.COOKINGSOURCEOTHER.Value.ToString()) Then
                isCookingValid = False
            Else
                isCookingValid = True
            End If
        Else
            isCookingValid = True
        End If

        'create the message to inform user of required fields if any are missing:
        If Not isWallValid Then
            requiredMessage.AppendLine("At least one Wall Structure value must be entered!")
            isValid = False
            'Else
            '    isValid = True
        End If

        If Not isRoofValid Then
            requiredMessage.AppendLine("At least one Roofing Material value must be entered!")
            isValid = False
            'Else
            '    isValid = True
        End If

        If Not isWaterValid Then
            requiredMessage.AppendLine("At least one Water Source value must be entered!")
            isValid = False
            'Else
            '    isValid = True
        End If

        If Not isLightValid Then
            requiredMessage.AppendLine("At least one Light Source value must be entered!")
            isValid = False
            'Else
            '    isValid = True
        End If

        If Not isCookingValid Then
            requiredMessage.AppendLine("At least one Cooking Source value must be entered!")
            isValid = False
            'Else
            '    isValid = True
        End If

        'You MUST set the e.Valid flag, or the form won't save.
        If Not isValid Then
            e.InvalidReason = requiredMessage.ToString()
            e.Valid = False
        Else
            e.Valid = True
        End If
    End Sub


    ' Method to display the Prompt to the user in CRM
    Private Sub ShowMessage(ByVal message As String, ByVal buttonStyle As UIPromptButtonStyle, ByVal imageStyle As UIPromptImageStyle)
        Dim prompt As New UIPrompt
        prompt.Text = message
        prompt.ImageStyle = imageStyle
        prompt.ButtonStyle = buttonStyle
        Me.Prompts.Add(prompt)
    End Sub

End Class
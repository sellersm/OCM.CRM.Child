Imports Blackbaud.AppFx.UIModeling.Core

Public Class TestBatchEditFormEditDataFormUIModel

    Private Sub TestBatchEditFormEditDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded

    End Sub

    Private Sub TestBatchEditFormEditDataFormUIModel_Validating(ByVal sender As Object, ByVal e As AppFx.UIModeling.Core.ValidatingEventArgs) Handles Me.Validating
        ShowMessage("Inside the validating event in the form to edit a batch row!", UIPromptButtonStyle.Ok, UIPromptImageStyle.Information)
    End Sub

    Private Sub ShowMessage(ByVal message As String, ByVal buttonStyle As UIPromptButtonStyle, ByVal imageStyle As UIPromptImageStyle)
        Dim prompt As New UIPrompt
        prompt.Text = message
        prompt.ImageStyle = imageStyle
        prompt.ButtonStyle = buttonStyle
        Me.Prompts.Add(prompt)
    End Sub

End Class
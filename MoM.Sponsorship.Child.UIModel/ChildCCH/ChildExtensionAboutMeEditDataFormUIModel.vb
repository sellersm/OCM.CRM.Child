Public Class ChildExtensionAboutMeEditDataFormUIModel

    Private Sub ChildExtensionAboutMeEditDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Me.MYFAVORITETHINGTODO.Required = True
        Me.WHENIPLAYWITHFRIENDSWE.Required = True
        Me.WHENATHOMEIHELPOUTBY.Required = True
        Me.WHENITALKTOGODIASKHIM.Required = True
        Me.SOMEDAYI.Required = True
        Me.TWOMOSTFAVORITETHINGS.Required = True
        'Me.CHILDPERSONALITY.Required = True  'this field moved to the Development Tab
    End Sub

End Class
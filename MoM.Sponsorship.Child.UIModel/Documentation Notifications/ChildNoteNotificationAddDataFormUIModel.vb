Imports Blackbaud.AppFx.UIModeling.Core

Public Class ChildNoteNotificationAddDataFormUIModel

    Private Sub ChildNoteNotificationAddDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Me.UpdateSelection()
    End Sub

    Private Sub _applytocode_ValueChanged(sender As Object, e As ValueChangedEventArgs) Handles _applytocode.ValueChanged
        Me.UpdateSelection()
    End Sub

    Private Sub UpdateSelection()
        If (DirectCast(Me.APPLYTOCODE.Value, APPLYTOCODES) = APPLYTOCODES.AllUsers) Then
            Dim guid As Guid
            Me.APPUSERIDSETREGISTERID.Enabled = False
            Me.APPUSERIDSETREGISTERID.Value = guid
            Me.APPUSERIDSETREGISTERID.Required = False
        Else
            Me.APPUSERIDSETREGISTERID.Enabled = True
            Me.APPUSERIDSETREGISTERID.Required = True
        End If
    End Sub

End Class
Imports Blackbaud.AppFx
Imports Blackbaud.AppFx.UIModeling.Core
Imports MoM.Common

Public NotInheritable Class CCHFormsHelper

    Private _model As UIModeling.Core.RootUIModel
    Private _userName As String

    ' these are used to display messages to the user if we can't find the codetable values:
    Private Const _errorTextChildLivesWithNotWithParents = "Could not find 'Does not live with parents' Child Lives With code table value"
    Private Const _errorTextChildLivesWithBothParents = "Could not find 'Both parents at home' Child Lives With code table value"
    Private Const _errorTextChildLivesWithFatherOnly = "Could not find 'Father only at home' Child Lives With code table value"
    Private Const _errorTextChildLivesWithMotherOnly = "Could not find 'Mother only at home' Child Lives With code table value"
    Private Const _errorTextFatherWorksAsOther = "Could not find 'Other' Father Works As code table value"
    Private Const _errorTextMotherWorksAsOther = "Could not find 'Other' Mother Works As code table value"
    Private Const _errorTextCaregiverWorksAsOther = "Could not find 'Other' Caregiver Works As code table value"
    Private Const _errorTextCaregiverRelationOther = "Could not find 'Other' Caregiver Relation code table value"
    Private Const _errorTextCaregiverReasonOther = "Could not find 'Other' Caregiver Reason code table value"

    ' ChildLivesWith code values we need to track:
    ' Case "does not live with parents"
    ' Case "both parents at home"
    ' Case "father only at home"
    ' Case "mother only at home"
    Private _childLivesWithNotWithParentsGuid As String = ""
    Private _childLivesWithBothParentsGuid As String = ""
    Private _childLivesWithFatherOnlyGuid As String = ""
    Private _childLivesWithMotherOnlyGuid As String = ""

    ' Fatherworks As code values we care about:
    ' "other"
    Private _fatherWorksAsOtherGuid As String = ""

    ' Motherworks as code values:
    ' "other"
    Private _motherWorksAsOtherGuid As String = ""

    ' CAREGIVERWORKSASCODE:
    ' "other"
    Private _caregiverWorksAsOtherGuid As String = ""

    ' Caregiver Relation code:
    ' "other"
    Private _caregiverRelationOtherGuid As String = ""

    ' Caregiver Reason code:
    ' "other"
    Private _caregiverReasonOtherGuid As String = ""

    Property FormMode As CRMHelper.FormMode

    Public Property UserName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property

    Public Sub New(ByVal model As UIModeling.Core.RootUIModel, ByVal mode As CRMHelper.FormMode)
        _model = model

        'set the default Mode to View:
        FormMode = mode

        'add the field handler events as necessary here
        SetupEventHandlers(model)

        'do any necessary work as this is called during the form Loaded() event handler
        'HandleFormLoaded()
    End Sub
    Public Sub InitializeCodeTableVars()
        ' create a sqlConnection factory in the Common assembly, will need the current model or context thing...
        ' pass the sqlconnection into the CRMHelper.GetCodeTableItemID() call, deal with possible exception
        ' caller is responsible for using/dispose of the shared sqlconnection object passed between all calls

        'Initialize Code Table IDs 
        Using crmSQLConnection = _model.GetRequestContext().OpenAppDBConnection()
            _childLivesWithBothParentsGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CHILDLIVESWITH_BOTHPARENTSATHOME, True, _errorTextChildLivesWithBothParents)
            _childLivesWithFatherOnlyGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CHILDLIVESWITH_FATHERONLYATHOME, True, _errorTextChildLivesWithFatherOnly)
            _childLivesWithMotherOnlyGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CHILDLIVESWITH_MOTHERONLYATHOME, True, _errorTextChildLivesWithMotherOnly)
            _childLivesWithNotWithParentsGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CHILDLIVESWITH_DOESNOTLIVEWITHPARENTS, True, _errorTextChildLivesWithNotWithParents)
            _caregiverReasonOtherGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CAREGIVERREASON_OTHER, True, _errorTextCaregiverReasonOther)
            _caregiverRelationOtherGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CAREGIVERRELATION_OTHER, True, _errorTextCaregiverRelationOther)
            _caregiverWorksAsOtherGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CAREGIVERWORKSAS_OTHER, True, _errorTextCaregiverWorksAsOther)
            _fatherWorksAsOtherGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.FATHERWORKSAS_OTHER, True, _errorTextFatherWorksAsOther)
            _motherWorksAsOtherGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.MOTHERWORKSAS_OTHER, True, _errorTextMotherWorksAsOther)
        End Using
    End Sub

    Public Sub HandleFormLoad(ByVal userName As String)
        _userName = userName
        HandleFormLoaded()
    End Sub

    Private Sub HandleFormLoaded()
        _model.Fields(CCHFieldNames.BIRTHDATEACCURACYCODEID.ToString()).Required = True
        _model.Fields(CCHFieldNames.CHILDLIVESWITHCODEID.ToString()).Required = True
        _model.Fields(CCHFieldNames.NUMBEROFBROTHERS.ToString()).Required = True
        _model.Fields(CCHFieldNames.NUMBEROFSISTERS.ToString()).Required = True
        _model.Fields(CCHFieldNames.AREADESCRIPTION.ToString()).Required = True
        _model.Fields(CCHFieldNames.MYFAVORITETHINGTODO.ToString()).Required = True
        _model.Fields(CCHFieldNames.WHENIPLAYWITHFRIENDSWE.ToString()).Required = True
        _model.Fields(CCHFieldNames.WHENATHOMEIHELPOUTBY.ToString()).Required = True
        _model.Fields(CCHFieldNames.WHENITALKTOGODIASKHIM.ToString()).Required = True
        _model.Fields(CCHFieldNames.SOMEDAYI.ToString()).Required = True
        _model.Fields(CCHFieldNames.TWOMOSTFAVORITETHINGS.ToString()).Required = True
        _model.Fields(CCHFieldNames.CHILDPERSONALITY.ToString()).Required = True

        'disable all of the 'Other' fields until needed to prevent accidental data entry
        _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Enabled = False
        _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Enabled = False
        _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Enabled = False
        _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).Enabled = False
        _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).Enabled = False

        'disable these fields until they select who they live with:
        _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Enabled = False
        _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Enabled = False
        _model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).Enabled = False
        _model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).Enabled = False
        _model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).Enabled = False

        'ShowMessage(GetRequestContext().AppUserInfo.AppUserNa_model.Fields(CCHFieldNames.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)

        _model.Fields(CCHFieldNames.CCHENTEREDBY.ToString()).ValueObject = _userName 'GetRequestContext().AppUserInfo.AppUserName

        If _model.Fields(CCHFieldNames.PHOTOSTORED.ToString()).HasValue Then
            _model.Fields(CCHFieldNames.CURRENTPHOTODATE.ToString()).Required = CBool(_model.Fields(CCHFieldNames.PHOTOSTORED.ToString()).ValueObject)
            _model.Fields(CCHFieldNames.CURRENTPHOTODATE.ToString()).Enabled = CBool(_model.Fields(CCHFieldNames.PHOTOSTORED.ToString()).ValueObject)
        Else
            _model.Fields(CCHFieldNames.CURRENTPHOTODATE.ToString()).Required = False
            _model.Fields(CCHFieldNames.CURRENTPHOTODATE.ToString()).Enabled = False
        End If

        ' set the not attending school reason required based on the attending school checkbox
        If _model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).HasValue Then
            _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Required = (Not CBool(_model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).ValueObject))
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Required = CBool(_model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).ValueObject)
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Enabled = CBool(_model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).ValueObject)
            If Not _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Required Then
                'disable the not attending school reason if the child is attending school:
                _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Enabled = False
            Else
                _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Enabled = True
            End If
        Else
            _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Required = False
            _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Enabled = False
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Required = False
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Enabled = False
        End If
    End Sub


    Private Sub ChildLivesWithCodeId_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs)
        ' these rules are from the google doc spreadsheet, "CCH Logic" tab:
        If _model.Fields(CCHFieldNames.CHILDLIVESWITHCODEID.ToString()).HasValue Then
            'Dim codeValue As String = CType(_model.Fields(CCHFieldNames.CHILDLIVESWITHCODEID.ToString()), Blackbaud.AppFx.UIModeling.Core.CodeTableField).GetDescription()
            'Select Case codeValue.ToLower()
            Select Case _model.Fields(CCHFieldNames.CHILDLIVESWITHCODEID.ToString()).ValueObject.ToString()
                'Case "both parents at home"
                Case _childLivesWithBothParentsGuid.ToString()
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Required = True
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Enabled = True
                    'Me.FATHERWORKSASOTHER.Enabled = True
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Required = True
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Enabled = True
                    'Me.MOTHERWORKSASOTHER.Enabled = True
                    SetCareGiverFields(False, _model)

                    'Case "father only at home"
                Case _childLivesWithFatherOnlyGuid.ToString()
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Required = True
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Enabled = True
                    'Me.FATHERWORKSASOTHER.Enabled = True
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).ValueObject = Nothing
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).ValueObject = Nothing
                    SetCareGiverFields(False, _model)

                    'Case "mother only at home"
                Case _childLivesWithMotherOnlyGuid.ToString()
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Required = True
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Enabled = True
                    'Me.MOTHERWORKSASOTHER.Enabled = True
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).ValueObject = Nothing
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).ValueObject = Nothing
                    SetCareGiverFields(False, _model)


                    'Case "does not live with parents"
                Case _childLivesWithNotWithParentsGuid.ToString()
                    SetCareGiverFields(True, _model)
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).ValueObject = Nothing
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).ValueObject = Nothing
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).ValueObject = Nothing
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).ValueObject = Nothing
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Enabled = False


                Case Else
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Enabled = True
                    'Me.FATHERWORKSASOTHER.Enabled = True
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Enabled = True
                    'Me.MOTHERWORKSASOTHER.Enabled = True
                    _model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).Enabled = True
                    'Me.CAREGIVERRELATIONOTHER.Enabled = True
                    _model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).Enabled = True
                    'Me.CAREGIVERWORKSASOTHER.Enabled = True
                    _model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).Required = False
                    _model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).Enabled = True
                    _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Required = False
                    'Me.REASONFORCAREGIVEROTHER.Enabled = True

            End Select
        Else
            _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).Enabled = True
            'Me.FATHERWORKSASOTHER.Enabled = True
            _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).Enabled = True
            'Me.MOTHERWORKSASOTHER.Enabled = True
            _model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).Enabled = True
            'Me.CAREGIVERRELATIONOTHER.Enabled = True
            _model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).Enabled = True
            'Me.CAREGIVERWORKSASOTHER.Enabled = True
            _model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).Enabled = True
            'Me.REASONFORCAREGIVEROTHER.Enabled = True
        End If
    End Sub

    Private Sub FatherWorksAsCodeId_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs)
        If _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).HasValue Then
            'Dim codeValue As String = CType(_model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()), Blackbaud.AppFx.UIModeling.Core.CodeTableField).GetDescription()
            'Select Case codeValue.ToLower()
            Select Case _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).ValueObject.ToString()
                'Select Case _model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).GetDescription
                'Case "other"
                Case _fatherWorksAsOtherGuid.ToString()
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Enabled = True
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Required = True
                Case Else
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Required = False
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).ValueObject = Nothing
            End Select
        Else
            _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Required = False
            _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).Enabled = False
            _model.Fields(CCHFieldNames.FATHERWORKSASOTHER.ToString()).ValueObject = Nothing
        End If
    End Sub

    Private Sub MotherWorksAsCode_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs)
        If _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).HasValue Then
            'Dim codeValue As String = CType(_model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()), Blackbaud.AppFx.UIModeling.Core.CodeTableField).GetDescription()
            'Select Case codeValue.ToLower()
            'Select Case _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.GetDescription
            Select Case _model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).ValueObject.ToString()
                'Case "other"
                Case _motherWorksAsOtherGuid.ToString()
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Enabled = True
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Required = True
                Case Else
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Required = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).ValueObject = Nothing
            End Select
        Else
            _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Required = False
            _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).Enabled = False
            _model.Fields(CCHFieldNames.MOTHERWORKSASOTHER.ToString()).ValueObject = Nothing
        End If
    End Sub

    Private Sub CaregiverWorksAsCodeid_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs)
        If _model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).HasValue Then
            'Dim codeValue As String = CType(_model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()), Blackbaud.AppFx.UIModeling.Core.CodeTableField).GetDescription()
            'Select Case codeValue.ToLower()
            'Select Case _model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).GetDescription
            Select Case _model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).ValueObject.ToString()
                'Case "other"
                Case _caregiverWorksAsOtherGuid.ToString()
                    _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).Enabled = True
                    _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).Required = True
                Case Else
                    _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).Required = False
                    _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).ValueObject = Nothing
            End Select
        Else
            _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).Required = False
            _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).Enabled = False
            _model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).ValueObject = Nothing
        End If
    End Sub

    Private Sub CaregiverRelationCodeid_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs)
        If _model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).HasValue Then
            'Dim codeValue As String = CType(_model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()), Blackbaud.AppFx.UIModeling.Core.CodeTableField).GetDescription()
            'Select Case codeValue.ToLower()
            'Select Case _model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.GetDescription
            Select Case _model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).ValueObject.ToString()
                'Case "other"
                Case _caregiverRelationOtherGuid.ToString()
                    _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).Enabled = True
                    _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).Required = True
                Case Else
                    _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).Required = False
                    _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).ValueObject = Nothing
            End Select
        Else
            _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).Required = False
            _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).Enabled = False
            _model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).ValueObject = Nothing
        End If
    End Sub

    Private Sub CaregiverReasonCodeid_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs)
        If _model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).HasValue Then
            'Dim codeValue As String = CType(_model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()), Blackbaud.AppFx.UIModeling.Core.CodeTableField).GetDescription()
            'Select Case codeValue.ToLower()
            'Select Case _model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).GetDescription
            Select Case _model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).ValueObject.ToString()
                'Case "other"
                Case _caregiverReasonOtherGuid.ToString()
                    _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Enabled = True
                    _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Required = True
                Case Else
                    _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Required = False
                    _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Enabled = False
                    _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).ValueObject = Nothing
            End Select
        Else
            _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Required = False
            _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Enabled = False
            _model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).ValueObject = Nothing
        End If
    End Sub

    Private Sub AttendingSchool_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs)
        ' set the not attending school reason required based on the attending school checkbox
        If _model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).HasValue Then
            _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Required = (Not CBool(_model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).ValueObject))
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Required = CBool(_model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).ValueObject)
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Enabled = CBool(_model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).ValueObject)
            If Not _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Required Then
                'disable the not attending school reason if the child is attending school:
                _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Enabled = False
                _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).ValueObject = Nothing
            Else
                _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Enabled = True
            End If
            If _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Required Then
                _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Enabled = True
            Else
                _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Enabled = False
                _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).ValueObject = Nothing
            End If
        Else
            _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Required = False
            _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).Enabled = False
            _model.Fields(CCHFieldNames.REASONNOTATTENDINGSCHOOL.ToString()).ValueObject = Nothing
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Required = False
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).Enabled = False
            _model.Fields(CCHFieldNames.CLASSLEVEL.ToString()).ValueObject = Nothing
        End If
    End Sub

    Private Sub PhotoStored_ValueChanged(ByVal sender As Object, ByVal e As UIModeling.Core.ValueChangedEventArgs)
        ' set the Current Photo Date required based on the Photo Scanned checkbox
        If _model.Fields(CCHFieldNames.PHOTOSTORED.ToString()).HasValue Then
            _model.Fields(CCHFieldNames.CURRENTPHOTODATE.ToString()).Required = CBool(_model.Fields(CCHFieldNames.PHOTOSTORED.ToString()).ValueObject)
            _model.Fields(CCHFieldNames.CURRENTPHOTODATE.ToString()).Enabled = CBool(_model.Fields(CCHFieldNames.PHOTOSTORED.ToString()).ValueObject)
        Else
            _model.Fields(CCHFieldNames.CURRENTPHOTODATE.ToString()).Required = False
            _model.Fields(CCHFieldNames.CURRENTPHOTODATE.ToString()).Enabled = False
        End If
    End Sub

    Private Sub CCHFormUIModel_Validating(ByVal sender As Object, ByVal e As UIModeling.Core.ValidatingEventArgs)
        Dim isWallValid As Boolean = False
        Dim isRoofValid As Boolean = False
        Dim isWaterValid As Boolean = False
        Dim isLightValid As Boolean = False
        Dim isCookingValid As Boolean = False
        Dim isValid As Boolean = True
        Dim requiredMessage As System.Text.StringBuilder = New System.Text.StringBuilder()

        'at least one Wall structure value must be entered:
        ' note that a checkbox will always have a value, even if it's not checked:
        ' value will be False if not checked.

        'note: this is a shared method so must check for field's existence first!
        If _model.Fields.Contains(CCHFieldNames.HOUSINGWALLBAMBOO.ToString()) Then
            If _model.Fields(CCHFieldNames.HOUSINGWALLBAMBOO.ToString()).ValueObject = False AndAlso _model.Fields(CCHFieldNames.HOUSINGWALLBLOCK.ToString()).ValueObject = False AndAlso CBool(_model.Fields(CCHFieldNames.HOUSINGWALLMUD.ToString()).ValueObject) = False AndAlso CBool(_model.Fields(CCHFieldNames.HOUSINGWALLWOOD.ToString()).ValueObject) = False Then
                'check the other field:
                If Not _model.Fields(CCHFieldNames.HOUSINGWALLOTHER.ToString()).HasValue Then 'AndAlso Not String.IsNullOrEmpty(_model.Fields(CCHFieldNames.HOUSINGWALLOTHER.ToString()).ValueObject.ToString()) Then
                    isWallValid = False
                Else
                    isWallValid = True
                End If
            Else
                isWallValid = True
            End If
        Else
            isWallValid = True
        End If

        If _model.Fields.Contains(CCHFieldNames.ROOFINGGRASSLEAVES.ToString()) Then
            'at least one Roofing Material value must be entered:
            If (CBool(_model.Fields(CCHFieldNames.ROOFINGGRASSLEAVES.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.ROOFINGTILE.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.ROOFINGTIN.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.ROOFINGWOOD.ToString()).ValueObject) = False) Then
                If Not _model.Fields(CCHFieldNames.ROOFINGOTHER.ToString()).HasValue Then 'AndAlso Not String.IsNullOrEmpty(_model.Fields(CCHFieldNames.ROOFINGOTHER.ValueObject.ToString()) Then
                    isRoofValid = False
                Else
                    isRoofValid = True
                End If
            Else
                isRoofValid = True
            End If
        Else
            isRoofValid = True
        End If


        If _model.Fields.Contains(CCHFieldNames.WATERSOURCEBOREHOLEWELL.ToString()) Then
            'at least one Water Source value must be entered:
            If (CBool(_model.Fields(CCHFieldNames.WATERSOURCEBOREHOLEWELL.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.WATERSOURCECOMMUNITYTAP.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.WATERSOURCEINDOOR.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.WATERSOURCERIVER.ToString()).ValueObject) = False) Then
                If Not _model.Fields(CCHFieldNames.WATERSOURCEOTHER.ToString()).HasValue Then 'AndAlso Not String.IsNullOrEmpty(_model.Fields(CCHFieldNames.WATERSOURCEOTHER.ValueObject.ToString()) Then
                    isWaterValid = False
                Else
                    isWaterValid = True
                End If
            Else
                isWaterValid = True
            End If
        Else
            isWaterValid = True
        End If


        If _model.Fields.Contains(CCHFieldNames.LIGHTSOURCEELECTRICITY.ToString()) Then
            'at least one Light Source value must be entered:
            If (CBool(_model.Fields(CCHFieldNames.LIGHTSOURCEELECTRICITY.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.LIGHTSOURCEGENERATOR.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.LIGHTSOURCENONE.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.LIGHTSOURCEOILLAMP.ToString()).ValueObject) = False) Then
                If Not _model.Fields(CCHFieldNames.LIGHTSOURCEOTHER.ToString()).HasValue Then 'AndAlso Not String.IsNullOrEmpty(_model.Fields(CCHFieldNames.LIGHTSOURCEOTHER.ValueObject.ToString()) Then
                    isLightValid = False
                    'ShowMessage("isLightValid is False!", UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)
                Else
                    isLightValid = True
                    'ShowMessage("isLightValid is True!", UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)
                End If
            Else
                isLightValid = True
                'ShowMessage("isLightValid is True!", UIPromptButtonStyle.Ok, UIPromptImageStyle.Exclamation)
            End If
        Else
            isLightValid = True
        End If

        If _model.Fields.Contains(CCHFieldNames.COOKINGSOURCEELECTRICSTOVE.ToString()) Then
            'at least one cooking source must be selected/entered:
            If (CBool(_model.Fields(CCHFieldNames.COOKINGSOURCEELECTRICSTOVE.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.COOKINGSOURCEGASSTOVE.ToString()).ValueObject) = False) AndAlso (CBool(_model.Fields(CCHFieldNames.COOKINGSOURCEWOODFIRE.ToString()).ValueObject) = False) Then
                If Not _model.Fields(CCHFieldNames.COOKINGSOURCEOTHER.ToString()).HasValue Then 'AndAlso Not String.IsNullOrEmpty(_model.Fields(CCHFieldNames.COOKINGSOURCEOTHER.ValueObject.ToString()) Then
                    isCookingValid = False
                Else
                    isCookingValid = True
                End If
            Else
                isCookingValid = True
            End If
        Else
            isCookingValid = True
        End If

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

        If Not isValid Then
            'ShowMessage(requiredMessage.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Warning)
            e.InvalidReason = requiredMessage.ToString()
            e.Valid = False
        Else
            e.Valid = True
        End If
    End Sub


    Private Sub ShowMessage(ByVal message As String, ByVal buttonStyle As UIPromptButtonStyle, ByVal imageStyle As UIPromptImageStyle)
        'use the static method in FormHelper:
        CRMHelper.ShowMessage(message, buttonStyle, imageStyle, _model)
    End Sub

    Private Sub SetupEventHandlers(ByVal model As RootUIModel)
        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(CCHFieldNames.CHILDLIVESWITHCODEID.ToString()) Then
            AddHandler model.Fields(CCHFieldNames.CHILDLIVESWITHCODEID.ToString()).ValueChanged, AddressOf ChildLivesWithCodeId_ValueChanged
        End If

        If model.Fields.Contains(CCHFieldNames.FATHERWORKSASCODEID.ToString()) Then
            AddHandler model.Fields(CCHFieldNames.FATHERWORKSASCODEID.ToString()).ValueChanged, AddressOf FatherWorksAsCodeId_ValueChanged
        End If

        If model.Fields.Contains(CCHFieldNames.MOTHERWORKSASCODEID.ToString()) Then
            AddHandler model.Fields(CCHFieldNames.MOTHERWORKSASCODEID.ToString()).ValueChanged, AddressOf MotherWorksAsCode_ValueChanged
        End If

        If model.Fields.Contains(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()) Then
            AddHandler model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).ValueChanged, AddressOf CaregiverWorksAsCodeid_ValueChanged
        End If

        If model.Fields.Contains(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()) Then
            AddHandler model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).ValueChanged, AddressOf CaregiverRelationCodeid_ValueChanged
        End If

        If model.Fields.Contains(CCHFieldNames.CAREGIVERREASONCODEID.ToString()) Then
            AddHandler model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).ValueChanged, AddressOf CaregiverReasonCodeid_ValueChanged
        End If

        If model.Fields.Contains(CCHFieldNames.ATTENDINGSCHOOL.ToString()) Then
            AddHandler model.Fields(CCHFieldNames.ATTENDINGSCHOOL.ToString()).ValueChanged, AddressOf AttendingSchool_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(CCHFieldNames.PHOTOSTORED.ToString()) Then
            AddHandler model.Fields(CCHFieldNames.PHOTOSTORED.ToString()).ValueChanged, AddressOf PhotoStored_ValueChanged
        End If

        AddHandler model.Validating, AddressOf CCHFormUIModel_Validating
    End Sub

    Public Sub SetCareGiverFields(ByVal value As Boolean, ByRef model As UIModeling.Core.RootUIModel)
        model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).Required = value
        model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).Enabled = value
        'Me.CAREGIVERRELATIONOTHER.Enabled = value

        model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).Required = value
        model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).Enabled = value
        'Me.CAREGIVERWORKSASOTHER.Enabled = value

        model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).Required = value
        model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).Enabled = value
        'Me.REASONFORCAREGIVEROTHER.Enabled = value

        'If turning fields 'off', clear out any entries in the fields:
        If value = False Then
            If model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).HasValue Then
                model.Fields(CCHFieldNames.CAREGIVERRELATIONCODEID.ToString()).ValueObject = Nothing
            End If

            If model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).HasValue Then
                model.Fields(CCHFieldNames.CAREGIVERWORKSASCODEID.ToString()).ValueObject = Nothing
            End If

            If model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).HasValue Then
                model.Fields(CCHFieldNames.CAREGIVERREASONCODEID.ToString()).ValueObject = Nothing
            End If

            model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).ValueObject = Nothing
            model.Fields(CCHFieldNames.CAREGIVERRELATIONOTHER.ToString()).Enabled = value
            model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).ValueObject = Nothing
            model.Fields(CCHFieldNames.CAREGIVERWORKSASOTHER.ToString()).Enabled = value
            model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).ValueObject = Nothing
            model.Fields(CCHFieldNames.REASONFORCAREGIVEROTHER.ToString()).Enabled = value
        End If
    End Sub

End Class


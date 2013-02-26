Imports Blackbaud.AppFx
Imports Blackbaud.AppFx.UIModeling.Core
Imports MoM.Common
Imports System.Linq

Public NotInheritable Class DepartureFormsHelper
    Private _model As UIModeling.Core.RootUIModel
    Private _userName As String
    Private _isDeparture As Boolean = False
    Private _isProgramCompletion As Boolean = False

    Private Const _errorTextCouldNotFindClassLevelOther = "Could not find 'Other' Class Level code table value"
    Private Const _errorTextCouldNotFindClassLevelApprentice = "Could not find 'Apprentice' Class Level code table value"
    Private Const _errorTextCouldNotFindClassLevelVocationalSchool = "Could not find 'Vocational School' Class Level code table value"

    Private _classLevelCodeOtherGuid As String = ""
    Private _classLevelCodeVocationalSchoolGuid As String = ""
    Private _classLevelCodeApprenticeGuid As String = ""

    'used to identify if this is an Admin departure, which means 
    'none of the validation/field rules apply except for general information fields
    Private _isAdminOverride As Boolean

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
        _isDeparture = False
        _isProgramCompletion = False

        'set the default Mode to View:
        FormMode = mode

        'Add handlers for all the events we care about:
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
            _classLevelCodeApprenticeGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CHILDCLASSLEVEL_APPRENTICESHIP, True, _errorTextCouldNotFindClassLevelApprentice)
            _classLevelCodeOtherGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CHILDCLASSLEVEL_OTHER, True, _errorTextCouldNotFindClassLevelOther)
            _classLevelCodeVocationalSchoolGuid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.CHILDCLASSLEVEL_VOCATIONALSCHOOL, True, _errorTextCouldNotFindClassLevelVocationalSchool)
        End Using

    End Sub

    Public Sub HandleFormLoad(ByVal userName As String)
        _userName = userName
        HandleFormLoaded()
    End Sub

    Private Sub HandleFormLoaded()

    End Sub

    Public Sub SetupDepartureFields()
        'sets the initial state of departure/program completion fields based on the data values:
        'if this is a program completion, disable all departure reasons
		'check the departureType and setup based on that:
		'10/26/12 Memphis: FogBugz Case 947 need to determine the departure type, could be called from the Edit form/tab, so may not have all the fields:
		If _model.Fields.Contains(DepartureFieldNames.DEPARTURETYPECODE.ToString()) Then
			If _model.Fields(DepartureFieldNames.DEPARTURETYPECODE.ToString()).ValueObject.ToString() = DepartureFieldNames.DepartureType.Departure.ToString() Then
				_isDeparture = True
				_isProgramCompletion = False
				_isAdminOverride = False
				SetDepartureReasonFields(True)
				SetProgramCompletionFieldsRequire(False)
				SetProgramCompletionFieldsEnable(False)
			Else
				If _model.Fields(DepartureFieldNames.DEPARTURETYPECODE.ToString()).ValueObject.ToString() = DepartureFieldNames.DepartureType.Completion.ToString() Then
					_isProgramCompletion = True
					_isDeparture = False
					_isAdminOverride = False
					SetDepartureReasonFields(False)
					SetRequireDepartureExplanation(False)
					SetProgramCompletionFieldsEnable(True)
					SetProgramCompletionFieldsRequire(True)
				End If
			End If
		Else
			'we don't have departuretype in this model/form, so check the other way:
			If _model.Fields.Contains(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()) Then
				If _model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).HasValue Then
					If CBool(_model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).ValueObject) = True Then
						SetDepartureReasonFields(False)
						SetRequireDepartureExplanation(False)
						SetProgramCompletionFieldsEnable(True)
						SetProgramCompletionFieldsRequire(True)
						_isProgramCompletion = True
						_isDeparture = False
					Else
						'we assume this is a departure then but check:
						If DepartureReasonsExist() Then
							_isDeparture = True
							_isProgramCompletion = False
							SetDepartureReasonFields(True)
							SetProgramCompletionFieldsRequire(False)
							SetProgramCompletionFieldsEnable(False)
						End If
					End If
				Else
					_isProgramCompletion = False
					_isDeparture = True
				End If
			Else
				_isProgramCompletion = False
				_isDeparture = False
			End If
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURETYPEVALUE.ToString()) Then
			If _model.Fields(DepartureFieldNames.DEPARTURETYPEVALUE.ToString()).ValueObject.ToString() = DepartureFieldNames.DepartureType.Completion.ToString() Then
				_isProgramCompletion = True
				_isDeparture = False
				_isAdminOverride = False
				SetDepartureReasonFields(False)
				SetRequireDepartureExplanation(False)
				SetProgramCompletionFieldsEnable(True)
				SetProgramCompletionFieldsRequire(True)
			End If
		End If

	End Sub

    Public Sub SetRequiredFields()
        If _model.Fields.Contains(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()) Then
            If _model.Fields.Contains(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()) Then
                _model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).Enabled = (_model.Fields(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()).HasValue)
            End If
        End If

        If _model.Fields.Contains(DepartureFieldNames.DEPARTURETYPECODE.ToString()) Then
            _model.Fields(DepartureFieldNames.DEPARTURETYPECODE.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()) Then
            _model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).Required = False
        End If

        'set the required fields:
        If _model.Fields.Contains(DepartureFieldNames.DATEOFDEPARTURE.ToString()) Then
            _model.Fields(DepartureFieldNames.DATEOFDEPARTURE.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.DATEFORMCOMPLETED.ToString()) Then
            _model.Fields(DepartureFieldNames.DATEFORMCOMPLETED.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.FORMCOMPLETEDBY.ToString()) Then
            _model.Fields(DepartureFieldNames.FORMCOMPLETEDBY.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.CHILDCHRISTIANEXPERIENCE.ToString()) Then
            _model.Fields(DepartureFieldNames.CHILDCHRISTIANEXPERIENCE.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.HEALTHCONDITIONS.ToString()) Then
            _model.Fields(DepartureFieldNames.HEALTHCONDITIONS.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.CHILDMATUREDCODE.ToString()) Then
            _model.Fields(DepartureFieldNames.CHILDMATUREDCODE.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.LEVELOFMATURITY.ToString()) Then
            _model.Fields(DepartureFieldNames.LEVELOFMATURITY.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()) Then
            _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()).Required = True
        End If

        If _model.Fields.Contains(DepartureFieldNames.GENERALCOMMENTS.ToString()) Then
            _model.Fields(DepartureFieldNames.GENERALCOMMENTS.ToString()).Required = True
        End If

    End Sub

    Private Sub AdministrativeCodeID_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
		' FogBugz #732: when an administrative reason is selected, turn off all other tabs & fields:
		If _model.Fields.Contains(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()) Then
			If _model.Fields(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()).HasValue Then
				'make the admin explanation required
				_model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).Required = True
				_model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).Enabled = True
				'passing False will turn off all required fields since this is an admin departure
				SetAdministrativeDeparture(False)
				_isAdminOverride = True
				'set the departuretype code to Administrative:
				_model.Fields(DepartureFieldNames.DEPARTURETYPECODE.ToString()).ValueObject = 2	 'Administrative
			Else
				_model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).ValueObject = Nothing
				_model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).Required = False
				_model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).Enabled = False
				_isAdminOverride = False
				'passing True will set all required fields
				SetAdministrativeDeparture(True)
			End If
		End If

	End Sub

    Private Sub DepartureDeathOfChild_ValueChanged()
        If _model.Fields(DepartureFieldNames.DEPARTURE_DEATHOFCHILD.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_DEATHOFCHILD.ToString()).ValueObject) Then
                _isDeparture = True
                'turn off program completion fields
                SetProgramCompletionFieldsEnable(False)
                SetProgramCompletionFieldsRequire(False)
                _isProgramCompletion = False
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                If _isProgramCompletion Then
                    SetRequireDepartureExplanation(False)
                    SetProgramCompletionFieldsEnable(True)
                End If

            End If
        Else
            If _isProgramCompletion Then
                SetProgramCompletionFieldsEnable(True)
            End If
        End If
    End Sub

	Private Sub SetDepartureReasonFields(ByVal isSet As Boolean)
		If _model.Fields.Contains(DepartureFieldNames.DETAILEDEXPLANATION.ToString()) Then
			_model.Fields(DepartureFieldNames.DETAILEDEXPLANATION.ToString()).Enabled = isSet
			If Not isSet Then
				_model.Fields(DepartureFieldNames.DETAILEDEXPLANATION.ToString()).ValueObject = Nothing
			End If
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURENEWSITUATION.ToString()) Then
			'_model.Fields(DepartureFieldNames.DETAILEDEXPLANATION.Required = isSet
			_model.Fields(DepartureFieldNames.DEPARTURENEWSITUATION.ToString()).Enabled = isSet
			If Not isSet Then
				_model.Fields(DepartureFieldNames.DEPARTURENEWSITUATION.ToString()).ValueObject = Nothing
			End If
		End If

		'_model.Fields(DepartureFieldNames.DEPARTURENEWSITUATION.Required = isSet
		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_DEATHOFCHILD.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_DEATHOFCHILD.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_EMPLOYED.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_EMPLOYED.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_FAILED.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_FAILED.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_FAMILYMOVED.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_FAMILYMOVED.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_FAMILYNOWPROVIDES.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_FAMILYNOWPROVIDES.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_ILLNESS.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_ILLNESS.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_LACKOFINTEREST.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_LACKOFINTEREST.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_LIVESWITHRELATIVES.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_LIVESWITHRELATIVES.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_MARRIED.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_MARRIED.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_NEEDEDATHOME.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_NEEDEDATHOME.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_OTHER.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_OTHER.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_PREGNANCY.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_PREGNANCY.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_PROJECTTOOFAR.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_PROJECTTOOFAR.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_REMOVEDBYPARENTS.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_REMOVEDBYPARENTS.ToString()).Enabled = isSet
		End If

		If _model.Fields.Contains(DepartureFieldNames.DEPARTURE_TRANSFERRED.ToString()) Then
			_model.Fields(DepartureFieldNames.DEPARTURE_TRANSFERRED.ToString()).Enabled = isSet
		End If

	End Sub

	Private Sub SetRequireDepartureExplanation(ByVal isSet As Boolean)
		If _model.Fields.Contains(DepartureFieldNames.DETAILEDEXPLANATION.ToString()) Then
			_model.Fields(DepartureFieldNames.DETAILEDEXPLANATION.ToString()).Required = isSet
			_model.Fields(DepartureFieldNames.DETAILEDEXPLANATION.ToString()).Enabled = isSet
			If Not isSet Then
				_model.Fields(DepartureFieldNames.DETAILEDEXPLANATION.ToString()).ValueObject = Nothing
			End If
		End If
	End Sub

    'Sets the Program completion fields to the parameter value
    Private Sub SetProgramCompletionFieldsRequire(ByVal isSet As Boolean)
        If _model.Fields.Contains(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()) Then
            _model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).Required = isSet
        End If

        If _model.Fields.Contains(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()) Then
            _model.Fields(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()).Required = isSet
        End If

        If Not isSet Then
            If _model.Fields.Contains(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()) Then
                _model.Fields(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()).ValueObject = Nothing
            End If
        End If
    End Sub

    Private Sub SetProgramCompletionFieldsEnable(ByVal isSet As Boolean)
        If _model.Fields.Contains(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()) Then
            _model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).Enabled = isSet
            If Not isSet Then
                _model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).ValueObject = Nothing
            End If
        End If
        If _model.Fields.Contains(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()) Then
            _model.Fields(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()).Enabled = isSet
            If Not isSet Then
                _model.Fields(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()).ValueObject = Nothing
            End If
        End If

    End Sub

    Private Sub DepartureEmployed_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_EMPLOYED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_EMPLOYED.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureFailed_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_FAILED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_FAILED.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureFamilyMoved_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_FAMILYMOVED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_FAMILYMOVED.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureFamilyNowProvides_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_FAMILYNOWPROVIDES.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_FAMILYNOWPROVIDES.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureIllness_ValueChanged()
        If _model.Fields(DepartureFieldNames.DEPARTURE_ILLNESS.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_ILLNESS.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureLackOfInterest_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_LACKOFINTEREST.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_LACKOFINTEREST.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureLivesWithRelatives_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_LIVESWITHRELATIVES.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_LIVESWITHRELATIVES.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureMarried_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_MARRIED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_MARRIED.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureNeededAtHome_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_NEEDEDATHOME.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_NEEDEDATHOME.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureOther_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_OTHER.ToString()).HasValue Then
            If Not String.IsNullOrEmpty(_model.Fields(DepartureFieldNames.DEPARTURE_OTHER.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DeparturePregnancy_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_PREGNANCY.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_PREGNANCY.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureProjectTooFar_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_PROJECTTOOFAR.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_PROJECTTOOFAR.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureRemovedByParents_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_REMOVEDBYPARENTS.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_REMOVEDBYPARENTS.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub DepartureTransferred_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.DEPARTURE_TRANSFERRED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_TRANSFERRED.ToString()).ValueObject) Then
                'turn off program completion fields
                'SetProgramCompletionFieldsEnable(False)
                'SetProgramCompletionFieldsRequire(False)
                'require detailed explanation
                SetRequireDepartureExplanation(True)
            Else
                'SetRequireDepartureExplanation(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        Else
            'SetProgramCompletionFieldsEnable(True)
        End If
    End Sub

    Private Sub IsProgramCompletion_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        'if user checks this box, then new situation program completed field is required and all deparure reason fields are disabled
        If Not _isAdminOverride Then
            If _model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).HasValue Then
                If CBool(_model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).ValueObject) Then
                    _isProgramCompletion = True
                    _isDeparture = False
                    TurnOnOffDepartureFields(False)
                    'SetDepartureReasonFields(False)
                    'SetRequireDepartureExplanation(False)
                    TurnOnOffProgramCompletionFields(True)
                    SetProgramCompletionFieldsEnable(True)
                    SetProgramCompletionFieldsRequire(True)
                Else
                    TurnOnOffDepartureFields(True)
                    'SetDepartureReasonFields(True)
                    TurnOnOffProgramCompletionFields(False)
                    'SetProgramCompletionFieldsRequire(False)
                    'SetProgramCompletionFieldsEnable(True)
                End If
            Else
                'SetDepartureReasonFields(True)
                'SetProgramCompletionFieldsRequire(False)
                'SetProgramCompletionFieldsEnable(True)
            End If
        End If
    End Sub

    Private Sub DepartureFormUIModel_Validating(ByVal sender As Object, ByVal e As ValidatingEventArgs)
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

        'only validate if this isn't an admin type of departure:
		If (Not _isAdminOverride) Then
			'at least one spiritual impact value must be entered:
			' note that a checkbox will always have a value, even if it's not checked:
			' value will be False if not checked.
			' 10/26/12 Memphis FogBugz Case 947. If program completion, then spiritual checkboxes aren't required.
			If Not _isProgramCompletion Then
				If _model.Fields.Contains(DepartureFieldNames.SHOWSCHRISTIANKNOWLEDGE.ToString()) Then
					If CBool(_model.Fields(DepartureFieldNames.SHOWSCHRISTIANKNOWLEDGE.ToString()).ValueObject) = False _
					 AndAlso CBool(_model.Fields(DepartureFieldNames.SHOWSCHRISTIANEVIDENCE.ToString()).ValueObject) = False _
					 AndAlso CBool(_model.Fields(DepartureFieldNames.PARTICIPATESCHRISTIANACTIVITIES.ToString()).ValueObject) = False _
					 AndAlso CBool(_model.Fields(DepartureFieldNames.OWNSBIBLEMATERIALS.ToString()).ValueObject) = False Then
						isSpiritualImpactValid = False
					Else
						isSpiritualImpactValid = True
					End If
				Else
					isSpiritualImpactValid = True
				End If

				If Not isSpiritualImpactValid Then
					requiredMessage.AppendLine("At least one Spiritual Impact checkbox value must be selected!")
					isValid = False
				End If
			End If

			'check that if there's a program completion reason, then the checkbox must be checked:
			If _model.Fields.Contains(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()) Then
				If _model.Fields(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()).HasValue Then
					'always check the hasvalue first, before checking the value:
					If Not _model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).HasValue Then
						isValid = False
						requiredMessage.AppendLine("If you have a Program Completion New Situation entry, then you must select the Is Program Completion checkbox.")
					Else
						' it has a value, but it's not checked:
						If Not CBool(_model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).ValueObject) Then
							isValid = False
							requiredMessage.AppendLine("If you have a Program Completion New Situation entry, then you must select the Is Program Completion checkbox.")
						End If
					End If
				End If
			Else
			End If

			'If the user does not check the ʺIsProgramCompletionʺ checkbox, then one ʺDepartureReasonʺ checkbox is required.
			If _model.Fields.Contains(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()) Then
				If _model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).HasValue Then
					' check the value of the checkbox:
					If CBool(_model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).ValueObject) = False Then
						' check the departure reasons to see if there's at least one:
						If DepartureReasonsExist() Then
							isValid = True
						Else
							isValid = False
							requiredMessage.AppendLine("If this is not a Program Completion, then there must be at least one Departure Reason.")
						End If
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
		Else
			''display the required fields to debug:
			'Dim fields As List(Of UIField) = _model.Fields.ToList()
			'For Each field As UIField In fields
			'    If field.Required Then
			'        CRMHelper.ShowMessage(field.Name.ToString(), UIPromptButtonStyle.Ok, UIPromptImageStyle.Information, _model)
			'    End If
			'Next
		End If

	End Sub

    Private Sub HighestClassLevelCodeID_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        If _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()).HasValue Then
            Dim codeValue As String = CType(_model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()), Blackbaud.AppFx.UIModeling.Core.CodeTableField).GetDescription()
            'Select Case codeValue.ToLower()
            Select Case _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()).ValueObject.ToString()
                ' other
                Case _classLevelCodeOtherGuid.ToString()
                    _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).Required = True
                    _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).Enabled = True
                    'clear out any entry in course of study field:
                    _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).ValueObject = Nothing

                    'vocational school: course of study is required
                Case _classLevelCodeVocationalSchoolGuid.ToString()
                    _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).Required = True
                    _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).Enabled = True
                    'clear out any entry in Other field:
                    _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).ValueObject = Nothing

                    ' apprenticeship: course of study is required
                Case _classLevelCodeApprenticeGuid.ToString()
                    _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).Required = True
                    _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).Enabled = True
                    'clear out any entry in Other field:
                    _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).ValueObject = Nothing

                Case Else
                    _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).Required = False
                    _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).Enabled = False
                    _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).ValueObject = Nothing
                    _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).Required = False
                    _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).Enabled = False
                    _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).ValueObject = Nothing
            End Select
        Else
            _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).Required = False
            _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).Enabled = False
            _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELOTHER.ToString()).ValueObject = Nothing
            _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).Required = False
            _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).Enabled = False
            _model.Fields(DepartureFieldNames.COURSEOFSTUDY.ToString()).ValueObject = Nothing

        End If
    End Sub

    Private Function DepartureReasonsExist() As Boolean
        'this method checks all the departure reason fields and returns if at least one has a value:
        Dim exists As Boolean = False
        If _model.Fields(DepartureFieldNames.DEPARTURE_DEATHOFCHILD.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_DEATHOFCHILD.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_EMPLOYED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_EMPLOYED.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_FAILED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_FAILED.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_FAMILYMOVED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_FAMILYMOVED.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_FAMILYNOWPROVIDES.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_FAMILYNOWPROVIDES.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_ILLNESS.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_ILLNESS.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_LACKOFINTEREST.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_LACKOFINTEREST.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_LIVESWITHRELATIVES.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_LIVESWITHRELATIVES.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_MARRIED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_MARRIED.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_NEEDEDATHOME.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_NEEDEDATHOME.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If Not String.IsNullOrEmpty(_model.Fields(DepartureFieldNames.DEPARTURE_OTHER.ToString()).ValueObject) Then
            exists = True
            Return exists
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_PREGNANCY.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_PREGNANCY.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_PROJECTTOOFAR.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_PROJECTTOOFAR.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_REMOVEDBYPARENTS.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_REMOVEDBYPARENTS.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        If _model.Fields(DepartureFieldNames.DEPARTURE_TRANSFERRED.ToString()).HasValue Then
            If CBool(_model.Fields(DepartureFieldNames.DEPARTURE_TRANSFERRED.ToString()).ValueObject) = True Then
                exists = True
                Return exists
            End If
        End If

        Return exists
    End Function

    Private Sub EmptyField(ByRef uIField As UIField)
        uIField.ValueObject = Nothing
    End Sub

    Private Sub SetupEventHandlers(ByRef model As RootUIModel)
        'add the field handler events as necessary here
        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()).ValueChanged, AddressOf AdministrativeCodeID_ValueChanged
        End If

        If model.Fields.Contains(DepartureFieldNames.DEPARTURETYPECODE.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURETYPECODE.ToString()).ValueChanged, AddressOf DepartureTypeCode_ValueChanged
        End If


        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_DEATHOFCHILD.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_DEATHOFCHILD.ToString()).ValueChanged, AddressOf DepartureDeathOfChild_ValueChanged
        End If

        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_EMPLOYED.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_EMPLOYED.ToString()).ValueChanged, AddressOf DepartureEmployed_ValueChanged
        End If

        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_FAILED.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_FAILED.ToString()).ValueChanged, AddressOf DepartureFailed_ValueChanged
        End If

        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_FAMILYMOVED.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_FAMILYMOVED.ToString()).ValueChanged, AddressOf DepartureFamilyMoved_ValueChanged
        End If

        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_FAMILYNOWPROVIDES.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_FAMILYNOWPROVIDES.ToString()).ValueChanged, AddressOf DepartureFamilyNowProvides_ValueChanged
        End If

        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_ILLNESS.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_ILLNESS.ToString()).ValueChanged, AddressOf DepartureIllness_ValueChanged
        End If

        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_LACKOFINTEREST.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_LACKOFINTEREST.ToString()).ValueChanged, AddressOf DepartureLackOfInterest_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_LIVESWITHRELATIVES.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_LIVESWITHRELATIVES.ToString()).ValueChanged, AddressOf DepartureLivesWithRelatives_ValueChanged
        End If

        ''since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_MARRIED.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_MARRIED.ToString()).ValueChanged, AddressOf DepartureMarried_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_NEEDEDATHOME.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_NEEDEDATHOME.ToString()).ValueChanged, AddressOf DepartureNeededAtHome_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_OTHER.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_OTHER.ToString()).ValueChanged, AddressOf DepartureOther_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_PREGNANCY.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_PREGNANCY.ToString()).ValueChanged, AddressOf DeparturePregnancy_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_PROJECTTOOFAR.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_PROJECTTOOFAR.ToString()).ValueChanged, AddressOf DepartureProjectTooFar_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_REMOVEDBYPARENTS.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_REMOVEDBYPARENTS.ToString()).ValueChanged, AddressOf DepartureRemovedByParents_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.DEPARTURE_TRANSFERRED.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.DEPARTURE_TRANSFERRED.ToString()).ValueChanged, AddressOf DepartureTransferred_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).ValueChanged, AddressOf IsProgramCompletion_ValueChanged
        End If

        'since this helper is shared with the other forms, check for the field first:
        If model.Fields.Contains(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()) Then
            AddHandler model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()).ValueChanged, AddressOf HighestClassLevelCodeID_ValueChanged
        End If


        AddHandler model.Validating, AddressOf DepartureFormUIModel_Validating
    End Sub

    Public Sub TurnOffDepartureFields(ByVal model As RootUIModel)
        TurnOnOffDepartureFields(False)
    End Sub

    Public Sub TurnOffProgramCompletionFields(ByVal model As RootUIModel)
        TurnOnOffProgramCompletionFields(False)
    End Sub

    Private Sub DepartureTypeCode_ValueChanged(ByVal sender As Object, ByVal e As ValueChangedEventArgs)
        ' this is an enum type field and 0 = departure
        'when you call the .ToString() on an Enum type, it gives you the string/text of the field:
        Select Case e.NewValue.ToString().ToLower()
            Case DepartureFieldNames.DepartureType.Departure.ToString().ToLower() ' "departure"
                _isDeparture = True
                _isProgramCompletion = False
                _isAdminOverride = False
                TurnOnOffDepartureFields(True)
                TurnOnOffProgramCompletionFields(False)
                'turn off admin field:
                SetAdminField(False)
                SetAdministrativeDeparture(True)


            Case DepartureFieldNames.DepartureType.Completion.ToString().ToLower() '"completion"
                _isProgramCompletion = True
                _isDeparture = False
                _isAdminOverride = False
                If _model.Fields.Contains(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()) Then
                    _model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).ValueObject = True
                End If
                TurnOnOffProgramCompletionFields(True)
                TurnOnOffDepartureFields(False)
                'turn off admin field:
                SetAdminField(False)
                SetAdministrativeDeparture(True)

            Case DepartureFieldNames.DepartureType.Administrative.ToString().ToLower() ' "administrative"
                'make the admin explanation required
                _isAdminOverride = True
                _isDeparture = False
                _isProgramCompletion = False
                'turn on admin field:
                SetAdminField(True)
                'passing False will turn off all required fields since this is an admin departure
                SetAdministrativeDeparture(False)
                TurnOnOffProgramCompletionFields(False)
                TurnOnOffDepartureFields(False)

                'who knows?
            Case Else

        End Select

    End Sub

    Private Sub TurnOnOffProgramCompletionFields(ByVal enabled As Boolean)
        '_model.Fields(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()).Enabled = enabled
        '_model.Fields(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()).Enabled = enabled
        '_model.Fields(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()).Enabled = enabled

        Dim genericList As List(Of UIField) = _model.Fields.ToList()
        Dim fieldsList = (From f In genericList Where f.Name.Contains(DepartureFieldNames.ISPROGRAMCOMPLETION.ToString()) _
                          Or f.Name.Contains(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()) _
                          Or f.Name.Contains(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString())
                          Select f)
        For Each field As UIField In fieldsList
            'we don't want to turn off the tab itself!
            If Not field.Name.Equals("DEPARTURE_REASONS_TAB") Then
                field.Enabled = enabled
                If enabled = False Then
                    field.ValueObject = Nothing
                    field.Required = enabled
                End If
            End If
        Next
    End Sub

    Private Sub TurnOnOffDepartureFields(ByVal enabled As Boolean)
        Dim genericList As List(Of UIField) = _model.Fields.ToList()
        Dim fieldsList = (From f In genericList Where f.Name.Contains("DEPARTURE_") _
                          Or f.Name.Contains(DepartureFieldNames.DETAILEDEXPLANATION.ToString()) _
                          Or f.Name.Contains(DepartureFieldNames.DEPARTURENEWSITUATION.ToString())
                          Select f)
        For Each field As UIField In fieldsList
            'we don't want to turn off the tab itself!
            If Not field.Name.Equals("DEPARTURE_REASONS_TAB") Then
                field.Enabled = enabled
                If enabled = False Then
                    field.ValueObject = Nothing
                    field.Required = enabled
                End If
            End If
        Next

        If enabled Then
            If _model.Fields.Contains(DepartureFieldNames.DETAILEDEXPLANATION.ToString()) Then
                _model.Fields(DepartureFieldNames.DETAILEDEXPLANATION.ToString()).Required = enabled
            End If
        End If
    End Sub

    Private Sub SetAdministrativeDeparture(ByVal isOn As Boolean)

        'turns on or off [depends on param] all the required fields except for what's in general information, including all tabs:
        'If _model.Fields.Contains(DepartureFieldNames.DEPARTURETYPECODE.ToString()) Then
        '    _model.Fields(DepartureFieldNames.DEPARTURETYPECODE.ToString()).Required = isOn
        'End If

        If _model.Fields.Contains(DepartureFieldNames.CHILDCHRISTIANEXPERIENCE.ToString()) Then
            _model.Fields(DepartureFieldNames.CHILDCHRISTIANEXPERIENCE.ToString()).Required = isOn
        End If

        If _model.Fields.Contains(DepartureFieldNames.HEALTHCONDITIONS.ToString()) Then
            _model.Fields(DepartureFieldNames.HEALTHCONDITIONS.ToString()).Required = isOn
        End If

        If _model.Fields.Contains(DepartureFieldNames.CHILDMATUREDCODE.ToString()) Then
            _model.Fields(DepartureFieldNames.CHILDMATUREDCODE.ToString()).Required = isOn
        End If

        If _model.Fields.Contains(DepartureFieldNames.LEVELOFMATURITY.ToString()) Then
            _model.Fields(DepartureFieldNames.LEVELOFMATURITY.ToString()).Required = isOn
        End If

        If _model.Fields.Contains(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()) Then
            _model.Fields(DepartureFieldNames.HIGHESTCLASSLEVELCODEID.ToString()).Required = isOn
        End If

        If _model.Fields.Contains(DepartureFieldNames.GENERALCOMMENTS.ToString()) Then
            _model.Fields(DepartureFieldNames.GENERALCOMMENTS.ToString()).Required = isOn
        End If

        If _model.Fields.Contains(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()) Then
            _model.Fields(DepartureFieldNames.PROGRAMCOMPLETIONNEWSITUATION.ToString()).Required = _isProgramCompletion 'isOn
        End If

        'If _model.Fields.Contains(DepartureFieldNames.DETAILEDEXPLANATION.ToString()) Then
        '    _model.Fields(DepartureFieldNames.DETAILEDEXPLANATION.ToString()).Required = isOn
        'End If


        'turn off the tabs so user can't get to the underlying fields:
        Dim genericList As List(Of UIField) = _model.Fields.ToList()
        Dim fieldsList = (From f In genericList Where f.Name.Contains("TAB") _
                          Or f.Name.Contains(DepartureFieldNames.DETAILEDEXPLANATION.ToString()) _
                          Or f.Name.Contains(DepartureFieldNames.DEPARTURENEWSITUATION.ToString())
                          Select f)
        For Each field As UIField In fieldsList
            'we don't want to turn off the tab itself!
            field.Enabled = isOn
        Next

    End Sub

    Private Sub SetAdminField(ByVal setValue As Boolean)
        If _model.Fields.Contains(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()) Then
            _model.Fields(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()).Enabled = setValue
            _model.Fields(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()).Required = setValue
            If Not setValue Then
                _model.Fields(DepartureFieldNames.ADMINISTRATIVECODEID.ToString()).ValueObject = Nothing
            End If
        End If
        If _model.Fields.Contains(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()) Then
            _model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).Required = setValue
            _model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).Enabled = setValue
            If Not setValue Then
                _model.Fields(DepartureFieldNames.ADMINISTRATIVEEXPLANATION.ToString()).ValueObject = Nothing
            End If
        End If
    End Sub


End Class

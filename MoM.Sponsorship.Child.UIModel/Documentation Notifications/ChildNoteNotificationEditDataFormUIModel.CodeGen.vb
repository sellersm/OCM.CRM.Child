﻿Option Strict On
Option Explicit On
Option Infer On

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by BBUIModelLibrary
'     Version:  4.0.170.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
''' <summary>
''' Represents the UI model for the 'Child Note Notification Edit Data Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit, "4d5bd7a9-e1ea-4843-941e-c796713804fe", "bdc2e76e-5b37-49d7-8aef-6b1703d56102", "Child Note Notification", "CRMEditNotification.html")>
Partial Public Class [ChildNoteNotificationEditDataFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Enums"

    ''' <summary>
    ''' Enumerated values for use with the APPLYTOCODE property
    ''' </summary>
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public Enum APPLYTOCODES As Integer
        [AllUsers] = 0
        [SelectedUsers] = 1
    End Enum

#End Region

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _displaynotificationwindow As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _validuntil As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _appuserrecordtypeid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _appuseridsetregisterid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of System.Guid)
    Private WithEvents _applytocode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of APPLYTOCODES)
    Private WithEvents _notificationusers As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
    Private WithEvents _editselection As Global.Blackbaud.AppFx.UIModeling.Core.ShowQueryFormUIAction

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public Sub New()
        MyBase.New()

        _displaynotificationwindow = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _validuntil = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _appuserrecordtypeid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _appuseridsetregisterid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of System.Guid)
        _applytocode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of APPLYTOCODES)
        _notificationusers = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        _editselection = New Global.Blackbaud.AppFx.UIModeling.Core.ShowQueryFormUIAction

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit
        MyBase.DataFormTemplateId = New System.Guid("4d5bd7a9-e1ea-4843-941e-c796713804fe")
        MyBase.DataFormInstanceId = New System.Guid("bdc2e76e-5b37-49d7-8aef-6b1703d56102")
        MyBase.RecordType = "Child Note Notification"
        MyBase.HelpKey = "CRMEditNotification.html"
        MyBase.FixedDialog = True
        MyBase.FORMHEADER.Value = "Edit a child note notification"
        MyBase.UserInterfaceUrl = "browser/htmlforms/custom/ChildNoteNotificationEditDataForm.html"

        '
        '_displaynotificationwindow
        '
        _displaynotificationwindow.Name = "DISPLAYNOTIFICATIONWINDOW"
        _displaynotificationwindow.Caption = "Display in notification window"
        Me.Fields.Add(_displaynotificationwindow)
        '
        '_validuntil
        '
        _validuntil.Name = "VALIDUNTIL"
        _validuntil.Caption = "End date"
        Me.Fields.Add(_validuntil)
        '
        '_appuserrecordtypeid
        '
        _appuserrecordtypeid.Name = "APPUSERRECORDTYPEID"
        _appuserrecordtypeid.Caption = "APPUSERRECORDTYPEID"
        _appuserrecordtypeid.Visible = False
        _appuserrecordtypeid.DBReadOnly = True
        Me.Fields.Add(_appuserrecordtypeid)
        '
        '_appuseridsetregisterid
        '
        _appuseridsetregisterid.Name = "APPUSERIDSETREGISTERID"
        _appuseridsetregisterid.Caption = "Selection"
        _appuseridsetregisterid.SearchListId = New System.Guid("98d0070e-c4a7-495b-a438-2ac12da79068")
        _appuseridsetregisterid.EnableQuickFind = True
        _appuseridsetregisterid.SearchFieldOverrides.Add(New Global.Blackbaud.AppFx.UIModeling.Core.FieldOverride() With {.FieldId = "RECORDTYPEID", .Caption = "Record type", .ReadOnly = True, .DefaultValueText = "Fields!APPUSERRECORDTYPEID"})
        _appuseridsetregisterid.SystemSearchType = Global.Blackbaud.AppFx.UIModeling.Core.SystemSearchType.Selection
        Me.Fields.Add(_appuseridsetregisterid)
        '
        '_applytocode
        '
        _applytocode.Name = "APPLYTOCODE"
        _applytocode.Caption = "Displays for"
        _applytocode.Required = True
        _applytocode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of APPLYTOCODES) With {.Value = APPLYTOCODES.[AllUsers], .Translation = "All users"})
        _applytocode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of APPLYTOCODES) With {.Value = APPLYTOCODES.[SelectedUsers], .Translation = "Selected users"})
        Me.Fields.Add(_applytocode)
        '
        '_notificationusers
        '
        _notificationusers.Name = "NOTIFICATIONUSERS"
        _notificationusers.Caption = "Notification users"
        _notificationusers.Fields.Add("APPLYTOCODE")
        _notificationusers.Fields.Add("APPUSERIDSETREGISTERID")
        Me.Fields.Add(_notificationusers)
        '
        '_editselection
        '
        _editselection.Name = "EDITSELECTION"
        _editselection.Caption = ""
        _appuseridsetregisterid.LinkedActions.Add(_editselection)
        Me.Actions.Add(_editselection)

		OnCreated()

    End Sub
    
    ''' <summary>
    ''' Display in notification window
    ''' </summary>
    <System.ComponentModel.Description("Display in notification window")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [DISPLAYNOTIFICATIONWINDOW]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _displaynotificationwindow
        End Get
    End Property
    
    ''' <summary>
    ''' End date
    ''' </summary>
    <System.ComponentModel.Description("End date")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [VALIDUNTIL]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _validuntil
        End Get
    End Property
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")>
    Public ReadOnly Property [APPUSERRECORDTYPEID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _appuserrecordtypeid
        End Get
    End Property

    ''' <summary>
    ''' Selection
    ''' </summary>
    <System.ComponentModel.Description("Selection")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [APPUSERIDSETREGISTERID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of System.Guid)
        Get
            Return _appuseridsetregisterid
        End Get
    End Property
    
    ''' <summary>
    ''' Displays for
    ''' </summary>
    <System.ComponentModel.Description("Displays for")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [APPLYTOCODE]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of APPLYTOCODES)
        Get
            Return _applytocode
        End Get
    End Property
    
    ''' <summary>
    ''' Notification users
    ''' </summary>
    <System.ComponentModel.Description("Notification users")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [NOTIFICATIONUSERS]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _notificationusers
        End Get
    End Property
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [EDITSELECTION]() As Global.Blackbaud.AppFx.UIModeling.Core.ShowQueryFormUIAction
        Get
            Return _editselection
        End Get
    End Property
    
End Class

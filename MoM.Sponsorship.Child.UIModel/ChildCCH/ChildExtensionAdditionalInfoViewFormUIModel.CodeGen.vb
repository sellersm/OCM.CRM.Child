﻿Option Strict On
Option Explicit On
Option Infer On

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by BBUIModelLibrary
'     Version:  2.93.2034.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
''' <summary>
''' Represents the UI model for the 'ChildExtension Additional Info View Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.View, "ce8c4111-dffd-4f66-a285-054a2c08bcd6", "b9390174-f5b7-4a6a-b73b-9d5b9cb5b1c4", "Child Extension")> _
Partial Public Class [ChildExtensionAdditionalInfoViewFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _additionalchildinformation As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _batchnumber As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _cchenteredby As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _cchtempid As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _registrationdate As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _funded As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _childprofilestatuscodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _childprofileupdatecodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _profileupdatenotification As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _cchvalidated As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _departureformreceived As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _cchzipfilename As Global.Blackbaud.AppFx.UIModeling.Core.StringField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Sub New()
        MyBase.New()

        _additionalchildinformation = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _batchnumber = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _cchenteredby = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _cchtempid = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _registrationdate = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _funded = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _childprofilestatuscodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _childprofileupdatecodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _profileupdatenotification = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _cchvalidated = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _departureformreceived = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _cchzipfilename = New Global.Blackbaud.AppFx.UIModeling.Core.StringField

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.View
        MyBase.DataFormTemplateId = New Guid("ce8c4111-dffd-4f66-a285-054a2c08bcd6")
        MyBase.DataFormInstanceId = New Guid("b9390174-f5b7-4a6a-b73b-9d5b9cb5b1c4")
        MyBase.RecordType = "Child Extension"
        MyBase.FixedDialog = True
		MyBase.UserInterfaceUrl = "browser/htmlforms/custom/ChildExtensionAdditionalInfoViewForm.html"

        '
        '_additionalchildinformation
        '
        _additionalchildinformation.Name = "ADDITIONALCHILDINFORMATION"
        _additionalchildinformation.Caption = "Additional Child Information"
        _additionalchildinformation.DBReadOnly = True
        _additionalchildinformation.MultiLine = True
        Me.Fields.Add(_additionalchildinformation)
        '
        '_batchnumber
        '
        _batchnumber.Name = "BATCHNUMBER"
        _batchnumber.Caption = "Batch Number"
        _batchnumber.DBReadOnly = True
        _batchnumber.MaxLength = 50
        Me.Fields.Add(_batchnumber)
        '
        '_cchenteredby
        '
        _cchenteredby.Name = "CCHENTEREDBY"
        _cchenteredby.Caption = "CCH Entered By"
        _cchenteredby.DBReadOnly = True
        _cchenteredby.MaxLength = 100
        Me.Fields.Add(_cchenteredby)
        '
        '_cchtempid
        '
        _cchtempid.Name = "CCHTEMPID"
        _cchtempid.Caption = "CH CCH Temp ID"
        _cchtempid.DBReadOnly = True
        _cchtempid.MaxLength = 250
        Me.Fields.Add(_cchtempid)
        '
        '_registrationdate
        '
        _registrationdate.Name = "REGISTRATIONDATE"
        _registrationdate.Caption = "Registration Date"
        _registrationdate.DBReadOnly = True
        Me.Fields.Add(_registrationdate)
        '
        '_funded
        '
        _funded.Name = "FUNDED"
        _funded.Caption = "Funded"
        _funded.DBReadOnly = True
        Me.Fields.Add(_funded)
        '
        '_childprofilestatuscodeid
        '
        _childprofilestatuscodeid.Name = "CHILDPROFILESTATUSCODEID"
        _childprofilestatuscodeid.Caption = "Profile Status"
        _childprofilestatuscodeid.DBReadOnly = True
        _childprofilestatuscodeid.CodeTableName = "USR_CHILDPROFILESTATUSCODE"
        Me.Fields.Add(_childprofilestatuscodeid)
        '
        '_childprofileupdatecodeid
        '
        _childprofileupdatecodeid.Name = "CHILDPROFILEUPDATECODEID"
        _childprofileupdatecodeid.Caption = "Profile Update"
        _childprofileupdatecodeid.DBReadOnly = True
        _childprofileupdatecodeid.CodeTableName = "USR_CHILDPROFILEUPDATECODE"
        Me.Fields.Add(_childprofileupdatecodeid)
        '
        '_profileupdatenotification
        '
        _profileupdatenotification.Name = "PROFILEUPDATENOTIFICATION"
        _profileupdatenotification.Caption = "Profile Update Notification?"
        _profileupdatenotification.DBReadOnly = True
        Me.Fields.Add(_profileupdatenotification)
        '
        '_cchvalidated
        '
        _cchvalidated.Name = "CCHVALIDATED"
        _cchvalidated.Caption = "CCH Validated"
        _cchvalidated.DBReadOnly = True
        Me.Fields.Add(_cchvalidated)
        '
        '_departureformreceived
        '
        _departureformreceived.Name = "DEPARTUREFORMRECEIVED"
        _departureformreceived.Caption = "Departure form received"
        _departureformreceived.DBReadOnly = True
        Me.Fields.Add(_departureformreceived)
        '
        '_cchzipfilename
        '
        _cchzipfilename.Name = "CCHZIPFILENAME"
        _cchzipfilename.Caption = "CCH zip file name"
        _cchzipfilename.DBReadOnly = True
        _cchzipfilename.MaxLength = 200
        Me.Fields.Add(_cchzipfilename)

		OnCreated()

    End Sub
    
    ''' <summary>
    ''' Additional Child Information
    ''' </summary>
    <System.ComponentModel.Description("Additional Child Information")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [ADDITIONALCHILDINFORMATION]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _additionalchildinformation
        End Get
    End Property
    
    ''' <summary>
    ''' Batch Number
    ''' </summary>
    <System.ComponentModel.Description("Batch Number")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [BATCHNUMBER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _batchnumber
        End Get
    End Property
    
    ''' <summary>
    ''' CCH Entered By
    ''' </summary>
    <System.ComponentModel.Description("CCH Entered By")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CCHENTEREDBY]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _cchenteredby
        End Get
    End Property
    
    ''' <summary>
    ''' CH CCH Temp ID
    ''' </summary>
    <System.ComponentModel.Description("CH CCH Temp ID")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CCHTEMPID]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _cchtempid
        End Get
    End Property
    
    ''' <summary>
    ''' Registration Date
    ''' </summary>
    <System.ComponentModel.Description("Registration Date")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [REGISTRATIONDATE]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _registrationdate
        End Get
    End Property
    
    ''' <summary>
    ''' Funded
    ''' </summary>
    <System.ComponentModel.Description("Funded")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [FUNDED]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _funded
        End Get
    End Property
    
    ''' <summary>
    ''' Profile Status
    ''' </summary>
    <System.ComponentModel.Description("Profile Status")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CHILDPROFILESTATUSCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _childprofilestatuscodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Profile Update
    ''' </summary>
    <System.ComponentModel.Description("Profile Update")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CHILDPROFILEUPDATECODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _childprofileupdatecodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Profile Update Notification?
    ''' </summary>
    <System.ComponentModel.Description("Profile Update Notification?")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [PROFILEUPDATENOTIFICATION]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _profileupdatenotification
        End Get
    End Property
    
    ''' <summary>
    ''' CCH Validated
    ''' </summary>
    <System.ComponentModel.Description("CCH Validated")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CCHVALIDATED]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _cchvalidated
        End Get
    End Property
    
    ''' <summary>
    ''' Departure form received
    ''' </summary>
    <System.ComponentModel.Description("Departure form received")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [DEPARTUREFORMRECEIVED]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _departureformreceived
        End Get
    End Property
    
    ''' <summary>
    ''' CCH zip file name
    ''' </summary>
    <System.ComponentModel.Description("CCH zip file name")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CCHZIPFILENAME]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _cchzipfilename
        End Get
    End Property
    
End Class

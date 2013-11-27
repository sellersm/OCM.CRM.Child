﻿Option Strict On
Option Explicit On
Option Infer On

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by BBUIModelLibrary
'     Version:  2.91.1535.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
''' <summary>
''' Represents the UI model for the 'ChildExtension Who I Live With Edit Data Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit, "d76de202-0aa6-4393-aae5-6eccdeb824ba", "eea105ac-bc35-40e5-b8ef-91126478848d", "Child Extension")> _
Partial Public Class [ChildExtensionWhoILiveWithEditDataFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _childliveswithcodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _fatherworksascodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _fatherworksasother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _motherworksascodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _motherworksasother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _caregiverrelationcodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _caregiverrelationother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _caregiverworksascodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _caregiverworksasother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _caregiverreasoncodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _reasonforcaregiverother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _numberofsisters As Global.Blackbaud.AppFx.UIModeling.Core.TinyIntField
    Private WithEvents _numberofbrothers As Global.Blackbaud.AppFx.UIModeling.Core.TinyIntField
    Private WithEvents _sponsorshipopportunitychildid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _parentalinformationgroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
    Private WithEvents _caregiverinformationgroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
    Private WithEvents _siblinginformationgroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public Sub New()
        MyBase.New()

        _childliveswithcodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _fatherworksascodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _fatherworksasother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _motherworksascodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _motherworksasother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _caregiverrelationcodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _caregiverrelationother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _caregiverworksascodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _caregiverworksasother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _caregiverreasoncodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _reasonforcaregiverother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _numberofsisters = New Global.Blackbaud.AppFx.UIModeling.Core.TinyIntField
        _numberofbrothers = New Global.Blackbaud.AppFx.UIModeling.Core.TinyIntField
        _sponsorshipopportunitychildid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _parentalinformationgroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        _caregiverinformationgroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        _siblinginformationgroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit
        MyBase.DataFormTemplateId = New Guid("d76de202-0aa6-4393-aae5-6eccdeb824ba")
        MyBase.DataFormInstanceId = New Guid("eea105ac-bc35-40e5-b8ef-91126478848d")
        MyBase.RecordType = "Child Extension"
        MyBase.FixedDialog = True
        MyBase.UserInterfaceUrl = "browser/htmlforms/custom/ChildExtensionWhoILiveWithEditDataForm.html"

        '
        '_childliveswithcodeid
        '
        _childliveswithcodeid.Name = "CHILDLIVESWITHCODEID"
        _childliveswithcodeid.Caption = "Child Lives With"
        _childliveswithcodeid.CodeTableName = "USR_CHILDLIVESWITHCODE"
        Me.Fields.Add(_childliveswithcodeid)
        '
        '_fatherworksascodeid
        '
        _fatherworksascodeid.Name = "FATHERWORKSASCODEID"
        _fatherworksascodeid.Caption = "Father Works As"
        _fatherworksascodeid.CodeTableName = "USR_FATHERWORKSASCODE"
        Me.Fields.Add(_fatherworksascodeid)
        '
        '_fatherworksasother
        '
        _fatherworksasother.Name = "FATHERWORKSASOTHER"
        _fatherworksasother.Caption = "Details/Other"
		_fatherworksasother.MaxLength = 100
        Me.Fields.Add(_fatherworksasother)
        '
        '_motherworksascodeid
        '
        _motherworksascodeid.Name = "MOTHERWORKSASCODEID"
        _motherworksascodeid.Caption = "Mother Works As"
        _motherworksascodeid.CodeTableName = "USR_MOTHERWORKSASCODE"
        Me.Fields.Add(_motherworksascodeid)
        '
        '_motherworksasother
        '
        _motherworksasother.Name = "MOTHERWORKSASOTHER"
        _motherworksasother.Caption = "Details/Other"
		_motherworksasother.MaxLength = 100
        Me.Fields.Add(_motherworksasother)
        '
        '_caregiverrelationcodeid
        '
        _caregiverrelationcodeid.Name = "CAREGIVERRELATIONCODEID"
        _caregiverrelationcodeid.Caption = "Caregiver Relation"
        _caregiverrelationcodeid.CodeTableName = "USR_CAREGIVERRELATIONCODE"
        Me.Fields.Add(_caregiverrelationcodeid)
        '
        '_caregiverrelationother
        '
        _caregiverrelationother.Name = "CAREGIVERRELATIONOTHER"
        _caregiverrelationother.Caption = "Details/Other"
        _caregiverrelationother.MaxLength = 50
        Me.Fields.Add(_caregiverrelationother)
        '
        '_caregiverworksascodeid
        '
        _caregiverworksascodeid.Name = "CAREGIVERWORKSASCODEID"
        _caregiverworksascodeid.Caption = "Caregiver Works As"
        _caregiverworksascodeid.CodeTableName = "USR_CAREGIVERWORKSASCODE"
        Me.Fields.Add(_caregiverworksascodeid)
        '
        '_caregiverworksasother
        '
        _caregiverworksasother.Name = "CAREGIVERWORKSASOTHER"
        _caregiverworksasother.Caption = "Details/Other"
		_caregiverworksasother.MaxLength = 100
        Me.Fields.Add(_caregiverworksasother)
        '
        '_caregiverreasoncodeid
        '
        _caregiverreasoncodeid.Name = "CAREGIVERREASONCODEID"
        _caregiverreasoncodeid.Caption = "Reason for Caregiver"
        _caregiverreasoncodeid.CodeTableName = "USR_CAREGIVERREASONCODE"
        Me.Fields.Add(_caregiverreasoncodeid)
        '
        '_reasonforcaregiverother
        '
        _reasonforcaregiverother.Name = "REASONFORCAREGIVEROTHER"
        _reasonforcaregiverother.Caption = "Details/Other"
        _reasonforcaregiverother.MaxLength = 50
        Me.Fields.Add(_reasonforcaregiverother)
        '
        '_numberofsisters
        '
        _numberofsisters.Name = "NUMBEROFSISTERS"
        _numberofsisters.Caption = "Number of Sisters"
        Me.Fields.Add(_numberofsisters)
        '
        '_numberofbrothers
        '
        _numberofbrothers.Name = "NUMBEROFBROTHERS"
        _numberofbrothers.Caption = "Number of Brothers"
        Me.Fields.Add(_numberofbrothers)
        '
        '_sponsorshipopportunitychildid
        '
        _sponsorshipopportunitychildid.Name = "SPONSORSHIPOPPORTUNITYCHILDID"
        _sponsorshipopportunitychildid.Caption = "SPONSORSHIPOPPORTUNITYCHILDID"
        _sponsorshipopportunitychildid.Visible = False
        _sponsorshipopportunitychildid.DBReadOnly = True
        Me.Fields.Add(_sponsorshipopportunitychildid)
        '
        '_parentalinformationgroup
        '
        _parentalinformationgroup.Name = "PARENTALINFORMATION_GROUP"
        _parentalinformationgroup.Caption = "Parental Information"
        _parentalinformationgroup.Fields.Add("CHILDLIVESWITHCODEID")
        _parentalinformationgroup.Fields.Add("FATHERWORKSASCODEID")
        _parentalinformationgroup.Fields.Add("MOTHERWORKSASCODEID")
        _parentalinformationgroup.Fields.Add("FATHERWORKSASOTHER")
        _parentalinformationgroup.Fields.Add("MOTHERWORKSASOTHER")
        Me.Fields.Add(_parentalinformationgroup)
        '
        '_caregiverinformationgroup
        '
        _caregiverinformationgroup.Name = "CAREGIVERINFORMATION_GROUP"
        _caregiverinformationgroup.Caption = "Caregiver Information"
        _caregiverinformationgroup.Fields.Add("CAREGIVERRELATIONCODEID")
        _caregiverinformationgroup.Fields.Add("CAREGIVERWORKSASCODEID")
        _caregiverinformationgroup.Fields.Add("CAREGIVERREASONCODEID")
        _caregiverinformationgroup.Fields.Add("CAREGIVERRELATIONOTHER")
        _caregiverinformationgroup.Fields.Add("CAREGIVERWORKSASOTHER")
        _caregiverinformationgroup.Fields.Add("REASONFORCAREGIVEROTHER")
        Me.Fields.Add(_caregiverinformationgroup)
        '
        '_siblinginformationgroup
        '
        _siblinginformationgroup.Name = "SIBLING_INFORMATION_GROUP"
        _siblinginformationgroup.Caption = "Sibling Information"
        _siblinginformationgroup.Fields.Add("NUMBEROFSISTERS")
        _siblinginformationgroup.Fields.Add("NUMBEROFBROTHERS")
        Me.Fields.Add(_siblinginformationgroup)

		OnCreated()

    End Sub
    
    ''' <summary>
    ''' Child Lives With
    ''' </summary>
    <System.ComponentModel.Description("Child Lives With")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CHILDLIVESWITHCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _childliveswithcodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Father Works As
    ''' </summary>
    <System.ComponentModel.Description("Father Works As")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [FATHERWORKSASCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _fatherworksascodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Father Works As other value
    ''' </summary>
    <System.ComponentModel.Description("Details/Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [FATHERWORKSASOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _fatherworksasother
        End Get
    End Property
    
    ''' <summary>
    ''' Mother Works As
    ''' </summary>
    <System.ComponentModel.Description("Mother Works As")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [MOTHERWORKSASCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _motherworksascodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Mother Works As other value
    ''' </summary>
    <System.ComponentModel.Description("Details/Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [MOTHERWORKSASOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _motherworksasother
        End Get
    End Property
    
    ''' <summary>
    ''' Caregiver Relation
    ''' </summary>
    <System.ComponentModel.Description("Caregiver Relation")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CAREGIVERRELATIONCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _caregiverrelationcodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Caregiver Relation other value
    ''' </summary>
    <System.ComponentModel.Description("Details/Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CAREGIVERRELATIONOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _caregiverrelationother
        End Get
    End Property
    
    ''' <summary>
    ''' Caregiver Works As
    ''' </summary>
    <System.ComponentModel.Description("Caregiver Works As")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CAREGIVERWORKSASCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _caregiverworksascodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Caregiver Works As other value
    ''' </summary>
    <System.ComponentModel.Description("Details/Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CAREGIVERWORKSASOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _caregiverworksasother
        End Get
    End Property
    
    ''' <summary>
    ''' Reason for Caregiver
    ''' </summary>
    <System.ComponentModel.Description("Reason for Caregiver")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CAREGIVERREASONCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _caregiverreasoncodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Caregiver Reason other value
    ''' </summary>
    <System.ComponentModel.Description("Details/Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [REASONFORCAREGIVEROTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _reasonforcaregiverother
        End Get
    End Property
    
    ''' <summary>
    ''' Number of Sisters
    ''' </summary>
    <System.ComponentModel.Description("Number of Sisters")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [NUMBEROFSISTERS]() As Global.Blackbaud.AppFx.UIModeling.Core.TinyIntField
        Get
            Return _numberofsisters
        End Get
    End Property
    
    ''' <summary>
    ''' Number of Brothers
    ''' </summary>
    <System.ComponentModel.Description("Number of Brothers")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [NUMBEROFBROTHERS]() As Global.Blackbaud.AppFx.UIModeling.Core.TinyIntField
        Get
            Return _numberofbrothers
        End Get
    End Property
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [SPONSORSHIPOPPORTUNITYCHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _sponsorshipopportunitychildid
        End Get
    End Property
    
    ''' <summary>
    ''' Parental Information
    ''' </summary>
    <System.ComponentModel.Description("Parental Information")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [PARENTALINFORMATION_GROUP]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _parentalinformationgroup
        End Get
    End Property
    
    ''' <summary>
    ''' Caregiver Information
    ''' </summary>
    <System.ComponentModel.Description("Caregiver Information")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CAREGIVERINFORMATION_GROUP]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _caregiverinformationgroup
        End Get
    End Property
    
    ''' <summary>
    ''' Sibling Information
    ''' </summary>
    <System.ComponentModel.Description("Sibling Information")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [SIBLING_INFORMATION_GROUP]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _siblinginformationgroup
        End Get
    End Property
    
End Class

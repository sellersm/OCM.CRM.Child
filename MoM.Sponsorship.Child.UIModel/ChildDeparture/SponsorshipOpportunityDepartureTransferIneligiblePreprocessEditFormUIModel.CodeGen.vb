﻿Option Strict On
Option Explicit On
Option Infer On

' This was copied from the OOB SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModel partial class
' The only change made was to disable _sposnsrshipreasonid 

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by BBUIModelLibrary
'     Version:  1.0.0.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
''' <summary>
''' Represents the UI model for the 'Sponsorship Opportunity Ineligible Preprocess Edit Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit, "3391c731-c111-4f52-8a12-21d2c9da3dd5", "366ec3c1-a3b7-4492-8f7d-a127860912be", "Sponsorship opportunity", "SPChildMarkIneligible.html")> _
Partial Public Class [SponsorshipOpportunityChildIneligiblePreprocessEditFormUIModelDepartureTransfer]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Enums"

	''' <summary>
	''' Enumerated values for use with the OUTPUTIDSETTYPECODE property
	''' </summary>
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public Enum OUTPUTIDSETTYPECODES As Integer
		[TransferredSourceSponsorships] = 0
		[TransferredTargetSponsorships] = 1
	End Enum

	''' <summary>
	''' Enumerated values for use with the CHOOSINGCHILD property
	''' </summary>
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public Enum CHOOSINGCHILDS As Integer
		[MatchingChild] = 0
		[SpecificChild] = 1
	End Enum

#End Region

#Region "Extensibility methods"

	Partial Private Sub OnCreated()
	End Sub

#End Region

	Private WithEvents _newsponsorshipopportunityid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
	Private WithEvents _sponsorshipreasonid As Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
	Private WithEvents _childsponsorships As Global.Blackbaud.AppFx.UIModeling.Core.IntegerField
	Private WithEvents _groupid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
	Private WithEvents _createoutputidset As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
	Private WithEvents _outputidsettypecode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of OUTPUTIDSETTYPECODES)
	Private WithEvents _outputidsetname As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _overwriteoutputidset As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
	Private WithEvents _choosingchild As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of CHOOSINGCHILDS))
	Private WithEvents _transfermsg As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _reason As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
	Private WithEvents _transfer As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
	Private WithEvents _results As Global.Blackbaud.AppFx.UIModeling.Core.GroupField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public Sub New()
		MyBase.New()

		_newsponsorshipopportunityid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_sponsorshipreasonid = New Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
		_childsponsorships = New Global.Blackbaud.AppFx.UIModeling.Core.IntegerField
		_groupid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
		_createoutputidset = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		_outputidsettypecode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of OUTPUTIDSETTYPECODES)
		_outputidsetname = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_overwriteoutputidset = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		_choosingchild = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of CHOOSINGCHILDS))
		_transfermsg = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_reason = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
		_transfer = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
		_results = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField

		MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit
		MyBase.DataFormTemplateId = New Guid("3391c731-c111-4f52-8a12-21d2c9da3dd5")
		MyBase.DataFormInstanceId = New Guid("366ec3c1-a3b7-4492-8f7d-a127860912be")
		MyBase.RecordType = "Sponsorship opportunity"
		MyBase.HelpKey = "SPChildMarkIneligible.html"
		MyBase.FixedDialog = True
		MyBase.FORMHEADER.Value = "Departure Transfer" '** CHANGED ** from "Mark child ineligible"
		MyBase.UserInterfaceUrl = "browser\htmlforms\sponsorship\SponsorshipOpportunityIneligiblePreprocessEditForm.html"

		'
		'_newsponsorshipopportunityid
		'
		_newsponsorshipopportunityid.Name = "NEWSPONSORSHIPOPPORTUNITYID"
		_newsponsorshipopportunityid.Caption = " New child"
		_newsponsorshipopportunityid.SearchListId = New Guid("ab076868-114a-4696-afe9-8d590677708c")
		_newsponsorshipopportunityid.EnableQuickFind = True
		_newsponsorshipopportunityid.SearchFieldOverrides.Add(New Global.Blackbaud.AppFx.UIModeling.Core.FieldOverride() With {.FieldId = "SPONSORSHIPPROGRAMID", .ReadOnly = True})
		_newsponsorshipopportunityid.SearchFieldOverrides.Add(New Global.Blackbaud.AppFx.UIModeling.Core.FieldOverride() With {.FieldId = "ELIGIBILITYCODE", .ReadOnly = True, .DefaultValueText = "1"})
		_newsponsorshipopportunityid.SearchFieldOverrides.Add(New Global.Blackbaud.AppFx.UIModeling.Core.FieldOverride() With {.FieldId = "AVAILABILITYCODE", .ReadOnly = True, .DefaultValueText = "0"})
		_newsponsorshipopportunityid.SearchFieldOverrides.Add(New Global.Blackbaud.AppFx.UIModeling.Core.FieldOverride() With {.FieldId = "RESTRICTFORSOLESPONSORSHIP", .Caption = "Only include unsponsored", .ReadOnly = True, .DefaultValueText = "Fields!ISSOLESPONSORSHIP"})
		_newsponsorshipopportunityid.SearchFieldOverrides.Add(New Global.Blackbaud.AppFx.UIModeling.Core.FieldOverride() With {.FieldId = "SPONSORSHIPOPPORTUNITYGROUPID", .ReadOnly = True, .DefaultValueText = "Fields!GROUPID"})
		_newsponsorshipopportunityid.SearchFieldOverrides.Add(New Global.Blackbaud.AppFx.UIModeling.Core.FieldOverride() With {.FieldId = "EXCLUDEOPPORTUNITYID", .Hidden = True, .ReadOnly = True, .DefaultValueText = "Fields!OLDSPONSORSHIPOPPORTUNITYID"})
		Me.Fields.Add(_newsponsorshipopportunityid)
		'
		'_sponsorshipreasonid
		'
		_sponsorshipreasonid.Name = "SPONSORSHIPREASONID"
		_sponsorshipreasonid.Caption = "Reason"
		_sponsorshipreasonid.Required = True
		_sponsorshipreasonid.SimpleDataListId = New Guid("c8d3128e-a2eb-4413-b0b4-1585ad5bf001")
		_sponsorshipreasonid.Parameters.Add(New Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListParameter("TYPE", "1"))
		_sponsorshipreasonid.Enabled = False
		Me.Fields.Add(_sponsorshipreasonid)
		'
		'_childsponsorships
		'
		_childsponsorships.Name = "CHILDSPONSORSHIPS"
		_childsponsorships.Caption = "CHILDSPONSORSHIPS"
		_childsponsorships.Visible = False
		Me.Fields.Add(_childsponsorships)
		'
		'_groupid
		'
		_groupid.Name = "GROUPID"
		_groupid.Caption = "GROUPID"
		_groupid.Visible = False
		Me.Fields.Add(_groupid)
		'
		'_createoutputidset
		'
		_createoutputidset.Name = "CREATEOUTPUTIDSET"
		_createoutputidset.Caption = "Create selection of"
		Me.Fields.Add(_createoutputidset)
		'
		'_outputidsettypecode
		'
		_outputidsettypecode.Name = "OUTPUTIDSETTYPECODE"
		_outputidsettypecode.Caption = "OUTPUTIDSETTYPECODE"
		_outputidsettypecode.Required = True
		_outputidsettypecode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of OUTPUTIDSETTYPECODES) With {.Value = OUTPUTIDSETTYPECODES.[TransferredSourceSponsorships], .Translation = "Transferred source sponsorships"})
		_outputidsettypecode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of OUTPUTIDSETTYPECODES) With {.Value = OUTPUTIDSETTYPECODES.[TransferredTargetSponsorships], .Translation = "Transferred target sponsorships"})
		_outputidsettypecode.Value = OUTPUTIDSETTYPECODES.[TransferredSourceSponsorships]
		Me.Fields.Add(_outputidsettypecode)
		'
		'_outputidsetname
		'
		_outputidsetname.Name = "OUTPUTIDSETNAME"
		_outputidsetname.Caption = "Selection name"
		_outputidsetname.MaxLength = 100
		Me.Fields.Add(_outputidsetname)
		'
		'_overwriteoutputidset
		'
		_overwriteoutputidset.Name = "OVERWRITEOUTPUTIDSET"
		_overwriteoutputidset.Caption = "Overwrite existing selection"
		Me.Fields.Add(_overwriteoutputidset)
		'
		'_choosingchild
		'
		_choosingchild.Name = "CHOOSINGCHILD"
		_choosingchild.Caption = "This opportunity has"
		_choosingchild.DBReadOnly = True
		_choosingchild.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of CHOOSINGCHILDS)) With {.Value = CHOOSINGCHILDS.[MatchingChild], .Translation = "Matching child"})
		_choosingchild.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of CHOOSINGCHILDS)) With {.Value = CHOOSINGCHILDS.[SpecificChild], .Translation = "Specific child"})
		_choosingchild.Value = CHOOSINGCHILDS.[MatchingChild]
		Me.Fields.Add(_choosingchild)
		'
		'_transfermsg
		'
		_transfermsg.Name = "TRANSFERMSG"
		_transfermsg.Caption = "This opportunity has"
		_transfermsg.DBReadOnly = True
		Me.Fields.Add(_transfermsg)
		'
		'_reason
		'
		_reason.Name = "REASON"
		_reason.Caption = "Reason"
		_reason.Fields.Add("SPONSORSHIPREASONID")
		Me.Fields.Add(_reason)
		'
		'_transfer
		'
		_transfer.Name = "TRANSFER"
		_transfer.Caption = "Transfer"
		_transfer.Fields.Add("CHILDSPONSORSHIPS")
		_transfer.Fields.Add("NEWSPONSORSHIPOPPORTUNITYID")
		Me.Fields.Add(_transfer)
		'
		'_results
		'
		_results.Name = "RESULTS"
		_results.Caption = "Results"
		_results.Fields.Add("CREATEOUTPUTIDSET")
		_results.Fields.Add("OUTPUTIDSETTYPECODE")
		_results.Fields.Add("OUTPUTIDSETNAME")
		_results.Fields.Add("OVERWRITEOUTPUTIDSET")
		Me.Fields.Add(_results)

		OnCreated()

	End Sub

	''' <summary>
	'''  New child
	''' </summary>
	<System.ComponentModel.Description(" New child")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [NEWSPONSORSHIPOPPORTUNITYID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _newsponsorshipopportunityid
		End Get
	End Property

	''' <summary>
	''' Reason
	''' </summary>
	<System.ComponentModel.Description("Reason")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [SPONSORSHIPREASONID]() As Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
		Get
			Return _sponsorshipreasonid
		End Get
	End Property

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [CHILDSPONSORSHIPS]() As Global.Blackbaud.AppFx.UIModeling.Core.IntegerField
		Get
			Return _childsponsorships
		End Get
	End Property

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [GROUPID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
		Get
			Return _groupid
		End Get
	End Property

	''' <summary>
	''' Create selection of
	''' </summary>
	<System.ComponentModel.Description("Create selection of")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [CREATEOUTPUTIDSET]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		Get
			Return _createoutputidset
		End Get
	End Property

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [OUTPUTIDSETTYPECODE]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of OUTPUTIDSETTYPECODES)
		Get
			Return _outputidsettypecode
		End Get
	End Property

	''' <summary>
	''' Selection name
	''' </summary>
	<System.ComponentModel.Description("Selection name")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [OUTPUTIDSETNAME]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _outputidsetname
		End Get
	End Property

	''' <summary>
	''' Overwrite existing selection
	''' </summary>
	<System.ComponentModel.Description("Overwrite existing selection")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [OVERWRITEOUTPUTIDSET]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		Get
			Return _overwriteoutputidset
		End Get
	End Property

	''' <summary>
	''' This opportunity has
	''' </summary>
	<System.ComponentModel.Description("This opportunity has")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [CHOOSINGCHILD]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of CHOOSINGCHILDS))
		Get
			Return _choosingchild
		End Get
	End Property

	''' <summary>
	''' This opportunity has
	''' </summary>
	<System.ComponentModel.Description("This opportunity has")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [TRANSFERMSG]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _transfermsg
		End Get
	End Property

	''' <summary>
	''' Reason
	''' </summary>
	<System.ComponentModel.Description("Reason")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [REASON]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
		Get
			Return _reason
		End Get
	End Property

	''' <summary>
	''' Transfer
	''' </summary>
	<System.ComponentModel.Description("Transfer")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [TRANSFER]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
		Get
			Return _transfer
		End Get
	End Property

	''' <summary>
	''' Results
	''' </summary>
	<System.ComponentModel.Description("Results")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
	Public ReadOnly Property [RESULTS]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
		Get
			Return _results
		End Get
	End Property

End Class

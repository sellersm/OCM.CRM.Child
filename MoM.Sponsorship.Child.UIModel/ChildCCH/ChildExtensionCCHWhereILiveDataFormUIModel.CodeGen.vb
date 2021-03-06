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
''' Represents the UI model for the 'ChildExtension CCH Where I Live Data Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit, "95668dac-b65e-4c5f-b65b-775788bf109c", "c19be720-044a-47fb-a9db-9a56f53d389e", "REPLACE_WITH_RECORDTYPE")> _
Partial Public Class [ChildExtensionCCHWhereILiveDataFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _housingwallwood As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _housingwallmud As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _housingwallbamboo As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _housingwallblock As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _housingwallother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _roofingtin As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _roofinggrassleaves As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _roofingwood As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _roofingtile As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _roofingother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _watersourceindoor As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _watersourcecommunitytap As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _watersourceboreholewell As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _watersourceriver As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _watersourceother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _cookingsourcewoodfire As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _cookingsourceelectricstove As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _cookingsourcegasstove As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _cookingsourceother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _lightsourceelectricity As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _lightsourceoillamp As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _lightsourcegenerator As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _lightsourcenone As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _lightsourceother As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _areadescription As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _sponsorshipopportunitychildid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _housingmaterialgroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
    Private WithEvents _energywatergroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
    Private WithEvents _areagroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public Sub New()
        MyBase.New()

        _housingwallwood = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _housingwallmud = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _housingwallbamboo = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _housingwallblock = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _housingwallother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _roofingtin = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _roofinggrassleaves = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _roofingwood = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _roofingtile = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _roofingother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _watersourceindoor = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _watersourcecommunitytap = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _watersourceboreholewell = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _watersourceriver = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _watersourceother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _cookingsourcewoodfire = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _cookingsourceelectricstove = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _cookingsourcegasstove = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _cookingsourceother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _lightsourceelectricity = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _lightsourceoillamp = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _lightsourcegenerator = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _lightsourcenone = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _lightsourceother = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _areadescription = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _sponsorshipopportunitychildid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _housingmaterialgroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        _energywatergroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        _areagroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit
        MyBase.DataFormTemplateId = New Guid("95668dac-b65e-4c5f-b65b-775788bf109c")
        MyBase.DataFormInstanceId = New Guid("c19be720-044a-47fb-a9db-9a56f53d389e")
        MyBase.RecordType = "REPLACE_WITH_RECORDTYPE"
        MyBase.FixedDialog = True
        MyBase.UserInterfaceUrl = "browser/htmlforms/custom/ChildExtensionCCHWhereILiveDataForm.html"

        '
        '_housingwallwood
        '
        _housingwallwood.Name = "HOUSINGWALLWOOD"
        _housingwallwood.Caption = "Wood"
        Me.Fields.Add(_housingwallwood)
        '
        '_housingwallmud
        '
        _housingwallmud.Name = "HOUSINGWALLMUD"
        _housingwallmud.Caption = "Mud"
        Me.Fields.Add(_housingwallmud)
        '
        '_housingwallbamboo
        '
        _housingwallbamboo.Name = "HOUSINGWALLBAMBOO"
        _housingwallbamboo.Caption = "Bamboo"
        Me.Fields.Add(_housingwallbamboo)
        '
        '_housingwallblock
        '
        _housingwallblock.Name = "HOUSINGWALLBLOCK"
        _housingwallblock.Caption = "Block"
        Me.Fields.Add(_housingwallblock)
        '
        '_housingwallother
        '
        _housingwallother.Name = "HOUSINGWALLOTHER"
        _housingwallother.Caption = "Other"
        Me.Fields.Add(_housingwallother)
        '
        '_roofingtin
        '
        _roofingtin.Name = "ROOFINGTIN"
        _roofingtin.Caption = "Tin"
        Me.Fields.Add(_roofingtin)
        '
        '_roofinggrassleaves
        '
        _roofinggrassleaves.Name = "ROOFINGGRASSLEAVES"
        _roofinggrassleaves.Caption = "Grass/Leaves"
        Me.Fields.Add(_roofinggrassleaves)
        '
        '_roofingwood
        '
        _roofingwood.Name = "ROOFINGWOOD"
        _roofingwood.Caption = "Wood"
        Me.Fields.Add(_roofingwood)
        '
        '_roofingtile
        '
        _roofingtile.Name = "ROOFINGTILE"
        _roofingtile.Caption = "Tile"
        Me.Fields.Add(_roofingtile)
        '
        '_roofingother
        '
        _roofingother.Name = "ROOFINGOTHER"
        _roofingother.Caption = "Other"
        Me.Fields.Add(_roofingother)
        '
        '_watersourceindoor
        '
        _watersourceindoor.Name = "WATERSOURCEINDOOR"
        _watersourceindoor.Caption = "Indoor"
        Me.Fields.Add(_watersourceindoor)
        '
        '_watersourcecommunitytap
        '
        _watersourcecommunitytap.Name = "WATERSOURCECOMMUNITYTAP"
        _watersourcecommunitytap.Caption = "Community Tap"
        Me.Fields.Add(_watersourcecommunitytap)
        '
        '_watersourceboreholewell
        '
        _watersourceboreholewell.Name = "WATERSOURCEBOREHOLEWELL"
        _watersourceboreholewell.Caption = "Borehole/Well"
        Me.Fields.Add(_watersourceboreholewell)
        '
        '_watersourceriver
        '
        _watersourceriver.Name = "WATERSOURCERIVER"
        _watersourceriver.Caption = "River"
        Me.Fields.Add(_watersourceriver)
        '
        '_watersourceother
        '
        _watersourceother.Name = "WATERSOURCEOTHER"
        _watersourceother.Caption = "Other"
        Me.Fields.Add(_watersourceother)
        '
        '_cookingsourcewoodfire
        '
        _cookingsourcewoodfire.Name = "COOKINGSOURCEWOODFIRE"
        _cookingsourcewoodfire.Caption = "Wood Fire"
        Me.Fields.Add(_cookingsourcewoodfire)
        '
        '_cookingsourceelectricstove
        '
        _cookingsourceelectricstove.Name = "COOKINGSOURCEELECTRICSTOVE"
        _cookingsourceelectricstove.Caption = "Electric Stove"
        Me.Fields.Add(_cookingsourceelectricstove)
        '
        '_cookingsourcegasstove
        '
        _cookingsourcegasstove.Name = "COOKINGSOURCEGASSTOVE"
        _cookingsourcegasstove.Caption = "Gas Stove"
        Me.Fields.Add(_cookingsourcegasstove)
        '
        '_cookingsourceother
        '
        _cookingsourceother.Name = "COOKINGSOURCEOTHER"
        _cookingsourceother.Caption = "Other"
        Me.Fields.Add(_cookingsourceother)
        '
        '_lightsourceelectricity
        '
        _lightsourceelectricity.Name = "LIGHTSOURCEELECTRICITY"
        _lightsourceelectricity.Caption = "Electricity"
        Me.Fields.Add(_lightsourceelectricity)
        '
        '_lightsourceoillamp
        '
        _lightsourceoillamp.Name = "LIGHTSOURCEOILLAMP"
        _lightsourceoillamp.Caption = "Oil Lamp"
        Me.Fields.Add(_lightsourceoillamp)
        '
        '_lightsourcegenerator
        '
        _lightsourcegenerator.Name = "LIGHTSOURCEGENERATOR"
        _lightsourcegenerator.Caption = "Generator"
        Me.Fields.Add(_lightsourcegenerator)
        '
        '_lightsourcenone
        '
        _lightsourcenone.Name = "LIGHTSOURCENONE"
        _lightsourcenone.Caption = "None"
        Me.Fields.Add(_lightsourcenone)
        '
        '_lightsourceother
        '
        _lightsourceother.Name = "LIGHTSOURCEOTHER"
        _lightsourceother.Caption = "Other"
        Me.Fields.Add(_lightsourceother)
        '
        '_areadescription
        '
        _areadescription.Name = "AREADESCRIPTION"
        _areadescription.Required = True
        _areadescription.Multiline = True
        _areadescription.Caption = "Area Description"
        Me.Fields.Add(_areadescription)
        '
        '_sponsorshipopportunitychildid
        '
        _sponsorshipopportunitychildid.Name = "SPONSORSHIPOPPORTUNITYCHILDID"
        _sponsorshipopportunitychildid.Caption = "SPONSORSHIPOPPORTUNITYCHILDID"
        _sponsorshipopportunitychildid.Visible = False
        _sponsorshipopportunitychildid.DBReadOnly = True
        Me.Fields.Add(_sponsorshipopportunitychildid)
        '
        '_housingmaterialgroup
        '
        _housingmaterialgroup.Name = "HOUSINGMATERIALGROUP"
        _housingmaterialgroup.Caption = "Housing Material"
        _housingmaterialgroup.Fields.Add("HOUSINGWALLWOOD")
        _housingmaterialgroup.Fields.Add("HOUSINGWALLMUD")
        _housingmaterialgroup.Fields.Add("HOUSINGWALLBAMBOO")
        _housingmaterialgroup.Fields.Add("HOUSINGWALLBLOCK")
        _housingmaterialgroup.Fields.Add("HOUSINGWALLOTHER")
        _housingmaterialgroup.Fields.Add("ROOFINGTIN")
        _housingmaterialgroup.Fields.Add("ROOFINGGRASSLEAVES")
        _housingmaterialgroup.Fields.Add("ROOFINGWOOD")
        _housingmaterialgroup.Fields.Add("ROOFINGTILE")
        _housingmaterialgroup.Fields.Add("ROOFINGOTHER")
        Me.Fields.Add(_housingmaterialgroup)
        '
        '_energywatergroup
        '
        _energywatergroup.Name = "ENERGYWATERGROUP"
        _energywatergroup.Caption = "Energy and Water Source"
        _energywatergroup.Fields.Add("WATERSOURCEINDOOR")
        _energywatergroup.Fields.Add("WATERSOURCECOMMUNITYTAP")
        _energywatergroup.Fields.Add("WATERSOURCEBOREHOLEWELL")
        _energywatergroup.Fields.Add("WATERSOURCERIVER")
        _energywatergroup.Fields.Add("WATERSOURCEOTHER")
        _energywatergroup.Fields.Add("COOKINGSOURCEWOODFIRE")
        _energywatergroup.Fields.Add("COOKINGSOURCEELECTRICSTOVE")
        _energywatergroup.Fields.Add("COOKINGSOURCEGASSTOVE")
        _energywatergroup.Fields.Add("COOKINGSOURCEOTHER")
        _energywatergroup.Fields.Add("LIGHTSOURCEELECTRICITY")
        _energywatergroup.Fields.Add("LIGHTSOURCEOILLAMP")
        _energywatergroup.Fields.Add("LIGHTSOURCEGENERATOR")
        _energywatergroup.Fields.Add("LIGHTSOURCENONE")
        _energywatergroup.Fields.Add("LIGHTSOURCEOTHER")
        Me.Fields.Add(_energywatergroup)
        '
        '_areagroup
        '
        _areagroup.Name = "AREAGROUP"
        _areagroup.Caption = "Area Description"
        _areagroup.Fields.Add("AREADESCRIPTION")
        Me.Fields.Add(_areagroup)

		OnCreated()

    End Sub
    
    ''' <summary>
    ''' Wood
    ''' </summary>
    <System.ComponentModel.Description("Wood")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [HOUSINGWALLWOOD]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _housingwallwood
        End Get
    End Property
    
    ''' <summary>
    ''' Mud
    ''' </summary>
    <System.ComponentModel.Description("Mud")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [HOUSINGWALLMUD]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _housingwallmud
        End Get
    End Property
    
    ''' <summary>
    ''' Bamboo
    ''' </summary>
    <System.ComponentModel.Description("Bamboo")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [HOUSINGWALLBAMBOO]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _housingwallbamboo
        End Get
    End Property
    
    ''' <summary>
    ''' Block
    ''' </summary>
    <System.ComponentModel.Description("Block")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [HOUSINGWALLBLOCK]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _housingwallblock
        End Get
    End Property
    
    ''' <summary>
    ''' Other
    ''' </summary>
    <System.ComponentModel.Description("Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [HOUSINGWALLOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _housingwallother
        End Get
    End Property
    
    ''' <summary>
    ''' Tin
    ''' </summary>
    <System.ComponentModel.Description("Tin")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ROOFINGTIN]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _roofingtin
        End Get
    End Property
    
    ''' <summary>
    ''' Grass/Leaves
    ''' </summary>
    <System.ComponentModel.Description("Grass/Leaves")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ROOFINGGRASSLEAVES]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _roofinggrassleaves
        End Get
    End Property
    
    ''' <summary>
    ''' Wood
    ''' </summary>
    <System.ComponentModel.Description("Wood")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ROOFINGWOOD]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _roofingwood
        End Get
    End Property
    
    ''' <summary>
    ''' Tile
    ''' </summary>
    <System.ComponentModel.Description("Tile")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ROOFINGTILE]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _roofingtile
        End Get
    End Property
    
    ''' <summary>
    ''' Other
    ''' </summary>
    <System.ComponentModel.Description("Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ROOFINGOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _roofingother
        End Get
    End Property
    
    ''' <summary>
    ''' Indoor
    ''' </summary>
    <System.ComponentModel.Description("Indoor")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [WATERSOURCEINDOOR]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _watersourceindoor
        End Get
    End Property
    
    ''' <summary>
    ''' Community Tap
    ''' </summary>
    <System.ComponentModel.Description("Community Tap")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [WATERSOURCECOMMUNITYTAP]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _watersourcecommunitytap
        End Get
    End Property
    
    ''' <summary>
    ''' Borehole/Well
    ''' </summary>
    <System.ComponentModel.Description("Borehole/Well")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [WATERSOURCEBOREHOLEWELL]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _watersourceboreholewell
        End Get
    End Property
    
    ''' <summary>
    ''' River
    ''' </summary>
    <System.ComponentModel.Description("River")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [WATERSOURCERIVER]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _watersourceriver
        End Get
    End Property
    
    ''' <summary>
    ''' Other
    ''' </summary>
    <System.ComponentModel.Description("Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [WATERSOURCEOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _watersourceother
        End Get
    End Property
    
    ''' <summary>
    ''' Wood Fire
    ''' </summary>
    <System.ComponentModel.Description("Wood Fire")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [COOKINGSOURCEWOODFIRE]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _cookingsourcewoodfire
        End Get
    End Property
    
    ''' <summary>
    ''' Electric Stove
    ''' </summary>
    <System.ComponentModel.Description("Electric Stove")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [COOKINGSOURCEELECTRICSTOVE]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _cookingsourceelectricstove
        End Get
    End Property
    
    ''' <summary>
    ''' Gas Stove
    ''' </summary>
    <System.ComponentModel.Description("Gas Stove")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [COOKINGSOURCEGASSTOVE]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _cookingsourcegasstove
        End Get
    End Property
    
    ''' <summary>
    ''' Other
    ''' </summary>
    <System.ComponentModel.Description("Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [COOKINGSOURCEOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _cookingsourceother
        End Get
    End Property
    
    ''' <summary>
    ''' Electricity
    ''' </summary>
    <System.ComponentModel.Description("Electricity")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [LIGHTSOURCEELECTRICITY]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _lightsourceelectricity
        End Get
    End Property
    
    ''' <summary>
    ''' Oil Lamp
    ''' </summary>
    <System.ComponentModel.Description("Oil Lamp")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [LIGHTSOURCEOILLAMP]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _lightsourceoillamp
        End Get
    End Property
    
    ''' <summary>
    ''' Generator
    ''' </summary>
    <System.ComponentModel.Description("Generator")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [LIGHTSOURCEGENERATOR]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _lightsourcegenerator
        End Get
    End Property
    
    ''' <summary>
    ''' None
    ''' </summary>
    <System.ComponentModel.Description("None")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [LIGHTSOURCENONE]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _lightsourcenone
        End Get
    End Property
    
    ''' <summary>
    ''' Other
    ''' </summary>
    <System.ComponentModel.Description("Other")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [LIGHTSOURCEOTHER]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _lightsourceother
        End Get
    End Property
    
    ''' <summary>
    ''' Area Description
    ''' </summary>
    <System.ComponentModel.Description("Area Description")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [AREADESCRIPTION]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _areadescription
        End Get
    End Property
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [SPONSORSHIPOPPORTUNITYCHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _sponsorshipopportunitychildid
        End Get
    End Property
    
    ''' <summary>
    ''' Housing Material
    ''' </summary>
    <System.ComponentModel.Description("Housing Material")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [HOUSINGMATERIALGROUP]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _housingmaterialgroup
        End Get
    End Property
    
    ''' <summary>
    ''' Energy and Water Source
    ''' </summary>
    <System.ComponentModel.Description("Energy and Water Source")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ENERGYWATERGROUP]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _energywatergroup
        End Get
    End Property
    
    ''' <summary>
    ''' Area Description
    ''' </summary>
    <System.ComponentModel.Description("Area Description")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [AREAGROUP]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _areagroup
        End Get
    End Property
    
End Class

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
''' Represents the UI model for the 'ChildExtension Edit Development Data Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit, "9ef858a2-00be-4899-a0a0-6f39edac60a4", "262037d6-634d-4be6-b9c8-36847751b97c", "Child Extension")> _
Partial Public Class [ChildExtensionDevelopmentEditDataFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _childhealth As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _spiritualdevelopment As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _attendingschool As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _reasonnotattendingschool As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _classlevel As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _favoritesubject As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _vocationalskills As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _physicaldevelopment As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
    Private WithEvents _spiritualdevelopmentgroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
    Private WithEvents _attendingschoolgroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
    Private WithEvents _currentprogramcompletiondate As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _originalprogramcompletiondate As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _childpersonality As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _socialemotionalgroup As Global.Blackbaud.AppFx.UIModeling.Core.GroupField


	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public Sub New()
        MyBase.New()

        _childhealth = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _spiritualdevelopment = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _attendingschool = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _reasonnotattendingschool = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _classlevel = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _favoritesubject = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _vocationalskills = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _physicaldevelopment = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        _spiritualdevelopmentgroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        _attendingschoolgroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        _currentprogramcompletiondate = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _originalprogramcompletiondate = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _childpersonality = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _socialemotionalgroup = New Global.Blackbaud.AppFx.UIModeling.Core.GroupField

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit
        MyBase.DataFormTemplateId = New Guid("9ef858a2-00be-4899-a0a0-6f39edac60a4")
        MyBase.DataFormInstanceId = New Guid("262037d6-634d-4be6-b9c8-36847751b97c")
        MyBase.RecordType = "Child Extension"
        MyBase.FixedDialog = True
        MyBase.UserInterfaceUrl = "browser/htmlforms/custom/ChildExtensionDevelopmentEditDataForm.html"

        '
        '_childpersonality
        '
        _childpersonality.Name = "CHILDPERSONALITY"
        _childpersonality.Caption = "Describes the child's personality or qualities that make them unique or special as well as how they interact with and relate to other children"
        _childpersonality.MaxLength = 1000
        _childpersonality.Multiline = True
        Me.Fields.Add(_childpersonality)
        '
        '_childhealth
        '
        _childhealth.Name = "CHILDHEALTH"
        _childhealth.Caption = "Describes the child's current health including any special concerns or conditions"
        _childhealth.MaxLength = 1000
        _childhealth.MultiLine = True
        Me.Fields.Add(_childhealth)
        '
        '_spiritualdevelopment
        '
        _spiritualdevelopment.Name = "SPIRITUALDEVELOPMENT"
        _spiritualdevelopment.Caption = "Describes the child's current level of faith, spiritual understanding and Christian activities"
        _spiritualdevelopment.MaxLength = 1000
        _spiritualdevelopment.MultiLine = True
        Me.Fields.Add(_spiritualdevelopment)
        '
        '_attendingschool
        '
        _attendingschool.Name = "ATTENDINGSCHOOL"
        _attendingschool.Caption = "Attending School"
        Me.Fields.Add(_attendingschool)
        '
        '_reasonnotattendingschool
        '
        _reasonnotattendingschool.Name = "REASONNOTATTENDINGSCHOOL"
        _reasonnotattendingschool.Caption = "Reason for Not Attending School"
        _reasonnotattendingschool.MaxLength = 255
        _reasonnotattendingschool.MultiLine = True
        Me.Fields.Add(_reasonnotattendingschool)
        '
        '_classlevel
        '
        _classlevel.Name = "CLASSLEVEL"
        _classlevel.Caption = "Class Level"
        _classlevel.MaxLength = 1000
        _classlevel.MultiLine = True
        Me.Fields.Add(_classlevel)
        '
        '_favoritesubject
        '
        _favoritesubject.Name = "FAVORITESUBJECT"
        _favoritesubject.Caption = "Favorite Subject or Activity"
        _favoritesubject.MaxLength = 1000
        _favoritesubject.MultiLine = True
        Me.Fields.Add(_favoritesubject)
        '
        '_vocationalskills
        '
        _vocationalskills.Name = "VOCATIONALSKILLS"
        _vocationalskills.Caption = "Vocational or Life Skills"
        _vocationalskills.MaxLength = 1000
        _vocationalskills.MultiLine = True
        Me.Fields.Add(_vocationalskills)
        '
        ' _socialemotionalgroup
        '
        _socialemotionalgroup.Name = "SOCIAL_EMOTIONAL"
        _socialemotionalgroup.Caption = "Social and Emotional Development"
        _socialemotionalgroup.Fields.Add("CHILDPERSONALITY")
        Me.Fields.Add(_socialemotionalgroup)
        '
        '_physicaldevelopment
        '
        _physicaldevelopment.Name = "PHYSICAL_DEVELOPMENT"
        _physicaldevelopment.Caption = "Physical Development"
        _physicaldevelopment.Fields.Add("CHILDHEALTH")
        Me.Fields.Add(_physicaldevelopment)
        '
        '_spiritualdevelopment
        '
        _spiritualdevelopmentgroup.Name = "SPIRITUAL_DEVELOPMENT"
        _spiritualdevelopmentgroup.Caption = "Spritual Development"
        _spiritualdevelopmentgroup.Fields.Add("SPIRITUALDEVELOPMENT")
        Me.Fields.Add(_spiritualdevelopmentgroup)
        '
        '_attendingschool
        '
        _attendingschoolgroup.Name = "ATTENDING_SCHOOL"
        _attendingschoolgroup.Caption = "Attending School"
        _attendingschoolgroup.Fields.Add("ATTENDINGSCHOOL")
        _attendingschoolgroup.Fields.Add("REASONNOTATTENDINGSCHOOL")
        _attendingschoolgroup.Fields.Add("CLASSLEVEL")
        _attendingschoolgroup.Fields.Add("FAVORITESUBJECT")
        _attendingschoolgroup.Fields.Add("VOCATIONALSKILLS")
        Me.Fields.Add(_attendingschoolgroup)
        '
        '_currentprogramcompletiondate
        '
        _currentprogramcompletiondate.Name = "CURRENTPROGRAMCOMPLETIONDATE"
        _currentprogramcompletiondate.Required = True
        _currentprogramcompletiondate.Caption = "Current Program Completion Date"
        Me.Fields.Add(_currentprogramcompletiondate)
        '
        '_originalprogramcompletiondate
        '
        _originalprogramcompletiondate.Name = "ORIGINALPROGRAMCOMPLETIONDATE"
        _originalprogramcompletiondate.Caption = "Original Program Completion Date"
        Me.Fields.Add(_originalprogramcompletiondate)

		OnCreated()

    End Sub
    ''' <summary>
    ''' Child's personality or quallities and how they interact with other children
    ''' </summary>
    <System.ComponentModel.Description("Describes the child's personality or qualities that make them unique or special as well as how they interact with and relate to other children")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CHILDPERSONALITY]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _childpersonality
        End Get
    End Property

    ''' <summary>
    ''' Physical Development
    ''' </summary>
    <System.ComponentModel.Description("Describes the child's current health including any special concerns or conditions")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CHILDHEALTH]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _childhealth
        End Get
    End Property
    
    ''' <summary>
    ''' Spiritual Development
    ''' </summary>
    <System.ComponentModel.Description("Describes the child's current level of faith, spiritual understanding and Christian activities")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [SPIRITUALDEVELOPMENT]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _spiritualdevelopment
        End Get
    End Property
    
    ''' <summary>
    ''' Attending School
    ''' </summary>
    <System.ComponentModel.Description("Attending School")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ATTENDINGSCHOOL]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _attendingschool
        End Get
    End Property
    
    ''' <summary>
    ''' Reason for Not Attending School
    ''' </summary>
    <System.ComponentModel.Description("Reason for Not Attending School")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [REASONNOTATTENDINGSCHOOL]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _reasonnotattendingschool
        End Get
    End Property
    
    ''' <summary>
    ''' Class Level
    ''' </summary>
    <System.ComponentModel.Description("Class Level")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CLASSLEVEL]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _classlevel
        End Get
    End Property
    
    ''' <summary>
    ''' Favorite Subject or Activity
    ''' </summary>
    <System.ComponentModel.Description("Favorite Subject or Activity")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [FAVORITESUBJECT]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _favoritesubject
        End Get
    End Property
    
    ''' <summary>
    ''' Vocational or Life Skills
    ''' </summary>
    <System.ComponentModel.Description("Vocational or Life Skills")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [VOCATIONALSKILLS]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _vocationalskills
        End Get
    End Property
    
    ''' <summary>
    ''' Physical Development
    ''' </summary>
    <System.ComponentModel.Description("Physical Development")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [PHYSICAL_DEVELOPMENT]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _physicaldevelopment
        End Get
    End Property
    
    ''' <summary>
    ''' Spritual Development
    ''' </summary>
    <System.ComponentModel.Description("Spritual Development")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [SPIRITUAL_DEVELOPMENT]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _spiritualdevelopmentgroup
        End Get
    End Property
    
    ''' <summary>
    ''' Attending School
    ''' </summary>
    <System.ComponentModel.Description("Attending School")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ATTENDING_SCHOOL]() As Global.Blackbaud.AppFx.UIModeling.Core.GroupField
        Get
            Return _attendingschoolgroup
        End Get
    End Property

    ''' <summary>
    ''' Current Program Completion Date
    ''' </summary>
    <System.ComponentModel.Description("Current Program Completion Date")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [CURRENTPROGRAMCOMPLETIONDATE]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _currentprogramcompletiondate
        End Get
    End Property

    ''' <summary>
    ''' Original Program Completion Date
    ''' </summary>
    <System.ComponentModel.Description("Original Program Completion Date")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ORIGINALPROGRAMCOMPLETIONDATE]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _originalprogramcompletiondate
        End Get
    End Property

End Class

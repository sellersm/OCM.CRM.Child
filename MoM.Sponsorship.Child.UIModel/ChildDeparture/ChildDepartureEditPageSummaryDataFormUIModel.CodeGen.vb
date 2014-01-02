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
''' Represents the UI model for the 'ChildDeparture Edit Page Summary Data Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit, "32792bf6-1f40-43c2-ab22-902f7e3a4816", "b3be4d91-42b5-4b50-bcf1-b9eb976c8c16", "ChildDeparture")> _
Partial Public Class [ChildDepartureEditPageSummaryDataFormUIModel]
    Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Enums"

    ''' <summary>
    ''' Enumerated values for use with the RECEIVEDFAREWELLLETTERCODE property
    ''' </summary>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public Enum RECEIVEDFAREWELLLETTERCODES As Integer
        [No] = 0
        [Yes] = 1
    End Enum

    ''' <summary>
    ''' Enumerated values for use with the DEPARTURETYPECODE property
    ''' </summary>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public Enum DEPARTURETYPECODES As Integer
        [Departure] = 0
        [Completion] = 1
        [Administrative] = 2
    End Enum

#End Region

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _nodepartureform As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _departuretypecode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of DEPARTURETYPECODES))
    Private WithEvents _receivedfarewelllettercode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of RECEIVEDFAREWELLLETTERCODES))
    Private WithEvents _dateformcompleted As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _formcompletedby As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _dateofdeparture As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _dateprocessed As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _administrativecodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _administrativeexplanation As Global.Blackbaud.AppFx.UIModeling.Core.StringField

    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public Sub New()
        MyBase.New()

        _nodepartureform = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _departuretypecode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of DEPARTURETYPECODES))
        _receivedfarewelllettercode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of RECEIVEDFAREWELLLETTERCODES))
        _dateformcompleted = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _formcompletedby = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _dateofdeparture = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _dateprocessed = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _administrativecodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _administrativeexplanation = New Global.Blackbaud.AppFx.UIModeling.Core.StringField

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit
        MyBase.DataFormTemplateId = New Guid("32792bf6-1f40-43c2-ab22-902f7e3a4816")
        MyBase.DataFormInstanceId = New Guid("b3be4d91-42b5-4b50-bcf1-b9eb976c8c16")
        MyBase.RecordType = "ChildDeparture"
        MyBase.FixedDialog = True
        MyBase.UserInterfaceUrl = "browser/htmlforms/ChildDepartureEditPageSummaryDataForm.html"

        '
        '_nodepartureform
        '
        _nodepartureform.Name = "NODEPARTUREFORM"
        _nodepartureform.Caption = "No Departure Form"
        Me.Fields.Add(_nodepartureform)
        '
        '_receivedfarewelllettercode
        '
        _receivedfarewelllettercode.Name = "RECEIVEDFAREWELLLETTERCODE"
        _receivedfarewelllettercode.Caption = "Received farewell letter"
        _receivedfarewelllettercode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of RECEIVEDFAREWELLLETTERCODES)) With {.Value = RECEIVEDFAREWELLLETTERCODES.[No], .Translation = "No"})
        _receivedfarewelllettercode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of RECEIVEDFAREWELLLETTERCODES)) With {.Value = RECEIVEDFAREWELLLETTERCODES.[Yes], .Translation = "Yes"})
        _receivedfarewelllettercode.Value = RECEIVEDFAREWELLLETTERCODES.[Yes]
        Me.Fields.Add(_receivedfarewelllettercode)
        '
        '_departuretypecode
        '
        _departuretypecode.Name = "DEPARTURETYPECODE"
        _departuretypecode.Caption = "Type of departure"
        _departuretypecode.Required = True
        _departuretypecode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of DEPARTURETYPECODES)) With {.Value = DEPARTURETYPECODES.[Departure], .Translation = "Departure"})
        _departuretypecode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of DEPARTURETYPECODES)) With {.Value = DEPARTURETYPECODES.[Completion], .Translation = "Completion"})
        _departuretypecode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of DEPARTURETYPECODES)) With {.Value = DEPARTURETYPECODES.[Administrative], .Translation = "Administrative"})
        Me.Fields.Add(_departuretypecode)


        '
        '_dateformcompleted
        '
        _dateformcompleted.Name = "DATEFORMCOMPLETED"
        _dateformcompleted.Caption = "Form Completed Date"
        Me.Fields.Add(_dateformcompleted)
        '
        '_formcompletedby
        '
        _formcompletedby.Name = "FORMCOMPLETEDBY"
        _formcompletedby.Caption = "Form Completed By"
        _formcompletedby.MaxLength = 50
        Me.Fields.Add(_formcompletedby)
        '
        '_dateofdeparture
        '
        _dateofdeparture.Name = "DATEOFDEPARTURE"
        _dateofdeparture.Caption = "Date of the departure or program completion"
        Me.Fields.Add(_dateofdeparture)
        '
        '_dateprocessed
        '
        _dateprocessed.Name = "DATEPROCESSED"
        _dateprocessed.Caption = "Date processed"
        _dateprocessed.Visible = False
        Me.Fields.Add(_dateprocessed)
        '
        '_administrativecodeid
        '
        _administrativecodeid.Name = "ADMINISTRATIVECODEID"
        _administrativecodeid.Caption = "Administrative"
        _administrativecodeid.CodeTableName = "USR_DEPARTURE_ADMINISTRATIVE_CODE"
        Me.Fields.Add(_administrativecodeid)
        '
        '_administrativeexplanation
        '
        _administrativeexplanation.Name = "ADMINISTRATIVEEXPLANATION"
        _administrativeexplanation.Caption = "Explanation"
        _administrativeexplanation.MaxLength = 50
        Me.Fields.Add(_administrativeexplanation)

        OnCreated()

    End Sub

    ''' <summary>
    ''' No Departure Form
    ''' </summary>
    <System.ComponentModel.Description("No Departure Form")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [NODEPARTUREFORM]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _nodepartureform
        End Get
    End Property
    ''' <summary>
    ''' Type of Departure
    ''' </summary>
    <System.ComponentModel.Description("Type of Departure")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [DEPARTURETYPECODE]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of DEPARTURETYPECODES))
        Get
            Return _departuretypecode
        End Get
    End Property
    ''' <summary>
    ''' Received farewell letter
    ''' </summary>
    <System.ComponentModel.Description("Received farewell letter")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [RECEIVEDFAREWELLLETTERCODE]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of RECEIVEDFAREWELLLETTERCODES))
        Get
            Return _receivedfarewelllettercode
        End Get
    End Property

    ''' <summary>
    ''' Form Completed Date
    ''' </summary>
    <System.ComponentModel.Description("Form Completed Date")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [DATEFORMCOMPLETED]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _dateformcompleted
        End Get
    End Property

    ''' <summary>
    ''' Form Completed By
    ''' </summary>
    <System.ComponentModel.Description("Form Completed By")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [FORMCOMPLETEDBY]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _formcompletedby
        End Get
    End Property

    ''' <summary>
    ''' Date of the departure or program completion
    ''' </summary>
    <System.ComponentModel.Description("Date of the departure or program completion")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [DATEOFDEPARTURE]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _dateofdeparture
        End Get
    End Property

    ''' <summary>
    ''' Date processed
    ''' </summary>
    <System.ComponentModel.Description("Date processed")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [DATEPROCESSED]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _dateprocessed
        End Get
    End Property

    ''' <summary>
    ''' Administrative
    ''' </summary>
    <System.ComponentModel.Description("Administrative")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ADMINISTRATIVECODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _administrativecodeid
        End Get
    End Property

    ''' <summary>
    ''' Explanation
    ''' </summary>
    <System.ComponentModel.Description("Explanation")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.91.1535.0")> _
    Public ReadOnly Property [ADMINISTRATIVEEXPLANATION]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _administrativeexplanation
        End Get
    End Property

End Class

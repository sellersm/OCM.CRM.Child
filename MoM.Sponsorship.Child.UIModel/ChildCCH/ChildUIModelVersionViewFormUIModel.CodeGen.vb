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
''' Represents the UI model for the 'Child UI Model Version' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.View, "7e898b45-9536-432b-a7e0-4909313ce134", "238619d4-7f2b-4441-a7d1-36908e9e5300", "REPLACE_WITH_RECORDTYPE")> _
Partial Public Class [ChildUIModelVersionViewFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _version As Global.Blackbaud.AppFx.UIModeling.Core.StringField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Sub New()
        MyBase.New()

        _version = New Global.Blackbaud.AppFx.UIModeling.Core.StringField

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.View
        MyBase.DataFormTemplateId = New Guid("7e898b45-9536-432b-a7e0-4909313ce134")
        MyBase.DataFormInstanceId = New Guid("238619d4-7f2b-4441-a7d1-36908e9e5300")
        MyBase.RecordType = "REPLACE_WITH_RECORDTYPE"
        MyBase.FixedDialog = True
        MyBase.UserInterfaceUrl = "browser/htmlforms/ChildUIModelVersion.ViewForm.html"

        '
        '_version
        '
        _version.Name = "VERSION"
        _version.Caption = "Child UI Model"
        _version.DBReadOnly = True
        _version.MaxLength = 50
        Me.Fields.Add(_version)

		OnCreated()

    End Sub
    
    ''' <summary>
    ''' Child UI Model
    ''' </summary>
    <System.ComponentModel.Description("Child UI Model")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [VERSION]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _version
        End Get
    End Property
    
End Class

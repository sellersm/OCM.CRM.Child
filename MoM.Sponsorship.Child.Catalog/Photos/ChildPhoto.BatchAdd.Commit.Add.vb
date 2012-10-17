Imports Blackbaud.AppFx.Server

Imports System
Imports System.IO
Imports System.Text

' Initial Version - Modified from Blackbaud prototype

Public NotInheritable Class ChildPhotoAddBatchCommitAddDataForm
	Inherits AppCatalog.AppAddDataForm

	'Add forms have an optional pre-load that can be overridden
	'Public Overrides Function Load() As Blackbaud.AppFx.Server.AppCatalog.AppAddDataFormLoadResult
	'    Return MyBase.Load()
	'End Function


	Public VALIDATEONLY As Boolean
	Public SPONSORSHIPOPPORTUNITYLOOKUPID As String
	Public ATTACHMENTTYPECODEID As Guid
	Public PICTURETITLE As String
	Public FILENAME As String
	Public FILELOCATION As String

	Public PictureFile As String


	Public Overrides Function Save() As Blackbaud.AppFx.Server.AppCatalog.AppAddDataFormSaveResult
		PictureFile = FILELOCATION & "\" & FILENAME
		SaveDataDB(SPONSORSHIPOPPORTUNITYLOOKUPID, ATTACHMENTTYPECODEID, PICTURETITLE, PictureFile, FILENAME)

		Return New AppCatalog.AppAddDataFormSaveResult() With {.ID = Guid.NewGuid().ToString()}
	End Function

	Private Function SaveDataDB(ByVal SponsorshipOpportunityLookupID As String, ByVal AttachmentTypeCodeID As Guid, ByVal PictureTitle As String, ByVal PictureFile As String, ByVal FileName As String)
		Using conn As SqlClient.SqlConnection = Me.RequestContext.OpenAppDBConnection()
			Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
			cmd.Connection = conn

			cmd.CommandText = "dbo.USR_USP_CHILDPHOTOADD"
			cmd.CommandType = CommandType.StoredProcedure

			cmd.Parameters.AddWithValue("@VALIDATEONLY", VALIDATEONLY)
			cmd.Parameters.AddWithValue("@SPONSORSHIPOPPORTUNITYLOOKUPID", SponsorshipOpportunityLookupID)
			cmd.Parameters.AddWithValue("@ATTACHMENTTYPECODEID", AttachmentTypeCodeID)
			cmd.Parameters.AddWithValue("@PICTURETITLE", PictureTitle)
			cmd.Parameters.AddWithValue("@FILENAME", PictureFile)
			cmd.Parameters.AddWithValue("@PICTURE", GetImage(PictureFile))

			cmd.ExecuteNonQuery()
		End Using

		Return 0
	End Function

	Public Shared Function GetImage(ByVal filePath As String) As Byte()
		Dim stream As FileStream = New FileStream( _
		   filePath, FileMode.Open, FileAccess.Read)
		Dim reader As BinaryReader = New BinaryReader(stream)

		Dim imageByte() As Byte = reader.ReadBytes(stream.Length)

		reader.Close()
		stream.Close()

		Return imageByte
	End Function

End Class

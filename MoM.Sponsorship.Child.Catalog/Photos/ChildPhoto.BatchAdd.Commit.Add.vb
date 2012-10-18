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
		Dim username As String = ""
		Dim password As String = ""
		Using Connection As SqlClient.SqlConnection = Me.RequestContext.OpenAppDBConnection()
			Dim command As SqlClient.SqlCommand = Connection.CreateCommand()
			With command

				'.CommandText = "dbo.USR_USP_IMPORT_GETIMPORTSOURCE"
				'.CommandType = CommandType.StoredProcedure

				'.Parameters.AddWithValue("@userName", username)
				'.Parameters("@userName").Direction = ParameterDirection.Output
				'.Parameters.AddWithValue("@password", password)
				'.Parameters("@password").Direction = ParameterDirection.Output

				'.ExecuteNonQuery()


				'.Parameters.Clear()
				.CommandType = CommandType.StoredProcedure

				.CommandText = "dbo.USR_USP_CHILDPHOTOADD"
				.CommandType = CommandType.StoredProcedure

				.Parameters.AddWithValue("@VALIDATEONLY", VALIDATEONLY)
				.Parameters.AddWithValue("@SPONSORSHIPOPPORTUNITYLOOKUPID", SponsorshipOpportunityLookupID)
				.Parameters.AddWithValue("@ATTACHMENTTYPECODEID", AttachmentTypeCodeID)
				.Parameters.AddWithValue("@PICTURETITLE", PictureTitle)
				.Parameters.AddWithValue("@FILENAME", PictureFile)
				.Parameters.AddWithValue("@PICTURE", GetImage(PictureFile))

				.ExecuteNonQuery()


			End With
		End Using

		
		Return 0
	End Function


	Public Shared Function GetImage(ByVal filePath As String) As Byte()

		Dim impersonationScope As UserImpersonationScope = Nothing
		Try
			impersonationScope = ImpersonationHelper.GetImpersonationScope("blackbaudhost\cmayeda21195p", "T#pPE2ki@P")
		Catch ex As Exception
			impersonationScope = ImpersonationHelper.GetImpersonationScope("blackbaudhost\caryma21195D", "T#pPE2ki@P")

		End Try
		
		Dim stream As FileStream = New FileStream( _
		   filePath, FileMode.Open, FileAccess.Read)
		Dim reader As BinaryReader = New BinaryReader(stream)

		Dim imageByte() As Byte = reader.ReadBytes(stream.Length)

		reader.Close()
		stream.Close()

		If impersonationScope IsNot Nothing Then
			impersonationScope.Dispose()
		End If


		Return imageByte
	End Function

End Class

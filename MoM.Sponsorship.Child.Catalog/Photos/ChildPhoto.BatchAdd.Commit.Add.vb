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

		Dim username As String = ""
		Dim password As String = ""

		username = PICTURETITLE.Substring(0, PICTURETITLE.IndexOf(","))
		password = PICTURETITLE.Substring(PICTURETITLE.IndexOf(",") + 1)

		Dim image As Byte()

		image = GetImage(PictureFile, PICTURETITLE)

		SaveDataDB(SPONSORSHIPOPPORTUNITYLOOKUPID, ATTACHMENTTYPECODEID, PICTURETITLE, PictureFile, FILENAME, image)

		Return New AppCatalog.AppAddDataFormSaveResult() With {.ID = Guid.NewGuid().ToString()}
	End Function

	Private Function SaveDataDB(ByVal SponsorshipOpportunityLookupID As String, ByVal AttachmentTypeCodeID As Guid, ByVal PictureTitle As String, ByVal PictureFile As String, ByVal FileName As String, ByVal Image As Byte())

		Using Connection As SqlClient.SqlConnection = New SqlClient.SqlConnection(RequestContext.AppDBConnectionString)
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
				.Parameters.AddWithValue("@PICTURETITLE", "2012 Health Update")
				.Parameters.AddWithValue("@FILENAME", PictureFile)
				.Parameters.AddWithValue("@PICTURE", Image)

				Connection.Open()

				.ExecuteNonQuery()

				Connection.Close()
			End With
		End Using


		Return 0
	End Function


	Public Shared Function GetImage(ByVal filePath As String, ByVal cred As String) As Byte()
		Dim username As String = ""
		Dim password As String = ""

		username = cred.Substring(0, cred.IndexOf(","))
		password = cred.Substring(cred.IndexOf(",") + 1)

		Dim impersonationScope As UserImpersonationScope = Nothing
		impersonationScope = ImpersonationHelper.GetImpersonationScope(username, password)

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

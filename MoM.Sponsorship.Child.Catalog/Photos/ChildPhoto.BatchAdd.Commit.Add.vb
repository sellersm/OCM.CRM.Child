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

	Public Overrides Function Save() As Blackbaud.AppFx.Server.AppCatalog.AppAddDataFormSaveResult
		Dim pictureFile As String = FILELOCATION & "\" & FILENAME

		Dim fileShareCredentials As Credential = GetCredentials()

		Dim image As Byte() 
		image = GetImage(pictureFile, fileShareCredentials.domain, fileShareCredentials.username, fileShareCredentials.password)

		SaveDataDB(SPONSORSHIPOPPORTUNITYLOOKUPID, ATTACHMENTTYPECODEID, PICTURETITLE, pictureFile, FILENAME, image)

		Return New AppCatalog.AppAddDataFormSaveResult() With {.ID = Guid.NewGuid().ToString()}

	End Function

	Private Function GetCredentials() As Credential
		
		Dim username As String = ""
		Dim password As String = ""

		Using Connection As SqlClient.SqlConnection = New SqlClient.SqlConnection(RequestContext.AppDBConnectionString)
			Dim command As SqlClient.SqlCommand = Connection.CreateCommand()
			With command

				.CommandText = "dbo.USR_USP_IMPORT_GETIMPORTSOURCE"
				.CommandType = CommandType.StoredProcedure

				.Parameters.Add("@importSourceName", SqlDbType.NVarChar, 100).Value = "Default Network Import Path"
				.Parameters.Add("@userName", SqlDbType.NVarChar, 255).Value = ""
				.Parameters("@userName").Direction = ParameterDirection.Output
				.Parameters.Add("@password", SqlDbType.NVarChar, 255).Value = ""
				.Parameters("@password").Direction = ParameterDirection.Output

				Try
					Connection.Open()

					.ExecuteNonQuery()

					username = .Parameters("@userName").Value.ToString
					password = .Parameters("@password").Value.ToString

					Connection.Close()

				Catch ex As Exception
					Throw New Exception("GetCredentials: " & ex.Message, ex)
				End Try
			End With
		End Using


		Dim myCredential As New Credential
		myCredential.password = password

		' The username passed back from the sproc includes the domain name, so it needs to be parsed out.
		ParseDomainAndUserName(username, myCredential.domain, myCredential.username)

		Return myCredential
	End Function


	Private Function SaveDataDB(ByVal SponsorshipOpportunityLookupID As String, ByVal AttachmentTypeCodeID As Guid, ByVal PictureTitle As String, ByVal PictureFile As String, ByVal FileName As String, ByVal Image As Byte())

		Using Connection As SqlClient.SqlConnection = New SqlClient.SqlConnection(RequestContext.AppDBConnectionString)
			Dim command As SqlClient.SqlCommand = Connection.CreateCommand()
			With command

				.CommandType = CommandType.StoredProcedure

				.CommandText = "dbo.USR_USP_CHILDPHOTOADD"
				.CommandType = CommandType.StoredProcedure

				.Parameters.AddWithValue("@VALIDATEONLY", VALIDATEONLY)
				.Parameters.AddWithValue("@SPONSORSHIPOPPORTUNITYLOOKUPID", SponsorshipOpportunityLookupID)
				.Parameters.AddWithValue("@ATTACHMENTTYPECODEID", AttachmentTypeCodeID)
				.Parameters.AddWithValue("@PICTURETITLE", PictureTitle)
				.Parameters.AddWithValue("@FILENAME", FileName)
				.Parameters.AddWithValue("@PICTURE", Image)

				Try
					Connection.Open()

					.ExecuteNonQuery()

					Connection.Close()

				Catch ex As Exception
					Throw New Exception("SaveDataDB: " & ex.Message, ex)
				End Try
			End With
		End Using


		Return 0
	End Function


	Public Shared Function GetImage(ByVal filePath As String, ByVal domain As String, ByVal username As String, ByVal password As String) As Byte()

		Dim impersonationScope As UserImpersonationScope = Nothing
		Dim imageByte() As Byte = Nothing
		Try
			impersonationScope = New UserImpersonationScope(username, domain, password, True)

			Dim stream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
			Dim reader As BinaryReader = New BinaryReader(stream)

			imageByte = reader.ReadBytes(stream.Length)

			reader.Close()
			stream.Close()


		Catch ex As Exception
			If filePath Is Nothing Then
				Throw New Exception("Error reading file - no file name provided, Username - " & username & "| domain=" & domain & "| password=" & password, ex)
			Else
				Throw New Exception("Error reading file " & filePath & ", Username - " & username & "| domain=" & domain & "| password=" & password, ex)
			End If

		Finally
			If impersonationScope IsNot Nothing Then
				impersonationScope.Dispose()
			End If

		End Try


		Return imageByte
	End Function

	Private Shared Sub ParseDomainAndUserName(ByVal domainAndUserName As String, ByRef domain As String, ByRef userName As String)
		Dim indexOfSlash = domainAndUserName.IndexOf("\", StringComparison.CurrentCulture)

		If indexOfSlash > 0 Then
			domain = domainAndUserName.Substring(0, indexOfSlash)
			userName = domainAndUserName.Remove(0, domain.Length + 1)
		Else
			domain = String.Empty
			userName = domainAndUserName
		End If
	End Sub

End Class

Public Class Credential
	Public Property domain As String
	Public Property username As String
	Public Property password As String

	Public Sub New()
		domain = ""
		username = ""
		password = ""
	End Sub
End Class
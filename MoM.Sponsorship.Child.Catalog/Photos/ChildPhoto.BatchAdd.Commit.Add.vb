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
				.Parameters.AddWithValue("@FILENAME", FileName)
				.Parameters.AddWithValue("@PICTURE", Image)

				Try
					Connection.Open()

					.ExecuteNonQuery()

					Connection.Close()

				Catch ex As Exception
					Throw ex
				End Try
			End With
		End Using


		Return 0
	End Function


	Public Shared Function GetImage(ByVal filePath As String, ByVal cred As String) As Byte()
		Dim domainName As String = ""
		Dim userNamePwd As String = ""
		Dim userName As String = ""
		Dim password As String = ""

		ParseDomainAndUserName(cred, domainName, userNamePwd)
		userName = userNamePwd.Substring(0, userNamePwd.IndexOf(","))
		password = userNamePwd.Substring(userNamePwd.IndexOf(",") + 1)


		Dim impersonationScope As UserImpersonationScope = Nothing
		Dim imageByte() As Byte = Nothing
		Try
			impersonationScope = New UserImpersonationScope(userName, domainName, password, True)

			Dim stream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
			Dim reader As BinaryReader = New BinaryReader(stream)

			imageByte = reader.ReadBytes(stream.Length)

			reader.Close()
			stream.Close()


		Catch ex As Exception
			If filePath Is Nothing Then
				Throw New Exception("Error reading file - no file name provided, Username - " & userName & "| domaianname=" & domainName & "| password=" & password, ex)
			Else
				Throw New Exception("Error reading file " & filePath & ", Username - " & userName & "| domaianname=" & domainName & "| password=" & password, ex)
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

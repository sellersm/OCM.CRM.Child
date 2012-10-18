Imports Blackbaud.AppFx.Server
Imports System.IO
Imports System.Data.SqlClient
Imports Blackbaud.AppFx.SpWrap

Friend NotInheritable Class ImpersonationHelper

    Friend Shared Function GetImpersonationScope(ByVal usernameAndDomain As String, ByVal password As String) As UserImpersonationScope
        Dim domain = String.Empty
        Dim userName = String.Empty

        ParseDomainAndUserName(usernameAndDomain, domain, userName)

        Return New UserImpersonationScope(userName, domain, password)
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

    Friend Shared Sub GrantRightsToFileForImportUser(ByVal impersonateUserName As String, ByVal filePath As String)

        Dim domain As String = Nothing
        Dim userName As String = Nothing

        ParseDomainAndUserName(impersonateUserName, domain, userName)

        Dim importUserAccount As New Security.Principal.NTAccount(domain, userName)

        'TWG 06/02/2009 Because File.Move is not being used instead of copy, import user must have read, write, delete privledges
        Dim rule As New Security.AccessControl.FileSystemAccessRule(importUserAccount, Security.AccessControl.FileSystemRights.Read Or Security.AccessControl.FileSystemRights.Write Or Security.AccessControl.FileSystemRights.Delete, Security.AccessControl.AccessControlType.Allow)

        Dim fileSecurity As Security.AccessControl.FileSecurity = File.GetAccessControl(filePath)
        fileSecurity.AddAccessRule(rule)

        File.SetAccessControl(filePath, fileSecurity)

    End Sub

    Friend Shared Function GetOptions(ByVal conn As SqlConnection) As USP_IMPORTPROCESSOPTIONS_GET.ResultRow

        Return USP_IMPORTPROCESSOPTIONS_GET.ExecuteRow(conn)

    End Function

    Friend Shared Function GetImportReadFileStream(ByVal fileName As String, ByVal impersonate As Boolean, ByVal userNameDomain As String, ByVal password As String) As Stream
        Dim impersonationScope As UserImpersonationScope = Nothing

        If impersonate Then
            impersonationScope = ImpersonationHelper.GetImpersonationScope(userNameDomain, password)
        End If
        Try
            Return New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)
        Finally
            If impersonationScope IsNot Nothing Then
                impersonationScope.Dispose()
            End If
        End Try
    End Function

    Friend Shared Function GetImportWriteFileStream(ByVal fileName As String, ByVal impersonate As Boolean, ByVal userNameDomain As String, ByVal password As String) As Stream
        Dim impersonationScope As UserImpersonationScope = Nothing

        If impersonate Then
            impersonationScope = ImpersonationHelper.GetImpersonationScope(userNameDomain, password)
        End If
        Try
            Return New FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)
        Finally
            If impersonationScope IsNot Nothing Then
                impersonationScope.Dispose()
            End If
        End Try
    End Function
End Class

CREATE PROCEDURE [dbo].[InsertExternalIdentityLoginLog]
	@SubjectId UNIQUEIDENTIFIER,
	@Provider NVARCHAR(255),
	@Timestamp DATETIMEOFFSET(7),
	@IpAddress NVARCHAR(40)	
AS

INSERT INTO [ExternalIdentityLoginLogs] ([ExternalIdentityId], [Timestamp], [IpAddress])
	(SELECT TOP 1 ei.[Id], @Timestamp, @IpAddress
	FROM [ExternalIdentities] ei
	JOIN [ExternalIdentityProviders] eip ON ei.[ExternalProviderId] = eip.[Id]
	WHERE ei.[UserId] = @SubjectId AND eip.[Name] = @Provider)

RETURN @@ROWCOUNT

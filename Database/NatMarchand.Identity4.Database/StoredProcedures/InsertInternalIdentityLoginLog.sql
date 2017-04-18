CREATE PROCEDURE [dbo].[InsertInternalIdentityLoginLog]
	@SubjectId UNIQUEIDENTIFIER,
	@Timestamp DATETIMEOFFSET(7),
	@IpAddress NVARCHAR(40)	
AS

INSERT INTO [InternalIdentityLoginLogs] ([InternalIdentityId], [Timestamp], [IpAddress])
	(SELECT TOP 1 [Id], @Timestamp, @IpAddress
	FROM [InternalIdentities]
	WHERE [UserId] = @SubjectId)

RETURN @@ROWCOUNT

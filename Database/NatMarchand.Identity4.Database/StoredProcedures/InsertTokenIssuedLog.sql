CREATE PROCEDURE [dbo].[InsertTokenIssuedLog]
	@SubjectId UNIQUEIDENTIFIER,
	@ClientId NVARCHAR(255),
	@Timestamp DATETIMEOFFSET(7),
	@IpAddress NVARCHAR(40),
	@Scopes NVARCHAR(MAX)
AS

INSERT INTO [TokenIssuedLogs] ([UserId], [ClientId], [Timestamp], [IpAddress], [Scopes])
	VALUES (@SubjectId, @ClientId, @Timestamp, @IpAddress, @Scopes)

RETURN @@ROWCOUNT

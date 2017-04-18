CREATE PROCEDURE [dbo].[GetUserByInternalIdentity]
	@UserName nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SELECT TOP 1 u.[Id] AS [SubjectId], cv.[Value] AS [Name], u.[IsActive], u.[Timestamp]
	FROM [dbo].[Users] u
	JOIN [dbo].[InternalIdentities] i ON u.[Id] = i.[UserId]
	JOIN [dbo].[ClaimTypes] ct
	JOIN [dbo].[ClaimValues] cv ON ct.[Id] = cv.[ClaimTypeId] ON cv.[UserId] = u.[Id]
	WHERE i.[UserName] = @UserName
		AND HASHBYTES('SHA2_256', CAST((i.[Salt] + @Password) AS VARCHAR)) = i.[HashedPassword]
		AND ct.Name = 'name'
END;
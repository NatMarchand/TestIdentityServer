CREATE PROCEDURE [dbo].[GetUserByExternalIdentity]
	@Provider nvarchar(255),
	@UserId nvarchar(255)
AS
BEGIN
	SELECT TOP 1 u.[Id] AS [SubjectId], cv.[Value] AS [Name], u.[IsActive], u.[Timestamp]
	FROM [dbo].[Users] u
	JOIN [dbo].[ExternalIdentities] i ON u.[Id] = i.[UserId]
	JOIN [dbo].[ExternalIdentityProviders] ip ON i.[ExternalProviderId] = ip.[Id]
	JOIN [dbo].[ClaimTypes] ct
	JOIN [dbo].[ClaimValues] cv ON ct.[Id] = cv.[ClaimTypeId] ON cv.[UserId] = u.[Id]
	WHERE ip.[Name] = @Provider
		AND i.[ExternalUserId] = @UserId
		AND ct.Name = 'name'
END;
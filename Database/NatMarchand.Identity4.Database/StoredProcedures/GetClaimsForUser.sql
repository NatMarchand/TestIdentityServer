CREATE PROCEDURE [dbo].[GetClaimsForUser]
	@SubjectId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT [ct].[Name] AS [Type], [cv].[Value], [cv].[Timestamp]
	FROM [ClaimTypes] ct
	JOIN [ClaimValues] cv ON [ct].[Id] = [cv].[ClaimTypeId]
	WHERE [cv].[UserId] = @SubjectId
END;
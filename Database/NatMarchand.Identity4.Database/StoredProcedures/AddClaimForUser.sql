CREATE PROCEDURE [dbo].[AddClaimForUser]
	@SubjectId UNIQUEIDENTIFIER,
	@ClaimType NVARCHAR(255),
	@ClaimValue NVARCHAR(255)
AS
BEGIN
	MERGE [ClaimTypes] AS [target]
	USING (SELECT @ClaimType) AS [source] ([Name])
		ON [target].[Name] = [source].[Name]
	WHEN NOT MATCHED THEN
	INSERT ([Name]) VALUES ([source].[Name]);

	
	INSERT INTO [ClaimValues] ([UserId], [ClaimTypeId], [Value])
		SELECT @SubjectId AS [UserId], [Id], @ClaimValue
		FROM [ClaimTypes]
		WHERE [Name] = @ClaimType
END;
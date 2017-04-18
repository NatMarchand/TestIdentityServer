CREATE PROCEDURE [dbo].[GetIsUserActive]
	@SubjectId UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @Count AS INT	
	SELECT @Count = COUNT(1) FROM [Users] WHERE [Id] = @SubjectId AND [IsActive] = 1	
	RETURN IIF(@Count = 1, 1, 0)
END;

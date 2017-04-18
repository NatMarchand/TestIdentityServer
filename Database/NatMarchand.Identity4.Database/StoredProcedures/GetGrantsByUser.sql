CREATE PROCEDURE [dbo].[GetGrantsByUser]
	@SubjectId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT * FROM [Grants] WHERE [SubjectId] = @SubjectId
END

CREATE PROCEDURE [dbo].[DeleteGrants]
	@SubjectId UNIQUEIDENTIFIER,
	@ClientId NVARCHAR(255),
	@Type NVARCHAR(255) = NULL
AS
BEGIN
	DELETE FROM [Grants]
		WHERE [SubjectId] = @SubjectId
			AND [ClientId] = @ClientId
			AND (@Type IS NULL OR [Type] = @Type)
	RETURN @@ROWCOUNT
END

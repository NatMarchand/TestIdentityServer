CREATE PROCEDURE [dbo].[UpsertGrant]
	@Key NVARCHAR(255),
	@Type NVARCHAR(255),
	@SubjectId UNIQUEIDENTIFIER,
	@ClientId NVARCHAR(255),
	@CreationTime DATETIMEOFFSET,
	@Expiration DATETIMEOFFSET,
	@Data NVARCHAR(MAX)
AS
BEGIN
	MERGE [Grants] AS [Source]
		USING (SELECT @Key) AS [Target] ([Key])
			ON [Source].[Key] = [Target].[Key]
		WHEN MATCHED THEN
			UPDATE SET [Type] = @Type,
				[SubjectId] = @SubjectId,
				[ClientId] = @ClientId,
				[CreationTime] = @CreationTime,
				[Expiration] = @Expiration,
				[Data] = @Data
		WHEN NOT MATCHED BY TARGET THEN
			INSERT ([Key], [Type], [SubjectId], [ClientId], [CreationTime], [Expiration], [Data])
				VALUES (@Key, @Type, @SubjectId, @ClientId, @CreationTime, @Expiration, @Data);
END;

CREATE TABLE [dbo].[Users] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [IsActive]	BIT NOT NULL,
    [Timestamp] ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

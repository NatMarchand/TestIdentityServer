CREATE TABLE [dbo].[ClaimTypes]
(
	[Id] INT IDENTITY NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,
	[Timestamp] ROWVERSION       NOT NULL,
	CONSTRAINT [PK_ClaimTypes] PRIMARY KEY CLUSTERED ([Id])
)

GO

CREATE UNIQUE INDEX [UQ_ClaimTypes_Name] ON [dbo].[ClaimTypes] ([Name])

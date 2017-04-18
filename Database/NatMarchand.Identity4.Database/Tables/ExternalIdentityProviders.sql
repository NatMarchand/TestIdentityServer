CREATE TABLE [dbo].[ExternalIdentityProviders]
(
	[Id]		INT IDENTITY	NOT NULL,
	[Name]		NVARCHAR(255)	NOT NULL,
	[Timestamp]	ROWVERSION		NOT NULL,
	CONSTRAINT [PK_ExternalIdentityProviders] PRIMARY KEY CLUSTERED ([Id] ASC)
)

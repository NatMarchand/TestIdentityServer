CREATE TABLE [dbo].[ExternalIdentities] (
    [Id]					INT IDENTITY		NOT NULL ,    
	[UserId]				UNIQUEIDENTIFIER	NOT NULL,
	[ExternalProviderId]	INT					NOT NULL,
	[ExternalUserId]		NVARCHAR(255)		NOT NULL,
	[Timestamp]				ROWVERSION			NOT NULL,
    CONSTRAINT [PK_ExternalIdentities] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_ExternalIdentities_Profiles] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) ON UPDATE CASCADE ON DELETE CASCADE, 
    CONSTRAINT [FK_ExternalIdentities_ExternalIdentityProviders] FOREIGN KEY ([ExternalProviderId]) REFERENCES [ExternalIdentityProviders]([Id]) ON UPDATE CASCADE ON DELETE CASCADE
);

GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_ExternalIdentities_ExternalProviderId_ExternalUserId] ON [dbo].[ExternalIdentities]([ExternalProviderId], [ExternalUserId]);

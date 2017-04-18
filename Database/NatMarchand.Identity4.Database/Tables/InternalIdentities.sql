CREATE TABLE [dbo].[InternalIdentities] (
    [Id]        INT NOT NULL IDENTITY,
    [UserId]	UNIQUEIDENTIFIER NOT NULL,
	[UserName]     NVARCHAR (255)   NOT NULL,
    [HashedPassword]  BINARY (32)      NOT NULL,
    [Salt]      NVARCHAR (255)   NOT NULL,
	[FailedLoginCount] INT NOT NULL,
    [Timestamp] ROWVERSION       NOT NULL,
    CONSTRAINT [PK_InternalIdentities] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_InternalIdentities_Profiles] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) ON UPDATE CASCADE ON DELETE CASCADE
);

GO

CREATE NONCLUSTERED INDEX [IX_InternalIdentities_UserName] ON [dbo].[InternalIdentities]([UserName] ASC) INCLUDE ([HashedPassword], [Salt]);

GO

CREATE UNIQUE INDEX [UQ_InternalIdentities_UserName] ON [dbo].[InternalIdentities] ([UserName])
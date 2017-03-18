CREATE TABLE [dbo].[InternalUsers] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Login]     NVARCHAR (255)   NOT NULL,
    [HashedPassword]  BINARY (32)      NOT NULL,
    [Salt]      NVARCHAR (255)   NOT NULL,
	[ProfileId]	INT NOT NULL,
    [Timestamp] ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_InternalUsers_Profiles] FOREIGN KEY ([ProfileId]) REFERENCES [Profiles]([Id]) 
);


GO

CREATE NONCLUSTERED INDEX [IX_InternalUsers_Login_Password] ON [dbo].[InternalUsers]([Login] ASC, [HashedPassword] ASC);

GO

CREATE UNIQUE INDEX [IX_InternalUsers_Login] ON [dbo].[InternalUsers] ([Login])

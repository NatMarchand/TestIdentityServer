CREATE TABLE [dbo].[ClientRedirectUris] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ClientId]    INT            NOT NULL,
    [RedirectUri] NVARCHAR (255) NOT NULL,
    [Timestamp]   ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ClientRedirectUris] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClientRedirectUris_Clients] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ClientRedirectUris_ClientId]
    ON [dbo].[ClientRedirectUris]([ClientId] ASC);


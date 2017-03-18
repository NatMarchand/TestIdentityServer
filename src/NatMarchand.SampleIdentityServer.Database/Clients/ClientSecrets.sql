CREATE TABLE [dbo].[ClientSecrets] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [ClientId]  INT            NOT NULL,
    [Secret]    NVARCHAR (255) NOT NULL,
    [Timestamp] ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ClientSecrets] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClientSecrets_Clients] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ClientSecrets_ClientId]
    ON [dbo].[ClientSecrets]([ClientId] ASC);

CREATE TABLE [dbo].[Clients] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ClientId]   NVARCHAR (32)  NOT NULL,
    [ClientName] NVARCHAR (255) NOT NULL,
    [IsEnabled]  BIT            NOT NULL,
    [Flow]       NVARCHAR (32)  NOT NULL,
    [Timestamp]  ROWVERSION     NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Clients_ClientId]
    ON [dbo].[Clients]([ClientId] ASC);
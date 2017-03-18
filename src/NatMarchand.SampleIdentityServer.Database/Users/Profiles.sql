CREATE TABLE [dbo].[Profiles] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [Email]     NVARCHAR (255)   NOT NULL,
    [FirstName] NVARCHAR (255)   NOT NULL,
    [LastName]  NVARCHAR (255)   NOT NULL,
    [Timestamp] ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


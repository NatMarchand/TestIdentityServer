CREATE TABLE [dbo].[Grants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
	[SubjectId] [uniqueidentifier] NOT NULL,
	[ClientId] [nvarchar](255) NOT NULL,
	[CreationTime] [datetimeoffset](7) NOT NULL,
	[Expiration] [datetimeoffset](7) NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Grants] PRIMARY KEY CLUSTERED  ([Id])
)

GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_Grants_Key] ON [dbo].[Grants] ([Key] ASC)
GO

CREATE NONCLUSTERED INDEX [IX_Grants_SubjectId_ClientId_Type] ON [dbo].[Grants]([SubjectId] ASC,[ClientId] ASC)
GO


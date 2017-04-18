CREATE TABLE [dbo].[ExternalIdentityLoginLogs]
(
	[ExternalIdentityId] INT NOT NULL,
	[Timestamp] DATETIMEOFFSET(7) NOT NULL,
	[IpAddress] NVARCHAR(40)NOT NULL

	CONSTRAINT [PK_ExternalIdentityLoginLogs] PRIMARY KEY CLUSTERED ([ExternalIdentityId], [Timestamp]), 
    CONSTRAINT [FK_ExternalIdentityLoginLogs_ExternalIdentities] FOREIGN KEY ([ExternalIdentityId]) REFERENCES [ExternalIdentities]([Id]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
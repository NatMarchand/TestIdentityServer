CREATE TABLE [dbo].[InternalIdentityLoginLogs]
(
	[InternalIdentityId] INT NOT NULL,
	[Timestamp] DATETIMEOFFSET(7) NOT NULL,
	[IpAddress] NVARCHAR(40) NOT NULL

	CONSTRAINT [PK_InternalIdentityLoginLogs] PRIMARY KEY CLUSTERED ([InternalIdentityId], [Timestamp]), 
    CONSTRAINT [FK_InternalIdentityLoginLogs_InternalIdentities] FOREIGN KEY ([InternalIdentityId]) REFERENCES [InternalIdentities]([Id]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
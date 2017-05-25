CREATE TABLE [dbo].[OpenIddictTokens] (
    [Id]              NVARCHAR (450) NOT NULL,
    [ApplicationId]   NVARCHAR (450) NULL,
    [AuthorizationId] NVARCHAR (450) NULL,
    [Subject]         NVARCHAR (MAX) NULL,
    [Type]            NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_OpenIddictTokens] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OpenIddictTokens_OpenIddictApplications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[OpenIddictApplications] ([Id]),
    CONSTRAINT [FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId] FOREIGN KEY ([AuthorizationId]) REFERENCES [dbo].[OpenIddictAuthorizations] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_OpenIddictTokens_AuthorizationId]
    ON [dbo].[OpenIddictTokens]([AuthorizationId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OpenIddictTokens_ApplicationId]
    ON [dbo].[OpenIddictTokens]([ApplicationId] ASC);


CREATE TABLE [dbo].[UserPermissions] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [UserProfileId] NVARCHAR (450) NULL,
    [Value]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPermissions_UserProfiles_UserProfileId] FOREIGN KEY ([UserProfileId]) REFERENCES [dbo].[UserProfiles] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserPermissions_UserProfileId]
    ON [dbo].[UserPermissions]([UserProfileId] ASC);


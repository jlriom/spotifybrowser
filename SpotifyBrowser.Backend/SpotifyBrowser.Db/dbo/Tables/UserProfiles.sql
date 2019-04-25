CREATE TABLE [dbo].[UserProfiles] (
    [Id]          NVARCHAR (450) NOT NULL,
    [Email]       NVARCHAR (MAX) NULL,
    [FirstName]   NVARCHAR (MAX) NULL,
    [LastName]    NVARCHAR (MAX) NULL,
    [UserState] INT            NOT NULL DEFAULT 0,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


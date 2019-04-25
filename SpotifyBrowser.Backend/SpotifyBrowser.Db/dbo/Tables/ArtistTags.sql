CREATE TABLE [dbo].[ArtistTags] (
    [UserId]  NVARCHAR (500) NOT NULL,
    [ArtistId] NVARCHAR (500) NOT NULL,
    [Tag]     NVARCHAR (500) NOT NULL,
    CONSTRAINT [PK_ArtistTags] PRIMARY KEY ([UserId] ASC, [ArtistId] ASC, [Tag] ASC) 
);

CREATE TABLE [dbo].[AlbumTags] (
    [UserId]  NVARCHAR (500) NOT NULL,
    [AlbumId] NVARCHAR (500) NOT NULL,
    [Tag]     NVARCHAR (500) NOT NULL,
    CONSTRAINT [PK_AlbumTags] PRIMARY KEY ([UserId] ASC, [AlbumId] ASC, [Tag] ASC) 
);

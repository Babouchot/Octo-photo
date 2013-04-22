CREATE TABLE [dbo].[Photo] (
    [id]      INT   IDENTITY (1, 1) NOT NULL,
    [size]    INT   NOT NULL,
    [blob]    IMAGE NOT NULL,
    [idAlbum] INT   NOT NULL
);


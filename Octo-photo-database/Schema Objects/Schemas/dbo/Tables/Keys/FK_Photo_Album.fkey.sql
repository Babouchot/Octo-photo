﻿ALTER TABLE [dbo].[Photo]
    ADD CONSTRAINT [FK_Photo_Album] FOREIGN KEY ([idAlbum]) REFERENCES [dbo].[Album] ([idAlbum]) ON DELETE NO ACTION ON UPDATE NO ACTION;


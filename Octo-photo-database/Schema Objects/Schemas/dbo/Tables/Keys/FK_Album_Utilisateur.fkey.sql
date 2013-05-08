ALTER TABLE [dbo].[Album]
    ADD CONSTRAINT [FK_Album_Utilisateur] FOREIGN KEY ([idUtilisateur]) REFERENCES [dbo].[Utilisateur] ([idUtilisateur]) ON DELETE CASCADE ON UPDATE NO ACTION;




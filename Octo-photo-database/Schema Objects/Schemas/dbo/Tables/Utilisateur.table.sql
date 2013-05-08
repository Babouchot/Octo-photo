CREATE TABLE [dbo].[Utilisateur] (
    [idUtilisateur] INT        IDENTITY (1, 1) NOT NULL,
    [nom]           NCHAR (50) NOT NULL,
    [prenom]        NCHAR (50) NOT NULL,
    [password]     NCHAR (30) NOT NULL
);




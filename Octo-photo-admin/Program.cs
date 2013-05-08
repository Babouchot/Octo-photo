using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octo_photo_library;

namespace Octo_photo_admin
{
    class Program
    {

        private static String version = "1.0";

        static void Main(string[] args)
        {

            Console.WriteLine("Bienvenue sur le client d'administration d'Octo-photo (version "
                + version + ")\n\nUtilisation : \n" +
                "rm user    Supprimer un utilisateur de la base de données\n" +
                "rm album   Supprimer un album photo de la base de données\n" +
                "rm photo   Supprimer une photo de la base de données\n");

            ImageTransfertServiceReference.ImageTransfertClient imageTransfertService =
                new ImageTransfertServiceReference.ImageTransfertClient();

            while (true)
            {
                Console.Write(">>> ");
                String line = Console.ReadLine();
                switch (line)
                {
                    case "rm user":
                        Console.WriteLine("Vous avez choisi de supprimer un utilisateur,\nveuillez spécifier son identifiant : ");
                        Console.Write("User ID : ");
                        String user = Console.ReadLine();
                        try
                        {
                            imageTransfertService.deleteUser(int.Parse(user));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("commande invalide : entrez un id (nombre entier)");
                        }
                        Console.WriteLine();
                        break;

                    case "rm album":
                        Console.WriteLine("Vous avez choisi de supprimer un album,\nveuillez spécifier son identifiant : ");
                        Console.Write("ID de l'album : ");
                        String album = Console.ReadLine();
                        try
                        {
                            imageTransfertService.deleteAlbum(int.Parse(album));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("commande invalide : entrez un id (nombre entier)");
                        }
                        Console.WriteLine();
                        break;

                    case "rm photo":
                        Console.WriteLine("Vous avez choisi de supprimer une photo,\nveuillez spécifier son identifiant : ");
                        Console.Write("ID de la photo : ");
                        String photo = Console.ReadLine();
                        try
                        {
                            imageTransfertService.deletePhoto(int.Parse(photo));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("commande invalide : entrez un id (nombre entier)");
                        }
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Commande non reconnue ! veuillez réessayer.\n");
                        break;
                }
            }
        }
    }
}
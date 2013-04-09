using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octo_photo_library;

namespace Octo_photo_admin
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">>>");
                String line = Console.ReadLine();
                if (line == "add")
                {
                    Console.WriteLine("Vous avez choisi d'ajouter une image, veuillez spécifier le chemin : ");
                    Console.Write("chemin :");
                    String path = Console.ReadLine();
                    ImageInterface im = new ImageInterface();
                }
                else if (line == "rm")
                {
                    Console.WriteLine("Mais t'es pas ouf !!");
                }
            }

        }
    }
}
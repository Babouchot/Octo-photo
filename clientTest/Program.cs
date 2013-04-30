using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace clientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciation de la référence de service 
            imageTransfert.ImageTransfertClient imageTransfertService = new imageTransfert.ImageTransfertClient();
            MemoryStream imageStream = new MemoryStream(lireFichier(@"C:\Users\user\Pictures\absorbeur.PNG"));
            // Appel de notre web method 
            imageTransfertService.UploadImage(imageStream);
            Console.Out.WriteLine("Transfert Terminé");
            Console.ReadLine(); 
        }

        /// <summary> 
        /// Lit et retourne le contenu du fichier sous la forme de tableau de byte 
        /// </summary> 
        /// <param name="chemin">chemin du fichier</param> 
        /// <returns></returns> 
        private static byte[] lireFichier(string chemin)
        {
            byte[] data = null;
            FileInfo fileInfo = new FileInfo(chemin);
            int nbBytes = (int)fileInfo.Length;
            FileStream fileStream = new FileStream(chemin, FileMode.Open,
            FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            data = br.ReadBytes(nbBytes);
            return data;
        } 
    }
}

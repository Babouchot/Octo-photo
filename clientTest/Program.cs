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
            ImageTransfertServiceReference.ImageTransfertClient imageTransfertService = new ImageTransfertServiceReference.ImageTransfertClient();
            MemoryStream imageStream = new MemoryStream(lireFichier(@"C:\Users\user\Pictures\absorbeur.PNG"));
            ImageTransfertServiceReference.ImageInfo info = new ImageTransfertServiceReference.ImageInfo();
            info.ID = "Plop2";
            info.idAlbum = 1;
            ImageTransfertServiceReference.ImageUploadRequest request = new ImageTransfertServiceReference.ImageUploadRequest();
            request.ImageData = imageStream;
            request.ImageInfo = info;
            // Appel de notre web method
            imageTransfertService.UploadImage(info, imageStream);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using Octo_photo_library;

namespace Octo_photo_wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ImageTransfert" à la fois dans le code, le fichier svc et le fichier de configuration.
    public class ImageTransfert : IImageTransfert
    {
        // la classe AccesDonnees n’est pas donnée ici 
        private ImageInterface bdAccess = new ImageInterface();

        public String UploadImage(Stream image)
        {
            // Stocker l’image en BDD
            byte[] imageBytes = null;
            MemoryStream imageStreamEnMemoire = new MemoryStream();
            image.CopyTo(imageStreamEnMemoire);
            imageBytes = imageStreamEnMemoire.ToArray();
            //String imageID = bdAccess.addImage(idAlbum, image);
            imageStreamEnMemoire.Close();
            image.Close();
            //return imageID;
            return "plop";
        }


        public Stream DownloadImage(String imageID)
        {
            // Récupérer l'image stockée en BDD et la transférer au client
            byte[] imageBytes = bdAccess.getImage(imageID);
            MemoryStream imageStreamEnMemoire = new MemoryStream(imageBytes);
            return imageStreamEnMemoire;
        }
    }
}

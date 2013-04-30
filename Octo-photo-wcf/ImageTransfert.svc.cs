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

        public void UploadImage(ImageUploadRequest data)
        {
            // Stocker l’image en BDD
            byte[] imageBytes = null;
            MemoryStream imageStreamEnMemoire = new MemoryStream();
            data.ImageData.CopyTo(imageStreamEnMemoire);
            imageBytes = imageStreamEnMemoire.ToArray();

            String imageID = bdAccess.addImage(data.ImageInfo.idAlbum, imageBytes);
            imageStreamEnMemoire.Close();
            data.ImageData.Close();
        }


        public ImageDownloadResponse DownloadImage(ImageDownloadRequest imageID)
        {
            // Récupérer l'image stockée en BDD et la transférer au client
            byte[] imageBytes = bdAccess.getImage(imageID.ImageInfo.ID);
            MemoryStream imageStreamEnMemoire = new MemoryStream(imageBytes);
            ImageDownloadResponse response = new ImageDownloadResponse();
            response.ImageData = imageStreamEnMemoire;
            return response;
        }
    }
}

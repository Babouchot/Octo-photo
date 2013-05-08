using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace Octo_photo_wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IImageTransfert" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IImageTransfert
    {
        [OperationContract]
        void UploadImage(ImageUploadRequest data);

        [OperationContract]
        ImageDownloadResponse DownloadImage(ImageDownloadRequest data);

        [OperationContract]
        void deleteUser(int id);

        [OperationContract]
        void deleteAlbum(int id);

        [OperationContract]
        void deletePhoto(int id);

        [OperationContract]
        void deletePhotoNom(String nom);

        [OperationContract]
        String[] getAlbum(int id);

        [OperationContract]
        int[] getUserAlbum(int id);
    }
    [MessageContract]
    public class ImageUploadRequest
    {
        [MessageHeader(MustUnderstand = true)]
        public ImageInfo ImageInfo;

        [MessageBodyMember(Order = 1)]
        public Stream ImageData;
    }
    [MessageContract]
    public class ImageDownloadResponse
    {
        [MessageBodyMember(Order = 1)]
        public Stream ImageData;
    }
    [MessageContract]
    public class ImageDownloadRequest
    {
        [MessageBodyMember(Order = 1)]
        public ImageInfo ImageInfo;
    }

    [DataContract]
    public class ImageInfo
    {
        [DataMember(Order = 1, IsRequired = true)]
        public string ID { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public int idAlbum { get; set; }
    }
}



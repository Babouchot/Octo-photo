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
        String UploadImage(Stream image);

        [OperationContract]
        Stream DownloadImage(String name);
    }
}

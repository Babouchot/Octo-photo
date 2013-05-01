using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ClientWeb
{
    public partial class VoirImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On récupére la valeur du paramètre ImageID passé dans l’URL
            String id = Request.QueryString["ImageID"];
            // Si ce paramètre n'est pas nul
            if (id != null)
            {
                // on récupére notre image là où il faut

                ImageTransfertServiceReference.ImageTransfertClient imageTransfertService = new ImageTransfertServiceReference.ImageTransfertClient();

                ImageTransfertServiceReference.ImageDownloadRequest request = new ImageTransfertServiceReference.ImageDownloadRequest();
                request.ImageInfo.ID = id;
                request.ImageInfo.idAlbum = 1;

                ImageTransfertServiceReference.ImageDownloadResponse reponse = new ImageTransfertServiceReference.ImageDownloadResponse();

                // Appel de notre web method
                reponse.ImageData = imageTransfertService.DownloadImage(request.ImageInfo);
                Stream image = reponse.ImageData;

                // et on crée le contenu de notre réponse à la requête HTTP
                // (ici un contenu de type image)
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/jpeg";
                Response.Write(image);
                Response.Flush();
                Response.End();
            }
        }

        protected void Visualiser_Click(object sender, EventArgs e)
        {
            ImageCourante.ImageUrl = "Image.aspx?ImageID=" + ImageIDBox.Text;
        }
    }
}
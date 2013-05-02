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

                ImageTransfertServiceReference.ImageInfo info = new ImageTransfertServiceReference.ImageInfo();
                info.ID = id;
                info.idAlbum = 1;

                ImageTransfertServiceReference.ImageDownloadResponse reponse = new ImageTransfertServiceReference.ImageDownloadResponse();

                // Appel de notre web method
                reponse.ImageData = imageTransfertService.DownloadImage(info);
                Stream image = reponse.ImageData;

                MemoryStream memStream = new MemoryStream();
                image.CopyTo(memStream);
                Byte[] bytes = memStream.ToArray();

                // et on crée le contenu de notre réponse à la requête HTTP
                // (ici un contenu de type image)
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }

        protected void Visualiser_Click(object sender, EventArgs e)
        {
            ImageCourante.ImageUrl = "VoirImage.aspx?ImageID=" + ImageIDBox.Text;
        }

        protected void Authentifier_Click(object sender, EventArgs e)
        {
            Session["user"] = UserTextBox.Text;
        }
    }
}
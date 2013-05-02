using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ClientWeb
{
    public partial class DeposerImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On récupére la valeur du text dans la TextBox
            String name = Request.QueryString["NomImage"];
            String path = Request.QueryString["Path"];
            // Si ce paramètre n'est pas nul
            if (name != null)
            {
                if (path != null)
                {
                    // Instanciation de la référence de service 
                    ImageTransfertServiceReference.ImageTransfertClient imageTransfertService = new ImageTransfertServiceReference.ImageTransfertClient();
                    MemoryStream imageStream = new MemoryStream(lireFichier(path));
                    ImageTransfertServiceReference.ImageInfo info = new ImageTransfertServiceReference.ImageInfo();
                    info.ID = name;
                    info.idAlbum = 1;
                    ImageTransfertServiceReference.ImageUploadRequest request = new ImageTransfertServiceReference.ImageUploadRequest();
                    request.ImageData = imageStream;
                    request.ImageInfo = info;
                    // Appel de notre web method
                    imageTransfertService.UploadImage(info, imageStream);
                    Session["transfert"] = "Transfert terminé";
                }
            }
        }
        protected void Deposer_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeposerImage.aspx?NomImage=" + NomImage.Text + "&Path=" + Path.Text);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
    public partial class VisualiserImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On récupére la valeur des paramètres
            String imageId = Request.QueryString["ImageID"];
            String albumId = Request.QueryString["AlbumID"];
            // Si ces paramètres ne sont pas nuls
            if (imageId != null && albumId != null)
            {
                NumeroAlbum.Text = albumId;
                ImageTransfertServiceReference.ImageTransfertClient imageTransfert =
                    new ImageTransfertServiceReference.ImageTransfertClient();
                try
                {
                    string[] album = imageTransfert.getAlbum(int.Parse(albumId));
                    albumImages.DataSource = album;
                }
                catch (FormatException)
                {
                    System.Diagnostics.Debug.WriteLine("Un nombre entier est requis");
                }
            }
        }

        protected void Visualiser_Click(object sender, EventArgs e)
        {
            ImageCourante.ImageUrl = "VisualiserAlbum.aspx?ImageID=" + albumImages.SelectedValue +
                "&AlbumID=" + NumeroAlbum.Text;
        }

        protected void albumImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageCourante.ImageUrl = "VisualiserAlbum.aspx?ImageID=" + albumImages.SelectedValue +
                "&AlbumID=" + NumeroAlbum.Text;
        }
    }
}
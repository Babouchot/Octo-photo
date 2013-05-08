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

        }

        protected void Visualiser_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("visualiser");
            ImageTransfertServiceReference.ImageTransfertClient imageTransfert =
                new ImageTransfertServiceReference.ImageTransfertClient();
            try
            {
                byte[][] album = imageTransfert.getAlbum(int.Parse(NumeroAlbum.Text));
            }
            catch (FormatException)
            {
                System.Diagnostics.Debug.WriteLine("Un nombre entier est requis");
            }
        }

        protected void albumImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageCourante.ImageUrl = "VisualiserAlbum.aspx?ImageID=" + albumImages.SelectedValue;
        }
    }
}
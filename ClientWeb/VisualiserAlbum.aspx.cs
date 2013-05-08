using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ClientWeb
{
    public partial class VisualiserImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Visualiser_Click(object sender, EventArgs e)
        {
            
        }
        
        protected void albumImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        protected void NewAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VisualiserAlbum.aspx");
        }
    }
}
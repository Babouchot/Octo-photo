using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ClientWPF
{
    public class ImageObjet
    {
        public String Nom { get; set; }
        public byte[] Image { get; set; }
        public ImageObjet(String Nom, byte[] Image)
        {
            this.Nom = Nom;
            this.Image = Image;
        }
    }
    public class ImageCollection : ObservableCollection<ImageObjet> {}
}

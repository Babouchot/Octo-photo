using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ClientWPF
{
    public class AlbumObjet
    {
        public String Nom { get; set; }
        public int idAlbum { get; set; }
        public int owner { get; set; }

        public AlbumObjet(String Nom, int idAlbum, int owner)
        {
            this.Nom = Nom;
            this.idAlbum = idAlbum;
            this.owner = owner;
        }
    }
    public class AlbumCollection : ObservableCollection<AlbumObjet> {}
}

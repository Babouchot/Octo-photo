using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Navigation;
using System.IO;
using System.Diagnostics;

namespace ClientWPF
{
    public partial class VoirAlbum : UserControl, ISwitchable
    {

        private ImageCollection listAlbum;
        private ImageCollection imageCollection;

        public VoirAlbum()
        {
            // Required to initialize variables
            InitializeComponent();

            listAlbum = new ImageCollection();
            imageCollection = new ImageCollection();

            ObjectDataProvider imageSource = (ObjectDataProvider)FindResource("ListeAlbum");
            imageSource.ObjectInstance = listAlbum;

            // On lie la collectionau ObjectDataProvider déclaré dans le fichier XAML
            ObjectDataProvider imageSource2 = (ObjectDataProvider)FindResource("ImageCollection");
            imageSource2.ObjectInstance = imageCollection;

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

        private void ListAlbum_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                imageCollection.Clear();
                ImageTransfertServiceReference.ImageTransfertClient transfertService = new ImageTransfertServiceReference.ImageTransfertClient();
                ListBox temp = (ListBox)sender;
                ImageObjet data = (ImageObjet)temp.SelectedItem;
                if (data != null)
                {
                    string[] parseNom = data.Nom.Split('-');
                    int numAlbum = int.Parse(parseNom[parseNom.Length - 1]);
                    String[] images = transfertService.getAlbum(numAlbum);

                    foreach (String s in images)
                    {
                        ImageTransfertServiceReference.ImageTransfertClient imageTransfertService = new ImageTransfertServiceReference.ImageTransfertClient();

                        ImageTransfertServiceReference.ImageInfo info = new ImageTransfertServiceReference.ImageInfo();
                        info.ID = s;
                        ImageTransfertServiceReference.ImageDownloadResponse reponse = new ImageTransfertServiceReference.ImageDownloadResponse();

                        // Appel de notre web method
                        reponse.ImageData = transfertService.DownloadImage(info);
                        Stream image = reponse.ImageData;
                        MemoryStream memStream = new MemoryStream();
                        image.CopyTo(memStream);
                        Byte[] bytes = memStream.ToArray();
                        imageCollection.Add(new ImageObjet(s, bytes));
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Le numéro d'album n'est pas un nombre");
            }
        }

        private void DownloadUserAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                listAlbum.Clear();
                imageCollection.Clear();
                ImageTransfertServiceReference.ImageTransfertClient transfertService = new ImageTransfertServiceReference.ImageTransfertClient();
                int[] numAlbum = transfertService.getUserAlbum(int.Parse(numeroUtilisateur.Text));
                foreach (int i in numAlbum)
                {
                    string temp = transfertService.getNomAlbum(i) + "\nAlbum-" + i;
                    listAlbum.Add(new ImageObjet(temp, lireFichier(System.IO.Path.GetFullPath("../../Menus/Dossier.png"))));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Le numéro d'album n'est pas un nombre");
            }
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
        #endregion
    }
}
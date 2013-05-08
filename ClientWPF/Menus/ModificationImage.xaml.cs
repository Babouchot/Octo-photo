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
    public partial class ModificationImage : UserControl, ISwitchable
    {
        private ImageCollection imageCollection1;
        private ImageCollection imageCollectionLocal;
        public ModificationImage()
        {
            InitializeComponent();

            //lecture des fichiers image en local.
            imageCollectionLocal = new ImageCollection();
            string[] files = Directory.GetFiles(@"C:\Users\Public\Pictures\Octo-Photo Images"); /// Stocke la liste des fichiers
            foreach (string s in files)
            {
                if (System.IO.Path.GetExtension(s).ToUpper().Equals(".JPG"))
                {
                    imageCollectionLocal.Add(new ImageObjet(System.IO.Path.GetFileNameWithoutExtension(s), lireFichier(s)));
                }

            }
            // On crée notre collection d'image et on y ajoute deux images
            imageCollection1 = new ImageCollection();
            // On lie la collection ObjectDataProvider déclaré dans le fichier XAML
            ObjectDataProvider imageSource = (ObjectDataProvider)FindResource("ImageCollection1");
            imageSource.ObjectInstance = imageCollection1;

            // On lie la collectionau ObjectDataProvider déclaré dans le fichier XAML
            ObjectDataProvider imageSource2 = (ObjectDataProvider)FindResource("ImageCollection2");
            imageSource2.ObjectInstance = imageCollectionLocal;
        }

        ListBox dragSource = null;
        // On initie le Drag and Drop
        private void ImageDragEvent(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }
        // On ajoute l'objet dans la nouvelle ListBox et on le supprime de l'ancienne
        private void ImageDropEvent(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            ImageObjet data = (ImageObjet)e.Data.GetData(typeof(ImageObjet));
            ((IList)dragSource.ItemsSource).Remove(data);
            ((IList)parent.ItemsSource).Add(data);
        }
        // On récupére l'objet que que l'on a dropé
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = (UIElement)source.InputHitTest(point);
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data =
                    source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = (UIElement)VisualTreeHelper.GetParent(element);
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
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

        private void DownloadAlbum_Click(object sender, EventArgs e)
        {
            //todo : charger les fichier un a un dans la listbox supérieur
            Debug.WriteLine("download");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //todo : sauvgarder les modif sur le serveur en uploadand les images ajouté.
            Debug.WriteLine("save");
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
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
	public partial class CreerAlbum : UserControl, ISwitchable
	{
		public CreerAlbum()
		{
			// Required to initialize variables
			InitializeComponent();
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

        private void creerAlbumButton_Click(object sender, EventArgs e)
        {
            ImageTransfertServiceReference.ImageTransfertClient transfertService = new ImageTransfertServiceReference.ImageTransfertClient();
            transfertService.createAlbum(albumNameBox.Text, int.Parse(userNumberBox.Text));
        }
	}
}
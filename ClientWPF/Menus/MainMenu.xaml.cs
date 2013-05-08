using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ClientWPF
{
	public partial class MainMenu : UserControl, ISwitchable
	{
		public MainMenu()
		{
            
			InitializeComponent();
		}

		private void modifierImageButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			Switcher.Switch(new ModificationImage());
		}

		private void voirAlbumButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			Switcher.Switch(new VoirAlbum());
		}
        private void creerAlbumButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(new CreerAlbum());
        }

        #region Event For Child Window
        private void loginWindowForm_SubmitClicked(object sender, EventArgs e)
        {
        }

        private void registerForm_SubmitClicked(object sender, EventArgs e)
        {
        }

        #endregion

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void loginTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Switcher.Switch(new Login());
        }

        private void registerTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	Switcher.Switch(new Register());
        }
        #endregion
		
	}
}
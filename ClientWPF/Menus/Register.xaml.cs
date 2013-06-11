using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientWPF
{
	/// <summary>
	/// Interaction logic for Register.xaml
	/// </summary>
	public partial class Register : UserControl
	{
		public Register()
		{
			this.InitializeComponent();
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			Switcher.Switch(new MainMenu());
		}

        private void Register_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!(lastNameTextBox.Text.Equals("") || firstNameTextBox.Text.Equals("") || passwordBox1.Password.Equals("")))
            {
                if (passwordBox1.Password.Equals(passwordBox2.Password))
                {
                    ImageTransfertServiceReference.ImageTransfertClient transfertService = new ImageTransfertServiceReference.ImageTransfertClient();
                    transfertService.createUser(lastNameTextBox.Text, firstNameTextBox.Text, passwordBox1.Password);
                    validation.Text = "Vous avez bien été enregistré";
                    validation.Background = Brushes.Green;
                }
                else
                {
                    validation.Text = "Les mots de passe sont différents";
                    validation.Background = Brushes.Red;
                }
            }
            else
            {
                validation.Text = "Tous les champs doivent être rempli";
                validation.Background = Brushes.Red;
            }

        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Edycja
{
    /// <summary>
    /// Interaction logic for UserDlg.xaml
    /// </summary>
    public partial class UserDlg : Window
    {
        private string z = string.Empty;
        public UserDlg()
        {
            InitializeComponent();
        }
        public string getName { get; set; }
        public string getSurname { get; set; }
        public string getEmail { get; set; }
        private void addNew(object sender, RoutedEventArgs e)
        {
            getName=name.Text;
            getSurname = surname.Text;
            
            try
            {
                var addr = new System.Net.Mail.MailAddress(email.Text);
                getEmail = email.Text;
                DialogResult = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Podany tekst nie jest adresem email", "Błędny email", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }

        private void doNothing(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            
            this.Close();
        }

        private void load(object sender, RoutedEventArgs e)
        {
            name.Text = getName;
            surname.Text = getSurname;
            email.Text = getEmail;
        }

        private void check(object sender, TextChangedEventArgs e)
        {
            if(name.Text==z || surname.Text==z || email.Text==z)
            {
                ok.IsEnabled = false;
            }
            else
            {
                ok.IsEnabled = true;
            }
        }
    }
}

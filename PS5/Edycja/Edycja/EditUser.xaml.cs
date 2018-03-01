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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public int var;
        public EditUser()
        {
            var = 1;
            InitializeComponent();
        }
        public string getName { get; set; }
        public string getSurname { get; set; }
        public string getEmail { get; set; }
        public int getX { get; set; }
        private void closeEditUser(object sender, RoutedEventArgs e)
        {
            if(name.Text!=string.Empty && surname.Text != string.Empty && var==1)
            {
                ((MainWindow)Application.Current.MainWindow).ustawX(0,getX);
                this.Close();

            }
            else
            {
                MessageBox.Show("Uzupełnij poprawnie dane","Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void load(object sender, RoutedEventArgs e)
        {
            name.Text = getName;
            surname.Text = getSurname;
            email.Text = getEmail;
        }
        
        private void nameChange(object sender, TextChangedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).changeName(name.Text, getX);
            if(name.Text==string.Empty)
            {
                ((MainWindow)Application.Current.MainWindow).block();
                
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).unlock();
                ((MainWindow)Application.Current.MainWindow).unlockButtons();
                ((App)Application.Current).UpdateEdit(name.Text, surname.Text, email.Text, getX);
            }
        }

        private void surnameChange(object sender, TextChangedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).changeSurname(surname.Text, getX);
            if (surname.Text == string.Empty)
            {
                ((MainWindow)Application.Current.MainWindow).block();
                
            }
            else
            {
                ((MainWindow)Application.Current.MainWindow).unlock();
                ((MainWindow)Application.Current.MainWindow).unlockButtons();
                ((App)Application.Current).UpdateEdit(name.Text, surname.Text, email.Text, getX);
            }
        }

        private void emailChange(object sender, TextChangedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).changeEmail(email.Text, getX);
            try
            {
                var addr = new System.Net.Mail.MailAddress(email.Text);
                ((MainWindow)Application.Current.MainWindow).unlock();
                ((App)Application.Current).UpdateEdit(name.Text, surname.Text, email.Text, getX);
                var = 1;
            }
            catch
            {
                ((MainWindow)Application.Current.MainWindow).block();
                var = 0;
            }
        }
        public void Update(string _name, string _surname, string _email, int x)
        {
            getX = x;
            name.Text = _name;
            surname.Text = _surname;
            email.Text = _email;
            
        }
        public void UpdateEditt(string _name, string _surname, string _email, int x)
        {
            getX = x;
            name.Text = _name;
            surname.Text = _surname;
            email.Text = _email;
        }
        public void Closing2()
        {
            this.Close();
        }
    }
}

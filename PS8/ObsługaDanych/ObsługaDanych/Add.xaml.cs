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

namespace ObsługaDanych
{
    /// <summary>
    /// Logika interakcji dla klasy Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }
        public string getName { get; set; }
        public string getSurname { get; set; }
        public string getEmail { get; set; }
        public string getPassword { get; set; }
        public decimal getSalary { get; set; }
        public int getAge { get; set; }

        private void addNewUser(object sender, RoutedEventArgs e)
        {
            getName = Name.Text;
            getSurname = Surname.Text;
            getEmail = Email.Text;
            getPassword = Password.Text;
            if(checkData())
            {
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Wprowadzone dane są błędne. Popraw je.");
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private bool checkData()
        {
            if(Name.Text == string.Empty || Surname.Text == string.Empty || Password.Text.Length < 6 || Email.Text == string.Empty || Salary.Text == string.Empty || Age.Text == string.Empty)
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email.Text);
                getSalary = Decimal.Parse(Salary.Text);
                getAge = Int32.Parse(Age.Text);
            }
            catch
            {
                return false;
            }
            if(getAge < 0 && getSalary < 0)
            {
                return false;
            }
            return true;
        }
    }
}

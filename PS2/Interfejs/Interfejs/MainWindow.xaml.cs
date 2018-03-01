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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interfejs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string clear = string.Empty;
        int var = 0;
        string enter = Environment.NewLine;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Clear_1(object sender, RoutedEventArgs e)
        {
            clear1.Text = clear;
        }

        public void Clear_2(object sender, RoutedEventArgs e)
        {
            clear2.Text = clear;
        }

        public void Cancel(object sender, RoutedEventArgs e)
        {
            clear1.Text = clear;
            clear2.Text = clear;
            extra1.Text = clear;
            extra2.Text = clear;
            extra3.Text = clear;
            description.Text = clear;
            cheese.IsChecked = false;
            sauce.IsChecked = false;
            drink.IsChecked = false;
            MessageBox.Show("Zamówienie anulowane");
            var = 0;
        }
        
        public void Ok(object sender, RoutedEventArgs e)
        {
            clear1.Text = clear;
            clear2.Text = clear;
            extra1.Text = clear;
            extra2.Text = clear;
            extra3.Text = clear;
            description.Text = clear;
            cheese.IsChecked = false;
            sauce.IsChecked = false;
            drink.IsChecked = false;
            MessageBox.Show("Zamówienie przyjęte");
            var = 0;
        }
        public void Add(object sender, RoutedEventArgs e)
        {
            if (var != 1)
            {
                if (clear1.Text != clear)
                    description.Text += clear1.Text + enter + "--" + enter;
                else
                    MessageBox.Show("Nie wpisano danych osobowych");
                if (clear2.Text != clear)  
                     description.Text += clear2.Text + " ";
                else
                    MessageBox.Show("Nie wprowadzono nazwy pizzy");
                if(plain.IsChecked==true)
                {
                    description.Text += "na zwykłym spodzie" + enter;
                }
                else if(thin.IsChecked==true)
                {
                    description.Text += "na ultracienkim spodzie" + enter;
                }
                else if(fat.IsChecked==true)
                {
                    description.Text += "na grubym spodzie" + enter;
                }
                else if (very_fat.IsChecked == true)
                {
                    description.Text += "na podwójnie grubym spodzie" + enter;
                }
                if (cheese.IsChecked!=false)
                    description.Text += "Dodatkowy ser: " + extra1.Text + enter;
                if (sauce.IsChecked != false)
                    description.Text += "Sos: " + extra2.Text + enter;
                if (drink.IsChecked != false)
                    description.Text += "Napoje chłodzące: " + extra3.Text + enter;
                var = 1;
            }
            else
            {
                MessageBox.Show("Nie można drugi raz dodać do zamówienia.");
            }

        }

    }
}

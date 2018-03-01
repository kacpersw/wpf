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
using System.Collections.ObjectModel;

namespace WiazanieDanych
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            region.Items.Add("Wschodni");
            region.Items.Add("Centralny");
            region.Items.Add("Zachodni");
            region.Items.Add("Północny");
            region.Items.Add("Południowy");
            region.Items.Add("");
            users.Add(new Data("Jan", "Kowalski", "kowal@kowal.com", 249.95, "Wschodni", 3, true));
            users.Add(new Data("Piotr", "Wiśniewski", "piotr@pb.edu.pl", 200.95, "Centralny", 1, true));
            users.Add(new Data("Anna", "Nowak", "nowa.anna@gmail.com", 121.55, "Zachodni", 2, true));
            users.Add(new Data("dodaj nową osobę...", false, ""));
            list.ItemsSource = users;
        }
        private ObservableCollection<Data> users=new ObservableCollection<Data>();
        private void checking(object sender, RoutedEventArgs e)
        {
            checking2();
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            if(list.SelectedIndex>=0)
            {
                users.RemoveAt(list.SelectedIndex);
                list.IsEnabled = true;
            }
        }

        private void change(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedIndex == users.Count - 1)
            {
                users[list.SelectedIndex].name = string.Empty;
                name.Text = string.Empty;
                users.Add(new Data("dodaj nową osobę...", false, ""));
            }
        }
        private void canIchange()
        {
            if(list.SelectedIndex>=0)
            {
                if (name.Text == string.Empty || surname.Text == string.Empty)
                {
                    list.IsEnabled = false;
                }
                else
                {
                    if (box.IsChecked == true)
                    {
                        if (email.Text == string.Empty || howMuch.Text == string.Empty || region.Text == string.Empty)
                        {
                            list.IsEnabled = false;
                        }
                        else
                        {
                            list.IsEnabled = true;
                        }
                    }
                    else
                    {
                        list.IsEnabled = true;
                    }
                }
            }    
        }
        private void checking2()
        {
            if (box.IsChecked == false)
            {
                email.IsEnabled = false;
                howMuch.IsEnabled = false;
                region.IsEnabled = false;
                slider.IsEnabled = false;
            }
            else
            {
                email.IsEnabled = true;
                howMuch.IsEnabled = true;
                region.IsEnabled = true;
                slider.IsEnabled = true;
            }
          
        }
        private void changeTXT(object sender, TextChangedEventArgs e)
        {
            canIchange();
        }

        private void regionChange(object sender, SelectionChangedEventArgs e)
        {
            canIchange();
        }

        private void moving(object sender, MouseEventArgs e)
        {
            canIchange();
            checking2();
        }
    }
}

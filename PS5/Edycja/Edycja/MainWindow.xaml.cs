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

namespace Edycja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users;
        public int sb;
        public int xs;
        public ListBoxItem asd;
        public MainWindow()
        {
            InitializeComponent();
            users = new List<User>();
            sb= 0;
    }
        public void ustawX(int a, int xc)
        {
            sb = a;
            xs = xc;
        }
        private void addNewUser(object sender, RoutedEventArgs e)
        {
            UserDlg udlg = new UserDlg();
            udlg.ok.IsEnabled = false;
            if(udlg.ShowDialog()==true)
            {
                users.Add(new User(udlg.getName, udlg.getSurname, udlg.getEmail));
                lista.Items.Add(new ListBoxItem { Content=users[users.Count - 1].show() });
            }
        }
        private void closeMain(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void changeData(string a, string b, string c, int x)
        {
            users[x].changeName(a);
            users[x].changeSurname(b);
            users[x].changeEmail(c);
        }
        public void changeName(string a, int x)
        {
            users[x].changeName(a);
            xs = lista.SelectedIndex;
            lista.Items.Clear();

            foreach (var item in users)
            {
                lista.Items.Add(new ListBoxItem { Content = item.show() });
            }
            lista.SelectedIndex = xs;
            
            //hide();
        }
        public void changeSurname(string b, int x)
        {
            users[x].changeSurname(b);
            xs = lista.SelectedIndex;
            lista.Items.Clear();
            foreach (var item in users)
            {
                lista.Items.Add(new ListBoxItem { Content = item.show() });
            }
            lista.SelectedIndex = xs;
            //hide();
        }
        public void changeEmail(string c, int x)
        {
            users[x].changeEmail(c);
            xs = lista.SelectedIndex;
            lista.Items.Clear();

            foreach (var item in users)
            {
                lista.Items.Add(new ListBoxItem { Content = item.show() });
            }
            lista.SelectedIndex = xs;
            //hide();
        }
        private void editUser(object sender, RoutedEventArgs e)
        {
            UserDlg udlg = new UserDlg();
            udlg.Owner = this;
            int x = lista.SelectedIndex;
            udlg.Title = "Edytuj";
            string a, b, c;
            udlg.getName = users[x].showName();
            udlg.getSurname = users[x].showSurname();
            udlg.getEmail = users[x].showEmail();
            if (udlg.ShowDialog()==true)
            {
                a = udlg.getName;
                b = udlg.getSurname;
                c = udlg.getEmail;
                changeData(a, b, c, x);
                lista.Items.Clear();
                
                foreach (var item in users)
                {
                    lista.Items.Add(new ListBoxItem { Content = item.show() }); 
                }
            }
            //hide();
                    
        }

        private void showUser(object sender, RoutedEventArgs e)
        {
            EditUser showed = new EditUser();
            showed.Owner = this;
            int x = lista.SelectedIndex;
            showed.getName = users[x].showName();
            showed.getSurname = users[x].showSurname();
            showed.getEmail = users[x].showEmail();
            showed.getX = x;
            showed.Show();
            sb = 1;
        }
        
        public void hide()
        {
            show.IsEnabled = false;
            remove.IsEnabled = false;
            edit.IsEnabled = false;
        }
        private void removeUser(object sender, RoutedEventArgs e)
        {
            int x = lista.SelectedIndex;
            MessageBoxResult y = MessageBox.Show("Jesteś pewien?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(y==MessageBoxResult.Yes)
            {
                if(sb==1 && x==xs)
                {
                    ((App)Application.Current).CloseAll();
                }
                lista.Items.RemoveAt(lista.SelectedIndex);
                users.RemoveAt(x);
                hide();
            }
            
        }

        private void click(object sender, MouseButtonEventArgs e)
        {
            int x = lista.SelectedIndex;
            ListBoxItem y = (ListBoxItem)lista.SelectedItem;
            if (x >= 0)
            {
                show.IsEnabled = true;
                remove.IsEnabled = true;
                edit.IsEnabled = true;
                
                string a, b, c;
                a = users[x].showName();
                b = users[x].showSurname();
                c = users[x].showEmail();
               ((App)Application.Current).UpdateAll(a, b, c, x);
                lista.SelectedItem = y;
            }
            else
            {
                show.IsEnabled = false;
                remove.IsEnabled = false;
                edit.IsEnabled = false;
            }
            
        }
        public void unlock()
        {
            lista.IsEnabled = true;
        }
        public void block()
        {
            lista.IsEnabled = false;
        }
        public void unlockButtons()
        {
            if(lista.SelectedIndex>=0)
            {
                show.IsEnabled = true;
                remove.IsEnabled = true;
                edit.IsEnabled = true;
            }
        }
        public void odblokuj()
        {
            show.IsEnabled = true;
            remove.IsEnabled = true;
            edit.IsEnabled = true;
        }

        private void ustaw(object sender, RoutedEventArgs e)
        {
            show.IsEnabled = false;
            remove.IsEnabled = false;
            edit.IsEnabled = false;
        }
    }
}

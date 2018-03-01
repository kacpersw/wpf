using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ObsługaDanych
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            users.Add(new User("Michał","Stankiewicz","miczu@wp.pl","szczupak14", 19, 1200));
            users.Add(new User("Ania", "Stachurska", "ania123@onet.pl", "czekolada", 21, 2000));
            users.Add(new User("Robert", "Michalak", "robi_micha@wp.pl", "abecadło", 45, 6500));
            users.Add(new User("Monika", "Kowalska", "kowalska@wp.pl", "kowadlo19", 32, 2200));
            users.Add(new User("Darek", "Bagiński", "bagis1234@gmail.com", "bigos5412", 50, 4200));
            users.Add(new User("Dominika", "Jachaś", "jaska@o2.pl", "murena43", 18, 1200));
            users.Add(new User("Marcin", "Iksiński", "marik1234@wp.pl", "mariczek12", 25, 2100));
            users.Add(new User("Aneta", "Popławska", "anecia@wp.vp", "kwiatuszek21", 18, 1000));
            users.Add(new User("Czarek", "Rogalski", "czarodziej@wp.pl", "czarymary12", 22, 5000));
            users.Add(new User("Paulina", "Bomba", "bomb123@o2.pl", "bombastik14", 41, 2400));

            List.ItemsSource = users;
        }

        private ObservableCollection<User> users = new ObservableCollection<User>();
        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(users);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            int maximumAge;
            if (int.TryParse(MaxAge.Text, out maximumAge))
            {
                View.Filter = delegate (object item)
                {
                    User user = item as User;
                    if (user != null)
                    {
                        return (user.age < maximumAge);
                    }
                    return false;
                };
            }
        }

        private void FilterExit(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
            MaxAge.Text = string.Empty;
        }


        private void WithoutSort(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
        }


        private void SortWithSurname(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
            View.SortDescriptions.Add(new SortDescription("surname", ListSortDirection.Ascending));
        }


        private void SortWithAge(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
            View.SortDescriptions.Add(new SortDescription("age", ListSortDirection.Ascending));
        }

        private void WithoutGroup(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
        }

        private void GroupWithFirstLetter(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.SortDescriptions.Add(new SortDescription("surname", ListSortDirection.Ascending));
            FirstLetterGruouper grouper = new FirstLetterGruouper();
            View.GroupDescriptions.Add(new PropertyGroupDescription("surname", grouper));
        }

        private void GroupWithAge(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.SortDescriptions.Add(new SortDescription("age",ListSortDirection.Ascending));
            AgeGrouper grouper = new AgeGrouper();
            grouper.GroupInterval = 10;
            View.GroupDescriptions.Add(new PropertyGroupDescription("age", grouper));
        }

        private void addNewUser(object sender, RoutedEventArgs e)
        {
            Add window = new Add();
            if(window.ShowDialog()==true)
            {
                users.Add(new User(window.getName, window.getSurname, window.getEmail, window.getPassword, window.getAge, window.getSalary));
            }
        }

        private void RemoveUser(object sender, RoutedEventArgs e)
        {
            if(List.SelectedIndex>=0)
            {
                users.RemoveAt(List.SelectedIndex);
            }
        }

        private void changeAge(object sender, TextChangedEventArgs e)
        {
            DataTemplateSelector selector = List.ItemTemplateSelector;
            List.ItemTemplateSelector = null;
            List.ItemTemplateSelector = selector;
        }
    }
}

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

namespace Hanoi
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HanoiCommandsUp_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ListBox UP = (ListBox)e.Parameter;
            if(txt.Text==string.Empty && UP!=null && Int32.Parse(UP.Items.Count.ToString())!=0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
            
        }

        private void HanoiCommandsUp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox UP = (ListBox)e.Parameter;
       
            string helper = UP.Items.GetItemAt(0).ToString();
            txt.Text = helper.Substring(helper.Length-1);
           
            UP.Items.RemoveAt(0);
        }

        private void HanoiCommandsDown_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ListBox DOWN = (ListBox)e.Parameter;
            if ((txt.Text != string.Empty && DOWN != null ))
            {
                if (Int32.Parse(DOWN.Items.Count.ToString()) == 0)
                {
                    e.CanExecute = true;
                }
                else if (Int32.Parse(DOWN.Items.Count.ToString()) != 0)
                {
                    string helper = DOWN.Items.GetItemAt(0).ToString();
                    int counter = Int32.Parse(helper.Substring(helper.Length - 1));
                    if (Int32.Parse(txt.Text) < counter)
                    {
                        e.CanExecute = true;
                    }
                    else
                    {
                        e.CanExecute = false;
                    }
                }
                else
                {
                    e.CanExecute = false;
                }
            }
            else
            {
                e.CanExecute = false;
            }
            
        }

        private void HanoiCommandsDown_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox DOWN = (ListBox)e.Parameter;
            DOWN.Items.Insert(0, txt.Text);
            txt.Text = string.Empty;
        }
    }
    public static class HanoiCommands
    {
        private static RoutedUICommand up;
        private static RoutedUICommand down;
        static HanoiCommands()
        {
            up = new RoutedUICommand("Up", "Up", typeof(HanoiCommands));
            down = new RoutedUICommand("Down", "Down", typeof(HanoiCommands));
        }
        public static RoutedUICommand Up
        {
            get { return up; }
        }
        public static RoutedUICommand Down
        {
            get { return down; }
        }
    }
}

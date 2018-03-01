using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Edycja
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void UpdateAll(string name, string surname, string email, int x)
        {
            foreach (Window window in Windows)
            {
                if(window is EditUser)
                {
                    ((EditUser)window).Update(name, surname, email,x);
                }
            }
        }
        public void UpdateEdit(string name, string surname, string email, int x)
        {
            foreach (Window window in Windows)
            {
                if (window is EditUser)
                {
                    ((EditUser)window).Update(name, surname, email, x);
                }
            }
        }
        public void CloseAll()
        {
            foreach (Window window in Windows)
            {
                if (window is EditUser)
                {
                    ((EditUser)window).Closing2();
                }
            }
        }
    }
}

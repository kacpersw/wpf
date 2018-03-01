using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ObsługaDanych
{
    class BackgroundSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Window window = Application.Current.MainWindow;
            if(item is User)
            {
                User age = (User)item;
                if(age.age > 25)
                {
                    return (DataTemplate)window.FindResource("PeopleAbove25");
                }
                else
                {
                    return (DataTemplate)window.FindResource("PeopleUnder25");
                }
            }
            return null;
        }
    }
}

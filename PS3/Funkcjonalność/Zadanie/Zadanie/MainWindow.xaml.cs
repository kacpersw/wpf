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

namespace Zadanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            R.Value = 255;
            G.Value = 255;
            B.Value = 255;
            Rf.Text = "0";
            Gf.Text = "0";
            Bf.Text = "0";
            x1.Value = 5;
            x2.Value = 5;


        }

        private void ahleft(object sender, RoutedEventArgs e)
        {
            label.HorizontalAlignment = HorizontalAlignment.Left;
        }
        private void ahright(object sender, RoutedEventArgs e)
        {
            label.HorizontalAlignment = HorizontalAlignment.Right;
        }
        private void ahcenter(object sender, RoutedEventArgs e)
        {
            label.HorizontalAlignment = HorizontalAlignment.Center;
        }
        private void ahstretch(object sender, RoutedEventArgs e)
        {
            label.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        private void avtop(object sender, RoutedEventArgs e)
        {
            label.VerticalAlignment = VerticalAlignment.Top;
        }

        private void avcenter(object sender, RoutedEventArgs e)
        {
            label.VerticalAlignment = VerticalAlignment.Center;
        }

        private void avbottom(object sender, RoutedEventArgs e)
        {
            label.VerticalAlignment = VerticalAlignment.Bottom;
        }

        private void avstretch(object sender, RoutedEventArgs e)
        {
            label.VerticalAlignment = VerticalAlignment.Stretch;
        }

        private void cahleft(object sender, RoutedEventArgs e)
        {
            label.HorizontalContentAlignment = HorizontalAlignment.Left;
        }
        private void cahright(object sender, RoutedEventArgs e)
        {
            label.HorizontalContentAlignment = HorizontalAlignment.Right;
        }
        private void cahcenter(object sender, RoutedEventArgs e)
        {
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
        }
        private void cahstretch(object sender, RoutedEventArgs e)
        {
            label.HorizontalContentAlignment = HorizontalAlignment.Stretch;
        }

        private void cbold(object sender, RoutedEventArgs e)
        {
            if(abold.IsChecked==true)
            {
                label.FontWeight = FontWeights.Bold;
            }
            else
            {
                label.FontWeight = FontWeights.Normal;
            }
        }

        private void citalic(object sender, RoutedEventArgs e)
        {
            if (aitalic.IsChecked == true)
            {
                label.FontStyle=FontStyles.Italic;
            }
            else
            {
                label.FontStyle = FontStyles.Normal;
            }
        }

        private void changeFontSize(object sender, TextChangedEventArgs e)
        {
            try
            {
                label.FontSize = int.Parse(size.Text);
            }
            catch (FormatException) { }


        }
        private void changeFontFamily(object sender, TextChangedEventArgs e)
        {
            label.FontFamily = new FontFamily(family.Text);
        }

        private void write(object sender, TextChangedEventArgs e)
        {
            label.Content = text.Text;
        }

        private void cavtop(object sender, RoutedEventArgs e)
        {
            label.VerticalContentAlignment = VerticalAlignment.Top;
        }

        private void cavstretch(object sender, RoutedEventArgs e)
        {
            label.VerticalContentAlignment = VerticalAlignment.Stretch;
        }

        private void cavbottom(object sender, RoutedEventArgs e)
        {
            label.VerticalContentAlignment = VerticalAlignment.Bottom;
        }

        private void cavcenter(object sender, RoutedEventArgs e)
        {
            label.VerticalContentAlignment = VerticalAlignment.Center;
        }

        private void marginRead(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            label.Margin = new Thickness(e.NewValue);
        }

        private void paddingRead(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            label.Padding = new Thickness(e.NewValue);
        }

        private void color(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color colorX = new Color();
            colorX.A = (byte)255;
            colorX.R = (byte)R.Value;
            colorX.G = (byte)G.Value;
            colorX.B = (byte)B.Value;
            label.Background = new SolidColorBrush(colorX);
        }

        private void colorForeground(object sender, TextChangedEventArgs e)
        {
            Color colorX = new Color();
            colorX.A = (byte)255;
            try
            {
                colorX.R = (byte)(int.Parse(Rf.Text.ToString()));
                colorX.G = (byte)(int.Parse(Gf.Text.ToString()));
                colorX.B = (byte)(int.Parse(Bf.Text.ToString()));

            }catch(FormatException ) {  }
            label.Foreground = new SolidColorBrush(colorX);
        }

        private void thickness(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            label.BorderThickness = new Thickness(e.NewValue);
        }

        private void changeBorder(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem itemX = (ComboBoxItem)id.SelectedItem;
            label.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(itemX.Content.ToString()));
        }
    }
}

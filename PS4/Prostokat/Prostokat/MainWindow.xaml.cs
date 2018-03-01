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

namespace Prostokat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrag = false;
        private Point point;
        private Point point2;
        private Rectangle rectangle_help;
        private bool isShift = false;
        public MainWindow()
        {
            InitializeComponent();
            rectangle_help = new Rectangle();
            point.X = 1;
            point.Y = 1;
        }


        private void addRectangle(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = new Rectangle();
            r.Stroke = Brushes.Black;
            isDrag = true;
            point = new Point();
            point = e.GetPosition(this);
            r.SetValue(Canvas.TopProperty, point.Y);
            r.SetValue(Canvas.LeftProperty, point.X);
            canvas.Children.Add(r);
            rectangle_help = r;
            Mouse.Capture(r);

        }

        private void moving(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                point2 = e.GetPosition(this);
                rectangle_help.SetValue(Canvas.TopProperty, Math.Min(point2.Y, point.Y));
                rectangle_help.SetValue(Canvas.LeftProperty, Math.Min(point.X, point2.X));
                rectangle_help.SetValue(Canvas.BottomProperty, Math.Max(point2.Y, point.Y));
                rectangle_help.SetValue(Canvas.RightProperty, Math.Max(point.X, point2.X));
                rectangle_help.Height = Math.Max(point2.Y, point.Y) - Math.Min(point.Y,point2.Y);
                rectangle_help.Width = Math.Max(point2.X, point.X) - Math.Min(point.X, point2.X);
            }

        }

        private void addded(object sender, MouseButtonEventArgs e)
        {
            isDrag = false;
            Mouse.Capture(null);
        }

        private void gotoxy(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                isShift = true;
            }
            if (Keyboard.IsKeyUp(Key.LeftShift))
            {
                isShift = false;
            }
            if (Keyboard.IsKeyDown(Key.Down) && isShift == true)
            {
                rectangle_help.Height += 1;
            }
            if (Keyboard.IsKeyDown(Key.Up) && isShift == true)
            {
                if (rectangle_help.Height > 0)
                {
                    rectangle_help.Height -= 1;
                }
            }
            if (Keyboard.IsKeyDown(Key.Left) && isShift == true)
            {
                if (rectangle_help.Width > 0)
                {
                    rectangle_help.Width -= 1;
                }

            }
            if (Keyboard.IsKeyDown(Key.Right) && isShift == true)
            {
                rectangle_help.Width += 1;
            }


            if (Keyboard.IsKeyDown(Key.Up) && isShift == false)
            {
                point.Y -= 1;
                rectangle_help.SetValue(Canvas.TopProperty, point.Y);
            }
            if (Keyboard.IsKeyDown(Key.Down) && isShift == false)
            {
                point.Y += 1;
                rectangle_help.SetValue(Canvas.TopProperty, point.Y);
            }
            if (Keyboard.IsKeyDown(Key.Left) && isShift == false)
            {
                point.X -= 1;
                rectangle_help.SetValue(Canvas.LeftProperty, point.X);
            }
            if (Keyboard.IsKeyDown(Key.Right) && isShift == false)
            {
                point.X += 1;
                rectangle_help.SetValue(Canvas.LeftProperty, point.X);
            }
        }
    }
}

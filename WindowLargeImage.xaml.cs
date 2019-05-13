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

namespace FlatExchanger
{
    /// <summary>
    /// Логика взаимодействия для WindowLargeImage.xaml
    /// </summary>
    public partial class WindowLargeImage : Window
    {
        public WindowLargeImage(string imgPath)
        {
            InitializeComponent();

            //(@"Pictures/no_photo.jpg"
            iLarge.Source = new BitmapImage(new Uri(imgPath, UriKind.Absolute));

        }

        public WindowLargeImage(Image img)
        {
            InitializeComponent();

            //(@"Pictures/no_photo.jpg"
            iLarge.Source = img.Source;

        }
    }
}

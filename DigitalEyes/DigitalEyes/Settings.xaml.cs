using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace DigitalEyes
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void BackgroundColorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BackgroundColor.xaml", UriKind.RelativeOrAbsolute));
            

        }

        private void TextColorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FontColor.xaml", UriKind.RelativeOrAbsolute));

        }

        private void FontSizeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FontSize.xaml", UriKind.RelativeOrAbsolute));

        }
        public static SolidColorBrush GetColorFromHexa(string hexaColor)
        {
            return new SolidColorBrush(
                Color.FromArgb(
                    Convert.ToByte(hexaColor.Substring(1, 2), 16),
                    Convert.ToByte(hexaColor.Substring(3, 2), 16),
                    Convert.ToByte(hexaColor.Substring(5, 2), 16),
                    Convert.ToByte(hexaColor.Substring(7, 2), 16)
                )
            );
        }

       
    }
}
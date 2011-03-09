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
using Microsoft.Phone.Shell;

namespace DigitalEyes
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

       

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            object FontSizeObject;

            if (phoneAppService.State.ContainsKey("LargeFontSize"))
            {
                if (phoneAppService.State.TryGetValue("LargeFontSize", out FontSizeObject))
                {
                    double largeFontSize = Convert.ToDouble(FontSizeObject);
                    textBlock1.FontSize = largeFontSize;
                    PageTitle.FontSize = largeFontSize;
                }
            }
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

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (scaleSlider != null)
            {
                phoneAppService.State["LargeFontSize"] = scaleSlider.Value;
                textBlock1.FontSize = scaleSlider.Value;
                textBlock2.FontSize = (scaleSlider.Value - 10);
            }
        }

        private void DigitalEyes_Loaded(object sender, RoutedEventArgs e)
        {

        }
        

       
    }
}
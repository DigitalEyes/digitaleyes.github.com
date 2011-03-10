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
using Microsoft.Xna.Framework.Audio;
using System.IO;

namespace DigitalEyes
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

/****************************CHANGE FONT SIZE DYNAMICALLY ****************************************/
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            object FontSizeObject;

            if (phoneAppService.State.ContainsKey("LargeFontSize"))
            {
                if (phoneAppService.State.TryGetValue("LargeFontSize", out FontSizeObject))
                {
                    double largeFontSize = Convert.ToDouble(FontSizeObject);
                    PageTitle.FontSize = largeFontSize;
                }
            }
            if (phoneAppService.State.ContainsKey("MediumFontSize"))
            {
                if (phoneAppService.State.TryGetValue("MediumFontSize", out FontSizeObject))
                {
                    double mediumFontSize = Convert.ToDouble(FontSizeObject);

                    ApplicationTitle.FontSize = mediumFontSize;
                    textBlock1.FontSize = mediumFontSize;
                    BackgroundColorButton.FontSize = mediumFontSize;
                    TextColorButton.FontSize = mediumFontSize;

                    if (mediumFontSize < 23)
                    {
                        BackgroundColorButton.Height = mediumFontSize * 4;
                        TextColorButton.Height = mediumFontSize * 4;

                    }
                    else if (mediumFontSize < 30)
                    {
                        BackgroundColorButton.Height = mediumFontSize * 3;
                        TextColorButton.Height = mediumFontSize * 3;
                    }
                    else
                    {
                        BackgroundColorButton.Height = mediumFontSize * 2.5;
                        TextColorButton.Height = mediumFontSize * 2.5;
                    }
                    
                }
            }
            if (phoneAppService.State.ContainsKey("SmallFontSize"))
            {
                if (phoneAppService.State.TryGetValue("SmallFontSize", out FontSizeObject))
                {
                    double smallFontSize = Convert.ToDouble(FontSizeObject);

                    textBlock2.FontSize = smallFontSize;
                }
            }
        }
/**********************************END CHANGE FONT SIZE DYNAMICALLY ******************************/
        private void BackgroundColorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BackgroundColor.xaml", UriKind.RelativeOrAbsolute));
            

        }

        private void TextColorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FontColor.xaml", UriKind.RelativeOrAbsolute));

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
                phoneAppService.State["LargeFontSize"] = scaleSlider.Value*2;
                phoneAppService.State["MediumFontSize"] = (scaleSlider.Value / 3) * 2 * 2;
                phoneAppService.State["SmallFontSize"] = (scaleSlider.Value / 3) *2;

                double smallFontSize = (scaleSlider.Value / 3) * 2;
                double mediumFontSize = (scaleSlider.Value / 3) * 2 * 2;
                double largeFontSize = (scaleSlider.Value) * 2 * 2;

                ApplicationTitle.FontSize = mediumFontSize;
                PageTitle.FontSize = largeFontSize; 
                textBlock1.FontSize = mediumFontSize; 
                textBlock2.FontSize = smallFontSize; 
                BackgroundColorButton.FontSize = mediumFontSize;
                TextColorButton.FontSize = mediumFontSize;

                if (mediumFontSize < 23)
                {
                    BackgroundColorButton.Height = mediumFontSize * 4;
                    TextColorButton.Height = mediumFontSize * 4;

                }
                else if (mediumFontSize < 30)
                {
                    BackgroundColorButton.Height = mediumFontSize * 3;
                    TextColorButton.Height = mediumFontSize * 3;
                }
                else
                {
                    BackgroundColorButton.Height = mediumFontSize * 2.5;
                    TextColorButton.Height = mediumFontSize * 2.5;
                }
            }
        }

        private void DigitalEyes_Loaded(object sender, RoutedEventArgs e)
        {

        }

       

       
    }
}
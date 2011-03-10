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
            object BGC;
            object FC;
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

                    
                    textBlock1.FontSize = mediumFontSize;
                    BackgroundColorButton.FontSize = mediumFontSize;
                    TextColorButton.FontSize = mediumFontSize;
                    checkBox1.FontSize = mediumFontSize;

                    if (mediumFontSize < 23)
                    {
                        BackgroundColorButton.Height = mediumFontSize * 4;
                        TextColorButton.Height = mediumFontSize * 4;
                        checkBox1.Height = mediumFontSize * 4;
                    }
                    else if (mediumFontSize < 30)
                    {
                        BackgroundColorButton.Height = mediumFontSize * 3;
                        TextColorButton.Height = mediumFontSize * 3;
                        checkBox1.Height = mediumFontSize * 3;
                    }
                    else
                    {
                        BackgroundColorButton.Height = mediumFontSize * 2.5;
                        TextColorButton.Height = mediumFontSize * 2.5;
                        checkBox1.Height = mediumFontSize * 2.5;
                    }
                    
                }
            }
            if (phoneAppService.State.ContainsKey("SmallFontSize"))
            {
                if (phoneAppService.State.TryGetValue("SmallFontSize", out FontSizeObject))
                {
                    double smallFontSize = Convert.ToDouble(FontSizeObject);
                    ApplicationTitle.FontSize = smallFontSize;
                    textBlock2.FontSize = smallFontSize;
                }
            }
            if (phoneAppService.State.ContainsKey("BackgroundColor"))
            {
                if (phoneAppService.State.TryGetValue("BackgroundColor", out BGC))
                {
                    string col = Convert.ToString(BGC);
                    LayoutRoot.Background = new SolidColorBrush(GetColorFromHex(col).Color);


                }
            }
            if (phoneAppService.State.ContainsKey("FontColor"))
            {
                if (phoneAppService.State.TryGetValue("FontColor", out FC))
                {
                    string col = Convert.ToString(FC);
                    SolidColorBrush brush = new SolidColorBrush(GetColorFromHex(col).Color);
                    ApplicationTitle.Foreground = brush;
                    PageTitle.Foreground = brush;
                    BackgroundColorButton.Foreground = brush;
                    TextColorButton.Foreground = brush;
                    textBlock1.Foreground = brush;
                    textBlock2.Foreground = brush;
                    checkBox1.Foreground = brush;
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

       
       

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (scaleSlider != null)
            {
                double smallFontSize = ((scaleSlider.Value / 4) * 1) * 2;
                double mediumFontSize = ((scaleSlider.Value / 4) * 2) * 2;
                double largeFontSize = ((scaleSlider.Value / 4) * 4) * 2;

                phoneAppService.State["LargeFontSize"] = largeFontSize;
                phoneAppService.State["MediumFontSize"] = mediumFontSize;
                phoneAppService.State["SmallFontSize"] = smallFontSize;

                

                ApplicationTitle.FontSize = smallFontSize;
                PageTitle.FontSize = largeFontSize; 
                textBlock1.FontSize = mediumFontSize; 
                textBlock2.FontSize = smallFontSize; 
                BackgroundColorButton.FontSize = mediumFontSize;
                TextColorButton.FontSize = mediumFontSize;
                checkBox1.FontSize = mediumFontSize;

                if (mediumFontSize < 23)
                {
                    BackgroundColorButton.Height = mediumFontSize * 4;
                    TextColorButton.Height = mediumFontSize * 4;
                    checkBox1.Height = mediumFontSize * 4;

                }
                else if (mediumFontSize < 30)
                {
                    BackgroundColorButton.Height = mediumFontSize * 3;
                    TextColorButton.Height = mediumFontSize * 3;
                    checkBox1.Height = mediumFontSize * 3;
                }
                else
                {
                    BackgroundColorButton.Height = mediumFontSize * 2.5;
                    TextColorButton.Height = mediumFontSize * 2.5;
                    checkBox1.Height = mediumFontSize * 2.5;
                }
            }
        }

        private void DigitalEyes_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private SolidColorBrush GetColorFromHex(string myColor)
        {
            return new SolidColorBrush(
                Color.FromArgb(
                    Convert.ToByte(myColor.Substring(1, 2), 16),
                    Convert.ToByte(myColor.Substring(3, 2), 16),
                    Convert.ToByte(myColor.Substring(5, 2), 16),
                    Convert.ToByte(myColor.Substring(7, 2), 16)
                )
            );
        }

       
    }
}
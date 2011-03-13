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
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        /*Ensures that the new font color will be reloaded when navigated back to MainPage page. Allowing the default
        value of the back button does not refresh all the values on the page */
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        /*Load and apply the saved values for the font size, background color, and font color */
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            object FontSizeObject;
            object BGC;
            object FC;

            /*Set font size on page, large font objects*/
            if (phoneAppService.State.ContainsKey("LargeFontSize"))
            {
                if (phoneAppService.State.TryGetValue("LargeFontSize", out FontSizeObject))
                {
                    double largeFontSize = Convert.ToDouble(FontSizeObject);
                    PageTitle.FontSize = largeFontSize;
                }
            }
            /*Set font size on page, medium font objects*/
            if (phoneAppService.State.ContainsKey("MediumFontSize"))
            {
                if (phoneAppService.State.TryGetValue("MediumFontSize", out FontSizeObject))
                {
                    double mediumFontSize = Convert.ToDouble(FontSizeObject);

                    textBlock1.FontSize = mediumFontSize;
                    button1.FontSize = mediumFontSize;
                    button2.FontSize = mediumFontSize;
                    checkBox1.FontSize = mediumFontSize;

                    /*Ensures that buttons resize appropriately, changes the height of button along with the fontSize
                     * so that the font will fit inside the button box*/
                    if (mediumFontSize < 23)
                    {
                        button1.Height = mediumFontSize * 4;
                        button2.Height = mediumFontSize * 4;
                        checkBox1.Height = mediumFontSize * 4;
                    }
                    else if (mediumFontSize < 30)
                    {
                        button1.Height = mediumFontSize * 3;
                        button2.Height = mediumFontSize * 3;
                        checkBox1.Height = mediumFontSize * 3;
                    }
                    else
                    {
                        button1.Height = mediumFontSize * 2.5;
                        button2.Height = mediumFontSize * 2.5;
                        checkBox1.Height = mediumFontSize * 2.5;
                    }
                }
            }
            /*Set font size on page, small font objects*/
            if (phoneAppService.State.ContainsKey("SmallFontSize"))
            {
                if (phoneAppService.State.TryGetValue("SmallFontSize", out FontSizeObject))
                {
                    double smallFontSize = Convert.ToDouble(FontSizeObject);
                    ApplicationTitle.FontSize = smallFontSize;
                    textBlock2.FontSize = smallFontSize;
                }
            }
            /*Set the background color of the page from the saved color*/
            if (phoneAppService.State.ContainsKey("BackgroundColor"))
            {
                if (phoneAppService.State.TryGetValue("BackgroundColor", out BGC))
                {
                    string col = Convert.ToString(BGC);
                    LayoutRoot.Background = new SolidColorBrush(GetColorFromHex(col).Color);
                }
            }
            /*Set the font color of all text on the page*/
            if (phoneAppService.State.ContainsKey("FontColor"))
            {
                if (phoneAppService.State.TryGetValue("FontColor", out FC))
                {
                    string col = Convert.ToString(FC);
                    SolidColorBrush brush = new SolidColorBrush(GetColorFromHex(col).Color);
                    ApplicationTitle.Foreground = brush;
                    PageTitle.Foreground = brush;
                    button1.Foreground = brush;
                    button2.Foreground = brush;
                    textBlock1.Foreground = brush;
                    textBlock2.Foreground = brush;
                    checkBox1.Foreground = brush;
                }
            }
        }
        /*Navigate to the background color picker page*/
        private void BackgroundColorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BackgroundColor.xaml", UriKind.RelativeOrAbsolute));
        }
        /*Navigate to the text color picker page*/
        private void TextColorButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FontColor.xaml", UriKind.RelativeOrAbsolute));
        }
        /*Dynamically changes the font size on the page as the slider is moved so that the user can 
         * see the immediate change of the font size*/
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
                button1.FontSize = mediumFontSize;
                button2.FontSize = mediumFontSize;
                checkBox1.FontSize = mediumFontSize;

                if (mediumFontSize < 23)
                {
                    button1.Height = mediumFontSize * 4;
                    button2.Height = mediumFontSize * 4;
                    checkBox1.Height = mediumFontSize * 4;

                }
                else if (mediumFontSize < 30)
                {
                    button1.Height = mediumFontSize * 3;
                    button2.Height = mediumFontSize * 3;
                    checkBox1.Height = mediumFontSize * 3;
                }
                else
                {
                    button1.Height = mediumFontSize * 2.5;
                    button2.Height = mediumFontSize * 2.5;
                    checkBox1.Height = mediumFontSize * 2.5;
                }
            }
        }
        /*Needed to calculate the values to set the color for the font and background, calculates
         a color from a hex color string*/
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
        private void DigitalEyes_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
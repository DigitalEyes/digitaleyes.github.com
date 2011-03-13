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
    public partial class FontColor : PhoneApplicationPage
    {
        public FontColor()
        {
            InitializeComponent();
        }

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        /*Ensures that the new font color will be reloaded when navigated back to Settings page. Allowing the default
        value of the back button does not refresh all the values on the page */
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
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
                }
            }
            /*Set font size on page, small font objects*/
            if (phoneAppService.State.ContainsKey("SmallFontSize"))
            {
                if (phoneAppService.State.TryGetValue("SmallFontSize", out FontSizeObject))
                {
                    double smallFontSize = Convert.ToDouble(FontSizeObject);
                    ApplicationTitle.FontSize = smallFontSize;
                }
            }
            /*Set the background color of the page*/
            if (phoneAppService.State.ContainsKey("BackgroundColor"))
            {
                if (phoneAppService.State.TryGetValue("BackgroundColor", out BGC))
                {
                    string col = Convert.ToString(BGC);
                    LayoutRoot.Background = new SolidColorBrush(GetColorFromHex(col).Color);
                }
            }
            /*Set the font color of the page*/
            if (phoneAppService.State.ContainsKey("FontColor"))
            {
                if (phoneAppService.State.TryGetValue("FontColor", out FC))
                {
                    string col = Convert.ToString(FC);
                    ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    PageTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                }
            }
        }

        /*Background color picker, color picker will save the selected values for future page loads and
         will also set the font color of the objects on the page to the new color immediately*/
        private void b_red1_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF780000").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF780000").Color);
            phoneAppService.State["FontColor"] = "#FF780000";
        }
        private void b_red2_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFB30000").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFB30000").Color);
            phoneAppService.State["FontColor"] = "#FFB30000";
        }
        private void b_red3_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFE73A36").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFE73A36").Color);
            phoneAppService.State["FontColor"] = "#FFE73A36";
        }
        private void b_red4_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFE94D22").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFE94D22").Color);
            phoneAppService.State["FontColor"] = "#FFE94D22";
        }
        private void b_green1_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF003500").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF003500").Color);
            phoneAppService.State["FontColor"] = "#FF003500";
        }
        private void b_green2_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(Colors.Green);
            ApplicationTitle.Foreground = new SolidColorBrush(Colors.Green);
            phoneAppService.State["FontColor"] = Colors.Green;
        }
        private void b_green3_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF00C114").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF00C114").Color);
            phoneAppService.State["FontColor"] = "#FF00C114";
        }
        private void b_green4_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF78C32B").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF78C32B").Color);
            phoneAppService.State["FontColor"] = "#FF78C32B";
        }
        private void b_blue1_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF000094").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF000094").Color);
            phoneAppService.State["FontColor"] = "#FF000094";
        }
        private void b_blue2_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(Colors.Blue);
            ApplicationTitle.Foreground = new SolidColorBrush(Colors.Blue);
            phoneAppService.State["FontColor"] = Colors.Blue;
        }
        private void b_blue3_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF14D6E9").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF14D6E9").Color);
            phoneAppService.State["FontColor"] = "#FF14D6E9";
        }
        private void b_blue4_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF96D6E9").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF96D6E9").Color);
            phoneAppService.State["FontColor"] = "#FF96D6E9";
        }
        private void b_purple1_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF580079").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FF580079").Color);
            phoneAppService.State["FontColor"] = "#FF580079";
        }
        private void b_purple2_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(Colors.Purple);
            ApplicationTitle.Foreground = new SolidColorBrush(Colors.Purple);
            phoneAppService.State["FontColor"] = Colors.Purple;
        }
        private void b_purple3_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFA6488D").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFA6488D").Color);
            phoneAppService.State["FontColor"] = "#FFA6488D";
        }
        private void b_purple4_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFA670A3").Color);
            ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex("#FFA670A3").Color);
            phoneAppService.State["FontColor"] = "#FFA670A3";
        }
        private void b_yellow1_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(Colors.Yellow);
            ApplicationTitle.Foreground = new SolidColorBrush(Colors.Yellow);
            phoneAppService.State["FontColor"] = Colors.Yellow;
        }
        private void b_white1_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(Colors.White);
            ApplicationTitle.Foreground = new SolidColorBrush(Colors.White);
            phoneAppService.State["FontColor"] = Colors.White;
        }
        private void b_black1_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(Colors.Black);
            ApplicationTitle.Foreground = new SolidColorBrush(Colors.Black);
            phoneAppService.State["FontColor"] = Colors.Black;
        }
        private void b_black2_Click(object sender, RoutedEventArgs e)
        {
            PageTitle.Foreground = new SolidColorBrush(Colors.Black);
            ApplicationTitle.Foreground = new SolidColorBrush(Colors.Black);
            phoneAppService.State["FontColor"] = Colors.Black;
        }
        /*End font color picker*/

        /*Calculate the color value from an input hex color string so that the input for a new 
         * SolidColorBrush is in the appropriate format*/
        private SolidColorBrush GetColorFromHex(string myColor)
        {
            return new SolidColorBrush(
                Color.FromArgb(
                    Convert.ToByte(myColor.Substring(1,2),16),
                    Convert.ToByte(myColor.Substring(3,2),16),
                    Convert.ToByte(myColor.Substring(5,2),16),
                    Convert.ToByte(myColor.Substring(7,2),16)
                )
            );
        }
    }
}
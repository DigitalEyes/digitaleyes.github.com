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
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Audio;
using System.IO;

namespace DigitalEyes
{
    public partial class Scan : PhoneApplicationPage
    {
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        public Scan()
        {
            InitializeComponent();
            /*This is the hardcoded sample result of a tag scan. The tag will return a string which will be referenced 
             * with a location in our data structure and will return information about the location*/
            textBlock1.Text = "This is room 3437. Multiple Computer Science and Chemical Engineering classes meet here.  It is a traditional classroom setup with chairs attached to the desks.  There are no stairs inside this room.";
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
                    button2.FontSize = mediumFontSize;
                    button1.FontSize = mediumFontSize;
                    

                    /*Ensure that buttons resize appropriately, changes the height of button along with the fontSize
                     * so that the font will fit inside the button box*/
                    if (mediumFontSize < 23)
                    {
                        button1.Height = mediumFontSize * 4;
                        button2.Height = mediumFontSize * 4;
                    }
                    else if (mediumFontSize < 30)
                    {
                        button1.Height = mediumFontSize * 3;
                        button2.Height = mediumFontSize * 3;
                    }
                    else
                    {
                        button1.Height = mediumFontSize * 2.5;
                        button2.Height = mediumFontSize * 2.5;
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
                    textBlock1.FontSize = smallFontSize;
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
                    ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    PageTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    button1.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    button2.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    textBlock1.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
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
        /*Navigate to the directions page to generate directions using the tag loaded in the current page, which
         * was just scanned as the starting location for the route generated*/
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Directions.xaml", UriKind.RelativeOrAbsolute));
        }
        /*Shortcut to return to the main page of the application to avoid having to click the back button on the
         * phone multiple times. */
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
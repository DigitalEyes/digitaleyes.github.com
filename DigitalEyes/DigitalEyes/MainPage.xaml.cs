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
    public partial class MainPage : PhoneApplicationPage
    {
        CameraCaptureTask cameraCaptureTask1;
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        public MainPage()
        {
            InitializeComponent();
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

                    button1.FontSize = mediumFontSize;
                    button2.FontSize = mediumFontSize;
                    button3.FontSize = mediumFontSize;
                    button4.FontSize = mediumFontSize;

                    /*Ensure that buttons resize appropriately, changes the height along with the fontSize
                     * so that the font will fit inside the button box*/
                    if (mediumFontSize < 23)
                    {
                        button1.Height = mediumFontSize * 4;
                        button2.Height = mediumFontSize * 4;
                        button3.Height = mediumFontSize * 4;
                        button4.Height = mediumFontSize * 4;
                    }
                    else if (mediumFontSize < 30)
                    {
                        button1.Height = mediumFontSize * 3;
                        button2.Height = mediumFontSize * 3;
                        button3.Height = mediumFontSize * 3;
                        button4.Height = mediumFontSize * 3;
                    }
                    else
                    {
                        button1.Height = mediumFontSize * 2.5;
                        button2.Height = mediumFontSize * 2.5;
                        button3.Height = mediumFontSize * 2.5;
                        button4.Height = mediumFontSize * 2.5;
                    }
                }
            }
            /*Set font size on page, small font objects*/
            if (phoneAppService.State.ContainsKey("SmallFontSize"))
            {
                if (phoneAppService.State.TryGetValue("SmallFontSize", out FontSizeObject))
                {
                    double smallFontSize = Convert.ToDouble(FontSizeObject);
                    //No small font objects on this page
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
            /*Set the font color of all text on the page*/
            if (phoneAppService.State.ContainsKey("FontColor"))
            {
                if (phoneAppService.State.TryGetValue("FontColor", out FC))
                {
                    string col = Convert.ToString(FC);
                    SolidColorBrush brush = new SolidColorBrush(GetColorFromHex(col).Color);
                    PageTitle.Foreground = brush;
                    button1.Foreground = brush;
                    button2.Foreground = brush;
                    button3.Foreground = brush;
                    button4.Foreground = brush;
                }
            }
        }
        /*Scan button: will Launch camera so that the user can take a picture of the Microsoft tag/QR code.
         * Once the user has taken the picture, it will be analyzed and the tag references will be loaded*/
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            cameraCaptureTask1 = new CameraCaptureTask();
            cameraCaptureTask1.Completed += new EventHandler<PhotoResult>(cameraCaptureTask_Completed);
            try
            {
                cameraCaptureTask1.Show();
            }
            catch (System.InvalidOperationException ex)
            {
                   //do nothing
            }
        }
        /*Camera picture has been taken successfully, proceed to scan screen*/
        void cameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            changeScreen();
            //don't need for now but this is where we will store the photo to memory 
        }
        /*Navigate to the scan page, which will show the results of the scanned tag after the camera has 
         * finished and the tag references have been loaded*/
        void changeScreen()
        {
            NavigationService.Navigate(new Uri("/Scan.xaml", UriKind.RelativeOrAbsolute));
        }   
        /*Navigate to Directions page, user needs to have scanned at least one tag to establish a starting location
         * before clicking the directions page as the directions page currently will simply assume the last location 
         * is the current location. To scan their new location the user should click on the scan button (on the 
         current page also).*/
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Directions.xaml", UriKind.RelativeOrAbsolute));
        }
        /*Navigate to Settings page to change the default settings of the application, such as 
         * font color, font size, avoidance of stairs, and background color*/
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
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
        /*Record button, will be used for the user to record instructions for the phone to perform. 
         * The user will speak instructions, finish recording and allow the phone to start analyzis. 
         * The recorded voice will be analyzed, voice-to-text generated, then the phone will respond
         * to the voice*/
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //No action taken currently
        }
        private void button1_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
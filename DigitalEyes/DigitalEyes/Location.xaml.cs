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
using Microsoft.Phone.Tasks;

namespace DigitalEyes
{
    public partial class Location : PhoneApplicationPage
    {
        CameraCaptureTask cameraCaptureTask1;
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        public Location()
        {
            InitializeComponent();
        }

        /*When the location page is navigated to the application will fetch the lcoation that the user typed into 
         * the destination textbox from the dictionary and use it to calculate directions as well as displaying it as
         * the page title*/
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            object LocationObject;

            if (phoneAppService.State.ContainsKey("Location"))
            {
                if (phoneAppService.State.TryGetValue("Location", out LocationObject))
                {
                    PageTitle.Text = "Directions to " + LocationObject.ToString();
                    try { textBlock1.Text = "Current location " + ConfigClass.current.name; }
                    catch { }
                    if ((LocationObject.ToString().Equals("restroom")) ||
                        (LocationObject.ToString().Equals("bathroom")))
                    {
                        if (ConfigClass.current.type.Equals("restroom") ||
                            ConfigClass.current.type.Equals("bathroom"))
                            textBlock1.Text = "Last scanned tag was a bathroom. You are at your destination or should scan a nearby tag.";
                        else if (ConfigClass.current.name.Equals("SEC3437"))
                        {
                            textBlock1.Text = ConfigClass.tag1.pathNext + ConfigClass.tag2.contDirNext;
                        }
                        else if (ConfigClass.current.name.Equals("Elevator")){
                            textBlock1.Text = ConfigClass.tag2.pathNext;
                        }
                    }
                    else if (LocationObject.ToString().Equals("SEC3437"))
                    {
                        if (ConfigClass.current.type.Equals("restroom") ||
                            ConfigClass.current.type.Equals("bathroom"))
                        {
                            textBlock1.Text = ConfigClass.tag3.pathLast + ConfigClass.tag2.contDirLast;
                        }
                        else if (ConfigClass.current.type.Equals("Elevator")){
                            textBlock1.Text = ConfigClass.tag2.pathLast;
                        }
                        else if (ConfigClass.current.name.Equals("SEC3437")){
                             textBlock1.Text = "Last scanned tag was SEC3437. You are at your destination or should scan a nearby tag.";
                        }
                    }
                    else if ((LocationObject.ToString().Equals("Elevator")) || 
                            (LocationObject.ToString().Equals("elevator")))
                    {
                        if (ConfigClass.current.type.Equals("restroom") ||
                            ConfigClass.current.type.Equals("bathroom"))
                        {
                            textBlock1.Text = ConfigClass.tag3.pathLast;
                        }
                        else if (ConfigClass.current.type.Equals("Elevator")){
                            textBlock1.Text = "Last scanned tag was an elevator. You are at your destination or should scan a nearby tag.";
                        }
                        else if (ConfigClass.current.name.Equals("SEC3437")){
                             textBlock1.Text = ConfigClass.tag1.pathNext;
                        }
                    }
                    else
                    {
                        textBlock2.Text = "Unknown location.";
                    }
                }
            }
            else
            {
                PageTitle.Text = "No Location Specified";
            }
            base.OnNavigatedTo(e);
        }

        /*Load and apply the saved values for the font size, background color, and font color*/
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
                }
            }
            /*Set font size on page, medium font objects*/
            if (phoneAppService.State.ContainsKey("MediumFontSize"))
            {
                if (phoneAppService.State.TryGetValue("MediumFontSize", out FontSizeObject))
                {
                    double mediumFontSize = Convert.ToDouble(FontSizeObject);

                    PageTitle.FontSize = mediumFontSize;
                    
                    button2.FontSize = mediumFontSize;
                    /*Ensures that buttons resize appropriately, changes the height of button along with the fontSize
                   * so that the font will fit inside the button box*/
                    if (mediumFontSize < 23)
                    {
                        button2.Height = mediumFontSize * 4;
                    }
                    else if (mediumFontSize < 30)
                    {
                        button2.Height = mediumFontSize * 3;
                    }
                    else
                    {
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
                    textBlock2.FontSize = smallFontSize;
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
                    ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    PageTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    textBlock1.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    textBlock2.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    button2.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
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
        /*Relaunch the camera, then navigate to the scan page to scan an intermediary tag. This is usefull if the
         * user has become confused about their current location en route to their destination, or simply wants more information
         * about the locations they are passing. They can scan another tag, receive information about that tag, then the app will
         * recalculate directions to their destination from the new current location*/
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

        /*Shortcut back to main page of the application in case the user has changed their mind about 
         * the actions they wish to perform, keeps the user from needing multiple clicks of the phone's
         * back button*/
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
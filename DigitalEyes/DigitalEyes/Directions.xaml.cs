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
    public partial class Directions : PhoneApplicationPage
    {
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        public Directions()
        {
            InitializeComponent();
        }

        /*When the user navigates away from the page the app will save the location that the user
         * input into the dictionary for future reference*/
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            phoneAppService.State["Location"] = textBox1.Text;
            base.OnNavigatedFrom(e);
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
                    PageTitle.FontSize = largeFontSize;
                }
            }
            /*Set font size on page, medium font objects*/
            if (phoneAppService.State.ContainsKey("MediumFontSize"))
            {
                if (phoneAppService.State.TryGetValue("MediumFontSize", out FontSizeObject))
                {
                    double mediumFontSize = Convert.ToDouble(FontSizeObject);

                    textBox1.FontSize = mediumFontSize;
                    button1.FontSize = mediumFontSize;
                    button2.FontSize = mediumFontSize;

                    /*Ensures that buttons resize appropriately, changes the height of button along with the fontSize
                     * so that the font will fit inside the button box*/
                    if (mediumFontSize < 23)
                    {
                        button1.Height = mediumFontSize * 4;
                        button2.Height = mediumFontSize * 4;
                        textBox1.Height = mediumFontSize * 4;
                    }
                    else if (mediumFontSize < 30)
                    {
                        button1.Height = mediumFontSize * 3;
                        button2.Height = mediumFontSize * 3;
                        textBox1.Height = mediumFontSize * 3;
                    }
                    else
                    {
                        button1.Height = mediumFontSize * 2.5;
                        button2.Height = mediumFontSize * 2.5;
                        textBox1.Height = mediumFontSize * 2.5;
                    }
                }
            }
            /*Set font size on page, small font objects*/
            if (phoneAppService.State.ContainsKey("SmallFontSize"))
            {
                if (phoneAppService.State.TryGetValue("SmallFontSize", out FontSizeObject))
                {
                    double smallFontSize = Convert.ToDouble(FontSizeObject);

                    textBlock1.FontSize = smallFontSize;
                    hyperlinkButton1.FontSize = smallFontSize;
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
            /*Set the font color of all text on the page*/
            if (phoneAppService.State.ContainsKey("FontColor"))
            {
                if (phoneAppService.State.TryGetValue("FontColor", out FC))
                {
                    string col = Convert.ToString(FC);
                    SolidColorBrush brush = new SolidColorBrush(GetColorFromHex(col).Color);
                    ApplicationTitle.Foreground = brush;
                    PageTitle.Foreground = brush;
                    textBlock1.Foreground = brush;
                    textBox1.Foreground = brush;
                    button1.Foreground = brush;
                    button2.Foreground = brush;
                    hyperlinkButton1.Foreground = brush;
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
        /*Clears the text in the text box when the box is clicked on. The box being clicked
         * on indicates that it has gained the focus and the keyboard will also pop up (default
         * behavior of phone)*/
        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
        }
        /*Shortcut back to main page of the application in case the user has changed their mind about 
         * the actions they wish to perform, keeps the user from needing multiple clicks of the phone's
         * back button*/
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void textBox1_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {

        }
    }
}
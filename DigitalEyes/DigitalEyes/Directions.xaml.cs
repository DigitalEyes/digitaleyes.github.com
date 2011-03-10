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
        public Directions()
        {
            InitializeComponent();
        }

/****************************CHANGE FONT SIZE DYNAMICALLY ****************************************/
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            phoneAppService.State["Location"] = textBox1.Text;
            base.OnNavigatedFrom(e);
        }

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

                    
                    textBox1.FontSize = mediumFontSize;
                    button1.FontSize = mediumFontSize;
                    //button2.FontSize = mediumFontSize;
                    
                    if (mediumFontSize < 23)
                    {
                        button1.Height = mediumFontSize * 4;
                        //button2.Height = mediumFontSize * 4;
                        textBox1.Height = mediumFontSize * 4;

                    }
                    else if (mediumFontSize < 30)
                    {
                        button1.Height = mediumFontSize * 3;
                        //button2.Height = mediumFontSize * 3;
                        textBox1.Height = mediumFontSize * 3;
                    }
                    else
                    {
                        button1.Height = mediumFontSize * 2.5;
                        //button2.Height = mediumFontSize * 2.5;
                        textBox1.Height = mediumFontSize * 2.5;
                    }

                }
            }

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
                    textBlock1.Foreground = brush;
                    textBox1.Foreground = brush;
                    button1.Foreground = brush;
                    //button2.Foreground = brush;
                    hyperlinkButton1.Foreground = brush;
                }
            }

        }
/**********************************END CHANGE FONT SIZE DYNAMICALLY ******************************/
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

        private void textBox1_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {

        }

    }
}
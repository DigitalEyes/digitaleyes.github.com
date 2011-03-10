﻿using System;
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
    public partial class Location : PhoneApplicationPage
    {
        public Location()
        {
            InitializeComponent();
        }
/****************************CHANGE FONT SIZE DYNAMICALLY ****************************************/
        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            object LocationObject;

            if (phoneAppService.State.ContainsKey("Location"))
            {
                if (phoneAppService.State.TryGetValue("Location", out LocationObject))
                {
                    PageTitle.Text = LocationObject.ToString();
                    
                }
            }
            else
            {
                PageTitle.Text = "No Location Specified";
            }
            base.OnNavigatedTo(e);
            


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

                }
            }
            if (phoneAppService.State.ContainsKey("MediumFontSize"))
            {
                if (phoneAppService.State.TryGetValue("MediumFontSize", out FontSizeObject))
                {
                    double mediumFontSize = Convert.ToDouble(FontSizeObject);

                    PageTitle.FontSize = mediumFontSize;
                    textBlock1.FontSize = mediumFontSize;
                    textBlock2.FontSize = mediumFontSize;
                    textBlock3.FontSize = mediumFontSize;
                    textBlock4.FontSize = mediumFontSize;
                    button1.FontSize = mediumFontSize;

   

                }
            }
            if (phoneAppService.State.ContainsKey("SmallFontSize"))
            {
                if (phoneAppService.State.TryGetValue("SmallFontSize", out FontSizeObject))
                {
                    double smallFontSize = Convert.ToDouble(FontSizeObject);
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
                    ApplicationTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    PageTitle.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    textBlock1.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    textBlock2.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    textBlock3.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    textBlock4.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
                    button1.Foreground = new SolidColorBrush(GetColorFromHex(col).Color);
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Scan.xaml", UriKind.RelativeOrAbsolute));
        }

       
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;


namespace Comp7211GroupProject
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeNav : Xamarin.Forms.TabbedPage
    {
        public HomeNav()
        {
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetIsSwipePagingEnabled(false);
            On<Android>().SetBarSelectedItemColor(Color.Black);
            On<Android>().SetBarItemColor(Color.FromHex("#737373"));
            this.CurrentPageChanged += TabbedPage_CurrentPageChanged;

            InitializeComponent();

            Children.Add(new HomePage());
            Children.Add(new ContactPage());
            Children.Add(new SettingsPage());
            Children[0].IconImageSource = "homedark.png";
            Children[0].Title = "Home";
            Children[1].IconImageSource = "contactdark.png";
            Children[1].Title = "Contact";
            Children[2].IconImageSource = "settingicon.png";
            Children[2].Title = "Settings";

            CurrentPage = Children[0]; //The page it loads first (Home Page)
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            if (CurrentPage == Children[0])
            {
                this.Title = "Home";
            }
            else if (CurrentPage == Children[1])
            {
                this.Title = "Contact";
            }
            else if (CurrentPage == Children[2])
            {
                this.Title = "Settings";
            }
        }
    }
}
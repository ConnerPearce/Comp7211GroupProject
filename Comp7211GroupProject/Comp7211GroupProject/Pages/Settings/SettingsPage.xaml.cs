using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comp7211GroupProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Logout?", "Are you sure you want to logout?", "Yes","No");
            if (answer)
                await Navigation.PushModalAsync(new LoginPage());
            else
                return;

        }

        private void btnShowStackTheme_Clicked(object sender, EventArgs e)
        {
            if (StackThemeLayout.IsVisible == true)
            {
                StackThemeLayout.IsVisible = false;
            }
            else
            {
                StackThemeLayout.IsVisible = true;
            }
        }

        private void btnShowStackNickname_Clicked(object sender, EventArgs e)
        {
            if (StackNicknameLayout.IsVisible == true)
            {
                StackNicknameLayout.IsVisible = false;
            }
            else
            {
                StackNicknameLayout.IsVisible = true;
            }
        }

        private void btnShowStackPassword_Clicked(object sender, EventArgs e)
        {
            if (StackPasswordLayout.IsVisible == true)
            {
                StackPasswordLayout.IsVisible = false;
            }
            else
            {
                StackPasswordLayout.IsVisible = true;
            }
        }
    }
}
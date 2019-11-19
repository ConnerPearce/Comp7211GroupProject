using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.API.Proxys;
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

        private void btnSaveNickname_Clicked(object sender, EventArgs e)
        {
            SaveNickname();
        }

        private void btnSavePassword_Clicked(object sender, EventArgs e)
        {
            SavePassword();
        }

        UserProxy userProxy = new UserProxy("https://comp7211groupprojectapi20191115092109.azurewebsites.net/");

        private async void SavePassword()
        {

            if (MainPage.user.Pword == txtOldPassword.Text)
            {
                if (txtNewPassword.Text == txtConfirmNewPassword.Text)
                {
                    MainPage.user.Pword = txtConfirmNewPassword.Text;
                    txtOldPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmNewPassword.Text = "";
                    await DisplayAlert("SUCCESS", "Successfuly changed Password", "Ok");
                }
                else
                {
                    await DisplayAlert("Password Error", "New Passwords do not match!", "Try Again!");
                }
            }
            else
            {
                await DisplayAlert("Password Error", "Old Password is incorrect!", "Try Again!");
            }
        }

        private async void SaveNickname()
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                if (MainPage.user.Pword == txtConfirmPassword.Text)
                {
                    MainPage.user.Nickname = txtNickname.Text;
                    txtNickname.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    await DisplayAlert("Result of Changes", $"{await userProxy.PostUserInfo((Users)MainPage.user)}", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Password Error", "Passwords do not match!", "Try Again!");
            }
        }

        private void btnAboutMe_Clicked(object sender, EventArgs e) //For Karl - 
        {
            if (stackAboutMe.IsVisible == true)
            {
                stackAboutMe.IsVisible = false;
            }
            else
            {
                stackAboutMe.IsVisible = true;
            }
        }
    }
}
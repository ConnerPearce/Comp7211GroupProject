using Autofac;
using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.LoginPage;
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
    public partial class LoginPage : ContentPage
    {
        private IContainer container;
        //private Users login;
        public LoginPage()//(LoginModel loginMdl) inside LoginPage()
        {
            InitializeComponent();
            //this.login = loginMdl;
        }

        private void btnLogin_Clicked(object sender, EventArgs e) //async
        {
            StartLogin();
        }

        public async void StartLogin()
        {
            try
            {
                container = DependancyInjection.Configure();

                using (var scope = container.BeginLifetimeScope())
                {
                    var app = scope.Resolve<ILoginBackend>();
                    string validation = app.CheckInfo(txtStudentID.Text, txtPassword.Text);
                    if (validation == null)
                    {
                        var user = await app.Login(txtStudentID.Text, txtPassword.Text);

                        if (user != null)
                        {
                            MainPage.user = (Users)user;
                            await Navigation.PopModalAsync();
                        }
                        else
                            await DisplayAlert("Error", "The Login details provided are incorrect, Try again", "Ok");
                    }
                    else
                        await DisplayAlert("Error", $"{validation}", "Ok");
                }
            }
            catch
            {
                await DisplayAlert("Error", "Something went wrong, please try again", "Ok");
            }

           
        }
    }
}
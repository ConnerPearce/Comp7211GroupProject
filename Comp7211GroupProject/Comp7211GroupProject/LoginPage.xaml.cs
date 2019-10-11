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
        //private LoginModel login;
        public LoginPage()//(LoginModel loginMdl) inside LoginPage()
        {
            InitializeComponent();
            //this.login = loginMdl;
        }

        private async void btnLogin_Clicked(object sender, EventArgs e) //async
        {
            await Navigation.PopModalAsync();
            //Button login = (Button)sender;

            //try
            //{
            //    //Login logic
            //    //if(loginSuccess)
            //    //{
            //    //    //await Navigation.PopModalAsync();
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    // error message
            //}
        }
    }
}
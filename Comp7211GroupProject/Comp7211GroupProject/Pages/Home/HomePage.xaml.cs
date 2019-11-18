using Autofac;
using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.API.Proxys;
using Comp7211GroupProject.Classes.HomePage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comp7211GroupProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        PostProxy postsProxy = new PostProxy("https://comp7211groupprojectapi20191115092109.azurewebsites.net/");

        public HomePage()
        {
            InitializeComponent();
            stackCreatePost.IsVisible = false;
            stackPosts.IsVisible = true;

        }

        private void btnCreatePost_Clicked(object sender, EventArgs e)
        {
            if (stackCreatePost.IsVisible == false)
            {
                stackPosts.IsVisible = false;
                stackCreatePost.IsVisible = true;
            }
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            stackCreatePost.IsVisible = false;
            stackPosts.IsVisible = true;
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            //Send Created Post to Listview
            stackCreatePost.IsVisible = false;
            stackPosts.IsVisible = true;
            if (!String.IsNullOrEmpty(txtMessage.Text))
            {
                string response = await postsProxy.PostPosts(new Posts { Post = txtMessage.Text, Uid = 1 });
                await DisplayAlert("Progress", response , "Ok");
            }
            else
                await DisplayAlert("Error", "The Message box must not be left empty!, Try again", "Ok");

        }
    }
}
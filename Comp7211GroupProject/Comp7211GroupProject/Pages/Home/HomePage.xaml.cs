﻿using Autofac;
using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.HomePage;
using Comp7211GroupProject.Pages.Home;
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
        private IContainer container;
        List<Posts> posts = new List<Posts>();

        public HomePage()
        {
            InitializeComponent();
            stackCreatePost.IsVisible = false;
            stackPosts.IsVisible = true;

          // GetPosts();
        }

        private async void GetPosts()
        {
            try
            {
                container = DependancyInjection.Configure();

                using (var scope = container.BeginLifetimeScope())
                {
                    var app = scope.Resolve<IHomeBackend>();

                    var temp = app.PostList;
                    if (temp != null)
                    {
                        posts = temp;
                    }
                    else
                        await DisplayAlert("Error", "There was an error retrieving the posts, Reload the page", "Ok");

                }
            }
            catch
            {
                await DisplayAlert("Error", "There was an error retrieving the posts, Reload the page", "Ok");
            }
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
            if (String.IsNullOrEmpty(txtMessage.Text))
            {
                await DisplayAlert("Error", "The Message box must not be left empty!, Try again", "Ok");
            }
            else
                await Navigation.PopModalAsync();
        }

        //tap on a post and it will expand on it allow you to like or private message
        private void lblViewPost_Tapped(object sender, EventArgs e)
        {
            ViewPostPage veiwPost = new ViewPostPage();

            this.Navigation.PushModalAsync(veiwPost);
        }
    }
}
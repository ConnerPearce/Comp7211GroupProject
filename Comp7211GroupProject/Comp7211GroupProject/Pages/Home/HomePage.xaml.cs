using Autofac;
using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.API.Proxys;
using Comp7211GroupProject.Classes.HomePage;
using Comp7211GroupProject.Classes.ContactPage.Message;
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
        CommentsProxy commentsProxy = new CommentsProxy("https://comp7211groupprojectapi20191115092109.azurewebsites.net/");
        private readonly IMessagesProxy _messagesProxy = new MessagesProxy("https://comp7211groupprojectapi20191115092109.azurewebsites.net/");
        private IPosts post = new Posts();
        bool liked;
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
                string response = await postsProxy.PostPosts(new Posts { Post = txtMessage.Text, Uid = MainPage.user.Id });
                await DisplayAlert("Progress", response , "Ok");
            }
            else
                await DisplayAlert("Error", "The Message box must not be left empty!, Try again", "Ok");
        }

        //tap on a post and it will expand on it allow you to like or private message


        private void viewPost_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            post = (IPosts)e.SelectedItem;
            if (stackCreatePost.IsVisible == false)
            {
                if (post != null)
                {
                    txtViewPost.Text = post.Post;
                    stackPosts.IsVisible = false;
                    stackViewPost.IsVisible = true;

                    HomeBackend hBackend = new HomeBackend();
                    hBackend.GetCommentsInfo(post.Id);
                    if (hBackend.CommentsList != null)
                    {
                        lstComments.ItemsSource = hBackend.CommentsList;
                    }
                }
            } 
        }

        private void btnVPBack_Clicked(object sender, EventArgs e)
        {
            stackPosts.IsVisible = true;
            stackViewPost.IsVisible = false;
            lstViewPosts.SelectedItem = null;
            txtViewPost.Text = String.Empty;
        }

        private void btnVPPrivateMsg_Clicked(object sender, EventArgs e)
        {
            stackPrivateM.IsVisible = true;
            stackViewPost.IsVisible = false;
        }

        private void btnVPUpVote_Clicked(object sender, EventArgs e)
        {
            if (liked == false)
            {
                (sender as ImageButton).Source = "arrowUp2.png";
                liked = true;
            }
            else
            {
                (sender as ImageButton).Source = "arrowUp1.png";
                liked = false;
            }
        }

        private async void btnSendComment_Clicked(object sender, EventArgs e)//sends comment
        {
            if (!String.IsNullOrEmpty(txtComment.Text))
            {
                string response = await commentsProxy.PostComments(new Comments { Comment = txtComment.Text, PostId = post.Id, Uid = MainPage.user.Id });
                await DisplayAlert("Comment Sent", response, "Ok");
                txtComment.Text = String.Empty;
            }
        }

        private void btnPMCancel_Clicked(object sender, EventArgs e)//brings the you back from Private Message page to View Posts page
        {
            stackPrivateM.IsVisible = false;
            stackViewPost.IsVisible = true;
        }

        private async void btnPMSubmit_Clicked(object sender, EventArgs e)
        {
            MessagesBackend _messagesBack = new MessagesBackend();

            string response = await _messagesBack.SendMessages(txtPrivateMessage.Text, post.Uid);
            await DisplayAlert("Comment Sent", response, "Ok");
            txtPrivateMessage.Text = String.Empty;

            //var result = await _messagesProxy.PostMessage(new Messages { ReceiverId = post, SenderId = MainPage.user.Id, Msg = txtPrivateMessage.Text });
            //await DisplayAlert("Comment Sent", result, "Ok");
        }
    }
}
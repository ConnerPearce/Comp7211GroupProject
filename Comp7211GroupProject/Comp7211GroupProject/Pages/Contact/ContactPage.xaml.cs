using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;
using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.API.Proxys;

namespace Comp7211GroupProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : Xamarin.Forms.TabbedPage
    {
        private readonly IMessagesProxy _messageProxy = new MessagesProxy("https://comp7211groupprojectapi20191115092109.azurewebsites.net/");
        private Messages msgMod = new Messages();

        public ContactPage()
        {
            On<Android>().SetBarSelectedItemColor(Color.Black);
            On<Android>().SetBarItemColor(Color.FromHex("#737373"));
            InitializeComponent();
            MsgStack.IsVisible = true;
            ReplyStack.IsVisible = false;
        }

        public ContactPage(IMessagesProxy messagesProxy)
        {
            _messageProxy = messagesProxy;
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            FormValidation();
        }

        private async void FormValidation()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtPhone.Text) || 
                string.IsNullOrWhiteSpace(txtEmail.Text) || 
                string.IsNullOrWhiteSpace(txtTopic.Text) || 
                string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                await DisplayAlert("ERROR", "Empty fields detected", "Try Again");
            }
            else
            {
                await DisplayAlert("SUCCESS", "Email Sent", "OK");
            }
        }






        //Message page stuff
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            msgMod = (Messages)e.SelectedItem;

            if(ReplyStack.IsVisible == false)
            {
                MsgStack.IsVisible = false;
                ReplyStack.IsVisible = true;
            }
        }

        private void btnCancelMsg_Clicked(object sender, EventArgs e)
        {
            MsgStack.IsVisible = true;
            ReplyStack.IsVisible = false;
        }

        private async void btnSubmitMsg_Clicked(object sender, EventArgs e)
        {
            MsgStack.IsVisible = true;
            ReplyStack.IsVisible = false;

            if(!String.IsNullOrEmpty(txtMsg.Text))
            {
                var temp = await _messageProxy.PostMessage(new Messages { ReceiverId = msgMod.SenderId, SenderId = msgMod.ReceiverId, Msg = txtMsg.Text });
                await DisplayAlert("Progress of Message", temp, "Ok");
                await Navigation.PopModalAsync();
            }
        }
    }
}
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
        private IMessages msgMod = new Messages();

        public ContactPage()
        {          
            InitializeComponent();
            On<Android>().SetBarSelectedItemColor(Color.Black);
            On<Android>().SetBarItemColor(Color.FromHex("#737373"));
            MsgStack.IsVisible = true;
            ReplyStack.IsVisible = false;
        }

        //Form page functions
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

        //Message page functions
        private void lstMsg_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            msgMod = (IMessages)e.SelectedItem;
            if (msgMod != null)
            {
                lblMsgPreview.Text = ($"Replying To: '{msgMod.Msg}'");
                MsgStack.IsVisible = false;
                ReplyStack.IsVisible = true;
            }      
        }

        private void btnCancelMsg_Clicked(object sender, EventArgs e)
        {
            MsgStack.IsVisible = true;
            ReplyStack.IsVisible = false;
            lstMsg.SelectedItem = null;
        }

        private async void btnSendMsg_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMsg.Text))
            {
                string response = await _messageProxy.PostMessage(new Messages { ReceiverId = msgMod.SenderId, SenderId = msgMod.ReceiverId, Msg = txtMsg.Text });
                await DisplayAlert("Reply Sent", response, "Ok");
                MsgStack.IsVisible = true;
                ReplyStack.IsVisible = false;
            }
        }
    }
}
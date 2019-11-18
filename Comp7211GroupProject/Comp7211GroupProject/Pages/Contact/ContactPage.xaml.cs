using System;
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
    public partial class ContactPage : Xamarin.Forms.TabbedPage
    {
        public ContactPage()
        {
            On<Android>().SetBarSelectedItemColor(Color.Black);
            On<Android>().SetBarItemColor(Color.FromHex("#737373"));
            InitializeComponent();
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
    }
}
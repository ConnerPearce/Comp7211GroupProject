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
            if (txtName.Text == "" || txtPhone.Text == "" || txtEmail.Text == "" || txtTopic.Text == "" || txtMessage.Text == "")
            {
                await DisplayAlert("ERROR", "Empty Fields Detected", "Try Again");
            }
            else
            {
                await DisplayAlert("SUCCESS", "Email Sent", "OK");
            }
        }
    }
}
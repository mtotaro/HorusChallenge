using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horus.Forms.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OkActionPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        public OkActionPopUp(string title, string description)
        {
            InitializeComponent();

            lblTitle.Text = title;
            lblDescription.Text = description;
        }

        private async void btnOk_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
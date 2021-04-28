using Horus.Core;
using Horus.Core.Messages;
using Horus.Core.ViewModels;
using Horus.Forms.Components;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horus.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class LoginPage : MvxContentPage<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, string.Empty);
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginViewModel, OkActionPopupMessage>(this, Constants.LoginMsg, async (sender, message) =>
            {
                await PopupNavigation.Instance.PushAsync(new OkActionPopUp(message.Title, message.Description));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<LoginViewModel, OkActionPopupMessage>(this, Constants.LoginMsg);
        }
    }
}
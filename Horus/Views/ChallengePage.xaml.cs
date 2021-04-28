using Horus.Core;
using Horus.Core.Messages;
using Horus.Core.ViewModels;
using Horus.Forms.Components;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horus.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class ChallengePage : MvxContentPage<ChallengeViewModel>
    { 
        public ChallengePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ChallengeViewModel, OkActionPopupMessage>(this, Constants.AlertChallengeMsg, async (sender, message) =>
            {
                await PopupNavigation.Instance.PushAsync(new OkActionPopUp(message.Title, message.Description));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<ChallengeViewModel, OkActionPopupMessage>(this, Constants.AlertChallengeMsg);
        }
    }
}
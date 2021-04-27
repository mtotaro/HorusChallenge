using Horus.Core.ViewModels;
using MvvmCross.Forms.Views;
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
    public partial class ChallengePage : MvxContentPage<ChallengeViewModel>
    { 
        public ChallengePage()
        {
            InitializeComponent();
        }
    }
}
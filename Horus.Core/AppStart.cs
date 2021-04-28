using Horus.Core.Helpers.Interface;
using Horus.Core.ViewModels;
using MvvmCross.Exceptions;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly IStorageHelper _storageHelper;
        private IMvxNavigationService _navigationService;

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService, IStorageHelper storageHelper) : base(application, navigationService)
        {
            _storageHelper = storageHelper;
            _navigationService = navigationService;
         

        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            try
            {

                await NavigationService.Navigate<LoginViewModel>();

            }
            catch (Exception exception)
            {
                throw exception.MvxWrap("Problem navigating to ViewModel {0}", typeof(LoginViewModel).Name);
            }
        }

        
    }
}

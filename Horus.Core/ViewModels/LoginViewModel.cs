using Horus.Core.Helpers.Interface;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private readonly IMvxNavigationService _navigationService;
        private readonly IStorageHelper _storageHelper;
        #endregion

        #region Constructor
        public LoginViewModel(
                              IMvxNavigationService navigationService,
                              IStorageHelper storageHelper
                              )
        {
            _navigationService = navigationService;
            _storageHelper = storageHelper;
        }
        #endregion

    }
}


using Horus.Core.Helpers.Interface;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private readonly IMvxNavigationService _navigationService;
        private readonly IStorageHelper _storageHelper;
        private string _email;
        private string _password;
        const string emailRegex = @"( |^)[^ ]*@horus\.com( |$)";
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

        #region MVVM Properties
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(() => Email);
            }
        }

        #endregion

        #region MVVM Commands
        // MVVM Commands
        public IMvxAsyncCommand LoginCommand => new MvxAsyncCommand(LoginAsync);

        #endregion

        #region Private methods
        // Private methods
        public async Task LoginAsync()
        {
            try
            {


            }
            catch (Exception ex)
            {
            
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}


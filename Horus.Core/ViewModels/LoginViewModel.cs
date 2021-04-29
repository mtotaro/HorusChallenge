using Horus.Core.Helpers.Interface;
using Horus.Core.Messages;
using Horus.Core.Models;
using Horus.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Horus.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private readonly IMvxNavigationService _navigationService;
        private readonly IStorageHelper _storageHelper;
        private readonly ILoginService _loginService;
        private readonly IChallengeService _challengeService;
        private string _email;
        private string _password;
        const string emailRegex = @"( |^)[^ ]*@mail\.com( |$)";
        private readonly IMessagingCenter _messagingCenter;
        private readonly IPopupNavigationService _popupNavigationService;
        public bool CanNavigate { get; } = true;
        private bool _isLoading;
        private bool _hideOnLoading;
        #endregion

        #region Constructor
        public LoginViewModel(
                              IMvxNavigationService navigationService,
                              IStorageHelper storageHelper,
                              ILoginService loginService,
                              IChallengeService challengeService,
                              IMessagingCenter messagingCenter,
                              IPopupNavigationService popupNavigationService
                              )
        {
            _navigationService = navigationService;
            _storageHelper = storageHelper;
            _loginService = loginService;
            _challengeService = challengeService;
            _messagingCenter = messagingCenter;
            _popupNavigationService = popupNavigationService;

            LoginCommand = new MvxAsyncCommand(LoginAsync);
            ForgotPasswordCommand = new MvxAsyncCommand(ForgotPassword);
            InstagramCommand = new MvxAsyncCommand(RedirectInstagram);
            FacebookCommand = new MvxAsyncCommand(RedirectFacebook);
            RegisterCommand = new MvxAsyncCommand(RedirectRegister);
        }
        #endregion

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            //did this because password wasnt updating in the ui 
            Password = String.Empty;
            Email = String.Empty;
        }

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

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public bool HideOnLoading
        {
            get { return !_hideOnLoading; }
            set { SetProperty(ref _hideOnLoading, value); }
        }

        #endregion

        #region MVVM Commands
        // MVVM Commands
        public IMvxAsyncCommand LoginCommand { get; private set; }
        public IMvxCommand ForgotPasswordCommand { get; private set; }
        public IMvxCommand InstagramCommand { get; private set; }
        public IMvxCommand FacebookCommand { get; private set; }
        public IMvxCommand RegisterCommand { get; private set; }
        #endregion

        #region Private methods
        // Private methods
        public async Task LoginAsync()
        {
            try
            {
                IsLoading = true;
                HideOnLoading = true;

                if (!ValidateEmail())
                    return;

                var user = new Dtos.SignIn.UserSignInRequest
                {
                    Email = Email,
                    Password = Password
                };

                var userSigned = await _loginService.OnSignInAsync(user);
                if (userSigned != null)
                {
                    await _storageHelper.SetAccessToken(userSigned.authorizationToken);
                    // call the challengeService 
                    var resultChallenge = await _challengeService.ChallengeList();
                    var auxChallenge = new List<Challenge>();
                    foreach (var item in resultChallenge)
                    {
                        var singleChallenge = new Challenge()
                        {
                            Id = item.Id,
                            CurrentPoints = item.CurrentPoints,
                            Description = item.Description,
                            Title = item.Title,
                            TotalPoints = item.TotalPoints

                        };

                        auxChallenge.Add(singleChallenge);
                    }

                    var challengeList = new MvxObservableCollection<Challenge>(auxChallenge);

                    await _navigationService.Navigate<ChallengeViewModel, MvxObservableCollection<Challenge>>(challengeList);
                }
                await Task.Delay(100);
                //clean the model
                IsLoading = false;
                HideOnLoading = false;
                Email = String.Empty;
                Password = String.Empty;
                _password = String.Empty;
            }
            catch (Exception ex)
            {
                IsLoading = false;
                HideOnLoading = false;
                var message = new OkActionPopupMessage()
                {
                    Title = "Error",
                    Description = ex.Message
                };
                _messagingCenter.Send<LoginViewModel, OkActionPopupMessage>(this, Constants.LoginMsg, message);
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        private async Task ForgotPassword()
        {
            var message = new OkActionPopupMessage()
            {
                Title = "Olvidaste tu contraseña"
            };

            _messagingCenter.Send<LoginViewModel, OkActionPopupMessage>(this, Constants.LoginMsg, message);

            return;
        }

        private async Task RedirectInstagram()
        {
            var message = new OkActionPopupMessage()
            {
                Title = "Instagram"
            };

            _messagingCenter.Send<LoginViewModel, OkActionPopupMessage>(this, Constants.LoginMsg, message);

            return;
        }

        private async Task RedirectFacebook()
        {
            var message = new OkActionPopupMessage()
            {
                Title = "Facebook"
            };

            _messagingCenter.Send<LoginViewModel, OkActionPopupMessage>(this, Constants.LoginMsg, message);

            return;
        }


        private async Task RedirectRegister()
        {
            var message = new OkActionPopupMessage()
            {
                Title = "Registrarme"
            };

            _messagingCenter.Send<LoginViewModel, OkActionPopupMessage>(this, Constants.LoginMsg, message);

            return;
        }
        public bool ValidateEmail()
        {
            bool isEmailValid = false;
            if (!String.IsNullOrEmpty(Email))
                isEmailValid = (Regex.IsMatch(Email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isEmailValid)
            {

                // MOSTRAR POPUP DE ERROR
                IsLoading = false;
                HideOnLoading = false;
                var message = new OkActionPopupMessage()
                {
                    Title = "Something went wrong",
                    Description = "Please write a valid email address.",
                };

                _messagingCenter.Send<LoginViewModel, OkActionPopupMessage>(this, Constants.LoginMsg, message);

                return false;
            }
            return true;
        }


        #endregion
    }
}


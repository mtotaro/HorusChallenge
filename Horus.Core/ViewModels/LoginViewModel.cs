using Horus.Core.Helpers.Interface;
using Horus.Core.Models;
using Horus.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
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
        private readonly ILoginService _loginService;
        private readonly IChallengeService _challengeService;
        private string _email;
        private string _password;
        const string emailRegex = @"( |^)[^ ]*@horus\.com( |$)";
        #endregion

        #region Constructor
        public LoginViewModel(
                              IMvxNavigationService navigationService,
                              IStorageHelper storageHelper,
                              ILoginService loginService,
                              IChallengeService challengeService
                              )
        {
            _navigationService = navigationService;
            _storageHelper = storageHelper;
            _loginService = loginService;
            _challengeService = challengeService;
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
                var user = new User
                {
                    EmailAddress = Email,
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
                            TotalPoint = item.TotalPoint

                        };

                        auxChallenge.Add(singleChallenge);
                    }

                    var challengeList = new MvxObservableCollection<Challenge>(auxChallenge);
                    await _navigationService.Navigate<ChallengeViewModel, MvxObservableCollection<Challenge>>(challengeList);

                }



            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}


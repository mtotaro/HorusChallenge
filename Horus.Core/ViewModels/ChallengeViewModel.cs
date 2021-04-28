using Horus.Core.Helpers.Interface;
using Horus.Core.Messages;
using Horus.Core.Models;
using Horus.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Horus.Core.ViewModels
{
    public class ChallengeViewModel : BaseViewModel<MvxObservableCollection<Challenge>>
    {
        #region Attributes
        private readonly IMvxNavigationService _navigationService;
        private IStorageHelper _storageHelper;
        private MvxObservableCollection<Challenge> _challengeList;
        private int _countChallengesCompleted;
        private int _totalChallenges;
        private Challenge _selectedItem;
        private readonly IMessagingCenter _messagingCenter;
        private readonly IPopupNavigationService _popupNavigationService;
        #endregion

        #region Constructor
        public ChallengeViewModel(IMvxNavigationService navigationService, IStorageHelper storageHelper, IMessagingCenter messagingCenter, IPopupNavigationService popupNavigationService)
        {
            _navigationService = navigationService;
            _storageHelper = storageHelper;
            _messagingCenter = messagingCenter;
            _popupNavigationService = popupNavigationService;
            _challengeList = new MvxObservableCollection<Challenge>();
         
        }


        public override void Prepare(MvxObservableCollection<Challenge> challenges)
        {
            try
            {
                base.Prepare();
                TotalChallenges = challenges.Count;
                CountChallengesCompleted = challenges.Count(x => x.IsCompletedChallenge);
                ChallengeList = new MvxObservableCollection<Challenge>(challenges);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }

            return;
        }

        #endregion

        #region MVVM Properties

        public MvxObservableCollection<Challenge> ChallengeList
        {
            get => _challengeList ?? new MvxObservableCollection<Challenge>();
            set
            {
                _challengeList = value;
                RaisePropertyChanged(() => ChallengeList);
            }
        }

        public int CountChallengesCompleted
        {
            get => _countChallengesCompleted;
            set
            {
                SetProperty(ref _countChallengesCompleted, value);
                RaisePropertyChanged(() => CountChallengesCompleted);
            }
        }

        public int TotalChallenges
        {
            get => _totalChallenges;
            set
            {
                SetProperty(ref _totalChallenges, value);
                RaisePropertyChanged(() => TotalChallenges);
            }
        }

        public Challenge SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        #endregion

        #region MVVM Commands
        // MVVM Commands
        public IMvxCommand ShowSelectedItemCommand => new MvxAsyncCommand<Challenge>(ChallengeSelected);
        //public IMvxCommand ShowSelectedItemCommand { get; private set; }
        #endregion

        #region Private methods
        // Private methods
        private async Task ChallengeSelected(Challenge selectedChallenge)
        {
            if (SelectedItem == null)
                return;

            try
            {
                var message = new OkActionPopupMessage()
                {
                    Title = SelectedItem.Title,
                    Description = SelectedItem.Description,
                };

                _messagingCenter.Send<ChallengeViewModel, OkActionPopupMessage>(this, Constants.AlertChallengeMsg, message);
                SelectedItem = null;
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        #endregion
    }
}


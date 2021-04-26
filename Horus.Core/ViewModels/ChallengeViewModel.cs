using Horus.Core.Helpers.Interface;
using Horus.Core.Models;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Horus.Core.ViewModels
{
    public class ChallengeViewModel : BaseViewModel<MvxObservableCollection<Challenge>>
    {
        #region Attributes
        private readonly IMvxNavigationService _navigationService;
        private IStorageHelper _storageHelper;
        private MvxObservableCollection<Challenge> _challengeList;
        #endregion

        #region Constructor
        public ChallengeViewModel(IMvxNavigationService navigationService, IStorageHelper storageHelper)
        {
            _navigationService = navigationService;
            _storageHelper = storageHelper;
            _challengeList = new MvxObservableCollection<Challenge>();

        }

        public override void Prepare(MvxObservableCollection<Challenge> challenges)
        {
            try
            {
                base.Prepare();
                Challenges = new MvxObservableCollection<Challenge>(challenges);
             
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            
            }

            return;
        }

        #endregion

        #region MVVM Properties
        public MvxObservableCollection<Challenge> Challenges
        {
            get
            {
                return _challengeList;
            }
            set
            {
                _challengeList = value;
                RaisePropertyChanged(() => _challengeList);
            }
        }


        #endregion

        #region MVVM Commands
        // MVVM Commands

        #endregion

        #region Private methods
        // Private methods

        #endregion
    }
}


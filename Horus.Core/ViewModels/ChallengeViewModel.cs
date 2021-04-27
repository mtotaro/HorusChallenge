using Horus.Core.Helpers.Interface;
using Horus.Core.Models;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region Constructor
        public ChallengeViewModel(IMvxNavigationService navigationService, IStorageHelper storageHelper)
        {
            _navigationService = navigationService;
            _storageHelper = storageHelper;
            _challengeList = new MvxObservableCollection<Challenge>();

        }

        public override async Task Initialize()
        {
            await base.Initialize();
            var chlg1 = new Challenge()
            {
                Id = new Guid("9ac61141-2a25-49a0-a1f4-029d395aa9de"),
                Title = "Invitar Amigos II",
                Description = "Invita a 10 amigos a participar en el proyecto para que compartan sus looks.",
                CurrentPoints = 10,
                TotalPoints = 10

            };
            var chlg2 = new Challenge()
            {
                Id = new Guid("595831ae-f2a4-4465-ac4b-720095358dd0"),
                Title = "Experta en Looks",
                Description = "Publica 50 looks y convertite en experta.",
                CurrentPoints = 47,
                TotalPoints = 50

            };
            var chlg3 = new Challenge()
            {
                Id = new Guid("6837d95f-a498-4afe-bb08-7cb82572b06f"),
                Title = "Publicaciones III",
                Description = "Realiza tus primeras 10 publicaciones de looks.",
                CurrentPoints = 9,
                TotalPoints = 10

            };
            try
            {
                ChallengeList = new MvxObservableCollection<Challenge>
                {
                    chlg1,
                    chlg2,
                    chlg3
                 };

                _totalChallenges = ChallengeList.Count;
                _countChallengesCompleted = 0;
                foreach (var item in ChallengeList)
                {
                    if (item.TotalPoints == item.CurrentPoints)
                        _countChallengesCompleted++;

                }




            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }

        }

        public override void Prepare(MvxObservableCollection<Challenge> challenges)
        {
            try
            {
                base.Prepare();
                var chlg1 = new Challenge()
                {
                    Id = new Guid("9ac61141-2a25-49a0-a1f4-029d395aa9de"),
                    Title = "Invitar Amigos II",
                    Description = "Invita a 10 amigos a participar en el proyecto para que compartan sus looks.",
                    CurrentPoints = 10,
                    TotalPoints = 10

                };
                var chlg2 = new Challenge()
                {
                    Id = new Guid("595831ae-f2a4-4465-ac4b-720095358dd0"),
                    Title = "Experta en Looks",
                    Description = "Publica 50 looks y convertite en experta.",
                    CurrentPoints = 47,
                    TotalPoints = 50

                };
                var chlg3 = new Challenge()
                {
                    Id = new Guid("6837d95f-a498-4afe-bb08-7cb82572b06f"),
                    Title = "Publicaciones III",
                    Description = "Realiza tus primeras 10 publicaciones de looks.",
                    CurrentPoints = 9,
                    TotalPoints = 10

                };
                ChallengeList = new MvxObservableCollection<Challenge>();
                ChallengeList.Add(chlg1);
                ChallengeList.Add(chlg2);
                ChallengeList.Add(chlg3);

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

        #endregion

        #region MVVM Commands
        // MVVM Commands

        #endregion

        #region Private methods
        // Private methods

        #endregion
    }
}


using FluentAssertions;
using FluentAssertions.Execution;
using Horus.Core;
using Horus.Core.Dtos.Challenge;
using Horus.Core.Dtos.SignIn;
using Horus.Core.Helpers.Interface;
using Horus.Core.Messages;
using Horus.Core.Models;
using Horus.Core.Services.Interfaces;
using Horus.Core.ViewModels;
using Horus.Tests.DummyDataProviders.Models;
using Horus.Tests.Fixture;
using Moq;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xunit;

namespace Horus.Tests.Core.ViewModel
{
    [Collection("ViewModel")]
    public class LoginViewModelShould : IClassFixture<LoginViewModelFixture>
    {
        private readonly Mock<IMvxNavigationService> _mockNavigationService;
        private readonly Mock<ILoginService> _mockLoginService;
        private readonly Mock<IChallengeService> _mockChallengeService;
        private readonly Mock<IStorageHelper> _mockStorageHelper;
        private readonly Mock<IMessagingCenter> _mockMessagingCenter;
        private readonly Mock<IPopupNavigationService> _popUpNavigationService;
        private readonly LoginViewModel _loginViewModel;

        public LoginViewModelShould()
        {
            _mockNavigationService = new Mock<IMvxNavigationService>();
            _mockLoginService = new Mock<ILoginService>();
            _mockStorageHelper = new Mock<IStorageHelper>();
            _mockMessagingCenter = new Mock<IMessagingCenter>();
            _mockChallengeService = new Mock<IChallengeService>();
            _popUpNavigationService = new Mock<IPopupNavigationService>();
            _loginViewModel = new LoginViewModel(_mockNavigationService.Object,
                                                   _mockStorageHelper.Object,
                                                   _mockLoginService.Object,
                                                   _mockChallengeService.Object,
                                                   _mockMessagingCenter.Object,
                                                   _popUpNavigationService.Object);
        }


        #region Login
        [Fact]
        public void ShowOnSignInCommand_WithInternetConnection_NavigateToChallenge()
        {
            //Arrange
            var user = UserProvider.GetUserProfile();
            _loginViewModel.Email = user.EmailAddress;
            _loginViewModel.Password = user.Password;
            _mockLoginService.Setup(x=> x.OnSignInAsync(It.IsAny<UserSignInRequest>()))
                .ReturnsAsync(new UserSignInResponse());
            _mockChallengeService.Setup(x => x.ChallengeList())
                 .ReturnsAsync(new List<ChallengeResponse>());

            //Act
            _loginViewModel.LoginCommand.Execute(user);
            
            //Assert
            using (new AssertionScope())
            {
                _loginViewModel.IsLoading.Should().BeFalse();
                _loginViewModel.HideOnLoading.Should().BeTrue();
                _mockNavigationService.Verify(x => x.Navigate<ChallengeViewModel, MvxObservableCollection<Challenge>>(It.IsAny<MvxObservableCollection<Challenge>>(), null, default), Times.Once);
            }
        }
        #endregion


        #region Initialize
        [Fact]
        public async void Initialize_Executes_ShouldSetProperties()
        {
            // Act
            await _loginViewModel.Initialize();

            // Assert
            using (new AssertionScope())
            {
                //_supplierListViewModel.
            }
        }
        #endregion

        #region ButtonsCommands
        [Fact]
        public void ShowInstagramAlertCommand_WithPressingButton_ErrorMessageIsSent()
        {
            //Arrange
            var expectedError = "Instagram";

            //Act
            _loginViewModel.InstagramCommand.Execute();

            //Assert
            using (new AssertionScope())
            {
                _mockMessagingCenter.Verify(messagingCenter =>
                            messagingCenter.Send(It.IsAny<LoginViewModel>(),
                                                 It.Is<string>(title => title == Constants.LoginMsg),
                                                 It.Is<OkActionPopupMessage>(message => message.Title == null)),
                                                 Times.Once);
            }
        }
        [Fact]
        public void ShowForgotPasswordAlertCommand_WithPressingButton_ErrorMessageIsSent()
        {
            //Arrange
            var expectedError = "Olvidaste tu contraseña";
            //Act
            _loginViewModel.InstagramCommand.Execute();

            //Assert
            using (new AssertionScope())
            {
                _mockMessagingCenter.Verify(messagingCenter =>
                            messagingCenter.Send(It.IsAny<LoginViewModel>(),
                                                 It.Is<string>(title => title == Constants.LoginMsg),
                                                 It.Is<OkActionPopupMessage>(message => message.Description == null)),
                                                 Times.Once);
            }
        }

        [Fact]
        public void ShowFacebookAlertCommand_WithPressingButton_ErrorMessageIsSent()
        {
            //Arrange
            var expectedError = "Facebook";
            //Act
            _loginViewModel.InstagramCommand.Execute();

            //Assert
            using (new AssertionScope())
            {
                _mockMessagingCenter.Verify(messagingCenter =>
                            messagingCenter.Send(It.IsAny<LoginViewModel>(),
                                                 It.Is<string>(title => title == Constants.LoginMsg),
                                                 It.Is<OkActionPopupMessage>(message => message.Title == null)),
                                                 Times.Once);
            }
        }



        #endregion

        #region Properties

        [Fact]
        public void CanNavigate_ViewModelIsCreated_ShouldBeReturnTrue()
        {
            // Assert
            using (new AssertionScope())
            {
                _loginViewModel.CanNavigate.Should().BeTrue();
            }
        }
        #endregion
    }
}

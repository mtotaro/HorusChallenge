using MvvmCross.ViewModels;
using MvvmCross.IoC;

using System;
using MvvmCross;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Horus.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Client")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Helper")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterSingleton<IPopupNavigation>(() => { return PopupNavigation.Instance; });

            Mvx.IoCProvider.RegisterSingleton<IMessagingCenter>(() => { return MessagingCenter.Instance; });


            // register the appstart object
            RegisterCustomAppStart<AppStart>();
        }
    }
}

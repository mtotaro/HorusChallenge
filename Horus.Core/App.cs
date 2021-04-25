using MvvmCross.ViewModels;
using MvvmCross.IoC;

using System;

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

           
            // register the appstart object
            RegisterCustomAppStart<AppStart>();
        }
    }
}

using Foundation;
using KeyboardOverlap.Forms.Plugin.iOSUnified;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;
using Xamarin;
using Xamarin.Forms.Platform.iOS;


namespace Horus.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<Core.App, App>, Core.App, App>
    {
   

        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Rg.Plugins.Popup.Popup.Init();
            XF.Material.iOS.Material.Init();
            UINavigationBar.Appearance.TintColor = UIColor.FromRGB(0, 153, 219);
            UINavigationBar.Appearance.Translucent = false;
            uiApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
            IQKeyboardManager.SharedManager.Enable = true;
            //KeyboardOverlapRenderer.Init();
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}

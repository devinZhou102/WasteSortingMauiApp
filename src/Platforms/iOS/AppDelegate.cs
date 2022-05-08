using Acr.UserDialogs;
using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using UIKit;

namespace WasteSortingMauiApp
{
	[Register("AppDelegate")]
	public class AppDelegate : MauiUIApplicationDelegate
	{
		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            return base.FinishedLaunching(application, launchOptions);
        }
    }
}
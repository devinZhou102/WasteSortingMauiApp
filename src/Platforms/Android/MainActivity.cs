using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Microsoft.Maui;
using Android.OS;

namespace WasteSortingMauiApp
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : MauiAppCompatActivity
	{

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            UserDialogs.Init(this);
        }
        //protected override void OnCreate(Bundle bundle)
        //{
        //	UserDialogs.Init(this);
        //}
    }
}
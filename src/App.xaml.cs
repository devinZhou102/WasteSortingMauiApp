using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WasteSortingMauiApp.ML;
using Application = Microsoft.Maui.Controls.Application;

namespace WasteSortingMauiApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
            //MobileNetImageClassifier.Instance.InitAsync();
        }
	}
}

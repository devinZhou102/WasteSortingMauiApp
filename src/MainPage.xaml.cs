using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using WasteSortingMauiApp.ViewModels;

namespace WasteSortingMauiApp
{
	public partial class MainPage : ContentPage
	{

		private readonly MainViewModel mainViewModel;

		public MainPage()
		{
			InitializeComponent();
			mainViewModel = new MainViewModel();
			this.BindingContext = mainViewModel;
			this.Appearing += MainPage_Appearing;
		}

		private bool firstAppear = true;

		private void MainPage_Appearing(object sender, EventArgs e)
		{
			if (firstAppear)
			{
				Debug.WriteLine(" ========= FirstAppear ========= ");
				firstAppear = false;
				mainViewModel.InitDatas();
            }
            else
            {
				Debug.WriteLine(" ========= Appear ========= ");
			}
		}

        protected override bool OnBackButtonPressed()
        {
			return base.OnBackButtonPressed();
        }

    }
}

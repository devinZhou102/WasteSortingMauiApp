using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;
using WasteSortingMauiApp.ML;
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

        public async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    //using FileStream localFileStream = File.OpenWrite(localFilePath);

                   // await sourceStream.CopyToAsync(localFileStream);
                    using var imageMemoryStream = new MemoryStream();
                    await sourceStream.CopyToAsync(imageMemoryStream);

                    Debug.WriteLine(" =========  TakePhoto ============");
                    try
                    {
                        byte[] image = imageMemoryStream.ToArray();
                        var classifier = new MobileNetImageClassifier();
                        
                        await classifier.InitAsync();
                        var result =  await classifier.GetClassificationAsync(image);
                        await DisplayAlert("test", "result: " + result, "确定");
                    }catch(Exception ex)
                    {

                        Debug.WriteLine(" =========  TakePhoto ============ " + ex.StackTrace);
                        Debug.WriteLine(" =========  TakePhoto ============ " + ex.Message);
                        await DisplayAlert("test", "result: Exception 11212" , "确定");
                    }
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TakePhoto();
        }
    }
}

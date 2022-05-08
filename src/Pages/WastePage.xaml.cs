using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using WasteSortingMauiApp.Models;
using WasteSortingMauiApp.ViewModels;

namespace WasteSortingMauiApp.Pages
{
    public partial class WastePage : ContentPage
    {
        private WasteViewModel viewModel;
        public WastePage(WasteModel waste)
        {
            InitializeComponent();
            Title = waste.Name;
            viewModel = new WasteViewModel();
            this.BindingContext = viewModel;
            viewModel.InitDatas(waste);
            this.Appearing += WastePage_Appearing;
        }

        private void WastePage_Appearing(object sender, EventArgs e)
        {
        }
    }
}
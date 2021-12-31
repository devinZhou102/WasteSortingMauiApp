using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteSortingMauiApp.ViewModels;

namespace WasteSortingMauiApp.Pages
{
    public partial class WasteDetailPage : ContentPage
    {
        private readonly WasteDetailViewModel viewModel;

        public WasteDetailPage(string name)
        {
            InitializeComponent();
            viewModel = new WasteDetailViewModel
            {
                WasteName = name
            };
            this.BindingContext = viewModel;
            this.Appearing += WasteDetailPage_Appearing;
        }

        private bool firstAppear = true;

        private void WasteDetailPage_Appearing(object sender, EventArgs e)
        {
            if (firstAppear)
            {
                Task.Run(() => viewModel.Search());
                firstAppear = false;
            }
        }
    }
}
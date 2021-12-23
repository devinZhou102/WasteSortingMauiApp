using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteSortingMauiApp.ViewModels;

namespace WasteSortingMauiApp.Pages
{
    public partial class SuggestListPage : ContentPage
    {

        private SuggestListViewModel viewModel;
        public SuggestListPage(string searchKey)
        {
            InitializeComponent();
            viewModel = new SuggestListViewModel
            {
                SearchKey = searchKey,
                Title = "搜索"
            };
            BindingContext = viewModel;
            
            this.Appearing += SuggestListPage_Appearing;
        }

        private bool firstAppear = true;

        private void SuggestListPage_Appearing(object sender, EventArgs e)
        {
            if (firstAppear)
            {
                viewModel.SearchCommand.Execute("");
                firstAppear = false;
            }
        }
    }
}
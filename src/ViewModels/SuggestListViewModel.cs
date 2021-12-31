using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WasteSortingMauiApp.ApiService;
using WasteSortingMauiApp.Dtos;
using WasteSortingMauiApp.Pages;

namespace WasteSortingMauiApp.ViewModels
{
    public class SuggestListViewModel:BaseViewModel
    {
        private bool isBusy;
        public bool IsBusy 
        { 
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private string title;

        public string Title
        {
            get => title ??= "";
            set => SetProperty(ref title, value);
        }

        private string searchKey;
        public string SearchKey
        {
            get => searchKey ??= "";
            set => SetProperty(ref searchKey, value);
        }


        private ObservableCollection<KeyItemViewModel> keys;
        public ObservableCollection<KeyItemViewModel> Keys 
        { 
            get => keys ??= new ObservableCollection<KeyItemViewModel>(); 
            set => SetProperty(ref keys, value);    
        }

        
        public ICommand SearchCommand => new Command(async () => await Search());



        private async Task WasteClicked(string waste)
        {
            Debug.WriteLine(" =========== " + waste);
            await App.Current.MainPage.Navigation.PushAsync(new WasteDetailPage(waste));
        }


        private async Task Search()
        {
            var service = RefitApiService.GetService<IWasteSearchApi>();
            IsBusy = true;
            var dto = await service.KeySearch(SearchKey);
            IsBusy = false;
            Debug.WriteLine("Search ===== "+JsonConvert.SerializeObject(dto));
            Keys.Clear();
            if (dto != null && dto.kw_arr != null)
            {
                foreach (var item in dto.kw_arr)
                {
                    keys.Add(new KeyItemViewModel
                    {
                        Name = item.Name,
                        ActionKeyTapped = new Action<string>( async(name)=> await WasteClicked(waste: name))
                    });
                }
            }
            else
            {
                
            }
        }


    }
}

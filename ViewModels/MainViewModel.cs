using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WasteSortingMauiApp.Dtos;
using WasteSortingMauiApp.Models;
using WasteSortingMauiApp.Pages;

namespace WasteSortingMauiApp.ViewModels
{
    internal class MainViewModel:BaseViewModel
    {
        private ObservableCollection<WasteItemViewModel> wasteModels;

        public ObservableCollection<WasteItemViewModel> WasteModels
        {
            get => wasteModels ??= new ObservableCollection<WasteItemViewModel>();
            set => SetProperty(ref wasteModels, value);
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


        public ICommand SearchCommand => new Command(async () => await Search());


        private async Task Search()
        {
            Debug.WriteLine("Search  =========== " + SearchKey);
            await  App.Current.MainPage.Navigation.PushAsync(new SuggestListPage(SearchKey));
        }

        private async Task WasteClicked(WasteModel waste)
        {
            Debug.WriteLine(" =========== "+waste.Name);
            await App.Current.MainPage.Navigation.PushAsync(new WastePage(waste));
        }

        public async void InitDatas()
        {
            Title = "垃圾分类助手";
            Debug.WriteLine(" === InitDatas === ");
            WasteModels.Clear();
            var datas = await queryDatas();

            var wetWaste = WasteDatas.WasteModelCreate(WasteType.wet);
            wetWaste.WasteDatas = datas.Item1;
            WasteModels.Add(new WasteItemViewModel{ 
               Number = datas.Item1.Count().ToString(),
               ActionTapped = new Action<WasteModel>( async(waste)=> await WasteClicked(waste)),
               Waste= wetWaste
            });

            var dryWaste = WasteDatas.WasteModelCreate(WasteType.dry);
            dryWaste.WasteDatas = datas.Item2;
            WasteModels.Add(new WasteItemViewModel
            {
                Number = datas.Item2.Count().ToString(),
                ActionTapped = new Action<WasteModel>(async (waste) => await WasteClicked(waste)),
                Waste = dryWaste
            });
            var recyclableWaste = WasteDatas.WasteModelCreate(WasteType.recyclable);
            recyclableWaste.WasteDatas = datas.Item3;
            WasteModels.Add(new WasteItemViewModel{
                Number = datas.Item3.Count().ToString(),
                ActionTapped = new Action<WasteModel>(async (waste) => await WasteClicked(waste)),
                Waste = recyclableWaste
            });
            var harmWaste = WasteDatas.WasteModelCreate(WasteType.harmful);
            harmWaste.WasteDatas = datas.Item4;
            WasteModels.Add(new WasteItemViewModel
            {
                Number = datas.Item4.Count().ToString(),
                ActionTapped = new Action<WasteModel>(async (waste) => await WasteClicked(waste)),
                Waste = harmWaste
            });

        }



        private async Task<ValueTuple<List<WasteDto>, List<WasteDto>, List<WasteDto>, List<WasteDto>>> queryDatas()
        {
            List<WasteDto> wetList = new List<WasteDto>();
            List<WasteDto> dryList = new List<WasteDto>();
            List<WasteDto> recyList = new List<WasteDto>();
            List<WasteDto> harmList = new List<WasteDto>();
            await Task.Run(() =>
            {
                var list = JsonConvert.DeserializeObject<List<WasteDto>>(WasteDatas.datas);
                wetList = list.FindAll((waste) => waste.sortId == 3);
                dryList = list.FindAll((waste) => waste.sortId == 4);
                recyList = list.FindAll((waste) => waste.sortId == 1);
                harmList = list.FindAll((waste) => waste.sortId == 2);
            });
            var result = new ValueTuple<List<WasteDto>, List<WasteDto>, List<WasteDto>, List<WasteDto>>(wetList,dryList,recyList,harmList);
            return await Task.FromResult(result);
        }

    }
}

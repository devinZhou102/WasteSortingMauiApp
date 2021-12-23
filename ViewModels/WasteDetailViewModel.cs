using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteSortingMauiApp.ApiService;
using WasteSortingMauiApp.Dtos;
using WasteSortingMauiApp.Models;

namespace WasteSortingMauiApp.ViewModels
{
    public class WasteDetailViewModel:BaseViewModel
    {

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private WasteModel waste;

        public WasteModel Waste
        {
            get => waste ?? (waste = new WasteModel());
            set => SetProperty(ref waste, value);
        }


        private string wasteName;
        public string WasteName
        {
            get => wasteName ?? (wasteName = "");
            set => SetProperty(ref wasteName, value);
        }


        public async Task Search()
        {
            var service = RefitApiService.GetService<IWasteSearchApi>();
            IsBusy = true;
            var dto = await service.WasteSearch(WasteName);
            IsBusy = false;
            Debug.WriteLine("Search ===== " + JsonConvert.SerializeObject(dto));
            if (dto != null && dto.query_result_type_1 != null)
            {
                var data = dto.query_result_type_1;
                Waste = WasteDatas.WasteModelCreate(data.trashType);
            }
            else
            {

            }
        }
    }
}

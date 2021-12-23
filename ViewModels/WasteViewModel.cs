using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteSortingMauiApp.Dtos;
using WasteSortingMauiApp.Models;

namespace WasteSortingMauiApp.ViewModels
{
    internal class WasteViewModel:BaseViewModel
    {

        private ObservableCollection<WasteDto> wasteDatas;

        public ObservableCollection<WasteDto> WasteDatas
        {
            get => wasteDatas ??= new ObservableCollection<WasteDto>();
            set => SetProperty(ref wasteDatas, value);
        }

        private string description;
        public string Description
        {
            get => description??="";
            set => SetProperty(ref description, value);
        }

        private string include;
        public string Include
        {
            get => include ??= "";
            set=> SetProperty(ref include, value);
        }

        private string notice;
        public string Notice
        {
            get => notice ??= "";
            set => SetProperty (ref notice, value);
        }

        private string wasteIcon;
        public string WasteIcon
        {
            get => wasteIcon ??= "";
            set => SetProperty(ref wasteIcon, value);
        }

        public void InitDatas(WasteModel waste)
        {
            Description = waste.Description;
            Include = waste.Info;
            Notice = waste.Notice;
            WasteIcon = waste.Icon;
            foreach(var item in waste.WasteDatas)
                WasteDatas.Add(item);
        }

    }
}

using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WasteSortingMauiApp.Models;

namespace WasteSortingMauiApp.ViewModels
{
    internal class WasteItemViewModel:BaseViewModel
    {

        private string number;
        public string Number
        {
            get => number ??= "0" ;
            set => SetProperty(ref number, value);
        }

        public WasteModel Waste { get; set; }

        public Action<WasteModel> ActionTapped { get; set; }

        public ICommand TappedCommand => new Command(()=> ActionTapped?.Invoke(Waste));
    }
}

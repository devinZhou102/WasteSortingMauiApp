using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WasteSortingMauiApp.ViewModels
{
    public class KeyItemViewModel:BaseViewModel
    {

        private string name;

        public string Name
        {
            get => name ?? (name = "");
            set => SetProperty(ref name, value);   
        }
        public Action<string> ActionKeyTapped { get; set; }

        public ICommand KeyTappedCommand => new Command(() => ActionKeyTapped?.Invoke(Name));
    }
}

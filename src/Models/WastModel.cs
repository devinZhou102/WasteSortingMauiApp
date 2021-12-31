using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteSortingMauiApp.Dtos;

namespace WasteSortingMauiApp.Models
{

    public enum WasteType { wet, dry, recyclable, harmful }

    public class WasteModel
    {
        public List<WasteDto> WasteDatas { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Info { get; set; }

        public string Notice { get; set; }

        public WasteType Type {  get; set; }


    }
}

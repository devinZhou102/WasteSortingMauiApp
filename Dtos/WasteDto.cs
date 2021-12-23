using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteSortingMauiApp.Dtos
{
    public class WasteDto
    {
        
        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public int sortId { get; set; }
        public string ctime { get; set; }
    }
}

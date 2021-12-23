using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteSortingMauiApp.Dtos
{
    public class WasteDetailDto
    {
        public string TargetId { get; set; }

        public string Name { get; set; }

        public bool is_live_trash { get; set; }
        public int trashType { get; set; }

        public string TypeKey { get; set; }
    } 
}

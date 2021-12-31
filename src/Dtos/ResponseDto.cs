using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteSortingMauiApp.Dtos
{
    public class ResponseDto
    {
        public int query_result { get; set; }

        #region key 查询结果
        public List<string> kw_list { get; set; }

        public List<KeyDto> kw_arr { get; set; }
        #endregion

        #region 详情查询结果
        public WasteDetailDto query_result_type_1 { get; set; }
        #endregion
    }
}

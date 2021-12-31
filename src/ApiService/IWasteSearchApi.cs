using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteSortingMauiApp.Dtos;

namespace WasteSortingMauiApp.ApiService
{
    internal interface IWasteSearchApi
    {
        [Get("/trashTypes_2/Handler/Handler.ashx?a=GET_KEYWORDS&kw={key}")]
        Task<ResponseDto> KeySearch(string key);

        [Get("/trashTypes_2/Handler/Handler.ashx?a=EXC_QUERY&kw={waste}")]
        Task<ResponseDto> WasteSearch(string waste);
    }
}

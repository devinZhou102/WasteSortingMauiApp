using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WasteSortingMauiApp.ApiService
{
    public class RefitApiService
    {

        public static T GetService<T>(string host = Consts.ApiGatewayUrl)
        {
            var client = Create(host);
            return Refit.RestService.For<T>(client);
        }

        private static HttpClient Create(string baseAddress)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress),
                Timeout = TimeSpan.FromSeconds(30),
            };
            return client;
        }
    }
}

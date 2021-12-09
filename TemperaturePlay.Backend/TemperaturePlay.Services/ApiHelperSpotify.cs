using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturePlay.Services
{
    public static class ApiHelperSpotify
    {
        public static HttpClient Client { get; set; }
        public static void Initialize()
        {
            if (Client == null)
                Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "abc123");
        }
    }
}

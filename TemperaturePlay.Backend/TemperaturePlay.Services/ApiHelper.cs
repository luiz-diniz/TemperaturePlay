using System.Net.Http;
using System.Net.Http.Headers;

namespace TemperaturePlay.Services
{
    public static class ApiHelper
    {
        public static HttpClient Client { get; set; }
        public static void Initialize()
        {
            if (Client == null)
                Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaiton/json"));
        }
    }
}

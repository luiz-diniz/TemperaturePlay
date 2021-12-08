using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TemperaturePlay.Services.Models;

namespace TemperaturePlay.Services
{
    public class MusicService : IMusicService
    {
        private string weatherApiKey = "b77e07f479efe92156376a8b07640ced";
        private string spotifyClientId = "08c1a6be652e4fdca07f1815bfd167e4";

        public async Task<string[]> GetByCity(string city)
        {
            try
            {
                if (String.IsNullOrEmpty(city))
                    throw new ArgumentNullException(nameof(city), "City value is null or empty, insert a valid city name.");

                var url = $"http://api.openweathermap.org/data/2.5/weather?q={city }&appid={weatherApiKey}";

                TemperatureResultModel temperatureResult = new TemperatureResultModel();

                using (HttpResponseMessage response = await ApiHelper.Client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        MainResultModel requestResult = await response.Content.ReadAsAsync<MainResultModel>();

                        temperatureResult = requestResult.Main;
                    }
                }

                var currentTemperature = ConvertKelvinToCelcius(temperatureResult.Temp);

                var genre = GetGenreByTemperature(currentTemperature);

                //TODO: Call spotify api
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }          
        }

        public string[] GetByLatitudeLongitude(long latitude, long longitude)
        {
            try
            {
                //TODO: Implementation 
                //api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API key}

                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }           

        private string GetGenreByTemperature(double temperature)
        {
            if (temperature > 30)
                return "Party";
            else if (temperature >= 15 && temperature <= 30)
                return "Pop";
            else if (temperature >= 10 && temperature <= 14)
                return "Rock";
            else
                return "Classical";
        }

        private double ConvertKelvinToCelcius(double kelvinTemp)
        {
            return kelvinTemp - 273.15;
        }
    }
}

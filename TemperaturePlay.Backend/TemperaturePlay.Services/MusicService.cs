using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TemperaturePlay.Services.Models;

namespace TemperaturePlay.Services
{
    public class MusicService : IMusicService
    {
        private string weatherApiKey = "b77e07f479efe92156376a8b07640ced";

        public async Task<string[]> GetByCity(string city)
        {
            try
            {
                if (String.IsNullOrEmpty(city))
                    throw new ArgumentNullException(nameof(city), "City value is null or empty, insert a valid city name.");

                var weatherUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city }&appid={weatherApiKey}";

                TemperatureResultModel temperatureResult = new TemperatureResultModel();

                using (HttpResponseMessage response = await ApiHelper.Client.GetAsync(weatherUrl))
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

                TrackModel tracksResult = new TrackModel();

                var spotifyUrl = $"https://api.spotify.com/v1/recommendations/?seed_genres={genre}";

                using (HttpResponseMessage response = await ApiHelperSpotify.Client.GetAsync(spotifyUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        SpotifyReturnModel requestResult = await response.Content.ReadAsAsync<SpotifyReturnModel>();

                    }
                }



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
                return "party";
            else if (temperature >= 15 && temperature <= 30)
                return "pop";
            else if (temperature >= 10 && temperature <= 14)
                return "rock";
            else
                return "classical";
        }

        private double ConvertKelvinToCelcius(double kelvinTemp)
        {
            return kelvinTemp - 273.15;
        }
    }
}

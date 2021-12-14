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

        public async Task<SpotifyReturnModel> GetByCity(string city)
        {
            try
            {
                if (String.IsNullOrEmpty(city))
                    throw new ArgumentNullException(nameof(city), "City value is null or empty, insert a valid city name.");

                var weatherUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={weatherApiKey}";

                return await GetTracksByWeather(weatherUrl);
            }
            catch (Exception)
            {
                throw;
            }          
        }

        public async Task<SpotifyReturnModel> GetByLatitudeLongitude(long latitude, long longitude)
        {
            try
            {
                var weatherUrl = $"http://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={weatherApiKey}";

                return await GetTracksByWeather(weatherUrl);
            }
            catch (Exception)
            {
                throw;
            }
        } 

        private async Task<SpotifyReturnModel> GetTracksByWeather(string weatherUrl)
        {
            TemperatureResultModel temperatureResult = new TemperatureResultModel();

            using (HttpResponseMessage response = await ApiHelper.Client.GetAsync(weatherUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    MainResultModel requestResult = await response.Content.ReadAsAsync<MainResultModel>();

                    temperatureResult = requestResult.Main;
                }
                else
                {
                    throw new Exception("Error getting city weather info.");
                }
            }

            var currentTemperature = ConvertKelvinToCelcius(temperatureResult.Temp);

            var genre = GetGenreByTemperature(currentTemperature);

            return await GetSpotifyTracksByGenre(genre);
        }

        private async Task<SpotifyReturnModel> GetSpotifyTracksByGenre(string genre)
        {
            var spotifyUrl = $"https://api.spotify.com/v1/recommendations/?seed_genres={genre}";

            using (HttpResponseMessage response = await ApiHelperSpotify.Client.GetAsync(spotifyUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    SpotifyReturnModel requestResult = await response.Content.ReadAsAsync<SpotifyReturnModel>();

                    return requestResult;
                }
                else
                {
                    throw new Exception("Error getting tracks from Spotify API.");
                }
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

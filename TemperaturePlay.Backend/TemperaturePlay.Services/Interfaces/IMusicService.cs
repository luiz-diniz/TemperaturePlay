using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturePlay.Services.Models;

namespace TemperaturePlay.Services
{
    public interface IMusicService
    {
        Task<SpotifyReturnModel> GetByCity(string city);
        Task<SpotifyReturnModel> GetByLatitudeLongitude(long latitude, long longitude);
    }
}

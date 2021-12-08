using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturePlay.Services
{
    public interface IMusicService
    {
        Task<string[]> GetByCity(string city);
        string[] GetByLatitudeLongitude(long latitude, long longitude);
    }
}

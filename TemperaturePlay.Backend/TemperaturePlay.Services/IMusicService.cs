using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturePlay.Services
{
    public interface IMusicService
    {
        string[] GetByCity(string city);
        string[] GetByLatLong(long lat, long longi);
    }
}

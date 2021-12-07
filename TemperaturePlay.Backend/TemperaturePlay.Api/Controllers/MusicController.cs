using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperaturePlay.Api.Controllers
{
    [Route("api/music")]
    public class MusicController : ControllerBase
    {
        [HttpGet]
        [Route("getbycity")]
        public string[] GetByCity(string city)
        {
            return new string[0];
        }

        [HttpGet]
        [Route("getbylatlong")]
        public string[] GetByLatLong(long lat, long longi)
        {
            return new string[0];
        }
    }
}

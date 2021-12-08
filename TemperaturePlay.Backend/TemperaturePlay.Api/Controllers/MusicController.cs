using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturePlay.Services;

namespace TemperaturePlay.Api.Controllers
{
    [Route("api/music")]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet]
        [Route("getbycity/{city}")]
        public string[] GetByCity(string city)
        {
            var result = _musicService.GetByCity(city);

            return result.Result;
        }

        [HttpGet]
        [Route("getbylatlong")]
        public string[] GetByLatLong(long lat, long longi)
        {
            throw new NotImplementedException();
        }
    }
}

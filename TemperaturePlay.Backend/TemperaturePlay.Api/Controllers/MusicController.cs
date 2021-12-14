using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperaturePlay.Services;
using TemperaturePlay.Services.Models;

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
        public SpotifyReturnModel GetByCity(string city)
        {
            return _musicService.GetByCity(city).Result;
        }

        [HttpGet]
        [Route("getbylatlong")]
        public SpotifyReturnModel GetByLatLong(LocationModel location)
        {
            return _musicService.GetByLatitudeLongitude(location.Latitude, location.Longitude).Result;
        }
    }
}

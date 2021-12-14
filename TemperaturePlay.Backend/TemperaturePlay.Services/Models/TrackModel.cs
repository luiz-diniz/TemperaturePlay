using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturePlay.Services.Models
{
    public class TrackModel
    {
        public string Name { get; set; }
        public ArtistModel[] Artists { get; set; }
    }
}

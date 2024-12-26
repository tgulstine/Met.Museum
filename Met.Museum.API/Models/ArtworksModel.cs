using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Met.Museum.API.Models
{
    public class ArtworksModel
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("objectIDs")]
        public long[]? ObjectIDs { get; set; }
    }
}

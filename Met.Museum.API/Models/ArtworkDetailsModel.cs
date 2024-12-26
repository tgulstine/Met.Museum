using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Met.Museum.API.Models
{
    public class ArtworkDetailsModel
    {
        [JsonProperty("objectID")]
        public long? ObjectId { get; set; }

        [JsonProperty("primaryImageSmall")]
        public Uri? PrimaryImageSmall { get; set; }

        [JsonProperty("department")]
        public string? Department { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("artistDisplayName")]
        public string? ArtistDisplayName { get; set; }

        [JsonProperty("artistDisplayBio")]
        public string? ArtistDisplayBio { get; set; }
    }
}

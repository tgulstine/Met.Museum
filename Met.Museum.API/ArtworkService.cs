using Met.Museum.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Met.Museum.API
{
    public class ArtworkService : IArtworkService
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<List<string>?> GetArtworkIdsByDepartment(long departmentId)
        {
            using HttpResponseMessage response =
                await client.GetAsync($"https://collectionapi.metmuseum.org/public/collection/v1/objects?departmentIds=1{departmentId}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var artworksModel = JsonConvert.DeserializeObject<ArtworksModel>(responseBody);

            // department list is nested under parent element
            return artworksModel?.ObjectIDs?.ToList().ConvertAll<string>(x => x.ToString());
        }

        public async Task<ArtworkDetailsModel?> GetArtworkById(string id)
        {
            using HttpResponseMessage response =
                await client.GetAsync($"https://collectionapi.metmuseum.org/public/collection/v1/objects/{id}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var artworkDetailsModel = JsonConvert.DeserializeObject<ArtworkDetailsModel>(responseBody);

            // department list is nested under parent element
            return artworkDetailsModel;
        }
    }
}

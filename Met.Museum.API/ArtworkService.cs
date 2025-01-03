using Met.Museum.API.Models;
using Met.Museum.Data;
using Newtonsoft.Json;
using System.Security.Policy;

namespace Met.Museum.API
{
    public class ArtworkService : IArtworkService
    {
        private IDataService<ErrorLog> _errorLogService { get; set; } = default!;
        private IDataService<SearchHistory> _searchHistoryService { get; set; } = default!;
        private readonly IHttpClientFactory _factory;


        public ArtworkService(IDataService<ErrorLog> errorLogService, IDataService<SearchHistory> searchHistoryService, IHttpClientFactory factory)
        {
            _errorLogService = errorLogService;
            _searchHistoryService = searchHistoryService;
            _factory = factory;
        }

        public async Task<List<string>?> GetArtworkIdsByDepartment(long departmentId)
        {
            var url = $"objects?departmentIds={departmentId}";
            return await GetArtworkIds(url);
        }

        public async Task<List<string>?> GetArtworkIdsByKeyword(string? keyword)
        {
            var url = $"search?q={keyword}";
            return await GetArtworkIds(url);
        }

        private async Task<List<string>?> GetArtworkIds(string url)
        {
            try
            {
                using var client = _factory.CreateClient("Met.Museum");

                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var artworksModel = JsonConvert.DeserializeObject<ArtworksModel>(responseBody);

                await _searchHistoryService.Save(new SearchHistory { DateCreated = DateTime.Now, SearchUrl = new Uri($"{client.BaseAddress}{url}") });

                // department list is nested under parent element
                return artworksModel?.ObjectIDs?.ToList().ConvertAll<string>(x => x.ToString());
            }
            catch (HttpRequestException e)
            {
                await _errorLogService.Save(new ErrorLog { DateCreated = DateTime.Now, ErrorMessage = e.Message });
            }
            return null;
        }

        public async Task<ArtworkDetailsModel?> GetArtworkById(string id)
        {
            try
            {
                using var client = _factory.CreateClient("MetMuseum");

                var url = $"https://collectionapi.metmuseum.org/public/collection/v1/objects/{id}";
                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var artworkDetailsModel = JsonConvert.DeserializeObject<ArtworkDetailsModel>(responseBody);

                await _searchHistoryService.Save(new SearchHistory { DateCreated = DateTime.Now, SearchUrl = new Uri($"{client.BaseAddress}{url}") });

                return artworkDetailsModel;
            }
            catch (HttpRequestException e)
            {
                await _errorLogService.Save(new ErrorLog { DateCreated = DateTime.Now, ErrorMessage = e.Message });
            }
            return null;
        }
    }
}

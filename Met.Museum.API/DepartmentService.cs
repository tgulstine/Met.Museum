using Met.Museum.API.Models;
using Met.Museum.Data;
using Newtonsoft.Json;

namespace Met.Museum.API
{
    public class DepartmentService : IDepartmentService
    {
        private IDataService<ErrorLog> _errorLogService { get; set; } = default!;
        private IDataService<SearchHistory> _searchHistoryService { get; set; } = default!;
        private readonly IHttpClientFactory _factory;

        public DepartmentService(IDataService<ErrorLog> errorLogService, IDataService<SearchHistory> searchHistoryService, IHttpClientFactory factory)
        {
            _errorLogService = errorLogService;
            _searchHistoryService = searchHistoryService;
            _factory = factory;
        }

        public async Task<Department[]?> GetDepartments()
        {
            try
            {
                using var client = _factory.CreateClient("Met.Museum");

                var url = $"departments";

                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var departmentsModel = JsonConvert.DeserializeObject<DepartmentsModel>(responseBody);

                await _searchHistoryService.Save(new SearchHistory { DateCreated = DateTime.Now, SearchUrl = new Uri($"{client.BaseAddress}{url}") });

                return departmentsModel?.Departments;
            }
            catch (HttpRequestException e)
            {
                await _errorLogService.Save(new ErrorLog { DateCreated = DateTime.Now, ErrorMessage = e.Message });
            }
            return null;
        }
    }
}

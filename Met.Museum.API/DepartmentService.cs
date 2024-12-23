using Met.Museum.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Met.Museum.API
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<Department[]?> GetDepartments()
        {
            using HttpResponseMessage response = await client.GetAsync($"https://collectionapi.metmuseum.org/public/collection/v1/departments");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var departmentsModel = JsonConvert.DeserializeObject<DepartmentsModel>(responseBody);

            // department list is nested under parent element
            return departmentsModel?.Departments;
        }
    }
}

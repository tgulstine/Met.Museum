using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Met.Museum.API.Models

{
    public class DepartmentsModel
    {
        [JsonProperty("departments")]
        public Department[]? Departments { get; set; }
    }

    public class Department
    {
        [JsonProperty("departmentId")]
        public long DepartmentId { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }
    }
}

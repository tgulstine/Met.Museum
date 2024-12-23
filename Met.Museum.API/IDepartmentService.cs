
using Met.Museum.API.Models;

namespace Met.Museum.API
{
    public interface IDepartmentService
    {
        Task<Department[]?> GetDepartments();
    }
}
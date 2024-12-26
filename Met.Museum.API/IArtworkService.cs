
using Met.Museum.API.Models;

namespace Met.Museum.API
{
    public interface IArtworkService
    {
        Task<List<string>?> GetArtworkIdsByDepartment(long departmentId);

        Task<ArtworkDetailsModel?> GetArtworkById(string id);
    }
}
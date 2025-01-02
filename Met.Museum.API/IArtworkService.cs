
using Met.Museum.API.Models;

namespace Met.Museum.API
{
    public interface IArtworkService
    {
        Task<List<string>?> GetArtworkIdsByDepartment(long departmentId);

        Task<List<string>?> GetArtworkIdsByKeyword(string? keyword);

        Task<ArtworkDetailsModel?> GetArtworkById(string id);
    }
}
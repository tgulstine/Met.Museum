using Met.Museum.API.Models;
using Met.Museum.API;
using Microsoft.AspNetCore.Components;

namespace Met.Museum.UI.Components.Pages
{
    public partial class ArtworkSearchForm
    {

        [Inject]
        public IDepartmentService _departmentService { get; set; } = default!;

        [Inject]
        public IArtworkService _artworkService { get; set; } = default!;

        Department[]? _departments { get; set; } = default!;

        long _selectedDepartmentId { get; set; }

        List<string>? _matchingArtworkIds { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _departments = await _departmentService.GetDepartments();
        }

        public async Task GetArtworkByDepartmentId()
        {
            _matchingArtworkIds = await _artworkService.GetArtworkIdsByDepartment(_selectedDepartmentId);
        }
    }
}

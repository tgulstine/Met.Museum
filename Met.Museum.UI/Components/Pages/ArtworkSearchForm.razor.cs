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

        List<Department>? _departments { get; set; } = default!;

        long _selectedDepartmentId { get; set; }

        List<string>? _matchingArtworkIds { get; set; }

        int? _currentArtworkIndex { get; set; }

        private const string Department = "Department";
        private const string Keyword = "Keyword";

        List<string> _searchOptions { get; set; } = new List<string> { Department, Keyword };

        string _selectedSearchOption { get; set; } = Department;

        string? _currentKeyword { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _departments = (await _departmentService.GetDepartments())?.ToList();
            _departments?.Insert(0, new Department { DepartmentId = 0, DisplayName = "PLEASE SELECT" });
        }

        public async Task GetArtworkByDepartmentId()
        {
            _matchingArtworkIds = await _artworkService.GetArtworkIdsByDepartment(_selectedDepartmentId);
            _currentArtworkIndex = 0;
        }

        protected void GetPreviousArtwork()
        {
            if (_currentArtworkIndex > 0)
                _currentArtworkIndex--;
        }

        protected void GetNextArtwork()
        {
            if (_matchingArtworkIds is not null && _currentArtworkIndex < (_matchingArtworkIds.Count() - 1))
                _currentArtworkIndex++;
        }

        protected void OnCheckedValueChanged(string value)
        {
            _matchingArtworkIds = null;
            _currentArtworkIndex = null;
            _selectedSearchOption = value;
        }

        protected async Task GetArtworkIdsByKeyword()
        {
            _matchingArtworkIds = await _artworkService.GetArtworkIdsByKeyword(_currentKeyword ?? string.Empty);
            _currentArtworkIndex = 0;
        }

    }
}

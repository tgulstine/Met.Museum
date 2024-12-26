using Met.Museum.API;
using Met.Museum.API.Models;
using Microsoft.AspNetCore.Components;

namespace Met.Museum.UI.Components
{
    public partial class ArtworkDetails
    {
        [Inject]
        public IArtworkService _artworkService { get; set; } = default!;

        [Parameter]
        public string? Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id is not null)
            {
                var result = await _artworkService.GetArtworkById(Id);
            }
        }
    }
}

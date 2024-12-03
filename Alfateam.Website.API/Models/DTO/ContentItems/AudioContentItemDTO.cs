using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Website.API.Models.DTO.ContentItems
{
    public class AudioContentItemDTO : ContentItemDTO
    {
        [ForClientOnly]
        public string AudioPath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

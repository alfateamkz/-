using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Website.API.Models.DTO.ContentItems
{
    public class VideoContentItemDTO : ContentItemDTO
    {
        [ForClientOnly]
        public string VideoPath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;

namespace Alfateam.Website.API.Models.DTO.ContentItems
{
    public class ImageSliderContentItemDTO : ContentItemDTO
    {
        public List<ImageContentItemDTO> Images { get; set; } = new List<ImageContentItemDTO>();

        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}

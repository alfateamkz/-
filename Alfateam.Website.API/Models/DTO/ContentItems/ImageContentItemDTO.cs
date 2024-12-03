using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Website.API.Models.DTO.ContentItems
{
    public class ImageContentItemDTO : ContentItemDTO
    {
        [ForClientOnly]
        public string ImgPath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

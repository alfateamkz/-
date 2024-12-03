using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;

namespace Alfateam.Website.API.Models.DTO.ContentItems
{
    public class ContentDTO : DTOModel<Content>
    {
        public List<ContentItemDTO> Items { get; set; } = new List<ContentItemDTO>();
    }
}

using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.Websites;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites
{
    public class WebsiteDTO : DTOModelAbs<Alfateam.Marketing.Models.Websites.Website>
    {
        public string URL { get; set; }
        public string? Title { get; set; }


        [ForClientOnly]
        public WebsiteGroupDTO Group { get; set; }

        [HiddenFromClient]
        public int GroupId { get; set; }
    }
}

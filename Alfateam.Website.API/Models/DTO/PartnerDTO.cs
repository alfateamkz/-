using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models;
using Alfateam2._0.Models.ContentItems;
using Alfateam.Website.API.Models.DTO.ContentItems;

namespace Alfateam.Website.API.Models.DTO
{
    public class PartnerDTO : AvailabilityDTOModel<Partner>
    {
        public string Title { get; set; }
        [ForClientOnly]
        public string LogoPath { get; set; }
        public ContentDTO Content { get; set; }




    }
}

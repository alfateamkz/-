using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models;
using Alfateam2._0.Models.ContentItems;

namespace Alfateam.Website.API.Models.DTO
{
    public class PartnerDTO : AvailabilityDTOModel<Partner>
    {
        public string Title { get; set; }
        [ForClientOnly]
        public string LogoPath { get; set; }
        public Content Content { get; set; }



        public int MainLanguageId { get; set; }
    }
}

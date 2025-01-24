using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Stats;

namespace Alfateam.Website.API.Models.DTO.Stats
{
    public class SiteVisitDTO : DTOModel<SiteVisit>
    {
        [ForClientOnly]
        public DateTime VisitedAt { get; set; } 


        public string URL { get; set; }
        public string UserAgent { get; set; }

        [ForClientOnly]
        public string? IP { get; set; }


        [ForClientOnly]
        public CountryDTO? Country { get; set; }
        public int? CountryId { get; set; }





        public string Fingerprint { get; set; }

        [ForClientOnly]
        public UserDTO? VisitedBy { get; set; }
        [ForClientOnly]
        public int? VisitedById { get; set; }
    }
}

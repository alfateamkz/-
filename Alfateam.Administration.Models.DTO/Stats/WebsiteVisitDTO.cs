using Alfateam.Administration.Models.Stats;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.DTO.Stats
{
    public class WebsiteVisitDTO : DTOModelAbs<WebsiteVisit>
    {
        [ForClientOnly]
        public DateTime VisitedAt { get; set; }
        public string URL { get; set; }

        public string UserAgent { get; set; }

        [ForClientOnly]
        public string IP { get; set; }
        public string Fingerprint { get; set; }


        [ForClientOnly]
        public string? VisitedByIdentifier { get; set; }
    }
}

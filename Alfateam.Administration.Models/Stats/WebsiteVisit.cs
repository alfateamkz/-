using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Stats
{
    public class WebsiteVisit : AbsModel
    {
        public DateTime VisitedAt { get; set; } = DateTime.UtcNow;
        public string URL { get; set; }

        public string UserAgent { get; set; }
        public string IP { get; set; }
        public string Fingerprint { get; set; }


        public string? VisitedByIdentifier { get; set; }
    }
}

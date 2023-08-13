using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Stats
{
    /// <summary>
    /// Сущность посещения сайта
    /// </summary>
    public class SiteVisit : AbsModel
    {
        public DateTime VisitedAt { get; set; } = DateTime.UtcNow;
        public string URL { get; set; }
        public string UserAgent { get; set; }
        public string? IP { get; set; }
        public Country? Country { get; set; }
        public int? CountryId { get; set; }




        public string Fingerprint { get; set; }
        public User? VisitedBy { get; set; }
        public int? VisitedById { get; set; }
    }
}

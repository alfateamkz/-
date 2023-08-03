using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models
{
    /// <summary>
    /// Сущность карточки партнера на странице партнеров
    /// </summary>
    public class Partner : AvailabilityModel
    {
        public string Title { get; set; }
        public string LogoPath { get; set; }


        public List<PartnerLocalization> Localizations { get; set; } = new List<PartnerLocalization>();
    }
}

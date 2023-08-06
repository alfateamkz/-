using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Portfolios
{
    /// <summary>
    /// Сущность индустрии кейса
    /// </summary>
    public class PortfolioIndustry : AvailabilityModel
    {
        public string Title { get; set; }

        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<PortfolioIndustryLocalization> Localizations { get; set; } = new List<PortfolioIndustryLocalization>();
    }
}

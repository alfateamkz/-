using Alfateam2._0.Models.Abstractions;
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
    public class PortfolioIndustry : AbsModel
    {
        public string Title { get; set; }

        public List<PortfolioIndustryLocalization> Localizations { get; set; } = new List<PortfolioIndustryLocalization>();
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTOs.Portfolios;
using Alfateam2._0.Models.Localization.Items.Portfolios;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Portfolios
{
    public class PortfolioIndustryLocalizationEditModel : LocalizationEditModel<PortfolioIndustryLocalization>
    {
        public string Title { get; set; }
    }
}

using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTOs.Portfolios;
using Alfateam2._0.Models.Localization.Items.Portfolios;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Portfolios
{
    public class PortfolioCategoryLocalizationEditModel : LocalizationEditModel<PortfolioCategoryLocalization>
    {
        public string Title { get; set; }
    }
}

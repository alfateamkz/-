using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Portfolios
{
    public class PortfolioLocalizationEditModel : LocalizationEditModel<PortfolioLocalization>
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }
    }
}

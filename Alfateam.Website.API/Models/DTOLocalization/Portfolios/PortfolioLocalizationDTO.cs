using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.ContentItems;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.DTOLocalization.Portfolios
{
    public class PortfolioLocalizationDTO : LocalizationDTOModel<PortfolioLocalization>
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public ContentDTO Content { get; set; }
    }
}

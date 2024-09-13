using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam2._0.Models.Localization.Items.Portfolios;

namespace Alfateam.Website.API.Models.DTOLocalization.Portfolios
{
    public class PortfolioCategoryLocalizationDTO : DTOModel<PortfolioCategoryLocalization>
    {
        public string Title { get; set; }
    }
}

using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.DTO.Portfolios
{
    public class PortfolioCategoryDTO : AvailabilityDTOModel<PortfolioCategory>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);


    }
}

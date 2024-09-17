using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.DTO.Portfolios
{
    public class PortfolioIndustryDTO : AvailabilityDTOModel<PortfolioIndustry>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);

        public int MainLanguageId { get; set; }
    }
}

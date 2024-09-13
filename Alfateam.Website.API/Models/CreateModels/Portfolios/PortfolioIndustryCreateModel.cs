using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.CreateModels.Portfolios
{
    public class PortfolioIndustryCreateModel : CreateModel<PortfolioIndustry>
    {
        public string Title { get; set; }

        public int MainLanguageId { get; set; }
    }
}

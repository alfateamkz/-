using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.EditModels.Portfolios
{
    public class PortfolioIndustryMainEditModel : EditModel<PortfolioIndustry>
    {
        public string Title { get; set; }

        public int MainLanguageId { get; set; }
    }
}

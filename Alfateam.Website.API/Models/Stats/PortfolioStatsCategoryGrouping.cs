using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Models.Stats
{
    public class PortfolioStatsCategoryGrouping
    {
        public PortfolioCategoryDTO Category { get; set; }
        public List<PortfolioStatsCategoryGroupingDay> Days { get; set; } = new List<PortfolioStatsCategoryGroupingDay>();
    }
}

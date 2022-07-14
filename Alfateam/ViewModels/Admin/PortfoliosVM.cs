using Alfateam.Database.Models;
using Alfateam.Database.Models.Portfolios;

namespace Alfateam.ViewModels.Admin
{
    public class PortfoliosVM
    {
        public Portfolio NewPortfolio { get; set; } = new Portfolio();





        public List<PortfolioCategory> PortfolioCategories { get; set; } = new List<PortfolioCategory>();
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}

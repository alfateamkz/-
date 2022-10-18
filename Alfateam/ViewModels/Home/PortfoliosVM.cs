using Alfateam.Database.Models;
using Alfateam.Database.Models.Portfolios;

namespace Alfateam.ViewModels.Home
{
    public class PortfoliosVM
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();



        public PortfolioCategory SelectedCategory { get; set; }
        public List<PortfolioCategory> PortfolioCategories { get; set; } = new List<PortfolioCategory>();

        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }


        public int CategoryId { get; set; }
    }
}

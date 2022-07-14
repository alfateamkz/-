using Alfateam.Database.Models;
using Alfateam.Database.Models.Portfolios;
using Alfateam.Database.Models.SitePagesTexts;

namespace Alfateam.ViewModels
{
    public class IndexVM
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public List<Post> News { get; set; } = new List<Post>();



        public GeneralTexts GeneralTexts { get; set; } = new GeneralTexts();
        public LandingTexts LandingTexts { get; set; } = new LandingTexts();


        public Order NewOrder { get; set; } = new Order();
    }
}

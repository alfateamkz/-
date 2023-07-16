using Alfateam.Database.Models;
using Alfateam.Database.Models.NewPosts;
using Alfateam.Database.Models.Portfolios;
using Alfateam.Database.Models.SitePagesTexts;

namespace Alfateam.ViewModels
{
    public class IndexVM
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public List<NewPost> News { get; set; } = new List<NewPost>();


        public List<Partner> Partners { get; set; } = new List<Partner>();
        public List<Teammate> Teammates { get; set; } = new List<Teammate>();



        public Order NewOrder { get; set; } = new Order();
    }
}

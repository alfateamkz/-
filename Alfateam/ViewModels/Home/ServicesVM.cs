using Alfateam.Database.Models;
using Alfateam.Database.Models.Promotions;
using Alfateam.Database.Models.SitePagesTexts;

namespace Alfateam.ViewModels.Home
{
    public class ServicesVM
    {
        public List<Promotion> Promotions { get; set; } = new List<Promotion>();
        public Order NewOrder { get; set; } = new Order();
    }
}

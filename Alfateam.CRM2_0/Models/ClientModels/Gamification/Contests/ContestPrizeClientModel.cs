using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Contests
{
    public class ContestPrizeClientModel : ClientModel<ContestPrize>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }


        public double Rating { get; set; }
        public double Coins { get; set; }
    }
}

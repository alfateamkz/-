using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.Contests
{
    public class ContestPrizeEditModel : EditModel<ContestPrize>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public double Rating { get; set; }
        public double Coins { get; set; }
    }
}

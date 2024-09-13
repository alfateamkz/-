using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Contests
{
    public class ContestPrizeCreateModel : CreateModel<ContestPrize>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public double Rating { get; set; }
        public double Coins { get; set; }
    }
}

using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.General
{
    public class LevelCriteriaClientModel : ClientModel<LevelCriteria>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public double Rating { get; set; }
        public double Coins { get; set; }
    }
}

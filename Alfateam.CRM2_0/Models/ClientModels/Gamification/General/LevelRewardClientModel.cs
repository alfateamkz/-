using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.General
{
    public class LevelRewardClientModel : ClientModel<LevelReward>
    {
        public double Rating { get; set; }
        public double Coins { get; set; }
    }
}

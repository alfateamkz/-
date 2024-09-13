using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.General;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.General
{
    public class LevelRewardCreateModel : CreateModel<LevelReward>
    {
        public double Rating { get; set; }
        public double Coins { get; set; }
    }
}

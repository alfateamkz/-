using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.General;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.General
{
    public class LevelCreateModel : CreateModel<Level>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public LevelRewardCreateModel Reward { get; set; }

        public override bool IsValid()
        {
            if(Reward == null)
            {
                return false;
            }
            return base.IsValid() && Reward.IsValid();
        }

        public override Level Create()
        {
            var level = base.Create();
            level.Reward = Reward.Create();

            return level;
        }
    }
}

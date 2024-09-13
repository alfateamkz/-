using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Achievements;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.Achievements
{
    public class AchievementEditModel : EditModel<Achievement>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }


        public double Rating { get; set; }
        public double Reward { get; set; }
    }
}

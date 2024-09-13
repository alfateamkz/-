using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Achievements;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Achievements
{
    public class AchievementClientModel : ClientModel<Achievement>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public AchievementCategoryClientModel Category { get; set; }


        public double Rating { get; set; }
        public double Reward { get; set; }
    }
}

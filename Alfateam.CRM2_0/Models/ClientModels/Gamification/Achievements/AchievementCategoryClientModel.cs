using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Achievements;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.Achievements
{
    public class AchievementCategoryClientModel : ClientModel<AchievementCategory>
    {
        public string Title { get; set; }
    }
}

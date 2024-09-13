using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Achievements;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.Achievements
{
    public class AchievementCategoryEditModel : EditModel<AchievementCategory>
    {
        public string Title { get; set; }
    }
}

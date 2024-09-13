using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Achievements;

namespace Alfateam.CRM2_0.Models.CreateModels.Gamification.Achievements
{
    public class AchievementCategoryCreateModel : CreateModel<AchievementCategory>
    {
        public string Title { get; set; }
    }
}

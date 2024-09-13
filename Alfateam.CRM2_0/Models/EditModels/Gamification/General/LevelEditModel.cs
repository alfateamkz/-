using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.General;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.General
{
    public class LevelEditModel : EditModel<Level>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}

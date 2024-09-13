using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Gamification.General
{
    public class LevelClientModel : ClientModel<Level>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
    }
}

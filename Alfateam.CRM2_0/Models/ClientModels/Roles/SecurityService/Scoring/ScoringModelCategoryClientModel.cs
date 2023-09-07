using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.SecurityService.Scoring
{
    public class ScoringModelCategoryClientModel : ClientModel<ScoringModelCategory>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}

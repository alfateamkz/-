using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Scoring;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.SecurityService.Checking
{
    public class SSCheckingScoringResultCreateModel : CreateModel<SSCheckingScoringResult>
    {
        public int ScoringModelId { get; set; }

        public List<SSCheckingScoringResultQGroup> QuestionGroups { get; set; } = new List<SSCheckingScoringResultQGroup>();
    }
}

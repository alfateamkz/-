using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.HR
{
    public class CandidateInterviewDecisionCreateModel : CreateModel<CandidateInterviewDecision>
    {
        public CandidateInterviewDecisionType Type { get; set; }
        public string Comment { get; set; }
    }
}

using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.HR
{
    public class CandidateCallCreateModel : CreateModel<CandidateCall>
    {
        public DateTime InitialPlannedTime { get; set; }
    }
}

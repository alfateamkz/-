using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.HR
{
    public class CandidateCallEditModel : EditModel<CandidateCall>
    {
        public DateTime InitialPlannedTime { get; set; }
    }
}

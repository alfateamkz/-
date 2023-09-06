using Alfateam.CRM2_0.Models.EditModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;

namespace Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.HR
{
    public class CandidateEditModel : UserEditModel
    {
        public CandidateStatus Status { get; set; }
    }
}

using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;

namespace Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.HR
{
    public class CandidateClientModel : UserClientModel
    {
        public CandidateStatus Status { get; set; }
    }
}

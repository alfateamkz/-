using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseInitDetailsClientModel : ClientModel<CorruptionCaseInitDetails>
    { 
        public UserClientModel Applicant { get; set; }
        public UserClientModel CreatedBy { get; set; }
    }
}

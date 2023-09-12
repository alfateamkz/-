using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Compliance
{
    public abstract class CorruptionCaseParticipantEditModel : EditModel<CorruptionCaseParticipant>
    {
        public string Comment { get; set; }
    }
}

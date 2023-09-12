using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Compliance
{
    public abstract class CorruptionCaseParticipantCreateModel : CreateModel<CorruptionCaseParticipant>
    {
        public string Comment { get; set; }
    }
}

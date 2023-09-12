using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseSideEditModel : EditModel<CorruptionCaseSide>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public CorruptionCaseSideType Type { get; set; }
        public bool IsInitiator { get; set; }
    }
}

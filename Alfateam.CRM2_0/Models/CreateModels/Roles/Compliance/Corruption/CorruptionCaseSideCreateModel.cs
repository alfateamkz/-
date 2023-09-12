using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseSideCreateModel : CreateModel<CorruptionCaseSide>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public CorruptionCaseSideType Type { get; set; } = CorruptionCaseSideType.Bribetakers;
        public bool IsInitiator { get; set; }
    }
}

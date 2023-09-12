using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseResultCreateModel : CreateModel<CorruptionCaseResult>
    {
        public string Description { get; set; }
    }
}

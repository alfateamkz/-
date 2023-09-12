using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseEditModel : EditModel<CorruptionCase>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

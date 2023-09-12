using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseActionClientModel : ClientModel<CorruptionCaseAction>
    {
        public CorruptionCaseSideClientModel Side { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
    }
}

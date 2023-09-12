using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseActionCreateModel : CreateModel<CorruptionCaseAction>
    {
        public int SideId { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
    }
}

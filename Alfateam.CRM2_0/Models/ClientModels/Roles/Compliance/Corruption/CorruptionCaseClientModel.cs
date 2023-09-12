using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseClientModel : ClientModel<CorruptionCase>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CorruptionCaseInitDetailsClientModel InitDetails { get; set; }


        public CorruptionCaseResultClientModel? Result { get; set; }
    }
}

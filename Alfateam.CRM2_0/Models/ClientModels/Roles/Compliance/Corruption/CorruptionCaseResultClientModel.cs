using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption
{
    public class CorruptionCaseResultClientModel : ClientModel<CorruptionCaseResult>
    {
        /// <summary>
        /// Ответственный за решение
        /// </summary>
        public UserClientModel DecisionMaker { get; set; }
        public string Description { get; set; }
    }
}

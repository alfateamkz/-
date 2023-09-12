using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Fraud
{
    public class FraudPreventionMethodClientModel : ClientModel<FraudPreventionMethod>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

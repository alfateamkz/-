using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Fraud
{
    public class FraudDescriptionClientModel : ClientModel<FraudDescription>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public FraudCategoryClientModel Category { get; set; }
        public int CategoryId { get; set; }

        public List<FraudPreventionMethodClientModel> PreventionMethods { get; set; } = new List<FraudPreventionMethodClientModel>();
    }
}

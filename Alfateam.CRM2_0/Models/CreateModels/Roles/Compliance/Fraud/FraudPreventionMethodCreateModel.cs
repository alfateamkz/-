using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Fraud
{
	public class FraudPreventionMethodCreateModel : CreateModel<FraudPreventionMethod>
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}

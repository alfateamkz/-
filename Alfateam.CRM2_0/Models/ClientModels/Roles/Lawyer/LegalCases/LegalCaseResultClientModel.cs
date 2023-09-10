using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.LegalCases
{
	public class LegalCaseResultClientModel : ClientModel<LegalCaseResult>
	{
		public string Decision { get; set; }
		public string Comment { get; set; }
	}
}

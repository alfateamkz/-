using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Scripting
{
	public class SalesScriptEditModel : EditModel<SalesScript>
	{
		public string Title { get; set; }
		public string? Description { get; set; }
	}
}

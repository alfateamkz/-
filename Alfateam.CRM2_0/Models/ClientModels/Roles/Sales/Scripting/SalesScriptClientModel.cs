using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Scripting
{
	public class SalesScriptClientModel : ClientModel<SalesScript>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		/// <summary>
		/// Начало скрипта
		/// </summary>
		public SalesScriptBlockClientModel Start { get; set; }
	}
}

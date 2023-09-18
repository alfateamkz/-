using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Scripting
{
	public class SalesScriptCreateModel : CreateModel<SalesScript>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		/// <summary>
		/// Начало скрипта
		/// </summary>
		public SalesScriptBlock Start { get; set; }
	}
}

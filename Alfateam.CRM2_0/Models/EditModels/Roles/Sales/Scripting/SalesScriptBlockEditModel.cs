using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Scripting
{
	public class SalesScriptBlockEditModel : EditModel<SalesScriptBlock>
	{
		/// <summary>
		/// Текст фразы
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Тип блока
		/// </summary>
		public SalesScriptBlockType Type { get; set; }
	}
}

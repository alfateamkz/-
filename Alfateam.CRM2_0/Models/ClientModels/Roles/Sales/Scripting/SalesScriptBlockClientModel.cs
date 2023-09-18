using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales.Scripting
{
	public class SalesScriptBlockClientModel : ClientModel<SalesScriptBlock>
	{
		/// <summary>
		/// Текст фразы
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Тип блока
		/// </summary>
		public SalesScriptBlockType Type { get; set; }

		/// <summary>
		/// Разветвления скрипта
		/// </summary>
		public List<SalesScriptBlockClientModel> Nodes { get; set; } = new List<SalesScriptBlockClientModel>();
	}
}

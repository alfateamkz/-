using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Scripting;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Sales.Scripting
{
	public class SalesScriptBlockCreateModel : CreateModel<SalesScriptBlock>
	{
		/// <summary>
		/// Текст фразы
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Тип блока
		/// </summary>
		public SalesScriptBlockType Type { get; set; } = SalesScriptBlockType.Intro;

		/// <summary>
		/// Разветвления скрипта
		/// </summary>
		public List<SalesScriptBlockCreateModel> Nodes { get; set; } = new List<SalesScriptBlockCreateModel>();

		public override SalesScriptBlock Create()
		{
			//TODO: SalesScriptBlockCreateModel Create()
			return base.Create();
		}

		public override bool IsValid()
		{
			//TODO: SalesScriptBlockCreateModel IsValid()
			return base.IsValid();
		}
	}
}

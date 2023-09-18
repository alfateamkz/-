using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing
{
	/// <summary>
	/// Запрос на проверку статуса задачи. Например, работник выполнил задачу, он отмечает ее выполненной, но сразу выполненной задача не становится
	/// Менеджер проверяет и после принимает решение
	/// </summary>
	public class AdCampaignItemTaskCheckRequest : AbsModel
	{
		public User From { get; set; }
		public int FromId { get; set; }


		public AdCampaignItemTaskStatus Status { get; set; }
		public string? Comment { get; set; }


		public AdCampaignItemTaskCheckRequestResult? Result { get; set; }
		public int? ResultId { get; set; }




		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int BaseAdCampaignItemTaskId { get; set; }
	}
}

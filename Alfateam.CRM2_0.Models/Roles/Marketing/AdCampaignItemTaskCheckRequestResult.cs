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
	/// Результат запроса на проверку статуса задачи
	/// </summary>
	public class AdCampaignItemTaskCheckRequestResult : AbsModel
	{
		public User SetBy { get; set; }
		public int SetById { get; set; }


		public AdCampaignItemTaskStatus Status { get; set; }
		public string? Comment { get; set; }
	}
}

﻿using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Sales.Conversation
{
	public class CustomerCallEditModel : EditModel<CustomerCall>
	{
		public string Phone { get; set; }
		public CustomerCallStatus Status { get; set; }



		public DateTime PlannedAt { get; set; }
		public DateTime? StartedAt { get; set; }
		public DateTime? EndedAt { get; set; }


		public string? Comment { get; set; }
	}
}

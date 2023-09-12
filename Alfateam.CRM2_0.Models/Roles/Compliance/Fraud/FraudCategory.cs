﻿using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Fraud
{
	public class FraudCategory : AbsModel
	{
		public string Title { get; set; }
		public string? Description { get; set; }




		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int ComplianceDepartmentId { get; set; }
	}
}

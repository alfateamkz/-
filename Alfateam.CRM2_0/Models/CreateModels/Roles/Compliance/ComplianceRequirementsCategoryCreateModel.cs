﻿using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance
{
	public class ComplianceRequirementsCategoryCreateModel : CreateModel<ComplianceRequirementsCategory>
	{
		public string Title { get; set; }
		public string Description { get; set; }
	}
}

﻿using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts.Resolutions
{
	public class ConflictResolutionAlgorithmBlockEditModel : EditModel<ConflictResolutionAlgorithmBlock>
	{
		public string Title { get; set; }
		public string? Description { get; set; }

		public ConflictResolutionAlgorithmBlockType Type { get; set; }
	}
}

﻿using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions;

namespace Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts.Resolutions
{
	public class ConflictResolutionAlgorithmCreateModel : CreateModel<ConflictResolutionAlgorithm>
	{
		public string Title { get; set; }
		public string Description { get; set; }


		/// <summary>
		/// Начало алгоритма урегулирования конфликта
		/// </summary>
		public ConflictResolutionAlgorithmBlockCreateModel StartBlock { get; set; }

		public override bool IsValid()
		{
			bool isValid = base.IsValid();

			//TODO: сделать рекурсию

			return isValid;
		}

		public override ConflictResolutionAlgorithm Create()
		{
			var entity = base.Create();

			//TODO: сделать рекурсию

			return entity;
		}
	}
}

using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Participants
{
	/// <summary>
	/// Участник конфликта без привязки к CRM
	/// </summary>
	public class InfoConflictParticipant : ConflictParticipant
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }


		public Country Country { get; set; }
		public int CountryId { get; set; }
	}
}

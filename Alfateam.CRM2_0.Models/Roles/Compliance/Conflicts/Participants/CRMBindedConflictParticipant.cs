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
	/// Участник конфликта с привязкой к CRM
	/// </summary>
	public class CRMBindedConflictParticipant : ConflictParticipant
	{
		public User User { get; set; }
		public int UserId { get; set; }
	}
}

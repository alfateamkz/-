using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;

namespace Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Lawyer
{
	public abstract class TrialProcessParticipantCreateModel : CreateModel<TrialProcessParticipant>
	{
		public string Description { get; set; }
		public string? Comment { get; set; }



		/// <summary>
		/// Роль участника в судебном процессе
		/// </summary>
		public TrialProcessParticipantType Role { get; set; } = TrialProcessParticipantType.KeyPerson;


		/// <summary>
		/// Дата, с которой человек стал учавствовать в судебном процессе
		/// </summary>
		public DateTime ConnectedAt { get; set; }

		/// <summary>
		/// Слушание, с которого человек стал учавствовать в судебном процессе(например, со второго слушания подключился адвокат)
		/// Если ConnectedAtHearing == null, то человек стал участвовать в судебном процессе с самого начала(до первого слушания)
		/// </summary>
		public int? ConnectedAtHearingId { get; set; }
	}
}

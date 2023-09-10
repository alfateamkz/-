using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Litigations;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Participants;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer
{


    [JsonConverter(typeof(JsonKnownTypesConverter<TrialProcessParticipant>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(CRMTrialProcessParticipant), "CRMTrialProcessParticipant")]
    [JsonKnownType(typeof(InfoTrialProcessParticipant), "InfoTrialProcessParticipant")]
    /// <summary>
    /// Базовая сущность участника судебного процесса
    /// </summary>
    public class TrialProcessParticipant : AbsModel
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
        public TrialHearing? ConnectedAtHearing { get; set; }
		public int? ConnectedAtHearingId { get; set; }



		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int TrialProcessSideId { get; set; }


	}
}

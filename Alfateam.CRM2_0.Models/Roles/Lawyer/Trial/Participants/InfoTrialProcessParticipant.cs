using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Participants
{
    /// <summary>
    /// Cущность участника судебного процесса без привязки к пользователю CRM
    /// </summary>
    public class InfoTrialProcessParticipant : TrialProcessParticipant
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

        public Country Country { get; set; }
		public int CountryId { get; set; }
	}
}

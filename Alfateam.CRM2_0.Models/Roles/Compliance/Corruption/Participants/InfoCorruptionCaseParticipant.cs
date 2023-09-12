using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Corruption.Participants
{
    /// <summary>
    /// Участник коррупционного инцидента без привязки к CRM
    /// </summary>
    public class InfoCorruptionCaseParticipant : CorruptionCaseParticipant
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}

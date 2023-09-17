using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Сущность стороны конфликта
    /// </summary>
    public class ConflictSide : AbsModel
    {
        public string Title { get; set; }   
        public string? Description { get; set; }
        public List<ConflictParticipant> Participants { get; set; } = new List<ConflictParticipant>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ConflictId { get; set; }

	}
}

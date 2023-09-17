using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Сущность необходимого действия, которое было определено по результату конфликта
    /// </summary>
    public class ConflictResultAction : AbsModel
    {
        public string Title { get; set; }   
        public string? Description { get; set; }

        public DateTime Deadline { get; set; }
        public ConflictResultActionStatus Status { get; set; } = ConflictResultActionStatus.NotPerformed;



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ConflictResultId { get; set; }

	}
}

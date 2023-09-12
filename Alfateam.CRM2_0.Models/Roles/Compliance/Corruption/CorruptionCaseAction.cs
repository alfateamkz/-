using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Corruption
{
    /// <summary>
    /// Сущность действия по коррупционному инциденту
    /// </summary>
    public class CorruptionCaseAction : AbsModel
    {
        public CorruptionCaseSide Side { get; set; }
        public int SideId { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int CorruptionCaseId { get; set; }

    }
}

using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Assessment.Risks
{
    /// <summary>
    /// Сущность мероприятия по устранению последствий риска
    /// </summary>
    public class RiskConsequenceAction : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Срок исполнения мероприятия
        /// </summary>
        public TimeSpan Term { get; set; }
    }
}

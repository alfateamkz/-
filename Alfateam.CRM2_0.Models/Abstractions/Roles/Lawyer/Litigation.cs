using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer
{
    /// <summary>
    /// Базовая сущность судебного разбирательства
    /// Наследуемые классы описывают конституционный, уголовный, гражданский, арбитражный и административный судебный процесс
    /// </summary>
    public abstract class Litigation : AbsModel
    {
        /// <summary>
        /// Стороны судебного процесса. Как правило две(истец и ответчик)
        /// </summary>
        public List<TrialProcessSide> Sides { get; set; } = new List<TrialProcessSide>();


        public List<TrialRequest> TrialRequests { get; set; } = new List<TrialRequest>();
        public List<TrialHearing> Hearings { get; set; } = new List<TrialHearing>();
        public TrialProcessResult? Result { get; set; }
    }
}

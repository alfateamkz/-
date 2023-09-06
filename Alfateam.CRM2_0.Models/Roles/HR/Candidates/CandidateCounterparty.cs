using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.Candidates
{
    /// <summary>
    /// Модель кандидата-контрагента
    /// </summary>
    public class CandidateCounterparty : Candidate
    {
        public Company Company { get; set; }
        public int CompanyId { get; set; }


        /// <summary>
        /// Информация о субподрячиках/работниках контрагента, которых можно изучить
        /// Например: у работников - проверить резюме, у субподрядчиков - репутацию
        /// </summary>
        public List<CounterpartySubparty> Subparties { get; set; } = new List<CounterpartySubparty>();

    }
}

using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Enums.Roles.Staff.Counterparties;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff.Counterparties
{
    /// <summary>
    /// Модель контрагента
    /// </summary>
    public class Counterparty : Worker
    {
        public Company Company { get; set; }

        public CounterpartyStatus Status { get; set; } = CounterpartyStatus.Active;
        public CounterpartyCooperationType CooperationType { get; set; } = CounterpartyCooperationType.ByProject;
        public CounterpartyPaymentScheme PaymentScheme { get; set; }
        

        /// <summary>
        /// Информация о субподрячиках/работниках контрагента
        /// </summary>
        public List<CounterpartySubparty> Subparties { get; set; } = new List<CounterpartySubparty>();

    }
}

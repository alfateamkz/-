using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties
{
    /// <summary>
    /// Информация о компании-субподрядчике контрагента, который учавствует в разработке проектов 
    /// </summary>
    public class CompanySubparty : CounterpartySubparty
    {
        public Company Company { get; set; }

        /// <summary>
        /// Субподрядчики/работники субподрядчика
        /// </summary>
        public List<CounterpartySubparty> Subparties { get; set; } = new List<CounterpartySubparty>();
    }
}

using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties
{
    /// <summary>
    /// Информация о компании-субподрядчике/работнике контрагента, который учавствует в разработке проектов 
    /// С привязкой к CRM
    /// </summary>
    public class BindedWorkerSubparty : CounterpartySubparty
    {
        public Worker Worker { get; set; }
    }
}

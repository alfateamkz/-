using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions
{
    /// <summary>
    /// Транзакция с привязкой к работнику/контрагенту
    /// </summary>
    public class StaffTransaction : Transaction
    {
        public User User { get; set; }

        //TODO: сделать заказы)))
    }
}

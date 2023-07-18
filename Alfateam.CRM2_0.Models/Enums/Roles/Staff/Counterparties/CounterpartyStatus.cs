using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Staff.Counterparties
{
    /// <summary>
    /// Статус контрагента
    /// </summary>
    public enum CounterpartyStatus
    {
        Active = 1, //Работает
        Break = 2, //Перерыв
        Terminated = 3, //Расторгнуто сотрудничество
        Lost = 4, //Пропал
        Dispute = 5, //Спор
        Reserve = 6, //Резерв
    }
}

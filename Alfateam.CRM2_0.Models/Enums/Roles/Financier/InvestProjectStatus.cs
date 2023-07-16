using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Financier
{
    /// <summary>
    /// Статус нашего инвест проекта
    /// </summary>
    public enum InvestProjectStatus
    {
        Research = 1, //Исследование
        Active = 2, //Активный проект
        Completed = 3, //Проект собрал необходимое количество денег
        DepositsPaid = 4, //Выплаты дивидендов произведены(в случае если депозитарные условия выплаты)
        DividendsPayments = 5, //Выплаты дивидендов(в случае если долевое участие)
        CanceledAfterStart = 6, //Проект отменен после старта
        CanceledAfterStartAndReturned = 7, //Проект отменен после старта и инвестиции возвращены
        Inexpedient = 8, //Проект отклонен как нецелесообразный
        Canceled = 9, //Проект отменен
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Accountance
{
    /// <summary>
    /// Тип транзакции с привязкой к работнику/контрагенту
    /// </summary>
    public enum WorkerTransactionType
    {
        Salary = 1, //ЗП
        ProjectFee = 2, //Гонорар по проекту
        PaymentForHours = 3, //Оплата за фактически затраченные часы работы
        UpfrontPayment = 4, //Предоплата

        Other = 999, //Прочее
    }
}

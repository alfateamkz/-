using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Staff.Counterparties
{
    /// <summary>
    /// Тип схемы расчета с контрагентами
    /// </summary>
    public enum CounterpartyPaymentSchemeType
    {
        PartialUpfrontPaymentForMilestone = 1, //Частичная предоплата за этап
        FullUpfrontPaymentForMilestone = 2, //Полная предоплата за этап
        PostPaymentForMilestone = 3, //Постоплата за этап
        PartialUpfrontPaymentForProject = 4, //Частичная предоплата за проект
        FullUpfrontPaymentForProject = 5, //Полная предоплата за проект
        PostPaymentForProject = 6, //Постоплата за проект
    }
}

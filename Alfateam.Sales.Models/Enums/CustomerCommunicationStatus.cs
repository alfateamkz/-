using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Enums
{
    public enum CustomerCommunicationStatus
    {
        Planned = 1, //Запланирована
        Active = 2, //Встреча идет прямо сейчас
        Completed = 3, //Завершена
        Failed = 4, //Несостоялась
        Cancelled = 5, //Отменен
        Postponed = 6 //Перенесена
    }
}

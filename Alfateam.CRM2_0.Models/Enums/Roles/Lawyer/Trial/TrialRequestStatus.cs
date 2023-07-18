using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial
{
    /// <summary>
    /// Статус заявления в суд
    /// </summary>
    public enum TrialRequestStatus
    {
        Preparing = 1, //Подготовка
        Pending = 2, //Подано в суд, в ожидании
        Reviewed = 3, //Рассмотрено судом
        Canceled = 4, //Отозвано 
    }
}

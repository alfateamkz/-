using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.HR
{
    /// <summary>
    /// Статус вакансии
    /// </summary>
    public enum JobVacancyStatus
    {
        Active = 1, //Активная вакансия
        Interviews = 2,//На этапе собеседований, новых не ищем кандидатов 
        Closed = 3, //Вакансия закрыта, сотрудник найден
        Canceled = 4, //Вакансия отменена
        Suspended = 5 //Вакансия приостановлена
    }
}

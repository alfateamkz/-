using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer
{
    /// <summary>
    /// Статус поручения юристу
    /// </summary>
    public enum LawyerTaskStatus
    {
        Waiting = 1, //В ожидании юриста, который примет поручение
        InWork = 2, //В работе, юрист назначен
        Checking = 3, //Проверка, нужно дать подтверждение или отправить в доработку
        Completed = 4, //Поручение выполнено
        Revision = 5, //Доработка поручения
        Canceled = 6, //Поручение отменено сотрудником, который создал поручение 
    }
}

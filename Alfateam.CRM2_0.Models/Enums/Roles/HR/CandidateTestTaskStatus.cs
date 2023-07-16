using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.HR
{
    /// <summary>
    /// Статус тестового задания для кандидата
    /// </summary>
    public enum CandidateTestTaskStatus
    {
        Active = 1, //Задача активна
        SetCompleted = 2, //Кандидат указал задание выполненным
        Checking = 3, //Проверка задачи
        Passed = 4, //Задача выполнена
        NotPassed = 5, //Задача не выполнена
        Failed = 6, //Задача не была решена
        Postponed = 7, //Перенесена
    }
}

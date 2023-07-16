using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales
{
    /// <summary>
    /// Статус задачи по заказу
    /// </summary>
    public enum OrderTaskStatus 
    {
        NotStarted = 1, //Не начата
        Analysis = 2, //Анализ задачи
        WorkingOn = 3, //В работе
        Testing = 4, //Тестирование
        Checking = 5, //Проверка выполнения
        Revision = 6, //Доработка
        Completed = 7, //Завершена
        Postponed = 8 //Отложена
    }
}

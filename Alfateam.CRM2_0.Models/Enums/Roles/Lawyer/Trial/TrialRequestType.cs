using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial
{
    /// <summary>
    /// Тип заявления в суд
    /// </summary>
    public enum TrialRequestType
    {
        Lawsuit = 1, //Исковое заявление
        LevelUp = 2 //Заявление в вышестоящую инстанцию(апелляция, кассация и т.п.)
    }
}

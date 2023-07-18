using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Data
{
    /// <summary>
    /// Сущность, описывающая статус выполнения критерия для перехода на следующий уровень
    /// конкретного пользователя в системе геймификации
    /// </summary>
    public class UserLevelCriteriaInfo : AbsModel
    {
        public LevelCriteria Criteria { get; set; }
        public bool IsCompleted { get; set; }

    }
}

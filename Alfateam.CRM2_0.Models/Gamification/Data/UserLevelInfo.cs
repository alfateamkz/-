using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Data
{
    /// <summary>
    /// Сущность, описывающая уровень конкретного пользователя в системе геймификации
    /// </summary>
    public class UserLevelInfo : AbsModel
    {
        public Level Level { get; set; }
        public int LevelId { get; set; }


        public DateTime GotLevelDate { get; set; } = DateTime.UtcNow;

        public List<UserLevelCriteriaInfo> RequirementInfos { get; set; } = new List<UserLevelCriteriaInfo>();
    }
}

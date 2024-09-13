using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification
{
    /// <summary>
    /// Пользователь в системе геймификации
    /// </summary>
    public class GamificationUser : AbsModel
    {

        public List<GamificationUserAchievement> Achievements { get; set; } = new List<GamificationUserAchievement>();
        public GamificationUserData Data { get; set; }
        public UserLevelInfo LevelInfo { get; set; }



        public List<GamificationEvent> Events { get; set; } = new List<GamificationEvent>();
        public List<GamificationUserTask> Tasks { get; set; } = new List<GamificationUserTask>();
    }
}

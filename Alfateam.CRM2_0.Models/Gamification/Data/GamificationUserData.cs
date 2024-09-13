using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Data
{
    /// <summary>
    /// Данные пользователя в системе геймификации
    /// </summary>
    public class GamificationUserData : AbsModel
    {

        public double Coins { get; set; }
        public double Rating { get; set; }

        public UserLevelInfo LevelInfo { get; set; }


        public List<GamificationUserTask> Tasks { get; set; } = new List<GamificationUserTask>();
        public List<GamificationUserAchievement> Achievements { get; set; } = new List<GamificationUserAchievement>();
        public List<ShopOrder> Orders { get; set; } = new List<ShopOrder>();


        public List<GamificationEvent> Events { get; set; } = new List<GamificationEvent>();
        public List<GamificationFine> Fines { get; set; } = new List<GamificationFine>();
    }
}

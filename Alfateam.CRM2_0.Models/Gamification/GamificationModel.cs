using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Achievements;
using Alfateam.CRM2_0.Models.Gamification.Contests;
using Alfateam.CRM2_0.Models.Gamification.General;
using Alfateam.CRM2_0.Models.Gamification.Shop;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification
{
    /// <summary>
    /// Сущность геймификации в целом
    /// </summary>
    public class GamificationModel : AbsModel
    {

        #region Achievements
        public List<Achievement> Achievements { get; set; } = new List<Achievement>();
        public List<AchievementCategory> AchievementCategories { get; set; } = new List<AchievementCategory>();

        #endregion

        #region Contests

        public List<Contest> Contests { get; set; } = new List<Contest>();

        #endregion

        #region General
        public List<Level> Levels { get; set; } = new List<Level>();

        #endregion

        #region Shops

        #region Order
        public List<ShopOrder> ShopOrders { get; set; } = new List<ShopOrder>();
        #endregion

        public List<ShopCategory> ShopCategories { get; set; } = new List<ShopCategory>();
        public List<ShopItem> ShopItems { get; set; } = new List<ShopItem>();
  
        #endregion 




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int OrganizationId { get; set; }
    }
}

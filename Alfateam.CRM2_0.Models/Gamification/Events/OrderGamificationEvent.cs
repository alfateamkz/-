using Alfateam.CRM2_0.Models.Abstractions.Gamification;
using Alfateam.CRM2_0.Models.Gamification.Achievements;
using Alfateam.CRM2_0.Models.Gamification.Shop.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Events
{
    /// <summary>
    /// Сущность события в системе геймификации с привязкой к заказу
    /// </summary>
    public class OrderGamificationEvent : GamificationEvent
    {
        public ShopOrder Order { get; set; }
    }
}

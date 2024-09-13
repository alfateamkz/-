using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Gamification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Shop
{
    /// <summary>
    /// Модель товара в магазине геймификации
    /// </summary>
    public class ShopItem : AbsModel
    { 
        public ShopItemType Type { get; set; } 


        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }


        public double Price { get; set; }
        public double Rating { get; set; }


        public ShopCategory Category { get; set; }
        public int CategoryId { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int GamificationModelId { get; set; }
    }
}

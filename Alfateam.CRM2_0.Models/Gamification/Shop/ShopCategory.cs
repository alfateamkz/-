using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification.Shop
{
    /// <summary>
    /// Модель категории товара в магазине геймификации
    /// </summary>
    public class ShopCategory : AbsModel
    { 
        public string Title { get; set; }
    }
}

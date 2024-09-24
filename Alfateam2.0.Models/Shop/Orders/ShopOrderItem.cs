using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop.Orders
{
    /// <summary>
    /// Сущность позиции заказ в магазине
    /// </summary>
    public class ShopOrderItem : AbsModel
    {
        public ShopProduct Item { get; set; }
        public int ItemId { get; set; }


        public double Amount { get; set; }
        public double PriceForOne { get; set; }

        [NotMapped]
        public double Sum 
        {
            get
            {
                double val = 0;
                val += Amount * PriceForOne;

                foreach (var selectedOption in SelectedModifiers.SelectMany(o => o.SelectedOptions))
                {
                    val += selectedOption.Sum * Amount;
                }

                return val;
            }
            
        }

        public List<ShopOrderItemModifier> SelectedModifiers { get; set; } = new List<ShopOrderItemModifier>();


        [JsonIgnore]
        public int ShopOrderId { get; set; }
    }
}

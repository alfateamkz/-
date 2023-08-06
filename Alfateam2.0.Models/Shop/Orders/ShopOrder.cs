﻿using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
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
    /// Сущность заказа в магазине
    /// </summary>
    public class ShopOrder : AbsModel
    {
        public User CreatedBy { get; set; }
        public Address Address { get; set; }


        public Currency? Currency { get; set; }
        public int? CurrencyId { get; set; }


        [NotMapped]
        public double SumWithoutDiscount
        {
            get
            {
                double val = 0;

                foreach(var item in Items)
                {
                    val += item.Sum;
                }

                return val;
            }
        }


        public ShopOrderStatus Status { get; set; } = ShopOrderStatus.Basket;
        public List<ShopOrderItem> Items { get; set; } = new List<ShopOrderItem>();
        public string? TrackingURL { get; set; }


        [JsonIgnore]
        public Promocode? UsedPromocode { get; set; }

        public double? DiscountByPromocode { get; set; }

        /// <summary>
        /// Список всех оплат(неуспешные и одна успешная)
        /// </summary>
        public List<ShopOrderPayment> Payments { get; set; } = new List<ShopOrderPayment>();
        public ShopOrderReturn? Return { get; set; }
    }
}

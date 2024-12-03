using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Promocodes
{
    /// <summary>
    /// Сущность промокода с фиксированным значением
    /// </summary>
    public class PricePromocode : Promocode
    {

        [NotMapped]
        public override PromocodeType Type => PromocodeType.Fixed;

        public PricingMatrix Discount { get; set; }
        public int DiscountId { get; set; }

    }
}

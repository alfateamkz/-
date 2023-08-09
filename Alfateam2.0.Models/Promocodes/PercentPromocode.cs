using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Promocodes
{
    /// <summary>
    /// Сущность промокода с процентным значением
    /// </summary>
    public class PercentPromocode : Promocode
    {
        [NotMapped]
        public override PromocodeType Type => PromocodeType.Percent;

        public double Percent { get; set; }
    }
}

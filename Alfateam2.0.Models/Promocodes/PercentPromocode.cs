using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
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
        public double Percent { get; set; }
    }
}

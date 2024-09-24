using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Promocodes
{
    /// <summary>
    /// Сущность использованного промокода
    /// </summary>
    public class UsedPromocode : AbsModel
    {
        public Promocode Promocode { get; set; }
        public int PromocodeId { get; set; }
    }
}

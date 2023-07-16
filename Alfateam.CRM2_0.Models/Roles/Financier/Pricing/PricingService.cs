using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Pricing
{
    /// <summary>
    /// Модель услуги в модели ценообразования, которую оказывает компания
    /// </summary>
    public class PricingService : AbsModel
    {
        public Service Service { get; set; }
        public double Price { get; set; }
    }
}

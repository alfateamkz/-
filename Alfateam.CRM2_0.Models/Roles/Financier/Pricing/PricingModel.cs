using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Financier;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Pricing
{
    /// <summary>
    /// Модель ценообразования
    /// </summary>
    public class PricingModel : AbsModel
    {
        public PricingModelStatus Status { get; set; } = PricingModelStatus.Reseacrh;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public List<PricingService> Services { get; set; } = new List<PricingService>();
    }
}

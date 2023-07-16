using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Pricing
{
    public class PricingGroup : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<PricingService> Services { get; set; } = new List<PricingService>();
    }
}

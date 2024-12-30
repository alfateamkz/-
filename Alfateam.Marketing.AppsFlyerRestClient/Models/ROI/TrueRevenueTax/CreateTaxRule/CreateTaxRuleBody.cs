using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.TrueRevenueTax.CreateTaxRule
{
    public class CreateTaxRuleBody
    {
        public List<TrueRevenueTaxRule> taxes { get; set; } = new List<TrueRevenueTaxRule>();
    }
}

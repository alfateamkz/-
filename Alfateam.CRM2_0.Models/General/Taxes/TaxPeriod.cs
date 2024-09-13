using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Taxes
{
    public class TaxPeriod : AbsModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public DateTime NeedToDeclareTaxesBefore { get; set; }
        public DateTime NeedToPayTaxesBefore { get; set; }
    }
}

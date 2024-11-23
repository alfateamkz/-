using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class CurrencyAndValue : AbsModel
    {
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }


        public double Value { get; set; }
    }
}

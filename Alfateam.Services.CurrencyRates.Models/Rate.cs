using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Services.CurrencyRates.Models
{
    public class Rate : AbsModel
    {
        public DateTime ActualAt { get; set; }


        public string From { get; set; }
        public string To { get; set; }
        public double Value { get; set; }
    }
}

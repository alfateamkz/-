using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class Currency : AbsModel
    {
        public string Title { get; set; }
        public string CurrencyCode { get; set; }
        public string Symbol { get; set; }
    }
}

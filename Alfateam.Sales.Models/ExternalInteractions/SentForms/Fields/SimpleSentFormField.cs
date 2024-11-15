using Alfateam.Sales.Models.Abstractions.ExtInterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.SentForms.Values
{
    public class SimpleSentFormField : SentWebsiteFormField
    {
        public string Value { get; set; }
    }
}

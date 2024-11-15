using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.Inputs
{
    public class NumberWebsiteFormInput : WebsiteFormInput
    {
        public bool IsDouble { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public double? Step { get; set; }


        //public override bool IsValid(SentWebsiteFormField field)
        //{
        //    bool isValid = base.IsValid(field);

        //    if(field is not SimpleSentFormField) return false;

        //    double val = 0;
        //    if(!double.TryParse((field as SimpleSentFormField).Value, out val))
        //    {
        //        return false;
        //    }

        //    if(MinValue != null && val < MinValue) return false;
        //    if(MaxValue != null && val > MaxValue) return false;

        //    return isValid;
        //}
    }
}

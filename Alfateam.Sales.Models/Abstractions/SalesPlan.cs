using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using Alfateam.Sales.Models.Plan.Types;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<SalesPlan>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ByFunnelsSalesPlan), "ByFunnelsSalesPlan")]
    [JsonKnownType(typeof(ByManagersSalesPlan), "ByManagersSalesPlan")]
    [JsonKnownType(typeof(ForAllCompanySalesPlan), "ForAllCompanySalesPlan")]
    public class SalesPlan : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
        public SalesPlanTargetType Target { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int SalesPlanningId { get; set; }



        public virtual bool CompliesWithOtherPlan(SalesPlan other)
        {
            if(this.GetType() != other.GetType()) return false;
            if(this.Target != other.Target) return false;

            return true;
        }
    }
}

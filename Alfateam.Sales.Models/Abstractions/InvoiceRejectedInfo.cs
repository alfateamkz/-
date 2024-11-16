using Alfateam.Core;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using Alfateam.Sales.Models.Invoices.RejectedInfo;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<InvoiceRejectedInfo>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ByCustomerInvoiceRejectedInfo), "ByCustomerInvoiceRejectedInfo")]
    [JsonKnownType(typeof(ByManagerInvoiceRejectedInfo), "ByManagerInvoiceRejectedInfo")]
    public class InvoiceRejectedInfo : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Comment { get; set; }
    }
}

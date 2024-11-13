using Alfateam.Core;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using Alfateam.Sales.Models.Invoices;
using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Alfateam.Sales.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<InvoicePaidInfo>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(InvoiceAcquiringPaidInfo), "InvoiceAcquiringPaidInfo")]
    [JsonKnownType(typeof(InvoiceCryptoPaidInfo), "InvoiceCryptoPaidInfo")]
    [JsonKnownType(typeof(InvoiceManualPaidInfo), "InvoiceManualPaidInfo")]
    public class InvoicePaidInfo : AbsModel
    {
        public DateTime PaidAt { get; set; }
    }
}

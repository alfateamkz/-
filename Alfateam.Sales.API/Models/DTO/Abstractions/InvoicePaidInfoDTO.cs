using Alfateam.Sales.API.Models.DTO.Invoices.PaidInfo;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<InvoicePaidInfoDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(InvoiceAcquiringPaidInfoDTO), "InvoiceAcquiringPaidInfo")]
    [JsonKnownType(typeof(InvoiceCryptoPaidInfoDTO), "InvoiceCryptoPaidInfo")]
    [JsonKnownType(typeof(InvoiceManualPaidInfoDTO), "InvoiceManualPaidInfo")]
    public class InvoicePaidInfoDTO : DTOModelAbs<InvoicePaidInfo>
    {
        public DateTime PaidAt { get; set; }
    }
}

using Alfateam.Sales.API.Models.DTO.Invoices.RejectedInfo;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Invoices.RejectedInfo;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions
{


    [JsonConverter(typeof(JsonKnownTypesConverter<InvoiceRejectedInfoDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ByCustomerInvoiceRejectedInfoDTO), "ByCustomerInvoiceRejectedInfo")]
    [JsonKnownType(typeof(ByManagerInvoiceRejectedInfoDTO), "ByManagerInvoiceRejectedInfo")]
    public class InvoiceRejectedInfoDTO : DTOModelAbs<InvoiceRejectedInfo>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Comment { get; set; }
    }
}

using Alfateam.Sales.API.Models.DTO.Invoices.Placeholders;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Invoices.Placeholders;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<InvoiceTemplatePlaceholderDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(InvoiceCustomerTemplatePlaceholderDTO), "InvoiceCustomerTemplatePlaceholder")]
    [JsonKnownType(typeof(InvoiceItemTemplatePlaceholderDTO), "InvoiceItemTemplatePlaceholder")]
    [JsonKnownType(typeof(InvoiceManualTemplatePlaceholderDTO), "InvoiceManualTemplatePlaceholder")]
    public class InvoiceTemplatePlaceholderDTO :DTOModelAbs<InvoiceTemplatePlaceholder>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string PlaceholderName { get; set; }
        public bool IsRequired { get; set; }
    }
}

using Alfateam.Core;
using Alfateam.Sales.Models.BusinessProposals.Placeholders;
using Alfateam.Sales.Models.Invoices.Placeholders;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<InvoiceTemplatePlaceholder>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(InvoiceCustomerTemplatePlaceholder), "InvoiceCustomerTemplatePlaceholder")]
    [JsonKnownType(typeof(InvoiceItemTemplatePlaceholder), "InvoiceItemTemplatePlaceholder")]
    [JsonKnownType(typeof(InvoiceManualTemplatePlaceholder), "InvoiceManualTemplatePlaceholder")]
    public class InvoiceTemplatePlaceholder : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string PlaceholderName { get; set; }
        public bool IsRequired { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int InvoiceTemplateId { get; set; }
    }
}

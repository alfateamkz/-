using Alfateam.Core;
using Alfateam.Sales.Models.BusinessProposals.Placeholders;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<BPTemplatePlaceholder>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(BPCustomerTemplatePlaceholder), "BPCustomerTemplatePlaceholder")]
    [JsonKnownType(typeof(BPManualTemplatePlaceholder), "BPManualTemplatePlaceholder")]
    public class BPTemplatePlaceholder : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string PlaceholderName { get; set; }
        public bool IsRequired { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessProposalTemplateId { get; set; }
    }
}

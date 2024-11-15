using Alfateam.Core;
using Alfateam.Sales.Models.ExternalInteractions;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Values;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions.ExtInterations
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ExternalInteraction>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CommunitationButtonsExtInteration), "CommunitationButtonsExtInteration")]
    [JsonKnownType(typeof(WebsiteFormExtInteration), "WebsiteFormExtInteration")]
    public class ExternalInteraction : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string UniqueIntegrationURL { get; set; } = $"{DateTime.UtcNow.ToString("dd-MM-yyyy")}-{Guid.NewGuid().ToString()}";
        public string Title { get; set; }






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }


        public virtual string GetSelfTypeName(string langCode = "RU")
        {
            return "Абстрактный тип";
        }

    }

}

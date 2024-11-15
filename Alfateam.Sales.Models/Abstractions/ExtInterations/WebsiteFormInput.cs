using Alfateam.Core;
using Alfateam.Sales.Models.ExternalInteractions.Inputs;
using Alfateam.Sales.Models.Invoices.PaidInfo;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions.ExtInterations
{
    [JsonConverter(typeof(JsonKnownTypesConverter<WebsiteFormInput>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CheckBoxWebsiteFormInput), "CheckBoxWebsiteFormInput")]
    [JsonKnownType(typeof(NumberWebsiteFormInput), "NumberWebsiteFormInput")]
    [JsonKnownType(typeof(RadioWebsiteFormInput), "RadioWebsiteFormInput")]
    [JsonKnownType(typeof(RangeWebsiteFormInput), "RangeWebsiteFormInput")]
    [JsonKnownType(typeof(TextWebsiteFormInput), "TextWebsiteFormInput")]
    [JsonKnownType(typeof(FileWebsiteFormInput), "FileWebsiteFormInput")]
    public class WebsiteFormInput : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
        public string Placeholder { get; set; }


        public string FieldName { get; set; }


        public bool IsRequired { get; set; }






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int WebsiteFormExtInterationId { get; set; }


        //public virtual bool IsValid(SentWebsiteFormField field)
        //{
        //    return field != null;
        //}
    }
}

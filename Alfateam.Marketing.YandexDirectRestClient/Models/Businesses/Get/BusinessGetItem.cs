using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Businesses.Get
{
    public class BusinessGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("ProfileUrl")]
        public string ProfileURL { get; set; }

        [JsonProperty("InternalUrl")]
        public string InternalURL { get; set; }

        [JsonProperty("IsPublished")]
        public YesNoEnum IsPublished { get; set; }

        [JsonProperty("MergedIds")]
        public ArrayOfLong MergedIds { get; set; }

        [JsonProperty("Rubric")]
        public string Rubric { get; set; }

        [JsonProperty("Urls")]
        public ArrayOfString URLs { get; set; }

        [JsonProperty("HasOffice")]
        public YesNoEnum HasOffice { get; set; }
    }
}

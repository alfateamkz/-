using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData
{
    public class AttributeType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("group")]
        public AttributeTypeGroup Group { get; set; }

        [JsonProperty("humanized")]
        public string Humanized { get; set; }
    }
}

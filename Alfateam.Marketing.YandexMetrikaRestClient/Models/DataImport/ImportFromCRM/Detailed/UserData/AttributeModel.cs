using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData
{
    public class AttributeModel
    {
        [JsonProperty("multivalued")]
        public bool Multivalued { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("humanized")]
        public string Humanized { get; set; }

        [JsonProperty("type_group")]
        public AttributeTypeGroup TypeGroup { get; set; }

        [JsonProperty("type_humanized")]
        public string TypeHumanized { get; set; }

        [JsonProperty("type_name")]
        public string TypeName { get; set; }
    }
}

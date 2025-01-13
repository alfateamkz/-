using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class FilterSchemaItemFields
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public FieldTypeEnum Type { get; set; }

        [JsonProperty("EnumProps")]
        public EnumFieldStructure EnumProps { get; set; }

        [JsonProperty("NumberProps")]
        public NumberFieldStructure NumberProps { get; set; }

        [JsonProperty("StringProps")]
        public StringFieldStructure StringProps { get; set; }

        [JsonProperty("Operators")]
        public List<OperatorStructure> Operators { get; set; } = new List<OperatorStructure>();
    }
}

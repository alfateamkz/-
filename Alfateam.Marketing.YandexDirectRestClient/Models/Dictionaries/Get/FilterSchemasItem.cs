using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class FilterSchemasItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Fields")]
        public List<FilterSchemaItemFields> Fields { get; set; } = new List<FilterSchemaItemFields>();
    }
}
